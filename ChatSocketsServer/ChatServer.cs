using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Linq;

namespace ChatSocketsServer
{
    public class ChatServer
    {
        public static List<Connection> Connections = new List<Connection>();
        private IPAddress enderecoIp;
        private int portaHost;

        public ChatServer(IPAddress ipAddres, int port)
        {
            enderecoIp = ipAddres;
            portaHost = port;
        }

        private Thread thrListener;
        private TcpListener tlsCliente;
        bool running = false;

        public static void IncludeUser(Connection connection)
        {
            Connections.Add(connection);
            SendAdminMessage(connection.UserName + " giris yapti.");
        }
        public static void RemoveUser(Connection connection)
        {
            if(Connections.Exists(x => x.UserName == connection.UserName))
            {
                SendAdminMessage(connection.UserName + " cikis yapti.");
                Connections.Remove(connection);
                connection.CloseConnection();
            }
        }

        public static void SendAdminMessage(string message)
        {
            if (string.IsNullOrEmpty(message.Trim())) return;
            var formattedMsg = $"Admin: {message}";

            foreach (Connection c in Connections)
            {
                if (c.tcpClient == null) continue;
                try
                {
                    c.SendToClient(MsgCode.GlobalChat, formattedMsg);
                }
                catch
                {
                    RemoveUser(c);
                }
            }
        }

        public static void SendMessage(string senderName, string message)
        {
            if (string.IsNullOrEmpty(message.Trim())) return;
            var formattedMsg = $"{senderName} yazdi: {message}";

            foreach (Connection c in Connections)
            {
                if (c.tcpClient == null) continue;
                try
                {
                    c.SendToClient(MsgCode.GlobalChat, formattedMsg);
                }
                catch
                {
                    RemoveUser(c);
                }
            }
        }
        public static void GiveConnectionInfo(string request)
        {
            try
            {
                var parameters = request.Split(";");
                string contactName = parameters[0];
                string userName = parameters[1];
                var connection = Connections.FirstOrDefault(x => x.UserName == userName);
                var contact = Connections.FirstOrDefault(x => x.UserName == contactName);
                if (connection != null)
                {
                    var message = $"{contact.IpAddress}:{contact.Port}:{contact.UserName}";
                    connection.SendToClient(MsgCode.RequestConnection, message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Start()
        {
            IPAddress ipLocal = enderecoIp;
            int portLocal = portaHost;

            tlsCliente = new TcpListener(ipLocal, portLocal);
            tlsCliente.Start();
            running = true;

            thrListener = new Thread(KeepListening);
            thrListener.IsBackground = true;
            thrListener.Start();
        }

        public void KeepListening()
        {
            while (running)
            {
                var tcpClient = tlsCliente.AcceptTcpClient();
                var endPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
                Console.WriteLine($"Yeni Baglanti;: {endPoint.Address}:{endPoint.Port}");
                Connection connection = new Connection(tcpClient);
            }
        }
    }
}
