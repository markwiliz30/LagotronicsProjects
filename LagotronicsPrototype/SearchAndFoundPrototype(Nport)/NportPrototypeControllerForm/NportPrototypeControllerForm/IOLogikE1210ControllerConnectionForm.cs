using MagicStoneKingdomDeviceControl;
using MagicStoneKingdomDeviceControl.Helper;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace NportPrototypeControllerForm
{
    public partial class IOLogikE1210ControllerConnectionForm : Form
    {
        private MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager;
        public IOLogikE1210DigitalInputServerController Controller;

        string name = "ioLogik1210", IpAdd = "192.168.127.50";
        public IOLogikE1210ControllerConnectionForm(MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager)
        {
            InitializeComponent();
            this.magicStoneKingdomDeviceControlManager = magicStoneKingdomDeviceControlManager;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (!NetworkHelper.CheckIPAddressSyntax(IpAdd))
            {
                int num2 = (int)MessageBox.Show("IP address syntax error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (!magicStoneKingdomDeviceControlManager.ConnectIOLogikE1210DigitalInputServerController(name, IpAdd))
            {
                int num3 = (int)MessageBox.Show("Device controller connection Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                Controller = this.magicStoneKingdomDeviceControlManager.GetIOLogikE1210DigitalInputServerController(name);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
