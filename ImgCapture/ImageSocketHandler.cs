using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using ImgCapture;

namespace WebCamService
{
    public class ImageSocketHandler : ImgCapture.IDataProvider
    {
        ImageCapturer Wcs { get; set; }        
        public ImageSocketHandler(ImageCapturer wcs)
        {
            Wcs = wcs;
            wcs.NewImage += wcs_NewImage;
        }

        void wcs_NewImage(object sender, ImageEventArgs iea)
        {
                MemoryStream stream = new MemoryStream();
                //NetworkStream ns = networkStream; 
                Image e = iea.Image;
                e.Save(stream, ImageFormat.Jpeg); 
                byte[] buffer = stream.ToArray();
                Data = buffer;
                if (DataChanged != null)
                {
                    DataChanged(this, new EventArgs());
                }
        }
            
        

        public byte[] Data{get;set;}
        public event EventHandler DataChanged;

       
    }
}
