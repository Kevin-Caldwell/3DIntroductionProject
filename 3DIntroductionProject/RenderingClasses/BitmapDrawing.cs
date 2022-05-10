using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DIntroductionProject
{
    internal class BitmapDrawing
    {
        private readonly int _screenWidth, _screenHeight;

        private Bitmap RenderBitmap;

        private PictureBox RenderedPictureBox;
        private Graphics DrawingSurface;

        public Graphics Graphics { get { return DrawingSurface; } }

        public BitmapDrawing(PictureBox pictureBox)
        {
            _screenHeight = pictureBox.Height;
            _screenWidth = pictureBox.Width;

            RenderBitmap = new Bitmap(_screenWidth, _screenHeight);
            DrawingSurface = Graphics.FromImage(RenderBitmap);
            RenderedPictureBox = pictureBox;
            RenderedPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
        }

        public void RefreshBitmap()
        {
            RenderedPictureBox.Refresh();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(RenderBitmap, 0, 0);
        }
    }
}
