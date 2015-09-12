using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MiSOI
{
    class ImageEdit
    {
        Bitmap BitMainPic;
        public void SetGrayscale(Bitmap bittt, ref int[,] massss, ToolStripProgressBar progress)
        {
            massss = new int[bittt.Width, bittt.Height];
            progress.Minimum = 0;
            progress.Maximum = bittt.Height;
            Color c;
            for (int i = 0; i < bittt.Width; i++)
            {
                for (int j = 0; j < bittt.Height; j++)
                {
                    c = bittt.GetPixel(i, j);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);

                    bittt.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            BitMainPic = (Bitmap)bittt.Clone();
        }

        public void SetInvert(Bitmap bittt, ref int[,] massss, ToolStripProgressBar progress)
        {
            massss = new int[bittt.Width, bittt.Height];
            progress.Minimum = 0;
            progress.Maximum = bittt.Height;
            Color c;
            for (int i = 0; i < bittt.Width; i++)
            {
                for (int j = 0; j < bittt.Height; j++)
                {
                    c = bittt.GetPixel(i, j);
                    bittt.SetPixel(i, j, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            BitMainPic = (Bitmap)bittt.Clone();
        }
    }
}
