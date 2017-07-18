using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNES.Core
{
    public enum ColorSpace
    {
        RGB = 0,
        BGR = 1,
        RGBA = 2,
    }

    public class PixelBuffer
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Channel { get; private set; }
        public ColorSpace ColorSpace { get; set; }
        public byte[] Data { get; set; }

        public PixelBuffer(int w, int h, int ch = 3, ColorSpace color = ColorSpace.BGR)
        {
            Width = w;
            Height = h;
            Channel = ch;
            ColorSpace = color;

            Data = new byte[w * h * ch];
        }
    }

    public class PPU
    {
        #region Values

        PPUMemory Memory { get; set; }
        Console Console { get; set; }

        /// <summary>
        /// 0-340
        /// </summary>
        int Cycle;

        /// <summary>
        /// 0-261, 0-239=visible, 240=post, 241-260=vblank, 261=pre
        /// </summary>
        int ScanLine;

        /// <summary>
        /// frame counter
        /// </summary>
        ulong Frame;

        byte[] paletteData = new byte[32];
        byte[] nameTableData = new byte[2048];
        byte[] oamData = new byte[256];
        PixelBuffer front;
        PixelBuffer back;

        // PPU registers
        UInt16 v;
        UInt16 t;
        byte x;
        byte w;
        byte f;

        byte register;

        // NMI flags
        bool nmiOccurred;
        bool nmiOutput;
        bool nmiPrevious;
        bool nmiDelay;

        // background temporary variables
        bool nameTableByte;
        bool attributeTableByte;
        bool lowTileByte;
        bool highTileByte;
        ulong tileData;

        // sprite temporary variables
        int spriteCount;
        uint[] spritePatterns = new uint[8];
        byte[] spritePositions = new byte[8];
        byte[] spritePriorities = new byte[8];
        byte[] spriteIndexes = new byte[8];

        // $2000 PPUCTRL
        /// <summary>
        /// 0: $2000; 1: $2400; 2: $2800; 3: $2C00
        /// </summary>
        bool flagNameTable;

        /// <summary>
        /// 0: add 1; 1: add 32
        /// </summary>
        bool flagIncrement;

        /// <summary>
        /// 0: $0000; 1: $1000; ignored in 8x16 mode
        /// </summary>
        bool flagSpriteTable;

        /// <summary>
        /// 0: $0000; 1: $1000
        /// </summary>
        bool flagBackgroundTable;

        /// <summary>
        /// 0: 8x8; 1: 8x16
        /// </summary>
        bool flagSpriteSize;

        /// <summary>
        /// 0: read EXT; 1: write EXT
        /// </summary>
        bool flagMasterSlave;

        // $2001 PPUMASK
        /// <summary>
        /// 0: color; 1: grayscale
        /// </summary>
        byte flagGrayscale;

        /// <summary>
        /// 0: hide; 1: show
        /// </summary>
        byte flagShowLeftBackground;

        /// <summary>
        /// 0: hide; 1: show
        /// </summary>
        byte flagShowLeftSprites;

        /// <summary>
        /// 0: hide; 1: show
        /// </summary>
        byte flagShowBackground;

        /// <summary>
        /// 0: hide; 1: show
        /// </summary>
        byte flagShowSprites;

        /// <summary>
        /// 0: normal; 1: emphasized
        /// </summary>
        byte flagRedTint;

        /// <summary>
        /// 0: normal; 1: emphasized
        /// </summary>
        byte flagGreenTint;

        /// <summary>
        /// 0: normal; 1: emphasized
        /// </summary>
        byte flagBlueTint;

        // $2002 PPUSTATUS
        byte flagSpriteZeroHit;
        byte flagSpriteOverflow;

        // $2003 OAMADDR
        byte oamAddress;

        // $2007 PPUDATA
        byte bufferedData; // for buffered reads

        #endregion Values

        public PPU(Console console)
        {
            Console = console;
            Memory = new PPUMemory(console);

            front = new PixelBuffer(256, 240);
            back = new PixelBuffer(256, 240);

            Reset();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            Cycle = 340;
            ScanLine = 240;
            Frame = 0;

        }

        private byte readPalette(ushort addr)
        {
            if (addr >= 16 && addr % 4 == 0)
            {
                addr -= 16;
            }

            return paletteData[addr];
        }

        private void writePalette(ushort addr, byte value)
        {
            if (addr >= 16 && addr % 4 == 0)
            {
                addr -= 16;

            }
            paletteData[addr] = value;
        }

        private byte readRegister(ushort addr)
        {
            switch (addr)
            {
                case 0x2002:
                    return readStatus();
                case 0x2004:
                    return readOAMData();

                case 0x2007:
                    return readData();

            }
            return 0;
        }

        private void writeRegister(ushort addr, byte value)
        {
            register = value;

            switch (addr)
            {
                case 0x2000:
                    writeControl(value);
                    break;
                case 0x2001:
                    writeMask(value);
                    break;
                case 0x2003:
                    writeOAMAddress(value);
                    break;
                case 0x2004:
                    writeOAMData(value);
                    break;
                case 0x2005:
                    writeScroll(value);
                    break;
                case 0x2006:
                    writeAddress(value);
                    break;
                case 0x2007:
                    writeData(value);
                    break;
                case 0x4014:
                    writeDMA(value);
                    break;

            }
        }

        private void writeControl(byte value)
        {
            flagNameTable = (value >> 0) & 3;
            flagIncrement = (value >> 2) & 1;
            flagSpriteTable = (value >> 3) & 1;
            flagBackgroundTable = (value >> 4) & 1;
            flagSpriteSize = (value >> 5) & 1;
            flagMasterSlave = (value >> 6) & 1;
            nmiOutput = (value >> 7) & 1 == 1;
            nmiChange();
            // t: ....BA.. ........ = d: ......BA
            t = (ushort)((t & 0xF3FF) | (((ushort)(value) & 0x03) << 10));
        }

        private void writeMask(byte value)
        {
            flagGrayscale = (value >> 0) & 1;
            flagShowLeftBackground = (value >> 1) & 1;
            flagShowLeftSprites = (value >> 2) & 1;
            flagShowBackground = (value >> 3) & 1;
            flagShowSprites = (value >> 4) & 1;
            flagRedTint = (value >> 5) & 1;
            flagGreenTint = (value >> 6) & 1;
            flagBlueTint = (value >> 7) & 1;
        }

        private byte readStatus()
        {
            var result = register & 0x1F;

            result |= flagSpriteOverflow << 5;

            result |= flagSpriteZeroHit << 6;

            if (nmiOccurred)
            {
                result |= 1 << 7;

            }
            nmiOccurred = false;

            nmiChange();
            // w:                   = 0
            w = 0;

            return (byte)result;
        }
    }
}
