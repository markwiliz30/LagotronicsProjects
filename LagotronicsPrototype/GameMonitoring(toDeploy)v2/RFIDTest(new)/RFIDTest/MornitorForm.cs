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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using AsyncCallBack;
using AsyncCallBack.ConverterClasses;

namespace RFIDTest
{
    public partial class MornitorForm : Form
    {
        public MornitorForm()
        {
            InitializeComponent();
            //SocketConnect.SetupServer();
            CallBack.SetupServer();
        }
        private InsertForm myInsertForm;
        private FirebaseClass myFirebase;
        private List<UserItem> userList;
        private static List<UserItem> oldUserList;
        private  List<ConvertItem> sfScoresList;
        private  List<ConvertItem> sfLoadedScoresList = new List<ConvertItem>();
        private List<ConvertItem> cogScoresList;
        private List<ConvertItem> cogLoadedScoresList = new List<ConvertItem>();
        private bool set = false;
        private string idHold;
        private int expectGuestNum, clientCount, holdSFScores = 0, holdSFLoadedScores = 0, holdCogScores = 0, holdCogLoadedScores = 0, holdDataToConvertCount = 0;

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void onOffSwitch_OnValueChange(object sender, EventArgs e)
        {

        }

        private void btnLoadForm_Click(object sender, EventArgs e)
        {
            myInsertForm = new InsertForm();
            myInsertForm.ShowDialog();
            SetInGridView();
        }

