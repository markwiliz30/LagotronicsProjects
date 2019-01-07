using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleServer
{
    public partial class ConnectedDevices : Form
    {
        static List<Socket> clientList = new List<Socket>();
        int clientCount;
        
        public ConnectedDevices(List<Socket> myClientList)
        {
            clientList = myClientList;
            InitializeComponent();
            foreach (var myCList in clientList)
            {
                connectedList.Items.Add(myCList.RemoteEndPoint);
            }
            connectedList.Sorted = true;
            clientCount = clientList.Count;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                Socket removeSelSocket = clientList.Find(p => p.RemoteEndPoint.ToString() == connectedList.SelectedItem.ToString());
                clientList.Remove(removeSelSocket);
                removeSelSocket.Shutdown(SocketShutdown.Both);
                removeSelSocket.Close();
                Program.messageFrForm = connectedList.SelectedItem + " " + "disconnection successful";
                Program.CheckMessage();
                connectedList.Items.Remove(connectedList.SelectedItem);
            }
            catch
            {
                MessageBox.Show("Please Select IP Address to disconnect");
            }
            
        }

        private void connectionListTimer_Tick(object sender, EventArgs e)
        {
            if (clientCount != clientList.Count)
            {
                connectedList.Items.Clear();
                foreach (var updatedItems in clientList)
                {
                    connectedList.Items.Add(updatedItems.RemoteEndPoint);
                }
                connectedList.Sorted = true;
                clientCount = clientList.Count;
            }
        }

        private void ConnectedDevices_Load(object sender, EventArgs e)
        {
            connectionListTimer.Start();
        }
    }
}
