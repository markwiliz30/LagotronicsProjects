using MagicStoneKingdomDeviceControl;
using MagicStoneKingdomDeviceControl.Helper;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SearchAndFoundNewTest
{
    public partial class NPortControllerConnectionForm : Form
    {
        private MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager_1, magicStoneKingdomDeviceControlManager_2, magicStoneKingdomDeviceControlManager_btn_1;
        public NPortSerialDeviceServerController Controller_1, Controller_2;
        public IOLogikE1210DigitalInputServerController Controller_btn_1;
        string ConnectionName = "Encoder", IPAdd = "192.168.127.254", ConnectionName2 = "Encoder2", IPAdd2 = "192.168.127.253", btnConnectName = "ioLogik1210", btnIpAdd = "192.168.127.51";
        public NPortControllerConnectionForm(MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager)
        {
            InitializeComponent();
            magicStoneKingdomDeviceControlManager_2 = magicStoneKingdomDeviceControlManager;
            magicStoneKingdomDeviceControlManager_1 = magicStoneKingdomDeviceControlManager;
            magicStoneKingdomDeviceControlManager_btn_1 = magicStoneKingdomDeviceControlManager;
            foreach (NPortBaudRate nportBaudRate in Enum.GetValues(typeof(NPortBaudRate)))
                comboBoxBaudRate.Items.Add((object)nportBaudRate);
            comboBoxBaudRate.SelectedItem = (object)NPortBaudRate.bps9600;
            foreach (NPortBitCount nportBitCount in Enum.GetValues(typeof(NPortBitCount)))
                comboBoxBitCount.Items.Add((object)nportBitCount);
            comboBoxBitCount.SelectedItem = (object)NPortBitCount.Eight;
            foreach (NPortStopBit nportStopBit in Enum.GetValues(typeof(NPortStopBit)))
                comboBoxStopBit.Items.Add((object)nportStopBit);
            comboBoxStopBit.SelectedItem = (object)NPortStopBit.One;
            foreach (NPortParity nportParity in Enum.GetValues(typeof(NPortParity)))
                comboBoxParity.Items.Add((object)nportParity);
            comboBoxParity.SelectedItem = (object)NPortParity.None;
        }

        private void NPortControllerConnectionForm_Load(object sender, EventArgs e)
        {
            textBoxName.Text = ConnectionName;
            textBoxIPAddress.Text = IPAdd;
            Invoke(new EventHandler(buttonConnect_Click));
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
            if (!magicStoneKingdomDeviceControlManager_1.ConnectNPortSerialDeviceServerController(ConnectionName, IPAdd, (NPortBaudRate)comboBoxBaudRate.SelectedItem, (NPortBitCount)comboBoxBitCount.SelectedItem, (NPortStopBit)comboBoxStopBit.SelectedItem, (NPortParity)comboBoxParity.SelectedItem, (uint)numericUpDownWriteTimeout.Value, (uint)numericUpDownReadTimeout.Value))
            {
                int num3 = (int)MessageBox.Show("Device controller connection Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (!magicStoneKingdomDeviceControlManager_2.ConnectNPortSerialDeviceServerController(ConnectionName2, IPAdd2, (NPortBaudRate)comboBoxBaudRate.SelectedItem, (NPortBitCount)comboBoxBitCount.SelectedItem, (NPortStopBit)comboBoxStopBit.SelectedItem, (NPortParity)comboBoxParity.SelectedItem, (uint)numericUpDownWriteTimeout.Value, (uint)numericUpDownReadTimeout.Value))
            {
                int num4 = (int)MessageBox.Show("Device controller connection Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (!magicStoneKingdomDeviceControlManager_btn_1.ConnectIOLogikE1210DigitalInputServerController(btnConnectName, btnIpAdd))
            {
                int num5 = (int)MessageBox.Show("Device controller connection Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                Controller_1 = magicStoneKingdomDeviceControlManager_1.GetNPortSerialDeviceServerController(ConnectionName);
                Controller_2 = magicStoneKingdomDeviceControlManager_2.GetNPortSerialDeviceServerController(ConnectionName2);
                Controller_btn_1 = magicStoneKingdomDeviceControlManager_btn_1.GetIOLogikE1210DigitalInputServerController(btnConnectName);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
