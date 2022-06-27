using UnityEngine;
using System;
using System.Diagnostics;
using System.Threading;
#if UNITY_5_3 || UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif
using OpenCVCompact;
using Rect = OpenCVCompact.Rect;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Debug = UnityEngine.Debug;

namespace FaceControlSDK
{
    [RequireComponent(typeof(WebCamTextureToMatHelperSDK))]
    public class FaceInterface : MonoBehaviour
    {
        //페이스 컨트롤러용 변수
        public bool isFaceAnalyzerOn = false;
        //
        /// <summary>
        /// 감정 포인트 글자 표시(Angry, Happy, Surprise, Info Text On/Off
        /// </summary>
        [SerializeField] private bool ExpressionTextOn;
        
        /// <summary>
        /// Pose View On/Off
        /// </summary>
        public bool poseViewOn = true;
        /// <summary>
        /// Face Landmark View On/Off
        /// </summary>
        public bool faceLandmarkOn = true;
        //Related To DNN Model
        dnn.DNNUtils dnnUtils;
        
        //For Image Capturing
        WebCamTextureToMatHelperSDK webCamTextureToMatHelper;
        Texture2D videoTexture;
        
        //Related To Model File Path
        string dnnLndmrkDetectModelFilePath;
        string dnnFaceAttr7ModelFilePath;
        string dnnFaceExpModelFilePath;

        //Related To Function
        int lndmrkMode = 1; //0: 51, 1: 84
        int lndmrkLevel = 3;
        bool kalmanOrNot = true;
        bool attribOrNot = true;

        // for Main Process
        public OpenCVCompact.Mat mat4Display;
        public OpenCVCompact.Mat mat4DisplayTexture;
        public OpenCVCompact.Mat grayMat4Process;
        public OpenCVCompact.Mat mat4Process;
        public OpenCVCompact.Mat lndmrk;
        public OpenCVCompact.Rect detectRect;
        public int[] faceRect = new int[4];
        public OpenCVCompact.MatOfRect detectionResult;
        public dnn.DNNUtils.FaceObject[] faceObjects;
        public dnn.DNNUtils.Object[] objects;

        // for Thread Process
        public bool didUpdateTheEstimationResult = false;
        bool multiThreadOrNot = false;
        bool isThreadRunning = false;
        bool isThreadInitialized = false;
        System.Object sync = new System.Object();
        OpenCVCompact.Mat img4Thread;
        OpenCVCompact.Mat lndmrk4Thread;
        
        //Face Expression(Happy, Angry, Sad, Surprise) 감정 표현 변수
        public OpenCVCompact.Mat probExp = new OpenCVCompact.Mat();
        // public List<double> probExpList = new List<double>();
        public Dictionary<string, double> probExpDict = new Dictionary<string, double>();
        
        //Related To Head Pose 머리 기울기/방향
        public OpenCVCompact.Point[] poseBox;
        public float headRoll;
        public float headPitch;
        public float headYaw;
        
        //Related To Landmark Performance
        float lndmrkEstScore;


        string faceAttrTextThread;
        int lndmrkSize = 3;
        
        //Bool Variables
        bool faceAttrEstMultiThread = false;
        bool faceExpEstMultiThread = true;
        bool _shouldEstimateInMultiThread = false;
        bool webCamReady = false;
        
        bool shouldEstimateInMultiThread
        {
            get
            {
                lock (sync)
                    return _shouldEstimateInMultiThread;
            }
            set
            {
                lock (sync)
                    _shouldEstimateInMultiThread = value;
            }
        }
        
        bool IsThreadRunning
        {
            get
            {
                lock (sync)
                    return isThreadRunning;
            }
            set
            {
                lock (sync)
                    isThreadRunning = value;
            }
        }

        bool _shouldStopThread = false;
        

        bool shouldStopThread
        {
            get
            {
                lock (sync)
                    return _shouldStopThread;
            }
            set
            {
                lock (sync)
                    _shouldStopThread = value;
            }
        }
        void Start()
        {
            webCamTextureToMatHelper = gameObject.GetComponent<WebCamTextureToMatHelperSDK>();
            InitModel();
            InitVariable();
            Run();
            OnAttrib_Runtime_Click();
            
        }