        private void MornitorForm_Load(object sender, EventArgs e)
        {
            holdDataToConvertCount = CallBack.dataToConvert.Count;
            CheckDbConnection();
            LoadConnectedDevices();
            try
            {
                LoadTodayScores();
            }
            catch{ }
        }
        private void HideSFColums()
        {
            gridSF.Columns[2].Visible = false;
            gridSF.Columns[4].Visible = false;
            gridSF.Columns[5].Visible = false;
        }
        private void HideCogColums()
        {
            gridCog.Columns[2].Visible = false;
            gridCog.Columns[4].Visible = false;
            gridCog.Columns[5].Visible = false;
        }
        private void LoadScores()
        {
            holdSFScores = CallBack.dataToConvert.Count;
            ConvertManager myConvertManager = new ConvertManager();
            foreach (var item in CallBack.dataToConvert)
            {
                var myConvItem = new ConvertItem();
                myConvItem = myConvertManager.convertToItem(item);
                sfScoresList.Add(myConvItem);
            }
            gridSF.DataSource = sfScoresList;
        }
        private void LoadTodayScores()
        {
            CallBack myCallBack = new CallBack();
            var retreiveScores = myCallBack.DataCollection();
            ConvertManager myConvertManager = new ConvertManager();
            sfLoadedScoresList = new List<ConvertItem>();
            cogLoadedScoresList = new List<ConvertItem>();
            foreach (var item in retreiveScores)
            {
                var myConvItem = new ConvertItem();
                myConvItem = myConvertManager.convertToItem(item);
                if (myConvItem.date == DateTime.Today.ToShortDateString() && myConvItem.appName == "Search_And_Found")
                {
                    sfLoadedScoresList.Add(myConvItem);
                }
                if (myConvItem.date == DateTime.Today.ToShortDateString() && myConvItem.appName == "Cognitive")
                {
                    cogLoadedScoresList.Add(myConvItem);
                }
            }
            holdSFLoadedScores = sfLoadedScoresList.Count;
            holdCogLoadedScores = cogLoadedScoresList.Count;
            holdSFScores = sfLoadedScoresList.Count;
            holdCogScores = cogLoadedScoresList.Count;
            lblSFcounter.Text = holdSFScores.ToString();
            lblCogCounter.Text = holdCogScores.ToString();
            sfScoresList = new List<ConvertItem>(sfLoadedScoresList);
            cogScoresList = new List<ConvertItem>(cogLoadedScoresList);
            gridSF.DataSource = sfScoresList;
            gridCog.DataSource = cogScoresList;
            try
            {
                LoadSFTopScores();
                LoadCogTopScores();
            }
            catch{}
            HideSFColums();
            HideCogColums();
        }
        private void LoadSFTopScores()
        {
            var topSfList = sfScoresList.OrderByDescending(x => x.score).Take(10).ToList();
            gridSFTopScore.DataSource = topSfList;
            gridSFTopScore.Columns[2].Visible = false;
            gridSFTopScore.Columns[4].Visible = false;
            gridSFTopScore.Columns[5].Visible = false;
        }
        private void LoadCogTopScores()
        {
            var topCogList = cogScoresList.OrderByDescending(x => x.score).Take(10).ToList();
            gridCogTopScore.DataSource = topCogList;
            gridCogTopScore.Columns[2].Visible = false;
            gridCogTopScore.Columns[4].Visible = false;
            gridCogTopScore.Columns[5].Visible = false;
        }
        private void LoadConnectedDevices()
        {
            foreach (var item in CallBack._clientSockets)
            {
                int i = 0;
                var holdItemString = item.RemoteEndPoint.ToString();
                byte[] holdItemByte = new byte[holdItemString.Length];
                holdItemByte = Encoding.ASCII.GetBytes(holdItemString);
                byte[] ipGetByte = new byte[holdItemString.Length];
                while (holdItemByte[i] != 58)
                {
                    ipGetByte[i] = holdItemByte[i];
                    i++;
                }
                byte[] ipToConvert = new byte[i];
                ipToConvert = ipGetByte;
                string ipGet = Encoding.ASCII.GetString(ipToConvert);
                i = 0;
                if (ipGet != "192.168.127.74")
                {
                    lstConnectedDevices.Items.Add(item.RemoteEndPoint);
                }
            }
            lstConnectedDevices.Sorted = true;
            clientCount = CallBack._clientSockets.Count;
        }
        private void UpdateConnectedLstDevices()
        {
            if (clientCount != CallBack._clientSockets.Count)
            {
                lstConnectedDevices.Items.Clear();
                foreach (var updatedItems in CallBack._clientSockets)
                {
                    int i = 0;
                    var holdItemString = updatedItems.RemoteEndPoint.ToString();
                    byte[] holdItemByte = new byte[holdItemString.Length];
                    holdItemByte = Encoding.ASCII.GetBytes(holdItemString);
                    byte[] ipGetByte = new byte[holdItemString.Length];
                    while (holdItemByte[i] != 58)
                    {
                        ipGetByte[i] = holdItemByte[i];
                        i++;
                    }
                    byte[] ipToConvert = new byte[i];
                    Array.Copy(ipGetByte, ipToConvert, i);
                    string ipGet = Encoding.ASCII.GetString(ipToConvert);
                    i = 0;
                    if (ipGet != "192.168.127.74")
                    {
                        lstConnectedDevices.Items.Add(updatedItems.RemoteEndPoint);
                    }
                }
                lstConnectedDevices.Sorted = true;
                clientCount = CallBack._clientSockets.Count;
            }
        }
        private void UpdateSFGuestCount()
        {
            lblSFcounter.Text = (holdSFLoadedScores + CallBack.sfCounter).ToString();
        }
        private void UpdateCogGuestCount()
        {
            lblCogCounter.Text = (holdCogLoadedScores + CallBack.cogCounter).ToString();
        }
        private void CheckDbConnection()
        {
            if (!ConnectToDb())
            {
                Close();
            }
            set = true;
        }
        private bool ConnectToDb()
        {
            myFirebase = new FirebaseClass();
            var check = myFirebase.RequireCredits("Sx8dMHGYsTKxGohDaYV2KjV9BuvlZdl5QSmY4jWV", "https://rfidtest-931fa.firebaseio.com/");
            MessageBox.Show(check);
            if (check == "Connection Fail")
            {
                return false;
            }
            return true;
        }
        private async Task<List<UserItem>> LoadUsers()
        {
            myFirebase = new FirebaseClass();
            userList = new List<UserItem>();

            userList = await myFirebase.GetAllUsers();
            return userList;
        }
        private async void SetInGridView()
        {
            gridGuest.DataSource = null;
            gridGuest.Rows.Clear();
            oldUserList = await LoadUsers();
            if (txtGuestSearch.text != "" || txtGuestSearch.text != null)
            {
                if (oldUserList != null)
                {
                    var fileteredList = oldUserList.FindAll(str => str.Name.Contains(txtGuestSearch.text) || str.RF_ID.Contains(txtGuestSearch.text.ToUpper()));
                    gridGuest.DataSource = fileteredList;
                }
            }
            else
            {
                gridGuest.DataSource = oldUserList;
            }
            gridGuest.Update();
            gridGuest.Refresh();
            if (oldUserList != null)
            {
                expectGuestNum = oldUserList.Count;
            }
            else
            {
                expectGuestNum = 0;
            }
            lblGuestsCount.Text = expectGuestNum.ToString();
        }
        private void DbChecker_Tick(object sender, EventArgs e)
        {
            SetInGridView();
        }

