using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketConnectionLib
{
    public class SendReceive
    {
        public static Socket _clientSocket;
        string deviceInfo;
        public Socket _publicClientSocket { get { return _clientSocket; } }
        public string ConnectToServer(string ipAddress, int port)
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (!_clientSocket.Connected)
            {
                try
                {
                    _clientSocket.Connect(IPAddress.Parse(ipAddress), port);
                    //_clientSocket.BeginConnect
                    deviceInfo = System.Environment.MachineName + " " + _clientSocket.LocalEndPoint.ToString();
                    SendToServer("+" + deviceInfo);
                }
                catch (SocketException)
                {
                    return "Connection Failed";
                }
            }
            return "Connected";
        }
        public void SendToServer(string toSend)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(toSend);
            _clientSocket.Send(buffer);

            byte[] receivedBuf = new byte[1024];
            int rec = _clientSocket.Receive(receivedBuf);
            byte[] data = new byte[rec];
            Array.Copy(receivedBuf, data, rec);
        }
    }
}
