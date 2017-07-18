using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SharpNES.Core
{
    public abstract class IPixelPresenter
    {
        /// <summary>
        /// Write Pixels As BGRA Format
        /// </summary>
        public abstract void Present(PixelBuffer buffer);
    }

    public class BitmapPixelPresenter : IPixelPresenter
    {
        public WriteableBitmap Bitmap { get; set; }

        public BitmapPixelPresenter()
        {

        }

        public override void Present(PixelBuffer buffer)
        {
            throw new NotImplementedException();
        }
    }
}
