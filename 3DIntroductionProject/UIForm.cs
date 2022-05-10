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

        #region Fields
        private readonly int _screenWidth, _screenHeight;

        private readonly RenderUtility RenderU;
        private readonly ObjectManager objectManager;   
        private readonly Monitoring FPSMonitor;

        #endregion

        #region Constructor
        public UIForm()
        {
            FPSMonitor = new Monitoring();
            // Generated Code
            InitializeComponent();

            // Strores values for the PictureBox's Height and Width
            _screenHeight = GraphicsDisplayPictureBox.Height;
            _screenWidth = GraphicsDisplayPictureBox.Width;

            ObjectDataGridView.Columns.Add("objName", "Objects");

            // Camera Setup
            Camera viewportCam = ObjectBuilder.CreateDefaultCamera(new Point(_screenWidth, _screenHeight));
            objectManager = new ObjectManager(ObjectDataGridView, viewportCam);

            objectManager.registerObject(ObjectBuilder.CreateCylinder(2, 3, 3));

            RenderU = new RenderUtility(objectManager, GraphicsDisplayPictureBox);
        }
        #endregion

        /// <summary>
        /// Loop which refreshes the window 40 to 90 times per second
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clock_Tick(object sender, EventArgs e)
        {
            Object obj = objectManager.GetObject(0);
            obj.Rotation.Z += 0.01;

            objectManager.UpdateTransforms();
            RenderU.Refresh();

            FPSMonitor.FramePassed();
            if(FPSMonitor.FramesElapsed == 0)
            {
                AverageFPSLabel.Text = ((int)FPSMonitor.FPS).ToString() + " FPS";
            }
        }
        private void UIForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'W')
            {
                objectManager.GetObject("Cylinder").Translation.MultiplyScalar(4d);
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
                double.TryParse(TranslationXTextBox.Text, out double x);
                objectManager.SelectedObject.Translation.X = x;
            }
            if (TranslationYTextBox.Text.Length > 0)
            {
                double.TryParse(TranslationYTextBox.Text, out double y);
                objectManager.SelectedObject.Translation.Y = y;
            }
            if (TranslationZTextBox.Text.Length > 0)
            {
                double.TryParse(TranslationZTextBox.Text, out double z);
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