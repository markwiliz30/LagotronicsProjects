namespace SearchAndFound1240
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
            this.btnAngleSensor = new System.Windows.Forms.Button();
            this.timerFormSynchronization = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnAngleSensor
            // 
            this.btnAngleSensor.Location = new System.Drawing.Point(24, 12);
            this.btnAngleSensor.Name = "btnAngleSensor";
            this.btnAngleSensor.Size = new System.Drawing.Size(75, 23);
            this.btnAngleSensor.TabIndex = 0;
            this.btnAngleSensor.Text = "AngleSensor";
            this.btnAngleSensor.UseVisualStyleBackColor = true;
            this.btnAngleSensor.Click += new System.EventHandler(this.ioLogikE1240AnalogInputServerToolStripMenuItem_Click);
            // 
            // timerFormSynchronization
            // 
            this.timerFormSynchronization.Tick += new System.EventHandler(this.timerFormSynchronization_Tick);
            // 
            // MagicStoneKingdomDeviceControlTestingPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(124, 49);
            this.Controls.Add(this.btnAngleSensor);
            this.Name = "MagicStoneKingdomDeviceControlTestingPanelForm";
            this.Text = "MagicStoneKingdomDeviceControlTestingPanelForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IOCabinetControl_FormClosed);
            this.Load += new System.EventHandler(this.MagicStoneKingdomDeviceControlTestingPanelForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAngleSensor;
        private System.Windows.Forms.Timer timerFormSynchronization;
    }
}