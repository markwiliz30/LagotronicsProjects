namespace ConsoleServer
{
    partial class ConnectedDevices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectedDevices));
            this.connectedList = new System.Windows.Forms.ListBox();
            this.btnDisconnect = new Bunifu.Framework.UI.BunifuFlatButton();
            this.connectionListTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // connectedList
            // 
            this.connectedList.FormattingEnabled = true;
            this.connectedList.Location = new System.Drawing.Point(12, 12);
            this.connectedList.Name = "connectedList";
            this.connectedList.Size = new System.Drawing.Size(305, 251);
            this.connectedList.TabIndex = 0;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnDisconnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDisconnect.BorderRadius = 0;
            this.btnDisconnect.ButtonText = "     Disconnect";
            this.btnDisconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisconnect.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDisconnect.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDisconnect.Iconimage")));
            this.btnDisconnect.Iconimage_right = null;
            this.btnDisconnect.Iconimage_right_Selected = null;
            this.btnDisconnect.Iconimage_Selected = null;
            this.btnDisconnect.IconZoom = 90D;
            this.btnDisconnect.IsTab = false;
            this.btnDisconnect.Location = new System.Drawing.Point(73, 276);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnDisconnect.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnDisconnect.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDisconnect.selected = false;
            this.btnDisconnect.Size = new System.Drawing.Size(186, 48);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Textcolor = System.Drawing.Color.White;
            this.btnDisconnect.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // connectionListTimer
            // 
            this.connectionListTimer.Tick += new System.EventHandler(this.connectionListTimer_Tick);
            // 
            // ConnectedDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 341);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.connectedList);
            this.Name = "ConnectedDevices";
            this.Text = "ConnectedDevices";
            this.Load += new System.EventHandler(this.ConnectedDevices_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox connectedList;
        private Bunifu.Framework.UI.BunifuFlatButton btnDisconnect;
        private System.Windows.Forms.Timer connectionListTimer;
    }
}