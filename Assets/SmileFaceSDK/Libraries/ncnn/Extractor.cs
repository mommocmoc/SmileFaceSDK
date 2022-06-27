using OpenCVCompact;
using System;
using System.Runtime.InteropServices;

namespace NCNN
{
    public class Extractor : OpenCVCompact.DisposableOpenCVCompactObject
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
         * Create Extractor
         * @param[in] addr(IntPtr) address
        */
        public Extractor(IntPtr addr)
        {
            if (addr == IntPtr.Zero)
                throw new CvException("Native object address is NULL");
            nativeObj = addr;
        }

        /**
         * Create Extractor with Empty Init
        */
        public Extractor()
        {
            nativeObj = ncnn_Extractor();

            return;
        }

        /**
         * Set thread count for this extractor this will overwrite the global setting default count is system depended
         * @param[in] num_threads(int) number of threads
        */
        public void SetNumThreads(int num_threads)
        {
            ncnn_Extractor_set_num_threads(nativeObj, num_threads);

            return;
        }

        /**
         * Enable light mode intermediate blob will be recycled when enabled enabled by default
         * @param[in] enable(bool) enable or not
        */
        public void SetLightMode(bool enable)
        {
            ncnn_Extractor_set_light_mode(nativeObj, enable);

            return;
        }

        /**
         * Set input by blob name return 0 if success
         * @param[in] blob_index(int) blob index
         * @param[in] input(NCNN.Mat) input mat
        */
        public int Input(int blob_index, NCNN.Mat input)
        {
            return ncnn_Extractor_input_10(nativeObj, blob_index, input.nativeObj);
        }

        /**
         * Set input by blob name return 0 if success
         * @param[in] blob_name(string) blob name
         * @param[in] input(NCNN.Mat) input mat
        */
        public int Input(string blob_name, NCNN.Mat input)
        {
            return ncnn_Extractor_input_11(nativeObj, blob_name, input.nativeObj);
        }

        /**
         * Get result by blob name return 0 if success
         * @param[in] blob_index(int) blob index
         * @param[out] feature(NCNN.Mat) feature
        */
        public int Extract(int blob_index, out NCNN.Mat feature)
        {
            feature = new NCNN.Mat();
            return ncnn_Extractor_extract_10(nativeObj, blob_index, feature.nativeObj);
        }

        /**
         * Get result by blob name return 0 if success
         * @param[in] blob_name(string) blob name
         * @param[out] feature(NCNN.Mat) feature
        */
        public int Extract(string blob_name, out NCNN.Mat feature)
        {
            feature = new NCNN.Mat();
            return ncnn_Extractor_extract_11(nativeObj, blob_name, feature.nativeObj);
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
        private static extern IntPtr ncnn_Extractor();

        [DllImport(LIBNAME)]
        private static extern void ncnn_Extractor_set_num_threads(IntPtr nativeObj, int num_threads);

        [DllImport(LIBNAME)]
        private static extern void ncnn_Extractor_set_light_mode(IntPtr nativeObj, bool enable);

        [DllImport(LIBNAME)]
        private static extern int ncnn_Extractor_input_10(IntPtr nativeObj, int blob_index, IntPtr in_nativeObj);

        [DllImport(LIBNAME)]
        private static extern int ncnn_Extractor_input_11(IntPtr nativeObj, string blob_name, IntPtr in_nativeObj);

        [DllImport(LIBNAME)]
        private static extern int ncnn_Extractor_extract_10(IntPtr nativeObj, int blob_index, IntPtr feat_nativeObj);

        [DllImport(LIBNAME)]
        private static extern int ncnn_Extractor_extract_11(IntPtr nativeObj, string blob_name, IntPtr feat_nativeObj);
    }
}
