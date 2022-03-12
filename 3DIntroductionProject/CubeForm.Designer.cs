namespace _3DIntroductionProject
{
    partial class CubeForm
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
            this.DrawButton = new System.Windows.Forms.Button();
            this.TimerButton = new System.Windows.Forms.Button();
            this.ForwardButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.LeftButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.TurnLeftButton = new System.Windows.Forms.Button();
            this.TurnRightButton = new System.Windows.Forms.Button();
            this.ClockTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsDisplayPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphicsDisplayPictureBox
            // 
            this.GraphicsDisplayPictureBox.Location = new System.Drawing.Point(12, 12);
            this.GraphicsDisplayPictureBox.Name = "GraphicsDisplayPictureBox";
            this.GraphicsDisplayPictureBox.Size = new System.Drawing.Size(677, 451);
            this.GraphicsDisplayPictureBox.TabIndex = 0;
            this.GraphicsDisplayPictureBox.TabStop = false;
            this.GraphicsDisplayPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphicsDisplayPictureBox_Paint);
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(726, 354);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(105, 23);
            this.DrawButton.TabIndex = 1;
            this.DrawButton.Text = "Draw Graphics";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // TimerButton
            // 
            this.TimerButton.Location = new System.Drawing.Point(695, 179);
            this.TimerButton.Name = "TimerButton";
            this.TimerButton.Size = new System.Drawing.Size(75, 23);
            this.TimerButton.TabIndex = 6;
            this.TimerButton.Text = "Start Motion";
            this.TimerButton.UseVisualStyleBackColor = true;
            this.TimerButton.Click += new System.EventHandler(this.TimerButton_Click);
            // 
            // ForwardButton
            // 
            this.ForwardButton.Location = new System.Drawing.Point(739, 26);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(75, 23);
            this.ForwardButton.TabIndex = 7;
            this.ForwardButton.Text = "Forward";
            this.ForwardButton.UseVisualStyleBackColor = true;
            this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(739, 118);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 8;
            this.BackButton.Text = "Backward";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // LeftButton
            // 
            this.LeftButton.Location = new System.Drawing.Point(704, 75);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(56, 23);
            this.LeftButton.TabIndex = 9;
            this.LeftButton.Text = "Left";
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // RightButton
            // 
            this.RightButton.Location = new System.Drawing.Point(783, 75);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(48, 23);
            this.RightButton.TabIndex = 10;
            this.RightButton.Text = "Right";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Location = new System.Drawing.Point(800, 165);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(51, 23);
            this.UpButton.TabIndex = 11;
            this.UpButton.Text = "Up";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Location = new System.Drawing.Point(800, 194);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(51, 23);
            this.DownButton.TabIndex = 12;
            this.DownButton.Text = "Down";
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // TurnLeftButton
            // 
            this.TurnLeftButton.Location = new System.Drawing.Point(695, 239);
            this.TurnLeftButton.Name = "TurnLeftButton";
            this.TurnLeftButton.Size = new System.Drawing.Size(75, 23);
            this.TurnLeftButton.TabIndex = 13;
            this.TurnLeftButton.Text = "Turn Left";
            this.TurnLeftButton.UseVisualStyleBackColor = true;
            this.TurnLeftButton.Click += new System.EventHandler(this.TurnLeftButton_Click);
            // 
            // TurnRightButton
            // 
            this.TurnRightButton.Location = new System.Drawing.Point(783, 239);
            this.TurnRightButton.Name = "TurnRightButton";
            this.TurnRightButton.Size = new System.Drawing.Size(75, 23);
            this.TurnRightButton.TabIndex = 14;
            this.TurnRightButton.Text = "Turn Right";
            this.TurnRightButton.UseVisualStyleBackColor = true;
            this.TurnRightButton.Click += new System.EventHandler(this.TurnRightButton_Click);
            // 
            // ClockTimer
            // 
            this.ClockTimer.Interval = 10;
            this.ClockTimer.Tick += new System.EventHandler(this.Clock_Tick);
            // 
            // CubeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 475);
            this.Controls.Add(this.TurnRightButton);
            this.Controls.Add(this.TurnLeftButton);
            this.Controls.Add(this.DownButton);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.RightButton);
            this.Controls.Add(this.LeftButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.ForwardButton);
            this.Controls.Add(this.TimerButton);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.GraphicsDisplayPictureBox);
            this.Name = "CubeForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsDisplayPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GraphicsDisplayPictureBox;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Button TimerButton;
        private System.Windows.Forms.Button ForwardButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button TurnLeftButton;
        private System.Windows.Forms.Button TurnRightButton;
        private System.Windows.Forms.Timer ClockTimer;
    }
}

