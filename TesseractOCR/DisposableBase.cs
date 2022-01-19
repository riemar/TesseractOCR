﻿//
// DisposableBase.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright 2012-2019 Charles Weld
// Copyright 2021-2022 Kees van Spelde
//
// Licensed under the Apache License, Version 2.0 (the "License");
//
// - You may not use this file except in compliance with the License.
// - You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Diagnostics;

namespace TesseractOCR
{
    public abstract class DisposableBase : IDisposable
    {
        #region Events
        public event EventHandler<EventArgs> Disposed;
        #endregion

        #region Properties
        private static readonly TraceSource Trace = new TraceSource("Tesseract");

        public bool IsDisposed { get; private set; }
        #endregion

        #region Constructor
        protected DisposableBase()
        {
            IsDisposed = false;
        }
        #endregion

        #region Destructor
        ~DisposableBase()
        {
            Dispose(false);
            Trace.TraceEvent(TraceEventType.Warning, 0, "{0} was not disposed off.", this);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            Dispose(true);

            IsDisposed = true;
            GC.SuppressFinalize(this);

            Disposed?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region VerifyNotDisposed
        protected virtual void VerifyNotDisposed()
        {
            if (IsDisposed) throw new ObjectDisposedException(ToString());
        }
        #endregion

        #region Abstracts
        protected abstract void Dispose(bool disposing);
        #endregion
    }
}