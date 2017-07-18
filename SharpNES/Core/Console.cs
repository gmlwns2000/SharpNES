
namespace SharpNES.Core
{
    public class Console
    {
        public Console(string path)
        {
            NesCPU = new CPU(this);
        }

        public CPU NesCPU { get; set; }
    }


}
