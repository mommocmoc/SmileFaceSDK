using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVCompact
{
    // C++: class Core
    public class Core
    {

        // these constants are wrapped inside functions to prevent inlining
        private static string getVersion () { return "4.2.0"; }
        private static string getNativeLibraryName () { return "opencvcompact"; }
        private static int getVersionMajor () { return 3; }
        private static int getVersionMinor () { return 3; }
        private static int getVersionRevision () { return 1; }
        private static string getVersionStatus () { return "-dev"; }

        public static readonly string VERSION = getVersion ();
        public static readonly string NATIVE_LIBRARY_NAME = getNativeLibraryName ();
        public static readonly int VERSION_MAJOR = getVersionMajor ();
        public static readonly int VERSION_MINOR = getVersionMinor ();
        public static readonly int VERSION_REVISION = getVersionRevision ();
        public static readonly string VERSION_STATUS = getVersionStatus ();

        private const int CV_8U = 0;
        private const int CV_8S = 1;
        private const int CV_16U = 2;
        private const int CV_16S = 3;
        private const int CV_32S = 4;
        private const int CV_32F = 5;
        private const int CV_64F = 6;
        private const int CV_USRTYPE1 = 7;
        public const int SVD_MODIFY_A = 1;
        public const int SVD_NO_UV = 2;
        public const int SVD_FULL_UV = 4;
        public const int FILLED = -1;
        public const int REDUCE_SUM = 0;
        public const int REDUCE_AVG = 1;
        public const int REDUCE_MAX = 2;
        public const int REDUCE_MIN = 3;
        public const int StsOk = 0;
        public const int StsBackTrace = -1;
        public const int StsError = -2;
        public const int StsInternal = -3;
        public const int StsNoMem = -4;
        public const int StsBadArg = -5;
        public const int StsBadFunc = -6;
        public const int StsNoConv = -7;
        public const int StsAutoTrace = -8;
        public const int HeaderIsNull = -9;
        public const int BadImageSize = -10;
        public const int BadOffset = -11;
        public const int BadDataPtr = -12;
        public const int BadStep = -13;
        public const int BadModelOrChSeq = -14;
        public const int BadNumChannels = -15;
        public const int BadNumChannel1U = -16;
        public const int BadDepth = -17;
        public const int BadAlphaChannel = -18;
        public const int BadOrder = -19;
        public const int BadOrigin = -20;
        public const int BadAlign = -21;
        public const int BadCallBack = -22;
        public const int BadTileSize = -23;
        public const int BadCOI = -24;
        public const int BadROISize = -25;
        public const int MaskIsTiled = -26;
        public const int StsNullPtr = -27;
        public const int StsVecLengthErr = -28;
        public const int StsFilterStructContentErr = -29;
        public const int StsKernelStructContentErr = -30;
        public const int StsFilterOffsetErr = -31;
        public const int StsBadSize = -201;
        public const int StsDivByZero = -202;
        public const int StsInplaceNotSupported = -203;
        public const int StsObjectNotFound = -204;
        public const int StsUnmatchedFormats = -205;
        public const int StsBadFlag = -206;
        public const int StsBadPoint = -207;
        public const int StsBadMask = -208;
        public const int StsUnmatchedSizes = -209;
        public const int StsUnsupportedFormat = -210;
        public const int StsOutOfRange = -211;
        public const int StsParseError = -212;
        public const int StsNotImplemented = -213;
        public const int StsBadMemBlock = -214;
        public const int StsAssert = -215;
        public const int GpuNotSupported = -216;
        public const int GpuApiCallError = -217;
        public const int OpenGlNotSupported = -218;
        public const int OpenGlApiCallError = -219;
        public const int OpenCLApiCallError = -220;
        public const int OpenCLDoubleNotSupported = -221;
        public const int OpenCLInitError = -222;
        public const int OpenCLNoAMDBlasFft = -223;
        public const int DECOMP_LU = 0;
        public const int DECOMP_SVD = 1;
        public const int DECOMP_EIG = 2;
        public const int DECOMP_CHOLESKY = 3;
        public const int DECOMP_QR = 4;
        public const int DECOMP_NORMAL = 16;
        public const int NORM_INF = 1;
        public const int NORM_L1 = 2;
        public const int NORM_L2 = 4;
        public const int NORM_L2SQR = 5;
        public const int NORM_HAMMING = 6;
        public const int NORM_HAMMING2 = 7;
        public const int NORM_TYPE_MASK = 7;
        public const int NORM_RELATIVE = 8;
        public const int NORM_MINMAX = 32;
        public const int CMP_EQ = 0;
        public const int CMP_GT = 1;
        public const int CMP_GE = 2;
        public const int CMP_LT = 3;
        public const int CMP_LE = 4;
        public const int CMP_NE = 5;
        public const int GEMM_1_T = 1;
        public const int GEMM_2_T = 2;
        public const int GEMM_3_T = 4;
        public const int DFT_INVERSE = 1;
        public const int DFT_SCALE = 2;
        public const int DFT_ROWS = 4;
        public const int DFT_COMPLEX_OUTPUT = 16;
        public const int DFT_REAL_OUTPUT = 32;
        public const int DFT_COMPLEX_INPUT = 64;
        public const int DCT_INVERSE = DFT_INVERSE;
        public const int DCT_ROWS = DFT_ROWS;
        public const int BORDER_CONSTANT = 0;
        public const int BORDER_REPLICATE = 1;
        public const int BORDER_REFLECT = 2;
        public const int BORDER_WRAP = 3;
        public const int BORDER_REFLECT_101 = 4;
        public const int BORDER_TRANSPARENT = 5;
        public const int BORDER_REFLECT101 = BORDER_REFLECT_101;
        public const int BORDER_DEFAULT = BORDER_REFLECT_101;
        public const int BORDER_ISOLATED = 16;
        public const int SORT_EVERY_ROW = 0;
        public const int SORT_EVERY_COLUMN = 1;
        public const int SORT_ASCENDING = 0;
        public const int SORT_DESCENDING = 16;
        public const int COVAR_SCRAMBLED = 0;
        public const int COVAR_NORMAL = 1;
        public const int COVAR_USE_AVG = 2;
        public const int COVAR_SCALE = 4;
        public const int COVAR_ROWS = 8;
        public const int COVAR_COLS = 16;
        public const int KMEANS_RANDOM_CENTERS = 0;
        public const int KMEANS_PP_CENTERS = 2;
        public const int KMEANS_USE_INITIAL_LABELS = 1;
        public const int LINE_4 = 4;
        public const int LINE_8 = 8;
        public const int LINE_AA = 16;
        public const int FONT_HERSHEY_SIMPLEX = 0;
        public const int FONT_HERSHEY_PLAIN = 1;
        public const int FONT_HERSHEY_DUPLEX = 2;
        public const int FONT_HERSHEY_COMPLEX = 3;
        public const int FONT_HERSHEY_TRIPLEX = 4;
        public const int FONT_HERSHEY_COMPLEX_SMALL = 5;
        public const int FONT_HERSHEY_SCRIPT_SIMPLEX = 6;
        public const int FONT_HERSHEY_SCRIPT_COMPLEX = 7;
        public const int FONT_ITALIC = 16;
        public const int ROTATE_90_CLOCKWISE = 0;
        public const int ROTATE_180 = 1;
        public const int ROTATE_90_COUNTERCLOCKWISE = 2;
        public const int TYPE_GENERAL = 0;
        public const int TYPE_MARKER = 0 + 1;
        public const int TYPE_WRAPPER = 0 + 2;
        public const int TYPE_FUN = 0 + 3;
        public const int IMPL_PLAIN = 0;
        public const int IMPL_IPP = 0 + 1;
        public const int IMPL_OPENCL = 0 + 2;
        public const int FLAGS_NONE = 0;
        public const int FLAGS_MAPPING = 0x01;
        public const int FLAGS_EXPAND_SAME_NAMES = 0x02;

        //
        // C++:  Scalar mean(Mat src, Mat mask = Mat())
        //
        public static Scalar mean(Mat src, Mat mask)
        {
            if (src != null) src.ThrowIfDisposed();
            if (mask != null) mask.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            double[] tmpArray = new double[4];
            core_Core_mean_10(src.nativeObj, mask.nativeObj, tmpArray);
            Scalar retVal = new Scalar(tmpArray);

#else
            return null;
#endif
            return retVal;
        }

        public static Scalar mean(Mat src)
        {
            if (src != null) src.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            double[] tmpArray = new double[4];
            core_Core_mean_11(src.nativeObj, tmpArray);
            Scalar retVal = new Scalar(tmpArray);

#else
            return null;
#endif
            return retVal;
        }


        //
        // C++:  Scalar sum(Mat src)
        //
        public static Scalar sumElems(Mat src)
        {
            if (src != null) src.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            double[] tmpArray = new double[4];
            core_Core_sumElems_10(src.nativeObj, tmpArray);
            Scalar retVal = new Scalar(tmpArray);

#else
            return null;
#endif
            return retVal;
        }


        //
        // C++:  Scalar trace(Mat mtx)
        //

        //javadoc: trace(mtx)
        public static Scalar trace(Mat mtx)
        {
            if (mtx != null) mtx.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            double[] tmpArray = new double[4];
            core_Core_trace_10(mtx.nativeObj, tmpArray);
            Scalar retVal = new Scalar(tmpArray);

#else
            return null;
#endif
            return retVal;
        }


        //
        // C++:  double invert(Mat src, Mat& dst, int flags = DECOMP_LU)
        //
        public static double invert(Mat src, Mat dst, int flags)
        {
            if (src != null) src.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            double retVal = core_Core_invert_10(src.nativeObj, dst.nativeObj, flags);

#else
            return -1;
#endif
            return retVal;
        }

        public static double invert(Mat src, Mat dst)
        {
            if (src != null) src.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            double retVal = core_Core_invert_11(src.nativeObj, dst.nativeObj);

#else
            return -1;
#endif
            return retVal;
        }


        //
        // C++:  double norm(Mat src1, Mat src2, int normType = NORM_L2, Mat mask = Mat())
        //
        public static double norm(Mat src1, Mat src2, int normType, Mat mask)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (src2 != null) src2.ThrowIfDisposed();
            if (mask != null) mask.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            double retVal = core_Core_norm_10(src1.nativeObj, src2.nativeObj, normType, mask.nativeObj);

#else
            return -1;
#endif
            return retVal;
        }

        public static double norm(Mat src1, Mat src2, int normType)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (src2 != null) src2.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            double retVal = core_Core_norm_11(src1.nativeObj, src2.nativeObj, normType);

#else
            return -1;
#endif
            return retVal;
        }

        public static double norm(Mat src1, Mat src2)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (src2 != null) src2.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            double retVal = core_Core_norm_12(src1.nativeObj, src2.nativeObj);

