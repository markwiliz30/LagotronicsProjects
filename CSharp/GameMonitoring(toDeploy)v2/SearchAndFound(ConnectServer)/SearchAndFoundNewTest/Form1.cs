using MagicStoneKingdomDeviceControl;
using SearchAndFoundNewTest.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingPanelResources;
using SavingDataLib.TransferClasses;
using System.Net.Sockets;
using System.Net;
using SocketConnectionLib;
using SavingDataLib;

namespace SearchAndFoundNewTest
{
    public partial class Form1 : Form, IDeviceControllerForm
    {
        string signature = "LAGOTRONICS";
        string appName = "Search_And_Found";
        string rfId = "";
        int gameAmout = 10;
        private Decimal readLength = new Decimal(8);
        private MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager;
        private NPortSerialDeviceServerController controller_1, controller_2;
        private IOLogikE1210DigitalInputServerController controller_btn_1;
        private Thread inputThread_1, inputThread_2;
        DigitalSignalUI digitalSignalUi;
        private bool synchronizingFormControls;
        CShot _shot;
        CFindBg _findBg;
        CHero _heroFind;
        CSplashScreen _splashScreen;
        bool canChange = false, heroCanDispose = false, splashCanDispose = false, isStarted = false, gameOver = false, valid = false, isPressed, entered, gameIsRunning = false, endingTimerCanOff = false;
        bool canResume = false, timeStop = false, canCount = false;
        int leftMove = 0;
        int topMove = 0;
        int splashIndicator = 3, numBg, numHero, holdNumHero, hits = 0, miss = 0, findTimer = 20, hHits, hMiss;
        int intCountDown = 60;
        Bitmap bgPic, heroPic, splashPic;
        int[] encoderValues_1 = new int[16];
        int[] encoderValues_2 = new int[16];
        int intConnectionChecker = 1;

        int locX = 0, locY = 0, sizeW = 100, sizeL = 100;

        SoundPlayer backgoundSound = new SoundPlayer(@"./background.wav");
        MediaPlayer.MediaPlayer soundFx;
        MediaPlayer.MediaPlayer endingTimer;

        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string deviceInfo;
        ServerConnect sc = new ServerConnect();
        StringTransferItem SFItem;
        TransferManager SFTManager;
        GetCredentials updateCredits;

