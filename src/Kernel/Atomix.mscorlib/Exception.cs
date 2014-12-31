﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atomix.CompilerExt;
using Atomix.CompilerExt.Attributes;

namespace Atomix.mscorlib
{
    public static class ExceptionImpl
    {
        /// <summary>
        /// Compiler Inbuilt Exception pointer
        /// </summary>
        [Label("Exception")]
        public static string Exception;

        [Plug("System_Void__System_Exception__cctor__")]
        public static unsafe void ctor()
        {
            return;
        }

        [Plug("System_Void__System_Exception__ctor_System_String_")]
        public static unsafe void ctor2(byte* aAddress, uint aMessage)
        {
            var xMessage = (uint*)(aAddress + 0x10);
            xMessage[0] = aMessage;
        }

        [Plug("System_String_System_Exception_get_Message__")]
        public static unsafe uint GetMessage(byte* aAddress)
        {
            var xMessage = (uint*)(aAddress + 0x10);
            return xMessage[0];
        }
    }
}
