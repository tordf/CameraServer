using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WebCamService;
using System.Net.Sockets;

namespace ImgCapture
{
    public class WebCamServer
    {
        bool run = true;
        protected Thread serverThread = null;
        public ImgCapturer ImgCap { get; set; }

        public WebCamServer()
        {
            ImgCap = new ImgCapturer();
            ImgCap.Init();
        }



        private void StartServer()
        {

            TcpListener tcpListener = new TcpListener(10);
            tcpListener.Start();  
            while (run)
            {
                new ImageSocketHandler(ImgCap, tcpListener.AcceptSocket());
            }
        }

        public void Start()
        {
            ThreadStart starterServer = new ThreadStart(StartServer);
            serverThread = new Thread(starterServer);
            serverThread.Start();
        }

        public void OnStop()
        {            
            serverThread.Abort();
        }
    }
}