        private void gridGuest_Paint(object sender, PaintEventArgs e)
        {
            if (set)
            {
                SetInGridView();
                set = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (idHold == null || idHold == "")
            {
                MessageBox.Show("Plaese Select user to delete");
                return;
            }
            var result = MessageBox.Show("Do you want to delete this user?", "Are you sure?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteUser();
                idHold = null;
            }
        }
        private async void DeleteUser()
        {
            myFirebase = new FirebaseClass();
            MessageBox.Show(await myFirebase.DeleteUser(idHold));
            SetInGridView();
        }

        private void gridGuest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idHold = gridGuest.Rows[e.RowIndex].Cells["RF_ID"].FormattedValue.ToString();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to delet all users", "Are you sure?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteAllUsers();
            }
        }
        private async void DeleteAllUsers()
        {
            myFirebase = new FirebaseClass();
            MessageBox.Show(await myFirebase.DeleteAllUser());
            SetInGridView();
        }

        private void txtGuestSearch_OnTextChange(object sender, EventArgs e)
        {
            if (gridGuest.Rows.Count != 0)
            {
                if (txtGuestSearch.text == "")
                {
                    gridGuest.DataSource = oldUserList;
                }
                else
                {
                    var fileteredList = oldUserList.FindAll(str => str.Name.Contains(txtGuestSearch.text) || str.RF_ID.Contains(txtGuestSearch.text.ToUpper()));
                    gridGuest.DataSource = fileteredList;
                }
            }
            else
            {
                gridGuest.DataSource = oldUserList;
            }
        }

