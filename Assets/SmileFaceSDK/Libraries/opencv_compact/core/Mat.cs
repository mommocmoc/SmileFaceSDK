using System;
using System.Runtime.InteropServices;

namespace OpenCVCompact
{
    public class Mat : OpenCVCompact.DisposableOpenCVCompactObject
    {
        public float UnityDNNTEST()
        {
            return Unity_DNN_TEST();
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
                    {
                        core_Mat_delete(nativeObj);
                    }
                    nativeObj = IntPtr.Zero;
                }                
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        public Mat(IntPtr addr)
        {
            if (addr == IntPtr.Zero)
                throw new CvException("Native object address is NULL");
            nativeObj = addr;
        }
        
        public Mat()
        {
            nativeObj = core_Mat();

            return;
        }

        public Mat(int rows, int cols, int type)
        {
            nativeObj = core_Mat_III(rows, cols, type);

            return;
        }

        public Mat(int rows, int cols, int type, float val)
        {
            nativeObj = core_Mat_IIIF(rows, cols, type, val);

            return;
        }


        public Mat(int rows, int cols, int type, Scalar s)
        {
            nativeObj = core_Mat_IIIDDDD(rows, cols, type, s.val[0], s.val[1], s.val[2], s.val[3]);

            return;
        }

        public Mat(Size size, int type, Scalar s)
        {
            nativeObj = core_Mat_IIIDDDD((int)size.height, (int)size.width, type, s.val[0], s.val[1], s.val[2], s.val[3]);

            return;
        }

        //
        // C++: Mat::Mat(Mat m, Range rowRange, Range colRange = Range::all())
        //

        /**
 * <p>Various Mat constructors</p>
 *
 * <p>These are various constructors that form a matrix. As noted in the
 * "AutomaticAllocation", often the default constructor is enough, and the
 * proper matrix will be allocated by an OpenCV function. The constructed matrix
 * can further be assigned to another matrix or matrix expression or can be
 * allocated with "Mat.create". In the former case, the old content is
 * de-referenced.</p>
 *
 * @param m Array that (as a whole or partly) is assigned to the constructed
 * matrix. No data is copied by these constructors. Instead, the header pointing
 * to <code>m</code> data or its sub-array is constructed and associated with
 * it. The reference counter, if any, is incremented. So, when you modify the
 * matrix formed using such a constructor, you also modify the corresponding
 * elements of <code>m</code>. If you want to have an independent copy of the
 * sub-array, use <code>Mat.clone()</code>.
 * @param rowRange Range of the <code>m</code> rows to take. As usual, the range
 * start is inclusive and the range end is exclusive. Use <code>Range.all()</code>
 * to take all the rows.
 * @param colRange Range of the <code>m</code> columns to take. Use
 * <code>Range.all()</code> to take all the columns.
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-mat">org.opencv.core.Mat.Mat</a>
 */
        public Mat(Mat m, Range rowRange, Range colRange)
        {
            if (m != null)
                m.ThrowIfDisposed();

            nativeObj = core_Mat_Range_JIIII(m.nativeObj, rowRange.start, rowRange.end, colRange.start, colRange.end);

            return;
        }
        //
        /**
 * <p>Various Mat constructors</p>
 *
 * <p>These are various constructors that form a matrix. As noted in the
 * "AutomaticAllocation", often the default constructor is enough, and the
 * proper matrix will be allocated by an OpenCV function. The constructed matrix
 * can further be assigned to another matrix or matrix expression or can be
 * allocated with "Mat.create". In the former case, the old content is
 * de-referenced.</p>
 *
 * @param m Array that (as a whole or partly) is assigned to the constructed
 * matrix. No data is copied by these constructors. Instead, the header pointing
 * to <code>m</code> data or its sub-array is constructed and associated with
 * it. The reference counter, if any, is incremented. So, when you modify the
 * matrix formed using such a constructor, you also modify the corresponding
 * elements of <code>m</code>. If you want to have an independent copy of the
 * sub-array, use <code>Mat.clone()</code>.
 * @param rowRange Range of the <code>m</code> rows to take. As usual, the range
 * start is inclusive and the range end is exclusive. Use <code>Range.all()</code>
 * to take all the rows.
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-mat">org.opencv.core.Mat.Mat</a>
 */
        public Mat(Mat m, Range rowRange)
        {
            if (m != null)
                m.ThrowIfDisposed();

            nativeObj = core_Mat_Range_JII(m.nativeObj, rowRange.start, rowRange.end);

            return;
        }

        //
        // C++: Mat::Mat(Mat m, Rect roi)
        //

