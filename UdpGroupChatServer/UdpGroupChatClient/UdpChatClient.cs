using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UdpGroupChatClient
{
    class UdpChatClient
    {
        private UdpClient udpClient;
        private const int Port = 12346;

        public void Start()
        {
            udpClient = new UdpClient();
            udpClient.JoinMulticastGroup(IPAddress.Parse("239.0.0.1"));
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse("239.0.0.1"), Port);

            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, Port));

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            var receiveThread = new System.Threading.Thread(() => ReceiveMessages(remoteEndPoint));
            receiveThread.Start();

            Console.WriteLine("Type your message.\n\n");

            while (true)
            {
                string message = Console.ReadLine();

                message = $"{name} [{DateTime.Now}]: {message}";

                byte[] data = Encoding.UTF8.GetBytes(message);
                udpClient.Send(data, data.Length, remoteEndPoint);
            }

            udpClient.Close();
        }

        private void ReceiveMessages(IPEndPoint remoteEndPoint)
        {
            while (true)
            {
                byte[] data = udpClient.Receive(ref remoteEndPoint);
                string message = Encoding.UTF8.GetString(data);
                Console.WriteLine("\nReceived:\n\n" + message);
            }
        }
    }
}