        private void MornitorForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            lstEventLogs.Items.Clear();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectDevice();
        }
        private void DisconnectDevice()
        {
            try
            {
                var result = MessageBox.Show("Do you want to disconnect this device?", "Are you sure?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                Socket removeSelSocket = CallBack._clientSockets.Find(p => p.RemoteEndPoint.ToString() == lstConnectedDevices.SelectedItem.ToString());
                CallBack._clientSockets.Remove(removeSelSocket);
                lstEventLogs.Items.Add(removeSelSocket.RemoteEndPoint + " Disconnection Sucess");
                removeSelSocket.Shutdown(SocketShutdown.Both);
                removeSelSocket.Close();
                lstConnectedDevices.Items.Remove(lstConnectedDevices.SelectedItem);
                MessageBox.Show("Disconnection Successful");
                }
            }
            catch
            {
                MessageBox.Show("Please Select IP Address to disconnect");
            }
        }

        private void btnDisconnectAll_Click(object sender, EventArgs e)
        {
            DisconnectAll();
        }
        private void DisconnectAll()
        {
            if (CallBack._clientSockets.Count == 0)
            {
                MessageBox.Show("No device(s) to disconnect");
                return;
            }
            var result = MessageBox.Show("Do you want to disconnect all devices?", "Are you sure?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                while (CallBack._clientSockets.Count != 0)
                {
                    Socket removeSocket = CallBack._clientSockets.Find(p => p.RemoteEndPoint.ToString() == lstConnectedDevices.Items[0].ToString());
                    CallBack._clientSockets.Remove(removeSocket);
                    lstEventLogs.Items.Add(removeSocket.RemoteEndPoint + " Disconnection Sucess");
                    lstConnectedDevices.Items.Remove(removeSocket.RemoteEndPoint);
                    try
                    {
                        removeSocket.Shutdown(SocketShutdown.Both);
                        removeSocket.Close();
                    }
                    catch
                    {

                    }
                }
                MessageBox.Show("Disconnection of all devices successful");
            }
        }

        private void lstEventLogs_ControlAdded(object sender, ControlEventArgs e)
        {
            //lstEventLogs.SelectedIndex = lstEventLogs.Items.Count - 1;
        }

        private void lstEventLogs_DisplayMemberChanged(object sender, EventArgs e)
        {
            //lstEventLogs.SelectedIndex = lstEventLogs.Items.Count - 1;
        }

        private void lstEventLogs_DrawItem(object sender, DrawItemEventArgs e)
        {
            lstEventLogs.SelectedIndex = lstEventLogs.Items.Count - 1;
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            CallBack.SetupServer();
        }

        private void gridSF_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnSearchGuestLoc_Click(object sender, EventArgs e)
        {
            FindUser();
        }

        private void MornitorForm_MaximumSizeChanged(object sender, EventArgs e)
        {

        }

        private void FindUser()
        {
            var UserLocList = sfScoresList.OrderByDescending(x => x.date).ThenByDescending(t => t.time).ToList();
            var UserLocItem = UserLocList.Find(y => y.rfId == txtSearchGuestLoc.text.ToUpper());
            lblRfId.Text = UserLocItem.rfId;
            lblName.Text = UserLocItem.name;
            lblGameLastVisit.Text = UserLocItem.appName;
        }

        private void lstConnectedDevices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void logTimer_Tick(object sender, EventArgs e)
        {
            UpdateConnectedLstDevices();
            UpdateSFGuestCount();
            UpdateCogGuestCount();
            UpdateSFGrid();
            UpdateCogGrid();
            while (CallBack.logMsg.Count != 0)
            {
                foreach (var item in CallBack.logMsg)
                {
                    lstEventLogs.Items.Add(item);
                }
                CallBack.logMsg.Clear();
            }
            lstEventLogs.SelectedIndex = lstEventLogs.Items.Count - 1;
        }
        private void UpdateSFGrid()
        {
            if (holdSFScores != holdSFLoadedScores + CallBack.sfCounter && holdDataToConvertCount != CallBack.dataToConvert.Count)
            {
                gridSF.DataSource = null;
                gridSF.Rows.Clear();
                ConvertManager myConvertManager = new ConvertManager();
                sfScoresList = new List<ConvertItem>(sfLoadedScoresList);
                foreach (var item in CallBack.dataToConvert)
                {
                    var myConvItem = new ConvertItem();
                    myConvItem = myConvertManager.convertToItem(item);
                    if (myConvItem.appName == "Search_And_Found")
                    {
                        sfScoresList.Add(myConvItem);
                    }
                }
                holdDataToConvertCount = CallBack.dataToConvert.Count;
                holdSFScores = holdSFLoadedScores + CallBack.sfCounter;
                gridSF.DataSource = sfScoresList;
                LoadSFTopScores();
                HideSFColums();
                gridSF.Update();
                gridSF.Refresh();
                //holdSFScores = holdSFLoadedScores + CallBack.dataToConvert.Count;
            }
        }
        private void UpdateCogGrid()
        {
            if (holdCogScores != holdCogLoadedScores + CallBack.cogCounter && holdDataToConvertCount != CallBack.dataToConvert.Count)
            {
                gridCog.DataSource = null;
                gridCog.Rows.Clear();
                ConvertManager myConvertManager = new ConvertManager();
                cogScoresList = new List<ConvertItem>(cogLoadedScoresList);
                foreach (var item in CallBack.dataToConvert)
                {
                    var myConvItem = new ConvertItem();
                    myConvItem = myConvertManager.convertToItem(item);
                    if (myConvItem.appName == "Cognitive")
                    {
                        cogScoresList.Add(myConvItem);
                    }
                }
                holdDataToConvertCount = CallBack.dataToConvert.Count;
                holdCogScores = holdCogLoadedScores + CallBack.cogCounter;
                gridCog.DataSource = cogScoresList;
                LoadCogTopScores();
                HideCogColums();
                gridCog.Update();
                gridCog.Refresh();
                //holdCogScores = holdCogLoadedScores + CallBack.dataToConvert.Count;
            }
        }
    }
}
