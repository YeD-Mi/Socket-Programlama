using ChatSocketsServer;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ChatSocketsClient
{
    public class DirectConnection
    {
        public Form1 Form;
        public TabPage Page;
        public TextBox Chat;

        public TcpClient tcpClient;        
        private Thread thrSender;
        private StreamReader srReceiver;
        private StreamWriter swSender;
        private string strAnswer;
        public string UserName;
        public string IpAddress;
        public int Port;

        public DirectConnection(TcpClient tcpCon, string userName, Form1 form)
        {
            Form = form;
            tcpClient = tcpCon;
            UserName = userName;
            Setup();
        }
        public DirectConnection(TcpClient tcpCon, Form1 form)
        {
            Form = form;
            tcpClient = tcpCon;
            Setup();
        }
        private void Setup()
        {
            srReceiver = new StreamReader(tcpClient.GetStream());
            swSender = new StreamWriter(tcpClient.GetStream());
            var endPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
            IpAddress = endPoint.Address.ToString();
            Port = endPoint.Port;

            thrSender = new Thread(AcceptClient);
            thrSender.IsBackground = true;
            thrSender.Start();
        }

        private void CloseConnection()
        {
            tcpClient.Close();
            srReceiver.Close();
            swSender.Close();
        }
        private void AcceptClient()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                UserName = MsgEncoding.Decode(srReceiver.ReadLine()).Body;
                if(Page != null)
                {
                    Page.Text = UserName;
                }
            }
            Form.Connections.Add(this);
            KeepListening();
        }
        private void KeepListening()
        {
            try
            {
                while (true)
                {
                    strAnswer = srReceiver.ReadLine();
                    if (strAnswer == null)
                    {
                        Form.Connections.Remove(this);
                        CloseConnection();
                        break;
                    }
                    var answer = MsgEncoding.Decode(strAnswer);
                    switch (answer.Code)
                    {
                        case MsgCode.GlobalChat:
                            var message = answer.Body;
                            ChatServer.SendMessage(UserName,message);
                            break;
                        case MsgCode.RequestConnection:
                            ChatServer.GiveConnectionInfo(answer.Body);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                Form.Connections.Remove(this);
                CloseConnection();
            }
        }
        public void SendToClient(MsgCode code, string body)
        {
            var text = MsgEncoding.Encode(code, body);
            swSender.WriteLine(text);
            swSender.Flush();
        }
    }
}
