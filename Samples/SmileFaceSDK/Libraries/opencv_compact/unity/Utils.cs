using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

namespace OpenCVCompact
{
    public static class Utils
    {
        /**
        * Returns this "FaceAnalyzer" version number.
        * 
        * @return this "FaceAnalyzer" version number
        */
        public static string getVersion ()
        {
            return "1.0.0";
        }

        public static void DebugLogMat(Mat mat)
        {
            string text = string.Empty;
            for (int c = 0; c < mat.channels(); c++)
            {
                for (int i = 0; i < mat.rows(); i++)
                {
                    for (int j = 0; j < mat.cols(); j++)
                    {
                        double val = mat.get(i, j)[c];
                        string tmp;
                        if (j != mat.cols() - 1)
                            tmp = string.Format("{0}, ", val);
                        else
                            tmp = string.Format("{0}\n", val);

                        text = string.Concat(text, tmp);
                    }
                }
            }
            UnityEngine.Debug.Log(text);
        }

        public static void FaceImageFromShape(Mat image, Rect rect, Mat faceShape, Mat normalized_faceShape, Mat faceImage, Mat textureImage, Mat nomalizedTextureImage)
        {
            if (image != null) image.ThrowIfDisposed();
            if (faceShape != null) faceShape.ThrowIfDisposed();
            if (faceImage != null) faceImage.ThrowIfDisposed();
            if (textureImage != null) textureImage.ThrowIfDisposed();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            Utils_FaceImageFromShape(image.nativeObj, (float)rect.x, (float)rect.y, (float)rect.width, (float)rect.height, faceShape.nativeObj, normalized_faceShape.nativeObj, faceImage.nativeObj, textureImage.nativeObj, nomalizedTextureImage.nativeObj);
#else
            return;
#endif
            return;
        }

        public static void matToTexture2D(Mat mat, Texture2D texture2D, bool flip = true, int flipCode = 0, bool flipAfter = false, bool updateMipmaps = false, bool makeNoLongerReadable = false)
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            if (mat != null)
                mat.ThrowIfDisposed();

            if (texture2D == null)
                throw new ArgumentNullException("texture2D");

            if (!mat.isContinuous())
            {
                Debug.LogError("mat.isContinuous() must be true.");
                return;
            }

            //if (texture2D.mipmapCount != 1)
            //{
            //    Debug.LogError("texture2D.mipmapCount must be 1.");
            //    return;
            //}

            if (flip)
            {
                Core.flip(mat, mat, flipCode);
            }
            texture2D.LoadRawTextureData((IntPtr)mat.dataAddr(), (int)mat.total() * (int)mat.elemSize());
            texture2D.Apply(updateMipmaps, makeNoLongerReadable);
            if (flipAfter)
            {
                Core.flip(mat, mat, flipCode);
            }
        }

        public static void texture2DToMat(Texture2D texture2D, Mat mat, bool flip = true, int flipCode = 0)
        {
            if (texture2D == null)
                throw new ArgumentNullException("texture2D");

            if (mat == null)
                throw new ArgumentNullException("mat");
            if (mat != null)
                mat.ThrowIfDisposed();

            if (mat.cols() != texture2D.width || mat.rows() != texture2D.height)
            {
                OpenCVCompact.Imgproc.resize(mat, mat, new OpenCVCompact.Size(texture2D.width, texture2D.height));
            }

            int type = mat.type();

            if (!(type == CvType.CV_8UC1 || type == CvType.CV_8UC3 || type == CvType.CV_8UC4))
                throw new ArgumentException("The Mat object must have the types 'CV_8UC4' (RGBA) , 'CV_8UC3' (RGB) or 'CV_8UC1' (GRAY).");

            if ((texture2D.format == TextureFormat.RGBA32 && type == CvType.CV_8UC4) || (texture2D.format == TextureFormat.RGB24 && type == CvType.CV_8UC3) || (texture2D.format == TextureFormat.Alpha8 && type == CvType.CV_8UC1))
            {
                GCHandle arrayHandle = GCHandle.Alloc(texture2D.GetRawTextureData(), GCHandleType.Pinned);
                Utils_ByteArrayToMatData(arrayHandle.AddrOfPinnedObject(), mat.nativeObj);
                arrayHandle.Free();

                if (flip)
                {
                    Core.flip(mat, mat, flipCode);
                }
                return;
            }
        }

#if !OPENCV_DONT_USE_WEBCAMTEXTURE_API
#if !(PLATFORM_LUMIN && !UNITY_EDITOR)