        public bool a;
        public Form1(MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager, NPortSerialDeviceServerController controller_1, NPortSerialDeviceServerController controller_2, IOLogikE1210DigitalInputServerController controller_btn_1)
        {
            InitializeComponent();
            this.magicStoneKingdomDeviceControlManager = magicStoneKingdomDeviceControlManager;
            this.controller_1 = controller_1;
            this.controller_2 = controller_2;
            this.controller_btn_1 = controller_btn_1;

            digitalSignalUi = Controls.Find("digitalSignalUIDI" + 0.ToString(), false)[0] as DigitalSignalUI;
            switch (controller_btn_1.GetDigitalInputChannelModes((byte)0, (byte)1)[0])
            {
                case IOLogikDigitalInputChannelMode.DI:
                    digitalSignalUi.Mode = DigitalSignalUIMode.Input;
                    digitalSignalUi.BindToDigitalSignalInputInterface((DigitalSignalInputInterface)controller_btn_1.DigitalSignalInputInterfaces[0]);
                    break;
                case IOLogikDigitalInputChannelMode.Counter:
                    digitalSignalUi.Mode = DigitalSignalUIMode.Input_Counter;
                    digitalSignalUi.BindToDigitalInputCounterSignalInputInterface((DigitalInputCounterSignalInputInterface)controller_btn_1.DigitalInputCounterSignalInputInterfaces[0]);
                    break;
            }
            inputThread_1 = new Thread(new ThreadStart(InputThreadStart_1));
            inputThread_1.Start();
            inputThread_2 = new Thread(new ThreadStart(InputThreadStart_2));
            inputThread_2.Start();
            controller_1.InputInterface.OnInputChanged += new EventHandler(this.InputInterface_OnInputChanged);
            controller_2.InputInterface.OnInputChanged += new EventHandler(this.InputInterface_OnInputChanged_2);
            //_findBg = new CFindBg() { Left = 250, Top = 140 };
            //RandomBackground();
            //_bfFrame = new CBgFrame();
            _shot = new CShot() { Left = 500, Top = 500 };
            _findBg = new CFindBg(RandomBGround());
            _heroFind = new CHero(RandomHeroPic());
            _splashScreen = new CSplashScreen(SetSplashScreen());
            AsyncCallBack.CallBack.SetupServer();
        }
        /*void RandomBackground()
        {
            if (canChange)
            {
                findBg.Dispose();
                GC.SuppressFinalize(findBg);
                bgChanged = true;
            }
            Random randomBg = new Random();
            int numBg = randomBg.Next(0, 3);
            switch (numBg)
            {
                case 0:
                    findBg = new CImageBase(Resources.set1);
                    findBg.Left = 250;
                    findBg.Top = 140;
                    break;
                case 1:
                    findBg = new CImageBase(Resources.set2);
                    findBg.Left = 250;
                    findBg.Top = 140;
                    break;
                case 2:
                    findBg = new CImageBase(Resources.set3);
                    findBg.Left = 250;
                    findBg.Top = 140;
                    break;
            }
            bgChanged = false;
            canChange = true;
        }*/
        private void InputInterface_OnInputChanged(object sender, EventArgs e)
        {
            try
            {
                if (controller_1.InputInterface.InputSignal.SignalValue == null)
                    return;
                StringBuilder stringBuilder1 = new StringBuilder();
                for (int index = 0; index < controller_1.InputInterface.InputSignal.SignalValue.Length; ++index)
                {
                    encoderValues_1[index] = controller_1.InputInterface.InputSignal.SignalValue[index];
                    stringBuilder1.Append(controller_1.InputInterface.InputSignal.SignalValue[index].ToString());
                    stringBuilder1.Append(" ");
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void InputInterface_OnInputChanged_2(object sender, EventArgs e)
        {
            try
            {
                if (controller_2.InputInterface.InputSignal.SignalValue == null)
                    return;
                StringBuilder stringBuilder1 = new StringBuilder();
                for (int index = 0; index < controller_2.InputInterface.InputSignal.SignalValue.Length; ++index)
                {
                    encoderValues_2[index] = controller_2.InputInterface.InputSignal.SignalValue[index];
                    stringBuilder1.Append(controller_2.InputInterface.InputSignal.SignalValue[index].ToString());
                    stringBuilder1.Append(" ");
                }
            }
            catch (Exception ex)
            {
            }
        }
        Bitmap RandomBGround()
        {
            if (canChange)
            {
                _findBg.Dispose();
            }
            Random randomBg = new Random();
            numBg = randomBg.Next(0, 3);
            switch (numBg)
            {
                case 0:
                    bgPic = Resources.set1;
                    break;
                case 1:
                    bgPic = Resources.set2;
                    break;
                case 2:
                    bgPic = Resources.set3;
                    break;
            }
            canChange = true;
            return bgPic;
        }
        Bitmap RandomHeroPic()
        {
            if (heroCanDispose)
            {
                _heroFind.Dispose();
            }
            Random randomHero = new Random();
            numHero = randomHero.Next(0, 3);
            while (numHero == holdNumHero)
            {
                numHero = randomHero.Next(0, 3);
            }
            switch (numHero)
            {
                case 0:
                    heroPic = Resources.eagleFit;
                    break;
                case 1:
                    heroPic = Resources.lionFit;
                    break;
                case 2:
                    heroPic = Resources.sharFit;
                    break;
            }
            heroCanDispose = true;
            holdNumHero = numHero;
            return heroPic;
        }
        Bitmap SetSplashScreen()
        {
            if (splashCanDispose)
            {
                _splashScreen.Dispose();
            }
            switch (splashIndicator)
            {
                case 3:
                    splashPic = Resources.bluredReady;
                    break;
                case 2:
                    splashPic = Resources.bluredSet;
                    break;
                case 1:
                    splashPic = Resources.bluredGo;
                    break;
                case 0:
                    splashPic = Resources.gameOverSplash;
                    break;
            }
            splashCanDispose = true;
            return splashPic;
        }
        void GenerateRamdomBgAndHero()
        {
            GenerateRandomBg();
            GenerateRandomHero();
        }
        void ValidateScore()
        {
            entered = true;
            hits++;
            lblHits.Text = hits.ToString();
            PlayFx(@"./Alert.wav");
            findTimer = 20;
            lblfindTimer.Text = findTimer.ToString();
            intCountDown += 5;
            if (intCountDown >= 60)
            {
                intCountDown = 60;
                progGameTimer.Value = intCountDown;
            }
            else
            {
                progGameTimer.Value = intCountDown;
            }
            GenerateRamdomBgAndHero();
            CheckEndingTimer();
        }
        void ValidateWrongTarget()
        {
            entered = true;
            PlayFx(@"./Warning.wav");
            intCountDown -= 10;
        }
        void ValidateMiss()
        {
            GenerateRamdomBgAndHero();
            miss++;
            PlayFx(@"./Unmounted.wav");
            lblMiss.Text = miss.ToString();
        }
        void GenerateRandomBg()
        {
            _findBg = new CFindBg(RandomBGround());
        }
        void GenerateRandomHero()
        {
            _heroFind = new CHero(RandomHeroPic());
        }
        void GererateSplashScreen()
        {
            splashIndicator--;
            _splashScreen = new CSplashScreen(SetSplashScreen());
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;

            /*if (!bgChanged)
            {
                findBg.DrawImage(dc);
            }*/
            //_bfFrame.DrawImage(dc);
            _findBg.DrawImage(dc);
            _heroFind.DrawImage(dc);
            _shot.DrawImage(dc);
            if (isStarted || gameOver)
            {
                _splashScreen.DrawImage(dc);
            }
            base.OnPaint(e);
        }
        private void MoveShot()
        {
            _shot.Update(Convert.ToInt32(encoderValues_1[4] * 6.4) + 225, Convert.ToInt32(encoderValues_2[4] * 3.5) + 125);
        }

        void StartClick()
        {
            if (isPressed)
            {
                if (gameOver)
                {
                    Invoke(new EventHandler(GameOverSplash));
                }
                isStarted = true;
                GameReset();
                PlayFx(@"./Start.wav");
                startTimer.Start();
                GenerateRamdomBgAndHero();
            }
        }
        void GameOverSplash(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                gameOver = true;
                splashIndicator = 1;
                GererateSplashScreen();
            }
            else if (gameOver)
            {
                gameOver = false;
                splashIndicator = 4;
                GererateSplashScreen();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sc.Owner = this;
            sc.ShowDialog();
            canCount = true;
            connectionCheck.Start();
            try
            {
                rfPort.Open();
            }
            catch
            {
            }
        }
        void GetHighScore()
        {
            hHits = Convert.ToInt32(File.ReadAllText(@"./Hits.txt"));
            lblHhits.Text = hHits.ToString();
            hMiss = Convert.ToInt32(File.ReadAllText(@"./Miss.txt"));
            lblHmiss.Text = hMiss.ToString();
        }
        void CheckEndingTimer()
        {
            if (intCountDown == 5)
            {
                endingTimerCanOff = true;
                PlayEnding(@"./Timer12.8sec.wav");
            }
            else if (intCountDown <= 0 && endingTimerCanOff)
            {
                endingTimerCanOff = false;
                endingTimer.Stop();
            }
            else if (intCountDown > 5 && endingTimerCanOff)
            {
                endingTimerCanOff = false;
                endingTimer.Stop();
            }
        }
        void ValidateHighScore()
        {
            if (hits > hHits)
            {
                File.WriteAllText(@"./Hits.txt", hits.ToString());
                File.WriteAllText(@"./Miss.txt", miss.ToString());
                GetHighScore();
                PlayFx(@"./Win.wav");
            }
            else
            {
                PlayFx(@"./LoseV2.wav");
            }
        }
        void ChangePanel()
        {
            var point = new Point(locX, locY);
            var size = new Size(sizeW, sizeL);
            //pnlTracker.Location = point;
            //pnlTracker.Size = size;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            locX += 2;
            button10.Text = locX.ToString();
            button8.Text = locX.ToString();
            ChangePanel();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            locX -= 2;
            button10.Text = locX.ToString();
            button8.Text = locX.ToString();
            ChangePanel();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            locY += 2;
            button9.Text = locY.ToString();
            button7.Text = locY.ToString();
            ChangePanel();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            sizeW += 2;
            button14.Text = sizeW.ToString();
            button12.Text = sizeW.ToString();
            ChangePanel();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sizeL += 2;
            button13.Text = sizeL.ToString();
            button11.Text = sizeL.ToString();
            ChangePanel();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            sizeW -= 2;
            button14.Text = sizeW.ToString();
            button12.Text = sizeW.ToString();
            ChangePanel();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            sizeL -= 2;
            button13.Text = sizeL.ToString();
            button11.Text = sizeL.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            locY -= 2;
            button9.Text = locY.ToString();
            button7.Text = locY.ToString();
            ChangePanel();
        }

        private void button10_MouseDown(object sender, MouseEventArgs e)
        {
            Invoke(new EventHandler(button10_Click));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DisconnectFromServer();
            }
            catch
            {
                /*var result = MessageBox.Show("Ang server ay hindi nakasindi. mawawala ang data kapag sinara ang application. Sigurado kaba na gusto mong isara ang application na ito?", "Babala", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    return;
                }
                e.Cancel = true;*/
            }
            rfPort.Close();
        }
        private void DisconnectFromServer()
        {
            string deviceInfo = System.Environment.MachineName + " " + Respond._publicClientSocket.LocalEndPoint.ToString();
            Respond.SendToServer("-" + deviceInfo);
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
            else if (intConnectionChecker == 2 && canResume && gameIsRunning)
            {
                ResumeGame();
                canResume = false;
            }
            if (timeStop)
            {
                crossHeirTimer.Stop();
                timeStop = false;
            }
        }
        private void PauseGame()
        {
            countDownTimer.Stop();
            backgoundSound.Stop();
            if (endingTimerCanOff)
            {
                endingTimer.Pause();
            }
        }
        private void ResumeGame()
        {
            countDownTimer.Start();
            backgoundSound.PlayLooping();
            if (endingTimerCanOff)
            {
                endingTimer.Play();
            }
        }
        private void rfPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Invoke(new EventHandler(StartCrossHeirTimer));
            rfId = rfPort.ReadLine();
            rfId = rfId.Remove(rfId.Length -1);
            SendGuestCount();
        }
        private void SendGuestCount()
        {
            if (canCount)
            {
                Invoke(new EventHandler(LoadCredentials));
                Respond.SendToServer("#");
                canCount = false;
            }
        }
        private void button10_MouseHover(object sender, EventArgs e)
        {
            Invoke(new EventHandler(button10_Click));
        }

        private void button10_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void idChecker_Tick(object sender, EventArgs e)
        {
            if (AsyncCallBack.CallBack.rfId != null && AsyncCallBack.CallBack.rfId != "")
            {
                rfId = AsyncCallBack.CallBack.rfId.ToUpper();
                AsyncCallBack.CallBack.rfId = "";
                Invoke(new EventHandler(StartCrossHeirTimer));
                PlayFx(@"./Mounted.wav");
                SendGuestCount();
            }
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            Invoke(new EventHandler(button10_Click));
        }

        private void button10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { MessageBox.Show(""); }
        }

