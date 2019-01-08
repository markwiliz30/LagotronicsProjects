using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArtNet;
using MoxaIOLogik_CSharp;
using System.Threading;
using System.IO;
using System.Media;
using System.Net.Sockets;
using SavingDataLib;
using SavingDataLib.TransferClasses;
using SocketConnectionLib;
using AsyncCallBack;

namespace CognitivePrototype
{
    public partial class CognitiveForm : Form
    {
        string signature = "LAGOTRONICS";
        string appName = "Cognitive";
        string rfId = "";
        int gameAmout = 10;
        bool canChange = false, isStarted = false, isGameOver = false, valid = false, isPressed, entered, endingTimerCanOff = false;
        bool canResume = false, timeStop = false, canCount = false;
        int intConnectionChecker = 1;
        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string deviceInfo;
        ServerConnect sc = new ServerConnect();
        StringTransferItem SFItem;
        TransferManager SFTManager;
        GetCredentials updateCredits;
        public CognitiveForm()
        {
            InitializeComponent();
            ArtNet.ArtNet.Initialize();
            //CallBack.SetupServer();
        }
        IOLogik1210 moxa1;
        IOLogik1210 moxa2;

        Thread readingArt, readingMoxa2;

        Thread startReading;

        SoundPlayer bg = new SoundPlayer(@"./background.wav");
        SoundPlayer gameStart = new SoundPlayer(@"./Start.wav");
        SoundPlayer gameOver = new SoundPlayer(@"./gameover.wav");
        SoundPlayer gotBeaten = new SoundPlayer(@"./Win.wav");
        SoundPlayer notBeaten = new SoundPlayer(@"./LoseV2.wav");
        MediaPlayer.MediaPlayer fxWin = new MediaPlayer.MediaPlayer();
        MediaPlayer.MediaPlayer fxFail = new MediaPlayer.MediaPlayer();
        MediaPlayer.MediaPlayer endingTimer;
        MediaPlayer.MediaPlayer playSoundFx;

        string ArtLynxIPAdd = "192.168.127.60";
        string Moxa2IpAdd = "192.168.127.62";
        string Moxa1IpAdd = "192.168.127.61";
        byte[] dmxValues = new byte[512];

        bool reading, isBeaten = false, endTimerCanTrig = true;

        static Random randomNum = new Random();

        char[] Moxa1;
        char[] Moxa2;

        char ON = '1';
        char OFF = '0';
        char[] Button_input;

        int cogInt = 0, cogInt2 = 0, i, inverted, randomInt_1, randomIncrement, score, cogCount, iterateCh = 0, iterateLed = 0,hScore, startChange = 1;
        double gtVal, ms;
        bool changIndicator = false, gameIsStart = false, canTap = false, isHard = false;
        bool canClick_0, canClick_1, canClick_2, canClick_3, canClick_4, canClick_5, canClick_6, canClick_7, canClick_8, canClick_9, canClick_10, canClick_11, canClick_12, canClick_13, canClick_14, canClick_15, canClick_16, canClick_17, canClick_18, canClick_19, canClick_20, canClick_21, canClick_22, canClick_23, canClick_24_StartBtn = true;

        private void idChecker_Tick(object sender, EventArgs e)
        {
            if (AsyncCallBack.CallBack.rfId != null && AsyncCallBack.CallBack.rfId != "")
            {
                rfId = AsyncCallBack.CallBack.rfId.ToUpper();
                AsyncCallBack.CallBack.rfId = "";
                if (canCount)
                {
                    PlaySoundFx(@"./Mounted.wav");
                    SendGuestCount();
                }
            }
        }

        private void SendGuestCount()
        {
            if (canCount)
            {
                Invoke(new EventHandler(LoadCredentials));
                Respond.SendToServer("@");
                canCount = false;
            }
        }
        private void LoadCredentials(object sender, EventArgs e)
        {
            var myCredentials = Respond.SendLoop("=" + rfId);
            lblName.Text = myCredentials.name;
            lblPoints.Text = myCredentials.points;
            var newBal = Convert.ToInt32(myCredentials.balance) - gameAmout;
            lblBalance.Text = newBal.ToString();
        }
        private void connectionCheck_Tick(object sender, EventArgs e)
        {
            intConnectionChecker = sc.connected;
            if (sc.parentFormClose)
            {
                Close();
            }

            if (intConnectionChecker == 1)
            {
                canResume = true;
                PauseGame();
            }
            else if (intConnectionChecker == 2 && canResume && gameIsStart)
            {
                ResumeGame();
                canResume = false;
            }
            if (timeStop)
            {
                //cogTimer.Stop();
                timeStop = false;
            }
        }
        private void PauseGame()
        {
            gameTimer.Stop();
            cogTimer.Stop();
            changeTimer.Stop();
            bg.Stop();
            if (!endTimerCanTrig)
            {
                endingTimer.Pause();
            }
        }
        private void ResumeGame()
        {
            gameTimer.Start();
            cogTimer.Start();
            changeTimer.Start();
            bg.PlayLooping();
            if (!endTimerCanTrig)
            {
                endingTimer.Play();
            }
        }
        private void chckHard_OnChange(object sender, EventArgs e)
        {
            if (chckHard.Checked == true)
            {
                chckEasy.Checked = false;
                isHard = true;
                pnlHard.Visible = true;
                pnlEasy.Visible = false;
            }
            if (chckHard.Checked == false)
            {
                chckEasy.Checked = true;
                isHard = false;
                pnlHard.Visible = false;
                pnlEasy.Visible = true;
            }
        }

