using System;

namespace OpenCVCompact
{
    [System.Serializable]
    public struct RectFloat : IEquatable<RectFloat>
    {
        public static RectFloat Zero = new RectFloat();

        public float x, y, width, height;

        public RectFloat(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public RectFloat(Point p1, Point p2)
        {
            x = (float)(p1.x < p2.x ? p1.x : p2.x);
            y = (float)(p1.y < p2.y ? p1.y : p2.y);
            width = (float)(p1.x > p2.x ? p1.x : p2.x) - x;
            height = (float)(p1.y > p2.y ? p1.y : p2.y) - y;
        }

        public RectFloat(Point p, Size s)
            : this ((float)p.x, (float)p.y, (float)s.width, (float)s.height)
        {

        }

        public RectFloat(double[] vals)
        {
            if (vals != null)
            {
                x = vals.Length > 0 ? (float)vals[0] : 0;
                y = vals.Length > 1 ? (float)vals[1] : 0;
                width = vals.Length > 2 ? (float)vals[2] : 0;
                height = vals.Length > 3 ? (float)vals[3] : 0;
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
                x = vals.Length > 0 ? (float)vals[0] : 0;
                y = vals.Length > 1 ? (float)vals[1] : 0;
                width = vals.Length > 2 ? (float)vals[2] : 0;
                height = vals.Length > 3 ? (float)vals[3] : 0;
            }
            else
            {
                x = 0;
                y = 0;
                width = 0;
                height = 0;
            }
        }

        public RectFloat clone ()
        {
            return new RectFloat(x, y, width, height);
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
        
        public bool Equals(RectFloat other)
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

        public static RectFloat operator + (RectFloat rect, Point pt)
        {
            return new RectFloat(rect.x + (float)pt.x, rect.y + (float)pt.y, rect.width, rect.height);
        }

        public static RectFloat operator - (RectFloat rect, Point pt)
        {
            return new RectFloat(rect.x - (float)pt.x, rect.y - (float)pt.y, rect.width, rect.height);
        }

        public static RectFloat operator + (RectFloat rect, Size size)
        {
            return new RectFloat(rect.x, rect.y, rect.width + (float)size.width, rect.height + (float)size.height);
        }

        public static RectFloat operator - (RectFloat rect, Size size)
        {
            return new RectFloat(rect.x, rect.y, rect.width - (float)size.width, rect.height - (float)size.height);
        }

        public static RectFloat operator & (RectFloat a, RectFloat b)
        {
            return intersect (a, b);
        }

        public static RectFloat operator | (RectFloat a, RectFloat b)
        {
            return union (a, b);
        }

        #endregion

        public bool contains (float x, float y)
        {
            return this.x <= x && x < this.x + this.width && this.y <= y && y < this.y + this.height;
        }

        public bool contains (RectFloat rect)
        {
            return x <= rect.x &&
                (rect.x + rect.width) <= (x + width) &&
                y <= rect.y &&
                (rect.y + rect.height) <= (y + height);
        }

        public void inflate (float width, float height)
        {
            this.x -= width;
            this.y -= height;
            this.width += (2 * width);
            this.height += (2 * height);
        }

        public void inflate (Size size)
        {
            inflate ((float)size.width, (float)size.height);
        }

        public static RectFloat inflate (RectFloat rect, float x, float y)
        {
            rect.inflate (x, y);
            return rect;
        }

        public static RectFloat intersect (RectFloat a, RectFloat b)
        {
            float x1 = Math.Max (a.x, b.x);
            float x2 = Math.Min (a.x + a.width, b.x + b.width);
            float y1 = Math.Max (a.y, b.y);
            float y2 = Math.Min (a.y + a.height, b.y + b.height);

            if (x2 >= x1 && y2 >= y1)
                return new RectFloat(x1, y1, x2 - x1, y2 - y1);

            return Zero;
        }

        public RectFloat intersect (RectFloat rect)
        {
            return intersect (this, rect);
        }

        public bool intersectsWith (RectFloat rect)
        {
            return (
                (x < rect.x + rect.width) &&
                (x + width > rect.x) &&
                (y < rect.y + rect.height) &&
                (y + height > rect.y)
                );
        }

        public RectFloat union (RectFloat rect)
        {
            return union (this, rect);
        }

        public static RectFloat union (RectFloat a, RectFloat b)
        {
            float x1 = Math.Min (a.x, b.x);
            float x2 = Math.Max (a.x + a.width, b.x + b.width);
            float y1 = Math.Min (a.y, b.y);
            float y2 = Math.Max (a.y + a.height, b.y + b.height);

            return new RectFloat(x1, y1, x2 - x1, y2 - y1);
        }
    }
}