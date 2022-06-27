using UnityEngine;

using System;

namespace OpenCVCompact
{
    abstract public class DisposableOpenCVCompactObject : OpenCVCompact.DisposableObject
    {

        internal IntPtr nativeObj;

        protected DisposableOpenCVCompactObject()
            : this (true)
        {
        }

        protected DisposableOpenCVCompactObject(IntPtr ptr)
            : this (ptr, true)
        {
        }

        protected DisposableOpenCVCompactObject(bool isEnabledDispose)
            : this (IntPtr.Zero, isEnabledDispose)
        {
        }

        protected DisposableOpenCVCompactObject(IntPtr ptr, bool isEnabledDispose)
            : base (isEnabledDispose)
        {
            this.nativeObj = ptr;
        }

        protected override void Dispose (bool disposing)
        {


            try
            {
                if (disposing)
                {
                }
                nativeObj = IntPtr.Zero;

            }
            finally
            {
                base.Dispose (disposing);
            }

        }

    }
}
