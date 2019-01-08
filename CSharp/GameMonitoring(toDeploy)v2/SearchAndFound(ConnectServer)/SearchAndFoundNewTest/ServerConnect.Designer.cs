namespace SearchAndFoundNewTest
{
    partial class ServerConnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerConnect));
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnClose = new WindowsFormsControlLibrary1.BunifuThinButton();
            this.btnConnect = new WindowsFormsControlLibrary1.BunifuThinButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new Bunifu.Framework.UI.BunifuTextbox();
            this.txtIP = new Bunifu.Framework.UI.BunifuTextbox();
            this.picLago = new System.Windows.Forms.PictureBox();
            this.SFanimator = new BunifuAnimatorNS.Animator(this.components);
            this.checkConnectionTimer = new System.Windows.Forms.Timer(this.components);
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLago)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.btnClose);
            this.bunifuGradientPanel1.Controls.Add(this.btnConnect);
            this.bunifuGradientPanel1.Controls.Add(this.label2);
            this.bunifuGradientPanel1.Controls.Add(this.label1);
            this.bunifuGradientPanel1.Controls.Add(this.txtPort);
            this.bunifuGradientPanel1.Controls.Add(this.txtIP);
            this.bunifuGradientPanel1.Controls.Add(this.picLago);
            this.SFanimator.SetDecoration(this.bunifuGradientPanel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(21)))), ((int)(((byte)(205)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(92)))), ((int)(((byte)(209)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(337, 493);
            this.bunifuGradientPanel1.TabIndex = 0;
            this.bunifuGradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.bunifuGradientPanel1_Paint);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SFanimator.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ForeColorHoverState = System.Drawing.Color.DimGray;
            this.btnClose.Iconimage = null;
            this.btnClose.IconVisible = true;
            this.btnClose.IconZoom = 90D;
            this.btnClose.ImageIconOverlay = false;
            this.btnClose.Location = new System.Drawing.Point(183, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 36);
            this.btnClose.TabIndex = 8;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConnect.BackgroundImage")));
            this.btnConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConnect.ButtonText = "Connect";
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SFanimator.SetDecoration(this.btnConnect, BunifuAnimatorNS.DecorationType.None);
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.ForeColorHoverState = System.Drawing.Color.DimGray;
            this.btnConnect.Iconimage = null;
            this.btnConnect.IconVisible = true;
            this.btnConnect.IconZoom = 90D;
            this.btnConnect.ImageIconOverlay = false;
            this.btnConnect.Location = new System.Drawing.Point(12, 419);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(142, 36);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.SFanimator.SetDecoration(this.label2, BunifuAnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Clarendon BT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(102, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Server Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.SFanimator.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Clarendon BT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(67, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server IP Address";
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.SlateBlue;
            this.txtPort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtPort.BackgroundImage")));
            this.txtPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SFanimator.SetDecoration(this.txtPort, BunifuAnimatorNS.DecorationType.None);
            this.txtPort.ForeColor = System.Drawing.Color.White;
            this.txtPort.Icon = ((System.Drawing.Image)(resources.GetObject("txtPort.Icon")));
            this.txtPort.Location = new System.Drawing.Point(46, 328);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(250, 42);
            this.txtPort.TabIndex = 4;
            this.txtPort.text = "";
            // 
            // txtIP
            // 
            this.txtIP.BackColor = System.Drawing.Color.SlateBlue;
            this.txtIP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtIP.BackgroundImage")));
            this.txtIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SFanimator.SetDecoration(this.txtIP, BunifuAnimatorNS.DecorationType.None);
            this.txtIP.ForeColor = System.Drawing.Color.White;
            this.txtIP.Icon = ((System.Drawing.Image)(resources.GetObject("txtIP.Icon")));
            this.txtIP.Location = new System.Drawing.Point(46, 234);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(250, 42);
            this.txtIP.TabIndex = 3;
            this.txtIP.text = "";
            // 
            // picLago
            // 
            this.SFanimator.SetDecoration(this.picLago, BunifuAnimatorNS.DecorationType.None);
            this.picLago.Image = global::SearchAndFoundNewTest.Properties.Resources.lago;
            this.picLago.Location = new System.Drawing.Point(12, 12);
            this.picLago.Name = "picLago";
            this.picLago.Size = new System.Drawing.Size(313, 157);
            this.picLago.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLago.TabIndex = 0;
            this.picLago.TabStop = false;
            // 
            // SFanimator
            // 
            this.SFanimator.AnimationType = BunifuAnimatorNS.AnimationType.Scale;
            this.SFanimator.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.SFanimator.DefaultAnimation = animation1;
            // 
            // checkConnectionTimer
            // 
            this.checkConnectionTimer.Interval = 1000;
            this.checkConnectionTimer.Tick += new System.EventHandler(this.checkConnectionTimer_Tick);
            // 
            // ServerConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 493);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.SFanimator.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServerConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServerConnect";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerConnect_FormClosing);
            this.Load += new System.EventHandler(this.ServerConnect_Load);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.PictureBox picLago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuTextbox txtPort;
        private Bunifu.Framework.UI.BunifuTextbox txtIP;
        private WindowsFormsControlLibrary1.BunifuThinButton btnConnect;
        private WindowsFormsControlLibrary1.BunifuThinButton btnClose;
        private BunifuAnimatorNS.Animator SFanimator;
        private System.Windows.Forms.Timer checkConnectionTimer;
    }
}