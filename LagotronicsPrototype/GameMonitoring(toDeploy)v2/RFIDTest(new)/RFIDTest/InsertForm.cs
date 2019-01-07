using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebaseLib;

namespace RFIDTest
{
    public partial class InsertForm : Form
    {
        FirebaseClass myFirebase;
        UserItem user;
        string rfId;
        string holdId;
        bool read = false, isComing = false;
        public InsertForm()
        {
            InitializeComponent();
            try
            {
                rfPort.Open();
            }
            catch
            {
            }
        }

        MediaPlayer.MediaPlayer soundFx;

        private  void rfPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            rfId = rfPort.ReadLine();
            isComing = true;
            var rfViaPort = rfId.Remove(rfId.Length -1);
            GetValues(rfViaPort);
        }

        private async void GetValues(string myId)
        {
            holdId = myId;

            myFirebase = new FirebaseClass();
            user = new UserItem();
            user = await myFirebase.CheckExisting(holdId);
            read = true;
        }
        private void DisableControls()
        {
            txtName.Enabled = false;
            txtLoad.Enabled = false;
            txtScAcc.Enabled = false;

            btnOK.Enabled = false;
            btnCancel.Enabled = false;
        }
        private void EnableControls()
        {
            txtName.Enabled = true;
            txtLoad.Enabled = true;
            txtScAcc.Enabled = true;

            btnOK.Enabled = true;
            btnCancel.Enabled = true;

            isComing = false;
        }
        void PlayFx(string audioPath)
        {
            soundFx = new MediaPlayer.MediaPlayer();
            soundFx.Open(audioPath);
            soundFx.Play();
        }
        private void check_Tick(object sender, EventArgs e)
        {
            if (AsyncCallBack.CallBack.rfId != null && AsyncCallBack.CallBack.rfId != "")
            {
                rfId = AsyncCallBack.CallBack.rfId.ToUpper();
                AsyncCallBack.CallBack.rfId = "";
                isComing = true;
                GetValues(rfId);
            }
            if (rfId != null && read)
            {
                lblId.Text = holdId;
                PlayFx(@"./Mounted.wav");
                if (user != null)
                {
                    txtName.text = user.Name;
                    txtBalance.text = user.Balance;
                    txtScAcc.text = user.Sc_Account;
                }
                else
                {
                    txtName.text = "";
                    txtBalance.text = "0";
                    txtScAcc.text = "";
                }
                read = false;
                EnableControls();
            }

            if (isComing)
            {
                DisableControls();
            }
            /*if (lblId.Text == "0E64708B")
            {
                label2.Text = "granted";
            }
            else
            {
                label2.Text = "denied";
            }*/
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            ClearForm();
            if (lblId.Text == "")
            {
                DisableControls();
            }
        }
        private void ClearForm()
        {
            rfId = null;
            holdId = null;
            txtName.text = "";
            txtLoad.text = "";
            txtScAcc.text = "";
            txtBalance.text = "0";
            lblId.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtBalance.text = "0";
            if (lblId.Text == "")
            {
                DisableControls();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AddUser();
        }
        private void AddUser()
        {
            myFirebase = new FirebaseClass();
            DateTime date = DateTime.Now;
            string _Date = date.ToString("MM:dd:yyyy");
            string _Time = date.ToString("HH:mm");

            if (!FormValidation())
            {
                return;
            }
            if (txtLoad.text == "")
            {
                txtLoad.text = "0";
            }
            try
            {
                myFirebase.SaveUser(lblId.Text, txtName.text, Convert.ToInt32(txtLoad.text), Convert.ToInt32(txtBalance.text), "0", txtScAcc.text, _Date, _Time);
                MessageBox.Show("Success");
                ClearForm();
                if (lblId.Text == "")
                {
                    DisableControls();
                }
            }
            catch
            {
                MessageBox.Show("Fail");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InsertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            rfPort.Close();
            Dispose();
        }

        private bool FormValidation()
        {
            if (rfId == null)
            {
                MessageBox.Show("Please put RFID");
                return false;
            }
            if (txtName.text == "")
            {
                MessageBox.Show("Please enter user's Name");
                return false;
            }
            return true;
        }
    }
}
