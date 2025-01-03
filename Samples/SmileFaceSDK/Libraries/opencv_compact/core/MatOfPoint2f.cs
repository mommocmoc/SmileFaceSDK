﻿using System;
using System.Collections.Generic;

namespace OpenCVCompact
{
    public class MatOfPoint2f : Mat
    {
        // 32FC2
        private const int _depth = CvType.CV_32F;
        private const int _channels = 2;

        public MatOfPoint2f ()
            : base ()
        {

        }

        protected MatOfPoint2f (IntPtr addr)
            : base (addr)
        {

            if (!empty () && checkVector (_channels, _depth) < 0)
                throw new CvException ("Incompatible Mat");
            //FIXME: do we need release() here?
        }

        public static MatOfPoint2f fromNativeAddr (IntPtr addr)
        {
            return new MatOfPoint2f (addr);
        }

        public MatOfPoint2f (Mat m)
            : base (m, Range.all ())
        {
            if (m != null)
                m.ThrowIfDisposed ();


            if (!empty () && checkVector (_channels, _depth) < 0)
                throw new CvException ("Incompatible Mat");
            //FIXME: do we need release() here?
        }

        public MatOfPoint2f (params Point[] a)
            : base ()
        {

            fromArray (a);
        }

        public void alloc (int elemNumber)
        {
            if (elemNumber > 0)
                base.create (elemNumber, 1, CvType.makeType (_depth, _channels));
        }

        public void fromArray (params Point[] a)
        {
            if (a == null || a.Length == 0)
                return;
            int num = a.Length;
            alloc (num);
            float[] buff = new float[num * _channels];
            for (int i = 0; i < num; i++)
            {
                Point p = a[i];
                buff[_channels * i + 0] = (float)p.x;
                buff[_channels * i + 1] = (float)p.y;
            }
            put (0, 0, buff); //TODO: check ret val!
        }

        public Point[] toArray ()
        {
            int num = (int)total ();
            Point[] ap = new Point[num];
            if (num == 0)
                return ap;
            float[] buff = new float[num * _channels];
            get (0, 0, buff); //TODO: check ret val!
            for (int i = 0; i < num; i++)
                ap[i] = new Point (buff[i * _channels], buff[i * _channels + 1]);
            return ap;
        }

        public void fromList (List<Point> lp)
        {
            Point[] ap = lp.ToArray ();
            fromArray (ap);
        }

        public List<Point> toList ()
        {
            Point[] ap = toArray ();
            return new List<Point> (ap);
        }
    }
}