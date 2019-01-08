namespace NportPrototypeControllerForm
{
    partial class IOLogikE1210ControllerForm
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
            this.digitalSignalUIDI0 = new TestingPanelResources.DigitalSignalUI();
            this.lbl1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // digitalSignalUIDI0
            // 
            this.digitalSignalUIDI0.Cursor = System.Windows.Forms.Cursors.Default;
            this.digitalSignalUIDI0.DigitalInputCounter = ((uint)(0u));
            this.digitalSignalUIDI0.DigitalSignal = false;
            this.digitalSignalUIDI0.Location = new System.Drawing.Point(12, 12);
            this.digitalSignalUIDI0.Mode = TestingPanelResources.DigitalSignalUIMode.Input;
            this.digitalSignalUIDI0.Name = "digitalSignalUIDI0";
            this.digitalSignalUIDI0.Size = new System.Drawing.Size(34, 33);
            this.digitalSignalUIDI0.TabIndex = 0;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(62, 23);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(35, 13);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // IOLogikE1210ControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 103);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.digitalSignalUIDI0);
            this.Name = "IOLogikE1210ControllerForm";
            this.Text = "IOLogikE1210ControllerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TestingPanelResources.DigitalSignalUI digitalSignalUIDI0;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Timer timer1;
    }
}