namespace _3DIntroductionProject
{
    partial class UIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GraphicsDisplayPictureBox = new System.Windows.Forms.PictureBox();
            this.ClockTimer = new System.Windows.Forms.Timer(this.components);
            this.AverageFPSLabel = new System.Windows.Forms.Label();
            this.ObjectDataGridView = new System.Windows.Forms.DataGridView();
            this.TranslationXTextBox = new System.Windows.Forms.TextBox();
            this.RotationXTextBox = new System.Windows.Forms.TextBox();
            this.ScaleXTextBox = new System.Windows.Forms.TextBox();
            this.ScaleYTextBox = new System.Windows.Forms.TextBox();
            this.RotationYTextBox = new System.Windows.Forms.TextBox();
            this.TranslationYTextBox = new System.Windows.Forms.TextBox();
            this.ScaleZTextBox = new System.Windows.Forms.TextBox();
            this.RotationZTextBox = new System.Windows.Forms.TextBox();
            this.TranslationZTextBox = new System.Windows.Forms.TextBox();
            this.TranslationGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TimeLogLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FaceColorDialog = new System.Windows.Forms.ColorDialog();
            this.ChangeColorButton = new System.Windows.Forms.Button();
            this.ShapeSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.ObjectSpawnButton = new System.Windows.Forms.Button();
            this.cubeFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsDisplayPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectDataGridView)).BeginInit();
            this.TranslationGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cubeFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphicsDisplayPictureBox
            // 
            this.GraphicsDisplayPictureBox.Location = new System.Drawing.Point(12, 12);
            this.GraphicsDisplayPictureBox.Name = "GraphicsDisplayPictureBox";
            this.GraphicsDisplayPictureBox.Size = new System.Drawing.Size(1016, 660);
            this.GraphicsDisplayPictureBox.TabIndex = 0;
            this.GraphicsDisplayPictureBox.TabStop = false;
            // 
            // ClockTimer
            // 
            this.ClockTimer.Enabled = true;
            this.ClockTimer.Interval = 1;
            this.ClockTimer.Tick += new System.EventHandler(this.Clock_Tick);
            // 
            // AverageFPSLabel
            // 
            this.AverageFPSLabel.AutoSize = true;
            this.AverageFPSLabel.Location = new System.Drawing.Point(1281, 659);
            this.AverageFPSLabel.Name = "AverageFPSLabel";
            this.AverageFPSLabel.Size = new System.Drawing.Size(61, 13);
            this.AverageFPSLabel.TabIndex = 17;
            this.AverageFPSLabel.Text = "0 FPS AVG";
            // 
            // ObjectDataGridView
            // 
            this.ObjectDataGridView.AllowUserToAddRows = false;
            this.ObjectDataGridView.AllowUserToDeleteRows = false;
            this.ObjectDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ObjectDataGridView.Location = new System.Drawing.Point(1034, 12);
            this.ObjectDataGridView.Name = "ObjectDataGridView";
            this.ObjectDataGridView.Size = new System.Drawing.Size(240, 150);
            this.ObjectDataGridView.TabIndex = 18;
            this.ObjectDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ObjectDataGridView_CellDoubleClick);
            this.ObjectDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ObjectDataGridView_CellValueChanged);
            // 
            // TranslationXTextBox
            // 
            this.TranslationXTextBox.Location = new System.Drawing.Point(6, 33);
            this.TranslationXTextBox.Name = "TranslationXTextBox";
            this.TranslationXTextBox.Size = new System.Drawing.Size(78, 20);
            this.TranslationXTextBox.TabIndex = 19;
            this.TranslationXTextBox.Text = "0";
            this.TranslationXTextBox.TextChanged += new System.EventHandler(this.TranslationTextBox_TextChanged);
            // 
            // RotationXTextBox
            // 
            this.RotationXTextBox.Location = new System.Drawing.Point(6, 33);
            this.RotationXTextBox.Name = "RotationXTextBox";
            this.RotationXTextBox.Size = new System.Drawing.Size(78, 20);
            this.RotationXTextBox.TabIndex = 20;
            this.RotationXTextBox.Text = "0";
            this.RotationXTextBox.TextChanged += new System.EventHandler(this.Rotation_Update);
            // 
            // ScaleXTextBox
            // 
            this.ScaleXTextBox.Location = new System.Drawing.Point(6, 33);
            this.ScaleXTextBox.Name = "ScaleXTextBox";
            this.ScaleXTextBox.Size = new System.Drawing.Size(78, 20);
            this.ScaleXTextBox.TabIndex = 21;
            this.ScaleXTextBox.Text = "1";
            this.ScaleXTextBox.TextChanged += new System.EventHandler(this.Scale_Update);
            // 
            // ScaleYTextBox
            // 
            this.ScaleYTextBox.Location = new System.Drawing.Point(6, 59);
            this.ScaleYTextBox.Name = "ScaleYTextBox";
            this.ScaleYTextBox.Size = new System.Drawing.Size(78, 20);
            this.ScaleYTextBox.TabIndex = 24;
            this.ScaleYTextBox.Text = "1";
            this.ScaleYTextBox.TextChanged += new System.EventHandler(this.Scale_Update);
            // 
            // RotationYTextBox
            // 
            this.RotationYTextBox.Location = new System.Drawing.Point(6, 59);
            this.RotationYTextBox.Name = "RotationYTextBox";
            this.RotationYTextBox.Size = new System.Drawing.Size(78, 20);
            this.RotationYTextBox.TabIndex = 23;
            this.RotationYTextBox.Text = "0";
            this.RotationYTextBox.TextChanged += new System.EventHandler(this.Rotation_Update);
            // 
            // TranslationYTextBox
            // 
            this.TranslationYTextBox.Location = new System.Drawing.Point(6, 59);
            this.TranslationYTextBox.Name = "TranslationYTextBox";
            this.TranslationYTextBox.Size = new System.Drawing.Size(78, 20);
            this.TranslationYTextBox.TabIndex = 22;
            this.TranslationYTextBox.Text = "0";
            this.TranslationYTextBox.TextChanged += new System.EventHandler(this.TranslationTextBox_TextChanged);
            // 
            // ScaleZTextBox
            // 
            this.ScaleZTextBox.Location = new System.Drawing.Point(6, 85);
            this.ScaleZTextBox.Name = "ScaleZTextBox";
            this.ScaleZTextBox.Size = new System.Drawing.Size(78, 20);
            this.ScaleZTextBox.TabIndex = 27;
            this.ScaleZTextBox.Text = "1";
            this.ScaleZTextBox.TextChanged += new System.EventHandler(this.Scale_Update);
            // 
            // RotationZTextBox
            // 
            this.RotationZTextBox.Location = new System.Drawing.Point(6, 85);
            this.RotationZTextBox.Name = "RotationZTextBox";
            this.RotationZTextBox.Size = new System.Drawing.Size(78, 20);
            this.RotationZTextBox.TabIndex = 26;
            this.RotationZTextBox.Text = "0";
            this.RotationZTextBox.TextChanged += new System.EventHandler(this.Rotation_Update);
            // 
            // TranslationZTextBox
            // 
            this.TranslationZTextBox.Location = new System.Drawing.Point(6, 85);
            this.TranslationZTextBox.Name = "TranslationZTextBox";
            this.TranslationZTextBox.Size = new System.Drawing.Size(78, 20);
            this.TranslationZTextBox.TabIndex = 25;
            this.TranslationZTextBox.Text = "0";
            this.TranslationZTextBox.TextChanged += new System.EventHandler(this.TranslationTextBox_TextChanged);
            // 
            // TranslationGroupBox
            // 
            this.TranslationGroupBox.Controls.Add(this.TranslationXTextBox);
            this.TranslationGroupBox.Controls.Add(this.TranslationYTextBox);
            this.TranslationGroupBox.Controls.Add(this.TranslationZTextBox);
            this.TranslationGroupBox.Location = new System.Drawing.Point(6, 19);
            this.TranslationGroupBox.Name = "TranslationGroupBox";
            this.TranslationGroupBox.Size = new System.Drawing.Size(93, 113);
            this.TranslationGroupBox.TabIndex = 28;
            this.TranslationGroupBox.TabStop = false;
            this.TranslationGroupBox.Text = "Location";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RotationXTextBox);
            this.groupBox1.Controls.Add(this.RotationYTextBox);
            this.groupBox1.Controls.Add(this.RotationZTextBox);
            this.groupBox1.Location = new System.Drawing.Point(105, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(93, 113);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rotation";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ScaleXTextBox);
            this.groupBox2.Controls.Add(this.ScaleYTextBox);
            this.groupBox2.Controls.Add(this.ScaleZTextBox);
            this.groupBox2.Location = new System.Drawing.Point(204, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(93, 113);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scale";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TranslationGroupBox);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(1034, 229);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 148);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transformations";
            // 
            // TimeLogLabel
            // 
            this.TimeLogLabel.AutoSize = true;
            this.TimeLogLabel.Location = new System.Drawing.Point(1268, 646);
            this.TimeLogLabel.Name = "TimeLogLabel";
            this.TimeLogLabel.Size = new System.Drawing.Size(74, 13);
            this.TimeLogLabel.TabIndex = 32;
            this.TimeLogLabel.Text = "TimeLogLabel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1251, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Render Mode:";
            // 
            // ChangeColorButton
            // 
            this.ChangeColorButton.Location = new System.Drawing.Point(1127, 395);
            this.ChangeColorButton.Name = "ChangeColorButton";
            this.ChangeColorButton.Size = new System.Drawing.Size(134, 23);
            this.ChangeColorButton.TabIndex = 35;
            this.ChangeColorButton.Text = "ChangeColorButton";
            this.ChangeColorButton.UseVisualStyleBackColor = true;
            this.ChangeColorButton.Click += new System.EventHandler(this.ChangeColorButton_Click);
            // 
            // ShapeSelectionComboBox
            // 
            this.ShapeSelectionComboBox.FormattingEnabled = true;
            this.ShapeSelectionComboBox.Items.AddRange(new object[] {
            "Cube",
            "Cylinder",
            "Plane",
            "Light"});
            this.ShapeSelectionComboBox.Location = new System.Drawing.Point(1088, 491);
            this.ShapeSelectionComboBox.Name = "ShapeSelectionComboBox";
            this.ShapeSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.ShapeSelectionComboBox.TabIndex = 36;
            this.ShapeSelectionComboBox.Text = "Pick an object to create";
            // 
            // ObjectSpawnButton
            // 
            this.ObjectSpawnButton.Location = new System.Drawing.Point(1110, 527);
            this.ObjectSpawnButton.Name = "ObjectSpawnButton";
            this.ObjectSpawnButton.Size = new System.Drawing.Size(99, 23);
            this.ObjectSpawnButton.TabIndex = 37;
            this.ObjectSpawnButton.Text = "Make Object";
            this.ObjectSpawnButton.UseVisualStyleBackColor = true;
            this.ObjectSpawnButton.Click += new System.EventHandler(this.ObjectSpawnButton_Click);
            // 
            // cubeFormBindingSource
            // 
            this.cubeFormBindingSource.DataSource = typeof(_3DIntroductionProject.UIForm);
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 684);
            this.Controls.Add(this.ObjectSpawnButton);
            this.Controls.Add(this.ShapeSelectionComboBox);
            this.Controls.Add(this.ChangeColorButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TimeLogLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ObjectDataGridView);
            this.Controls.Add(this.AverageFPSLabel);
            this.Controls.Add(this.GraphicsDisplayPictureBox);
            this.KeyPreview = true;
            this.Name = "UIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3D Visualizer";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UIForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsDisplayPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectDataGridView)).EndInit();
            this.TranslationGroupBox.ResumeLayout(false);
            this.TranslationGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cubeFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GraphicsDisplayPictureBox;
        private System.Windows.Forms.Label AverageFPSLabel;
        private System.Windows.Forms.BindingSource cubeFormBindingSource;
        private System.Windows.Forms.DataGridView ObjectDataGridView;
        private System.Windows.Forms.TextBox TranslationXTextBox;
        private System.Windows.Forms.TextBox RotationXTextBox;
        private System.Windows.Forms.TextBox ScaleXTextBox;
        private System.Windows.Forms.TextBox ScaleYTextBox;
        private System.Windows.Forms.TextBox RotationYTextBox;
        private System.Windows.Forms.TextBox TranslationYTextBox;
        private System.Windows.Forms.TextBox ScaleZTextBox;
        private System.Windows.Forms.TextBox RotationZTextBox;
        private System.Windows.Forms.TextBox TranslationZTextBox;
        private System.Windows.Forms.GroupBox TranslationGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label TimeLogLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer ClockTimer;
        private System.Windows.Forms.ColorDialog FaceColorDialog;
        private System.Windows.Forms.Button ChangeColorButton;
        private System.Windows.Forms.ComboBox ShapeSelectionComboBox;
        private System.Windows.Forms.Button ObjectSpawnButton;
    }
}

