namespace Server
{
    partial class Client1
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
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.lst_sent = new System.Windows.Forms.ListBox();
            this.lst_received = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.message_check = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(12, 12);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(177, 20);
            this.txt_ip.TabIndex = 0;
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(195, 12);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(86, 23);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // lst_sent
            // 
            this.lst_sent.FormattingEnabled = true;
            this.lst_sent.Location = new System.Drawing.Point(154, 87);
            this.lst_sent.Name = "lst_sent";
            this.lst_sent.Size = new System.Drawing.Size(127, 173);
            this.lst_sent.TabIndex = 3;
            // 
            // lst_received
            // 
            this.lst_received.FormattingEnabled = true;
            this.lst_received.Location = new System.Drawing.Point(12, 87);
            this.lst_received.Name = "lst_received";
            this.lst_received.Size = new System.Drawing.Size(127, 173);
            this.lst_received.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Received:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sent:";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(203, 274);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(78, 34);
            this.btn_send.TabIndex = 7;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txt_msg
            // 
            this.txt_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_msg.Location = new System.Drawing.Point(12, 277);
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(185, 26);
            this.txt_msg.TabIndex = 8;
            // 
            // message_check
            // 
            this.message_check.Enabled = true;
            this.message_check.Interval = 50;
            this.message_check.Tick += new System.EventHandler(this.message_check_Tick);
            // 
            // Client1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 333);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_received);
            this.Controls.Add(this.lst_sent);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.txt_ip);
            this.Name = "Client1";
            this.Text = "Client 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.ListBox lst_sent;
        private System.Windows.Forms.ListBox lst_received;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.Timer message_check;
    }
}

