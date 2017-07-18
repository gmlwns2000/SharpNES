using System;

namespace SharpNES.Core
{
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

}
