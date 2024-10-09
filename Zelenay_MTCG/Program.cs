using System;
using System.Net;
using MonsterCardGame.Server;

namespace MonsterCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var tcpServerInstance = new TcpServerInstance(IPAddress.Loopback, 10001);
            tcpServerInstance.Start();
        }
    }
}
