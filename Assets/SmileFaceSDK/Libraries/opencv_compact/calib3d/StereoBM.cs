using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVCompact
{

    // C++: class StereoBM
    /**
     * Class for computing stereo correspondence using the block matching algorithm, introduced and
     * contributed to OpenCV by K. Konolige.
     */
    public class StereoBM : StereoMatcher
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
                        StereoBM_delete(nativeObj);
                    nativeObj = IntPtr.Zero;
                }
            }
            finally
            {
                base.Dispose(disposing);
            }

        }

        protected internal StereoBM(IntPtr addr) : base(addr) { }

        // internal usage only
        public static new StereoBM __fromPtr__(IntPtr addr) { return new StereoBM(addr); }

        // C++: enum <unnamed>
        public const int PREFILTER_NORMALIZED_RESPONSE = 0;
        public const int PREFILTER_XSOBEL = 1;

        //
        // C++: static Ptr_StereoBM cv::StereoBM::create(int numDisparities = 0, int blockSize = 21)
        //

        /**
         * Creates StereoBM object
         *
         *     @param numDisparities the disparity search range. For each pixel algorithm will find the best
         *     disparity from 0 (default minimum disparity) to numDisparities. The search range can then be
         *     shifted by changing the minimum disparity.
         *     @param blockSize the linear size of the blocks compared by the algorithm. The size should be odd
         *     (as the block is centered at the current pixel). Larger block size implies smoother, though less
         *     accurate disparity map. Smaller block size gives more detailed disparity map, but there is higher
         *     chance for algorithm to find a wrong correspondence.
         *
         *     The function create StereoBM object. You can then call StereoBM::compute() to compute disparity for
         *     a specific stereo pair.
         * @return automatically generated
         */
        public static StereoBM create(int numDisparities, int blockSize)
        {       
        return StereoBM.__fromPtr__(StereoBM_create_10(numDisparities, blockSize));
        }


        /**
         * Creates StereoBM object
         *
         *     @param numDisparities the disparity search range. For each pixel algorithm will find the best
         *     disparity from 0 (default minimum disparity) to numDisparities. The search range can then be
         *     shifted by changing the minimum disparity.
         *     (as the block is centered at the current pixel). Larger block size implies smoother, though less
         *     accurate disparity map. Smaller block size gives more detailed disparity map, but there is higher
         *     chance for algorithm to find a wrong correspondence.
         *
         *     The function create StereoBM object. You can then call StereoBM::compute() to compute disparity for
         *     a specific stereo pair.
         * @return automatically generated
         */
        public static StereoBM create(int numDisparities)
        {            
        return StereoBM.__fromPtr__(StereoBM_create_11(numDisparities));
        }


        /**
         * Creates StereoBM object
         *
         *     disparity from 0 (default minimum disparity) to numDisparities. The search range can then be
         *     shifted by changing the minimum disparity.
         *     (as the block is centered at the current pixel). Larger block size implies smoother, though less
         *     accurate disparity map. Smaller block size gives more detailed disparity map, but there is higher
         *     chance for algorithm to find a wrong correspondence.
         *
         *     The function create StereoBM object. You can then call StereoBM::compute() to compute disparity for
         *     a specific stereo pair.
         * @return automatically generated
         */
        public static StereoBM create()
        {        
        return StereoBM.__fromPtr__(StereoBM_create_12());
        }


        //
        // C++:  Rect cv::StereoBM::getROI1()
        //
        public Rect getROI1()
        {

        double[] tmpArray = new double[4];
        getROI1_10(nativeObj, tmpArray);
        Rect retVal = new Rect (tmpArray);
        
        return retVal;
        }


        //
        // C++:  Rect cv::StereoBM::getROI2()
        //
        public Rect getROI2()
        {

        double[] tmpArray = new double[4];
        getROI2_10(nativeObj, tmpArray);
        Rect retVal = new Rect (tmpArray);
        
        return retVal;
        }


        //
        // C++:  int cv::StereoBM::getPreFilterCap()
        //
        public int getPreFilterCap()
        {
        int retVal = getPreFilterCap_10(nativeObj);
        return retVal;
        }


        //
        // C++:  int cv::StereoBM::getPreFilterSize()
        //
        public int getPreFilterSize()
        {        
        return getPreFilterSize_10(nativeObj);
        }


        //
        // C++:  int cv::StereoBM::getPreFilterType()
        //
        public int getPreFilterType()
        {
        return getPreFilterType_10(nativeObj);
        }


        //
        // C++:  int cv::StereoBM::getSmallerBlockSize()
        //        
        public int getSmallerBlockSize()
        {        
        return getSmallerBlockSize_10(nativeObj);
        }


        //
        // C++:  int cv::StereoBM::getTextureThreshold()
        //
        public int getTextureThreshold()
        {
        return getTextureThreshold_10(nativeObj);
        }


        //
        // C++:  int cv::StereoBM::getUniquenessRatio()
        //
        public int getUniquenessRatio()
        {
        return getUniquenessRatio_10(nativeObj);
        }


        //
        // C++:  void cv::StereoBM::setPreFilterCap(int preFilterCap)
        //
        public void setPreFilterCap(int preFilterCap)
        {
            setPreFilterCap_10(nativeObj, preFilterCap);
        }


        //
        // C++:  void cv::StereoBM::setPreFilterSize(int preFilterSize)
        //
        public void setPreFilterSize(int preFilterSize)
        {
            setPreFilterSize_10(nativeObj, preFilterSize);
        }


        //
        // C++:  void cv::StereoBM::setPreFilterType(int preFilterType)
        //
        public void setPreFilterType(int preFilterType)
        {
            setPreFilterType_10(nativeObj, preFilterType);
        }


        //
        // C++:  void cv::StereoBM::setROI1(Rect roi1)
        //
        public void setROI1(Rect roi1)
        {
            setROI1_10(nativeObj, roi1.x, roi1.y, roi1.width, roi1.height);
        }


        //
        // C++:  void cv::StereoBM::setROI2(Rect roi2)
        //
        public void setROI2(Rect roi2)
        {
            setROI2_10(nativeObj, roi2.x, roi2.y, roi2.width, roi2.height);      
        }


        //
        // C++:  void cv::StereoBM::setSmallerBlockSize(int blockSize)
        //
        public void setSmallerBlockSize(int blockSize)
        {
            setSmallerBlockSize_10(nativeObj, blockSize);
        }


        //
        // C++:  void cv::StereoBM::setTextureThreshold(int textureThreshold)
        //
        public void setTextureThreshold(int textureThreshold)
        {
            setTextureThreshold_10(nativeObj, textureThreshold);
        }


        //
        // C++:  void cv::StereoBM::setUniquenessRatio(int uniquenessRatio)
        //
        public void setUniquenessRatio(int uniquenessRatio)
        {
            setUniquenessRatio_10(nativeObj, uniquenessRatio);
        }


