/*************************************************************************
*
* ILLUNI CONFIDENTIAL
* __________________
*
*  [2018] Illuni Incorporated
*  All Rights Reserved.
*
* NOTICE:  All information contained herein is, and remains
* the property of Illuni Incorporated and its suppliers,
* if any.  The intellectual and technical concepts contained
* herein are proprietary to Illuni Incorporated
* and its suppliers and may be covered by Republic of Korea, U.S. and Foreign Patents,
* patents in process, and are protected by trade secret or copyright law.
* Dissemination of this information or reproduction of this material
* is strictly forbidden unless prior written permission is obtained
* from Illuni Incorporated.
*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCVCompact;

namespace dnn
{
    public class DNNUtils : dnnDisposeable
    {
        public struct FaceObject
        {
            public OpenCVCompact.RectFloat rect;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public OpenCVCompact.Point[] landmark;
            public float prob;
        };

        public struct Object
        {
            public OpenCVCompact.RectFloat rect;
            public int label;
            public float prob;
        };


        ////////////////////////////////////////////////////////////////////////
#if UNITY_IOS && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "face_analyzer";
#endif
                
        List<string> dnnFaceAttribLabels_7;
        List<int> dnnFaceAttribLayerSize_7;
        List<string> dnnFaceAttribMethod_7;
        public Dictionary<string, string> dnnFaceAttribRes_7;

        public List<string> dnnFaceExpLabels_7;
        public List<string> objectLabels_21;

        [DllImport(LIBNAME)]
        private static extern void Release_DNN(IntPtr objPtr);

        [DllImport(LIBNAME)]
        private static extern IntPtr Create_DNN();

        [DllImport(LIBNAME)]
        private static extern bool Init_FaceLandmarkDetect(IntPtr objPtr, string model_data_path);

        [DllImport(LIBNAME)]
        private static extern bool Init_FaceLandmarkDetect_Mobile(IntPtr objPtr, string model_data_path);

        [DllImport(LIBNAME)]
        private static extern void Init_HeadPoseEstimation(IntPtr objPtr);

        [DllImport(LIBNAME)]
        private static extern void Init_HeadPoseEstimation_CameraInfo(IntPtr objPtr, int image_width, int image_height);

        [DllImport(LIBNAME)]
        private static extern bool Detect_Face(IntPtr objPtr, IntPtr image, IntPtr detectedFace, int minSize, int maxSize, bool usePyr);

        [DllImport(LIBNAME)]
        private static extern float Estimate_FacialLandmark(IntPtr objPtr, IntPtr iImage, ref int rect, IntPtr landmark, int flag, bool kalman_or_not, int level);
        
        [DllImport(LIBNAME)]
        private static extern bool Get_EstimateLandmarkSuccessOrNot(IntPtr objPtr);

        [DllImport(LIBNAME)]
        private static extern void Set_EstimateLandmarkSuccessOrNot(IntPtr objPtr, bool val);
        
        [DllImport(LIBNAME)]
        private static extern bool Solve_HeadPoseEstimation(IntPtr objPtr, IntPtr landmark);

        [DllImport(LIBNAME)]
        private static extern void Get_HeadPose(IntPtr objPtr, ref float roll, ref float pitch, ref float yaw);

        [DllImport(LIBNAME)]
        private static extern void Get_HeadPoseBox(IntPtr objPtr, out IntPtr vec_float, out int size_of_vec_float);

        [DllImport(LIBNAME)]
        private static extern void Square_From_InnerLandmark(IntPtr objPtr, IntPtr landmark, out IntPtr rect);

        [DllImport(LIBNAME)]
        private static extern int Init_FaceAttribNet_7(IntPtr objPtr, string model_file_path);

        [DllImport(LIBNAME)]
        private static extern bool Est_FaceAttribNet_7(IntPtr objPtr, IntPtr imgPtr, IntPtr lndmrkPtr, int colorType, IntPtr probPtr);

        [DllImport(LIBNAME)]
        private static extern int Init_FaceExpressionNet_7(IntPtr objPtr, string model_file_path);
               
        [DllImport(LIBNAME)]
        private static extern bool Est_FaceExpressionNet_7(IntPtr objPtr, IntPtr imgPtr, IntPtr lndmrkPtr, int colorType, IntPtr probPtr);

        [DllImport(LIBNAME)]
        private static extern int Init_MultiTinyFaceDetector(IntPtr objPtr, string model_file_path);

        [DllImport(LIBNAME)]
        private static extern bool Est_MultiTinyFaceDetector(IntPtr objPtr, IntPtr imgPtr, float prob_threshold, float nms_threshold, int colorType, out IntPtr val_ptr, out int nb_of_values, out int size_of_a_value);

        [DllImport(LIBNAME)]
        private static extern int Init_YOLOV3Detector(IntPtr objPtr, string model_file_path, string param_file_path);

        [DllImport(LIBNAME)]
        private static extern bool Est_YOLOV3Detector(IntPtr objPtr, IntPtr imgPtr, int colorType, out IntPtr val_ptr, out int nb_of_values, out int size_of_a_value);

        [DllImport(LIBNAME)]
        private static extern void Init_KalmanFilter(IntPtr objPtr, float noise_weight);
              
        ////////////////////////////////////////////////////////////////////////

        /**
        * Init and Create DNN Utils Object
        */
        public DNNUtils()
        {
            nativeObj = Create_DNN();
        }

        /**
         * Init Face Landmark Detect Module
         *
         * @param[in] face_model_data_path(string) facial landmark dnn(deep neural network) model file path(face_lndmrk_detect.bin)
         * @return[bool] result
        */
        public bool InitFaceLandmarkDetect(string face_model_data_path)
        {
            if (nativeObj == IntPtr.Zero)
            {
                return false;
            }
            
            return Init_FaceLandmarkDetect(nativeObj, face_model_data_path);
        }

        /**
         * Init Face Landmark Detect Module
         *
         * @param[in] face_model_data_path(string) facial landmark dnn(deep neural network) model file path(face_lndmrk_detect.bin)
         * @return[bool] result
        */
        public bool InitFaceLandmarkDetectMobile(string face_model_data_path)
        {
            if (nativeObj == IntPtr.Zero)
            {
                return false;
            }

            return Init_FaceLandmarkDetect_Mobile(nativeObj, face_model_data_path);
        }

        /**
         * Init Head Pose Estimation Module
        */
        public void InitHeadPoseEstimation()
        {
            Init_HeadPoseEstimation(nativeObj);
        }

        /**
         * Init Head Pose Estimation Camera Information to draw head bounding box with profer perspective
         * 
         * @param[in] image_width(int) input image width(column size)
         * @param[in] image_height(int) input image height(row size)
        */
        public void InitHeadPoseEstimationCameraInfo(int image_width, int image_height)
        {
            Init_HeadPoseEstimation_CameraInfo(nativeObj, image_width, image_height);
        }

        /**
         * Detect Face Location
         * 
         * @param[in] image(Mat) target image frame
         * @param[out] objects(MatOfRect) output face locations
         * @param[in] minSize(int) minimum face size
         * @param[in] maxSize(int) maximum face size
         * @param[in] usePyr(bool) use image pyramid strategy or not
         * @return[bool]    detect face success or not (true: success, false: failed)
        */
        public bool DetectFace(Mat image, MatOfRect objects, int minSize, int maxSize, bool usePyr)
        {
            ThrowIfDisposed();
            if (image != null) image.ThrowIfDisposed();
            if (objects != null) objects.ThrowIfDisposed();
            Mat objects_mat = objects;

            bool res = Detect_Face(nativeObj, image.nativeObj, objects_mat.nativeObj, minSize, maxSize, usePyr);
            return res;
        }

        /**
         * Estimate Facial Landmarks
         * 
         * @param[in] iImage(IntPtr) target image frame
         * @param[in] rect(ref int) target face location in rectangle(x, y, width, height)
         * @param[out] landmark(IntPtr) minimum face size
         * @param[in] flag(int) facial landmark mode. 
         *                      0: only estimate inner facial 51 landmarks
         *                      1: estimate inner and contour facial 84 landmarks (takes much times than mode 0)
         * @param[in] kalman_or_not(bool) kalman filtering or not for contour facial landmark if it has previous landmarks estimate for smooth tracking.
         * @param[in] lndmrkEstLevel(int) landmark estimation level within 1 ~ 4. 1: Not accurate but fast, 4: accurate but slow.
         * @return[float]    facial landmark estimation score 
        */
        public float EstimateFacialLandmark(IntPtr iImage, ref int rect, IntPtr landmark, int flag = 0, bool kalman_or_not = false, int lndmrkEstLevel = 3)
        {
            return Estimate_FacialLandmark(nativeObj, iImage, ref rect, landmark, flag, kalman_or_not, lndmrkEstLevel);
        }

        /**
         * Get Facial Landmark Estimation Result
         * 
         * @return[bool] Facial landmark estimation success or not (true: success, false: failed)
        */
        public bool GetEstimateLandmarkSuccessOrNot()
        {
            return Get_EstimateLandmarkSuccessOrNot(nativeObj);
        }

        /**
         * Set Facial Landmark Estimation Result
         * 
         * @param[in] val(bool) target value (true: success, false: failed)
        */
        public void SetEstimateLandmarkSuccessOrNot(bool val)
        {
            Set_EstimateLandmarkSuccessOrNot(nativeObj, val);
        }

        /**
         * Calculate Head Pose from the facial landmark
         * 
         * @param[in] landmark(IntPtr) input facial landmark
         * @return[bool] result
        */
        public bool SolveHeadPoseEstimation(IntPtr landmark)
        {
            return Solve_HeadPoseEstimation(nativeObj, landmark);
        }

        /**
         * Get Head Pose
         * 
         * @param[out] roll(ref float) roll angle
         * @param[out] pitch(ref float) pitch angle
         * @param[out] yaw(ref float) yaw angle
        */
        public void GetHeadPose(ref float roll, ref float pitch, ref float yaw)
        {
            Get_HeadPose(nativeObj, ref roll, ref pitch, ref yaw);
        }

        /**
         * Get Head Pose Box
         * 
         * @param[out] points(OpenCVCompact.Point[]) head pose box composed with 8 points
        */
        public void GetHeadPoseBox(out OpenCVCompact.Point[] points)
        {
            IntPtr point_ptr;
            int size_of_point;

            Get_HeadPoseBox(nativeObj, out point_ptr, out size_of_point);

            float[] points_val = new float[size_of_point];
            Marshal.Copy(point_ptr, points_val, 0, size_of_point);
            Marshal.FreeCoTaskMem(point_ptr);

            points = new OpenCVCompact.Point[size_of_point / 2];
            for (int i = 0; i < size_of_point / 2; i++)
            {
                points[i] = new Point(points_val[2 * i + 0], points_val[2 * i + 1]);
            }
        }

        /**
         * Get Face Rectangle from inner facial landmarks. The result rectangle is used for facial landmark tracking.
         * 
         * @param[in] landmark(IntPtr) input inner facial landmark
         * @return[int[]] face roi square
        */
        public int[] SquareFromInnerLandmark(IntPtr landmark)
        {
           // OpenCVCompact.Rect rect_out = new OpenCVCompact.Rect();

            IntPtr rect_ptr;
            Square_From_InnerLandmark(nativeObj, landmark, out rect_ptr);

            int[] rect_int = new int[4];

            Marshal.Copy(rect_ptr, rect_int, 0, 4);
            Marshal.FreeCoTaskMem(rect_ptr);

            //rect_out.x = rect_int[0];
            //rect_out.y = rect_int[1];
            //rect_out.width = rect_int[2];
            //rect_out.height = rect_int[3];

            return rect_int;
        }

        /**
         * Initialize Face Attribute Estimation DNN Model
         * 
         * @param[in] model_file_path(string) dnn model file path(att_7.bin)
         * @return[int] initialization success or not(1: success, -1: false)
        */
        public int InitFaceAttribNet_7(string model_file_path)
        {
            return Init_FaceAttribNet_7(nativeObj, model_file_path);
        }

        /**
         * Estimate Face Attribute From Face Image and Facial Landmark
         * 
         * @param[in] imgPtr(IntPtr) target face image
         * @param[in] lndmrkPtr(IntPtr) target face landmark
         * @param[out] probPtr(IntPtr) 7 facial attribute probabilistic result data
         * @return[bool] result
         * @note Face Attribute Estimation Deep Neural Network Model is trained on frontal face. Non-frontal face will be not accurate!
        */
        public bool EstFaceAttribNet_7(IntPtr imgPtr, IntPtr lndmrkPtr, int colorType, IntPtr probPtr)
        {
            return Est_FaceAttribNet_7(nativeObj, imgPtr, lndmrkPtr, colorType, probPtr);
        }

        /**
         * Initialize Face Expression Estimation DNN Model
         * 
         * @param[in] model_file_path(string) dnn model file path(face_exp.bin)
         * @return[int] initialization success or not(1: success, -1: false)
        */
        public int InitFaceExpressionNet_7(string model_file_path)
        {
            return Init_FaceExpressionNet_7(nativeObj, model_file_path);
        }

        /**
         * Estimate Face Expression From Face Image and Facial Landmark
         * 
         * @param[in] imgPtr(IntPtr) target face image
         * @param[in] lndmrkPtr(IntPtr) target face landmark
         * @param[out] probPtr(IntPtr) 7 facial expression probabilistic result data
         * @return[bool] result
         * @note This is BETA function. Face Expression Estimation Deep Neural Network Model is trained on frontal face. Non-frontal face will be not accurate!
        */
        public bool EstFaceExpressionNet_7(IntPtr imgPtr, IntPtr lndmrkPtr, int colorType, IntPtr probPtr)
        {
            return Est_FaceExpressionNet_7(nativeObj, imgPtr, lndmrkPtr, colorType, probPtr);
        }

        /**
         * Initialize Multi Tiny Face Detector
         * 
         * @param[in] model_file_path(string) dnn model file path(multi_tiny_face_detect_mobile.bin)
         * @return[int] initialization success or not(1: success, -1: false)
         * @note This is based on NCNN example. Improved version will ba available in the future.
        */
        public int InitMultiTinyFaceDetector(string model_file_path)
        {
            return Init_MultiTinyFaceDetector(nativeObj, model_file_path);
        }

        /**
         * Estimate Multi Tiny Face Information
         * 
         * @param[in] imgPtr(IntPtr) target face image
         * @param[in] prob_threshold(float) probability threshold
         * @param[in] nms_threshold(float) nam threshold
         * @param[in] colorType(int) input image color type
         * @return[FaceObject[]] extimation result
         * @note This is based on NCNN example. Improved version will ba available in the future.
        */
        public FaceObject[] EstMultiTinyFaceDetector(IntPtr imgPtr, float prob_threshold, float nms_threshold, int colorType = CvType.COLOR_RGB)
        {
            IntPtr val_ptr;
            int nb_of_values;
            int size_of_a_value;
            Est_MultiTinyFaceDetector(nativeObj, imgPtr, prob_threshold, nms_threshold, colorType, out val_ptr, out nb_of_values, out size_of_a_value);

            float[] values = new float[nb_of_values * size_of_a_value];
            Marshal.Copy(val_ptr, values, 0, nb_of_values * size_of_a_value);
            Marshal.FreeCoTaskMem(val_ptr);

            FaceObject[] faceObjects = new FaceObject[nb_of_values];

            for(int i = 0; i < nb_of_values; i++)
            {
                faceObjects[i].landmark = new Point[5];
                faceObjects[i].rect.x = values[size_of_a_value * i + 0];
                faceObjects[i].rect.y = values[size_of_a_value * i + 1];
                faceObjects[i].rect.width = values[size_of_a_value * i + 2];
                faceObjects[i].rect.height = values[size_of_a_value * i + 3];
                faceObjects[i].landmark[0].x = values[size_of_a_value * i + 4];
                faceObjects[i].landmark[0].y = values[size_of_a_value * i + 5];
                faceObjects[i].landmark[1].x = values[size_of_a_value * i + 6];
                faceObjects[i].landmark[1].y = values[size_of_a_value * i + 7];
                faceObjects[i].landmark[2].x = values[size_of_a_value * i + 8];
                faceObjects[i].landmark[2].y = values[size_of_a_value * i + 9];
                faceObjects[i].landmark[3].x = values[size_of_a_value * i + 10];
                faceObjects[i].landmark[3].y = values[size_of_a_value * i + 11];
                faceObjects[i].landmark[4].x = values[size_of_a_value * i + 12];
                faceObjects[i].landmark[4].y = values[size_of_a_value * i + 13];
                faceObjects[i].prob = values[size_of_a_value * i + 14];
            }

            return faceObjects;
        }

        /**
        * Initialize YOLO V3 Detector. This is based on NCNN example
        * 
        * @param[in] model_file_path(string) dnn model file path("yolov3.bin)
        * @param[in] param_file_path(string) dnn param file path("yolov3.param)
        * @return[int] initialization success or not(1: success, -1: false)
        */
        public int InitYOLOV3Detector(string model_file_path, string param_file_path)
        {
            return Init_YOLOV3Detector(nativeObj, model_file_path, param_file_path);
        }

        /**
         * Estimate Object class and location using YOLO V3 NCNN example
         * 
         * @param[in] imgPtr(IntPtr) target face image
         * @param[in] colorType(int) input image color type
         * @return[Object[]] estimation result
         * @note This is based on NCNN example.
        */
        public Object[] EstYOLOV3Detector(IntPtr imgPtr, int colorType = CvType.COLOR_RGB)
        {
            IntPtr val_ptr;
            int nb_of_values;
            int size_of_a_value;
            Est_YOLOV3Detector(nativeObj, imgPtr, colorType, out val_ptr, out nb_of_values, out size_of_a_value);

            float[] values = new float[nb_of_values * size_of_a_value];
            Marshal.Copy(val_ptr, values, 0, nb_of_values * size_of_a_value);
            Marshal.FreeCoTaskMem(val_ptr);

            Object[] objects = new Object[nb_of_values];

            for (int i = 0; i < nb_of_values; i++)
            {
                objects[i].rect.x = values[size_of_a_value * i + 0];
                objects[i].rect.y = values[size_of_a_value * i + 1];
                objects[i].rect.width = values[size_of_a_value * i + 2];
                objects[i].rect.height = values[size_of_a_value * i + 3];
                objects[i].label = (int)values[size_of_a_value * i + 4];
                objects[i].prob = values[size_of_a_value * i + 5];
            }

            return objects;
        }

        /**
         * Init Kalman Filter Noise Weight
         * 
         * @param[in] noiseWeight(float) noise weight for kalman filter
         * @note Kalman Filter noise weight. Bigger value show more reliable but less prompt result. For Kalman Filter information, check https://en.wikipedia.org/wiki/Kalman_filter
        */
        public void InitKalmanFilter(float noiseWeight)
        {
            Init_KalmanFilter(nativeObj, noiseWeight);
        }
        
        /**
         * Initialize 7 Facial Attribute Labels for parsing a data
        */
        public void InitLabels_7()
        {
            dnnFaceAttribLabels_7 = new List<string>();
            dnnFaceAttribLayerSize_7 = new List<int>();
            dnnFaceAttribMethod_7 = new List<string>();
            dnnFaceAttribRes_7 = new Dictionary<string, string>();

            dnnFaceAttribLabels_7.Add("gender");
            dnnFaceAttribLayerSize_7.Add(2);
            dnnFaceAttribMethod_7.Add("classification");

            dnnFaceAttribLabels_7.Add("age");
            dnnFaceAttribLayerSize_7.Add(1);
            dnnFaceAttribMethod_7.Add("regression");

            dnnFaceAttribLabels_7.Add("race");
            dnnFaceAttribLayerSize_7.Add(5);
            dnnFaceAttribMethod_7.Add("classification");

            dnnFaceAttribLabels_7.Add("Bald");
            dnnFaceAttribLayerSize_7.Add(2);
            dnnFaceAttribMethod_7.Add("classification");

            dnnFaceAttribLabels_7.Add("Blond_Hair");
            dnnFaceAttribLayerSize_7.Add(2);
            dnnFaceAttribMethod_7.Add("classification");

            dnnFaceAttribLabels_7.Add("Eyeglasses");
            dnnFaceAttribLayerSize_7.Add(2);
            dnnFaceAttribMethod_7.Add("classification");
            
            dnnFaceAttribLabels_7.Add("Wearing_Hat");
            dnnFaceAttribLayerSize_7.Add(2);
            dnnFaceAttribMethod_7.Add("classification");
        }

        /**
         * Parse 7 Facial Attribute Labels from a probabilistic numeric data
         * 
         * @param[in] prob(OpenCVCompact.Mat) probabilistic numeric data, which is the output of EstFaceAttribNet_7 function.
        */
        public void ParseEstFaceAttrib_7(OpenCVCompact.Mat prob)
        {
            int currIdx = 0;

            float resVal = 0;
            float resProb = 0;

            for (int i = 0; i < dnnFaceAttribLabels_7.Count; i++)
            {
                if (dnnFaceAttribMethod_7[i] == "classification")
                {
                    List<float> resAttrib = new List<float>();
                    for (int j = 0; j < dnnFaceAttribLayerSize_7[i]; j++)
                    {
                        resAttrib.Add((float)prob.get(0, currIdx)[0]);
                        currIdx = currIdx + 1;
                    }

                    //find max idx
                    int idx = -1;
                    float maxVal = -1;

                    float sumExp = 0;
                    for (int j = 0; j < resAttrib.Count; j++)
                    {
                        if (resAttrib[j] > maxVal)
                        {
                            maxVal = resAttrib[j];
                            idx = j;
                        }
                        sumExp = sumExp + (float)Math.Exp(resAttrib[j]);
                    }
                    resVal = idx;
                    resProb = (float)Math.Exp(resAttrib[idx]) / sumExp;
                }
                else // Regression Case
                {
                    resVal = (float)prob.get(0, currIdx)[0];
                    currIdx = currIdx + 1;
                }

                if (i == 0)
                {
                    if (resVal == 1)
                    {
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "Female (" + (resProb * 100).ToString("F1") + ") %";
                    }
                    else
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "Male (" + (resProb * 100).ToString("F1") + ") %";
                }
                else if (i == 1)
                {
                    dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = (resVal * 10).ToString("F1") + " yrs";
                }
                else if (i == 2)
                {
                    if (resVal == 0)
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "White (" + (resProb * 100).ToString("F1") + ") %";
                    else if (resVal == 1)
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "Black (" + (resProb * 100).ToString("F1") + ") %";
                    else if (resVal == 2)
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "Asian (" + (resProb * 100).ToString("F1") + ") %";
                    else if (resVal == 3)
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "Indian (" + (resProb * 100).ToString("F1") + ") %";
                    else if (resVal == 4)
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "Others (" + (resProb * 100).ToString("F1") + ") %";
                }
                else if (i == 3)
                {
                    if (resVal == 1)
                    {
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "Yes";
                    }
                    else
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "No";
                }
                else if (i == 4)
                {
                    if (resVal == 1)
                    {
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "Yes";
                    }
                    else
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "No";
                }
                else if (i == 5)
                {
                    if (resVal == 1)
                    {
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "Yes";
                    }
                    else
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "No";
                }
                else if (i == 6)
                {
                    if (resVal == 1)
                    {
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "Yes";
                    }
                    else
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "No";
                }
                else if (i == 7)
                {
                    if (resVal == 1)
                    {
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "Yes";
                    }
                    else
                        dnnFaceAttribRes_7[dnnFaceAttribLabels_7[i]] = "No";
                }               
            }
        }

        public void InitExpLabels_7()
        {
            dnnFaceExpLabels_7 = new List<string>();

            dnnFaceExpLabels_7.Add("angry");
            dnnFaceExpLabels_7.Add("disgust");
            dnnFaceExpLabels_7.Add("fear");
            dnnFaceExpLabels_7.Add("happy");
            dnnFaceExpLabels_7.Add("sad");
            dnnFaceExpLabels_7.Add("surprise");
            dnnFaceExpLabels_7.Add("neutral");
        }

        public void InitObjectLabels_21()
        {
            objectLabels_21 = new List<string>();
            objectLabels_21.Add("background");
            objectLabels_21.Add("aeroplane");
            objectLabels_21.Add("bicycle");
            objectLabels_21.Add("bird");
            objectLabels_21.Add("boat");
            objectLabels_21.Add("bottle");
            objectLabels_21.Add("bus");
            objectLabels_21.Add("car");
            objectLabels_21.Add("cat");
            objectLabels_21.Add("chair");
            objectLabels_21.Add("cow");
            objectLabels_21.Add("diningtable");
            objectLabels_21.Add("dog");
            objectLabels_21.Add("horse");
            objectLabels_21.Add("motorbike");
            objectLabels_21.Add("person");
            objectLabels_21.Add("pottedplant");
            objectLabels_21.Add("sheep");
            objectLabels_21.Add("sofa");
            objectLabels_21.Add("train");
            objectLabels_21.Add("tvmonitor");
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                }
                if (IsEnabledDispose)
                {
                    if (nativeObj != IntPtr.Zero)
                        Release_DNN(nativeObj);
                    nativeObj = IntPtr.Zero;
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

    }
}