        private void chckEasy_OnChange(object sender, EventArgs e)
        {
            if (chckEasy.Checked == true)
            {
                chckHard.Checked = false;
                isHard = false;
                pnlEasy.Visible = true;
                pnlHard.Visible = false;
            }
            if (chckEasy.Checked == false)
            {
                chckHard.Checked = true;
                isHard = true;
                pnlEasy.Visible = false;
                pnlHard.Visible = true;
            }
        }

        void Play(string audioPath)
        {
            endingTimer = new MediaPlayer.MediaPlayer();
            endingTimer.Open(audioPath);
            endingTimer.Play();
        }
        void PlaySoundFx(string audioPath)
        {
            playSoundFx = new MediaPlayer.MediaPlayer();
            playSoundFx.Open(audioPath);
            playSoundFx.Play();
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            /*bg.Play();
            fxWin.Open(@"./Alert.wav");
            fxWin.Play();
            Play(@"./Timer12.8sec.wav");*/
            startChange = 1;
            startBtn();
        }

        private void closingTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
            closingTimer.Stop();
        }

        private void CognitiveForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void runningLights_Tick(object sender, EventArgs e)
        {
            runLights();
        }
        void runLights()
        {
            lightsOff();
            for (int a = 0; a < 20; a++, iterateCh += 3)
            {
                dmxValues[iterateCh] = Convert.ToByte(255);
            }
            if (iterateCh > 328) 
            {
                blueLight();
                runningLights.Stop();
                gameOverTimer.Start();
            }
        }
        private void gameOverTimer_Tick(object sender, EventArgs e)
        {
            if (gameIsStart == false)
            {
                trigGameOver();
                if (isBeaten == true)
                {
                    gotBeaten.Play();
                }
                else if (isBeaten == false)
                {
                    notBeaten.Play();
                }

            }
            else if (gameIsStart == true)
            {
                gameOverTimer.Interval = 500;
                cogTimer.Start();
                gameTimer.Start();
                changeTimer.Start();
                lightsOff();
                gameOverTimer.Stop();
                canTap = true;
                bg.PlayLooping();
            }
        }

        void trigGameOver()
        {
            lightsOff();
            startChange = 1;
            canClick_24_StartBtn = true;
            startBtn();
            randomRGBTimer.Start();
            lblIndicator.Visible = false;
            btnCogStart.Visible = true;
            if (score > hScore)
            {
                isBeaten = true;
                File.WriteAllText(@".\HighScore.txt", score.ToString());
                hScore = Convert.ToInt32(File.ReadAllText(@".\HighScore.txt"));
                lblHScore.Text = hScore.ToString();
            }
            else
            {
                isBeaten = false;
            }
            gameOverTimer.Stop();
        }

        private void btnCogStart_Click(object sender, EventArgs e)
        {
            startBlueLight();
            gameStart.Play();
            randomRGBTimer.Stop();
            btnCogStart.Visible = false;
            lblIndicator.Text = "Game Started";
            lblIndicator.Visible = true;
            gameReset();
            changIndicator = false;
            runningLights.Start();
            lblTimer.ForeColor = Color.WhiteSmoke;
            gameIsStart = true;
            disableChk();
        }
        void disableChk()
        {
            chckEasy.Enabled = false;
            chckHard.Enabled = false;
        }
        void enableChk()
        {
            chckEasy.Enabled = true;
            chckHard.Enabled = true;
        }
        void startBlueLight()
        {
            startChange = 0;
            canClick_24_StartBtn = false;
            startBtn();
        }
        private void cogTimer_Tick(object sender, EventArgs e)
        {
            Invoke(new EventHandler(runCog));
        }

