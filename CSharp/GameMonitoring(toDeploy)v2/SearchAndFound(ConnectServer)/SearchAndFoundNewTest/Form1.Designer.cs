namespace SearchAndFoundNewTest
{
    partial class Form1
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
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.crossHeirTimer = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.digitalSignalUIDI0 = new TestingPanelResources.DigitalSignalUI();
            this.countDownTimer = new System.Windows.Forms.Timer(this.components);
            this.progGameTimer = new Bunifu.Framework.UI.BunifuProgressBar();
            this.lblfindTimer = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMiss = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblHits = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblHmiss = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHhits = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.startTimer = new System.Windows.Forms.Timer(this.components);
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.SFanimator = new BunifuAnimatorNS.Animator(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.connectionCheck = new System.Windows.Forms.Timer(this.components);
            this.rfPort = new System.IO.Ports.SerialPort(this.components);
            this.idChecker = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Controls.Add(this.btnClose);
            this.SFanimator.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1905, 35);
            this.panel2.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.SFanimator.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(1862, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 28);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // crossHeirTimer
            // 
            this.crossHeirTimer.Interval = 10;
            this.crossHeirTimer.Tick += new System.EventHandler(this.crossHeirTimer_Tick);
            // 
            // button5
            // 
            this.SFanimator.SetDecoration(this.button5, BunifuAnimatorNS.DecorationType.None);
            this.button5.Location = new System.Drawing.Point(32, 43);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.SFanimator.SetDecoration(this.button6, BunifuAnimatorNS.DecorationType.None);
            this.button6.Location = new System.Drawing.Point(157, 43);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 13;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // digitalSignalUIDI0
            // 
            this.digitalSignalUIDI0.Cursor = System.Windows.Forms.Cursors.Default;
            this.SFanimator.SetDecoration(this.digitalSignalUIDI0, BunifuAnimatorNS.DecorationType.None);
            this.digitalSignalUIDI0.DigitalInputCounter = ((uint)(0u));
            this.digitalSignalUIDI0.DigitalSignal = false;
            this.digitalSignalUIDI0.Location = new System.Drawing.Point(43, 43);
            this.digitalSignalUIDI0.Margin = new System.Windows.Forms.Padding(4);
            this.digitalSignalUIDI0.Mode = TestingPanelResources.DigitalSignalUIMode.Input;
            this.digitalSignalUIDI0.Name = "digitalSignalUIDI0";
            this.digitalSignalUIDI0.Size = new System.Drawing.Size(34, 33);
            this.digitalSignalUIDI0.TabIndex = 14;
            this.digitalSignalUIDI0.Visible = false;
            // 
            // countDownTimer
            // 
            this.countDownTimer.Interval = 1000;
            this.countDownTimer.Tick += new System.EventHandler(this.countDownTimer_Tick);
            // 
            // progGameTimer
            // 
            this.progGameTimer.BackColor = System.Drawing.Color.Silver;
            this.progGameTimer.BorderRadius = 5;
            this.SFanimator.SetDecoration(this.progGameTimer, BunifuAnimatorNS.DecorationType.None);
            this.progGameTimer.Location = new System.Drawing.Point(250, 93);
            this.progGameTimer.Margin = new System.Windows.Forms.Padding(4);
            this.progGameTimer.MaximumValue = 60;
            this.progGameTimer.Name = "progGameTimer";
            this.progGameTimer.ProgressColor = System.Drawing.Color.Green;
            this.progGameTimer.Size = new System.Drawing.Size(1655, 35);
            this.progGameTimer.TabIndex = 25;
            this.progGameTimer.Value = 60;
            // 
            // lblfindTimer
            // 
            this.lblfindTimer.AutoSize = true;
            this.SFanimator.SetDecoration(this.lblfindTimer, BunifuAnimatorNS.DecorationType.None);
            this.lblfindTimer.Font = new System.Drawing.Font("Adobe Gothic Std B", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblfindTimer.ForeColor = System.Drawing.Color.White;
            this.lblfindTimer.Location = new System.Drawing.Point(98, 138);
            this.lblfindTimer.Name = "lblfindTimer";
            this.lblfindTimer.Size = new System.Drawing.Size(52, 60);
            this.lblfindTimer.TabIndex = 28;
            this.lblfindTimer.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.SFanimator.SetDecoration(this.label5, BunifuAnimatorNS.DecorationType.None);
            this.label5.Font = new System.Drawing.Font("Algerian", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(34, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 54);
            this.label5.TabIndex = 27;
            this.label5.Text = "Find In";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.SFanimator.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Algerian", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 54);
            this.label1.TabIndex = 26;
            this.label1.Text = "Find Me";
            // 
            // lblMiss
            // 
            this.lblMiss.AutoSize = true;
            this.SFanimator.SetDecoration(this.lblMiss, BunifuAnimatorNS.DecorationType.None);
            this.lblMiss.Font = new System.Drawing.Font("Adobe Gothic Std B", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMiss.ForeColor = System.Drawing.Color.White;
            this.lblMiss.Location = new System.Drawing.Point(51, 656);
            this.lblMiss.Name = "lblMiss";
            this.lblMiss.Size = new System.Drawing.Size(45, 50);
            this.lblMiss.TabIndex = 34;
            this.lblMiss.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.SFanimator.SetDecoration(this.label7, BunifuAnimatorNS.DecorationType.None);
            this.label7.Font = new System.Drawing.Font("Algerian", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(24, 611);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 45);
            this.label7.TabIndex = 33;
            this.label7.Text = "Miss";
            // 
            // lblHits
            // 
            this.lblHits.AutoSize = true;
            this.SFanimator.SetDecoration(this.lblHits, BunifuAnimatorNS.DecorationType.None);
            this.lblHits.Font = new System.Drawing.Font("Adobe Gothic Std B", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHits.ForeColor = System.Drawing.Color.White;
            this.lblHits.Location = new System.Drawing.Point(159, 656);
            this.lblHits.Name = "lblHits";
            this.lblHits.Size = new System.Drawing.Size(45, 50);
            this.lblHits.TabIndex = 32;
            this.lblHits.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.SFanimator.SetDecoration(this.label2, BunifuAnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Algerian", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(132, 611);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 45);
            this.label2.TabIndex = 31;
            this.label2.Text = "Hits";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblHmiss);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblHhits);
            this.SFanimator.SetDecoration(this.groupBox1, BunifuAnimatorNS.DecorationType.None);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 731);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 310);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Highest Score";
            // 
            // lblHmiss
            // 
            this.lblHmiss.AutoSize = true;
            this.SFanimator.SetDecoration(this.lblHmiss, BunifuAnimatorNS.DecorationType.None);
            this.lblHmiss.Font = new System.Drawing.Font("Adobe Gothic Std B", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHmiss.ForeColor = System.Drawing.Color.White;
            this.lblHmiss.Location = new System.Drawing.Point(82, 221);
            this.lblHmiss.Name = "lblHmiss";
            this.lblHmiss.Size = new System.Drawing.Size(45, 50);
            this.lblHmiss.TabIndex = 36;
            this.lblHmiss.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.SFanimator.SetDecoration(this.label8, BunifuAnimatorNS.DecorationType.None);
            this.label8.Font = new System.Drawing.Font("Algerian", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(55, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 45);
            this.label8.TabIndex = 35;
            this.label8.Text = "Miss";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.SFanimator.SetDecoration(this.label3, BunifuAnimatorNS.DecorationType.None);
            this.label3.Font = new System.Drawing.Font("Algerian", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(55, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 45);
            this.label3.TabIndex = 33;
            this.label3.Text = "Hits";
            // 
            // lblHhits
            // 
            this.lblHhits.AutoSize = true;
            this.SFanimator.SetDecoration(this.lblHhits, BunifuAnimatorNS.DecorationType.None);
            this.lblHhits.Font = new System.Drawing.Font("Adobe Gothic Std B", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHhits.ForeColor = System.Drawing.Color.White;
            this.lblHhits.Location = new System.Drawing.Point(82, 104);
            this.lblHhits.Name = "lblHhits";
            this.lblHhits.Size = new System.Drawing.Size(45, 50);
            this.lblHhits.TabIndex = 34;
            this.lblHhits.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.SFanimator.SetDecoration(this.label9, BunifuAnimatorNS.DecorationType.None);
            this.label9.Font = new System.Drawing.Font("Algerian", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(244, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 32);
            this.label9.TabIndex = 39;
            this.label9.Text = "Name:";
            // 
            // startTimer
            // 
            this.startTimer.Interval = 1000;
            this.startTimer.Tick += new System.EventHandler(this.startTimer_Tick);
            // 
            // button7
            // 
            this.SFanimator.SetDecoration(this.button7, BunifuAnimatorNS.DecorationType.None);
            this.button7.Location = new System.Drawing.Point(815, 302);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 44;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.SFanimator.SetDecoration(this.button8, BunifuAnimatorNS.DecorationType.None);
            this.button8.Location = new System.Drawing.Point(734, 302);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 43;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.SFanimator.SetDecoration(this.button9, BunifuAnimatorNS.DecorationType.None);
            this.button9.Location = new System.Drawing.Point(815, 273);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 42;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.SFanimator.SetDecoration(this.button10, BunifuAnimatorNS.DecorationType.None);
            this.button10.Location = new System.Drawing.Point(734, 273);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 41;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Visible = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            this.button10.DragEnter += new System.Windows.Forms.DragEventHandler(this.button10_DragEnter);
            this.button10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button10_KeyDown);
            this.button10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button10_MouseDown);
            this.button10.MouseEnter += new System.EventHandler(this.button10_MouseEnter);
            this.button10.MouseHover += new System.EventHandler(this.button10_MouseHover);
            // 
            // button11
            // 
            this.SFanimator.SetDecoration(this.button11, BunifuAnimatorNS.DecorationType.None);
            this.button11.Location = new System.Drawing.Point(996, 302);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 48;
            this.button11.Text = "button11";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Visible = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.SFanimator.SetDecoration(this.button12, BunifuAnimatorNS.DecorationType.None);
            this.button12.Location = new System.Drawing.Point(915, 302);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 47;
            this.button12.Text = "button12";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Visible = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.SFanimator.SetDecoration(this.button13, BunifuAnimatorNS.DecorationType.None);
            this.button13.Location = new System.Drawing.Point(996, 273);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 46;
            this.button13.Text = "button13";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Visible = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.SFanimator.SetDecoration(this.button14, BunifuAnimatorNS.DecorationType.None);
            this.button14.Location = new System.Drawing.Point(915, 273);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 45;
            this.button14.Text = "button14";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Visible = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // SFanimator
            // 
            this.SFanimator.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
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
            this.SFanimator.Interval = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.SFanimator.SetDecoration(this.label4, BunifuAnimatorNS.DecorationType.None);
            this.label4.Font = new System.Drawing.Font("Algerian", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(728, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 32);
            this.label4.TabIndex = 49;
            this.label4.Text = "Points:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.SFanimator.SetDecoration(this.label6, BunifuAnimatorNS.DecorationType.None);
            this.label6.Font = new System.Drawing.Font("Algerian", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1320, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 32);
            this.label6.TabIndex = 50;
            this.label6.Text = "Balance:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.SFanimator.SetDecoration(this.lblName, BunifuAnimatorNS.DecorationType.None);
            this.lblName.Font = new System.Drawing.Font("Algerian", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(351, 49);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(32, 32);
            this.lblName.TabIndex = 51;
            this.lblName.Text = "N";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.SFanimator.SetDecoration(this.lblPoints, BunifuAnimatorNS.DecorationType.None);
            this.lblPoints.Font = new System.Drawing.Font("Algerian", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.Color.White;
            this.lblPoints.Location = new System.Drawing.Point(851, 49);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(32, 32);
            this.lblPoints.TabIndex = 52;
            this.lblPoints.Text = "P";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.SFanimator.SetDecoration(this.lblBalance, BunifuAnimatorNS.DecorationType.None);
            this.lblBalance.Font = new System.Drawing.Font("Algerian", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.White;
            this.lblBalance.Location = new System.Drawing.Point(1480, 49);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(34, 32);
            this.lblBalance.TabIndex = 53;
            this.lblBalance.Text = "B";
            // 
            // connectionCheck
            // 
            this.connectionCheck.Tick += new System.EventHandler(this.connectionCheck_Tick);
            // 
            // rfPort
            // 
            this.rfPort.PortName = "COM3";
            this.rfPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.rfPort_DataReceived);
            // 
            // idChecker
            // 
            this.idChecker.Enabled = true;
            this.idChecker.Tick += new System.EventHandler(this.idChecker_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(39)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1905, 1084);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHits);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMiss);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblfindTimer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progGameTimer);
            this.Controls.Add(this.digitalSignalUIDI0);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel2);
            this.SFanimator.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Tag = "";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private System.Windows.Forms.Timer crossHeirTimer;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private TestingPanelResources.DigitalSignalUI digitalSignalUIDI0;
        private System.Windows.Forms.Timer countDownTimer;
        private Bunifu.Framework.UI.BunifuProgressBar progGameTimer;
        private System.Windows.Forms.Label lblfindTimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMiss;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblHits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHmiss;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHhits;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer startTimer;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private BunifuAnimatorNS.Animator SFanimator;
        public System.Windows.Forms.Timer connectionCheck;
        private System.IO.Ports.SerialPort rfPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Timer idChecker;
    }
}

