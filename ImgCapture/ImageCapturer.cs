using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCamService;

namespace ImgCapture
{
    public interface ImageCapturer
    {
        event EventHandler<ImageEventArgs> NewImage;
    }
}
