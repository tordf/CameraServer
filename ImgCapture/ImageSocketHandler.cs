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
    public class ImageSocketHandler
    {
        ImageCapturer Wcs { get; set; }
        Socket SocketForClient { get; set; }
        NetworkStream networkStream;
        public ImageSocketHandler(ImageCapturer wcs, Socket socketForClient)
        {
            Wcs = wcs;
            SocketForClient = socketForClient;
            wcs.NewImage += new EventHandler<ImageEventArgs>(wcs_NewImage);
            networkStream = new NetworkStream(socketForClient);
        }

        void wcs_NewImage(object sender, ImageEventArgs iea)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                NetworkStream ns = networkStream; 
                Image e = iea.Image;
                e.Save(stream, ImageFormat.Jpeg); 
                byte[] buffer = stream.ToArray(); 
                System.IO.StreamWriter sw = new System.IO.StreamWriter(ns);
                sw.WriteLine(buffer.Length.ToString());
                sw.Flush();
                System.IO.BinaryWriter bw = new System.IO.BinaryWriter(ns);
                System.Console.WriteLine("size of array: " + buffer.Length);
                bw.Write(buffer);   
                ns.Flush();
            }
            catch (Exception)
            {
                Wcs.NewImage -= new EventHandler<ImageEventArgs>(wcs_NewImage);
                SocketForClient.Close();
            }
        }

    }
}