#else
            return -1;
#endif
            return retVal;
        }


        //
        // C++:  double norm(Mat src1, int normType = NORM_L2, Mat mask = Mat())
        //
        public static double norm(Mat src1, int normType, Mat mask)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (mask != null) mask.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            double retVal = core_Core_norm_13(src1.nativeObj, normType, mask.nativeObj);

#else
            return -1;
#endif
            return retVal;
        }

        public static double norm(Mat src1, int normType)
        {
            if (src1 != null) src1.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            double retVal = core_Core_norm_14(src1.nativeObj, normType);

#else
            return -1;
#endif
            return retVal;
        }

        public static double norm(Mat src1)
        {
            if (src1 != null) src1.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            double retVal = core_Core_norm_15(src1.nativeObj);

#else
            return -1;
#endif
            return retVal;
        }



        //
        // C++:  int countNonZero(Mat src)
        //
        public static int countNonZero(Mat src)
        {
            if (src != null) src.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            int retVal = core_Core_countNonZero_10(src.nativeObj);

#else
            return -1;
#endif
            return retVal;
        }




        //
        // C++:  void add(Mat src1, Mat src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
        //
        public static void add(Mat src1, Mat src2, Mat dst, Mat mask, int dtype)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (src2 != null) src2.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
            if (mask != null) mask.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_add_10(src1.nativeObj, src2.nativeObj, dst.nativeObj, mask.nativeObj, dtype);

