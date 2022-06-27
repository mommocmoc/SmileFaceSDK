/*************************************************************************
*
* ILLUNI CONFIDENTIAL
* __________________
*
*  [2018] Illuni Incorporated
*  All Rights Reserved.
*
* NOTICE:  All information contained herein is, and remains
* the property of Illuni Incorporated and its suppliers,
* if any.  The intellectual and technical concepts contained
* herein are proprietary to Illuni Incorporated
* and its suppliers and may be covered by Republic of Korea, U.S. and Foreign Patents,
* patents in process, and are protected by trade secret or copyright law.
* Dissemination of this information or reproduction of this material
* is strictly forbidden unless prior written permission is obtained
* from Illuni Incorporated.
*/

using UnityEngine;
using System;

namespace dnn
{
    public class dnnDisposeable : IDisposable
    {
        internal IntPtr nativeObj;

        public bool IsDisposed { get; protected set; }
        public bool IsEnabledDispose { get; set; }

        protected dnnDisposeable()
            : this (true)
        {
        }

        protected dnnDisposeable(IntPtr ptr)
            : this (ptr, true)
        {
        }

        protected dnnDisposeable(bool isEnabledDispose)
            : this (IntPtr.Zero, isEnabledDispose)
        {
        }

        protected dnnDisposeable(IntPtr ptr, bool isEnabledDispose)
        {
            IsEnabledDispose = isEnabledDispose;
            IsDisposed = false;
            this.nativeObj = ptr;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
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
                if (!IsDisposed)
                {

                    if (disposing)
                    {
                    }

                    IsDisposed = true;
                }
            }
        }

        ~dnnDisposeable()
        {
            Dispose(false);
        }

        public void ThrowIfDisposed()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(GetType().FullName);
        }
    }
}