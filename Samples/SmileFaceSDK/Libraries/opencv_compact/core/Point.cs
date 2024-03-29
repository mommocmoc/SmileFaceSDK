﻿using System;

namespace OpenCVCompact
{

    /**
     * <p>template<typename _Tp> class CV_EXPORTS Point_ <code></p>
     *
     * <p>// C++ code:</p>
     *
     *
     * <p>public:</p>
     *
     * <p>typedef _Tp value_type;</p>
     *
     * <p>// various constructors</p>
     *
     * <p>Point_();</p>
     *
     * <p>Point_(_Tp _x, _Tp _y);</p>
     *
     * <p>Point_(const Point_& pt);</p>
     *
     * <p>Point_(const CvPoint& pt);</p>
     *
     * <p>Point_(const CvPoint2D32f& pt);</p>
     *
     * <p>Point_(const Size_<_Tp>& sz);</p>
     *
     * <p>Point_(const Vec<_Tp, 2>& v);</p>
     *
     * <p>Point_& operator = (const Point_& pt);</p>
     *
     * <p>//! conversion to another data type</p>
     *
     * <p>template<typename _Tp2> operator Point_<_Tp2>() const;</p>
     *
     * <p>//! conversion to the old-style C structures</p>
     *
     * <p>operator CvPoint() const;</p>
     *
     * <p>operator CvPoint2D32f() const;</p>
     *
     * <p>operator Vec<_Tp, 2>() const;</p>
     *
     * <p>//! dot product</p>
     *
     * <p>_Tp dot(const Point_& pt) const;</p>
     *
     * <p>//! dot product computed in double-precision arithmetics</p>
     *
     * <p>double ddot(const Point_& pt) const;</p>
     *
     * <p>//! cross-product</p>
     *
     * <p>double cross(const Point_& pt) const;</p>
     *
     * <p>//! checks whether the point is inside the specified rectangle</p>
     *
     * <p>bool inside(const Rect_<_Tp>& r) const;</p>
     *
     * <p>_Tp x, y; //< the point coordinates</p>
     *
     * <p>};</p>
     *
     * <p>Template class for 2D points specified by its coordinates </code></p>
     *
     * <p><em>x</em> and <em>y</em>.
     * An instance of the class is interchangeable with C structures,
     * <code>CvPoint</code> and <code>CvPoint2D32f</code>. There is also a cast
     * operator to convert point coordinates to the specified type. The conversion
     * from floating-point coordinates to integer coordinates is done by rounding.
     * Commonly, the conversion uses thisoperation for each of the coordinates.
     * Besides the class members listed in the declaration above, the following
     * operations on points are implemented: <code></p>
     *
     * <p>// C++ code:</p>
     *
     * <p>pt1 = pt2 + pt3;</p>
     *
     * <p>pt1 = pt2 - pt3;</p>
     *
     * <p>pt1 = pt2 * a;</p>
     *
     * <p>pt1 = a * pt2;</p>
     *
     * <p>pt1 += pt2;</p>
     *
     * <p>pt1 -= pt2;</p>
     *
     * <p>pt1 *= a;</p>
     *
     * <p>double value = norm(pt); // L2 norm</p>
     *
     * <p>pt1 == pt2;</p>
     *
     * <p>pt1 != pt2;</p>
     *
     * <p>For your convenience, the following type aliases are defined:</p>
     *
     * <p>typedef Point_<int> Point2i;</p>
     *
     * <p>typedef Point2i Point;</p>
     *
     * <p>typedef Point_<float> Point2f;</p>
     *
     * <p>typedef Point_<double> Point2d;</p>
     *
     * <p>Example:</p>
     *
     * <p>Point2f a(0.3f, 0.f), b(0.f, 0.4f);</p>
     *
     * <p>Point pt = (a + b)*10.f;</p>
     *
     * <p>cout << pt.x << ", " << pt.y << endl;</p>
     *
     * @see <a href="http://docs.opencv.org/modules/core/doc/basic_structures.html#point">org.opencv.core.Point_</a>
     */
    [System.Serializable]
    public struct Point : IEquatable<Point>
    {

        public double x, y;

        public Point (double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point (double[] vals)
            : this ()
        {
            set (vals);
        }

        public void set (double[] vals)
        {
            if (vals != null)
            {
                x = vals.Length > 0 ? vals[0] : 0;
                y = vals.Length > 1 ? vals[1] : 0;
            }
            else
            {
                x = 0;
                y = 0;
            }
        }

        public Point clone ()
        {
            return new Point (x, y);
        }

        public double dot (Point p)
        {
            return x * p.x + y * p.y;
        }

        ////  @Override
        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            long temp;
            temp = BitConverter.DoubleToInt64Bits(x);
            result = prime * result + (int)(temp ^ (Utils.URShift(temp, 32)));
            temp = BitConverter.DoubleToInt64Bits(y);
            result = prime * result + (int)(temp ^ (Utils.URShift(temp, 32)));
            return result;
        }

        //@Override
        //public override bool Equals (Object obj)
        //{
        //    if (this == obj)
        //        return true;
        //    if (!(obj is Point))
        //        return false;
        //    Point it = (Point)obj;
        //    return x == it.x && y == it.y;
        //}

        public bool Equals(Point other)
        {
            if (this.x == other.x && this.y == other.y) return true;
            return false;
        }

        public bool inside (Rect r)
        {
            return r.contains (this);
        }

        //@Override
        public override string ToString ()
        {
            return "{" + x + ", " + y + "}";
        }


        //
        #region Operators

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER

        public static Point operator + (Point pt)
        {
            return pt;
        }
        
        public static Point operator - (Point pt)
        {
            return new Point (-pt.x, -pt.y);
        }
        
        public static Point operator + (Point p1, Point p2)
        {
            return new Point (p1.x + p2.x, p1.y + p2.y);
        }
        
        public static Point operator - (Point p1, Point p2)
        {
            return new Point (p1.x - p2.x, p1.y - p2.y);
        }
        
        public static Point operator * (Point pt, double scale)
        {
            return new Point (pt.x * scale, pt.y * scale);
        }
        
        public static Point operator * (double scale, Point pt)
        {
            return new Point (pt.x * scale, pt.y * scale);
        }
        
#endif

        #endregion
        //
    }
}
