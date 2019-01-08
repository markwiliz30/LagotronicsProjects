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
        private static Socket _clientSocket;
        string deviceInfo;
        bool alreadyDisconnected = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void ConnectToServer(string ipAddress)
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (!_clientSocket.Connected)
            {
                try
                {
                    _clientSocket.Connect(IPAddress.Parse(ipAddress), 100);
                    alreadyDisconnected = false;
                    //_clientSocket.BeginConnect
                    deviceInfo = System.Environment.MachineName + " " + _clientSocket.LocalEndPoint.ToString();
                    SendToServer("+" + deviceInfo);
                }
                catch (SocketException)
                {
                    MessageBox.Show("Connection Failed");
                    return;
                }
            }
            MessageBox.Show("Connected");
        }
        private void SendToServer(string toSend)
        {
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(toSend);
                _clientSocket.Send(buffer);

                byte[] receivedBuf = new byte[1024];
                int rec = _clientSocket.Receive(receivedBuf);
                byte[] data = new byte[rec];
                Array.Copy(receivedBuf, data, rec);
            }
            catch
            {
                if (!alreadyDisconnected)
                {
                    _clientSocket.Shutdown(SocketShutdown.Both);
                    _clientSocket.Close();
                    alreadyDisconnected = true;
                }
                MessageBox.Show("You are not connected from server");
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer(txtIpAddress.Text);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendToServer(txtMessage.Text);
            txtMessage.Text = "";
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("attention", "Data will be loss", MessageBoxButtons.YesNoCancel);
            timer1.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                deviceInfo = System.Environment.MachineName + " " + _clientSocket.LocalEndPoint.ToString();
                SendToServer("-" + deviceInfo);
            }
            catch
            {
                var result = MessageBox.Show("Ang server ay hindi nakasindi. mawawala ang data kapag sinara ang application. Sigurado kaba na gusto mong isara ang application na ito?", "Babala", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    return;
                }
                e.Cancel = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtMessage.Text = "hey";
            Invoke(new EventHandler(btnSend_Click));
        }
    }
}
