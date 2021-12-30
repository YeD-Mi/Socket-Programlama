using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatSocketsServer
{
    public class Connection
    {
        public TcpClient tcpClient;
        private Thread thrSender;
        private StreamReader srReceiver;
        private StreamWriter swSender;
        private string strAnswer;
        public string UserName;        
        public string IpAddress;
        public int Port;

        public Connection(TcpClient tcpCon)
        {
            tcpClient = tcpCon;
            srReceiver = new StreamReader(tcpClient.GetStream());
            swSender = new StreamWriter(tcpClient.GetStream());
            var endPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
            IpAddress = endPoint.Address.ToString();
            Port = endPoint.Port;

            thrSender = new Thread(AcceptClient);
            thrSender.IsBackground = true;
            thrSender.Start();
        }
        public void CloseConnection()
        {
            tcpClient.Close();
            srReceiver.Close();
            swSender.Close();
        }
        private void AcceptClient()
        {
            UserName = MsgEncoding.Decode(srReceiver.ReadLine()).Body;
            if (!ValidateUserName()) return;
            SendToClient(MsgCode.ConnectionSuccess, $"{IpAddress}:{Port}");
            ChatServer.IncludeUser(this);
            KeepListening();
        }

        private bool ValidateUserName()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                CloseConnection();
                return false;
            }
            if (ChatServer.Connections.Exists(x => x.UserName == UserName))
            {
                SendToClient(MsgCode.ConnectionError, "Kullanici Zaten Var!");
                CloseConnection();
                return false;
            }
            if (UserName == "Admin")
            {
                SendToClient(MsgCode.ConnectionError, "Gecersiz Kullanici");
                CloseConnection();
                return false;
            }
            return true;
        }
        private void KeepListening()
        {
            try
            {
                while (true)
                {
                    strAnswer = srReceiver.ReadLine();
                    Console.WriteLine("Gelen ->" + strAnswer);
                    if (strAnswer == null)
                    {
                        ChatServer.RemoveUser(this);
                        break;
                    }
                    var answer = MsgEncoding.Decode(strAnswer);
                    switch (answer.Code)
                    {
                        case MsgCode.GlobalChat:
                            var message = answer.Body;
                            string metin = message;
                            if(metin.EndsWith("1") || metin.EndsWith("0"))
                            {
                                if (metin.StartsWith("1") || metin.StartsWith("0"))
                                {
                                    SPN16Server spn = new SPN16Server("crypto12");
                                    var CozulenMesaj = spn.decrypt(message);
                                    ChatServer.SendMessage(UserName, CozulenMesaj);
                                }
                                else
                                {
                                    ChatServer.SendMessage(UserName, message);
                                };
                            }
                            else
                            {
                                ChatServer.SendMessage(UserName, message);
                            };
                            break;
                        case MsgCode.RequestConnection:
                            ChatServer.GiveConnectionInfo(answer.Body);
                            break;
                        case MsgCode.OnlineListRequest:
                            var r = "";
                            foreach (var item in ChatServer.Connections) {
                                r += item.UserName + ":";
                            }
                            SendToClient(MsgCode.OnlineListRequest, r);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                ChatServer.RemoveUser(this);
            }
        }

        public void SendToClient(MsgCode code, string body)
        {
            var text = MsgEncoding.Encode(code, body);
            Console.WriteLine("Giden ->" + text);
            swSender.WriteLine(text);
            swSender.Flush();
        }
    }
   
}
