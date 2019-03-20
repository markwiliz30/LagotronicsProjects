using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace NetworkLib
{
    public class AsyncServer
    {
        public static readonly Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static readonly List<Socket> clientSockets = new List<Socket>();
        public static string message = "";
        public const int BUFFER_SIZE = 2048;
        public const int PORT = 5555;
        public static readonly byte[] buffer = new byte[BUFFER_SIZE];

        public static bool SetupServer()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT));
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallback, null);
            return true;
        }

        /// <summary>
        /// Close all connected client (we do not need to shutdown the server socket as its connections
        /// are already closed with the clients).
        /// </summary>
        public void CloseAllSockets()
        {
            foreach (Socket socket in clientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            serverSocket.Close();
        }

        public static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                socket = serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }

            clientSockets.Add(socket);
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        public static void ReceiveCallback(IAsyncResult AR)
        {
            Socket current = (Socket)AR.AsyncState;
            int received;

            try
            {
                received = current.EndReceive(AR);
            }
            catch (SocketException)
            {
                // Don't shutdown because the socket may be disposed and its disconnected anyway.
                current.Close();
                clientSockets.Remove(current);
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);
            message = text;
            if (text.ToLower() == "get time") // Client requested time
            {
                byte[] data = Encoding.ASCII.GetBytes(DateTime.Now.ToLongTimeString());
                current.Send(data);
            }
            else if (text.ToLower() == "exit") // Client wants to exit gracefully
            {
                // Always Shutdown before closing
                current.Shutdown(SocketShutdown.Both);
                current.Close();
                clientSockets.Remove(current);
                return;
            }
            else
            {
                byte[] data = Encoding.ASCII.GetBytes("Invalid request");
                current.Send(data);
            }

            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
        }
    }
}
