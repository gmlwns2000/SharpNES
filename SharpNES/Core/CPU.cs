using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNES.Core
{
    public static class CPU
    {
        public const UInt32 Frequency = 1789773;
        
        public enum InterruptType
        {
            None,
            NMI,
            IRQ
        }

        public enum AddressingMode
        {
            Absolute,
            AbsoluteX,
            AbsoluteY,
            Accumulator,
            Immediate,
            Implied,
            IndexedIndirect,
            Indirect,
            IndirectIndexed,
            Relative,
            ZeroPage,
            ZeroPageX,
            ZeroPageY
        }
        
    }
}
