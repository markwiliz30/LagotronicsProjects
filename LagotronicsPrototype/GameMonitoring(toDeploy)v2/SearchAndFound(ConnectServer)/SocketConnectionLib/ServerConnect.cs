using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocketConnectionLib;
using MagicStoneKingdomDeviceControl.Helper;

namespace SearchAndFoundNewTest
{
    public partial class ServerConnect : Form
    {
        public bool parentFormClose = false;
        private SendReceive Respond;
        public int connected = 0;
        public ServerConnect()
        {
            InitializeComponent();
        }

        private void ServerConnect_Load(object sender, EventArgs e)
        {
            
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }
        private void ConnectToServer()
        {
            int portRes;
            if (txtIP.text.Length <= 0 || txtPort.text.Length <= 0)
            {
                MessageBox.Show("Please Enter the IP Address and Port of the Server");
            }
            else if (!NetworkHelper.CheckIPAddressSyntax(txtIP.text))
            {
                MessageBox.Show("Wrong IP Address Syntax!");
            }
            else if (!int.TryParse(txtPort.text, out portRes))
            {
                MessageBox.Show("Invalid Port");
            }
            else
            {
                Respond = new SendReceive();
                //var holdResult = mySendReceive.ConnectToServer(txtIP.text, Convert.ToInt32(txtPort.text));
                var holdResult = SocketConnectionLib.Respond.LoopConnect(txtIP.text, Convert.ToInt32(txtPort.text));
                if (holdResult != "Connected")
                {
                    MessageBox.Show(holdResult);
                    return;
                }
                MessageBox.Show(holdResult);
                checkConnectionTimer.Start();
                connected = 2;
                Hide();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (connected == 1)
            {
                var result = MessageBox.Show("Ang server ay hindi nakasindi. mawawala ang data kapag sinara ang application. Sigurado kaba na gusto mong isara ang application na ito?", "Babala", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    parentFormClose = true;
                    Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                Close();
                Owner.Close();
            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void checkConnectionTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                SocketConnectionLib.Respond.SendToServer(".");
            }
            catch
            {
                if (!SocketConnectionLib.Respond._publicClientSocket.Connected)
                {
                    Respond._publicClientSocket.Close();
                    connected = 1;
                    Show();
                }
            }
        }

        private void ServerConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*try
            {
                DisconnectFromServer();
                Owner.Close();
            }
            catch
            {
                var result = MessageBox.Show("Ang server ay hindi nakasindi. mawawala ang data kapag sinara ang application. Sigurado kaba na gusto mong isara ang application na ito?", "Babala", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    return;
                }
                e.Cancel = true;
            }*/
        }
        private void DisconnectFromServer()
        {
            Respond = new SendReceive();
            string deviceInfo = System.Environment.MachineName + " " + Respond._publicClientSocket.LocalEndPoint.ToString();
            Respond.SendToServer("-" + deviceInfo);
        }
    }
}
