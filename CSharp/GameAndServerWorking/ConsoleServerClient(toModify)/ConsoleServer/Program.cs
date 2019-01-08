using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TransferLib.TransferClasses;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleServer
{
    class Program
    {
        private static byte[] _buffer = new byte[1024];
        private static IPAddress IPAddressHold;
        private static List<Socket> _clientSockets = new List<Socket>();
        private static Socket _serverSockets = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public List<Socket> _pubClientSocket { get {return _clientSockets; } set {_clientSockets = value; } }
        public static string messageFrForm { get; set; } = null;
        static void Main(string[] args)
        {
            Console.Title = "Server";
            SetupServer();


        jump: var toRead = Console.ReadKey();
            Console.WriteLine();
            if (toRead.KeyChar == 'd' || toRead.KeyChar == 'D')
            {
                DisplayDevices();
                goto jump;
            }
            if (toRead.KeyChar == 'm')
            {
                CheckMessage();
                goto jump;
            }
        }


        public static void CheckMessage()
        {
            if (messageFrForm != null)
            {
                string holdMessage = messageFrForm;
                messageFrForm = null;
                Console.WriteLine(holdMessage);
            }
        }
        private static void DisplayDevices()
        {
            ConnectedDevices cd = new ConnectedDevices(_clientSockets);
            System.Windows.Forms.Application.Run(cd);
            /*foreach (var dis in _clientSockets)
            {
                Console.WriteLine(dis.RemoteEndPoint);
            }*/
        }
        private static void SetupServer()
        {
            Console.WriteLine("Setting Server...");
            _serverSockets.Bind(new IPEndPoint(IPAddress.Any, 100));
            _serverSockets.Listen(100);
            _serverSockets.BeginAccept(new AsyncCallback(AcceptCallback), null);
            Console.WriteLine("Server Started");
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
            //Console.WriteLine("Client Connected");
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
                if (_buffer[0] == 43 || _buffer[0] == 45)
                {
                    Array.ConstrainedCopy(_buffer, 1, dataBuf, 0, received);
                }
                else
                {
                    Array.Copy(_buffer, dataBuf, received);
                }

                string text = Encoding.ASCII.GetString(dataBuf);

                if (_buffer[0] == 43)
                {
                    Console.WriteLine(text + " is Connected!");
                }
                else if (_buffer[0] == 45)
                {
                    Console.WriteLine(text + " is Disconnected!");
                }
                else if (_buffer[0] == 46)
                {

                }
                else
                {
                    DataValidation myValidation = new DataValidation();
                    string sigStatus = myValidation.CheckSignature(dataBuf);

                    /*Console.WriteLine(text);
                    foreach (var i in dataBuf)
                    {
                        Console.Write(i + " ");
                    }
                    Console.WriteLine();*/

                    if (sigStatus == "correct")
                    {
                        TransferManager saveMyData = new TransferManager();
                        TransferItem myItem = new TransferItem();
                        myItem.TransData = dataBuf;
                        saveMyData.SaveData(myItem);

                        //IPEndPoint remoteEndPoint = socket.RemoteEndPoint as IPEndPoint;
                        //string name = Dns.GetHostEntry(remoteEndPoint.Address.ToString()).HostName.ToString();
                        Console.WriteLine("Data Saved from: " + socket.RemoteEndPoint.ToString() +" "+ DateTime.Now);
                    }
                    else
                    {
                        //IPEndPoint remoteEndPoint = socket.RemoteEndPoint as IPEndPoint;
                        //string name = Dns.GetHostEntry(remoteEndPoint.Address.ToString()).HostName.ToString();
                        Console.WriteLine("Access Denied from: " + socket.RemoteEndPoint.ToString() + " Message: " + sigStatus + " " +DateTime.Now);
                    }
                }
                    
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
                    try
                    {
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                        _clientSockets.Remove(socket);
                    }
                    catch
                    {
                    }
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
