using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DIntroductionProject
{
    public partial class CubeForm : Form
    {
        private int _screenWidth, _screenHeight;

        private RenderUtility RenderU;
        private ObjectManager objectManager;

        int frameCount = 0;
        double timeSpent = 0;

        public CubeForm()
        {
            InitializeComponent();
            _screenHeight = GraphicsDisplayPictureBox.Height;
            _screenWidth = GraphicsDisplayPictureBox.Width;
            

            objectManager = new ObjectManager();

            Camera camera = new Camera(new Vector3(1, 0, 0), new Vector3(0, 0, 1), new Vector3(-5, 0, 0), 70, new Vector3(0, 0, 0), new Point(_screenWidth, _screenHeight));
            camera.Name = "Camera";
            camera.Renderable = false;
            objectManager.registerObject(camera);

            objectManager.registerObject(ObjectBuilder.createCube(2));

            objectManager.GetObject(0).Scale = new Vector3(0.5, 0.5, 0.5);
            RenderU = new RenderUtility(camera, objectManager, GraphicsDisplayPictureBox);
        }
        double angle = 0;
        private void Clock_Tick(object sender, EventArgs e)
        {
            long currTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            /*Vector3 pos = camera.Basis.Position;

            camera.Basis.Forward = camera.Basis.Forward.rotateZ(0.02);
            camera.Basis.Right = camera.Basis.Right.rotateZ(0.02);

            pos.X = Math.Cos(cameraAngle) * 5;
            pos.Y = Math.Sin(cameraAngle) * 5;

            cameraAngle += 0.02;*/

            Object obj = objectManager.GetObject(1);

            obj.Rotation.Z += 0.01;
            angle += 0.05;

            obj.Translation.Z = Math.Sin(angle) / 2;

            obj.updateTransformedVertices();
            RenderU.refreshBitmap();
            currTime -= DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            FPSLabel.Text = ((int)(-1000 / (double)currTime)).ToString() + " FPS";
            timeSpent += -1000 / (double)currTime;
            frameCount++;
            AverageFPSLabel.Text = ((int)(timeSpent / frameCount)).ToString() + " FPS AVG";
            //GraphicsDisplayPictureBox.Refresh();
        }

        private void TimerButton_Click(object sender, EventArgs e)
        {

            if (ClockTimer.Enabled) ClockTimer.Stop();
            else ClockTimer.Start();
        }
    }
}