        /**
 * <p>Various Mat constructors</p>
 *
 * <p>These are various constructors that form a matrix. As noted in the
 * "AutomaticAllocation", often the default constructor is enough, and the
 * proper matrix will be allocated by an OpenCV function. The constructed matrix
 * can further be assigned to another matrix or matrix expression or can be
 * allocated with "Mat.create". In the former case, the old content is
 * de-referenced.</p>
 *
 * @param m Array that (as a whole or partly) is assigned to the constructed
 * matrix. No data is copied by these constructors. Instead, the header pointing
 * to <code>m</code> data or its sub-array is constructed and associated with
 * it. The reference counter, if any, is incremented. So, when you modify the
 * matrix formed using such a constructor, you also modify the corresponding
 * elements of <code>m</code>. If you want to have an independent copy of the
 * sub-array, use <code>Mat.clone()</code>.
 * @param roi Region of interest.
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-mat">org.opencv.core.Mat.Mat</a>
 */
        public Mat(Mat m, Rect roi)
        {
            if (m != null)
                m.ThrowIfDisposed();

            nativeObj = core_Mat_Range_JIIII(m.nativeObj, roi.y, roi.y + roi.height, roi.x, roi.x + roi.width);

            return;
        }
        

        public int put(int row, int col, params double[] data)
        {
            ThrowIfDisposed();

            int t = type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new CvException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            return core_Mat_PutD(nativeObj, row, col, data.Length, data);
        }

        public int put(int row, int col, float[] data)
        {
            ThrowIfDisposed();

            int t = type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new CvException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_32F)
            {
                return core_Mat_PutF(nativeObj, row, col, data.Length, data);
            }
            throw new CvException("Mat data type is not compatible: " + t);
        }

