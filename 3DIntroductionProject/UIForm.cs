using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _3DIntroductionProject
{
    public partial class UIForm : Form
    {
        private int _screenWidth, _screenHeight;

        private RenderUtility RenderU;
        private ObjectManager objectManager;   

        private int FPS = 0;

        private double angle = 0;
        private long time = 0;

        public UIForm()
        {
            // Generated Code
            InitializeComponent();

            // Strores values for the PictureBox's Height and Width
            _screenHeight = GraphicsDisplayPictureBox.Height;
            _screenWidth = GraphicsDisplayPictureBox.Width;

            ObjectDataGridView.Columns.Add("objName", "Objects");

            Camera viewportCam = ObjectBuilder.createDefaultCamera(new Point(_screenWidth, _screenHeight));
            objectManager = new ObjectManager(ObjectDataGridView, viewportCam);

            // Object initializations. These are the objects the program starts with.
            objectManager.registerObject(ObjectBuilder.createCube(2));

            RenderU = new RenderUtility(objectManager, GraphicsDisplayPictureBox);
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            time = nanoTime();

            Object obj = objectManager.GetObject(0);

            obj.Rotation.Z += 0.02;
            //angle += 0.01;

            //obj.Translation.Z = Math.Sin(angle) / 2;

            objectManager.UpdateTransforms();
            RenderU.refreshBitmap();

            time = nanoTime() - time;
            FPS = (int)(1000000000L * 1 / (double)time);
            AverageFPSLabel.Text = FPS.ToString() + " FPS";
        }

        private static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }

        private void UIForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'W')
            {
                objectManager.GetObject("Cylinder").Translation.multiplyScalar(4d);
            }
        }

        private void ObjectDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            objectManager.SelectedObject = objectManager.GetObject(e.RowIndex);
        }

        private void ObjectDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            objectManager.GetObject(e.RowIndex).Name = e.ToString();
        }

        private void TranslationTextBox_TextChanged(object sender, EventArgs e)
        {
            if (TranslationXTextBox.Text.Length > 0)
            {
                double x = objectManager.SelectedObject.Translation.X;
                double.TryParse(TranslationXTextBox.Text, out x);
                objectManager.SelectedObject.Translation.X = x;
            }
            if (TranslationYTextBox.Text.Length > 0)
            {
                double y = objectManager.SelectedObject.Translation.Y;
                double.TryParse(TranslationYTextBox.Text, out y);
                objectManager.SelectedObject.Translation.Y = y;
            }
            if (TranslationZTextBox.Text.Length > 0)
            {
                double z = objectManager.SelectedObject.Translation.Z;
                double.TryParse(TranslationZTextBox.Text, out z);
                objectManager.SelectedObject.Translation.Z = z;
            }
        }

        private void TimerButton_Click(object sender, EventArgs e)
        {
            if (ClockTimer.Enabled) ClockTimer.Stop();
            else ClockTimer.Start();
        }
    }
}