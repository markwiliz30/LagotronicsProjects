using FirebaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TransferLib.TransferClasses;
using SavingDataLib;

namespace AsyncCallBack
{
    public class CallBack
    {
        //
        private static byte[] _buffer = new byte[1024];
        private static IPAddress IPAddressHold;
        public static List<Socket> _clientSockets = new List<Socket>();
        public static Socket _serverSockets = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static List<string> logMsg = new List<string>();
        public static List<SavingDataLib.TransferClasses.StringTransferItem> sfScores = new List<SavingDataLib.TransferClasses.StringTransferItem>();
        public static List<byte[]> dataToConvert = new List<byte[]>();
        public static int sfCounter = 0, cogCounter = 0;
        public static string rfId;
        public static string SetupServer()
        {
            _serverSockets.Bind(new IPEndPoint(IPAddress.Any, 100));
            _serverSockets.Listen(100);
            _serverSockets.BeginAccept(new AsyncCallback(AcceptCallback), null);
            return "Server Started";
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
        private static async void ReceiveCallback(IAsyncResult AR)
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
                Console.WriteLine("Text received: " + text);

                string response = string.Empty;

                if (text.ToLower() != "get date")
                {
                    response = "Invalid Request";
                }
                else
                {
                    response = DateTime.Now.ToLongTimeString();
                }

                if (_buffer[0] == 43)
                {
                    logMsg.Add(text.Remove(text.Length - 1) + " is Connected!");
                }
                else if (_buffer[0] == 45)
                {
                    logMsg.Add(text.Remove(text.Length - 1) + " is Disconnected!");
                }
                else if (_buffer[0] == 46)
                {

                }
                else if (_buffer[0] == 35)
                {
                    sfCounter++;
                }
                else if (_buffer[0] == 64)
                {
                    cogCounter++;
                }
                else if (_buffer[0] == 61)
                {
                    FirebaseClass myFirebase = new FirebaseClass();

                    var holdRes = await myFirebase.CheckExisting(text.Substring(1));

                    if (holdRes != null)
                    {
                        response = "~" + holdRes.Name + "~" + "!" + holdRes.Balance + "!" + "@" + holdRes.Points + "@";
                    }
                    else
                    {
                        response = "NOUSER";
                    }

                    byte[] data = Encoding.ASCII.GetBytes(response);
                    socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                }
                else if (_buffer[0] == 124)
                {
                    byte[] data = dataBuf;
                    var item = new ConverterClasses.ConvertItem();
                    var myManager = new ConverterClasses.ConvertManager();
                    item = myManager.UpdateItem(data);

                    FirebaseClass myFirebase = new FirebaseClass();
                    UserItem itemToSend = new UserItem();
                    myFirebase.UpdateScore(item.rfId, item.points, item.balance);
                }
                else if (_buffer[0] == 41)
                {
                    //byte[] data = dataBuf;
                    rfId = text.Substring(1);
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
                        //var convertedData = GetSFScores(myItem.TransData);

                        dataToConvert.Add(myItem.TransData);

                        //IPEndPoint remoteEndPoint = socket.RemoteEndPoint as IPEndPoint;
                        //string name = Dns.GetHostEntry(remoteEndPoint.Address.ToString()).HostName.ToString();
                        logMsg.Add("Data Saved from: " + socket.RemoteEndPoint.ToString() + " " + DateTime.Now);
                    }
                    else
                    {
                        //IPEndPoint remoteEndPoint = socket.RemoteEndPoint as IPEndPoint;
                        //string name = Dns.GetHostEntry(remoteEndPoint.Address.ToString()).HostName.ToString();
                        logMsg.Add("Access Denied from: " + socket.RemoteEndPoint.ToString() + " Message: " + sigStatus + " " + DateTime.Now);
                    }
                }
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
        public List<byte[]> DataCollection()
        {
            var holdCollection = new List<byte[]>();
            TransferManager myManager = new TransferManager();
            var holdDataList = myManager.RetreiveAllData();
            foreach (var i in holdDataList)
            {
                var item = new byte[i.TransData.Length];
                item = i.TransData;
                holdCollection.Add(item);
            }
            return holdCollection;
        }
    }
}
