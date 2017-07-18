using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNES.Core
{
    static public class CPUConstants
    {
        public static readonly UInt32 Frequency = 1789773;

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

        public static readonly byte[] InstructionModes = new byte[]
        {
            6, 7, 6, 7, 11, 11, 11, 11, 6, 5, 4, 5, 1, 1, 1, 1,
            10, 9, 6, 9, 12, 12, 12, 12, 6, 3, 6, 3, 2, 2, 2, 2,
            1, 7, 6, 7, 11, 11, 11, 11, 6, 5, 4, 5, 1, 1, 1, 1,
            10, 9, 6, 9, 12, 12, 12, 12, 6, 3, 6, 3, 2, 2, 2, 2,
            6, 7, 6, 7, 11, 11, 11, 11, 6, 5, 4, 5, 1, 1, 1, 1,
            10, 9, 6, 9, 12, 12, 12, 12, 6, 3, 6, 3, 2, 2, 2, 2,
            6, 7, 6, 7, 11, 11, 11, 11, 6, 5, 4, 5, 8, 1, 1, 1,
            10, 9, 6, 9, 12, 12, 12, 12, 6, 3, 6, 3, 2, 2, 2, 2,
            5, 7, 5, 7, 11, 11, 11, 11, 6, 5, 6, 5, 1, 1, 1, 1,
            10, 9, 6, 9, 12, 12, 13, 13, 6, 3, 6, 3, 2, 2, 3, 3,
            5, 7, 5, 7, 11, 11, 11, 11, 6, 5, 6, 5, 1, 1, 1, 1,
            10, 9, 6, 9, 12, 12, 13, 13, 6, 3, 6, 3, 2, 2, 3, 3,
            5, 7, 5, 7, 11, 11, 11, 11, 6, 5, 6, 5, 1, 1, 1, 1,
            10, 9, 6, 9, 12, 12, 12, 12, 6, 3, 6, 3, 2, 2, 2, 2,
            5, 7, 5, 7, 11, 11, 11, 11, 6, 5, 6, 5, 1, 1, 1, 1,
            10, 9, 6, 9, 12, 12, 12, 12, 6, 3, 6, 3, 2, 2, 2, 2
        };

        public static readonly byte[] InstructionSizes = new byte[]
        {
            1, 2, 0, 0, 2, 2, 2, 0, 1, 2, 1, 0, 3, 3, 3, 0,
            2, 2, 0, 0, 2, 2, 2, 0, 1, 3, 1, 0, 3, 3, 3, 0,
            3, 2, 0, 0, 2, 2, 2, 0, 1, 2, 1, 0, 3, 3, 3, 0,
            2, 2, 0, 0, 2, 2, 2, 0, 1, 3, 1, 0, 3, 3, 3, 0,
            1, 2, 0, 0, 2, 2, 2, 0, 1, 2, 1, 0, 3, 3, 3, 0,
            2, 2, 0, 0, 2, 2, 2, 0, 1, 3, 1, 0, 3, 3, 3, 0,
            1, 2, 0, 0, 2, 2, 2, 0, 1, 2, 1, 0, 3, 3, 3, 0,
            2, 2, 0, 0, 2, 2, 2, 0, 1, 3, 1, 0, 3, 3, 3, 0,
            2, 2, 0, 0, 2, 2, 2, 0, 1, 0, 1, 0, 3, 3, 3, 0,
            2, 2, 0, 0, 2, 2, 2, 0, 1, 3, 1, 0, 0, 3, 0, 0,
            2, 2, 2, 0, 2, 2, 2, 0, 1, 2, 1, 0, 3, 3, 3, 0,
            2, 2, 0, 0, 2, 2, 2, 0, 1, 3, 1, 0, 3, 3, 3, 0,
            2, 2, 0, 0, 2, 2, 2, 0, 1, 2, 1, 0, 3, 3, 3, 0,
            2, 2, 0, 0, 2, 2, 2, 0, 1, 3, 1, 0, 3, 3, 3, 0,
            2, 2, 0, 0, 2, 2, 2, 0, 1, 2, 1, 0, 3, 3, 3, 0,
            2, 2, 0, 0, 2, 2, 2, 0, 1, 3, 1, 0, 3, 3, 3, 0
        };

        public static readonly byte[] InstructionCycles = new byte[]
        {
            7, 6, 2, 8, 3, 3, 5, 5, 3, 2, 2, 2, 4, 4, 6, 6,
            2, 5, 2, 8, 4, 4, 6, 6, 2, 4, 2, 7, 4, 4, 7, 7,
            6, 6, 2, 8, 3, 3, 5, 5, 4, 2, 2, 2, 4, 4, 6, 6,
            2, 5, 2, 8, 4, 4, 6, 6, 2, 4, 2, 7, 4, 4, 7, 7,
            6, 6, 2, 8, 3, 3, 5, 5, 3, 2, 2, 2, 3, 4, 6, 6,
            2, 5, 2, 8, 4, 4, 6, 6, 2, 4, 2, 7, 4, 4, 7, 7,
            6, 6, 2, 8, 3, 3, 5, 5, 4, 2, 2, 2, 5, 4, 6, 6,
            2, 5, 2, 8, 4, 4, 6, 6, 2, 4, 2, 7, 4, 4, 7, 7,
            2, 6, 2, 6, 3, 3, 3, 3, 2, 2, 2, 2, 4, 4, 4, 4,
            2, 6, 2, 6, 4, 4, 4, 4, 2, 5, 2, 5, 5, 5, 5, 5,
            2, 6, 2, 6, 3, 3, 3, 3, 2, 2, 2, 2, 4, 4, 4, 4,
            2, 5, 2, 5, 4, 4, 4, 4, 2, 4, 2, 4, 4, 4, 4, 4,
            2, 6, 2, 8, 3, 3, 5, 5, 2, 2, 2, 2, 4, 4, 6, 6,
            2, 5, 2, 8, 4, 4, 6, 6, 2, 4, 2, 7, 4, 4, 7, 7,
            2, 6, 2, 8, 3, 3, 5, 5, 2, 2, 2, 2, 4, 4, 6, 6,
            2, 5, 2, 8, 4, 4, 6, 6, 2, 4, 2, 7, 4, 4, 7, 7
        };

        public static readonly byte[] instructionPageCycles = new byte[]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0,
        };

        public static readonly string[] InstructionNames = new string[]
        {
            "BRK", "ORA", "KIL", "SLO", "NOP", "ORA", "ASL", "SLO",
            "PHP", "ORA", "ASL", "ANC", "NOP", "ORA", "ASL", "SLO",
            "BPL", "ORA", "KIL", "SLO", "NOP", "ORA", "ASL", "SLO",
            "CLC", "ORA", "NOP", "SLO", "NOP", "ORA", "ASL", "SLO",
            "JSR", "AND", "KIL", "RLA", "BIT", "AND", "ROL", "RLA",
            "PLP", "AND", "ROL", "ANC", "BIT", "AND", "ROL", "RLA",
            "BMI", "AND", "KIL", "RLA", "NOP", "AND", "ROL", "RLA",
            "SEC", "AND", "NOP", "RLA", "NOP", "AND", "ROL", "RLA",
            "RTI", "EOR", "KIL", "SRE", "NOP", "EOR", "LSR", "SRE",
            "PHA", "EOR", "LSR", "ALR", "JMP", "EOR", "LSR", "SRE",
            "BVC", "EOR", "KIL", "SRE", "NOP", "EOR", "LSR", "SRE",
            "CLI", "EOR", "NOP", "SRE", "NOP", "EOR", "LSR", "SRE",
            "RTS", "ADC", "KIL", "RRA", "NOP", "ADC", "ROR", "RRA",
            "PLA", "ADC", "ROR", "ARR", "JMP", "ADC", "ROR", "RRA",
            "BVS", "ADC", "KIL", "RRA", "NOP", "ADC", "ROR", "RRA",
            "SEI", "ADC", "NOP", "RRA", "NOP", "ADC", "ROR", "RRA",
            "NOP", "STA", "NOP", "SAX", "STY", "STA", "STX", "SAX",
            "DEY", "NOP", "TXA", "XAA", "STY", "STA", "STX", "SAX",
            "BCC", "STA", "KIL", "AHX", "STY", "STA", "STX", "SAX",
            "TYA", "STA", "TXS", "TAS", "SHY", "STA", "SHX", "AHX",
            "LDY", "LDA", "LDX", "LAX", "LDY", "LDA", "LDX", "LAX",
            "TAY", "LDA", "TAX", "LAX", "LDY", "LDA", "LDX", "LAX",
            "BCS", "LDA", "KIL", "LAX", "LDY", "LDA", "LDX", "LAX",
            "CLV", "LDA", "TSX", "LAS", "LDY", "LDA", "LDX", "LAX",
            "CPY", "CMP", "NOP", "DCP", "CPY", "CMP", "DEC", "DCP",
            "INY", "CMP", "DEX", "AXS", "CPY", "CMP", "DEC", "DCP",
            "BNE", "CMP", "KIL", "DCP", "NOP", "CMP", "DEC", "DCP",
            "CLD", "CMP", "NOP", "DCP", "NOP", "CMP", "DEC", "DCP",
            "CPX", "SBC", "NOP", "ISC", "CPX", "SBC", "INC", "ISC",
            "INX", "SBC", "NOP", "SBC", "CPX", "SBC", "INC", "ISC",
            "BEQ", "SBC", "KIL", "ISC", "NOP", "SBC", "INC", "ISC",
            "SED", "SBC", "NOP", "ISC", "NOP", "SBC", "INC", "ISC"
        };
    }

    public struct StepInfo
    {
        UInt16 address;
        UInt16 PC;
        byte mode;
    }

    public class CPU
    {
        public IMemory Memory { get; set; }          // memory interface
        public UInt64 Cycles { get; set; } = 0;      // number of cycles
        public UInt64 PC { get; set; } = 0;          // program counter

        public byte SP { get; set; } = 0; // stack pointer
        public byte A { get; set; } = 0; // accumulator
        public byte X { get; set; } = 0; // x register
        public byte Y { get; set; } = 0; // y register
        public byte C { get; set; } = 0; // carry flag
        public byte Z { get; set; } = 0; // zero flag
        public byte I { get; set; } = 0; // interrupt disable flag
        public byte D { get; set; } = 0; // decimal mode flag
        public byte B { get; set; } = 0; // break command flag
        public byte U { get; set; } = 0; // unused flag
        public byte V { get; set; } = 0; // overflow flag
        public byte N { get; set; } = 0; // negative flag

        public byte Interrupt { get; set; } = 0;  // interrupt type to perform
        public int Stall { get; set; } = 0; // number of cycles to stall

        public delegate void StepFunc(StepInfo stepInfo);
        public StepFunc[] Table { get; set; } = new StepFunc[256];

        public CPU(Console console)
        {
            Memory = new CPUMemory(console);
            CreateTable();
            Reset();
        }

        public void CreateTable()
        {
 //           c.table = [256]func(*stepInfo){
 //               c.brk, c.ora, c.kil, c.slo, c.nop, c.ora, c.asl, c.slo,
    //	c.php, c.ora, c.asl, c.anc, c.nop, c.ora, c.asl, c.slo,
    //	c.bpl, c.ora, c.kil, c.slo, c.nop, c.ora, c.asl, c.slo,
    //	c.clc, c.ora, c.nop, c.slo, c.nop, c.ora, c.asl, c.slo,
    //	c.jsr, c.and, c.kil, c.rla, c.bit, c.and, c.rol, c.rla,
    //	c.plp, c.and, c.rol, c.anc, c.bit, c.and, c.rol, c.rla,
    //	c.bmi, c.and, c.kil, c.rla, c.nop, c.and, c.rol, c.rla,
    //	c.sec, c.and, c.nop, c.rla, c.nop, c.and, c.rol, c.rla,
    //	c.rti, c.eor, c.kil, c.sre, c.nop, c.eor, c.lsr, c.sre,
    //	c.pha, c.eor, c.lsr, c.alr, c.jmp, c.eor, c.lsr, c.sre,
    //	c.bvc, c.eor, c.kil, c.sre, c.nop, c.eor, c.lsr, c.sre,
    //	c.cli, c.eor, c.nop, c.sre, c.nop, c.eor, c.lsr, c.sre,
    //	c.rts, c.adc, c.kil, c.rra, c.nop, c.adc, c.ror, c.rra,
    //	c.pla, c.adc, c.ror, c.arr, c.jmp, c.adc, c.ror, c.rra,
    //	c.bvs, c.adc, c.kil, c.rra, c.nop, c.adc, c.ror, c.rra,
    //	c.sei, c.adc, c.nop, c.rra, c.nop, c.adc, c.ror, c.rra,
    //	c.nop, c.sta, c.nop, c.sax, c.sty, c.sta, c.stx, c.sax,
    //	c.dey, c.nop, c.txa, c.xaa, c.sty, c.sta, c.stx, c.sax,
    //	c.bcc, c.sta, c.kil, c.ahx, c.sty, c.sta, c.stx, c.sax,
    //	c.tya, c.sta, c.txs, c.tas, c.shy, c.sta, c.shx, c.ahx,
    //	c.ldy, c.lda, c.ldx, c.lax, c.ldy, c.lda, c.ldx, c.lax,
    //	c.tay, c.lda, c.tax, c.lax, c.ldy, c.lda, c.ldx, c.lax,
    //	c.bcs, c.lda, c.kil, c.lax, c.ldy, c.lda, c.ldx, c.lax,
    //	c.clv, c.lda, c.tsx, c.las, c.ldy, c.lda, c.ldx, c.lax,
    //	c.cpy, c.cmp, c.nop, c.dcp, c.cpy, c.cmp, c.dec, c.dcp,
    //	c.iny, c.cmp, c.dex, c.axs, c.cpy, c.cmp, c.dec, c.dcp,
    //	c.bne, c.cmp, c.kil, c.dcp, c.nop, c.cmp, c.dec, c.dcp,
    //	c.cld, c.cmp, c.nop, c.dcp, c.nop, c.cmp, c.dec, c.dcp,
    //	c.cpx, c.sbc, c.nop, c.isc, c.cpx, c.sbc, c.inc, c.isc,
    //	c.inx, c.sbc, c.nop, c.sbc, c.cpx, c.sbc, c.inc, c.isc,
    //	c.beq, c.sbc, c.kil, c.isc, c.nop, c.sbc, c.inc, c.isc,
    //	c.sed, c.sbc, c.nop, c.isc, c.nop, c.sbc, c.inc, c.isc,
    //}
        }

        public void Save() { }
        public void Load() { }
        public void Reset() { }

        public void PrintInstruction()
        {
            // opcode := cpu.Read(cpu.PC)
            // bytes := instructionSizes[opcode]
            // name := instructionNames[opcode]
            // w0 := fmt.Sprintf("%02X", cpu.Read(cpu.PC+0))
            // w1 := fmt.Sprintf("%02X", cpu.Read(cpu.PC+1))
            // w2 := fmt.Sprintf("%02X", cpu.Read(cpu.PC+2))
            // if bytes < 2 {
            //     w1 = "  "
            // }
            // if bytes < 3 {
            //     w2 = "  "
            // }
            // fmt.Printf(
            // "%4X  %s %s %s  %s %28s"+
            //     "A:%02X X:%02X Y:%02X P:%02X SP:%02X CYC:%3d\n",
            // cpu.PC, w0, w1, w2, name, "",
            // cpu.A, cpu.X, cpu.Y, cpu.Flags(), cpu.SP, (cpu.Cycles*3)%341)
        }

        // public static bool PagesDiffer(UInt16 a, UInt16 b)
        // {
        //     return a & 0xFF00 != b & 0xFF00;
        // }



    }
}