        void runCog(object sender, EventArgs e)
        {
            ms = gameTimer.ElapsedMilliseconds;
            gtVal = 60000 - Convert.ToDouble(ms);
            gtVal = (gtVal / 60000) * 100;

            if (ms >= 50000 && endTimerCanTrig == true)
            {
                Play(@"./Timer12.8sec.wav");
                endTimerCanTrig = false;
            }

            if (ms >= 60000)
            {
                timerProgress.Value = 0;
                lblIndicator.Visible = true;
                gameTimer.Stop();
                cogTimer.Stop();
                changeTimer.Stop();
                timerProgress.ForeColor = Color.FromArgb(224, 224, 224);
                lblTimer.ForeColor = Color.FromArgb(192, 0, 0);
                lblIndicator.ForeColor = Color.FromArgb(192, 0, 0);
                lblIndicator.Text = "Game Over";
                lightsOff();
                gameIsStart = false;
                canTap = false;
                canCount = true;
                iterateCh = 0;
                gameOverTimer.Interval = 3000;
                gameOverTimer.Start();
                finalScore();
                blueLight();
                bg.Stop();
                gameOver.Play();
                endingTimer.Stop();
                endTimerCanTrig = true;
                startBlueLight();
                sc.TransferData(signature, appName, score.ToString(), rfId, lblName.Text);
                sc.SendScore(rfId, score.ToString(), lblBalance.Text);
                rfId = "";
                ClrLbl();
                enableChk();
            }
            else
            {
                timerProgress.Value = Convert.ToInt32(gtVal);
                if (timerProgress.Value <= 50 && timerProgress.Value > 20)
                {
                    colr = Color.FromArgb(192, 192, 0);
                    timerProgress.ProgressColor = colr;
                    timerProgress.ForeColor = colr;
                }
                if (timerProgress.Value <= 20)
                {
                    colr = Color.FromArgb(192, 0, 0);
                    timerProgress.ProgressColor = colr;
                    timerProgress.ForeColor = colr;
                }
            }
            if (changIndicator == false)
            {
                changIndicator = true;
                lblTimer.ForeColor = colr;
            }
            else if (changIndicator == true)
            {
                changIndicator = false;
                lblTimer.ForeColor = Color.WhiteSmoke;
            }
        }
        void TransferData(string score, string id)
        {
            SFItem = new StringTransferItem();
            SFTManager = new TransferManager();
            SFItem.TransSignature = signature;
            SFItem.AppName = appName;
            SFItem.Score = score;
            SFItem.ID = id;
            SFItem.User = lblName.Text;

            SFTManager.SetAndSend(SFItem);
        }
        private void SendScore()
        {
            Respond myRespond = new Respond();
            SocketConnectionLib.Respond.SendUpdatedData2(rfId, score.ToString(), lblBalance.Text);
        }
        private void ClrLbl()
        {
            lblName.Text = "";
            lblPoints.Text = "";
            lblBalance.Text = "";
        }
        private void changeTimer_Tick(object sender, EventArgs e)
        {
            startChange = 2;
            startBtn();
            Invoke(new EventHandler(randomOn));
        }

        void randomOn(object sender, EventArgs e)
        {
            lightsOff();
            if (isHard == false)
            {
                OnEasy();
            }
            else if (isHard == true)
            {
                OnHard();
            }
        }

        private void randomRGBTimer_Tick(object sender, EventArgs e)
        {
            runningRandomLignts();
        }

        void runningRandomLignts()
        {
            lightsOff();
            randomLights();
        }

        void close()
        {
            randomRGBTimer.Stop();
            lightsOff();
        }

        public void btnClose_Click(object sender, EventArgs e)
        {
            FormWillClose();
        }

        private void FormWillClose()
        {
            close();
            closingTimer.Start();
        }
        Color colr = Color.FromArgb(0, 192, 0);
        System.Diagnostics.Stopwatch gameTimer = new System.Diagnostics.Stopwatch();

        Random LEDNum;

        private string MOXA_CSharp_MXI01;

        void lightsOff()
        {
            for (i = 0; i < 288; i++)
            {
                dmxValues[i] = Convert.ToByte(0);
            }
        }

        void lightsOn()
        {
            for (i = 2; i < 288; i += 3)
            {
                if (i == 74 || i == 77 || i == 80 || i == 83 || i == 134 || i == 137 || i == 140 || i == 143 || i == 182 || i == 185 || i == 188 || i == 191 || i == 278 || i == 281 || i == 284 || i == 287)
                {
                    inverted = i - 1;
                    dmxValues[inverted] = Convert.ToByte(255);
                }
                else
                {
                    dmxValues[i] = Convert.ToByte(255);
                }
            }
        }