        // Update is called once per frame
        void Update()
        {
            if (webCamTextureToMatHelper.IsPlaying() && webCamTextureToMatHelper.DidUpdateThisFrame())
            {
                    isFaceAnalyzerOn = true;
                    mat4Display = webCamTextureToMatHelper.GetMat();
                    mat4Display.copyTo(mat4Process);
                    
                        LandmarkDetect();
                    
                    if (didUpdateTheEstimationResult == true)
                    {
                        if (multiThreadOrNot == true)
                        {
                            if (!shouldEstimateInMultiThread)
                            {
                                mat4Process.copyTo(img4Thread);
                                lndmrk.copyTo(lndmrk4Thread);

                                shouldEstimateInMultiThread = true;
                            }
                        }
                    }
            }
            if (didUpdateTheEstimationResult)
            {
                didUpdateTheEstimationResult = false;

                
                    if (lndmrk != null)
                    {
                        //랜드마크 점 그려주는 기능
                        if (faceLandmarkOn)
                        {
                            for (int i = 0; i < lndmrk.cols(); i++)
                            {
                                Imgproc.circle(mat4Display, new Point(lndmrk.get(0, i)[0], lndmrk.get(1, i)[0]), lndmrkSize, new Scalar(255, 30, 0, 255), -1);
                            }
                        }
                        
                        // 감정 포인트 표시 기능
                        if (faceExpEstMultiThread == true)
                        {
                            int max_exp_idx = -1;
                            double max_exp_score = -1;
                            for (int idx = 0; idx < dnnUtils.dnnFaceExpLabels_7.Count; idx++)
                            {
                             if (max_exp_score < probExp.get(0, idx)[0])
                             {
                                    max_exp_idx = idx;
                                    max_exp_score = probExp.get(0, idx)[0];
                             }
                            }
                
                            
                            
                            for (int idx = 0; idx < dnnUtils.dnnFaceExpLabels_7.Count; idx++)
                            {
                                    probExpDict[dnnUtils.dnnFaceExpLabels_7[idx]]=probExp.get(0, idx)[0];
                                    if (idx == max_exp_idx)
                                    {
                                        string desc = dnnUtils.dnnFaceExpLabels_7[idx] + " : " + probExp.get(0, idx)[0].ToString("F3");
                                        //감정 포인트 글자 표시
                                        if (ExpressionTextOn)
                                        {
                                            Imgproc.putText(mat4Display, desc, new Point((int)(mat4Display.cols() * 0.050 + 0.5), (int)(mat4Display.rows() * 0.05 + 0.5) + 25 * idx), Core.FONT_HERSHEY_SIMPLEX, 0.85, new Scalar(255, 0, 0, 255), 2);
                                        }
                                    }
                                    else
                                    {
                                        string desc = dnnUtils.dnnFaceExpLabels_7[idx] + " : " + probExp.get(0, idx)[0].ToString("F3");
                                        //감정 포인트 글자 표시
                                        if (ExpressionTextOn)
                                        {
                                            Imgproc.putText(mat4Display, desc,
                                                new Point((int) (mat4Display.cols() * 0.050 + 0.5),
                                                    (int) (mat4Display.rows() * 0.05 + 0.5) + 25 * idx),
                                                Core.FONT_HERSHEY_SIMPLEX, 0.85, new Scalar(255, 255, 255, 255), 2);
                                        }
                                    }
                                
                            }
                            
                            
                        }

                        
                        if (poseViewOn == true)
                        {
                            if (lndmrkEstScore > 0.4)
                            {
                                DrawPose(mat4Display, headRoll * 3.141592f / 180.0f, headPitch * 3.141592f / 180.0f, headYaw * 3.141592f / 180.0f, 50);
                                DrawHeadPoseBox(mat4Display, poseBox);
                            }
                        }
                
                        
                    
                }
            }
            if (webCamReady == true)
            {
                if (mat4Display.rows() == videoTexture.height)
                {
                    mat4Display.copyTo(mat4DisplayTexture);                    
                    Utils.matToTexture2D(mat4DisplayTexture, videoTexture);
                }
            }
        }
        //Related to WebcamTexture
        public void OnWebCamTextureToMatHelperInitialized()
        {
            OpenCVCompact.Mat webCamTextureMat = webCamTextureToMatHelper.GetMat();

            videoTexture = new Texture2D(webCamTextureMat.cols(), webCamTextureMat.rows(), TextureFormat.RGBA32, false);

            gameObject.GetComponent<Renderer>().material.mainTexture = videoTexture;    
            //gameObject.GetComponent<Renderer>().material.mainTexture = mat4DisplayTexture;
            
            gameObject.transform.localScale = new Vector3(webCamTextureMat.cols(), webCamTextureMat.rows(), 1);

            mat4Display = new OpenCVCompact.Mat(webCamTextureMat.rows(), webCamTextureMat.cols(), OpenCVCompact.CvType.CV_8UC4);
            mat4DisplayTexture = new OpenCVCompact.Mat(webCamTextureMat.rows(), webCamTextureMat.cols(), OpenCVCompact.CvType.CV_8UC4);

            UnityEngine.Debug.Log("Screen.width " + Screen.width + " Screen.height " + Screen.height + " Screen.orientation " + Screen.orientation);

            float width = webCamTextureMat.width();
            float height = webCamTextureMat.height();

            float widthScale = (float)Screen.width / width;
            float heightScale = (float)Screen.height / height;
            if (widthScale < heightScale)
            {
                Camera.main.orthographicSize = (width * (float)Screen.height / (float)Screen.width) / 2;
            }
            else
            {
                Camera.main.orthographicSize = height / 2;
            }
            
            dnnUtils.InitHeadPoseEstimationCameraInfo(webCamTextureMat.cols(), webCamTextureMat.rows());

            webCamReady = true;
            UnityEngine.Debug.Log("OnWebCamTextureToMatHelperInitialized");
        }

