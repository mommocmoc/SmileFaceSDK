using System;

namespace OpenCVCompact
{
    [System.Serializable]
    public class Point3
    {

        public double x, y, z;

        public Point3 (double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Point3 ()
            : this (0, 0, 0)
        {

        }

        public Point3 (Point p)
        {
            x = p.x;
            y = p.y;
            z = 0;
        }

        public Point3 (double[] vals)
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
                z = vals.Length > 2 ? vals[2] : 0;
            }
            else
            {
                x = 0;
                y = 0;
                z = 0;
            }
        }

        public Point3 clone ()
        {
            return new Point3 (x, y, z);
        }

        public double dot (Point3 p)
        {
            return x * p.x + y * p.y + z * p.z;
        }

        public Point3 cross (Point3 p)
        {
            return new Point3 (y * p.z - z * p.y, z * p.x - x * p.z, x * p.y - y * p.x);
        }

        //@Override
        public override int GetHashCode ()
        {
            const int prime = 31;
            int result = 1;
            long temp;
            temp = BitConverter.DoubleToInt64Bits (x);
            result = prime * result + (int)(temp ^ (Utils.URShift (temp, 32)));
            temp = BitConverter.DoubleToInt64Bits (y);
            result = prime * result + (int)(temp ^ (Utils.URShift (temp, 32)));
            temp = BitConverter.DoubleToInt64Bits (z);
            result = prime * result + (int)(temp ^ (Utils.URShift (temp, 32)));
            return result;
        }

        //@Override
        public override bool Equals (Object obj)
        {
            if (this == obj)
                return true;
            if (!(obj is Point3))
                return false;
            Point3 it = (Point3)obj;
            return x == it.x && y == it.y && z == it.z;
        }

        //@Override
        public override string ToString ()
        {
            return "{" + x + ", " + y + ", " + z + "}";
        }

        //
        #region Operators

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        public static Point3 operator + (Point3 pt)
        {
            return pt;
        }
        
        public static Point3 operator - (Point3 pt)
        {
            return new Point3 (-pt.x, -pt.y, -pt.z);
        }
        
        public static Point3 operator + (Point3 p1, Point3 p2)
        {
            return new Point3 (p1.x + p2.x, p1.y + p2.y, p1.z + p2.z);
        }
        
        public static Point3 operator - (Point3 p1, Point3 p2)
        {
            return new Point3 (p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);
        }
        
        public static Point3 operator * (Point3 pt, double scale)
        {
            return new Point3 (pt.x * scale, pt.y * scale, pt.z * scale);
        }
        
        public static Point3 operator * (double scale, Point3 pt)
        {
            return new Point3 (pt.x * scale, pt.y * scale, pt.z * scale);
        }
        
#endif

        #endregion
        //
    }
}