        void matchLight(int ledAddress)
        {
            if (ledAddress == 0)
            {
                dmxValues[2] = Convert.ToByte(255);
                dmxValues[5] = Convert.ToByte(255);
                dmxValues[8] = Convert.ToByte(255);
                dmxValues[11] = Convert.ToByte(255);
            }
            if (ledAddress == 1)
            {
                dmxValues[14] = Convert.ToByte(255);
                dmxValues[17] = Convert.ToByte(255);
                dmxValues[20] = Convert.ToByte(255);
                dmxValues[23] = Convert.ToByte(255);
            }
            if (ledAddress == 2)
            {
                dmxValues[26] = Convert.ToByte(255);
                dmxValues[29] = Convert.ToByte(255);
                dmxValues[32] = Convert.ToByte(255);
                dmxValues[35] = Convert.ToByte(255);
            }
            if (ledAddress == 3)
            {
                dmxValues[38] = Convert.ToByte(255);
                dmxValues[41] = Convert.ToByte(255);
                dmxValues[44] = Convert.ToByte(255);
                dmxValues[47] = Convert.ToByte(255);
            }
            if (ledAddress == 4)
            {
                dmxValues[50] = Convert.ToByte(255);
                dmxValues[53] = Convert.ToByte(255);
                dmxValues[56] = Convert.ToByte(255);
                dmxValues[59] = Convert.ToByte(255);
            }
            if (ledAddress == 5)
            {
                dmxValues[62] = Convert.ToByte(255);
                dmxValues[65] = Convert.ToByte(255);
                dmxValues[68] = Convert.ToByte(255);
                dmxValues[71] = Convert.ToByte(255);
            }
            if (ledAddress == 6)
            {
                //inverted
                dmxValues[73] = Convert.ToByte(255);
                dmxValues[76] = Convert.ToByte(255);
                dmxValues[79] = Convert.ToByte(255);
                dmxValues[82] = Convert.ToByte(255);
            }
            if (ledAddress == 7)
            {
                dmxValues[86] = Convert.ToByte(255);
                dmxValues[89] = Convert.ToByte(255);
                dmxValues[92] = Convert.ToByte(255);
                dmxValues[95] = Convert.ToByte(255);
            }
            if (ledAddress == 8)
            {
                dmxValues[98] = Convert.ToByte(255);
                dmxValues[101] = Convert.ToByte(255);
                dmxValues[104] = Convert.ToByte(255);
                dmxValues[107] = Convert.ToByte(255);
            }
            if (ledAddress == 9)
            {
                dmxValues[110] = Convert.ToByte(255);
                dmxValues[113] = Convert.ToByte(255);
                dmxValues[116] = Convert.ToByte(255);
                dmxValues[119] = Convert.ToByte(255);
            }
            if (ledAddress == 10)
            {
                dmxValues[122] = Convert.ToByte(255);
                dmxValues[125] = Convert.ToByte(255);
                dmxValues[128] = Convert.ToByte(255);
                dmxValues[131] = Convert.ToByte(255);
            }
            if (ledAddress == 11)
            {
                //inverted
                dmxValues[133] = Convert.ToByte(255);
                dmxValues[136] = Convert.ToByte(255);
                dmxValues[139] = Convert.ToByte(255);
                dmxValues[142] = Convert.ToByte(255);
            }
            if (ledAddress == 12)
            {
                dmxValues[146] = Convert.ToByte(255);
                dmxValues[149] = Convert.ToByte(255);
                dmxValues[152] = Convert.ToByte(255);
                dmxValues[155] = Convert.ToByte(255);
            }
            if (ledAddress == 13)
            {
                dmxValues[158] = Convert.ToByte(255);
                dmxValues[161] = Convert.ToByte(255);
                dmxValues[164] = Convert.ToByte(255);
                dmxValues[167] = Convert.ToByte(255);
            }
            if (ledAddress == 14)
            {
                dmxValues[170] = Convert.ToByte(255);
                dmxValues[173] = Convert.ToByte(255);
                dmxValues[176] = Convert.ToByte(255);
                dmxValues[179] = Convert.ToByte(255);
            }
            if (ledAddress == 15)
            {
                //inverted
                dmxValues[181] = Convert.ToByte(255);
                dmxValues[184] = Convert.ToByte(255);
                dmxValues[187] = Convert.ToByte(255);
                dmxValues[190] = Convert.ToByte(255);
            }
            if (ledAddress == 16)
            {
                dmxValues[194] = Convert.ToByte(255);
                dmxValues[197] = Convert.ToByte(255);
                dmxValues[200] = Convert.ToByte(255);
                dmxValues[203] = Convert.ToByte(255);
            }
            if (ledAddress == 17)
            {
                dmxValues[206] = Convert.ToByte(255);
                dmxValues[209] = Convert.ToByte(255);
                dmxValues[212] = Convert.ToByte(255);
                dmxValues[215] = Convert.ToByte(255);
            }
            if (ledAddress == 18)
            {
                dmxValues[218] = Convert.ToByte(255);
                dmxValues[221] = Convert.ToByte(255);
                dmxValues[224] = Convert.ToByte(255);
                dmxValues[227] = Convert.ToByte(255);
            }
            if (ledAddress == 19)
            {
                dmxValues[230] = Convert.ToByte(255);
                dmxValues[233] = Convert.ToByte(255);
                dmxValues[236] = Convert.ToByte(255);
                dmxValues[239] = Convert.ToByte(255);
            }
            if (ledAddress == 20)
            {
                dmxValues[242] = Convert.ToByte(255);
                dmxValues[245] = Convert.ToByte(255);
                dmxValues[248] = Convert.ToByte(255);
                dmxValues[251] = Convert.ToByte(255);
            }
            if (ledAddress == 21)
            {
                dmxValues[254] = Convert.ToByte(255);
                dmxValues[257] = Convert.ToByte(255);
                dmxValues[260] = Convert.ToByte(255);
                dmxValues[263] = Convert.ToByte(255);
            }
            if (ledAddress == 22)
            {
                dmxValues[266] = Convert.ToByte(255);
                dmxValues[269] = Convert.ToByte(255);
                dmxValues[272] = Convert.ToByte(255);
                dmxValues[275] = Convert.ToByte(255);
            }
            if (ledAddress == 23)
            {
                //inverted
                dmxValues[277] = Convert.ToByte(255);
                dmxValues[280] = Convert.ToByte(255);
                dmxValues[283] = Convert.ToByte(255);
                dmxValues[286] = Convert.ToByte(255);
            }
        }

