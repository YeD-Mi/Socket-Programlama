using System;
using System.Net;

namespace ChatSocketsServer
{
    class Program
    {
        private static  bool _connected;
        private delegate void UpdateStatusCallback(string message);
        static void Main(string[] args)
        {
            Console.WriteLine("IP Gir:");
            var ipString = Console.ReadLine();
            Console.WriteLine("Port Gir:");
            var hostPortString = Console.ReadLine();
            IPAddress ipAddress = IPAddress.Parse(ipString);
            int hostPort = int.Parse(hostPortString);

            ChatServer mainServer = new ChatServer(ipAddress, hostPort);
            mainServer.Start();
            Console.WriteLine($"Server Aktif Edildi; {ipString}:{hostPortString}");
            _connected = true;

            while (_connected) { }
        }
    }
}
