using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiSOI
{
    public partial class Form1 : Form
    {

        ImageEdit imageEdit = new ImageEdit();
        Bitmap BitMainPic;
        private int[,] mas;
        public Form1()
        {
            InitializeComponent();

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {


           openFileDialog.Filter = "All file (*.*)|*.*|Image bmp (*.bmp)|*.bmp|Image jpg(*.jpg)|*.jpg";
            openFileDialog.FileName = "";
            openFileDialog.InitialDirectory = "C:\\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               
                pictureBox2.Image = new Bitmap(this.openFileDialog.FileName);
                BitMainPic = (Bitmap)pictureBox2.Image;

            }   
        }
        private void binarize(Bitmap bittt, ref int[,] massss, ToolStripProgressBar progress)
        {
            massss = new int[bittt.Width, bittt.Height];
            progress.Minimum = 0;
            progress.Maximum = bittt.Height;
            for (int i = 0; i < bittt.Height; i++)
            {
                for (int j = 0; j < bittt.Width; j++)
                {
                    if (bittt.GetPixel(j, i).R > 200 || bittt.GetPixel(j, i).B > 200 || bittt.GetPixel(j, i).G > 200)
                    {
                        bittt.SetPixel(j, i, Color.White);
                        massss[j, i] = 0;
                    }
                    else
                    {
                        bittt.SetPixel(j, i, Color.Black);
                        massss[j, i] = 1;
                    }
                    /*      if (j == (int)(bittt.Height / 6))
                           {
                               bittt.SetPixel(j, i, Color.Teal);
                           }*/
                }
                if (progress.Value < bittt.Height)
                {
                    progress.Value++;
                }
            }
            progress.Value = 0;
        }

        private void бинаризацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            binarize(BitMainPic, ref mas, ProgressBar1);
            pictureBox3.Image = BitMainPic;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить картинку как ...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter =
                "Bitmap File(*.bmp)|*.bmp|" +
                "GIF File(*.gif)|*.gif|" +
                "JPEG File(*.jpg)|*.jpg|" +
                "TIF File(*.tif)|*.tif|" +
                "PNG File(*.png)|*.png";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {

                // Get the user-selected file name
                string fileName = savedialog.FileName;
                // Get the extension
                string strFilExtn =
                    fileName.Remove(0, fileName.Length - 3);
                // Save file
                switch (strFilExtn)
                {
                    case "bmp":
                        BitMainPic.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        BitMainPic.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        BitMainPic.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        BitMainPic.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        BitMainPic.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }

        public void ClearImage()
        {
            BitMainPic = new Bitmap(1, 1);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void фильтрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (groupBox3.Visible == true)
            {
                groupBox3.Visible = false;
                groupBox3.Update();
            }
            else
            {
                groupBox3.Visible = true;
                groupBox3.Update();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imageEdit.SetGrayscale(BitMainPic, ref mas, ProgressBar1);
            pictureBox3.Image = BitMainPic;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imageEdit.SetInvert(BitMainPic, ref mas, ProgressBar1);
            pictureBox3.Image = BitMainPic;
        }

    }
}
