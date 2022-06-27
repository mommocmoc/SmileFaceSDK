using System;

namespace OpenCVCompact
{
    [System.Serializable]
    public struct Rect : IEquatable<Rect>
    {
        public static Rect Zero = new Rect();

        public int x, y, width, height;

        public Rect (int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public Rect (Point p1, Point p2)
        {
            x = (int)(p1.x < p2.x ? p1.x : p2.x);
            y = (int)(p1.y < p2.y ? p1.y : p2.y);
            width = (int)(p1.x > p2.x ? p1.x : p2.x) - x;
            height = (int)(p1.y > p2.y ? p1.y : p2.y) - y;
        }

        public Rect (Point p, Size s)
            : this ((int)p.x, (int)p.y, (int)s.width, (int)s.height)
        {

        }

        public Rect (double[] vals)
        {
            if (vals != null)
            {
                x = vals.Length > 0 ? (int)vals[0] : 0;
                y = vals.Length > 1 ? (int)vals[1] : 0;
                width = vals.Length > 2 ? (int)vals[2] : 0;
                height = vals.Length > 3 ? (int)vals[3] : 0;
            }
            else
            {
                x = 0;
                y = 0;
                width = 0;
                height = 0;
            }
        }

        public void set (double[] vals)
        {
            if (vals != null)
            {
                x = vals.Length > 0 ? (int)vals[0] : 0;
                y = vals.Length > 1 ? (int)vals[1] : 0;
                width = vals.Length > 2 ? (int)vals[2] : 0;
                height = vals.Length > 3 ? (int)vals[3] : 0;
            }
            else
            {
                x = 0;
                y = 0;
                width = 0;
                height = 0;
            }
        }

        public Rect clone ()
        {
            return new Rect (x, y, width, height);
        }

        public Point tl ()
        {
            return new Point (x, y);
        }

        public Point br ()
        {
            return new Point (x + width, y + height);
        }

        public Size size ()
        {
            return new Size (width, height);
        }

        public double area ()
        {
            return width * height;
        }

        public bool empty ()
        {
            return width <= 0 || height <= 0;
        }

        public bool contains (Point p)
        {
            return x <= p.x && p.x < x + width && y <= p.y && p.y < y + height;
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
            temp = BitConverter.DoubleToInt64Bits(x);
            result = prime * result + (int)(temp ^ (Utils.URShift(temp, 32)));
            temp = BitConverter.DoubleToInt64Bits(y);
            result = prime * result + (int)(temp ^ (Utils.URShift(temp, 32)));
            return result;
        }
        
        public bool Equals(Rect other)
        {
            if (this.x == other.x && this.y == other.y &&
                this.width == other.width && this.height == other.height)
                return true;

            return false;
        }

        //@Override
        public override string ToString ()
        {
            return "{" + x + ", " + y + ", " + width + "x" + height + "}";
        }

        //
        #region Operators

        public static Rect operator + (Rect rect, Point pt)
        {
            return new Rect (rect.x + (int)pt.x, rect.y + (int)pt.y, rect.width, rect.height);
        }

        public static Rect operator - (Rect rect, Point pt)
        {
            return new Rect (rect.x - (int)pt.x, rect.y - (int)pt.y, rect.width, rect.height);
        }

        public static Rect operator + (Rect rect, Size size)
        {
            return new Rect (rect.x, rect.y, rect.width + (int)size.width, rect.height + (int)size.height);
        }

        public static Rect operator - (Rect rect, Size size)
        {
            return new Rect (rect.x, rect.y, rect.width - (int)size.width, rect.height - (int)size.height);
        }

        public static Rect operator & (Rect a, Rect b)
        {
            return intersect (a, b);
        }

        public static Rect operator | (Rect a, Rect b)
        {
            return union (a, b);
        }

        #endregion

        public bool contains (int x, int y)
        {
            return this.x <= x && x < this.x + this.width && this.y <= y && y < this.y + this.height;
        }

        public bool contains (Rect rect)
        {
            return x <= rect.x &&
                (rect.x + rect.width) <= (x + width) &&
                y <= rect.y &&
                (rect.y + rect.height) <= (y + height);
        }

        public void inflate (int width, int height)
        {
            this.x -= width;
            this.y -= height;
            this.width += (2 * width);
            this.height += (2 * height);
        }

        public void inflate (Size size)
        {
            inflate ((int)size.width, (int)size.height);
        }

        public static Rect inflate (Rect rect, int x, int y)
        {
            rect.inflate (x, y);
            return rect;
        }

        public static Rect intersect (Rect a, Rect b)
        {
            int x1 = Math.Max (a.x, b.x);
            int x2 = Math.Min (a.x + a.width, b.x + b.width);
            int y1 = Math.Max (a.y, b.y);
            int y2 = Math.Min (a.y + a.height, b.y + b.height);

            if (x2 >= x1 && y2 >= y1)
                return new Rect (x1, y1, x2 - x1, y2 - y1);

            return Zero;
        }

        public Rect intersect (Rect rect)
        {
            return intersect (this, rect);
        }

        public bool intersectsWith (Rect rect)
        {
            return (
                (x < rect.x + rect.width) &&
                (x + width > rect.x) &&
                (y < rect.y + rect.height) &&
                (y + height > rect.y)
                );
        }

        public Rect union (Rect rect)
        {
            return union (this, rect);
        }

        public static Rect union (Rect a, Rect b)
        {
            int x1 = Math.Min (a.x, b.x);
            int x2 = Math.Max (a.x + a.width, b.x + b.width);
            int y1 = Math.Min (a.y, b.y);
            int y2 = Math.Max (a.y + a.height, b.y + b.height);

            return new Rect (x1, y1, x2 - x1, y2 - y1);
        }
    }
}