#else
            return;
#endif
            return;
        }

        public static void add(Mat src1, Mat src2, Mat dst, Mat mask)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (src2 != null) src2.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
            if (mask != null) mask.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_add_11(src1.nativeObj, src2.nativeObj, dst.nativeObj, mask.nativeObj);

#else
            return;
#endif
            return;
        }

        public static void add(Mat src1, Mat src2, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (src2 != null) src2.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_add_12(src1.nativeObj, src2.nativeObj, dst.nativeObj);

#else
            return;
#endif
            return;
        }


        //
        // C++:  void add(Mat src1, Scalar src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
        //
        public static void add(Mat src1, Scalar src2, Mat dst, Mat mask, int dtype)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
            if (mask != null) mask.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_add_13(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj, mask.nativeObj, dtype);

#else
            return;
#endif
            return;
        }

        public static void add(Mat src1, Scalar src2, Mat dst, Mat mask)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
            if (mask != null) mask.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_add_14(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj, mask.nativeObj);

#else
            return;
#endif
            return;
        }

        public static void add(Mat src1, Scalar src2, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_add_15(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj);

#else
            return;
#endif
            return;
        }


        //
        // C++:  void divide(Mat src1, Mat src2, Mat& dst, double scale = 1, int dtype = -1)
        //
        public static void divide(Mat src1, Mat src2, Mat dst, double scale, int dtype)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (src2 != null) src2.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_divide_10(src1.nativeObj, src2.nativeObj, dst.nativeObj, scale, dtype);