        public int put(int row, int col, int[] data)
        {
            ThrowIfDisposed();
            int t = type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new CvException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_32S)
            {
                return core_Mat_PutI(nativeObj, row, col, data.Length, data);
            }
            throw new CvException("Mat data type is not compatible: " + t);
        }

        public int put(int row, int col, short[] data)
        {
            ThrowIfDisposed();

            int t = type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new CvException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_16U || CvType.depth(t) == CvType.CV_16S)
            {
                return core_Mat_PutS(nativeObj, row, col, data.Length, data);
            }
            throw new CvException("Mat data type is not compatible: " + t);
        }

        public int put(int row, int col, byte[] data)
        {
            ThrowIfDisposed();

            int t = type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new CvException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_8U || CvType.depth(t) == CvType.CV_8S)
            {
                return core_Mat_PutB(nativeObj, row, col, data.Length, data);
            }
            throw new CvException("Mat data type is not compatible: " + t);
        }

        public int get(int row, int col, byte[] data)
        {
            ThrowIfDisposed();

            int t = type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new CvException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_8U || CvType.depth(t) == CvType.CV_8S)
            {
                return core_Mat_GetB(nativeObj, row, col, data.Length, data);
            }
            throw new CvException("Mat data type is not compatible: " + t);
        }

        public int get(int row, int col, short[] data)
        {
            ThrowIfDisposed();

            int t = type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new CvException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_16U || CvType.depth(t) == CvType.CV_16S)
            {
                return core_Mat_GetS(nativeObj, row, col, data.Length, data);
            }
            throw new CvException("Mat data type is not compatible: " + t);
        }

        public int get(int row, int col, int[] data)
        {
            ThrowIfDisposed();

            int t = type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new CvException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_32S)
            {
                return core_Mat_GetI(nativeObj, row, col, data.Length, data);
            }
            throw new CvException("Mat data type is not compatible: " + t);
        }

        public int get(int row, int col, float[] data)
        {
            ThrowIfDisposed();

            int t = type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new CvException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_32F)
            {
                return core_Mat_GetF(nativeObj, row, col, data.Length, data);
            }
            throw new CvException("Mat data type is not compatible: " + t);
        }

        public int get(int row, int col, double[] data)
        {
            ThrowIfDisposed();

            int t = type();
            if (data == null || data.Length % CvType.channels(t) != 0)
                throw new CvException(
                    "Provided data element number (" +
                    (data == null ? 0 : data.Length) +
                    ") should be multiple of the Mat channels count (" +
                    CvType.channels(t) + ")");
            if (CvType.depth(t) == CvType.CV_64F)
            {
                return core_Mat_GetD(nativeObj, row, col, data.Length, data);
            }
            throw new CvException("Mat data type is not compatible: " + t);
        }

        public double[] get(int row, int col)
        {
            ThrowIfDisposed();

            double[] tmpArray = new double[channels()];
            int result = core_Mat_Get(nativeObj, row, col, tmpArray.Length, tmpArray);

            if (result == 0)
            {
                return null;
            }
            else
            {
                return tmpArray;
            }
        }

        public void release()
        {
            ThrowIfDisposed();

            core_Mat_release(nativeObj);

            return;
        }

        public int rows()
        {
            ThrowIfDisposed();
            return core_Mat_rows(nativeObj);
        }

        public int cols()
        {
            ThrowIfDisposed();     
            return core_Mat_cols(nativeObj);
        }

        public int height()
        {
            ThrowIfDisposed();   
            return core_Mat_rows(nativeObj);
        }

        public int width()
        {
            ThrowIfDisposed();  
            return core_Mat_cols(nativeObj);
        }


        //
        // C++: Size Mat::size()
        //

        /**
 * <p>Returns a matrix size.</p>
 *
 * <p>The method returns a matrix size: <code>Size(cols, rows)</code>. When the
 * matrix is more than 2-dimensional, the returned size is (-1, -1).</p>
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-size">org.opencv.core.Mat.size</a>
 */
        public Size size()
        {
            ThrowIfDisposed();

            double[] tmpArray = new double[2];
            core_Mat_size(nativeObj, tmpArray);

            Size retVal = new Size(tmpArray);

            return retVal;
        }


        //
        // C++: void Mat::convertTo(Mat& m, int rtype, double alpha = 1, double beta
        // = 0)
        //

        /**
 * <p>Converts an array to another data type with optional scaling.</p>
 *
 * <p>The method converts source pixel values to the target data type.
 * <code>saturate_cast<></code> is applied at the end to avoid possible
 * overflows:</p>
 *
 * <p><em>m(x,y) = saturate _ cast&ltrType&gt(alpha(*this)(x,y) + beta)</em></p>
 *
 * @param m output matrix; if it does not have a proper size or type before the
 * operation, it is reallocated.
 * @param rtype desired output matrix type or, rather, the depth since the
 * number of channels are the same as the input has; if <code>rtype</code> is
 * negative, the output matrix will have the same type as the input.
 * @param alpha optional scale factor.
 * @param beta optional delta added to the scaled values.
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-convertto">org.opencv.core.Mat.convertTo</a>
 */
        public void convertTo(Mat m, int rtype, double alpha, double beta)
        {
            if (m != null)
                m.ThrowIfDisposed();
            ThrowIfDisposed();

            core_Mat_convertTo_JJIDD(nativeObj, m.nativeObj, rtype, alpha, beta);

            return;
        }

        /**
 * <p>Converts an array to another data type with optional scaling.</p>
 *
 * <p>The method converts source pixel values to the target data type.
 * <code>saturate_cast<></code> is applied at the end to avoid possible
 * overflows:</p>
 *
 * <p><em>m(x,y) = saturate _ cast&ltrType&gt(alpha(*this)(x,y) + beta)</em></p>
 *
 * @param m output matrix; if it does not have a proper size or type before the
 * operation, it is reallocated.
 * @param rtype desired output matrix type or, rather, the depth since the
 * number of channels are the same as the input has; if <code>rtype</code> is
 * negative, the output matrix will have the same type as the input.
 * @param alpha optional scale factor.
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-convertto">org.opencv.core.Mat.convertTo</a>
 */
        public void convertTo(Mat m, int rtype, double alpha)
        {
            if (m != null)
                m.ThrowIfDisposed();
            ThrowIfDisposed();
            core_Mat_convertTo_JJID(nativeObj, m.nativeObj, rtype, alpha);

            return;
        }

        /**
 * <p>Converts an array to another data type with optional scaling.</p>
 *
 * <p>The method converts source pixel values to the target data type.
 * <code>saturate_cast<></code> is applied at the end to avoid possible
 * overflows:</p>
 *
 * <p><em>m(x,y) = saturate _ cast&ltrType&gt(alpha(*this)(x,y) + beta)</em></p>
 *
 * @param m output matrix; if it does not have a proper size or type before the
 * operation, it is reallocated.
 * @param rtype desired output matrix type or, rather, the depth since the
 * number of channels are the same as the input has; if <code>rtype</code> is
 * negative, the output matrix will have the same type as the input.
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-convertto">org.opencv.core.Mat.convertTo</a>
 */
        public void convertTo(Mat m, int rtype)
        {
            if (m != null)
                m.ThrowIfDisposed();
            ThrowIfDisposed();

            core_Mat_convertTo_JJI(nativeObj, m.nativeObj, rtype);

            return;
        }

        //
        // C++: Mat Mat::clone()
        //

        /**
 * <p>Creates a full copy of the array and the underlying data.</p>
 *
 * <p>The method creates a full copy of the array. The original <code>step[]</code>
 * is not taken into account. So, the array copy is a continuous array occupying
 * <code>total()*elemSize()</code> bytes.</p>
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-clone">org.opencv.core.Mat.clone</a>
 */
        public OpenCVCompact.Mat clone()
        {
            ThrowIfDisposed();
           
            return new Mat(core_Mat_clone(nativeObj));
        }

        //
        // C++: void Mat::copyTo(Mat& m)
        //

        /**
 * <p>Copies the matrix to another one.</p>
 *
 * <p>The method copies the matrix data to another matrix. Before copying the data,
 * the method invokes <code></p>
 *
 * <p>// C++ code:</p>
 *
 * <p>m.create(this->size(), this->type());</p>
 *
 * <p>so that the destination matrix is reallocated if needed. While
 * <code>m.copyTo(m);</code> works flawlessly, the function does not handle the
 * case of a partial overlap between the source and the destination matrices.
 * </code></p>
 *
 * <p>When the operation mask is specified, if the <code>Mat.create</code> call
 * shown above reallocates the matrix, the newly allocated matrix is initialized
 * with all zeros before copying the data.</p>
 *
 * @param m Destination matrix. If it does not have a proper size or type before
 * the operation, it is reallocated.
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-copyto">org.opencv.core.Mat.copyTo</a>
 */
        public void copyTo(Mat m)
        {
            if (m != null)
                m.ThrowIfDisposed();
            ThrowIfDisposed();

            core_Mat_copyTo_JJ(nativeObj, m.nativeObj);

            return;
        }

        //
        // C++: void Mat::copyTo(Mat& m, Mat mask)
        //

        /**
 * <p>Copies the matrix to another one.</p>
 *
 * <p>The method copies the matrix data to another matrix. Before copying the data,
 * the method invokes <code></p>
 *
 * <p>// C++ code:</p>
 *
 * <p>m.create(this->size(), this->type);</p>
 *
 * <p>so that the destination matrix is reallocated if needed. While
 * <code>m.copyTo(m);</code> works flawlessly, the function does not handle the
 * case of a partial overlap between the source and the destination matrices.
 * </code></p>
 *
 * <p>When the operation mask is specified, and the <code>Mat.create</code> call
 * shown above reallocated the matrix, the newly allocated matrix is initialized
 * with all zeros before copying the data.</p>
 *
 * @param m Destination matrix. If it does not have a proper size or type before
 * the operation, it is reallocated.
 * @param mask Operation mask. Its non-zero elements indicate which matrix
 * elements need to be copied.
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-copyto">org.opencv.core.Mat.copyTo</a>
 */
        public void copyTo(Mat m, Mat mask)
        {
            if (m != null)
                m.ThrowIfDisposed();
            if (mask != null)
                mask.ThrowIfDisposed();
            ThrowIfDisposed();

            core_Mat_copyTo_JJJ(nativeObj, m.nativeObj, mask.nativeObj);

            return;
        }


        public void copyToSubMat(Mat m, int roi_x, int roi_y, int roi_width, int roi_height)
        {
            if (m != null)
                m.ThrowIfDisposed();
            ThrowIfDisposed();

            core_Mat_copyTo_SubMat_JJ_IIII(nativeObj, m.nativeObj, roi_x, roi_y, roi_width, roi_height);

            return;
        }


        public int channels()
        {
            ThrowIfDisposed();
            return core_Mat_channels(nativeObj);
        }



        /**
 * <p>Extracts a rectangular submatrix.</p>
 *
 * <p>The operators make a new header for the specified sub-array of
 * <code>*this</code>. They are the most generalized forms of "Mat.row",
 * "Mat.col", "Mat.rowRange", and "Mat.colRange". For example,
 * <code>A(Range(0, 10), Range.all())</code> is equivalent to <code>A.rowRange(0,
 * 10)</code>. Similarly to all of the above, the operators are O(1) operations,
 * that is, no matrix data is copied.</p>
 *
 * @param rowStart a rowStart
 * @param rowEnd a rowEnd
 * @param colStart a colStart
 * @param colEnd a colEnd
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-operator">org.opencv.core.Mat.operator()</a>
 */
        public Mat submat(int rowStart, int rowEnd, int colStart, int colEnd)
        {
            ThrowIfDisposed();

            OpenCVCompact.Mat resMat = new OpenCVCompact.Mat();
            core_Mat_submat_IIII(nativeObj, resMat.nativeObj, rowStart, rowEnd, colStart, colEnd);
            return resMat;
        }

        //
        // C++: Mat Mat::operator()(Range rowRange, Range colRange)
        //

        /**
 * <p>Extracts a rectangular submatrix.</p>
 *
 * <p>The operators make a new header for the specified sub-array of
 * <code>*this</code>. They are the most generalized forms of "Mat.row",
 * "Mat.col", "Mat.rowRange", and "Mat.colRange". For example,
 * <code>A(Range(0, 10), Range.all())</code> is equivalent to <code>A.rowRange(0,
 * 10)</code>. Similarly to all of the above, the operators are O(1) operations,
 * that is, no matrix data is copied.</p>
 *
 * @param rowRange Start and end row of the extracted submatrix. The upper
 * boundary is not included. To select all the rows, use <code>Range.all()</code>.
 * @param colRange Start and end column of the extracted submatrix. The upper
 * boundary is not included. To select all the columns, use <code>Range.all()</code>.
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-operator">org.opencv.core.Mat.operator()</a>
 */
        public Mat submat(Range rowRange, Range colRange)
        {
            ThrowIfDisposed();

            OpenCVCompact.Mat resMat = new OpenCVCompact.Mat();
            core_Mat_submat_IIII(nativeObj, resMat.nativeObj, rowRange.start, rowRange.end, colRange.start, colRange.end);
            return resMat;
        }

        //
        // C++: Mat Mat::operator()(Rect roi)
        //

        /**
 * <p>Extracts a rectangular submatrix.</p>
 *
 * <p>The operators make a new header for the specified sub-array of
 * <code>*this</code>. They are the most generalized forms of "Mat.row",
 * "Mat.col", "Mat.rowRange", and "Mat.colRange". For example,
 * <code>A(Range(0, 10), Range.all())</code> is equivalent to <code>A.rowRange(0,
 * 10)</code>. Similarly to all of the above, the operators are O(1) operations,
 * that is, no matrix data is copied.</p>
 *
 * @param roi Extracted submatrix specified as a rectangle.
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-operator">org.opencv.core.Mat.operator()</a>
 */
        public Mat submat(Rect roi)
        {
            ThrowIfDisposed();

            OpenCVCompact.Mat resMat = new OpenCVCompact.Mat();
            core_Mat_submat(nativeObj, resMat.nativeObj, roi.x, roi.y, roi.width, roi.height);
            return resMat;
        }


        //
        // C++: Mat Mat::t()
        //

        /**
 * <p>Transposes a matrix.</p>
 *
 * <p>The method performs matrix transposition by means of matrix expressions. It
 * does not perform the actual transposition but returns a temporary matrix
 * transposition object that can be further used as a part of more complex
 * matrix expressions or can be assigned to a matrix: <code></p>
 *
 * <p>// C++ code:</p>
 *
 * <p>Mat A1 = A + Mat.eye(A.size(), A.type)*lambda;</p>
 *
 * <p>Mat C = A1.t()*A1; // compute (A + lambda*I)^t * (A + lamda*I)</p>
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-t">org.opencv.core.Mat.t</a>
 */
        public Mat t()
        {
            ThrowIfDisposed();
            Mat retVal = new Mat(core_Mat_t(nativeObj));

            return retVal;
        }


        //
        // C++: size_t Mat::total()
        //

        /**
 * <p>Returns the total number of array elements.</p>
 *
 * <p>The method returns the number of array elements (a number of pixels if the
 * array represents an image).</p>
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-total">org.opencv.core.Mat.total</a>
 */
        public long total()
        {
            ThrowIfDisposed();
            long retVal = core_Mat_total(nativeObj);

            return retVal;
        }

        public int type()
        {
            ThrowIfDisposed();
            return core_Mat_type(nativeObj);
        }


        public bool isContinuous()
        {
            ThrowIfDisposed();
            return core_Mat_isContinuous(nativeObj);
        }



        //
        // C++: void Mat::create(int rows, int cols, int type)
        //

        /**
 * <p>Allocates new array data if needed.</p>
 *
 * <p>This is one of the key <code>Mat</code> methods. Most new-style OpenCV
 * functions and methods that produce arrays call this method for each output
 * array. The method uses the following algorithm:</p>
 * <ul>
 *   <li> If the current array shape and the type match the new ones, return
 * immediately. Otherwise, de-reference the previous data by calling
 * "Mat.release".
 *   <li> Initialize the new header.
 *   <li> Allocate the new data of <code>total()*elemSize()</code> bytes.
 *   <li> Allocate the new, associated with the data, reference counter and set
 * it to 1.
 * </ul>
 * <p>Such a scheme makes the memory management robust and efficient at the same
 * time and helps avoid extra typing for you. This means that usually there is
 * no need to explicitly allocate output arrays. That is, instead of writing:
 * <code></p>
 *
 * <p>// C++ code:</p>
 *
 * <p>Mat color;...</p>
 *
 * <p>Mat gray(color.rows, color.cols, color.depth());</p>
 *
 * <p>cvtColor(color, gray, CV_BGR2GRAY);</p>
 *
 * <p>you can simply write:</p>
 *
 * <p>Mat color;...</p>
 *
 * <p>Mat gray;</p>
 *
 * <p>cvtColor(color, gray, CV_BGR2GRAY);</p>
 *
 * <p>because <code>cvtColor</code>, as well as the most of OpenCV functions, calls
 * <code>Mat.create()</code> for the output array internally.
 * </code></p>
 *
 * @param rows New number of rows.
 * @param cols New number of columns.
 * @param type New matrix type.
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-create">org.opencv.core.Mat.create</a>
 */
        public void create(int rows, int cols, int type)
        {
            ThrowIfDisposed();
            core_Mat_create_JIII(nativeObj, rows, cols, type);
            return;
        }

        //
        // C++: void Mat::create(Size size, int type)
        //

        /**
 * <p>Allocates new array data if needed.</p>
 *
 * <p>This is one of the key <code>Mat</code> methods. Most new-style OpenCV
 * functions and methods that produce arrays call this method for each output
 * array. The method uses the following algorithm:</p>
 * <ul>
 *   <li> If the current array shape and the type match the new ones, return
 * immediately. Otherwise, de-reference the previous data by calling
 * "Mat.release".
 *   <li> Initialize the new header.
 *   <li> Allocate the new data of <code>total()*elemSize()</code> bytes.
 *   <li> Allocate the new, associated with the data, reference counter and set
 * it to 1.
 * </ul>
 * <p>Such a scheme makes the memory management robust and efficient at the same
 * time and helps avoid extra typing for you. This means that usually there is
 * no need to explicitly allocate output arrays. That is, instead of writing:
 * <code></p>
 *
 * <p>// C++ code:</p>
 *
 * <p>Mat color;...</p>
 *
 * <p>Mat gray(color.rows, color.cols, color.depth());</p>
 *
 * <p>cvtColor(color, gray, CV_BGR2GRAY);</p>
 *
 * <p>you can simply write:</p>
 *
 * <p>Mat color;...</p>
 *
 * <p>Mat gray;</p>
 *
 * <p>cvtColor(color, gray, CV_BGR2GRAY);</p>
 *
 * <p>because <code>cvtColor</code>, as well as the most of OpenCV functions, calls
 * <code>Mat.create()</code> for the output array internally.
 * </code></p>
 *
 * @param size Alternative new matrix size specification: <code>Size(cols,
 * rows)</code>
 * @param type New matrix type.
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-create">org.opencv.core.Mat.create</a>
 */
        public void create(Size size, int type)
        {
            ThrowIfDisposed();

            core_Mat_create_JIII(nativeObj, (int)size.width, (int)size.height, type);

        }


        public IntPtr dataAddr()
        {
            ThrowIfDisposed();
            return core_Mat_dataAddr(nativeObj);
        }

        public bool empty()
        {
            ThrowIfDisposed();
            return core_Mat_empty(nativeObj);
        }

        //
        // C++: size_t Mat::elemSize()
        //

        /**
 * <p>Returns the matrix element size in bytes.</p>
 *
 * <p>The method returns the matrix element size in bytes. For example, if the
 * matrix type is <code>CV_16SC3</code>, the method returns <code>3*sizeof(short)</code>
 * or 6.</p>
 *
 * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#mat-elemsize">org.opencv.core.Mat.elemSize</a>
 */
        public long elemSize()
        {
            ThrowIfDisposed();

            return core_Mat_elemSize(nativeObj); //TODO: @size_t long long
        }

        //
        // C++: int Mat::checkVector(int elemChannels, int depth = -1, bool
        // requireContinuous = true)
        //

        public int checkVector(int elemChannels, int depth, bool requireContinuous)
        {
            ThrowIfDisposed();

            int retVal = core_Mat_checkVector_JIIZ(nativeObj, elemChannels, depth, requireContinuous);

            return retVal;
        }

        public int checkVector(int elemChannels, int depth)
        {
            ThrowIfDisposed();

            int retVal = core_Mat_checkVector_JII(nativeObj, elemChannels, depth);

            return retVal;
        }

        public int checkVector(int elemChannels)
        {
            ThrowIfDisposed();

            int retVal = core_Mat_checkVector_JI(nativeObj, elemChannels);

            return retVal;
        }

        public Mat reshape(int cn, int rows)
        {
            ThrowIfDisposed();

            return new Mat(core_Mat_n_1reshape__JII(nativeObj, cn, rows));

        }

        public Mat reshape(int cn)
        {
            ThrowIfDisposed();

            return new Mat(core_Mat_n_1reshape__JI(nativeObj, cn));

        }

        ////////////////////////////////////////////////////////////////////////
