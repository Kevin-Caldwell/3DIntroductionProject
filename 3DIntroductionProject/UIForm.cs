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

        private Stopwatch timer;

        private int frameCount = 0;
        private int FPS = 0;
        private long PrevFrameTime = 0;

        public UIForm()
        {
            InitializeComponent();
            _screenHeight = GraphicsDisplayPictureBox.Height;
            _screenWidth = GraphicsDisplayPictureBox.Width;

            ObjectDataGridView.Columns.Add("objName", "Objects");

            objectManager = new ObjectManager(ObjectDataGridView);

            Camera camera = new Camera(new Vector3(1, 0, 0), new Vector3(0, 0, 1), new Vector3(-5, 0, 0), 70, new Vector3(0, 0, 0), new Point(_screenWidth, _screenHeight));
            camera.Name = "Camera";
            camera.Renderable = false;
            objectManager.registerObject(camera);

            objectManager.registerObject(ObjectBuilder.createCube(2));

            objectManager.GetObject(0).Scale = new Vector3(0.5, 0.5, 0.5);
            RenderU = new RenderUtility(camera, objectManager, GraphicsDisplayPictureBox);
            ClockTimer.Start();
            timer = new Stopwatch();
            PrevFrameTime = timer.ElapsedMilliseconds;
        }
        double angle = 0;
        private void Clock_Tick(object sender, EventArgs e)
        {
            if (!timer.IsRunning)
            {
                timer.Start();
            }
            /*Vector3 pos = camera.Basis.Position;

            camera.Basis.Forward = camera.Basis.Forward.rotateZ(0.02);
            camera.Basis.Right = camera.Basis.Right.rotateZ(0.02);

            pos.X = Math.Cos(cameraAngle) * 5;
            pos.Y = Math.Sin(cameraAngle) * 5;

            cameraAngle += 0.02;*/

            /*            Object obj = objectManager.GetObject(1);

                        obj.Rotation.Z += 0.02;
                        angle += 0.05;

                        obj.Translation.Z = Math.Sin(angle) / 2;*/

            //obj.updateTransformedVertices();
            objectManager.UpdateTransforms();
            RenderU.refreshBitmap();
            //Thread.Sleep(6);  // 64 FPS
            //Thread.Sleep(12); // 33 FPS
            //Thread.Sleep(24); // 24 FPS
            frameCount++;

            FPSLabel.Text = timer.ElapsedMilliseconds.ToString();
            
            PrevFrameTime = timer.ElapsedMilliseconds;
/*          TimerIntervalLabel.Text = ClockTimer.Interval.ToString() + " Clock Interval";
            const int TARGET_FPS = 20;
            const int ANALYSIS_INTERVAL = 1000;*/

            if(timer.ElapsedMilliseconds > 200)
            {
                FPS = (int)(1000 * frameCount/ (double)timer.ElapsedMilliseconds);
                AverageFPSLabel.Text = FPS.ToString() + " FPS AVG";
                
                frameCount = 0;
                timer.Restart();
            }
        }

        private void UIForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void UIForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'W')
            {
                objectManager.GetObject("Cube").Translation.multiplyScalar(4.4);
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

        private void ObjectDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }

        private void TranslationXTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TranslationYTextBox_TextChanged(object sender, EventArgs e)
        {
            double y = objectManager.SelectedObject.Translation.Y;
            double.TryParse(TranslationYTextBox.Text, out y);
            objectManager.SelectedObject.Translation.Y = y;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TimerButton_Click(object sender, EventArgs e)
        {
            if (ClockTimer.Enabled) ClockTimer.Stop();
            else ClockTimer.Start();
        }
    }
}