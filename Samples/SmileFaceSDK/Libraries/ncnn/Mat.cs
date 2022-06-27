using OpenCVCompact;
using System;
using System.Runtime.InteropServices;

namespace NCNN
{
    public class Mat : OpenCVCompact.DisposableOpenCVCompactObject
    {
        public enum PixelType
        {
            PIXEL_CONVERT_SHIFT = 16,
            PIXEL_FORMAT_MASK = 0x0000ffff,
            //PIXEL_CONVERT_MASK = 0xffff0000,

            PIXEL_RGB = 1,
            PIXEL_BGR = 2,
            PIXEL_GRAY = 3,
            PIXEL_RGBA = 4,
            PIXEL_BGRA = 5,

            PIXEL_RGB2BGR = PIXEL_RGB | (PIXEL_BGR << PIXEL_CONVERT_SHIFT),
            PIXEL_RGB2GRAY = PIXEL_RGB | (PIXEL_GRAY << PIXEL_CONVERT_SHIFT),
            PIXEL_RGB2RGBA = PIXEL_RGB | (PIXEL_RGBA << PIXEL_CONVERT_SHIFT),
            PIXEL_RGB2BGRA = PIXEL_RGB | (PIXEL_BGRA << PIXEL_CONVERT_SHIFT),

            PIXEL_BGR2RGB = PIXEL_BGR | (PIXEL_RGB << PIXEL_CONVERT_SHIFT),
            PIXEL_BGR2GRAY = PIXEL_BGR | (PIXEL_GRAY << PIXEL_CONVERT_SHIFT),
            PIXEL_BGR2RGBA = PIXEL_BGR | (PIXEL_RGBA << PIXEL_CONVERT_SHIFT),
            PIXEL_BGR2BGRA = PIXEL_BGR | (PIXEL_BGRA << PIXEL_CONVERT_SHIFT),

            PIXEL_GRAY2RGB = PIXEL_GRAY | (PIXEL_RGB << PIXEL_CONVERT_SHIFT),
            PIXEL_GRAY2BGR = PIXEL_GRAY | (PIXEL_BGR << PIXEL_CONVERT_SHIFT),
            PIXEL_GRAY2RGBA = PIXEL_GRAY | (PIXEL_RGBA << PIXEL_CONVERT_SHIFT),
            PIXEL_GRAY2BGRA = PIXEL_GRAY | (PIXEL_BGRA << PIXEL_CONVERT_SHIFT),

            PIXEL_RGBA2RGB = PIXEL_RGBA | (PIXEL_RGB << PIXEL_CONVERT_SHIFT),
            PIXEL_RGBA2BGR = PIXEL_RGBA | (PIXEL_BGR << PIXEL_CONVERT_SHIFT),
            PIXEL_RGBA2GRAY = PIXEL_RGBA | (PIXEL_GRAY << PIXEL_CONVERT_SHIFT),
            PIXEL_RGBA2BGRA = PIXEL_RGBA | (PIXEL_BGRA << PIXEL_CONVERT_SHIFT),

            PIXEL_BGRA2RGB = PIXEL_BGRA | (PIXEL_RGB << PIXEL_CONVERT_SHIFT),
            PIXEL_BGRA2BGR = PIXEL_BGRA | (PIXEL_BGR << PIXEL_CONVERT_SHIFT),
            PIXEL_BGRA2GRAY = PIXEL_BGRA | (PIXEL_GRAY << PIXEL_CONVERT_SHIFT),
            PIXEL_BGRA2RGBA = PIXEL_BGRA | (PIXEL_RGBA << PIXEL_CONVERT_SHIFT),
        };

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
                    {
                        ncnn_Mat_delete(nativeObj);
                    }
                    nativeObj = IntPtr.Zero;
                }                
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        /**
         * Create NCNN Mat 
         * @param[in] addr(IntPtr) address
        */
        public Mat(IntPtr addr)
        {
            if (addr == IntPtr.Zero)
                throw new CvException("Native object address is NULL");
            nativeObj = addr;
        }