#if UNITY_IOS && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "face_analyzer";
#endif
        [DllImport(LIBNAME)]
        public static extern float Unity_DNN_TEST();

        [DllImport(LIBNAME)]
        private static extern void core_Mat_delete(IntPtr objPtr);

        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat();

        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat_III(int rows, int cols, int type);

        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat_IIIF(int rows, int cols, int type, float val);

        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat_IIIDDDD(int rows, int cols, int type, double val_0, double val_1, double val_2, double val_3);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_PutD(IntPtr self, int row, int col, int count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] double[] data);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_PutF(IntPtr self, int row, int col, int count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] float[] data);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_PutI(IntPtr self, int row, int col, int count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] int[] data);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_PutS(IntPtr self, int row, int col, int count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] short[] data);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_PutB(IntPtr self, int row, int col, int count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] data);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_GetB(IntPtr self, int row, int col, int count, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] vals);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_GetS(IntPtr self, int row, int col, int count, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] short[] vals);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_GetI(IntPtr self, int row, int col, int count, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] int[] vals);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_GetF(IntPtr self, int row, int col, int count, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] float[] vals);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_GetD(IntPtr self, int row, int col, int count, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] double[] vals);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_Get(IntPtr self, int row, int col, int count, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] double[] vals);

        // C++: void Mat::release()
        [DllImport(LIBNAME)]
        private static extern void core_Mat_release(IntPtr nativeObj);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_rows(IntPtr objPtr);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_cols(IntPtr objPtr);

        // C++: Size Mat::size()
        [DllImport(LIBNAME)]
        private static extern void core_Mat_size(IntPtr nativeObj,
                                                     [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] vals);

        // C++: void Mat::convertTo(Mat& m, int rtype, double alpha = 1, double beta
        // = 0)
        [DllImport(LIBNAME)]
        private static extern void core_Mat_convertTo_JJIDD(IntPtr nativeObj, IntPtr m_nativeObj, int rtype, double alpha, double beta);

        [DllImport(LIBNAME)]
        private static extern void core_Mat_convertTo_JJID(IntPtr nativeObj, IntPtr m_nativeObj, int rtype, double alpha);

        [DllImport(LIBNAME)]
        private static extern void core_Mat_convertTo_JJI(IntPtr nativeObj, IntPtr m_nativeObj, int rtype);

        // C++: Mat Mat::clone()
        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat_clone(IntPtr nativeObj);

        // C++: void Mat::copyTo(Mat& m)
        [DllImport(LIBNAME)]
        private static extern void core_Mat_copyTo_JJ(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: void Mat::copyTo(Mat& m, Mat mask)
        [DllImport(LIBNAME)]
        private static extern void core_Mat_copyTo_JJJ(IntPtr nativeObj, IntPtr m_nativeObj, IntPtr mask_nativeObj);

        // C++: void Mat::copyTo(Mat& m, Mat mask)
        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat_copyTo_SubMat_JJ_IIII(IntPtr nativeObj, IntPtr m_nativeObj, int roi_x, int roi_y, int roi_width, int roi_height);        
        
        [DllImport(LIBNAME)]
        private static extern int core_Mat_channels(IntPtr objPtr);

        // C++: Mat Mat::operator()(Range rowRange, Range colRange)
        [DllImport(LIBNAME)]
        private static extern void core_Mat_submat_IIII(IntPtr nativeObj, IntPtr m_nativeObj, int rowRange_start, int rowRange_end, int colRange_start, int colRange_end);

        // C++: Mat Mat::operator()(Rect roi)
        [DllImport(LIBNAME)]
        private static extern void core_Mat_submat(IntPtr nativeObj, IntPtr m_nativeObj, int roi_x, int roi_y, int roi_width, int roi_height);
                
        // C++: Mat Mat::t()
        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat_t(IntPtr nativeObj);

        // C++: size_t Mat::total()
        [DllImport(LIBNAME)]
        private static extern long core_Mat_total(IntPtr nativeObj);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_type(IntPtr objPtr);

        [DllImport(LIBNAME)]
        private static extern bool core_Mat_isContinuous(IntPtr objPtr);

        // C++: void Mat::create(int rows, int cols, int type)
        [DllImport(LIBNAME)]
        private static extern void core_Mat_create_JIII(IntPtr nativeObj, int rows, int cols, int type);

        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat_dataAddr(IntPtr objPtr);

        [DllImport(LIBNAME)]
        private static extern bool core_Mat_empty(IntPtr objPtr);

        [DllImport(LIBNAME)]
        private static extern long core_Mat_elemSize(IntPtr objPtr);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_checkVector_JIIZ(IntPtr objPtr, int elemChannels, int depth, bool requireContinuous);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_checkVector_JII(IntPtr objPtr, int elemChannels, int depth);

        [DllImport(LIBNAME)]
        private static extern int core_Mat_checkVector_JI(IntPtr objPtr, int elemChannels);

        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat_Range_JIIII(IntPtr objPtr, int rowRange_start, int rowRange_end, int colRange_start, int colRange_end);

        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat_Range_JII(IntPtr objPtr, int rowRange_start, int rowRange_end);

        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat_n_1zeros__III(int rows, int cols, int type);

        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat_n_1zeros__DDI(double size_width, double size_height, int type);

        // C++: Mat Mat::reshape(int cn, int rows = 0)
        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat_n_1reshape__JII(IntPtr nativeObj, int cn, int rows);

        [DllImport(LIBNAME)]
        private static extern IntPtr core_Mat_n_1reshape__JI(IntPtr nativeObj, int cn);

        //

        #region Operators

        #region Unary

        #region +

        public static Mat operator +(Mat mat)
        {
            return mat;
        }

        #endregion

        #region -

        public static Mat operator -(Mat mat)
        {
            Mat m = new Mat();
            Core.multiply(mat, new Scalar(-1, -1, -1, -1), m);
            return m;
        }

        #endregion

        #endregion

        #region Binary

        #region +

        public static Mat operator +(Mat a, Mat b)
        {
            Mat m = new Mat();
            Core.add(a, b, m);
            return m;
        }

        public static Mat operator +(Mat a, Scalar s)
        {
            Mat m = new Mat();
            Core.add(a, s, m);
            return m;
        }

        public static Mat operator +(Scalar s, Mat a)
        {
            Mat m = new Mat();
            Core.add(a, s, m);
            return m;
        }

        #endregion

        #region -

        public static Mat operator -(Mat a, Mat b)
        {
            Mat m = new Mat();
            Core.subtract(a, b, m);
            return m;
        }

        public static Mat operator -(Mat a, Scalar s)
        {
            Mat m = new Mat();
            Core.subtract(a, s, m);
            return m;
        }

        public static Mat operator -(Scalar s, Mat a)
        {
            Mat m = new Mat();
            using (Mat b = new Mat(a.size(), a.type(), s))
            {
                Core.subtract(b, a, m);
            }
            return m;
        }

        #endregion

        #region *

        public static Mat operator *(Mat a, Mat b)
        {
            Mat m = new Mat();
            Core.gemm(a, b, 1, new Mat(), 0, m);
            return m;
        }

        public static Mat operator *(Mat a, double s)
        {
            Mat m = new Mat();
            Core.multiply(a, Scalar.all(s), m);
            return m;
        }

        public static Mat operator *(double s, Mat a)
        {
            Mat m = new Mat();
            Core.multiply(a, Scalar.all(s), m);
            return m;
        }

        #endregion

        #region /

        public static Mat operator /(Mat a, Mat b)
        {
            Mat m = new Mat();
            Core.divide(a, b, m);
            return m;
        }

        public static Mat operator /(Mat a, double s)
        {
            Mat m = new Mat();
            Core.divide(a, Scalar.all(s), m);
            return m;
        }

        public static Mat operator /(double s, Mat a)
        {
            Mat m = new Mat();
            using (Mat b = new Mat(a.size(), a.type(), Scalar.all(s)))
            {
                Core.divide(b, a, m);
            }
            return m;
        }

        #endregion

        //#region &

        //public static Mat operator &(Mat a, Mat b)
        //{
        //    Mat m = new Mat();
        //    Core.bitwise_and(a, b, m);
        //    return m;
        //}

        //public static Mat operator &(Mat a, double s)
        //{
        //    Mat m = new Mat();
        //    using (Mat b = new Mat(a.size(), a.type(), new Scalar(s)))
        //    {
        //        Core.bitwise_and(a, b, m);
        //    }
        //    return m;
        //}

        //public static Mat operator &(double s, Mat a)
        //{
        //    Mat m = new Mat();
        //    using (Mat b = new Mat(a.size(), a.type(), new Scalar(s)))
        //    {
        //        Core.bitwise_and(b, a, m);
        //    }
        //    return m;
        //}

        //#endregion

        //#region |

        //public static Mat operator |(Mat a, Mat b)
        //{
        //    Mat m = new Mat();
        //    Core.bitwise_or(a, b, m);
        //    return m;
        //}

        //public static Mat operator |(Mat a, double s)
        //{
        //    Mat m = new Mat();
        //    using (Mat b = new Mat(a.size(), a.type(), new Scalar(s)))
        //    {
        //        Core.bitwise_or(a, b, m);
        //    }
        //    return m;
        //}

        //public static Mat operator |(double s, Mat a)
        //{
        //    Mat m = new Mat();
        //    using (Mat b = new Mat(a.size(), a.type(), new Scalar(s)))
        //    {
        //        Core.bitwise_or(b, a, m);
        //    }
        //    return m;
        //}

        //#endregion

        //#region ^

        //public static Mat operator ^(Mat a, Mat b)
        //{
        //    Mat m = new Mat();
        //    Core.bitwise_xor(a, b, m);
        //    return m;
        //}

        //public static Mat operator ^(Mat a, double s)
        //{
        //    Mat m = new Mat();
        //    using (Mat b = new Mat(a.size(), a.type(), new Scalar(s)))
        //    {
        //        Core.bitwise_xor(a, b, m);
        //    }
        //    return m;
        //}

        //public static Mat operator ^(double s, Mat a)
        //{
        //    Mat m = new Mat();
        //    using (Mat b = new Mat(a.size(), a.type(), new Scalar(s)))
        //    {
        //        Core.bitwise_xor(b, a, m);
        //    }
        //    return m;
        //}

        //#endregion

        //#region ~

        //public static Mat operator ~(Mat a)
        //{
        //    Mat m = new Mat();
        //    Core.bitwise_not(a, m);
        //    return m;
        //}

        //#endregion

        #endregion

        #endregion

    }
}
