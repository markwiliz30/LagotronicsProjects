using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworkLib;

namespace Server
{
    public partial class Client1 : Form
    {
        AsyncClient client = new AsyncClient();

        public Client1()
        {
            InitializeComponent();
            AsyncServer.SetupServer();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                client.SendString(txt_msg.Text);
                string response = AsyncClient.ReceiveResponse();
                lst_sent.Items.Add(txt_msg.Text);
                lst_received.Items.Add(response);
                txt_msg.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Error Connection");
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            string conStatus = client.ConnectToServer(txt_ip.Text);
            MessageBox.Show(conStatus);
        }

        private void message_check_Tick(object sender, EventArgs e)
        {
            if (AsyncServer.message != "")
            {
                lst_received.Items.Add(AsyncServer.message);
                AsyncServer.message = "";
            }
        }
    }
}
