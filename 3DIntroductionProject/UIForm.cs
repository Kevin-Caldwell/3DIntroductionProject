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
        private double i = 0;

        #endregion

        #region Constructor
        public UIForm()
        {
            FPSMonitor = new Monitoring();
            InitializeComponent();

            // Strores values for the PictureBox's Height and Width
            _screenHeight = GraphicsDisplayPictureBox.Height;
            _screenWidth = GraphicsDisplayPictureBox.Width;

            ObjectDataGridView.Columns.Add("objName", "Objects");

            // Camera Setup
            Camera viewportCam = ObjectBuilder.CreateDefaultCamera(new Point(_screenWidth, _screenHeight));
            objectManager = new ObjectManager(ObjectDataGridView, viewportCam);

            objectManager.RegisterObject(ObjectBuilder.CreateCube(2));

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
            Object obj = objectManager.SelectedObject;
            obj.Rotation.Z += 0.01;
            //objectManager.RegisterObject(ObjectBuilder.CreateCube(i));

            objectManager.UpdateTransforms();
            RenderU.Refresh();
            FPSMonitor.FramePassed();
            if(FPSMonitor.FramesElapsed == 0)
            {
                //objectManager.RegisterObject(ObjectBuilder.CreateCube(i));
                AverageFPSLabel.Text = ((int)FPSMonitor.FPS).ToString() + " FPS";
                i += 0.1;
            }
        }
        private void UIForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w')
            {
                objectManager.GetObject(0).Translation.X -= 0.1d;
            }
            if (e.KeyChar == 's')
            {
                objectManager.GetObject(0).Translation.X += 0.1d;
            }
            if (e.KeyChar == 'a')
            {
                objectManager.GetObject(0).Translation.Y -= 0.1d;
            }
            if (e.KeyChar == 'd')
            {
                objectManager.GetObject(0).Translation.Y += 0.1d;
            }
            if (e.KeyChar == 'q')
            {
                objectManager.GetObject(0).Translation.Z -= 0.1d;
            }
            if (e.KeyChar == 'e')
            {
                objectManager.GetObject(0).Translation.Z += 0.1d;
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

        private void ChangeColorButton_Click(object sender, EventArgs e)
        {
            FaceColorDialog.ShowDialog();
            Settings.FILL_COLOR = FaceColorDialog.Color;
        }

        private void ObjectSpawnButton_Click(object sender, EventArgs e)
        {
            switch (ShapeSelectionComboBox.SelectedIndex)
            {
                case 0:
                    objectManager.RegisterObject(ObjectBuilder.CreateCube(1));
                    break;
                case 1:
                    objectManager.RegisterObject(ObjectBuilder.CreateCylinder(1, 2, 32));
                    break;
                case 2:
                    objectManager.RegisterObject(ObjectBuilder.CreatePlane(1));
                    break;
                default:
                    break;
            }
        }

        private void Rotation_Update(object sender, EventArgs e)
        {
            if (RotationXTextBox.Text.Length > 0)
            {
                double.TryParse(RotationXTextBox.Text, out double x);
                objectManager.SelectedObject.Rotation.X = x * Math.PI / 180;
            }
            if (RotationYTextBox.Text.Length > 0)
            {
                double.TryParse(RotationYTextBox.Text, out double y);
                objectManager.SelectedObject.Rotation.Y = y * Math.PI / 180;
            }
            if (RotationZTextBox.Text.Length > 0)
            {
                double.TryParse(RotationZTextBox.Text, out double z);
                objectManager.SelectedObject.Rotation.Z = z * Math.PI / 180;
            }
        }

        private void Scale_Update(object sender, EventArgs e)
        {
            if (ScaleXTextBox.Text.Length > 0)
            {
                double.TryParse(ScaleXTextBox.Text, out double x);
                objectManager.SelectedObject.Scale.X = x;
            }
            if (ScaleYTextBox.Text.Length > 0)
            {
                double.TryParse(ScaleYTextBox.Text, out double y);
                objectManager.SelectedObject.Scale.Y = y;
            }
            if (ScaleZTextBox.Text.Length > 0)
            {
                double.TryParse(ScaleZTextBox.Text, out double z);
                objectManager.SelectedObject.Scale.Z = z;
            }
        }

        private void TimerButton_Click(object sender, EventArgs e)
        {

        }
    }
}