#else
            return;
#endif
            return;
        }

        public static void divide(Mat src1, Mat src2, Mat dst, double scale)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (src2 != null) src2.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_divide_11(src1.nativeObj, src2.nativeObj, dst.nativeObj, scale);

#else
            return;
#endif
            return;
        }

        public static void divide(Mat src1, Mat src2, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (src2 != null) src2.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_divide_12(src1.nativeObj, src2.nativeObj, dst.nativeObj);

#else
            return;
#endif
            return;
        }


        //
        // C++:  void divide(Mat src1, Scalar src2, Mat& dst, double scale = 1, int dtype = -1)
        //
        public static void divide(Mat src1, Scalar src2, Mat dst, double scale, int dtype)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_divide_13(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj, scale, dtype);

#else
            return;
#endif
            return;
        }

        public static void divide(Mat src1, Scalar src2, Mat dst, double scale)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_divide_14(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj, scale);

#else
            return;
#endif
            return;
        }

        public static void divide(Mat src1, Scalar src2, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_divide_15(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj);

#else
            return;
#endif
            return;
        }


        //
        // C++:  void divide(double scale, Mat src2, Mat& dst, int dtype = -1)
        //
        public static void divide(double scale, Mat src2, Mat dst, int dtype)
        {
            if (src2 != null) src2.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_divide_16(scale, src2.nativeObj, dst.nativeObj, dtype);

#else
            return;
#endif
            return;
        }

        public static void divide(double scale, Mat src2, Mat dst)
        {
            if (src2 != null) src2.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_divide_17(scale, src2.nativeObj, dst.nativeObj);

#else
            return;
#endif
            return;
        }



        //
        // C++:  void exp(Mat src, Mat& dst)
        //
        public static void exp(Mat src, Mat dst)
        {
            if (src != null) src.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_exp_10(src.nativeObj, dst.nativeObj);

#else
            return;
#endif
            return;
        }


        //
        // C++:  void findNonZero(Mat src, Mat& idx)
        //
        public static void findNonZero(Mat src, Mat idx)
        {
            if (src != null) src.ThrowIfDisposed();
            if (idx != null) idx.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_findNonZero_10(src.nativeObj, idx.nativeObj);

#else
            return;
#endif
            return;
        }


        //
        // C++:  void flip(Mat src, Mat& dst, int flipCode)
        //
        public static void flip (Mat src, Mat dst, int flipCode)
        {
            if (src != null) src.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_flip_10(src.nativeObj, dst.nativeObj, flipCode);
        
#else
            return;
#endif
            return;
        }
        
        //
        // C++:  void gemm(Mat src1, Mat src2, double alpha, Mat src3, double beta, Mat& dst, int flags = 0)
        //
        public static void gemm (Mat src1, Mat src2, double alpha, Mat src3, double beta, Mat dst, int flags)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (src2 != null) src2.ThrowIfDisposed ();
            if (src3 != null) src3.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_gemm_10(src1.nativeObj, src2.nativeObj, alpha, src3.nativeObj, beta, dst.nativeObj, flags);
        
#else
            return;
