using System;

namespace SharpNES.Core
{
    public enum MirrorModes
    {
        MirrorHorizontal = 0,
        MirrorVertical = 1,
        MirrorSingle0 = 2,
        MirrorSingle1 = 3,
        MirrorFour = 4,
    }

    public interface IMemory
    {
        byte Read(UInt16 address);
        byte Write(UInt16 address);
    }

    // CPU Memory Map
    public class CPUMemory : IMemory
    {
        public CPUMemory(Console console)
        {
            _console = console;
        }

        public byte Read(ushort address)
        {
            throw new NotImplementedException();
        }

        public byte Write(ushort address)
        {
            throw new NotImplementedException();
        }

        private Console _console;
    }

    public class PPUMemory : IMemory
    {
        private Console _console;

        public PPUMemory(Console console)
        {
            _console = console;
        }

        public byte Read(ushort address)
        {
            throw new NotImplementedException();
        }

        public byte Write(ushort address)
        {
            throw new NotImplementedException();
        }
    }
}
