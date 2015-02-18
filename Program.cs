using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPSend
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Requires 3 parameters :");
                Console.WriteLine("1.target ip address");
                Console.WriteLine("2.target port");
                Console.WriteLine("3.raw data");
                return;
            }

            var host = args[0];
            var port = Convert.ToInt32(args[1]);
            var data = args[2];
            int count = 1;
            if (args.Length > 3)
                count = Convert.ToInt32(args[3]);
            for (int i = 0; i < count; i++)
            {
                UdpClient udpClient = new UdpClient(host, port);
                Byte[] sendBytes = Encoding.ASCII.GetBytes(data);
                try
                {
                    udpClient.Send(sendBytes, sendBytes.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                System.Threading.Thread.Sleep(250);
            }
        }
    }
}
