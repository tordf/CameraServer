namespace ImgCapture
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Emgu.CV.UI.ImageBox HandTrackerBox;
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
            this.HandTrackerBox = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.HandTrackerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // HandTrackerBox
            // 
            this.HandTrackerBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.HandTrackerBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.HandTrackerBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HandTrackerBox.Location = new System.Drawing.Point(0, 0);
            this.HandTrackerBox.Name = "HandTrackerBox";
            this.HandTrackerBox.Size = new System.Drawing.Size(730, 449);
            this.HandTrackerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HandTrackerBox.TabIndex = 2;
            this.HandTrackerBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 449);
            this.Controls.Add(this.HandTrackerBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.HandTrackerBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

    }
}

