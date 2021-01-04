using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Timers;

namespace Fikret.TCP
{
    class FikretTCPClient
    {
        private TcpClient tc = new TcpClient();

        private NetworkStream ns;

        public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs args);

        public event EventHandler MessageReceived;

        public void Send(string message)
        {
            byte[] mesaj = new byte[100];

            mesaj = Encoding.UTF8.GetBytes(message + "{CONNECTION_END}");

            ns.Write(mesaj, 0, mesaj.Length);
        }

        public void Start()
        {
            Timer tmr = new Timer();
            tmr.Elapsed += kontrol;
        }

        private void kontrol(object sender, ElapsedEventArgs args)
        {
            try
            {
                byte[] cevap = new byte[100];
                ns.Read(cevap, 0, cevap.Length);
                if (cevap != null)
                {
                    string metin = Encoding.UTF8.GetString(cevap).Split(new string[] { "{CONNECTION_END}" }, StringSplitOptions.None)[0];

                    MessageReceivedEventArgs eventargs = new MessageReceivedEventArgs(metin);
                    
                    MessageReceived(this, eventargs);
                }
            }
            catch
            {

            }
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
