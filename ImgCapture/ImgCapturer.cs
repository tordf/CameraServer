using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCamService;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows.Forms;
using Emgu.CV.CvEnum;
using System.Drawing;

namespace ImgCapture
{
    public class ImgCapturer : ImageCapturer, FrameCapturer
    {
        private Capture _capture;
        private bool _captureInProgress;
        public Image<Bgr, Byte> frame;

        public void Init()
        {
            if (_capture == null)
            {
                try
                {
                    _capture = new Capture();
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }

            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    //stop the capture
                    Application.Idle -= ProcessFrame;
                }
                else
                {
                    //start the capture
                    Application.Idle += ProcessFrame;
                }

                _captureInProgress = !_captureInProgress;
            }
        }

        public event EventHandler<ImageEventArgs> NewImage;
        private void ProcessFrame(object sender, EventArgs arg)
        {
            frame = _capture.QueryFrame().Flip(FLIP.HORIZONTAL);
            if (NewFrame != null)
            {
                FrameEventArgs fea = new FrameEventArgs();
                fea.Frame = frame;
                NewFrame(this, fea);
            }
            Image image = frame.Bitmap;
            if (NewImage != null)
            {
                ImageEventArgs iea = new ImageEventArgs();
                iea.Image = image;
                NewImage(this, iea);
            }
            //
           // Bitmap b = new Bitmap(frame.Bitmap);
        }

        #region FrameCapturer Members

        public event EventHandler<FrameEventArgs> NewFrame;

        #endregion
    }
}
