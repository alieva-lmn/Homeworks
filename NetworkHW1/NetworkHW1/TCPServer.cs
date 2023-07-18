using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkHW1
{
    public class TCPServer
    {
        private TcpListener _listener;

        public TCPServer()
        {
            StartServer();
        }

        private void StartServer()
        {
            var port = 8080;
            var hostAdress = IPAddress.Parse("127.0.0.1");
            _listener = new TcpListener(hostAdress, port);
            _listener.Start();

            byte[] buffer = new byte[256];
            string receivedMessage;

            using TcpClient client = _listener.AcceptTcpClient();

            var tcpStream = client.GetStream();
            int readTotal;

            while ((readTotal = tcpStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string incomingMessage = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                var response = Encoding.UTF8.GetBytes("SUCCESSFULLY CONNECTED");
                tcpStream.Write(response, 0, response.Length);
            }
        }
    }
}