        public static void webCamTextureToMat(WebCamTexture webCamTexture, Mat mat, bool flip = true, int flipCode = 0)
        {
            webCamTextureToMat(webCamTexture, mat, null, flip, flipCode);
        }

        public static void webCamTextureToMat(WebCamTexture webCamTexture, Mat mat, Color32[] bufferColors, bool flip = true, int flipCode = 0)
        {
            if (webCamTexture == null)
                throw new ArgumentNullException("webCamTexture");

            if (mat == null)
                throw new ArgumentNullException("mat");
            if (mat != null)
                mat.ThrowIfDisposed();

            if (mat.cols() != webCamTexture.width || mat.rows() != webCamTexture.height)
            {
                OpenCVCompact.Imgproc.resize(mat, mat, new OpenCVCompact.Size(webCamTexture.width, webCamTexture.height));
            }

            GCHandle colorsHandle;
            if (bufferColors == null)
            {
                Color32[] colors = webCamTexture.GetPixels32();

                colorsHandle = GCHandle.Alloc(colors, GCHandleType.Pinned);
            }
            else
            {
                webCamTexture.GetPixels32(bufferColors);

                colorsHandle = GCHandle.Alloc(bufferColors, GCHandleType.Pinned);
            }

            Utils_TextureToMat(colorsHandle.AddrOfPinnedObject(), mat.nativeObj, flip, flipCode);
            colorsHandle.Free();
        }

#endif
#endif

        public static void textureToTexture2D(Texture texture, Texture2D texture2D)
        {
            if (texture == null)
                throw new ArgumentNullException("texture");

            if (texture2D == null)
                throw new ArgumentNullException("texture2D");

            if (texture.width != texture2D.width || texture.height != texture2D.height)
                throw new ArgumentException("texture and texture2D need to be the same size.");

            RenderTexture prevRT = RenderTexture.active;

            if (texture is RenderTexture)
            {
                RenderTexture.active = (RenderTexture)texture;
                texture2D.ReadPixels(new UnityEngine.Rect(0f, 0f, texture.width, texture.height), 0, 0, false);
                texture2D.Apply(false, false);
            }
            else
            {
                RenderTexture tempRT = RenderTexture.GetTemporary(texture.width, texture.height, 0, RenderTextureFormat.ARGB32);
                Graphics.Blit(texture, tempRT);

                RenderTexture.active = tempRT;
                texture2D.ReadPixels(new UnityEngine.Rect(0f, 0f, texture.width, texture.height), 0, 0, false);
                texture2D.Apply(false, false);
                RenderTexture.ReleaseTemporary(tempRT);
            }

            RenderTexture.active = prevRT;
        }
        
        public static string getFilePath(string filepath, bool refresh = false, int timeout = 0)
        {
            if (filepath == null)
                filepath = string.Empty;

            filepath = filepath.TrimStart(chTrims);

            if (string.IsNullOrEmpty(filepath) || string.IsNullOrEmpty(Path.GetExtension(filepath)))
                return String.Empty;

#if UNITY_ANDROID && !UNITY_EDITOR
            string srcPath = Path.Combine(Application.streamingAssetsPath, filepath);
            string destPath = Path.Combine(Application.persistentDataPath, "faceanalyzer");
            destPath = Path.Combine(destPath, filepath);

            if (!refresh && File.Exists(destPath))
                return destPath;

#if UNITY_2017_1_OR_NEWER
            using (UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequest.Get(srcPath))
            {
                request.timeout = timeout;

#if UNITY_2018_2_OR_NEWER
                request.SendWebRequest ();
#else
                request.Send();
#endif

                while (!request.isDone) {; }

#if UNITY_2017_1_OR_NEWER
                if (request.isHttpError || request.isNetworkError) {
#else
                if (request.isError)
                {
#endif
                    Debug.LogWarning(request.error);
                    Debug.LogWarning(request.responseCode);
                    return String.Empty;
                }

                //create Directory
                String dirPath = Path.GetDirectoryName(destPath);
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);

                File.WriteAllBytes(destPath, request.downloadHandler.data);
            }
#else
            using (WWW request = new WWW(srcPath))
            {
                while (!request.isDone) {; }

                if (!string.IsNullOrEmpty(request.error))
                {
                    Debug.LogWarning(request.error);
                    return String.Empty;
                }

                //create Directory
                String dirPath = Path.GetDirectoryName(destPath);
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);

                File.WriteAllBytes(destPath, request.bytes);
            }
#endif
            return destPath;
#elif UNITY_WEBGL && !UNITY_EDITOR
            string destPath = Path.Combine(Path.DirectorySeparatorChar.ToString(), "faceanalyzer");
            destPath = Path.Combine(destPath, filepath);

