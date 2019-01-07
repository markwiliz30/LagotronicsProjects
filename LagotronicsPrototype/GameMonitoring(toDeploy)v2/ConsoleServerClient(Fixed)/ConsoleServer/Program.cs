using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AsyncCallBack;

namespace ConsoleServer
{
    class Program
    {
        //private static bool socketIsConnected;
        private static byte[] _buffer = new byte[1024];
        private static IPAddress IPAddressHold;
        private static List<Socket> _clientSockets = new List<Socket>();
        private static Socket _serverSockets = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            Console.Title = "Server";
            CallBack.SetupServer();
            Console.ReadLine();
        }
        private static void SetupServer()
        {
            Console.WriteLine("Setting Server...");
            _serverSockets.Bind(new IPEndPoint(IPAddress.Any, 100));
            _serverSockets.Listen(100);
            _serverSockets.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }
        private static IPAddress GetIPAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddressHold = IP;
                }
            }
            return IPAddressHold;
        }
        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = _serverSockets.EndAccept(AR);
            _clientSockets.Add(socket);
            Console.WriteLine("Client Connected");
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            _serverSockets.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }
        private static void ReceiveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            try
            {
                int received = socket.EndReceive(AR);
                byte[] dataBuf = new byte[received];
                Array.Copy(_buffer, dataBuf, received);
                string text = Encoding.ASCII.GetString(dataBuf);
                Console.WriteLine("Text received: " + text);

                string response = string.Empty;

                if (text.ToLower() != "get time")
                {
                    response = "Invalid Request";
                }
                else
                {
                    response = DateTime.Now.ToLongTimeString();
                }

                byte[] data = Encoding.ASCII.GetBytes(response);
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            }
            catch 
            {
                if (!socket.Connected)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    _clientSockets.Remove(socket);
                }
            }
            
        }
        private static void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }
    }
}