        private void crossHeirTimer_Tick(object sender, EventArgs e)
        {
            if (intConnectionChecker == 2)
            {
                crossHeirMove();
                TrigPushButton();
            }
        }
        void TrigPushButton()
        {
            isPressed = digitalSignalUi.DigitalSignal;
            if (gameIsRunning)
            {
                ConfirmTarget();
            }
            else
            {
                StartClick();
            }
        }
        void ConfirmTarget()
        {
            if (isPressed == false)
            {
                entered = false;
            }
            if (isPressed == true)
            {
                switch (numHero)
                {
                    case 0:
                        ValidateEagle();
                        break;
                    case 1:
                        ValidateLion();
                        break;
                    case 2:
                        ValidateShark(); 
                        break;
                }
            }
        }
        void PlayFx(string audioPath)
        {
            soundFx = new MediaPlayer.MediaPlayer();
            soundFx.Open(audioPath);
            soundFx.Play();
        }
        void PlayEnding(string audioPath)
        {
            endingTimer = new MediaPlayer.MediaPlayer();
            endingTimer.Open(audioPath);
            endingTimer.Play();
        }
        void crossHeirMove()
        {
            MoveShot();
            Refresh();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //LoadCredentials();
            //GenerateRandomBg();
            //sc.TopMost = true;
            /*if (rfId != "" || rfId != null)
            {
                GetCredentials myCredentials = new GetCredentials();
                SendReceive result = new SendReceive();
                myCredentials = result.SendRFID(rfId);
            }*/
        }
        private void LoadCredentials(object sender, EventArgs e)
        {
            var myCredentials = Respond.SendLoop("=" + rfId);
            lblName.Text = myCredentials.name;
            lblPoints.Text = myCredentials.points;
            var newBal = Convert.ToInt32(myCredentials.balance) - gameAmout;
            lblBalance.Text = newBal.ToString();
        }
        private void StartCrossHeirTimer(object sender, EventArgs e)
        {
            crossHeirTimer.Start();
        }
        private void countDownTimer_Tick(object sender, EventArgs e)
        {
            intCountDown--;
            findTimer--;
            progGameTimer.Value = intCountDown;
            if (intCountDown <= 0)
            {
                Invoke(new EventHandler(GameOverSplash));
                backgoundSound.Stop();
                PlayFx(@"./gameover.wav");
                startTimer.Start();
                startTimer.Interval = 2000;
                gameIsRunning = false;
                CheckEndingTimer();
                TransferData(hits.ToString(), rfId);
                countDownTimer.Stop();
                timeStop = true;
                canCount = true;
                Invoke(new EventHandler(SendScore));
                rfId = "";
                ClrLbl();
            }
            if (findTimer < 0)
            {
                ValidateMiss();
                findTimer = 20;
                lblfindTimer.Text = findTimer.ToString();
            }
            lblfindTimer.Text = findTimer.ToString();
            CheckEndingTimer();
        }
        private void ClrLbl()
        {
            lblName.Text = "";
            lblPoints.Text = "";
            lblBalance.Text = "";
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
        void GameReset()
        {
            intCountDown = 60;
            progGameTimer.Value = intCountDown;
            findTimer = 20;
            lblfindTimer.Text = findTimer.ToString();
            hits = 0;
            lblHits.Text = hits.ToString();
            miss = 0;
            lblMiss.Text = miss.ToString();
        }
        private void startTimer_Tick(object sender, EventArgs e)
        {
            if (gameOver)
            {
                ValidateHighScore();
                startTimer.Interval = 1000;
                startTimer.Stop();
                return;
            }
            if (splashIndicator <= 1)
            {
                isStarted = false;
                splashIndicator = 4;
                GererateSplashScreen();
                gameIsRunning = true;
                lblfindTimer.Text = findTimer.ToString();
                countDownTimer.Start();
                backgoundSound.PlayLooping();
                startTimer.Stop();
            }
            else
            {
                GererateSplashScreen();
            }      
        }

        public void SynchronizeFormControls()
        {
            synchronizingFormControls = true;
            synchronizingFormControls = false;
        }
        public Decimal ReadLength
        {
            get
            {
                return readLength;
            }
            set
            {
                readLength = value;
            }
        }
        private void InputThreadStart_1()
        {
            while (true)
                controller_1.InputInterface.PollInput((int)this.ReadLength);
        }
        private void InputThreadStart_2()
        {
            while (true)
                controller_2.InputInterface.PollInput((int)this.ReadLength);
        }
        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            inputThread_1.Abort();
            inputThread_2.Abort();
            magicStoneKingdomDeviceControlManager.DisconnectNPortSerialDeviceServerController(controller_1.Name);
            magicStoneKingdomDeviceControlManager.DisconnectNPortSerialDeviceServerController(controller_2.Name);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            /*if (!isStarted)
            {
                isStarted = true;
            }
            else if (isStarted)
            {
                isStarted = false;
            }*/
            //SFanimator.Hide(sc);
            Invoke(new EventHandler(SendScore));
        }
        private void SendScore(object sender, EventArgs e)
        {
            Respond myRespond = new Respond();
            myRespond.SendUpdatedData(rfId, hits.ToString(), lblBalance.Text);
        }
        void ValidateLion()
        {
            switch (numBg)
            {
                case 0:
                    if ((_shot.Left + 35) >= 570 && (_shot.Left + 35) <= (570 + 442) && (_shot.Top + 35) >= 432 && (_shot.Top + 35) <= (432 + 556))
                    {
                        ValidateScore();
                    }
                    else if (!entered)
                    {
                        ValidateWrongTarget();
                    }
                    break;
                case 1:
                    if ((_shot.Left + 35) >= 978 && (_shot.Left + 35) <= (978 + 582) && (_shot.Top + 35) >= 154 && (_shot.Top + 35) <= (154 + 482))
                    {
                        ValidateScore();
                    }
                    else if(!entered)
                    {
                        ValidateWrongTarget();
                    }
                    break;
                case 2:
                    if ((_shot.Left + 35) >= 1380 && (_shot.Left + 35) <= (1380 + 512) && (_shot.Top + 35) >= 310 && (_shot.Top + 35) <= (310 + 688))
                    {
                        ValidateScore();
                    }
                    else if (!entered)
                    {
                        ValidateWrongTarget();
                    }
                    break;
            }
        }
        void ValidateEagle()
        {
            switch (numBg)
            {
                case 0:
                    if ((_shot.Left + 35) >= 1304 && (_shot.Left + 35) <= (1304 + 600) && (_shot.Top + 35) >= 576 && (_shot.Top + 35) <= (576 + 440))
                    {
                        ValidateScore();
                    }
                    else if (!entered)
                    {
                        ValidateWrongTarget();
                    }
                    break;
                case 1:
                    if ((_shot.Left + 35) >= 264 && (_shot.Left + 35) <= (264 + 490) && (_shot.Top + 35) >= 464 && (_shot.Top + 35) <= (464 + 406))
                    {
                        ValidateScore();
                    }
                    else if (!entered)
                    {
                        ValidateWrongTarget();
                    }
                    break;
                case 2:
                    if ((_shot.Left + 35) >= 762 && (_shot.Left + 35) <= (762 + 754) && (_shot.Top + 35) >= 154 && (_shot.Top + 35) <= (154 + 458))
                    {
                        ValidateScore();
                    }
                    else if (!entered)
                    {
                        ValidateWrongTarget();
                    }
                    break;
            }
        }
        void ValidateShark()
        {
            switch (numBg)
            {
                case 0:
                    if ((_shot.Left + 35) >= 754 && (_shot.Left + 35) <= (754 + 760) && (_shot.Top + 35) >= 154 && (_shot.Top + 35) <= (154 + 436))
                    {
                        ValidateScore();
                    }
                    else if (!entered)
                    {
                        ValidateWrongTarget();
                    }
                    break;
                case 1:
                    if ((_shot.Left + 35) >= 1090 && (_shot.Left + 35) <= (1090 + 760) && (_shot.Top + 35) >= 610 && (_shot.Top + 35) <= (610 + 446))
                    {
                        ValidateScore();
                    }
                    else if (!entered)
                    {
                        ValidateWrongTarget();
                    }
                    break;
                case 2:
                    if ((_shot.Left + 35) >= 260 && (_shot.Left + 35) <= (260 + 686) && (_shot.Top + 35) >= 534 && (_shot.Top + 35) <= (534 + 476))
                    {
                        ValidateScore();
                    }
                    else if (!entered)
                    {
                        ValidateWrongTarget();
                    }
                    break;
            }
        }
    }
}
