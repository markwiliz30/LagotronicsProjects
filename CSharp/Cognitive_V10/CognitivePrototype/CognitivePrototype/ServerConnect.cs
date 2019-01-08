using AsyncCallBack;
using MagicStoneKingdomDeviceControl.Helper;
using SavingDataLib.TransferClasses;
using SocketConnectionLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CognitivePrototype
{
    public partial class ServerConnect : Form
    {
        public bool parentFormClose = false;
        private SendReceive Respond;
        public int connected = 0;
        StringTransferItem SFItem;
        TransferManager SFTManager;
        public ServerConnect()
        {
            InitializeComponent();
            CallBack.SetupServer();
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
            else
            {
                Respond = new SendReceive();
                //var holdResult = mySendReceive.ConnectToServer(txtIP.text, Convert.ToInt32(txtPort.text));
                string holdResult = null;
                try
                {
                    holdResult = SocketConnectionLib.Respond.LoopConnect(txtIP.text, Convert.ToInt32(txtPort.text));
                }
                catch
                {
                    MessageBox.Show("Incorrect Ip syntax");
                    return;
                }
                
                if (holdResult != "Connected")
                {
                    MessageBox.Show(holdResult);
                    return;
                }
                MessageBox.Show(holdResult);
                checkConnectionTimer.Start();
                connected = 2;
                parentFormClose = false;
                Hide();
            }
        }
        public void TransferData(string signature, string appName, string score, string id, string user)
        {
            SFItem = new StringTransferItem();
            SFTManager = new TransferManager();
            SFItem.TransSignature = signature;
            SFItem.AppName = appName;
            SFItem.Score = score;
            SFItem.ID = id;
            SFItem.User = user;

            SFTManager.SetAndSend(SFItem);
        }
        public void SendScore(string rfid, string hits, string balance)
        {
            Respond myRespond = new Respond();
            SocketConnectionLib.Respond.SendUpdatedData2(rfid, hits, balance);
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
                parentFormClose = true;
                Close();
                //Owner.Close();
            }
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
        private void DisconnectFromServer()
        {
            Respond = new SendReceive();
            string deviceInfo = System.Environment.MachineName + " " + Respond._publicClientSocket.LocalEndPoint.ToString();
            Respond.SendToServer("-" + deviceInfo);
        }
    }
}