#endif
            return;
        }

        public static void gemm (Mat src1, Mat src2, double alpha, Mat src3, double beta, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (src2 != null) src2.ThrowIfDisposed ();
            if (src3 != null) src3.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_gemm_11(src1.nativeObj, src2.nativeObj, alpha, src3.nativeObj, beta, dst.nativeObj);
        
#else
            return;
#endif
            return;
        }

        

        //
        // C++:  void max(Mat src1, Mat src2, Mat& dst)
        //
        public static void max (Mat src1, Mat src2, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (src2 != null) src2.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_max_10(src1.nativeObj, src2.nativeObj, dst.nativeObj);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void max(Mat src1, Scalar src2, Mat& dst)
        //
        public static void max (Mat src1, Scalar src2, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_max_11(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj);
        
#else
            return;
#endif
            return;
        }

        //
        // C++:  void min(Mat src1, Mat src2, Mat& dst)
        //
        public static void min (Mat src1, Mat src2, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (src2 != null) src2.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_min_10(src1.nativeObj, src2.nativeObj, dst.nativeObj);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void min(Mat src1, Scalar src2, Mat& dst)
        //
        public static void min (Mat src1, Scalar src2, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_min_11(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void mulTransposed(Mat src, Mat& dst, bool aTa, Mat delta = Mat(), double scale = 1, int dtype = -1)
        //
        public static void mulTransposed (Mat src, Mat dst, bool aTa, Mat delta, double scale, int dtype)
        {
            if (src != null) src.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
            if (delta != null) delta.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_mulTransposed_10(src.nativeObj, dst.nativeObj, aTa, delta.nativeObj, scale, dtype);
        
#else
            return;
#endif
            return;
        }

        public static void mulTransposed (Mat src, Mat dst, bool aTa, Mat delta, double scale)
        {
            if (src != null) src.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
            if (delta != null) delta.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_mulTransposed_11(src.nativeObj, dst.nativeObj, aTa, delta.nativeObj, scale);
        
#else
            return;
#endif
            return;
        }

        public static void mulTransposed (Mat src, Mat dst, bool aTa)
        {
            if (src != null) src.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_mulTransposed_12(src.nativeObj, dst.nativeObj, aTa);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void multiply(Mat src1, Mat src2, Mat& dst, double scale = 1, int dtype = -1)
        //
        public static void multiply (Mat src1, Mat src2, Mat dst, double scale, int dtype)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (src2 != null) src2.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_multiply_10(src1.nativeObj, src2.nativeObj, dst.nativeObj, scale, dtype);
        
#else
            return;
#endif
            return;
        }

        public static void multiply (Mat src1, Mat src2, Mat dst, double scale)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (src2 != null) src2.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_multiply_11(src1.nativeObj, src2.nativeObj, dst.nativeObj, scale);
        
#else
            return;
#endif
            return;
        }

        public static void multiply (Mat src1, Mat src2, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (src2 != null) src2.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_multiply_12(src1.nativeObj, src2.nativeObj, dst.nativeObj);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void multiply(Mat src1, Scalar src2, Mat& dst, double scale = 1, int dtype = -1)
        //
        public static void multiply (Mat src1, Scalar src2, Mat dst, double scale, int dtype)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_multiply_13(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj, scale, dtype);
        
#else
            return;
#endif
            return;
        }

        public static void multiply (Mat src1, Scalar src2, Mat dst, double scale)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_multiply_14(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj, scale);
        
#else
            return;
#endif
            return;
        }

        public static void multiply (Mat src1, Scalar src2, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_multiply_15(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void normalize(Mat src, Mat& dst, double alpha = 1, double beta = 0, int norm_type = NORM_L2, int dtype = -1, Mat mask = Mat())
        //
        public static void normalize (Mat src, Mat dst, double alpha, double beta, int norm_type, int dtype, Mat mask)
        {
            if (src != null) src.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
            if (mask != null) mask.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_normalize_10(src.nativeObj, dst.nativeObj, alpha, beta, norm_type, dtype, mask.nativeObj);
        
#else
            return;
#endif
            return;
        }

        public static void normalize (Mat src, Mat dst, double alpha, double beta, int norm_type, int dtype)
        {
            if (src != null) src.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_normalize_11(src.nativeObj, dst.nativeObj, alpha, beta, norm_type, dtype);
        
#else
            return;
#endif
            return;
        }

        public static void normalize (Mat src, Mat dst, double alpha, double beta, int norm_type)
        {
            if (src != null) src.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_normalize_12(src.nativeObj, dst.nativeObj, alpha, beta, norm_type);
        
#else
            return;
#endif
            return;
        }

        public static void normalize (Mat src, Mat dst)
        {
            if (src != null) src.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_normalize_13(src.nativeObj, dst.nativeObj);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void rotate(Mat src, Mat& dst, int rotateCode)
        //
        public static void rotate(Mat src, Mat dst, int rotateCode)
        {
            if (src != null) src.ThrowIfDisposed();
            if (dst != null) dst.ThrowIfDisposed();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

            core_Core_rotate_10(src.nativeObj, dst.nativeObj, rotateCode);

#else
            return;
#endif
            return;
        }


        //
        // C++:  void scaleAdd(Mat src1, double alpha, Mat src2, Mat& dst)
        //
        public static void scaleAdd (Mat src1, double alpha, Mat src2, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (src2 != null) src2.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_scaleAdd_10(src1.nativeObj, alpha, src2.nativeObj, dst.nativeObj);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void setIdentity(Mat& mtx, Scalar s = Scalar(1))
        //
        public static void setIdentity (Mat mtx, Scalar s)
        {
            if (mtx != null) mtx.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_setIdentity_10(mtx.nativeObj, s.val[0], s.val[1], s.val[2], s.val[3]);
        
#else
            return;
#endif
            return;
        }

        public static void setIdentity (Mat mtx)
        {
            if (mtx != null) mtx.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            core_Core_setIdentity_11(mtx.nativeObj);
        
#else
            return;
#endif
            return;
        }

        //
        // C++:  void sqrt(Mat src, Mat& dst)
        //
        public static void sqrt (Mat src, Mat dst)
        {
            if (src != null) src.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_sqrt_10(src.nativeObj, dst.nativeObj);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void subtract(Mat src1, Mat src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
        //
        public static void subtract (Mat src1, Mat src2, Mat dst, Mat mask, int dtype)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (src2 != null) src2.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
            if (mask != null) mask.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_subtract_10(src1.nativeObj, src2.nativeObj, dst.nativeObj, mask.nativeObj, dtype);
        
#else
            return;
#endif
            return;
        }

        public static void subtract (Mat src1, Mat src2, Mat dst, Mat mask)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (src2 != null) src2.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
            if (mask != null) mask.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_subtract_11(src1.nativeObj, src2.nativeObj, dst.nativeObj, mask.nativeObj);
        
#else
            return;
#endif
            return;
        }

        public static void subtract (Mat src1, Mat src2, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (src2 != null) src2.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_subtract_12(src1.nativeObj, src2.nativeObj, dst.nativeObj);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void subtract(Mat src1, Scalar src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
        //
        public static void subtract (Mat src1, Scalar src2, Mat dst, Mat mask, int dtype)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
            if (mask != null) mask.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_subtract_13(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj, mask.nativeObj, dtype);
        
#else
            return;
#endif
            return;
        }

        public static void subtract (Mat src1, Scalar src2, Mat dst, Mat mask)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
            if (mask != null) mask.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_subtract_14(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj, mask.nativeObj);
        
#else
            return;
#endif
            return;
        }

        public static void subtract (Mat src1, Scalar src2, Mat dst)
        {
            if (src1 != null) src1.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        core_Core_subtract_15(src1.nativeObj, src2.val[0], src2.val[1], src2.val[2], src2.val[3], dst.nativeObj);
        
#else
            return;
#endif
            return;
        }

        // manual port
        public class MinMaxLocResult
        {
            public double minVal;
            public double maxVal;
            public Point minLoc;
            public Point maxLoc;


            public MinMaxLocResult ()
            {
                minVal = 0; maxVal = 0;
                minLoc = new Point ();
                maxLoc = new Point ();
            }
        }


#if (UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "face_analyzer";
#endif



        // C++:  Scalar mean(Mat src, Mat mask = Mat())
        [DllImport (LIBNAME)]
        private static extern void core_Core_mean_10 (IntPtr src_nativeObj, IntPtr mask_nativeObj, double[] retVal);
        [DllImport (LIBNAME)]
        private static extern void core_Core_mean_11 (IntPtr src_nativeObj, double[] retVal);

        // C++:  Scalar sum(Mat src)
        [DllImport (LIBNAME)]
        private static extern void core_Core_sumElems_10 (IntPtr src_nativeObj, double[] retVal);

        // C++:  Scalar trace(Mat mtx)
        [DllImport (LIBNAME)]
        private static extern void core_Core_trace_10 (IntPtr mtx_nativeObj, double[] retVal);

        // C++:  String getBuildInformation()
        [DllImport (LIBNAME)]
        private static extern IntPtr core_Core_getBuildInformation_10 ();

        // C++:  double invert(Mat src, Mat& dst, int flags = DECOMP_LU)
        [DllImport (LIBNAME)]
        private static extern double core_Core_invert_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags);
        [DllImport (LIBNAME)]
        private static extern double core_Core_invert_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);

        // C++:  double norm(Mat src1, Mat src2, int normType = NORM_L2, Mat mask = Mat())
        [DllImport (LIBNAME)]
        private static extern double core_Core_norm_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, int normType, IntPtr mask_nativeObj);
        [DllImport (LIBNAME)]
        private static extern double core_Core_norm_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, int normType);
        [DllImport (LIBNAME)]
        private static extern double core_Core_norm_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj);

        // C++:  double norm(Mat src1, int normType = NORM_L2, Mat mask = Mat())
        [DllImport (LIBNAME)]
        private static extern double core_Core_norm_13 (IntPtr src1_nativeObj, int normType, IntPtr mask_nativeObj);
        [DllImport (LIBNAME)]
        private static extern double core_Core_norm_14 (IntPtr src1_nativeObj, int normType);
        [DllImport (LIBNAME)]
        private static extern double core_Core_norm_15 (IntPtr src1_nativeObj);

        // C++:  int countNonZero(Mat src)
        [DllImport (LIBNAME)]
        private static extern int core_Core_countNonZero_10 (IntPtr src_nativeObj);

        // C++:  void add(Mat src1, Mat src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
        [DllImport (LIBNAME)]
        private static extern void core_Core_add_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj, int dtype);
        [DllImport (LIBNAME)]
        private static extern void core_Core_add_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);
        [DllImport (LIBNAME)]
        private static extern void core_Core_add_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);

        // C++:  void add(Mat src1, Scalar src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
        [DllImport (LIBNAME)]
        private static extern void core_Core_add_13 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, IntPtr mask_nativeObj, int dtype);
        [DllImport (LIBNAME)]
        private static extern void core_Core_add_14 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, IntPtr mask_nativeObj);
        [DllImport (LIBNAME)]
        private static extern void core_Core_add_15 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);

        // C++:  void divide(Mat src1, Mat src2, Mat& dst, double scale = 1, int dtype = -1)
        [DllImport (LIBNAME)]
        private static extern void core_Core_divide_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, double scale, int dtype);
        [DllImport (LIBNAME)]
        private static extern void core_Core_divide_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, double scale);
        [DllImport (LIBNAME)]
        private static extern void core_Core_divide_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);

        // C++:  void divide(Mat src1, Scalar src2, Mat& dst, double scale = 1, int dtype = -1)
        [DllImport (LIBNAME)]
        private static extern void core_Core_divide_13 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, double scale, int dtype);
        [DllImport (LIBNAME)]
        private static extern void core_Core_divide_14 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, double scale);
        [DllImport (LIBNAME)]
        private static extern void core_Core_divide_15 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);

        // C++:  void divide(double scale, Mat src2, Mat& dst, int dtype = -1)
        [DllImport (LIBNAME)]
        private static extern void core_Core_divide_16 (double scale, IntPtr src2_nativeObj, IntPtr dst_nativeObj, int dtype);
        [DllImport (LIBNAME)]
        private static extern void core_Core_divide_17 (double scale, IntPtr src2_nativeObj, IntPtr dst_nativeObj);

        // C++:  void exp(Mat src, Mat& dst)
        [DllImport (LIBNAME)]
        private static extern void core_Core_exp_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj);

        // C++:  void findNonZero(Mat src, Mat& idx)
        [DllImport (LIBNAME)]
        private static extern void core_Core_findNonZero_10 (IntPtr src_nativeObj, IntPtr idx_nativeObj);

        // C++:  void flip(Mat src, Mat& dst, int flipCode)
        [DllImport (LIBNAME)]
        private static extern void core_Core_flip_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flipCode);

        // C++:  void gemm(Mat src1, Mat src2, double alpha, Mat src3, double beta, Mat& dst, int flags = 0)
        [DllImport (LIBNAME)]
        private static extern void core_Core_gemm_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, double alpha, IntPtr src3_nativeObj, double beta, IntPtr dst_nativeObj, int flags);
        [DllImport (LIBNAME)]
        private static extern void core_Core_gemm_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, double alpha, IntPtr src3_nativeObj, double beta, IntPtr dst_nativeObj);

        // C++:  void max(Mat src1, Mat src2, Mat& dst)
        [DllImport (LIBNAME)]
        private static extern void core_Core_max_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);

        // C++:  void max(Mat src1, Scalar src2, Mat& dst)
        [DllImport (LIBNAME)]
        private static extern void core_Core_max_11 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);

        // C++:  void meanStdDev(Mat src, vector_double& mean, vector_double& stddev, Mat mask = Mat())
        [DllImport (LIBNAME)]
        private static extern void core_Core_meanStdDev_10 (IntPtr src_nativeObj, IntPtr mean_mat_nativeObj, IntPtr stddev_mat_nativeObj, IntPtr mask_nativeObj);
        [DllImport (LIBNAME)]
        private static extern void core_Core_meanStdDev_11 (IntPtr src_nativeObj, IntPtr mean_mat_nativeObj, IntPtr stddev_mat_nativeObj);

        // C++:  void merge(vector_Mat mv, Mat& dst)
        [DllImport (LIBNAME)]
        private static extern void core_Core_merge_10 (IntPtr mv_mat_nativeObj, IntPtr dst_nativeObj);

        // C++:  void min(Mat src1, Mat src2, Mat& dst)
        [DllImport (LIBNAME)]
        private static extern void core_Core_min_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);

        // C++:  void min(Mat src1, Scalar src2, Mat& dst)
        [DllImport (LIBNAME)]
        private static extern void core_Core_min_11 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);

        // C++:  void mulTransposed(Mat src, Mat& dst, bool aTa, Mat delta = Mat(), double scale = 1, int dtype = -1)
        [DllImport (LIBNAME)]
        private static extern void core_Core_mulTransposed_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, bool aTa, IntPtr delta_nativeObj, double scale, int dtype);
        [DllImport (LIBNAME)]
        private static extern void core_Core_mulTransposed_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj, bool aTa, IntPtr delta_nativeObj, double scale);
        [DllImport (LIBNAME)]
        private static extern void core_Core_mulTransposed_12 (IntPtr src_nativeObj, IntPtr dst_nativeObj, bool aTa);

        // C++:  void multiply(Mat src1, Mat src2, Mat& dst, double scale = 1, int dtype = -1)
        [DllImport (LIBNAME)]
        private static extern void core_Core_multiply_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, double scale, int dtype);
        [DllImport (LIBNAME)]
        private static extern void core_Core_multiply_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, double scale);
        [DllImport (LIBNAME)]
        private static extern void core_Core_multiply_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);

        // C++:  void multiply(Mat src1, Scalar src2, Mat& dst, double scale = 1, int dtype = -1)
        [DllImport (LIBNAME)]
        private static extern void core_Core_multiply_13 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, double scale, int dtype);
        [DllImport (LIBNAME)]
        private static extern void core_Core_multiply_14 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, double scale);
        [DllImport (LIBNAME)]
        private static extern void core_Core_multiply_15 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);

        // C++:  void normalize(Mat src, Mat& dst, double alpha = 1, double beta = 0, int norm_type = NORM_L2, int dtype = -1, Mat mask = Mat())
        [DllImport (LIBNAME)]
        private static extern void core_Core_normalize_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, double alpha, double beta, int norm_type, int dtype, IntPtr mask_nativeObj);
        [DllImport (LIBNAME)]
        private static extern void core_Core_normalize_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj, double alpha, double beta, int norm_type, int dtype);
        [DllImport (LIBNAME)]
        private static extern void core_Core_normalize_12 (IntPtr src_nativeObj, IntPtr dst_nativeObj, double alpha, double beta, int norm_type);
        [DllImport (LIBNAME)]
        private static extern void core_Core_normalize_13 (IntPtr src_nativeObj, IntPtr dst_nativeObj);

        // C++:  void rotate(Mat src, Mat& dst, int rotateCode)
        [DllImport (LIBNAME)]
        private static extern void core_Core_rotate_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int rotateCode);

        // C++:  void scaleAdd(Mat src1, double alpha, Mat src2, Mat& dst)
        [DllImport (LIBNAME)]
        private static extern void core_Core_scaleAdd_10 (IntPtr src1_nativeObj, double alpha, IntPtr src2_nativeObj, IntPtr dst_nativeObj);

        // C++:  void setIdentity(Mat& mtx, Scalar s = Scalar(1))
        [DllImport (LIBNAME)]
        private static extern void core_Core_setIdentity_10 (IntPtr mtx_nativeObj, double s_val0, double s_val1, double s_val2, double s_val3);
        [DllImport (LIBNAME)]
        private static extern void core_Core_setIdentity_11 (IntPtr mtx_nativeObj);

        // C++:  void sqrt(Mat src, Mat& dst)
        [DllImport (LIBNAME)]
        private static extern void core_Core_sqrt_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj);

        // C++:  void subtract(Mat src1, Mat src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
        [DllImport (LIBNAME)]
        private static extern void core_Core_subtract_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj, int dtype);
        [DllImport (LIBNAME)]
        private static extern void core_Core_subtract_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);
        [DllImport (LIBNAME)]
        private static extern void core_Core_subtract_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);

        // C++:  void subtract(Mat src1, Scalar src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
        [DllImport (LIBNAME)]
        private static extern void core_Core_subtract_13 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, IntPtr mask_nativeObj, int dtype);
        [DllImport (LIBNAME)]
        private static extern void core_Core_subtract_14 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, IntPtr mask_nativeObj);
        [DllImport (LIBNAME)]
        private static extern void core_Core_subtract_15 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);

        //[DllImport (LIBNAME)]
        //private static extern void core_Core_n_1minMaxLocManual (IntPtr src_nativeObj, IntPtr mask_nativeObj, double[] vals);
    }
}
