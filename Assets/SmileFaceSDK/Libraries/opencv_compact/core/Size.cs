using System;

namespace OpenCVCompact
{
    [System.Serializable]
    public class Size
    {

        public double width, height;

        public Size (double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public Size ()
            : this (0, 0)
        {

        }

        public Size (Point p)
        {
            width = p.x;
            height = p.y;
        }

        public Size (double[] vals)
        {
            set (vals);
        }

        public void set (double[] vals)
        {
            if (vals != null)
            {
                width = vals.Length > 0 ? vals[0] : 0;
                height = vals.Length > 1 ? vals[1] : 0;
            }
            else
            {
                width = 0;
                height = 0;
            }
        }

        public double area ()
        {
            return width * height;
        }

        public bool empty ()
        {
            return width <= 0 || height <= 0;
        }

        public Size clone ()
        {
            return new Size (width, height);
        }

        //@Override
        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            long temp;
            temp = BitConverter.DoubleToInt64Bits(height);
            result = prime * result + (int)(temp ^ (Utils.URShift(temp, 32)));
            temp = BitConverter.DoubleToInt64Bits(width);
            result = prime * result + (int)(temp ^ (Utils.URShift(temp, 32)));
            return result;
        }

        //@Override
        public override bool Equals (Object obj)
        {
            if (this == obj)
                return true;
            if (!(obj is Size))
                return false;
            Size it = (Size)obj;
            return width == it.width && height == it.height;
        }

        //@Override
        public override string ToString ()
        {
            return (int)width + "x" + (int)height;
        }

    }
}

