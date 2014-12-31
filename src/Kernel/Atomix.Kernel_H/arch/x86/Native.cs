﻿/* Copyright (C) Atomix Development, Inc - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Aman Priyadarshi <aman.eureka@gmail.com>, December 2014
 * 
 * Native.cs
 *      x86-arch Native Instructions
 *      
 *      History:
 *          20-12-14    File Created    Aman Priyadarshi
 */

using System;
using System.Collections.Generic;

using Atomix.CompilerExt;
using Atomix.CompilerExt.Attributes;

using Atomix.Assembler;
using Atomix.Assembler.x86;
using Core = Atomix.Assembler.AssemblyHelper;

namespace Atomix.Kernel_H.arch.x86
{
    public static class Native
    {
        /// <summary>
        /// Clear Interrupts
        /// </summary>
        [Assembly(0x0)]
        public static void Cli()
        {
            Core.AssemblerCode.Add(new Cli());
        }

        /// <summary>
        /// Enable Interrupts
        /// </summary>
        [Assembly(0x0)]
        public static void Sti()
        {
            Core.AssemblerCode.Add(new Sti());
        }

        /// <summary>
        /// Halt The Processor
        /// </summary>
        [Assembly(0x0)]
        public static void Hlt()
        {
            Core.AssemblerCode.Add(new Literal("hlt"));
        }

        /// <summary>
        /// End of kernel offset
        /// </summary>
        /// <returns></returns>
        [Assembly(0x0)]
        public static uint EndOfKernel()
        {
            //Just put Compiler_End location into return value
            Core.AssemblerCode.Add(new Mov { DestinationReg = Registers.EBP, DestinationDisplacement = 0x8, DestinationIndirect = true, SourceRef = "Compiler_End" });

            return 0; //just for c# error
        }
    }
}
