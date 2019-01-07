using MagicStoneKingdomDeviceControl;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TestingPanelResources;

namespace NportPrototypeControllerForm
{
    public partial class IOLogikE1210ControllerForm : Form, IDeviceControllerForm
    {
        private MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager;
        private IOLogikE1210DigitalInputServerController controller;
        private bool synchronizingFormControls;
        bool trig;
        DigitalSignalUI digitalSignalUi;
        //private DigitalSignalUI digitalSignalUIDI0;
        /*private DigitalSignalUI digitalSignalUIDI1;
        private DigitalSignalUI digitalSignalUIDI2;
        private DigitalSignalUI digitalSignalUIDI3;
        private DigitalSignalUI digitalSignalUIDI4;
        private DigitalSignalUI digitalSignalUIDI5;
        private DigitalSignalUI digitalSignalUIDI6;
        private DigitalSignalUI digitalSignalUIDI7;
        private DigitalSignalUI digitalSignalUIDI15;
        private DigitalSignalUI digitalSignalUIDI14;
        private DigitalSignalUI digitalSignalUIDI13;
        private DigitalSignalUI digitalSignalUIDI12;
        private DigitalSignalUI digitalSignalUIDI11;
        private DigitalSignalUI digitalSignalUIDI10;
        private DigitalSignalUI digitalSignalUIDI9;
        private DigitalSignalUI digitalSignalUIDI8;*/

