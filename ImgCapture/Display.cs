using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.Util;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace ImgCapture
{
    public partial class Display : Form
    {

        WebCamServer server;
        public Display()
        {
            server = new WebCamServer();
            server.Start();
            InitializeComponent();            
        }

        void ImgCap_NewFrame(object sender, WebCamService.FrameEventArgs e)
        {
            pictureBox.Image = e.Frame;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                server.ImgCap.NewFrame += ImgCap_NewFrame;
            else
                server.ImgCap.NewFrame -= ImgCap_NewFrame;

        }

        private void Display_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Stop();
            server.ImgCap.NewFrame -= ImgCap_NewFrame;            
            Application.Exit();      
        }

      
    }
}
