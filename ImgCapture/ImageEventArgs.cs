using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WebCamService
{
    public class ImageEventArgs : EventArgs
    {
        public Image Image { get; set; }
    }

    public class FrameEventArgs : EventArgs
    {
        public Image<Bgr, Byte> Frame {get;set;}
    }
}
