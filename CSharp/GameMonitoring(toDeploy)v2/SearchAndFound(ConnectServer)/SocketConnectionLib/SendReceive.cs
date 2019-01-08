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
        public static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string deviceInfo;
        public Socket _publicClientSocket { get { return _clientSocket; } }
        public string ConnectToServer(string ipAddress, int port)
        {
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

            /*byte[] receivedBuf = new byte[1024];
            int rec = _clientSocket.Receive(receivedBuf);
            byte[] data = new byte[rec];
            Array.Copy(receivedBuf, data, rec);*/
        }
        public static string SendRFID(string toSend)
        {
            string hold = "=" + toSend;
            byte[] buffer = Encoding.ASCII.GetBytes(toSend);
            _clientSocket.Send(buffer);

            byte[] receivedBuf = new byte[1024];
            int rec = _clientSocket.Receive(receivedBuf);
            byte[] data = new byte[rec];
            Array.Copy(receivedBuf, data, rec);
            var a = Encoding.ASCII.GetString(data);
            return a;
            //return GetValues(data);
        }
        private GetCredentials GetValues(byte[] data)
        {
            GetCredentials myitem = new GetCredentials();
            int i = 0;
            byte[] _buffer;
            byte[] name;
            byte[] balance;
            byte[] points;
            for (int a = 0; a <= data.Length - 1; a++)
            {
                if (data[a] == 126)
                {
                    _buffer = new byte[1024];
                    a++;
                    while (data[a] != 126)
                    {
                        _buffer[i] = data[a];
                        a++;
                        i++;
                    }
                    name = new byte[i];
                    Array.Copy(_buffer, name, i);
                    i = 0;
                    a++;
                    myitem.name = Encoding.ASCII.GetString(name);
                }
                if (data[a] == 33)
                {
                    _buffer = new byte[1024];
                    a++;
                    while (data[a] != 33)
                    {
                        _buffer[i] = data[a];
                        a++;
                        i++;
                    }
                    balance = new byte[i];
                    Array.Copy(_buffer, balance, i);
                    i = 0;
                    a++;
                    myitem.name = Encoding.ASCII.GetString(balance);
                }
                if (data[a] == 64)
                {
                    _buffer = new byte[1024];
                    a++;
                    while (data[a] != 64)
                    {
                        _buffer[i] = data[a];
                        a++;
                        i++;
                    }
                    points = new byte[i];
                    Array.Copy(_buffer, points, i);
                    i = 0;
                    a++;
                    myitem.name = Encoding.ASCII.GetString(points);
                }
            }
            return myitem;
        }
    }
}
