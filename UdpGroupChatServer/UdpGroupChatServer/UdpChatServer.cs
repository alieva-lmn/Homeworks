using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UdpGroupChatServer
{
    class UdpChatServer
    {
        private UdpClient udpServer;
        private IPEndPoint groupEndPoint;
        private List<IPEndPoint> clientEndPoints = new List<IPEndPoint>();
        private const int Port = 12345;

        public void Start()
        {
            udpServer = new UdpClient(Port);
            groupEndPoint = new IPEndPoint(IPAddress.Parse("239.0.0.1"), Port);

            Console.WriteLine("Server started. Waiting for clients...");

            while (true)
            {
                IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = udpServer.Receive(ref clientEndPoint);

                if (!clientEndPoints.Contains(clientEndPoint))
                {
                    clientEndPoints.Add(clientEndPoint);
                    Console.WriteLine($"New client connected: {clientEndPoint}");
                }

                string message = Encoding.UTF8.GetString(data);
                Console.WriteLine("Received: " + message);

                foreach (var client in clientEndPoints)
                {
                    if (!client.Equals(clientEndPoint))
                    {
                        udpServer.Send(data, data.Length, client);
                    }
                }
            }
        }

        public void Stop()
        {
            udpServer.Close();
        }
    }
}