        public void OnWebCamTextureToMatHelperDisposed()
        {
            UnityEngine.Debug.Log("OnWebCamTextureToMatHelperDisposed");

        }

        public void OnWebCamTextureToMatHelperErrorOccurred(WebCamTextureToMatHelperSDK.ErrorCode errorCode)
        {
            UnityEngine.Debug.Log("OnWebCamTextureToMatHelperErrorOccurred " + errorCode);
        }
        private void InitVariable()
        {
            mat4Process = new OpenCVCompact.Mat();
            grayMat4Process = new OpenCVCompact.Mat();
            detectionResult = new OpenCVCompact.MatOfRect();
            lndmrk = new OpenCVCompact.Mat(2, 84, OpenCVCompact.CvType.CV_32FC1, 0.0f);

            detectRect = new OpenCVCompact.Rect();
            poseViewOn = true;
        }
        private void Run()
        {
            webCamTextureToMatHelper.Initialize();
            // OnChangeCameraButtonClick();
        }
        public void OnAttrib_Runtime_Click()
        {

            faceAttrEstMultiThread = !faceAttrEstMultiThread;

            if (faceAttrEstMultiThread == true || faceExpEstMultiThread == true)
            {
                multiThreadOrNot = true;
            }
            else
            {
                multiThreadOrNot = false;
            }

            if (multiThreadOrNot == true)
            {
                InitThread();
            }
            else
            {
                StopThread();               
            }
        }
        private bool InitModel()
        {
            dnnUtils = new dnn.DNNUtils();

            //Init Model File Path
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            dnnLndmrkDetectModelFilePath = Utils.getFilePath("face_lndmrk_detect_mobile.bin");
#else
            dnnLndmrkDetectModelFilePath = Utils.getFilePath("face_lndmrk_detect.bin");
#endif

#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            dnnFaceAttr7ModelFilePath = Utils.getFilePath("att_7_mobile.bin");
#else
            dnnFaceAttr7ModelFilePath = Utils.getFilePath("att_7.bin");
#endif

#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            dnnFaceExpModelFilePath = Utils.getFilePath("face_exp_mobile.bin");
#else
            dnnFaceExpModelFilePath = Utils.getFilePath("face_exp.bin");
#endif
           

            bool initFaceLndmrkRes;

            initFaceLndmrkRes = dnnUtils.InitFaceLandmarkDetect(dnnLndmrkDetectModelFilePath);
            if (initFaceLndmrkRes == false)
            {
                UnityEngine.Debug.LogError(dnnLndmrkDetectModelFilePath + " file is not loaded.");
                UnityEngine.Debug.LogError(dnnLndmrkDetectModelFilePath + " file is not existed on StreamingAssets Folder. Please copy from “Assets/FaceAnalyzer/StreamingAssets/” to “Assets/StreamingAssets/” folder.");
            }

            dnnUtils.InitHeadPoseEstimation();

            int initFaceAttrRes = dnnUtils.InitFaceAttribNet_7(dnnFaceAttr7ModelFilePath);
            if (initFaceAttrRes <= 0)
            {
                UnityEngine.Debug.LogError(dnnFaceAttr7ModelFilePath + " file is not loaded.");
                UnityEngine.Debug.LogError(dnnFaceAttr7ModelFilePath + " file is not existed on StreamingAssets Folder. Please copy from “Assets/FaceAnalyzer/StreamingAssets/” to “Assets/StreamingAssets/” folder.");           
            }

            int initFaceExpRes = dnnUtils.InitFaceExpressionNet_7(dnnFaceExpModelFilePath);
            if (initFaceExpRes <= 0)
            {
                UnityEngine.Debug.LogError(dnnFaceExpModelFilePath + " file is not loaded.");
                UnityEngine.Debug.LogError(dnnFaceExpModelFilePath + " file is not existed on StreamingAssets Folder. Please copy from “Assets/FaceAnalyzer/StreamingAssets/” to “Assets/StreamingAssets/” folder.");
            }
            dnnUtils.InitLabels_7();
            dnnUtils.InitExpLabels_7();
            dnnUtils.InitObjectLabels_21();
            dnnUtils.InitKalmanFilter(10f);
            
            return true;
        }
        //MAIN Facial Landmark Tracking Section
        private bool FaceAttribEst()
        {
            OpenCVCompact.Mat prob = new OpenCVCompact.Mat();
            bool res = dnnUtils.EstFaceAttribNet_7(img4Thread.nativeObj, lndmrk4Thread.nativeObj, CvType.COLOR_RGBA, prob.nativeObj);

            if (res == false)
                return false;

            dnnUtils.ParseEstFaceAttrib_7(prob);

            faceAttrTextThread = string.Empty;
            string faceAttrTextThread_temp = string.Empty;
            int idx = 0;
            foreach (var pair in dnnUtils.dnnFaceAttribRes_7)
            {
                string tmp;
                if (idx % 2 == 0)
                    tmp = string.Format("[{0}] : {1}\n", pair.Key, pair.Value);
                else
                    tmp = string.Format("[{0}] : {1}\t\t", pair.Key, pair.Value);

                faceAttrTextThread_temp = string.Concat(faceAttrTextThread_temp, tmp);

                idx = idx + 1;
            }

            faceAttrTextThread = faceAttrTextThread_temp;
            prob.Dispose();

            return true;
        }
        private bool FaceExpEst()
        {
            bool res = dnnUtils.EstFaceExpressionNet_7(img4Thread.nativeObj, lndmrk4Thread.nativeObj, CvType.COLOR_RGBA, probExp.nativeObj);

            return res;
        }
        
        
        private void LandmarkDetect()
        {
            if (dnnUtils.GetEstimateLandmarkSuccessOrNot() == false || lndmrkEstScore < 0.25) //If It Failed To Track Facial Landmark in Previous Frame
            {
                //Face Detect!!!
                Imgproc.cvtColor(mat4Process, grayMat4Process, OpenCVCompact.Imgproc.COLOR_RGBA2GRAY); //Face Detection Should Use Gray Image
               
                if (dnnUtils.DetectFace(grayMat4Process, detectionResult, 32, 1024, true)) //Detect Face
                {
                    detectRect = detectionResult.toArray()[0];
                    faceRect[0] = detectRect.x; 
                    faceRect[1] = detectRect.y; 
                    faceRect[2] = detectRect.width; 
                    faceRect[3] = detectRect.height;
                    
                    lndmrkEstScore = dnnUtils.EstimateFacialLandmark(mat4Process.nativeObj, ref faceRect[0], lndmrk.nativeObj, lndmrkMode, kalmanOrNot, lndmrkLevel);
                    didUpdateTheEstimationResult = true;
                }
                else
                {
                    didUpdateTheEstimationResult = false;
                }
            }
            else
            {
                //Track Facial Landmark If It Succeeded In Previous Frame
                faceRect = dnnUtils.SquareFromInnerLandmark(lndmrk.nativeObj);
                lndmrkEstScore = dnnUtils.EstimateFacialLandmark(mat4Process.nativeObj, ref faceRect[0], lndmrk.nativeObj, lndmrkMode, kalmanOrNot, lndmrkLevel);
                didUpdateTheEstimationResult = true;
            }

            if (dnnUtils.GetEstimateLandmarkSuccessOrNot() == true)
            {
                dnnUtils.SolveHeadPoseEstimation(lndmrk.nativeObj);
                dnnUtils.GetHeadPose(ref headRoll, ref headPitch, ref headYaw);
                dnnUtils.GetHeadPoseBox(out poseBox);
                
            }
            if (attribOrNot == true)
            {
                OpenCVCompact.Mat prob = new OpenCVCompact.Mat();
                if(dnnUtils.EstFaceAttribNet_7(mat4Process.nativeObj, lndmrk.nativeObj, CvType.COLOR_RGBA, prob.nativeObj) == true)
                {
                    dnnUtils.ParseEstFaceAttrib_7(prob);

                    string text = string.Empty;
                    int idx = 0;
                    foreach (var pair in dnnUtils.dnnFaceAttribRes_7)
                    {
                        string tmp;
                        if (idx % 2 == 0)
                            tmp = string.Format("[{0}] : {1}\n", pair.Key, pair.Value);
                        else
                            tmp = string.Format("[{0}] : {1}\t\t", pair.Key, pair.Value);

                        text = string.Concat(text, tmp);

                        idx = idx + 1;
                    }
                    // GameObject.Find("AttributeInfo").GetComponent<Text>().text = text.Substring(0, text.Length - 1);
                }

                prob.Dispose();             
                attribOrNot = false;
            }
        }
        
