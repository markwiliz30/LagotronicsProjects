namespace SearchAndFoundNewTest
{
    partial class NPortControllerConnectionForm
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.numericUpDownReadTimeout = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWriteTimeout = new System.Windows.Forms.NumericUpDown();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBit = new System.Windows.Forms.ComboBox();
            this.comboBoxBitCount = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWriteTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(36, 238);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 18;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            // 
            // numericUpDownReadTimeout
            // 
            this.numericUpDownReadTimeout.Location = new System.Drawing.Point(21, 204);
            this.numericUpDownReadTimeout.Maximum = new decimal(new int[] {
            999999999,
            1,
            0,
            0});
            this.numericUpDownReadTimeout.Name = "numericUpDownReadTimeout";
            this.numericUpDownReadTimeout.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownReadTimeout.TabIndex = 17;
            this.numericUpDownReadTimeout.Value = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            // 
            // numericUpDownWriteTimeout
            // 
            this.numericUpDownWriteTimeout.Location = new System.Drawing.Point(21, 178);
            this.numericUpDownWriteTimeout.Name = "numericUpDownWriteTimeout";
            this.numericUpDownWriteTimeout.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownWriteTimeout.TabIndex = 16;
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(21, 41);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(100, 20);
            this.textBoxIPAddress.TabIndex = 15;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(21, 15);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 14;
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(21, 151);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(121, 21);
            this.comboBoxParity.TabIndex = 13;
            // 
            // comboBoxStopBit
            // 
            this.comboBoxStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBit.FormattingEnabled = true;
            this.comboBoxStopBit.Location = new System.Drawing.Point(21, 124);
            this.comboBoxStopBit.Name = "comboBoxStopBit";
            this.comboBoxStopBit.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStopBit.TabIndex = 12;
            // 
            // comboBoxBitCount
            // 
            this.comboBoxBitCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBitCount.FormattingEnabled = true;
            this.comboBoxBitCount.Location = new System.Drawing.Point(21, 97);
            this.comboBoxBitCount.Name = "comboBoxBitCount";
            this.comboBoxBitCount.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBitCount.TabIndex = 11;
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(21, 70);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBaudRate.TabIndex = 10;
            // 
            // NPortControllerConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 277);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.numericUpDownReadTimeout);
            this.Controls.Add(this.numericUpDownWriteTimeout);
            this.Controls.Add(this.textBoxIPAddress);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.comboBoxParity);
            this.Controls.Add(this.comboBoxStopBit);
            this.Controls.Add(this.comboBoxBitCount);
            this.Controls.Add(this.comboBoxBaudRate);
            this.Name = "NPortControllerConnectionForm";
            this.Text = "NPortControllerConnectionForm";
            this.Load += new System.EventHandler(this.buttonConnect_Click);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWriteTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.NumericUpDown numericUpDownReadTimeout;
        private System.Windows.Forms.NumericUpDown numericUpDownWriteTimeout;
        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.ComboBox comboBoxStopBit;
        private System.Windows.Forms.ComboBox comboBoxBitCount;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
    }
}