using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVCompact
{
    // C++: class StereoMatcher
    /**
     * The base class for stereo correspondence algorithms.
     */
    public class StereoMatcher : Algorithm
    {
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
                        StereoMatcher_delete(nativeObj);
                    nativeObj = IntPtr.Zero;
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected internal StereoMatcher(IntPtr addr) : base(addr) { }

        // internal usage only
        public static new StereoMatcher __fromPtr__(IntPtr addr) { return new StereoMatcher(addr); }

        // C++: enum <unnamed>
        public const int DISP_SHIFT = 4;
        public const int DISP_SCALE = (1 << DISP_SHIFT);

        //
        // C++:  int cv::StereoMatcher::getBlockSize()
        //
        public int getBlockSize()
        {
            return getBlockSize_10(nativeObj);
        }


        //
        // C++:  int cv::StereoMatcher::getDisp12MaxDiff()
        //
        public int getDisp12MaxDiff()
        {
            return getDisp12MaxDiff_10(nativeObj);
        }


        //
        // C++:  int cv::StereoMatcher::getMinDisparity()
        //
        public int getMinDisparity()
        {        
            return getMinDisparity_10(nativeObj);
        }


        //
        // C++:  int cv::StereoMatcher::getNumDisparities()
        //        
        public int getNumDisparities()
        {
            return getNumDisparities_10(nativeObj);
        }


        //
        // C++:  int cv::StereoMatcher::getSpeckleRange()
        //
        public int getSpeckleRange()
        {
            return getSpeckleRange_10(nativeObj);
        }


        //
        // C++:  int cv::StereoMatcher::getSpeckleWindowSize()
        //
        public int getSpeckleWindowSize()
        {
            return getSpeckleWindowSize_10(nativeObj);
        }


        //
        // C++:  void cv::StereoMatcher::compute(Mat left, Mat right, Mat& disparity)
        //

        /**
         * Computes disparity map for the specified stereo pair
         *
         *     @param left Left 8-bit single-channel image.
         *     @param right Right image of the same size and the same type as the left one.
         *     @param disparity Output disparity map. It has the same size as the input images. Some algorithms,
         *     like StereoBM or StereoSGBM compute 16-bit fixed-point disparity map (where each disparity value
         *     has 4 fractional bits), whereas other algorithms output 32-bit floating-point disparity map.
         */
        public void compute(Mat left, Mat right, Mat disparity)
        {
            if (left != null) left.ThrowIfDisposed();
            if (right != null) right.ThrowIfDisposed();
            if (disparity != null) disparity.ThrowIfDisposed();

            compute_10(nativeObj, left.nativeObj, right.nativeObj, disparity.nativeObj);
        }


        //
        // C++:  void cv::StereoMatcher::setBlockSize(int blockSize)
        //
        public void setBlockSize(int blockSize)
        {       
            setBlockSize_10(nativeObj, blockSize);
        }


        //
        // C++:  void cv::StereoMatcher::setDisp12MaxDiff(int disp12MaxDiff)
        //
        public void setDisp12MaxDiff(int disp12MaxDiff)
        {
            setDisp12MaxDiff_10(nativeObj, disp12MaxDiff);    
        }


        //
        // C++:  void cv::StereoMatcher::setMinDisparity(int minDisparity)
        //
        public void setMinDisparity(int minDisparity)
        {        
            setMinDisparity_10(nativeObj, minDisparity);        
        }


        //
        // C++:  void cv::StereoMatcher::setNumDisparities(int numDisparities)
        //
        public void setNumDisparities(int numDisparities)
        {  
            setNumDisparities_10(nativeObj, numDisparities);
        }


        //
        // C++:  void cv::StereoMatcher::setSpeckleRange(int speckleRange)
        //
        public void setSpeckleRange(int speckleRange)
        {      
            setSpeckleRange_10(nativeObj, speckleRange);        
        }


        //
        // C++:  void cv::StereoMatcher::setSpeckleWindowSize(int speckleWindowSize)
        //
        public void setSpeckleWindowSize(int speckleWindowSize)
        {        
            setSpeckleWindowSize_10(nativeObj, speckleWindowSize);
        }


#if (UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "face_analyzer";
#endif
                
        // C++:  int cv::StereoMatcher::getBlockSize()
        [DllImport(LIBNAME)]
        private static extern int getBlockSize_10(IntPtr nativeObj);

        // C++:  int cv::StereoMatcher::getDisp12MaxDiff()
        [DllImport(LIBNAME)]
        private static extern int getDisp12MaxDiff_10(IntPtr nativeObj);

        // C++:  int cv::StereoMatcher::getMinDisparity()
        [DllImport(LIBNAME)]
        private static extern int getMinDisparity_10(IntPtr nativeObj);

        // C++:  int cv::StereoMatcher::getNumDisparities()
        [DllImport(LIBNAME)]
        private static extern int getNumDisparities_10(IntPtr nativeObj);

        // C++:  int cv::StereoMatcher::getSpeckleRange()
        [DllImport(LIBNAME)]
        private static extern int getSpeckleRange_10(IntPtr nativeObj);

        // C++:  int cv::StereoMatcher::getSpeckleWindowSize()
        [DllImport(LIBNAME)]
        private static extern int getSpeckleWindowSize_10(IntPtr nativeObj);

        // C++:  void cv::StereoMatcher::compute(Mat left, Mat right, Mat& disparity)
        [DllImport(LIBNAME)]
        private static extern void compute_10(IntPtr nativeObj, IntPtr left_nativeObj, IntPtr right_nativeObj, IntPtr disparity_nativeObj);

        // C++:  void cv::StereoMatcher::setBlockSize(int blockSize)
        [DllImport(LIBNAME)]
        private static extern void setBlockSize_10(IntPtr nativeObj, int blockSize);

        // C++:  void cv::StereoMatcher::setDisp12MaxDiff(int disp12MaxDiff)
        [DllImport(LIBNAME)]
        private static extern void setDisp12MaxDiff_10(IntPtr nativeObj, int disp12MaxDiff);

        // C++:  void cv::StereoMatcher::setMinDisparity(int minDisparity)
        [DllImport(LIBNAME)]
        private static extern void setMinDisparity_10(IntPtr nativeObj, int minDisparity);

        // C++:  void cv::StereoMatcher::setNumDisparities(int numDisparities)
        [DllImport(LIBNAME)]
        private static extern void setNumDisparities_10(IntPtr nativeObj, int numDisparities);

        // C++:  void cv::StereoMatcher::setSpeckleRange(int speckleRange)
        [DllImport(LIBNAME)]
        private static extern void setSpeckleRange_10(IntPtr nativeObj, int speckleRange);

        // C++:  void cv::StereoMatcher::setSpeckleWindowSize(int speckleWindowSize)
        [DllImport(LIBNAME)]
        private static extern void setSpeckleWindowSize_10(IntPtr nativeObj, int speckleWindowSize);

        // native support for java finalize()
        [DllImport(LIBNAME)]
        private static extern void StereoMatcher_delete(IntPtr nativeObj);

    }
}