        void DrawPose(Mat img, float roll, float pitch, float yaw, float lineL)
        {
            //Related To Head Pose Estimation
            int mLOC_x = (int)(img.cols() * 8 / 10 + 0.5);
            int mLOC_y = 70;
            OpenCVCompact.Mat matRotationMTX = new OpenCVCompact.Mat(3, 3, CvType.CV_32FC1);
            float[] val_P = new float[] { 0.0f, lineL, 0.0f, 0.0f, 0.0f, 0.0f, -lineL, 0.0f, 0.0f, 0.0f, 0.0f, -lineL };
            OpenCVCompact.Mat P = new OpenCVCompact.Mat(3, 4, CvType.CV_32FC1);
            float[] val = new float[1];
            OpenCVCompact.Mat RotMtxX = new OpenCVCompact.Mat(3, 3, CvType.CV_32FC1);
            OpenCVCompact.Mat RotMtxY = new OpenCVCompact.Mat(3, 3, CvType.CV_32FC1);
            OpenCVCompact.Mat RotMtxZ = new OpenCVCompact.Mat(3, 3, CvType.CV_32FC1);

            int thickness = 5;
            int lineType = 8;
           
            P.put(0, 0, val_P);
                    
            float angleX = -pitch;
            float angleY = -yaw;
            float angleZ = -roll;
                  
            Core.setIdentity(matRotationMTX);
          
            Core.setIdentity(RotMtxX);
            val[0] = (float)Math.Cos(angleX);
            RotMtxX.put(1, 1, val);

            val[0] = -(float)Math.Sin(angleX);
            RotMtxX.put(1, 2, val);

            val[0] = (float)Math.Sin(angleX);
            RotMtxX.put(2, 1, val);

            val[0] = (float)Math.Cos(angleX);
            RotMtxX.put(2, 2, val);

            matRotationMTX = RotMtxX * matRotationMTX;
                       
            Core.setIdentity(RotMtxY);

            val[0] = (float)Math.Cos(angleY);
            RotMtxY.put(0, 0, val);

            val[0] = (float)Math.Sin(angleY);
            RotMtxY.put(0, 2, val);

            val[0] = -(float)Math.Sin(angleY);
            RotMtxY.put(2, 0, val);

            val[0] = (float)Math.Cos(angleY);
            RotMtxY.put(2, 2, val);

            matRotationMTX = RotMtxY * matRotationMTX;
                       
            Core.setIdentity(RotMtxZ);

            val[0] = (float)Math.Cos(angleZ);
            RotMtxZ.put(0, 0, val);

            val[0] = -(float)Math.Sin(angleZ);
            RotMtxZ.put(0, 1, val);

            val[0] = (float)Math.Sin(angleZ);
            RotMtxZ.put(1, 0, val);

            val[0] = (float)Math.Cos(angleZ);
            RotMtxZ.put(1, 1, val);

            matRotationMTX = RotMtxZ * matRotationMTX;

            P = matRotationMTX * P;
            for (int i = 0; i < P.cols(); i++)
            {
                val[0] = (float)(P.get(0, i)[0] + mLOC_x);
                P.put(0, i, val);

                val[0] = (float)(P.get(1, i)[0] + mLOC_y);
                P.put(1, i, val);
            }

            Point p0 = new Point(P.get(0, 0)[0], P.get(1, 0)[0]);

            Imgproc.line(img, p0, new Point(P.get(0, 1)[0], P.get(1, 1)[0]), new Scalar(0, 0, 255, 255), thickness, lineType, 0);
            Imgproc.line(img, p0, new Point(P.get(0, 2)[0], P.get(1, 2)[0]), new Scalar(0, 255, 0, 255), thickness, lineType, 0);
            Imgproc.line(img, p0, new Point(P.get(0, 3)[0], P.get(1, 3)[0]), new Scalar(255, 0, 0, 255), thickness, lineType, 0);
            
            if (P != null)
                P.Dispose();

            if (RotMtxX != null)
                RotMtxX.Dispose();

            if (RotMtxY != null)
                RotMtxY.Dispose();

            if (RotMtxZ != null)
                RotMtxZ.Dispose();
        }
        void DrawHeadPoseBox(Mat img, Point[] point)
        {
            Imgproc.line(img, point[0], point[1], new Scalar(0, 0, 255, 255), 2);
            Imgproc.line(img, point[1], point[2], new Scalar(0, 0, 255, 255), 2);
            Imgproc.line(img, point[2], point[3], new Scalar(0, 0, 255, 255), 2);
            Imgproc.line(img, point[3], point[0], new Scalar(0, 0, 255, 255), 2);
            Imgproc.line(img, point[4], point[5], new Scalar(0, 0, 255, 255), 2);
            Imgproc.line(img, point[5], point[6], new Scalar(0, 0, 255, 255), 2);
            Imgproc.line(img, point[6], point[7], new Scalar(0, 0, 255, 255), 2);
            Imgproc.line(img, point[7], point[4], new Scalar(0, 0, 255, 255), 2);
            Imgproc.line(img, point[0], point[4], new Scalar(0, 0, 255, 255), 2);
            Imgproc.line(img, point[1], point[5], new Scalar(0, 0, 255, 255), 2);
            Imgproc.line(img, point[2], point[6], new Scalar(0, 0, 255, 255), 2);
            Imgproc.line(img, point[3], point[7], new Scalar(0, 0, 255, 255), 2);
        }
        private void InitThread()
        {
            UnityEngine.Debug.Log("InitThread");

            if(isThreadInitialized == false)
            {
                StopThread();

                img4Thread = new Mat();
                lndmrk4Thread = new OpenCVCompact.Mat();
                probExp = new Mat(1, dnnUtils.dnnFaceExpLabels_7.Count, OpenCVCompact.CvType.CV_32FC1, 0.0f);

                shouldEstimateInMultiThread = false;

                StartThread(ThreadWorker);

            }
            isThreadInitialized = true;
        }
        private void StartThread(Action action)
        {
            UnityEngine.Debug.Log("StartThread");

            shouldStopThread = false;

#if UNITY_METRO && NETFX_CORE
            System.Threading.Tasks.Task.Run(() => action());
#elif UNITY_METRO
            action.BeginInvoke(ar => action.EndInvoke(ar), null);
#else
            ThreadPool.QueueUserWorkItem(_ => action());
#endif

            UnityEngine.Debug.Log("Thread Start");
        }
        
