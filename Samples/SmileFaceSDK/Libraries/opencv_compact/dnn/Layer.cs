#if !UNITY_WSA_10_0
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVCompact
{

    // C++: class Layer

    public class Layer : Algorithm
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
                        dnn_Layer_delete(nativeObj);
                    nativeObj = IntPtr.Zero;
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected internal Layer (IntPtr addr) : base (addr) { }

        // internal usage only
        public static new Layer __fromPtr__ (IntPtr addr) { return new Layer (addr); }

        //
        // C++:  int cv::dnn::Layer::outputNameToIndex(String outputName)
        //

        /**
         * Returns index of output blob in output array.
         * SEE: inputNameToIndex()
         * param outputName automatically generated
         * return automatically generated
         */
        public int outputNameToIndex(string outputName)
        {
            ThrowIfDisposed();
            return dnn_Layer_outputNameToIndex_10(nativeObj, outputName);
        }

        //
        // C++:  void cv::dnn::Layer::finalize(vector_Mat inputs, vector_Mat& outputs)
        //

        /**
         * Computes and sets internal parameters according to inputs, outputs and blobs.
         * param outputs vector of already allocated output blobs
         *
         * If this method is called after network has allocated all memory for input and output blobs
         * and before inferencing.
         * param inputs automatically generated
         */
        public void finalize(List<Mat> inputs, List<Mat> outputs)
        {
            ThrowIfDisposed();
            Mat inputs_mat = Converters.vector_Mat_to_Mat(inputs);
            Mat outputs_mat = new Mat();
            dnn_Layer_finalize_10(nativeObj, inputs_mat.nativeObj, outputs_mat.nativeObj);
            Converters.Mat_to_vector_Mat(outputs_mat, outputs);
            outputs_mat.release();

        }



        //
        // C++: vector_Mat Layer::blobs
        //

        public List<Mat> get_blobs()
        {
            ThrowIfDisposed();
            List<Mat> retVal = new List<Mat>();
            Mat retValMat = new Mat(dnn_Layer_get_1blobs_10(nativeObj));
            Converters.Mat_to_vector_Mat(retValMat, retVal);
            return retVal;
        }

        //
        // C++: void Layer::blobs
        //

        public void set_blobs(List<Mat> blobs)
        {
            ThrowIfDisposed();
            Mat blobs_mat = Converters.vector_Mat_to_Mat(blobs);
            dnn_Layer_set_1blobs_10(nativeObj, blobs_mat.nativeObj);
        }


        //
        // C++: String Layer::name
        //

        public string get_name()
        {
            ThrowIfDisposed();
            string retVal = Marshal.PtrToStringAnsi(dnn_Layer_get_1name_10(nativeObj));
            return retVal;
        }

        //
        // C++: String Layer::type
        //

        public string get_type()
        {
            ThrowIfDisposed();

            string retVal = Marshal.PtrToStringAnsi(dnn_Layer_get_1type_10(nativeObj));

            return retVal;
        }

        //
        // C++: int Layer::preferableTarget
        //

        public int get_preferableTarget()
        {
            ThrowIfDisposed();

            return dnn_Layer_get_1preferableTarget_10(nativeObj);
        }


#if UNITY_IOS && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "face_analyzer";
#endif

        // C++:  int cv::dnn::Layer::outputNameToIndex(String outputName)
        [DllImport(LIBNAME)]
        private static extern int dnn_Layer_outputNameToIndex_10(IntPtr nativeObj, string outputName);

        // C++:  void cv::dnn::Layer::finalize(vector_Mat inputs, vector_Mat& outputs)
        [DllImport(LIBNAME)]
        private static extern void dnn_Layer_finalize_10(IntPtr nativeObj, IntPtr inputs_mat_nativeObj, IntPtr outputs_mat_nativeObj);

        // C++:  void cv::dnn::Layer::run(vector_Mat inputs, vector_Mat& outputs, vector_Mat& internals)
        [DllImport(LIBNAME)]
        private static extern void dnn_Layer_run_10(IntPtr nativeObj, IntPtr inputs_mat_nativeObj, IntPtr outputs_mat_nativeObj, IntPtr internals_mat_nativeObj);

        // C++: vector_Mat Layer::blobs
        [DllImport(LIBNAME)]
        private static extern IntPtr dnn_Layer_get_1blobs_10(IntPtr nativeObj);

        // C++: void Layer::blobs
        [DllImport(LIBNAME)]
        private static extern void dnn_Layer_set_1blobs_10(IntPtr nativeObj, IntPtr blobs_mat_nativeObj);

        // C++: String Layer::name
        [DllImport(LIBNAME)]
        private static extern IntPtr dnn_Layer_get_1name_10(IntPtr nativeObj);

        // C++: String Layer::type
        [DllImport(LIBNAME)]
        private static extern IntPtr dnn_Layer_get_1type_10(IntPtr nativeObj);

        // C++: int Layer::preferableTarget
        [DllImport(LIBNAME)]
        private static extern int dnn_Layer_get_1preferableTarget_10(IntPtr nativeObj);

        // native support for java finalize()
        [DllImport(LIBNAME)]
        private static extern void dnn_Layer_delete(IntPtr nativeObj);

        [DllImport(LIBNAME)]
        public static extern float Unity_DNN_LAYER_TEST();
    }
}
#endif