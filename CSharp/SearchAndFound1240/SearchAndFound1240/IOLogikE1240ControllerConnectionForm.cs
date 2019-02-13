using MagicStoneKingdomDeviceControl;
using MagicStoneKingdomDeviceControl.Helper;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SearchAndFound1240
{
    public partial class IOLogikE1240ControllerConnectionForm : Form
    {
        private MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager_1, magicStoneKingdomDeviceControlManager_2;
        public IOLogikE1240AnalogInputServerController Controller_1;
        public IOLogikE1210DigitalInputServerController Controller_2;
        public IOLogikE1240ControllerConnectionForm(MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager)
        {
            InitializeComponent();
            magicStoneKingdomDeviceControlManager_1 = magicStoneKingdomDeviceControlManager;
            magicStoneKingdomDeviceControlManager_2 = magicStoneKingdomDeviceControlManager;
        }
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            /*if (textBoxName.Text.Length <= 0)
            {
                int num1 = (int)MessageBox.Show("Please enter a name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (!NetworkHelper.CheckIPAddressSyntax(textBoxIPAddress.Text))
            {
                int num2 = (int)MessageBox.Show("IP address syntax error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }*/
            if (!magicStoneKingdomDeviceControlManager_1.ConnectIOLogikE1240AnalogInputServerController("m", "192.168.127.50"))
            {
                int num3 = (int)MessageBox.Show("Device controller connection Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (!magicStoneKingdomDeviceControlManager_2.ConnectIOLogikE1210DigitalInputServerController("n", "192.168.127.51"))
            {
                int num5 = (int)MessageBox.Show("Device controller connection Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                Controller_1 = magicStoneKingdomDeviceControlManager_1.GetIOLogikE1240AnalogInputServerController("m");
                Controller_2 = magicStoneKingdomDeviceControlManager_2.GetIOLogikE1210DigitalInputServerController("n");
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void IOLogikE1240ControllerConnectionForm_Load(object sender, EventArgs e)
        {
            Invoke(new EventHandler(buttonConnect_Click));
        }
    }
}
