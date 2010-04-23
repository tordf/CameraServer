using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace ImgCapture
{
    public class SocketWriter
    {
        Socket SocketForClient { get; set; }
        private IDataProvider Idp;
        private NetworkStream ns;
        public SocketWriter(IDataProvider Idp, Socket s)
        {
            SocketForClient = s;
            this.ns = new NetworkStream(s);
            this.Idp = Idp;
            Idp.DataChanged += new EventHandler(Idp_DataChanged);
        }

        void Idp_DataChanged(object sender, EventArgs e)
        {
            WriteToSocket(Idp.Data);
        }

        private void WriteToSocket(byte[] buffer)
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(ns);
                sw.WriteLine(buffer.Length.ToString());
                sw.Flush();
                System.IO.BinaryWriter bw = new System.IO.BinaryWriter(ns);
                System.Console.WriteLine("size of array: " + buffer.Length);
                bw.Write(buffer);
                bw.Flush();
            }
            catch (Exception)
            {
                Idp.DataChanged -= Idp_DataChanged;
                ns.Close();
                SocketForClient.Close();
            }
        }
    }
}