#if (UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "face_analyzer";
#endif

        // C++: static Ptr_StereoBM cv::StereoBM::create(int numDisparities = 0, int blockSize = 21)
        [DllImport(LIBNAME)]
        private static extern IntPtr StereoBM_create_10(int numDisparities, int blockSize);
        [DllImport(LIBNAME)]
        private static extern IntPtr StereoBM_create_11(int numDisparities);
        [DllImport(LIBNAME)]
        private static extern IntPtr StereoBM_create_12();

        // C++:  Rect cv::StereoBM::getROI1()
        [DllImport(LIBNAME)]
        private static extern void getROI1_10(IntPtr nativeObj, double[] retVal);

        // C++:  Rect cv::StereoBM::getROI2()
        [DllImport(LIBNAME)]
        private static extern void getROI2_10(IntPtr nativeObj, double[] retVal);

        // C++:  int cv::StereoBM::getPreFilterCap()
        [DllImport(LIBNAME)]
        private static extern int getPreFilterCap_10(IntPtr nativeObj);

        // C++:  int cv::StereoBM::getPreFilterSize()
        [DllImport(LIBNAME)]
        private static extern int getPreFilterSize_10(IntPtr nativeObj);

        // C++:  int cv::StereoBM::getPreFilterType()
        [DllImport(LIBNAME)]
        private static extern int getPreFilterType_10(IntPtr nativeObj);

        // C++:  int cv::StereoBM::getSmallerBlockSize()
        [DllImport(LIBNAME)]
        private static extern int getSmallerBlockSize_10(IntPtr nativeObj);

        // C++:  int cv::StereoBM::getTextureThreshold()
        [DllImport(LIBNAME)]
        private static extern int getTextureThreshold_10(IntPtr nativeObj);

        // C++:  int cv::StereoBM::getUniquenessRatio()
        [DllImport(LIBNAME)]
        private static extern int getUniquenessRatio_10(IntPtr nativeObj);

        // C++:  void cv::StereoBM::setPreFilterCap(int preFilterCap)
        [DllImport(LIBNAME)]
        private static extern void setPreFilterCap_10(IntPtr nativeObj, int preFilterCap);

        // C++:  void cv::StereoBM::setPreFilterSize(int preFilterSize)
        [DllImport(LIBNAME)]
        private static extern void setPreFilterSize_10(IntPtr nativeObj, int preFilterSize);

        // C++:  void cv::StereoBM::setPreFilterType(int preFilterType)
        [DllImport(LIBNAME)]
        private static extern void setPreFilterType_10(IntPtr nativeObj, int preFilterType);

        // C++:  void cv::StereoBM::setROI1(Rect roi1)
        [DllImport(LIBNAME)]
        private static extern void setROI1_10(IntPtr nativeObj, int roi1_x, int roi1_y, int roi1_width, int roi1_height);

        // C++:  void cv::StereoBM::setROI2(Rect roi2)
        [DllImport(LIBNAME)]
        private static extern void setROI2_10(IntPtr nativeObj, int roi2_x, int roi2_y, int roi2_width, int roi2_height);

        // C++:  void cv::StereoBM::setSmallerBlockSize(int blockSize)
        [DllImport(LIBNAME)]
        private static extern void setSmallerBlockSize_10(IntPtr nativeObj, int blockSize);

        // C++:  void cv::StereoBM::setTextureThreshold(int textureThreshold)
        [DllImport(LIBNAME)]
        private static extern void setTextureThreshold_10(IntPtr nativeObj, int textureThreshold);

        // C++:  void cv::StereoBM::setUniquenessRatio(int uniquenessRatio)
        [DllImport(LIBNAME)]
        private static extern void setUniquenessRatio_10(IntPtr nativeObj, int uniquenessRatio);

        // native support for java finalize()
        [DllImport(LIBNAME)]
        private static extern void StereoBM_delete(IntPtr nativeObj);
    }
}
