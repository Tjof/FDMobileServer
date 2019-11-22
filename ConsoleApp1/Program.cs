using System;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting");
            Socket s = new Socket(SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("starting2");
            s.Bind(new IPEndPoint(IPAddress.Any,7777));

            Console.WriteLine("starting3");
            s.Listen(100);
            Console.WriteLine("starting4");
            Console.WriteLine(s.LocalEndPoint.ToString());
            var sock = s.Accept();

            Console.WriteLine("starting5");
        }
    }
}