        void blueLight()
        {
            for (i = 1; i < 288; i += 3)
            {
                if (i == 73 || i == 76 || i == 79 || i == 82 || i == 133 || i == 136 || i == 139 || i == 142 || i == 181 || i == 184 || i == 187 || i == 190 || i == 277 || i == 280 || i == 283 || i == 286)
                {
                    inverted = i + 1;
                    dmxValues[inverted] = Convert.ToByte(255);
                }
                else
                {
                    dmxValues[i] = Convert.ToByte(255);
                }   
            }
        }

        private void CognitiveForm_Load(object sender, EventArgs e)
        {
            ArtNet.ArtNet.Initialize();
            ArtNet.ArtNet.SendArtPoll(ArtLynxIPAdd);
            ArtNet.ArtNet.SendArtPollReply(ArtLynxIPAdd);
            ArtNet.ArtNet.SendArtDmx(ArtLynxIPAdd, 0, 1, dmxValues);

            moxa1 = new IOLogik1210();
            moxa2 = new IOLogik1210();
            reading = true;
            startReading = new Thread(startRead_InOut);
            startReading.Start();
            randomRGBTimer.Start();
            gameIsStart = false;

            hScore = Convert.ToInt32(File.ReadAllText(@".\HighScore.txt"));
            lblHScore.Text = hScore.ToString();

            chckEasy.Checked = true;
            pnlEasy.Visible = true;
            startChange = 1;
            startBtn();

            sc.Owner = this;
            sc.ShowDialog();
            if (sc.parentFormClose)
            {
                FormWillClose();
                return;
            }
            canCount = true;
            connectionCheck.Start();
        }

