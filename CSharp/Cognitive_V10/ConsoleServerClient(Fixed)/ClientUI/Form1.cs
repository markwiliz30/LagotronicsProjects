using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientUI
{
    public partial class Form1 : Form
    {
        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form1()
        {
            InitializeComponent();
        }
        private void ConnectToServer(string ipAddress)
        {
            while (!_clientSocket.Connected)
            {
                try
                {
                    _clientSocket.Connect(IPAddress.Parse(ipAddress), 100);
                    //_clientSocket.BeginConnect
                }
                catch (SocketException)
                {
                    MessageBox.Show("Connection Failed");
                    return;
                }
            }
            MessageBox.Show("Connected");
        }
        private void SendToServer()
        {
            byte[] buffer = Encoding.ASCII.GetBytes(txtMessage.Text);
            _clientSocket.Send(buffer);

            byte[] receivedBuf = new byte[1024];
            int rec = _clientSocket.Receive(receivedBuf);
            byte[] data = new byte[rec];
            Array.Copy(receivedBuf, data, rec);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer(txtIpAddress.Text);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendToServer();
            txtMessage.Text = "";
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {

        }
    }
}
