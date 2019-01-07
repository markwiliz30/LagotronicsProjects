namespace NportPrototypeControllerForm
{
    partial class MagicStoneKingdomDeviceControlTestingPanelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBoxConnectedDeviceController = new System.Windows.Forms.ListBox();
            this.timerFormSynchronization = new System.Windows.Forms.Timer(this.components);
            this.nPortSerialDeviceServerToolStripMenuItem = new System.Windows.Forms.Button();
            this.ioLogikE1210DigitalInputServerToolStripMenuItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxConnectedDeviceController
            // 
            this.listBoxConnectedDeviceController.FormattingEnabled = true;
            this.listBoxConnectedDeviceController.Location = new System.Drawing.Point(12, 49);
            this.listBoxConnectedDeviceController.Name = "listBoxConnectedDeviceController";
            this.listBoxConnectedDeviceController.Size = new System.Drawing.Size(340, 199);
            this.listBoxConnectedDeviceController.TabIndex = 0;
            this.listBoxConnectedDeviceController.SelectedIndexChanged += new System.EventHandler(this.listBoxConnectedDeviceController_SelectedIndexChanged);
            // 
            // timerFormSynchronization
            // 
            this.timerFormSynchronization.Tick += new System.EventHandler(this.timerFormSynchronization_Tick);
            // 
            // nPortSerialDeviceServerToolStripMenuItem
            // 
            this.nPortSerialDeviceServerToolStripMenuItem.Location = new System.Drawing.Point(56, 13);
            this.nPortSerialDeviceServerToolStripMenuItem.Name = "nPortSerialDeviceServerToolStripMenuItem";
            this.nPortSerialDeviceServerToolStripMenuItem.Size = new System.Drawing.Size(75, 23);
            this.nPortSerialDeviceServerToolStripMenuItem.TabIndex = 1;
            this.nPortSerialDeviceServerToolStripMenuItem.Text = "Nport";
            this.nPortSerialDeviceServerToolStripMenuItem.UseVisualStyleBackColor = true;
            this.nPortSerialDeviceServerToolStripMenuItem.Click += new System.EventHandler(this.nPortSerialDeviceServerToolStripMenuItem_Click);
            // 
            // ioLogikE1210DigitalInputServerToolStripMenuItem
            // 
            this.ioLogikE1210DigitalInputServerToolStripMenuItem.Location = new System.Drawing.Point(208, 13);
            this.ioLogikE1210DigitalInputServerToolStripMenuItem.Name = "ioLogikE1210DigitalInputServerToolStripMenuItem";
            this.ioLogikE1210DigitalInputServerToolStripMenuItem.Size = new System.Drawing.Size(75, 23);
            this.ioLogikE1210DigitalInputServerToolStripMenuItem.TabIndex = 2;
            this.ioLogikE1210DigitalInputServerToolStripMenuItem.Text = "IOLogik";
            this.ioLogikE1210DigitalInputServerToolStripMenuItem.UseVisualStyleBackColor = true;
            this.ioLogikE1210DigitalInputServerToolStripMenuItem.Click += new System.EventHandler(this.ioLogikE1210DigitalInputServerToolStripMenuItem_Click);
            // 
            // MagicStoneKingdomDeviceControlTestingPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 268);
            this.Controls.Add(this.ioLogikE1210DigitalInputServerToolStripMenuItem);
            this.Controls.Add(this.nPortSerialDeviceServerToolStripMenuItem);
            this.Controls.Add(this.listBoxConnectedDeviceController);
            this.Name = "MagicStoneKingdomDeviceControlTestingPanelForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MagicStoneKingdomDeviceControlTestingPanelForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IOCabinetControl_FormClosed);
            this.Load += new System.EventHandler(this.MagicStoneKingdomDeviceControlTestingPanelForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxConnectedDeviceController;
        private System.Windows.Forms.Timer timerFormSynchronization;
        private System.Windows.Forms.Button nPortSerialDeviceServerToolStripMenuItem;
        private System.Windows.Forms.Button ioLogikE1210DigitalInputServerToolStripMenuItem;
    }
}

