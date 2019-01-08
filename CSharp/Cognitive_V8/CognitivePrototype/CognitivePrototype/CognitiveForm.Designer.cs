namespace CognitivePrototype
{
    partial class CognitiveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CognitiveForm));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.formHPanel = new System.Windows.Forms.Panel();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblCognitive = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.scoreRate = new Bunifu.Framework.UI.BunifuRating();
            this.lblIndicator = new System.Windows.Forms.Label();
            this.btnCogStart = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblTimer = new System.Windows.Forms.Label();
            this.timerProgress = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.lblInput = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.changeTimer = new System.Windows.Forms.Timer(this.components);
            this.cogTimer = new System.Windows.Forms.Timer(this.components);
            this.gameOverTimer = new System.Windows.Forms.Timer(this.components);
            this.randomRGBTimer = new System.Windows.Forms.Timer(this.components);
            this.runningLights = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblHScore = new System.Windows.Forms.Label();
            this.closingTimer = new System.Windows.Forms.Timer(this.components);
            this.btnSelect = new Bunifu.Framework.UI.BunifuFlatButton();
            this.chckEasy = new Bunifu.Framework.UI.BunifuCheckbox();
            this.lblEasy = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chckHard = new Bunifu.Framework.UI.BunifuCheckbox();
            this.pnlEasy = new System.Windows.Forms.Panel();
            this.pnlHard = new System.Windows.Forms.Panel();
            this.formHPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCogStart)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // formHPanel
            // 
            this.formHPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(102)))), ((int)(((byte)(221)))));
            this.formHPanel.Controls.Add(this.btnClose);
            this.formHPanel.Controls.Add(this.lblCognitive);
            this.formHPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formHPanel.Location = new System.Drawing.Point(0, 0);
            this.formHPanel.Name = "formHPanel";
            this.formHPanel.Size = new System.Drawing.Size(1556, 46);
            this.formHPanel.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(1512, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(33, 31);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCognitive
            // 
            this.lblCognitive.AutoSize = true;
            this.lblCognitive.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCognitive.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCognitive.Location = new System.Drawing.Point(56, 6);
            this.lblCognitive.Name = "lblCognitive";
            this.lblCognitive.Size = new System.Drawing.Size(137, 31);
            this.lblCognitive.TabIndex = 3;
            this.lblCognitive.Text = "Cognitive";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(264, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 55);
            this.label1.TabIndex = 8;
            this.label1.Text = "Score";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblScore.Location = new System.Drawing.Point(310, 160);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(69, 73);
            this.lblScore.TabIndex = 7;
            this.lblScore.Text = "0";
            // 
            // scoreRate
            // 
            this.scoreRate.BackColor = System.Drawing.Color.Transparent;
            this.scoreRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(37)))));
            this.scoreRate.Location = new System.Drawing.Point(70, 266);
            this.scoreRate.Name = "scoreRate";
            this.scoreRate.Size = new System.Drawing.Size(316, 50);
            this.scoreRate.TabIndex = 6;
            this.scoreRate.Value = 0;
            // 
            // lblIndicator
            // 
            this.lblIndicator.AutoSize = true;
            this.lblIndicator.Font = new System.Drawing.Font("Bauhaus 93", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicator.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndicator.Location = new System.Drawing.Point(558, 133);
            this.lblIndicator.Name = "lblIndicator";
            this.lblIndicator.Size = new System.Drawing.Size(513, 108);
            this.lblIndicator.TabIndex = 39;
            this.lblIndicator.Text = "Game Over";
            this.lblIndicator.Visible = false;
            // 
            // btnCogStart
            // 
            this.btnCogStart.BackColor = System.Drawing.Color.Transparent;
            this.btnCogStart.Image = ((System.Drawing.Image)(resources.GetObject("btnCogStart.Image")));
            this.btnCogStart.ImageActive = null;
            this.btnCogStart.Location = new System.Drawing.Point(632, 74);
            this.btnCogStart.Name = "btnCogStart";
            this.btnCogStart.Size = new System.Drawing.Size(398, 210);
            this.btnCogStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCogStart.TabIndex = 38;
            this.btnCogStart.TabStop = false;
            this.btnCogStart.Zoom = 10;
            this.btnCogStart.Click += new System.EventHandler(this.btnCogStart_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTimer.Location = new System.Drawing.Point(1286, 61);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(200, 73);
            this.lblTimer.TabIndex = 41;
            this.lblTimer.Text = "Timer";
            // 
            // timerProgress
            // 
            this.timerProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(82)))), ((int)(((byte)(100)))));
            this.timerProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.timerProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.timerProgress.LabelVisible = true;
            this.timerProgress.LineThickness = 10;
            this.timerProgress.Location = new System.Drawing.Point(1278, 133);
            this.timerProgress.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.timerProgress.MaxValue = 100;
            this.timerProgress.Name = "timerProgress";
            this.timerProgress.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.timerProgress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.timerProgress.Size = new System.Drawing.Size(201, 201);
            this.timerProgress.TabIndex = 40;
            this.timerProgress.Value = 100;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblInput.Location = new System.Drawing.Point(12, 326);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(155, 55);
            this.lblInput.TabIndex = 42;
            this.lblInput.Text = "Score";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.formHPanel;
            this.bunifuDragControl1.Vertical = true;
            // 
            // changeTimer
            // 
            this.changeTimer.Interval = 1500;
            this.changeTimer.Tick += new System.EventHandler(this.changeTimer_Tick);
            // 
            // cogTimer
            // 
            this.cogTimer.Interval = 1000;
            this.cogTimer.Tick += new System.EventHandler(this.cogTimer_Tick);
            // 
            // gameOverTimer
            // 
            this.gameOverTimer.Interval = 3000;
            this.gameOverTimer.Tick += new System.EventHandler(this.gameOverTimer_Tick);
            // 
            // randomRGBTimer
            // 
            this.randomRGBTimer.Tick += new System.EventHandler(this.randomRGBTimer_Tick);
            // 
            // runningLights
            // 
            this.runningLights.Interval = 250;
            this.runningLights.Tick += new System.EventHandler(this.runningLights_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(37, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 42);
            this.label2.TabIndex = 44;
            this.label2.Text = "High Score";
            // 
            // lblHScore
            // 
            this.lblHScore.AutoSize = true;
            this.lblHScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHScore.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblHScore.Location = new System.Drawing.Point(106, 163);
            this.lblHScore.Name = "lblHScore";
            this.lblHScore.Size = new System.Drawing.Size(69, 73);
            this.lblHScore.TabIndex = 43;
            this.lblHScore.Text = "0";
            // 
            // closingTimer
            // 
            this.closingTimer.Interval = 400;
            this.closingTimer.Tick += new System.EventHandler(this.closingTimer_Tick);
            // 
            // btnSelect
            // 
            this.btnSelect.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelect.BorderRadius = 0;
            this.btnSelect.ButtonText = "        Select Music";
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSelect.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSelect.Iconimage")));
            this.btnSelect.Iconimage_right = null;
            this.btnSelect.Iconimage_right_Selected = null;
            this.btnSelect.Iconimage_Selected = null;
            this.btnSelect.IconZoom = 90D;
            this.btnSelect.IsTab = false;
            this.btnSelect.Location = new System.Drawing.Point(729, 61);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSelect.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnSelect.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSelect.selected = false;
            this.btnSelect.Size = new System.Drawing.Size(191, 48);
            this.btnSelect.TabIndex = 45;
            this.btnSelect.Textcolor = System.Drawing.Color.White;
            this.btnSelect.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // chckEasy
            // 
            this.chckEasy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.chckEasy.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chckEasy.Checked = false;
            this.chckEasy.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.chckEasy.ForeColor = System.Drawing.Color.White;
            this.chckEasy.Location = new System.Drawing.Point(22, 402);
            this.chckEasy.Name = "chckEasy";
            this.chckEasy.Size = new System.Drawing.Size(20, 20);
            this.chckEasy.TabIndex = 46;
            this.chckEasy.OnChange += new System.EventHandler(this.chckEasy_OnChange);
            // 
            // lblEasy
            // 
            this.lblEasy.AutoSize = true;
            this.lblEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasy.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblEasy.Location = new System.Drawing.Point(52, 393);
            this.lblEasy.Name = "lblEasy";
            this.lblEasy.Size = new System.Drawing.Size(99, 39);
            this.lblEasy.TabIndex = 47;
            this.lblEasy.Text = "Easy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(52, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 39);
            this.label4.TabIndex = 49;
            this.label4.Text = "Hard";
            // 
            // chckHard
            // 
            this.chckHard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.chckHard.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chckHard.Checked = false;
            this.chckHard.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.chckHard.ForeColor = System.Drawing.Color.White;
            this.chckHard.Location = new System.Drawing.Point(22, 465);
            this.chckHard.Name = "chckHard";
            this.chckHard.Size = new System.Drawing.Size(20, 20);
            this.chckHard.TabIndex = 48;
            this.chckHard.OnChange += new System.EventHandler(this.chckHard_OnChange);
            // 
            // pnlEasy
            // 
            this.pnlEasy.BackColor = System.Drawing.Color.Green;
            this.pnlEasy.Location = new System.Drawing.Point(62, 431);
            this.pnlEasy.Name = "pnlEasy";
            this.pnlEasy.Size = new System.Drawing.Size(76, 10);
            this.pnlEasy.TabIndex = 50;
            this.pnlEasy.Visible = false;
            // 
            // pnlHard
            // 
            this.pnlHard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlHard.Location = new System.Drawing.Point(62, 492);
            this.pnlHard.Name = "pnlHard";
            this.pnlHard.Size = new System.Drawing.Size(76, 10);
            this.pnlHard.TabIndex = 51;
            this.pnlHard.Visible = false;
            // 
            // CognitiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(82)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(1556, 529);
            this.Controls.Add(this.pnlHard);
            this.Controls.Add(this.pnlEasy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chckHard);
            this.Controls.Add(this.lblEasy);
            this.Controls.Add(this.chckEasy);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHScore);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.timerProgress);
            this.Controls.Add(this.lblIndicator);
            this.Controls.Add(this.btnCogStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.scoreRate);
            this.Controls.Add(this.formHPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CognitiveForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CognitiveForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CognitiveForm_FormClosed);
            this.Load += new System.EventHandler(this.CognitiveForm_Load);
            this.formHPanel.ResumeLayout(false);
            this.formHPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCogStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lblTimer;
        private Bunifu.Framework.UI.BunifuCircleProgressbar timerProgress;
        private System.Windows.Forms.Label lblIndicator;
        private Bunifu.Framework.UI.BunifuImageButton btnCogStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScore;
        private Bunifu.Framework.UI.BunifuRating scoreRate;
        private System.Windows.Forms.Panel formHPanel;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private System.Windows.Forms.Label lblCognitive;
        private System.Windows.Forms.Label lblInput;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Timer changeTimer;
        private System.Windows.Forms.Timer cogTimer;
        private System.Windows.Forms.Timer gameOverTimer;
        private System.Windows.Forms.Timer randomRGBTimer;
        private System.Windows.Forms.Timer runningLights;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHScore;
        private System.Windows.Forms.Timer closingTimer;
        private Bunifu.Framework.UI.BunifuFlatButton btnSelect;
        private System.Windows.Forms.Label lblEasy;
        private Bunifu.Framework.UI.BunifuCheckbox chckEasy;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuCheckbox chckHard;
        private System.Windows.Forms.Panel pnlHard;
        private System.Windows.Forms.Panel pnlEasy;
    }
}