        /**
         * Create Empty Mat
        */
        public Mat()
        {
            nativeObj = ncnn_Mat();

            return;
        }

        /**
         * Create Empty Mat
         * @param[in] w(int) width
         * @param[in] h(int) height
        */
        public Mat(int w, int h)
        {
            nativeObj = ncnn_Mat_II(w, h);

            return;
        }
        
        /**
         * Convenient construct from pixel data(OpencvCompact.Mat data) and resize to specific size 
         * @param[in] mat(OpenCVCompact.mat) input pixel data
         * @param[in] type(int) imput pixel data type, NCNN.Mat.PixelType
         * @param[in] target_width(int) target width
         * @param[in] target_height(int) target height
        */
        public void FromPixelsResize(OpenCVCompact.Mat mat, int type, int target_width, int target_height)
        {
            nativeObj = ncnn_Mat_from_pixels_resize(mat.nativeObj, type, target_width, target_height);

            return;
        }

        /**
         * Substract channel-wise mean values, then multiply by normalize values, pass 0 to skip 
         * @param[in] mean_vals(float[]) channel-wise mean values
         * @param[in] norm_vals(float[]) channel-wise norm values
        */
        public void SubstractMeanNormalize(float[] mean_vals, float[] norm_vals)
        {
            ncnn_Mat_substract_mean_normalize(nativeObj, mean_vals, norm_vals);

            return;
        }

        /**
         * Get rows
         * @param[out] get rows of this NCNN.Mat
        */
        public int rows()
        {
            ThrowIfDisposed();
            return ncnn_Mat_height(nativeObj);
        }

        /**
         * Get cols
         * @param[out] get cols of this NCNN.Mat
        */
        public int cols()
        {
            ThrowIfDisposed();
            return ncnn_Mat_width(nativeObj);
        }

        /**
         * Get height
         * @param[out] get height of this NCNN.Mat
        */
        public int h()
        {
            ThrowIfDisposed();
            return ncnn_Mat_height(nativeObj);
        }

        /**
         * Get width
         * @param[out] get width of this NCNN.Mat
        */
        public int w()
        {
            ThrowIfDisposed();
            return ncnn_Mat_width(nativeObj);
        }

        /**
        * Get value of this NCNN.Mat
        * @param[int] row(int) target row
        * @param[int] col(int) target col
        * @param[int] channel(int) target channel
        * @param[out] target data value
        */
        public float GetVal(int row, int col, int channel)
        {
            ThrowIfDisposed();
            return ncnn_Mat_get_val(nativeObj, row, col, channel);
        }

        ////////////////////////////////////////////////////////////////////////
#if UNITY_IOS && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "face_analyzer";
#endif
        [DllImport(LIBNAME)]
        private static extern void ncnn_Mat_delete(IntPtr objPtr);

        [DllImport(LIBNAME)]
        private static extern IntPtr ncnn_Mat();

        [DllImport(LIBNAME)]
        private static extern IntPtr ncnn_Mat_II(int w, int h);

        [DllImport(LIBNAME)]
        private static extern IntPtr ncnn_Mat_from_pixels_resize(IntPtr cv_mat_nativeObj, int type, int target_width, int target_height);

        [DllImport(LIBNAME)]
        private static extern void ncnn_Mat_substract_mean_normalize(IntPtr mat_nativeObj, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] float[] mean_vals, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] float[] norm_vals);

        [DllImport(LIBNAME)]
        private static extern int ncnn_Mat_height(IntPtr mat_nativeObj);

        [DllImport(LIBNAME)]
        private static extern int ncnn_Mat_width(IntPtr mat_nativeObj);
        
        [DllImport(LIBNAME)]
        private static extern float ncnn_Mat_get_val(IntPtr mat_nativeObj, int row, int col, int channel);
    }
}
