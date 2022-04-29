﻿using System;
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

            // Object initializations. These are the objects the program starts with.
            objectManager.registerObject(ObjectBuilder.CreateCylinder(2, 3, 32));
            objectManager.registerObject(ObjectBuilder.CreateCylinder(2, 3, 16));
            objectManager.GetObject(1).Translation = new Vector3(0, 1, 1);
            //objectManager.registerObject(ObjectBuilder.CreatePlane(5));

            RenderU = new RenderUtility(objectManager, GraphicsDisplayPictureBox, FPSMonitor);
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

            obj.Rotation.Z += 0.02;
            //angle += 0.01;

            //obj.Translation.Z = Math.Sin(angle) / 2;

            objectManager.UpdateTransforms();
            FPSMonitor.Log(0);

            RenderU.RefreshBitmap();

            FPSMonitor.FramePassed();
            AverageFPSLabel.Text = FPSMonitor.FPS.ToString() + " FPS";

            TimeLogLabel.Text = "";
            
            for(int i = 0; i < 5; i++)
            {
                TimeLogLabel.Text += FPSMonitor.TimeSpentComparisons[i] + " , ";
            }
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