            if (File.Exists(destPath))
            {
                return destPath;
            }
            else
            {
                return String.Empty;
            }
#else
            string destPath = Path.Combine(Application.streamingAssetsPath, filepath);

            if (File.Exists(destPath))
            {
                return destPath;
            }
            else
            {
                return String.Empty;
            }
#endif
        }

        public static List<string> getMultipleFilePaths(IList<string> filepaths, bool refresh = false, int timeout = 0)
        {
            if (filepaths == null)
                throw new ArgumentNullException("filepaths");

            List<string> result = new List<string>();

            for (int i = 0; i < filepaths.Count; i++)
            {
                result.Add(getFilePath(filepaths[i], refresh, timeout));
            }

            return result;
        }

        public static IEnumerator getFilePathAsync(string filepath, Action<string> completed, bool refresh = false, int timeout = 0)
        {
            return getFilePathAsync(filepath, completed, null, null, refresh, timeout);
        }

        public static IEnumerator getFilePathAsync(string filepath, Action<string> completed, Action<string, float> progressChanged, bool refresh = false, int timeout = 0)
        {
            return getFilePathAsync(filepath, completed, progressChanged, null, refresh, timeout);
        }
            
        public static IEnumerator getFilePathAsync(string filepath, Action<string> completed, Action<string, float> progressChanged, Action<string, string, long> errorOccurred, bool refresh = false, int timeout = 0)
        {
            if (filepath == null)
                filepath = string.Empty;

            filepath = filepath.TrimStart(chTrims);

            if (string.IsNullOrEmpty(filepath) || string.IsNullOrEmpty(Path.GetExtension(filepath)))
            {
                if (progressChanged != null)
                    progressChanged(filepath, 0);
                yield return null;
                if (progressChanged != null)
                    progressChanged(filepath, 1);

                if (errorOccurred != null)
                {
                    errorOccurred(filepath, "Invalid file path.", 0);
                }
                else
                {
                    if (completed != null)
                        completed(String.Empty);
                }
                yield break;
            }

#if (UNITY_ANDROID || UNITY_WEBGL) && !UNITY_EDITOR
            string srcPath = Path.Combine(Application.streamingAssetsPath, filepath);
#if UNITY_ANDROID
            string destPath = Path.Combine(Application.persistentDataPath, "faceanalyzer");
#else
            string destPath = Path.Combine(Path.DirectorySeparatorChar.ToString(), "faceanalyzer");
#endif
            destPath = Path.Combine(destPath, filepath);

            if (!refresh && File.Exists(destPath))
            {
                if (progressChanged != null)
                    progressChanged(filepath, 0);
                yield return null;
                if (progressChanged != null)
                    progressChanged(filepath, 1);
                if (completed != null)
                    completed(destPath);
            }
            else
            {

#if UNITY_WEBGL || (UNITY_ANDROID && UNITY_2017_1_OR_NEWER)
                using (UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequest.Get(srcPath))
                {
                    request.timeout = timeout;

#if UNITY_2018_2_OR_NEWER
                    request.SendWebRequest ();
#else
                    request.Send();
#endif

                    while (!request.isDone)
                    {

                        if (progressChanged != null)
                            progressChanged(filepath, request.downloadProgress);

                        yield return null;
                    }

                    if (progressChanged != null)
                        progressChanged(filepath, request.downloadProgress);

#if UNITY_2017_1_OR_NEWER
                    if (request.isHttpError || request.isNetworkError) {
#else
                    if (request.isError)
                    {
#endif
                        Debug.LogWarning(request.error);
                        Debug.LogWarning(request.responseCode);

                        if (errorOccurred != null)
                        {
                            errorOccurred(filepath, request.error, request.responseCode);
                        }
                        else
                        {
                            if (completed != null)
                                completed(String.Empty);
                        }
                        yield break;
                    }

                    //create Directory
                    String dirPath = Path.GetDirectoryName(destPath);
                    if (!Directory.Exists(dirPath))
                        Directory.CreateDirectory(dirPath);

                    File.WriteAllBytes(destPath, request.downloadHandler.data);
                }
#else
                using (WWW request = new WWW(srcPath))
                {

                    while (!request.isDone)
                    {
                        if (progressChanged != null)
                            progressChanged(filepath, request.progress);

                        yield return null;
                    }

                    if (progressChanged != null)
                        progressChanged(filepath, request.progress);

                    if (!string.IsNullOrEmpty(request.error))
                    {
                        Debug.LogWarning(request.error);

                        if (errorOccurred != null)
                        {
                            errorOccurred(filepath, request.error, 0);
                        }
                        else
                        {
                            if (completed != null)
                                completed(String.Empty);
                        }
                        yield break;
                    }

                    //create Directory
                    String dirPath = Path.GetDirectoryName(destPath);
                    if (!Directory.Exists(dirPath))
                        Directory.CreateDirectory(dirPath);

                    File.WriteAllBytes(destPath, request.bytes);
                }
#endif
                if (completed != null)
                    completed(destPath);
            }
#else
            string destPath = Path.Combine(Application.streamingAssetsPath, filepath);

            if (progressChanged != null)
                progressChanged(filepath, 0);
            yield return null;
            if (progressChanged != null)
                progressChanged(filepath, 1);

            if (File.Exists(destPath))
            {
                if (completed != null)
                    completed(destPath);
            }
            else
            {
                if (errorOccurred != null)
                {
                    errorOccurred(filepath, "File does not exist.", 0);
                }
                else
                {
                    if (completed != null)
                        completed(String.Empty);
                }
            }
#endif

            yield break;
        }
        
        public static IEnumerator getMultipleFilePathsAsync(IList<string> filepaths, Action<List<string>> allCompleted, bool refresh = false, int timeout = 0)
        {
            return getMultipleFilePathsAsync(filepaths, allCompleted, null, null, null, refresh, timeout);
        }

        public static IEnumerator getMultipleFilePathsAsync(IList<string> filepaths, Action<List<string>> allCompleted, Action<string> completed, bool refresh = false, int timeout = 0)
        {
            return getMultipleFilePathsAsync(filepaths, allCompleted, completed, null, null, refresh, timeout);
        }

        public static IEnumerator getMultipleFilePathsAsync(IList<string> filepaths, Action<List<string>> allCompleted, Action<string> completed, Action<string, float> progressChanged, bool refresh = false, int timeout = 0)
        {
            return getMultipleFilePathsAsync(filepaths, allCompleted, completed, progressChanged, null, refresh, timeout);
        }

        public static IEnumerator getMultipleFilePathsAsync(IList<string> filepaths, Action<List<string>> allCompleted, Action<string> completed, Action<string, float> progressChanged, Action<string, string, long> errorOccurred, bool refresh = false, int timeout = 0)
        {
            if (filepaths == null)
                throw new ArgumentNullException("filepaths");

            List<string> readableFilePaths = new List<string>();

            for (int i = 0; i < filepaths.Count; i++)
            {
                yield return getFilePathAsync(filepaths[i],
                (path) =>
                {
                    readableFilePaths.Add(path);

                    if (completed != null)
                        completed(path);
                },
                progressChanged,
                (path, error, code) =>
                {
                    readableFilePaths.Add(string.Empty);

                    if (errorOccurred != null)
                        errorOccurred(path, error, code);
                }
                , refresh, timeout);
            }

            if (allCompleted != null)
                allCompleted(readableFilePaths);
        }

        private static char[] chTrims = {
            '.',
#if UNITY_WINRT_8_1 && !UNITY_EDITOR
            '/',
            '\\'
#else
            System.IO.Path.DirectorySeparatorChar,
            System.IO.Path.AltDirectorySeparatorChar
#endif
        };

        internal static int URShift(int number, int bits)
        {
            if (number >= 0)
                return number >> bits;
            else
                return (number >> bits) + (2 << ~bits);
        }

        internal static long URShift(long number, int bits)//TODO:@check
        {
            if (number >= 0)
                return number >> bits;
            else
                return (number >> bits) + (2 << ~bits);
        }

        internal static int HashContents<T>(this IEnumerable<T> enumerable)//TODO:@check
        {
            int hash = 0x218A9B2C;
            foreach (var item in enumerable)
            {
                int thisHash = item.GetHashCode();
                //mix up the bits.
                hash = thisHash ^ ((hash << 5) + hash);
            }
            return hash;
        }

#if (UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "face_analyzer";
#endif
        
        [DllImport(LIBNAME)]
        private static extern void Utils_ByteArrayToMatData(IntPtr textureColors, IntPtr Mat);

        [DllImport(LIBNAME)]
        private static extern void Utils_TextureToMat(IntPtr textureColors, IntPtr Mat, [MarshalAs(UnmanagedType.U1)] bool flip, int flipCode);

        [DllImport(LIBNAME)]
        private static extern void Utils_FaceImageFromShape(IntPtr image, float rect_x, float rect_y, float rect_w, float rect_h, IntPtr faceShape, IntPtr normalized_facial_landmark, IntPtr faceImage, IntPtr textureImage, IntPtr normalizedTextureImage);
    }
}
