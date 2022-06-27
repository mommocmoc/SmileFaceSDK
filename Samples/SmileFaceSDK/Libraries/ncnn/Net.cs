using OpenCVCompact;
using System;
using System.Runtime.InteropServices;

namespace NCNN
{
    public class Net : OpenCVCompact.DisposableOpenCVCompactObject
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
                        ncnn_Net_delete(nativeObj);
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
         * Create NCNN Net 
         * @param[in] addr(IntPtr) address
        */
        public Net(IntPtr addr)
        {
            if (addr == IntPtr.Zero)
                throw new CvException("Native object address is NULL");
            nativeObj = addr;
        }
        
        /**
         * Create NCNN with empty init
        */
        public Net()
        {
            nativeObj = ncnn_Net();

            return;
        }

        /**
         * Load network structure from plain param file return 0 if success
         * @param[in] param_path(string) parameter file path
        */
        public int LoadParam(string param_path)
        {
            return ncnn_load_param(nativeObj, param_path);
        }

        /**
         * Load network structure from binary param file return 0 if success
         * @param[in] param_path(string) parameter file path
        */
        public int LoadParamBin(string param_path)
        {
            return ncnn_load_param_bin(nativeObj, param_path);
        }

        /**
         * Load network structure from param data return 0 if success
         * @param[in] param_path(string) parameter file path
        */
        public int LoadParamMem(string param_path)
        {
            return ncnn_load_param_mem(nativeObj, param_path);
        }

        /**
         * Load network weight data from model file return 0 if success
         * @param[in] model_path(string) model file path
        */
        public int LoadModel(string model_path)
        {
            return ncnn_load_model(nativeObj, model_path);
        }

        /**
         * Construct an Extractor from network 
        */
        public NCNN.Extractor CreateExtractor()
        {
            NCNN.Extractor extractor = new NCNN.Extractor();
            extractor.nativeObj = ncnn_create_extractor(nativeObj);

            return extractor;
        }

        ////////////////////////////////////////////////////////////////////////
#if UNITY_IOS && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "face_analyzer";
#endif
        [DllImport(LIBNAME)]
        private static extern void ncnn_Net_delete(IntPtr objPtr);

        [DllImport(LIBNAME)]
        private static extern IntPtr ncnn_Net();

        [DllImport(LIBNAME)]
        private static extern int ncnn_load_param(IntPtr nativeObj, string param_path);

        [DllImport(LIBNAME)]
        private static extern int ncnn_load_param_bin(IntPtr nativeObj, string param_path);

        [DllImport(LIBNAME)]
        private static extern int ncnn_load_param_mem(IntPtr nativeObj, string param_path);

        [DllImport(LIBNAME)]
        private static extern int ncnn_load_model(IntPtr nativeObj, string model_path);

        [DllImport(LIBNAME)]
        private static extern IntPtr ncnn_create_extractor(IntPtr nativeObj);
    }
}
