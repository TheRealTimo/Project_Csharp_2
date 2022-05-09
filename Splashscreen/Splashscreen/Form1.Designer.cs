
namespace Splashscreen
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SSLoadingBar = new System.Windows.Forms.ProgressBar();
            this.loadTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // SSLoadingBar
            // 
            this.SSLoadingBar.Location = new System.Drawing.Point(12, 635);
            this.SSLoadingBar.Name = "SSLoadingBar";
            this.SSLoadingBar.Size = new System.Drawing.Size(1062, 23);
            this.SSLoadingBar.TabIndex = 1;
            this.SSLoadingBar.Click += new System.EventHandler(this.SSLoadingBar_Click);
            // 
            // loadTimer
            // 
            this.loadTimer.Interval = 1000;
            this.loadTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1087, 667);
            this.Controls.Add(this.SSLoadingBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(500, 300);
            this.MaximumSize = new System.Drawing.Size(1087, 667);
            this.MinimumSize = new System.Drawing.Size(1087, 667);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conflict";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ProgressBar SSLoadingBar;
        public System.Windows.Forms.Timer loadTimer;
    }
}

