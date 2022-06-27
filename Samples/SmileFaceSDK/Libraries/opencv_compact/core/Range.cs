using System;

namespace OpenCVCompact
{
    [System.Serializable]
    public class Range
    {

        public int start, end;

        public Range (int s, int e)
        {
            this.start = s;
            this.end = e;
        }

        public Range ()
            : this (0, 0)
        {

        }

        public Range (double[] vals)
        {
            set (vals);
        }

        public void set (double[] vals)
        {
            if (vals != null)
            {
                start = vals.Length > 0 ? (int)vals[0] : 0;
                end = vals.Length > 1 ? (int)vals[1] : 0;
            }
            else
            {
                start = 0;
                end = 0;
            }

        }

        public int size ()
        {
            return empty () ? 0 : end - start;
        }

        public bool empty ()
        {
            return end <= start;
        }

        public static Range all ()
        {
            return new Range (int.MinValue, int.MaxValue);


        }

        public Range intersection (Range r1)
        {
            Range r = new Range (Math.Max (r1.start, this.start), Math.Min (r1.end, this.end));
            r.end = Math.Max (r.end, r.start);
            return r;
        }

        public Range shift (int delta)
        {
            return new Range (start + delta, end + delta);
        }

        public Range clone ()
        {
            return new Range (start, end);
        }

        //@Override
        public override int GetHashCode ()
        {
            const int prime = 31;
            int result = 1;
            long temp;
            temp = BitConverter.DoubleToInt64Bits (start);
            result = prime * result + (int)(temp ^ (Utils.URShift (temp, 32)));
            temp = BitConverter.DoubleToInt64Bits (end);
            result = prime * result + (int)(temp ^ (Utils.URShift (temp, 32)));
            return result;
        }

        //@Override
        public override bool Equals (Object obj)
        {
            if (this == obj)
                return true;
            if (!(obj is Range))
                return false;
            Range it = (Range)obj;
            return start == it.start && end == it.end;
        }

        //@Override
        public override string ToString ()
        {
            return "[" + start + ", " + end + ")";
        }
    }
}