        /*private void InitializeComponent_1()
        {
            digitalSignalUIDI15 = new DigitalSignalUI();
            digitalSignalUIDI14 = new DigitalSignalUI();
            digitalSignalUIDI13 = new DigitalSignalUI();
            digitalSignalUIDI12 = new DigitalSignalUI();
            digitalSignalUIDI11 = new DigitalSignalUI();
            digitalSignalUIDI10 = new DigitalSignalUI();
            digitalSignalUIDI9 = new DigitalSignalUI();
            digitalSignalUIDI8 = new DigitalSignalUI();
            digitalSignalUIDI7 = new DigitalSignalUI();
            digitalSignalUIDI6 = new DigitalSignalUI();
            digitalSignalUIDI5 = new DigitalSignalUI();
            digitalSignalUIDI4 = new DigitalSignalUI();
            digitalSignalUIDI3 = new DigitalSignalUI();
            digitalSignalUIDI2 = new DigitalSignalUI();
            digitalSignalUIDI1 = new DigitalSignalUI();
            //digitalSignalUIDI0 = new DigitalSignalUI();

          
            digitalSignalUIDI15.Cursor = Cursors.Default;
            digitalSignalUIDI15.DigitalSignal = false;
            digitalSignalUIDI15.Location = new Point(498, 50);
            digitalSignalUIDI15.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI15.Name = "digitalSignalUIDI15";
            digitalSignalUIDI15.Size = new Size(30, 30);
            digitalSignalUIDI15.TabIndex = 62;
            digitalSignalUIDI14.Cursor = Cursors.Default;
            digitalSignalUIDI14.DigitalSignal = false;
            digitalSignalUIDI14.Location = new Point(433, 50);
            digitalSignalUIDI14.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI14.Name = "digitalSignalUIDI14";
            digitalSignalUIDI14.Size = new Size(30, 30);
            digitalSignalUIDI14.TabIndex = 60;
            digitalSignalUIDI13.Cursor = Cursors.Default;
            digitalSignalUIDI13.DigitalSignal = false;
            digitalSignalUIDI13.Location = new Point(368, 50);
            digitalSignalUIDI13.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI13.Name = "digitalSignalUIDI13";
            digitalSignalUIDI13.Size = new Size(30, 30);
            digitalSignalUIDI13.TabIndex = 58;
            digitalSignalUIDI12.Cursor = Cursors.Default;
            digitalSignalUIDI12.DigitalSignal = false;
            digitalSignalUIDI12.Location = new Point(303, 50);
            digitalSignalUIDI12.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI12.Name = "digitalSignalUIDI12";
            digitalSignalUIDI12.Size = new Size(30, 30);
            digitalSignalUIDI12.TabIndex = 56;
            digitalSignalUIDI11.Cursor = Cursors.Default;
            digitalSignalUIDI11.DigitalSignal = false;
            digitalSignalUIDI11.Location = new Point(238, 50);
            digitalSignalUIDI11.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI11.Name = "digitalSignalUIDI11";
            digitalSignalUIDI11.Size = new Size(30, 30);
            digitalSignalUIDI11.TabIndex = 54;
            digitalSignalUIDI10.Cursor = Cursors.Default;
            digitalSignalUIDI10.DigitalSignal = false;
            digitalSignalUIDI10.Location = new Point(173, 50);
            digitalSignalUIDI10.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI10.Name = "digitalSignalUIDI10";
            digitalSignalUIDI10.Size = new Size(30, 30);
            digitalSignalUIDI10.TabIndex = 52;
            digitalSignalUIDI9.Cursor = Cursors.Default;
            digitalSignalUIDI9.DigitalSignal = false;
            digitalSignalUIDI9.Location = new Point(108, 50);
            digitalSignalUIDI9.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI9.Name = "digitalSignalUIDI9";
            digitalSignalUIDI9.Size = new Size(30, 30);
            digitalSignalUIDI9.TabIndex = 50;
            digitalSignalUIDI8.Cursor = Cursors.Default;
            digitalSignalUIDI8.DigitalSignal = false;
            digitalSignalUIDI8.Location = new Point(43, 50);
            digitalSignalUIDI8.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI8.Name = "digitalSignalUIDI8";
            digitalSignalUIDI8.Size = new Size(30, 30);
            digitalSignalUIDI8.TabIndex = 48;
            digitalSignalUIDI7.Cursor = Cursors.Default;
            digitalSignalUIDI7.DigitalSignal = false;
            digitalSignalUIDI7.Location = new Point(498, 14);
            digitalSignalUIDI7.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI7.Name = "digitalSignalUIDI7";
            digitalSignalUIDI7.Size = new Size(30, 30);
            digitalSignalUIDI7.TabIndex = 46;
            digitalSignalUIDI6.Cursor = Cursors.Default;
            digitalSignalUIDI6.DigitalSignal = false;
            digitalSignalUIDI6.Location = new Point(433, 14);
            digitalSignalUIDI6.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI6.Name = "digitalSignalUIDI6";
            digitalSignalUIDI6.Size = new Size(30, 30);
            digitalSignalUIDI6.TabIndex = 44;
            digitalSignalUIDI5.Cursor = Cursors.Default;
            digitalSignalUIDI5.DigitalSignal = false;
            digitalSignalUIDI5.Location = new Point(368, 14);
            digitalSignalUIDI5.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI5.Name = "digitalSignalUIDI5";
            digitalSignalUIDI5.Size = new Size(30, 30);
            digitalSignalUIDI5.TabIndex = 42;
            digitalSignalUIDI4.Cursor = Cursors.Default;
            digitalSignalUIDI4.DigitalSignal = false;
            digitalSignalUIDI4.Location = new Point(303, 14);
            digitalSignalUIDI4.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI4.Name = "digitalSignalUIDI4";
            digitalSignalUIDI4.Size = new Size(30, 30);
            digitalSignalUIDI4.TabIndex = 40;
            digitalSignalUIDI3.Cursor = Cursors.Default;
            digitalSignalUIDI3.DigitalSignal = false;
            digitalSignalUIDI3.Location = new Point(238, 14);
            digitalSignalUIDI3.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI3.Name = "digitalSignalUIDI3";
            digitalSignalUIDI3.Size = new Size(30, 30);
            digitalSignalUIDI3.TabIndex = 38;
            digitalSignalUIDI2.Cursor = Cursors.Default;
            digitalSignalUIDI2.DigitalSignal = false;
            digitalSignalUIDI2.Location = new Point(173, 14);
            digitalSignalUIDI2.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI2.Name = "digitalSignalUIDI2";
            digitalSignalUIDI2.Size = new Size(30, 30);
            digitalSignalUIDI2.TabIndex = 36;
            digitalSignalUIDI1.Cursor = Cursors.Default;
            digitalSignalUIDI1.DigitalSignal = false;
            digitalSignalUIDI1.Location = new Point(108, 14);
            digitalSignalUIDI1.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI1.Name = "digitalSignalUIDI1";
            digitalSignalUIDI1.Size = new Size(30, 30);
            digitalSignalUIDI1.TabIndex = 34;
            digitalSignalUIDI0.Cursor = Cursors.Default;
            digitalSignalUIDI0.DigitalSignal = false;
            digitalSignalUIDI0.Location = new Point(43, 14);
            digitalSignalUIDI0.Mode = DigitalSignalUIMode.Input;
            digitalSignalUIDI0.Name = "digitalSignalUIDI0";
            digitalSignalUIDI0.Size = new Size(30, 30);
            digitalSignalUIDI0.TabIndex = 32;
            AutoScaleDimensions = new SizeF(6f, 12f);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add((Control)digitalSignalUIDI15);
            Controls.Add((Control)digitalSignalUIDI14);
            Controls.Add((Control)digitalSignalUIDI13);
            Controls.Add((Control)digitalSignalUIDI12);
            Controls.Add((Control)digitalSignalUIDI11);
            Controls.Add((Control)digitalSignalUIDI10);
            Controls.Add((Control)digitalSignalUIDI9);
            Controls.Add((Control)digitalSignalUIDI8);
            Controls.Add((Control)digitalSignalUIDI7);
            Controls.Add((Control)digitalSignalUIDI6);
            Controls.Add((Control)digitalSignalUIDI5);
            Controls.Add((Control)digitalSignalUIDI4);
            Controls.Add((Control)digitalSignalUIDI3);
            Controls.Add((Control)digitalSignalUIDI2);
            Controls.Add((Control)digitalSignalUIDI1);
            Controls.Add((Control)digitalSignalUIDI0);
        }*/

