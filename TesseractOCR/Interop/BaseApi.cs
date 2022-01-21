﻿//
// BaseApi.cs
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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using TesseractOCR.Enums;
using TesseractOCR.Internal;
using TesseractOCR.InteropDotNet;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace TesseractOCR.Interop
{
    /// <summary>
    ///     The exported tesseract api signatures.
    /// </summary>
    /// <remarks>
    ///     Please note this is only public for technical reasons (you can't proxy a internal interface).
    ///     It should be considered an internal interface and is NOT part of the public api and may have
    ///     breaking changes between releases.
    /// </remarks>
    public interface ITessApiSignatures
    {
        #region Base API
        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetComponentImages")]
        IntPtr BaseApiGetComponentImages(HandleRef handle, PageIteratorLevel level, int text_only, IntPtr pixa, IntPtr blockids);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIAnalyseLayout")]
        IntPtr BaseApiAnalyseLayout(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIClear")]
        void BaseApiClear(HandleRef handle);

        /// <summary>
        ///     Creates a new BaseApi instance
        /// </summary>
        /// <returns></returns>
        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPICreate")]
        IntPtr BaseApiCreate();

        /// <summary>
        ///     Deletes a base api instance.
        /// </summary>
        /// <returns></returns>
        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIDelete")]
        void BaseApiDelete(HandleRef ptr);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIDetectOrientationScript")]
        int TessBaseAPIDetectOrientationScript(HandleRef handle, out int orient_deg, out float orient_conf, out IntPtr script_name, out float script_conf);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetBoolVariable")]
        int BaseApiGetBoolVariable(HandleRef handle, string name, out int value);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetDoubleVariable")]
        int BaseApiGetDoubleVariable(HandleRef handle, string name, out double value);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetHOCRText")]
        IntPtr BaseApiGetHOcrTextInternal(HandleRef handle, int pageNum);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetAltoText")]
        IntPtr BaseApiGetAltoTextInternal(HandleRef handle, int pageNum);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetTsvText")]
        IntPtr BaseApiGetTsvTextInternal(HandleRef handle, int pageNum);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetBoxText")]
        IntPtr BaseApiGetBoxTextInternal(HandleRef handle, int pageNum);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetLSTMBoxText")]
        IntPtr BaseApiGetLstmBoxTextInternal(HandleRef handle, int pageNum);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetWordStrBoxText")]
        IntPtr BaseApiGetWordStrBoxTextInternal(HandleRef handle, int pageNum);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetUNLVText")]
        IntPtr BaseApiGetUnlvTextInternal(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetIntVariable")]
        int BaseApiGetIntVariable(HandleRef handle, string name, out int value);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetIterator")]
        IntPtr BaseApiGetIterator(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetPageSegMode")]
        PageSegMode BaseApiGetPageSegMode(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetStringVariable")]
        IntPtr BaseApiGetStringVariableInternal(HandleRef handle, string name);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetThresholdedImage")]
        IntPtr BaseApiGetThresholdedImage(HandleRef handle);

        // The following were causing issues on Linux/MacOsX when used in .net core
        //[RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIProcessPages")]
        //int BaseApiProcessPages(HandleRef handle, string filename, string retry_config, int timeout_millisec, HandleRef renderer);

        //[RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIProcessPage")]
        //int BaseApiProcessPage(HandleRef handle, Pix pix, int page_index, string filename, string retry_config, int timeout_millisec, HandleRef renderer);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPISetInputName")]
        void BaseApiSetInputName(HandleRef handle, string name);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetDatapath")]
        string BaseApiGetDatapath(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPISetOutputName")]
        void BaseApiSetOutputName(HandleRef handle, string name);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIGetUTF8Text")]
        IntPtr BaseApiGetUTF8TextInternal(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIInit4")]
        int BaseApiInit(HandleRef handle, string datapath, string language, int mode,
            string[] configs, int configs_size,
            string[] vars_vec, string[] vars_values, UIntPtr vars_vec_size,
            bool set_only_non_debug_params);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIMeanTextConf")]
        int BaseApiMeanTextConf(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIRecognize")]
        int BaseApiRecognize(HandleRef handle, HandleRef monitor);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPISetDebugVariable")]
        int BaseApiSetDebugVariable(HandleRef handle, string name, IntPtr valPtr);

        // image analysis
        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPISetImage2")]
        void BaseApiSetImage(HandleRef handle, HandleRef pixHandle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPISetPageSegMode")]
        void BaseApiSetPageSegMode(HandleRef handle, PageSegMode mode);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPISetRectangle")]
        void BaseApiSetRectangle(HandleRef handle, int left, int top, int width, int height);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPISetVariable")]
        int BaseApiSetVariable(HandleRef handle, string name, IntPtr valPtr);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBaseAPIPrintVariablesToFile")]
        int BaseApiPrintVariablesToFile(HandleRef handle, string filename);
        #endregion

        #region Helper functions
        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessVersion")]
        IntPtr GetVersion();

        //[RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessDeleteBlockList")]
        //void DeleteBlockList(IntPtr arr);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessDeleteIntArray")]
        void DeleteIntArray(IntPtr arr);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessDeleteText")]
        void DeleteText(IntPtr textPtr);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessDeleteTextArray")]
        void DeleteTextArray(IntPtr arr);
        #endregion

        #region Result iterator
        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessPageIteratorBaseline")]
        int PageIteratorBaseline(HandleRef handle, PageIteratorLevel level, out int x1, out int y1, out int x2, out int y2);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessPageIteratorBegin")]
        void PageIteratorBegin(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessPageIteratorBlockType")]
        PolyBlockType PageIteratorBlockType(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessPageIteratorBoundingBox")]
        int PageIteratorBoundingBox(HandleRef handle, PageIteratorLevel level, out int left, out int top, out int right, out int bottom);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessPageIteratorCopy")]
        IntPtr PageIteratorCopy(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessPageIteratorDelete")]
        void PageIteratorDelete(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessPageIteratorGetBinaryImage")]
        IntPtr PageIteratorGetBinaryImage(HandleRef handle, PageIteratorLevel level);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessPageIteratorGetImage")]
        IntPtr PageIteratorGetImage(HandleRef handle, PageIteratorLevel level, int padding, HandleRef originalImage, out int left, out int top);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessPageIteratorIsAtBeginningOf")]
        int PageIteratorIsAtBeginningOf(HandleRef handle, PageIteratorLevel level);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessPageIteratorIsAtFinalElement")]
        int PageIteratorIsAtFinalElement(HandleRef handle, PageIteratorLevel level, PageIteratorLevel element);
        #endregion

        #region Page iterator
        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessPageIteratorNext")]
        int PageIteratorNext(HandleRef handle, PageIteratorLevel level);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessPageIteratorOrientation")]
        void PageIteratorOrientation(HandleRef handle, out Orientation orientation, out WritingDirection writing_direction, out TextLineOrder textLineOrder, out float deskew_angle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultIteratorCopy")]
        IntPtr ResultIteratorCopy(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultIteratorDelete")]
        void ResultIteratorDelete(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultIteratorConfidence")]
        float ResultIteratorGetConfidence(HandleRef handle, PageIteratorLevel level);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultIteratorWordFontAttributes")]
        IntPtr ResultIteratorWordFontAttributes(HandleRef handle, out bool isBold, out bool isItalic, out bool isUnderlined, out bool isMonospace, out bool isSerif, out bool isSmallCaps, out int pointSize, out int fontId);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultIteratorWordIsFromDictionary")]
        bool ResultIteratorWordIsFromDictionary(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultIteratorWordIsNumeric")]
        bool ResultIteratorWordIsNumeric(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultIteratorWordRecognitionLanguage")]
        IntPtr ResultIteratorWordRecognitionLanguageInternal(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultIteratorSymbolIsSuperscript")]
        bool ResultIteratorSymbolIsSuperscript(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultIteratorSymbolIsSubscript")]
        bool ResultIteratorSymbolIsSubscript(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultIteratorSymbolIsDropcap")]
        bool ResultIteratorSymbolIsDropcap(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultIteratorGetPageIterator")]
        IntPtr ResultIteratorGetPageIterator(HandleRef handle);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultIteratorGetUTF8Text")]
        IntPtr ResultIteratorGetUTF8TextInternal(HandleRef handle, PageIteratorLevel level);
        #endregion

        #region Choice Iterator
        /// <summary>
        ///     Native API call to TessResultIteratorGetChoiceIterator
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultIteratorGetChoiceIterator")]
        IntPtr ResultIteratorGetChoiceIterator(HandleRef handle);

        /// <summary>
        ///     Native API call to TessChoiceIteratorDelete
        /// </summary>
        /// <param name="handle"></param>
        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessChoiceIteratorDelete")]
        void ChoiceIteratorDelete(HandleRef handle);

        /// <summary>
        ///     Native API call to TessChoiceIteratorNext
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessChoiceIteratorNext")]
        int ChoiceIteratorNext(HandleRef handle);

        /// <summary>
        ///     Native API call to TessChoiceIteratorGetUTF8Text
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessChoiceIteratorGetUTF8Text")]
        IntPtr ChoiceIteratorGetUTF8TextInternal(HandleRef handle);

        /// <summary>
        ///     Native API call to TessChoiceIteratorConfidence
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessChoiceIteratorConfidence")]
        float ChoiceIteratorGetConfidence(HandleRef handle);
        #endregion

        #region Renderer API
        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessTextRendererCreate")]
        IntPtr TextRendererCreate(string outputbase);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessAltoRendererCreate")]
        IntPtr AltoRendererCreate(string outputbase);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessTsvRendererCreate")]
        IntPtr TsvRendererCreate(string outputbase);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessHOcrRendererCreate")]
        IntPtr HOcrRendererCreate(string outputbase);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessHOcrRendererCreate2")]
        IntPtr HOcrRendererCreate2(string outputbase, int font_info);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessPDFRendererCreate")]
        IntPtr PDFRendererCreate(string outputbase, IntPtr datadir, int textonly);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessUnlvRendererCreate")]
        IntPtr UnlvRendererCreate(string outputbase);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessBoxTextRendererCreate")]
        IntPtr BoxTextRendererCreate(string outputbase);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessLSTMBoxRendererCreate")]
        IntPtr LSTMBoxRendererCreate(string outputbase);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessWordStrBoxRendererCreate")]
        IntPtr WordStrBoxRendererCreate(string outputbase);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessDeleteResultRenderer")]
        void DeleteResultRenderer(HandleRef renderer);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultRendererInsert")]
        void ResultRendererInsert(HandleRef renderer, HandleRef next);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultRendererNext")]
        IntPtr ResultRendererNext(HandleRef renderer);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultRendererBeginDocument")]
        int ResultRendererBeginDocument(HandleRef renderer, IntPtr titlePtr);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultRendererAddImage")]
        int ResultRendererAddImage(HandleRef renderer, HandleRef api);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultRendererEndDocument")]
        int ResultRendererEndDocument(HandleRef renderer);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultRendererExtention")]
        IntPtr ResultRendererExtention(HandleRef renderer);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultRendererTitle")]
        IntPtr ResultRendererTitle(HandleRef renderer);

        [RuntimeDllImport(Constants.TesseractDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TessResultRendererImageNum")]
        int ResultRendererImageNum(HandleRef renderer);
        #endregion
    }

    internal static class TessApi
    {
        #region Fields
        private static ITessApiSignatures native;
        #endregion

        #region Properties
        public static ITessApiSignatures Native
        {
            get
            {
                if (native == null)
                    Initialize();
                return native;
            }
        }
        #endregion

        #region BaseApiGetVersion
        public static string BaseApiGetVersion()
        {
            var versionHandle = Native.GetVersion();
            if (versionHandle == IntPtr.Zero) return null;
            var result = MarshalHelper.PtrToString(versionHandle, Encoding.UTF8);
            return result;
        }
        #endregion

        #region BaseApiGetHOcrText
        public static string BaseApiGetHOcrText(HandleRef handle, int pageNum)
        {
            var txtHandle = Native.BaseApiGetHOcrTextInternal(handle, pageNum);
            if (txtHandle == IntPtr.Zero) return null;
            var result = MarshalHelper.PtrToString(txtHandle, Encoding.UTF8);
            Native.DeleteText(txtHandle);
            return result;
        }
        #endregion

        #region BaseApiGetAltoText
        public static string BaseApiGetAltoText(HandleRef handle, int pageNum)
        {
            var txtHandle = Native.BaseApiGetAltoTextInternal(handle, pageNum);
            if (txtHandle == IntPtr.Zero) return null;
            var result = MarshalHelper.PtrToString(txtHandle, Encoding.UTF8);
            Native.DeleteText(txtHandle);
            return result;
        }
        #endregion

        #region BaseApiGetTsvText
        public static string BaseApiGetTsvText(HandleRef handle, int pageNum)
        {
            var txtHandle = Native.BaseApiGetTsvTextInternal(handle, pageNum);
            if (txtHandle == IntPtr.Zero) return null;
            var result = MarshalHelper.PtrToString(txtHandle, Encoding.UTF8);
            Native.DeleteText(txtHandle);
            return result;
        }
        #endregion

        #region BaseApiGetBoxText
        public static string BaseApiGetBoxText(HandleRef handle, int pageNum)
        {
            var txtHandle = Native.BaseApiGetBoxTextInternal(handle, pageNum);
            if (txtHandle == IntPtr.Zero) return null;
            var result = MarshalHelper.PtrToString(txtHandle, Encoding.UTF8);
            Native.DeleteText(txtHandle);
            return result;
        }
        #endregion

        #region BaseApiGetLSTMBoxText
        public static string BaseApiGetLSTMBoxText(HandleRef handle, int pageNum)
        {
            var txtHandle = Native.BaseApiGetLstmBoxTextInternal(handle, pageNum);
            if (txtHandle == IntPtr.Zero) return null;
            var result = MarshalHelper.PtrToString(txtHandle, Encoding.UTF8);
            Native.DeleteText(txtHandle);
            return result;
        }
        #endregion

        #region BaseApiGetWordStrBoxText
        public static string BaseApiGetWordStrBoxText(HandleRef handle, int pageNum)
        {
            var txtHandle = Native.BaseApiGetWordStrBoxTextInternal(handle, pageNum);
            if (txtHandle == IntPtr.Zero) return null;
            var result = MarshalHelper.PtrToString(txtHandle, Encoding.UTF8);
            Native.DeleteText(txtHandle);
            return result;
        }
        #endregion

        #region BaseApiGetUNLVText
        public static string BaseApiGetUnlvText(HandleRef handle)
        {
            var txtHandle = Native.BaseApiGetUnlvTextInternal(handle);
            if (txtHandle == IntPtr.Zero) return null;
            var result = MarshalHelper.PtrToString(txtHandle, Encoding.UTF8);
            Native.DeleteText(txtHandle);
            return result;
        }
        #endregion

        #region BaseApiGetStringVariable
        public static string BaseApiGetStringVariable(HandleRef handle, string name)
        {
            var resultHandle = Native.BaseApiGetStringVariableInternal(handle, name);
            return resultHandle != IntPtr.Zero ? MarshalHelper.PtrToString(resultHandle, Encoding.UTF8) : null;
        }
        #endregion

        #region BaseApiGetUTF8Text
        public static string BaseApiGetUTF8Text(HandleRef handle)
        {
            var txtHandle = Native.BaseApiGetUTF8TextInternal(handle);
            if (txtHandle == IntPtr.Zero) return null;
            var result = MarshalHelper.PtrToString(txtHandle, Encoding.UTF8);
            Native.DeleteText(txtHandle);
            return result;
        }
        #endregion

        #region BaseApiInit
        public static int BaseApiInit(HandleRef handle, string datapath, string language, int mode,
            IEnumerable<string> configFiles, IDictionary<string, object> initialValues, bool setOnlyNonDebugParams)
        {
            Guard.Require("handle", handle.Handle != IntPtr.Zero, "Handle for BaseApi, created through BaseApiCreate is required.");
            Guard.RequireNotNullOrEmpty("language", language);
            Guard.RequireNotNull("configFiles", configFiles);
            Guard.RequireNotNull("initialValues", initialValues);

            var configFilesArray = new List<string>(configFiles).ToArray();
            var varNames = new string[initialValues.Count];
            var varValues = new string[initialValues.Count];
            var i = 0;

            foreach (var pair in initialValues)
            {
                Guard.Require("initialValues", !string.IsNullOrEmpty(pair.Key), "Variable must have a name.");

                Guard.Require("initialValues", pair.Value != null, "Variable '{0}': The type '{1}' is not supported.", pair.Key, pair.Value?.GetType());
                varNames[i] = pair.Key;

                if (TessConvert.TryToString(pair.Value, out var varValue))
                    varValues[i] = varValue;
                else
                    throw new ArgumentException(
                        $"Variable '{pair.Key}': The type '{pair.Value?.GetType()}' is not supported.",
                        nameof(initialValues));
                i++;
            }

            return Native.BaseApiInit(handle, datapath, language, mode,
                configFilesArray, configFilesArray.Length,
                varNames, varValues, new UIntPtr((uint)varNames.Length), setOnlyNonDebugParams);
        }
        #endregion

        #region BaseApiSetDebugVariable
        public static int BaseApiSetDebugVariable(HandleRef handle, string name, string value)
        {
            var valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = MarshalHelper.StringToPtr(value, Encoding.UTF8);
                return Native.BaseApiSetDebugVariable(handle, name, valuePtr);
            }
            finally
            {
                if (valuePtr != IntPtr.Zero) Marshal.FreeHGlobal(valuePtr);
            }
        }
        #endregion

        #region BaseApiSetVariable
        public static int BaseApiSetVariable(HandleRef handle, string name, string value)
        {
            var valuePtr = IntPtr.Zero;

            try
            {
                valuePtr = MarshalHelper.StringToPtr(value, Encoding.UTF8);
                return Native.BaseApiSetVariable(handle, name, valuePtr);
            }
            finally
            {
                if (valuePtr != IntPtr.Zero) Marshal.FreeHGlobal(valuePtr);
            }
        }
        #endregion

        #region Initialize
        public static void Initialize()
        {
            if (native != null) return;
            LeptonicaApi.Initialize();
            Helper.SetPath();
            native = InteropRuntimeImplementer.CreateInstance<ITessApiSignatures>();
        }
        #endregion

        #region ResultIteratorWordRecognitionLanguage
        public static string ResultIteratorWordRecognitionLanguage(HandleRef handle)
        {
            // per docs (ltrresultiterator.h:118 as of 4897796 in github:tesseract-ocr/tesseract)
            // this return value should *NOT* be deleted.
            var txtHandle =
                Native.ResultIteratorWordRecognitionLanguageInternal(handle);

            return txtHandle != IntPtr.Zero
                ? MarshalHelper.PtrToString(txtHandle, Encoding.UTF8)
                : null;
        }
        #endregion

        #region ResultIteratorGetUTF8Text
        public static string ResultIteratorGetUTF8Text(HandleRef handle, PageIteratorLevel level)
        {
            var txtHandle = Native.ResultIteratorGetUTF8TextInternal(handle, level);
            if (txtHandle != IntPtr.Zero)
            {
                var result = MarshalHelper.PtrToString(txtHandle, Encoding.UTF8);
                Native.DeleteText(txtHandle);
                return result;
            }

            return null;
        }
        #endregion

        #region ChoiceIteratorGetUTF8Text
        /// <summary>
        ///     Returns the null terminated UTF-8 encoded text string for the current choice
        /// </summary>
        /// <remarks>
        ///     NOTE: Unlike LTRResultIterator::GetUTF8Text, the return points to an
        ///     internal structure and should NOT be delete[]ed to free after use.
        /// </remarks>
        /// <param name="choiceIteratorHandle"></param>
        /// <returns>string</returns>
        internal static string ChoiceIteratorGetUTF8Text(HandleRef choiceIteratorHandle)
        {
            Guard.Require("choiceIteratorHandle", choiceIteratorHandle.Handle != IntPtr.Zero,
                "ChoiceIterator Handle cannot be a null IntPtr and is required");
            var txtChoiceHandle = Native.ChoiceIteratorGetUTF8TextInternal(choiceIteratorHandle);
            return MarshalHelper.PtrToString(txtChoiceHandle, Encoding.UTF8);
        }
        #endregion
    }
}