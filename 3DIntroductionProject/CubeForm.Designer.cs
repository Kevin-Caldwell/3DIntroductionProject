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
            this.TimerButton = new System.Windows.Forms.Button();
            this.ClockTimer = new System.Windows.Forms.Timer(this.components);
            this.ObjectListView = new System.Windows.Forms.ListView();
            this.FPSLabel = new System.Windows.Forms.Label();
            this.AverageFPSLabel = new System.Windows.Forms.Label();
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
            // ClockTimer
            // 
            this.ClockTimer.Interval = 1;
            this.ClockTimer.Tick += new System.EventHandler(this.Clock_Tick);
            // 
            // ObjectListView
            // 
            this.ObjectListView.HideSelection = false;
            this.ObjectListView.Location = new System.Drawing.Point(890, 44);
            this.ObjectListView.Name = "ObjectListView";
            this.ObjectListView.Size = new System.Drawing.Size(74, 97);
            this.ObjectListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ObjectListView.TabIndex = 15;
            this.ObjectListView.UseCompatibleStateImageBehavior = false;
            this.ObjectListView.View = System.Windows.Forms.View.Details;
            // 
            // FPSLabel
            // 
            this.FPSLabel.AutoSize = true;
            this.FPSLabel.Location = new System.Drawing.Point(765, 450);
            this.FPSLabel.Name = "FPSLabel";
            this.FPSLabel.Size = new System.Drawing.Size(36, 13);
            this.FPSLabel.TabIndex = 16;
            this.FPSLabel.Text = "0 FPS";
            // 
            // AverageFPSLabel
            // 
            this.AverageFPSLabel.AutoSize = true;
            this.AverageFPSLabel.Location = new System.Drawing.Point(850, 450);
            this.AverageFPSLabel.Name = "AverageFPSLabel";
            this.AverageFPSLabel.Size = new System.Drawing.Size(61, 13);
            this.AverageFPSLabel.TabIndex = 17;
            this.AverageFPSLabel.Text = "0 FPS AVG";
            // 
            // CubeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 475);
            this.Controls.Add(this.AverageFPSLabel);
            this.Controls.Add(this.FPSLabel);
            this.Controls.Add(this.ObjectListView);
            this.Controls.Add(this.TimerButton);
            this.Controls.Add(this.GraphicsDisplayPictureBox);
            this.Name = "CubeForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsDisplayPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GraphicsDisplayPictureBox;
        private System.Windows.Forms.Button TimerButton;
        private System.Windows.Forms.Timer ClockTimer;
        private System.Windows.Forms.ListView ObjectListView;
        private System.Windows.Forms.Label FPSLabel;
        private System.Windows.Forms.Label AverageFPSLabel;
    }
}

