using System;
using System.Linq;

namespace OpenCVCompact
{
    [System.Serializable]
    public struct Scalar : IEquatable<Scalar>
    {

        public double[] val;

        public Scalar (double v0, double v1, double v2, double v3)
        {
            val = new double[] { v0, v1, v2, v3 };
        }

        public Scalar (double v0, double v1, double v2)
        {
            val = new double[] { v0, v1, v2, 0 };
        }

        public Scalar (double v0, double v1)
        {
            val = new double[] { v0, v1, 0, 0 };
        }

        public Scalar (double v0)
        {
            val = new double[] { v0, 0, 0, 0 };
        }

        public Scalar (double[] vals)
        {
            if (vals != null && vals.Length == 4)
                val = (double[])vals.Clone ();
            else
            {
                val = new double[4];
                set (vals);
            }
        }

        public void set (double[] vals)
        {
            if (vals != null)
            {
                val[0] = vals.Length > 0 ? vals[0] : 0;
                val[1] = vals.Length > 1 ? vals[1] : 0;
                val[2] = vals.Length > 2 ? vals[2] : 0;
                val[3] = vals.Length > 3 ? vals[3] : 0;
            }
            else
                val[0] = val[1] = val[2] = val[3] = 0;
        }

        public static Scalar all (double v)
        {
            return new Scalar (v, v, v, v);
        }

        public Scalar clone ()
        {
            return new Scalar (val);
        }

        public Scalar mul (Scalar it, double scale)
        {
            return new Scalar (val[0] * it.val[0] * scale, val[1] * it.val[1] * scale,
                          val[2] * it.val[2] * scale, val[3] * it.val[3] * scale);
        }

        public Scalar mul (Scalar it)
        {
            return mul (it, 1);
        }

        public Scalar conj ()
        {
            return new Scalar (val[0], -val[1], -val[2], -val[3]);
        }

        public bool isReal ()
        {
            return val[1] == 0 && val[2] == 0 && val[3] == 0;
        }

        ////@Override
        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            //      result = prime * result + java.util.Arrays.hashCode(val);//TODO: @CHECK
            result = prime * result + Utils.HashContents(val);
            return result;
        }

        //@Override
        //public override bool Equals (Object obj)
        //{
        //    if (this == obj)
        //        return true;
        //    if (!(obj is Scalar))
        //        return false;
        //    Scalar it = (Scalar)obj;
        //    //      if (!java.util.Arrays.equals(val, it.val)) return false;//TODO: @CHECK
        //    if (!val.SequenceEqual (it.val))
        //        return false;
        //    return true;
        //}

        //@Override
        public override string ToString ()
        {
            return string.Format("{0}, {1}, {2}, {3}", this.val[0], this.val[1], this.val[2], this.val[3]);
            //return "[" + val[0] + ", " + val[1] + ", " + val[2] + ", " + val[3] + "]";
        }

        public bool Equals(Scalar other)
        {
            if (this.val == null || this.val.Length == 0)
            {
                if (other.val == null || other.val.Length == 0) return true;
                return false;
            }

            if (this.val.Length != other.val.Length) return false;

            for (int i = 0, length = this.val.Length; i < length; ++i)
            {
                if (this.val[i] != other.val[i]) return false;
            }

            return true;
        }
    }
}
