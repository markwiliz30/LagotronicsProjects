using MagicStoneKingdomDeviceControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchAndFoundNewTest
{
    public partial class MagicStoneKingdomDeviceControlTestingPanelForm : Form, IDeviceControllerForm
    {
        private bool synchronizingFormControls;
        private MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager;
        private Dictionary<IMagicStoneKingdomDeviceController, IDeviceControllerForm> controllerFormTable = new Dictionary<IMagicStoneKingdomDeviceController, IDeviceControllerForm>();
        private IContainer components1;
        public MagicStoneKingdomDeviceControlTestingPanelForm()
        {
            InitializeComponent();
            MagicStoneKingdomDeviceControlManager.Initialize();
            magicStoneKingdomDeviceControlManager = new MagicStoneKingdomDeviceControlManager();
        }

        public void SynchronizeFormControls()
        {
            synchronizingFormControls = true;
            foreach (IMagicStoneKingdomDeviceController key in controllerFormTable.Keys)
                controllerFormTable[key].SynchronizeFormControls();
            synchronizingFormControls = false;
        }

        private void DisconnectDevices()
        {
            if (magicStoneKingdomDeviceControlManager == null)
                return;
            magicStoneKingdomDeviceControlManager.DisconnectAllControllers();
        }

        private void MagicStoneKingdomDeviceControlTestingPanelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (MessageBox.Show("Are you sure you want to quit this program?", "Quit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
                return;
            e.Cancel = true;*/
        }

        private void IOCabinetControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (IMagicStoneKingdomDeviceController key in controllerFormTable.Keys)
                controllerFormTable[key].Close();
            DisconnectDevices();
            MagicStoneKingdomDeviceControlManager.End();
        }

        private void timerFormSynchronization_Tick(object sender, EventArgs e)
        {
            SynchronizeFormControls();
        }
        private void nPortSerialDeviceServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NPortControllerConnectionForm controllerConnectionForm = new NPortControllerConnectionForm(magicStoneKingdomDeviceControlManager);
            if (controllerConnectionForm.ShowDialog() != DialogResult.OK)
                return;
            Form1 form1 = new Form1(magicStoneKingdomDeviceControlManager, controllerConnectionForm.Controller_1, controllerConnectionForm.Controller_2, controllerConnectionForm.Controller_btn_1);
            form1.ShowDialog();
            //controllerFormTable.Add((IMagicStoneKingdomDeviceController)controllerConnectionForm.Controller, (IDeviceControllerForm)nportControllerForm);
            Close();
        }

        /*private void ioLogikE1210DigitalInputServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOLogikE1210ControllerConnectionForm controllerConnectionForm = new IOLogikE1210ControllerConnectionForm(magicStoneKingdomDeviceControlManager);
            if (controllerConnectionForm.ShowDialog() != DialogResult.OK)
                return;
            IOLogikE1210ControllerForm e1210ControllerForm = new IOLogikE1210ControllerForm(this.magicStoneKingdomDeviceControlManager, controllerConnectionForm.Controller);
            e1210ControllerForm.Show();
            //controllerFormTable.Add((IMagicStoneKingdomDeviceController)controllerConnectionForm.Controller, (IDeviceControllerForm)e1210ControllerForm);
        }*/
        private void MagicStoneKingdomDeviceControlTestingPanelForm_Load(object sender, EventArgs e)
        {
            Invoke(new EventHandler(nPortSerialDeviceServerToolStripMenuItem_Click));
        }
    }
}
