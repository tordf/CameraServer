﻿using System;
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
    public partial class Form1 : Form
    {

        WebCamServer server;
        public Form1()
        {
            server = new WebCamServer();
            server.ImgCap.NewFrame += new EventHandler<WebCamService.FrameEventArgs>(ImgCap_NewFrame);
            server.Start();
            InitializeComponent();
        }

        void ImgCap_NewFrame(object sender, WebCamService.FrameEventArgs e)
        {
            HandTrackerBox.Image = e.Frame;
        }

      
    }
}