        public IOLogikE1210ControllerForm(MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager, IOLogikE1210DigitalInputServerController controller)
        {
            InitializeComponent();
            //InitializeComponent_1();
            this.magicStoneKingdomDeviceControlManager = magicStoneKingdomDeviceControlManager;
            this.controller = controller;
            //for (int index = 0; index < controller.ChannelCount; ++index)
            //{
                digitalSignalUi = Controls.Find("digitalSignalUIDI" + 0, false)[0] as DigitalSignalUI;
                switch (controller.GetDigitalInputChannelModes((byte)0, (byte)1)[0])
                {
                    case IOLogikDigitalInputChannelMode.DI:
                        digitalSignalUi.Mode = DigitalSignalUIMode.Input;
                        digitalSignalUi.BindToDigitalSignalInputInterface((DigitalSignalInputInterface)controller.DigitalSignalInputInterfaces[0]);
                        trig = digitalSignalUi.DigitalSignal;
                        break;
                    /*case IOLogikDigitalInputChannelMode.Counter:
                        digitalSignalUi.Mode = DigitalSignalUIMode.Input_Counter;
                        digitalSignalUi.BindToDigitalInputCounterSignalInputInterface((DigitalInputCounterSignalInputInterface)controller.DigitalInputCounterSignalInputInterfaces[0]);
                        trig = 2;
                        lbl1.Text = trig.ToString();
                        break;*/
                }
            //}
            Text = controller.ToString();
        }

        public void SynchronizeFormControls()
        {
            synchronizingFormControls = true;
            synchronizingFormControls = false;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            trig = digitalSignalUi.DigitalSignal;
            lbl1.Text = trig.ToString();
        }
    }
}
