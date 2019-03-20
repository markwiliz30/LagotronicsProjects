using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace NetworkLib
{
    public class AsyncClient
    {
        private static Socket ClientSocket;
        //public Socket _publicClientSocket { get { return ClientSocket; } set { ClientSocket = value; } }

        public const int PORT = 5555;

        public string ConnectToServer(string inputIp)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (!ClientSocket.Connected)
            {
                try
                {
                    ClientSocket.Connect(IPAddress.Parse(inputIp), PORT);
                }
                catch (Exception)
                {
                    return "Connection Failed";
                }
            }

            return "Connected";
        }

        public string Request(string request)
        {
            SendString(request);
            return ReceiveResponse();
        }

        /// <summary>
        /// Close socket and exit program.
        /// </summary>
        public void Exit()
        {
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
        }

        /// <summary>
        /// Sends a string to the server with ASCII encoding.
        /// </summary>
        public void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        public static string ReceiveResponse()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return "";
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            return text;
        }
    }
}
