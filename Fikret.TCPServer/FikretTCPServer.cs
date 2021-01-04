using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Fikret.UDPServer
{
    public class UDPServer
    {
        public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs args);

        TcpListener tcpserver;

        NetworkStream sonstream;

        public event EventHandler MessageReceived;

        public void Start(int port)
        {
            tcpserver = new TcpListener(IPAddress.Any, port);
            tcpserver.Start();
            kabulet();
        }

        public void Stop()
        {
            tcpserver.Stop();
        }

        private void kabulet()
        {
            tcpserver.BeginAcceptTcpClient(handle, tcpserver);
        }

        private void handle(IAsyncResult result)
        {
            TcpClient client = tcpserver.EndAcceptTcpClient(result);
            while (true)
            {
                kabulet();


                NetworkStream ns = client.GetStream();

                byte[] mesaj = new byte[1024];

                if (mesaj != null)
                {
                    ns.Read(mesaj, 0, mesaj.Length);

                    string metin = Encoding.UTF8.GetString(mesaj).Split(new string[] { "{CONNECTION_END}" }, StringSplitOptions.None)[0];

                    MessageReceivedEventArgs args = new MessageReceivedEventArgs(metin);

                    sonstream = ns; //nice

                    MessageReceived(this, args);
                }
            }
        }

        public void Send(string metin)
        {
            byte[] gndmesaj = new byte[100];
            gndmesaj = Encoding.UTF8.GetBytes(metin + "{CONNECTION_END}");

            sonstream.Write(gndmesaj, 0, gndmesaj.Length);
        }
    }

    public class MessageReceivedEventArgs : EventArgs
    {
        public MessageReceivedEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
