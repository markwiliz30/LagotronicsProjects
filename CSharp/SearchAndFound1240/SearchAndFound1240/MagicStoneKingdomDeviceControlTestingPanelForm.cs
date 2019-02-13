using MagicStoneKingdomDeviceControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SearchAndFound1240
{
    public partial class MagicStoneKingdomDeviceControlTestingPanelForm : Form, IDeviceControllerForm
    {
        private bool synchronizingFormControls;
        private MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager;
        private Dictionary<IMagicStoneKingdomDeviceController, IDeviceControllerForm> controllerFormTable = new Dictionary<IMagicStoneKingdomDeviceController, IDeviceControllerForm>();
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
        private void ioLogikE1240AnalogInputServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOLogikE1240ControllerConnectionForm controllerConnectionForm = new IOLogikE1240ControllerConnectionForm(magicStoneKingdomDeviceControlManager);
            if (controllerConnectionForm.ShowDialog() != DialogResult.OK)
                return;
            IOLogikE1240ControllerForm e1240ControllerForm = new IOLogikE1240ControllerForm(magicStoneKingdomDeviceControlManager, controllerConnectionForm.Controller_1, controllerConnectionForm.Controller_2 );
            e1240ControllerForm.ShowDialog();
            //controllerFormTable.Add((IMagicStoneKingdomDeviceController)controllerConnectionForm.Controller, (IDeviceControllerForm)e1240ControllerForm);
            Close();
        }

        private void MagicStoneKingdomDeviceControlTestingPanelForm_Load(object sender, EventArgs e)
        {
            Invoke(new EventHandler(ioLogikE1240AnalogInputServerToolStripMenuItem_Click));
        }
    }
}