        void startBtn()
        {
            startOff();
            if (startChange == 0)
            {
                dmxValues[290] = Convert.ToByte(255);
                dmxValues[293] = Convert.ToByte(255);
                dmxValues[296] = Convert.ToByte(255);
                dmxValues[299] = Convert.ToByte(255);
            }
            else if (startChange == 1)
            {
                dmxValues[289] = Convert.ToByte(255);
                dmxValues[292] = Convert.ToByte(255);
                dmxValues[295] = Convert.ToByte(255);
                dmxValues[298] = Convert.ToByte(255);
            }
            else if (startChange == 2)
            {
                dmxValues[288] = Convert.ToByte(255);
                dmxValues[291] = Convert.ToByte(255);
                dmxValues[294] = Convert.ToByte(255);
                dmxValues[297] = Convert.ToByte(255);
            }
        }
        void startOff()
        {
            for (int ini = 0; ini < 12; ini++)
            {
                dmxValues[288 + ini] = Convert.ToByte(0);
            }
        }
        void startRead_InOut()
        {
            while (reading)
            {

                try
                {
                    ArtNet.ArtNet.SendArtDmx(ArtLynxIPAdd, 0, 1, dmxValues);
                    //ArtNet.ArtNet.SendArtDmx(ArtLynxIPAdd, 0, 2, dmxValues);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

                try
                {
                        moxa1.Read(Moxa1IpAdd);
                        moxa2.Read(Moxa2IpAdd);                  
                }
                catch
                {
                    MessageBox.Show("The Controller is disconnected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Invoke(new EventHandler(MoxaData));
            }
        }

        private void CognitiveForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            startReading.Abort();
            if (intConnectionChecker == 2)
            {
                DisconnectFromServer();
            }
        }
        private void DisconnectFromServer()
        {
            string deviceInfo = System.Environment.MachineName + " " + Respond._publicClientSocket.LocalEndPoint.ToString();
            Respond.SendToServer("-" + deviceInfo);
        }

        void MoxaData(object sender, EventArgs e)
        {
            Moxa1 = new char[16];
            Moxa2 = new char[16];

            Moxa1 = moxa1.DigitalInput;
            Moxa2 = moxa2.DigitalInput;


            if (gameIsStart == true && canTap == true && intConnectionChecker == 2)
            {
                lblInput.Text = Moxa1[0].ToString() + Moxa1[1] + Moxa1[2] + Moxa1[3] + Moxa1[4] + Moxa1[5] + Moxa1[6] + Moxa1[7] + Moxa1[8] + Moxa1[9] + Moxa1[10] + Moxa1[11] + Moxa1[12] + Moxa1[13] + Moxa1[14] + Moxa1[15] + "|" + Moxa2[0] + Moxa2[1] + Moxa2[2] + Moxa2[3] + Moxa2[4] + Moxa2[5] + Moxa2[6] + Moxa2[7] + Moxa2[8] + Moxa2[9] + Moxa2[10] + Moxa2[11] + Moxa2[12] + Moxa2[13] + Moxa2[14] + Moxa2[15];

                if (Moxa1[0] == '1')
                {
                    if (canClick_0 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_0 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_0 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 0;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa1[1] == '1')
                {
                    if (canClick_1 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_1 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_1 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 12;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa1[2] == '1')
                {
                    if (canClick_2 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_2 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_2 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 24;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa1[3] == '1')
                {
                    if (canClick_3 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_3 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_3 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 36;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa1[4] == '1')
                {
                    if (canClick_4 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_4 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_4 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 48;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa1[5] == '1')
                {
                    if (canClick_5 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_5 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_5 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 60;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa1[6] == '1')
                {
                    if (canClick_6 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_6 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_6 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 72;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa1[7] == '1')
                {
                    if (canClick_7 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_7 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_7 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 84;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa1[10] == '1')
                {
                    if (canClick_8 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_8 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_8 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 96;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa1[11] == '1')
                {
                    if (canClick_9 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_9 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_9 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 108;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa1[12] == '1')
                {
                    if (canClick_10 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_10 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_10 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 120;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa1[13] == '1')
                {
                    if (canClick_11 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_11 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_11 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 132;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa1[14] == '1')
                {
                    if (canClick_12 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_12 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_12 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 144;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa1[15] == '1')
                {
                    if (canClick_13 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_13 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_13 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 156;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa2[0] == '1')
                {
                    if (canClick_14 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_14 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_14 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 168;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa2[1] == '1')
                {
                    if (canClick_15 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_15 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_15 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 180;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa2[4] == '1')
                {
                    if (canClick_16 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_16 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_16 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 192;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa2[5] == '1')
                {
                    if (canClick_17 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_17 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_17 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 204;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa2[6] == '1')
                {
                    if (canClick_18 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_18 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_18 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 216;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa2[7] == '1')
                {
                    if (canClick_19 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_19 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_19 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 228;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa2[8] == '1')
                {
                    if (canClick_20 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_20 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_20 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 240;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa2[9] == '1')
                {
                    if (canClick_21 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_21 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_21 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 252;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa2[10] == '1')
                {
                    if (canClick_22 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_22 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_22 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 264;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
                if (Moxa2[11] == '1')
                {
                    if (canClick_23 == true)
                    {
                        fxWin.Open(@"./Alert.wav");
                        fxWin.Play();
                        Invoke(new EventHandler(randomOn));
                        score++;
                        lblScore.Text = score.ToString();
                        canClick_23 = false;
                        changeTimer.Stop();
                        changeTimer.Start();
                    }
                    else if (canClick_23 == false)
                    {
                        fxFail.Open(@"./Warning.wav");
                        fxFail.Play();
                        int y = 276;
                        for (int x = 0; x < 4; x++)
                        {
                            dmxValues[y] = Convert.ToByte(255);
                            y += 3;
                        }
                    }
                }
            }
            if (canClick_24_StartBtn == true && intConnectionChecker == 2 && rfId != "")
            {
                if (Moxa2[12] == '1')
                {
                    Invoke(new EventHandler(btnCogStart_Click));
                    canClick_24_StartBtn = false;
                }
            }
        }
        void gameReset()
        {
            gameTimer.Reset();
            lightsOff();
            ms = 0;
            score = 0;
            scoreRate.Value = 0;
            lblScore.Text = score.ToString();
            colr = Color.FromArgb(0, 192, 0);
            timerProgress.Value = 100;
            timerProgress.ProgressColor = colr;
            timerProgress.ForeColor = colr;
            canClick_0 = false;
            canClick_1 = false;
            canClick_2 = false;
            canClick_3 = false;
            canClick_4 = false;
            canClick_5 = false;
            canClick_6 = false;
            canClick_7 = false;
            canClick_8 = false;
            canClick_9 = false;
            canClick_10 = false;
            canClick_11 = false;
            canClick_12 = false;
            canClick_13 = false;
            canClick_14 = false;
            canClick_15 = false;
            canClick_16 = false;
            canClick_17 = false;
            canClick_18 = false;
            canClick_19 = false;
            canClick_20 = false;
            canClick_21 = false;
            canClick_22 = false;
            canClick_23 = false;
            canClick_24_StartBtn = true;

            lblIndicator.ForeColor = Color.FromArgb(224, 224, 224);
        }

        int OnEasy()
        {
            LEDNum = new Random();
            cogInt = LEDNum.Next(0, 24);
            //OutputMoxa1(1, Convert.ToByte(LEDInt), ON);
            if (cogInt == 0)
            {
                matchLight(cogInt);
                canClick_0 = true;
            }
            if (cogInt == 1)
            {
                matchLight(cogInt);
                canClick_1 = true;
            }
            if (cogInt == 2)
            {
                matchLight(cogInt);
                canClick_2 = true;
            }
            if (cogInt == 3)
            {
                matchLight(cogInt);
                canClick_3 = true;
            }
            if (cogInt == 4)
            {
                matchLight(cogInt);
                canClick_4 = true;
            }
            if (cogInt == 5)
            {
                matchLight(cogInt);
                canClick_5 = true;
            }
            if (cogInt == 6)
            {
                matchLight(cogInt);
                canClick_6 = true;
            }
            if (cogInt == 7)
            {
                matchLight(cogInt);
                canClick_7 = true;
            }
            if (cogInt == 8)
            {
                matchLight(cogInt);
                canClick_8 = true;
            }
            if (cogInt == 9)
            {
                matchLight(cogInt);
                canClick_9 = true;
            }
            if (cogInt == 10)
            {
                matchLight(cogInt);
                canClick_10 = true;
            }
            if (cogInt == 11)
            {
                matchLight(cogInt);
                canClick_11 = true;
            }
            if (cogInt == 12)
            {
                matchLight(cogInt);
                canClick_12 = true;
            }
            if (cogInt == 13)
            {
                matchLight(cogInt);
                canClick_13 = true;
            }
            if (cogInt == 14)
            {
                matchLight(cogInt);
                canClick_14 = true;
            }
            if (cogInt == 15)
            {
                matchLight(cogInt);
                canClick_15 = true;
            }
            if (cogInt == 16)
            {
                matchLight(cogInt);
                canClick_16 = true;
            }
            if (cogInt == 17)
            {
                matchLight(cogInt);
                canClick_17 = true;
            }
            if (cogInt == 18)
            {
                matchLight(cogInt);
                canClick_18 = true;
            }
            if (cogInt == 19)
            {
                matchLight(cogInt);
                canClick_19 = true;
            }
            if (cogInt == 20)
            {
                matchLight(cogInt);
                canClick_20 = true;
            }
            if (cogInt == 21)
            {
                matchLight(cogInt);
                canClick_21 = true;
            }
            if (cogInt == 22)
            {
                matchLight(cogInt);
                canClick_22 = true;
            }
            if (cogInt == 23)
            {
                matchLight(cogInt);
                canClick_23 = true;
            }
            return cogInt;
        }

        void OnHard()
        {
            int compare = OnEasy();
            LEDNum = new Random();
            cogInt2 = LEDNum.Next(0, 24);
            while (cogInt2 == compare)
            {
                cogInt2 = LEDNum.Next(0, 24);
            }
            //OutputMoxa1(1, Convert.ToByte(LEDInt), ON);
            if (cogInt2 == 0)
            {
                matchLight(cogInt2);
                canClick_0 = true;
            }
            if (cogInt2 == 1)
            {
                matchLight(cogInt2);
                canClick_1 = true;
            }
            if (cogInt2 == 2)
            {
                matchLight(cogInt2);
                canClick_2 = true;
            }
            if (cogInt2 == 3)
            {
                matchLight(cogInt2);
                canClick_3 = true;
            }
            if (cogInt2 == 4)
            {
                matchLight(cogInt2);
                canClick_4 = true;
            }
            if (cogInt2 == 5)
            {
                matchLight(cogInt2);
                canClick_5 = true;
            }
            if (cogInt2 == 6)
            {
                matchLight(cogInt2);
                canClick_6 = true;
            }
            if (cogInt2 == 7)
            {
                matchLight(cogInt2);
                canClick_7 = true;
            }
            if (cogInt2 == 8)
            {
                matchLight(cogInt2);
                canClick_8 = true;
            }
            if (cogInt2 == 9)
            {
                matchLight(cogInt2);
                canClick_9 = true;
            }
            if (cogInt2 == 10)
            {
                matchLight(cogInt2);
                canClick_10 = true;
            }
            if (cogInt2 == 11)
            {
                matchLight(cogInt2);
                canClick_11 = true;
            }
            if (cogInt2 == 12)
            {
                matchLight(cogInt2);
                canClick_12 = true;
            }
            if (cogInt2 == 13)
            {
                matchLight(cogInt2);
                canClick_13 = true;
            }
            if (cogInt2 == 14)
            {
                matchLight(cogInt2);
                canClick_14 = true;
            }
            if (cogInt2 == 15)
            {
                matchLight(cogInt2);
                canClick_15 = true;
            }
            if (cogInt2 == 16)
            {
                matchLight(cogInt2);
                canClick_16 = true;
            }
            if (cogInt2 == 17)
            {
                matchLight(cogInt2);
                canClick_17 = true;
            }
            if (cogInt2 == 18)
            {
                matchLight(cogInt2);
                canClick_18 = true;
            }
            if (cogInt2 == 19)
            {
                matchLight(cogInt2);
                canClick_19 = true;
            }
            if (cogInt2 == 20)
            {
                matchLight(cogInt2);
                canClick_20 = true;
            }
            if (cogInt2 == 21)
            {
                matchLight(cogInt2);
                canClick_21 = true;
            }
            if (cogInt2 == 22)
            {
                matchLight(cogInt2);
                canClick_22 = true;
            }
            if (cogInt2 == 23)
            {
                matchLight(cogInt2);
                canClick_23 = true;
            }
        }
        void Off()
        {
            if (cogInt == 0)
            {
                canClick_0 = false;
            }
            if (cogInt == 1)
            {
                canClick_1 = false;
            }
            if (cogInt == 2)
            {
                canClick_2 = false;
            }
            if (cogInt == 3)
            {
                canClick_3 = false;
            }
            if (cogInt == 4)
            {
                canClick_4 = false;
            }
            if (cogInt == 5)
            {
                canClick_5 = false;
            }
            if (cogInt == 6)
            {
                canClick_6 = false;
            }
            if (cogInt == 7)
            {
                canClick_7 = false;
            }
            if (cogInt == 8)
            {
                canClick_8 = false;
            }
            if (cogInt == 9)
            {
                canClick_9 = false;
            }
            if (cogInt == 10)
            {
                canClick_10 = false;
            }
            if (cogInt == 11)
            {
                canClick_11 = false;
            }
            if (cogInt == 12)
            {
                canClick_12 = false;
            }
            if (cogInt == 13)
            {
                canClick_13 = false;
            }
            if (cogInt == 14)
            {
                canClick_14 = false;
            }
            if (cogInt == 15)
            {
                canClick_15 = false;
            }
            if (cogInt == 16)
            {
                canClick_16 = false;
            }
            if (cogInt == 17)
            {
                canClick_17 = false;
            }
            if (cogInt == 18)
            {
                canClick_18 = false;
            }
            if (cogInt == 19)
            {
                canClick_19 = false;
            }
            if (cogInt == 20)
            {
                canClick_20 = false;
            }
            if (cogInt == 21)
            {
                canClick_21 = false;
            }
            if (cogInt == 22)
            {
                canClick_22 = false;
            }
            if (cogInt == 23)
            {
                canClick_23 = false;
            }
        }
        void finalScore()
        {
            if (score <= 19)
            {
                scoreRate.Value = 0;
            }
            else if (score >= 20 && score <= 39)
            {
                scoreRate.Value = 1;
            }
            else if (score >= 40 && score <= 59)
            {
                scoreRate.Value = 2;
            }
            else if (score >= 60 && score <= 79)
            {
                scoreRate.Value = 3;
            }
            else if (score >= 80 && score <= 99)
            {
                scoreRate.Value = 4;
            }
            else if (score >= 100)
            {
                scoreRate.Value = 5;
            }
        }
        void randomLights()
        {
            for (cogCount = 0, randomIncrement =0; cogCount < 24; cogCount++, randomIncrement+=12)
            {
                randomInt_1 = randomNum.Next(randomIncrement, randomIncrement+3);
                for (int a = 0; a < 4; a++)
                {
                    dmxValues[randomInt_1] = Convert.ToByte(255);
                    randomInt_1 += 3;
                }
            }
        }
    }
}
