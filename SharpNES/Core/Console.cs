
namespace SharpNES.Core
{
    public class Console
    {
        public Console(string path)
        {
        }

        public CPU NesCPU { get; set; } = new CPU();
    }


}