        private void StopThread()
        {
            if (!IsThreadRunning)
                return;

            shouldStopThread = true;

            while (IsThreadRunning)
            {
                //Wait threading stop
            }
            UnityEngine.Debug.Log("Thread Stop");
            isThreadInitialized = false;
        }
#if !UNITY_WEBGL
        private void ThreadWorker()
        {
            UnityEngine.Debug.Log("ThreadWorker");
            isThreadRunning = true;
            
            while (!shouldStopThread)
            {
                if (!shouldEstimateInMultiThread)
                {
                    continue;
                }
                //if (Math.Abs(yaw) < 15 && Math.Abs(pitch) < 15 && Math.Abs(roll) < 15) //Just Estimate Face Attribute on abs(yaw) < 15 degree
                //{
                //    FaceAttribEst();
                //}
                //if (Math.Abs(pitch) < 30) //Just Estimate Face Attribute on certain degree range
                //{
                //    FaceAttribEst();
                //}
                if(faceAttrEstMultiThread == true)
                {
                    FaceAttribEst();
                }

                if(faceExpEstMultiThread == true)
                {
                    FaceExpEst();
                }

                shouldEstimateInMultiThread = false;
            }
            UnityEngine.Debug.Log("ThreadWorker Done");
            isThreadRunning = false;
        }
#else
        private IEnumerator ThreadWorker ()
        {
            while (true) {
                while (!shouldDetectInMultiThread) {
                    yield return null;
                }

                Detect ();

                shouldDetectInMultiThread = false;
                didUpdateTheDetectionResult = true;
            }
        }
#endif
    }
}
