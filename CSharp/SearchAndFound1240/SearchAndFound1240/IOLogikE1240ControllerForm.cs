using MagicStoneKingdomDeviceControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TestingPanelResources;

namespace SearchAndFound1240
{
    public partial class IOLogikE1240ControllerForm : Form, IDeviceControllerForm
    {
        private MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager;
        private IOLogikE1240AnalogInputServerController controller_1;
        private IOLogikE1210DigitalInputServerController controller_2;
        DigitalSignalUI digitalSignalUi;
        private bool synchronizingFormControls;
        int holdPnlShotLocX, holdPnlShotLocY, shotCenterLocX, shotCenterLocY, findTimerVal = 20, randomNum;
        string A0val, A1val;
        double A0doub, A1doub;
        double gtVal, beforeStartVal = 3, accuracyVal = 0, hits = 0, miss = 0, hHits = 0, hAccuracy = 0;
        bool trig = true, beforeStart = true, endingTimerCanTrig = true, entered = false, isBeaten = false, canStart = true;
        bool isMiss, trigCentaur = false, trigBounty = false, trigLanaya = false, trigShadowDemon = false, trigWindRunner = false, trigObsydian = false, trigPheonix = false, trigLoneDruid = false, trigSlardar = false, trigVissage = false, trigRhasta = false, trigFireSpirit = false, trigCrystalMaiden = false, trigVengeful = false, trigTreant = false, trigBatRider = false, trigVenomancer = false, trigChaosKnight = false, trigTroll = false, trigSpectre = false, trigTwinHead = false, trigDeathPropeth = false, trigJaggernut = false, trigAlchemist = false, trigKardel = false, trigNaix = false, trigMirana = false, trigTimberSaw = false, trigRazor = false, trigWitchDoctor = false, trigLuna = false, trigMedusa = false, trigTiny = false, trigDragonKnight = false, trigLycan = false, trigElderTitan = false, trigHuskar = false, trigInvoker = false, trigKeeperOfLight = false, trigLegionCommander = false, trigLich = false, trigMagina = false, trigMeepo = false, trigNeverMore = false, trigNyxAssasin = false, trigRubick = false, trigSandKing = false, trigSpiritBreaker = false, trigTerrorBlade = false, trigTusk = false, trigUrsa = false, trigWeaver = false;
        static double ms;
        int xMove, yMove;

        SoundPlayer backgoundSound = new SoundPlayer(@"./shootBackground2.wav");
        MediaPlayer.MediaPlayer soundFx;
        MediaPlayer.MediaPlayer endingTimer;

        Random randomTarget;
        Color colr = Color.FromArgb(0, 192, 0);
        private void btnStart_Click(object sender, EventArgs e)
        {
            lblIndicator.Text = beforeStartVal.ToString();
            BeforeStartTimer.Start();
            Play(@"./Start.wav");
            BeforeStartTimer.Interval = 1000;
            beforeStart = true;
            endingTimerCanTrig = true;
        }

        private void changeTimer_Tick(object sender, EventArgs e)
        {
            Invoke(new EventHandler(changeEvent));
        }
        private void OneSecTimer_Tick(object sender, EventArgs e)
        {
            decrementFindTimer();
            incrementStopWatch();
        }
        private void startTimer_Tick(object sender, EventArgs e)
        {
            trig = digitalSignalUi.DigitalSignal;
            if (trig == true)
            {
                if (canStart == true)
                {
                    Invoke(new EventHandler(btnStart_Click));
                    canStart = false;
                    startTimer.Stop();
                }
            }
        }

        private void BeforeStartTimer_Tick(object sender, EventArgs e)
        {
            if (beforeStart == true)
            {
                beforeStartVal--;
                lblIndicator.Text = beforeStartVal.ToString();
                if (beforeStartVal == 0)
                {
                    lblIndicator.Text = "Game Started";
                    gameStart();
                    beforeStart = false;
                    BeforeStartTimer.Stop();
                    BeforeStartTimer.Interval = 3000;
                }
            }
            else if (beforeStart == false)
            {

                lblIndicator.Text = "Timer";
                //picboxGear.Visible = false;
                //btnStart.Visible = true;
                canStart = true;
                startTimer.Start();

                try
                {
                    accuracyVal = (hits / (hits + miss)) * 100;
                    accuracyGauge.Value = Convert.ToInt32(accuracyVal);
                }
                catch
                {
                    accuracyGauge.Value = 0;
                }

                BeforeStartTimer.Stop();

                validateHighScore();
            }
        }

        public IOLogikE1240ControllerForm(MagicStoneKingdomDeviceControlManager magicStoneKingdomDeviceControlManager, IOLogikE1240AnalogInputServerController controller_1, IOLogikE1210DigitalInputServerController controller_2)
        {
            InitializeComponent();
            pnlShot.BackColor = Color.Transparent;
            this.magicStoneKingdomDeviceControlManager = magicStoneKingdomDeviceControlManager;
            this.controller_1 = controller_1;
            this.controller_2 = controller_2;
            for (int index = 0; index < controller_1.AnalogInputChannelCount; ++index)
            {
                controller_1.AnalogSignalInputInterfaces[index].OnInputChanged += new EventHandler(AnalogSignalInputInterface_OnInputChanged);
            }

            digitalSignalUi = Controls.Find("digitalSignalUIDI" + 0.ToString(), false)[0] as DigitalSignalUI;
            switch (controller_2.GetDigitalInputChannelModes((byte)0, (byte)1)[0])
            {
                case IOLogikDigitalInputChannelMode.DI:
                    digitalSignalUi.Mode = DigitalSignalUIMode.Input;
                    digitalSignalUi.BindToDigitalSignalInputInterface((DigitalSignalInputInterface)controller_2.DigitalSignalInputInterfaces[0]);
                    break;
                case IOLogikDigitalInputChannelMode.Counter:
                    digitalSignalUi.Mode = DigitalSignalUIMode.Input_Counter;
                    digitalSignalUi.BindToDigitalInputCounterSignalInputInterface((DigitalInputCounterSignalInputInterface)controller_2.DigitalInputCounterSignalInputInterfaces[0]);
                    break;
            }
        }
        public void SynchronizeFormControls()
        {
            synchronizingFormControls = true;
            A0val = controller_1.AnalogInputChannelValuesFromActiveTag[0].ToString("F0");
            A1val = controller_1.AnalogInputChannelValuesFromActiveTag[1].ToString("F0");
            labelAI0.Text = A0val;
            labelAI1.Text = A1val;
            A0doub = Convert.ToDouble(controller_1.AnalogInputChannelValuesFromActiveTag[0]);
            A1doub = Convert.ToDouble(controller_1.AnalogInputChannelValuesFromActiveTag[1]);

            //changePosition();

            synchronizingFormControls = false;
        }
        void trigAllFalse()
        {
            trigCentaur = false;
            trigBounty = false;
            trigLanaya = false;
            trigShadowDemon = false;
            trigWindRunner = false;
            trigObsydian = false;
            trigPheonix = false;
            trigLoneDruid = false;
            trigSlardar = false;
            trigVissage = false;
            trigRhasta = false;
            trigFireSpirit = false;
            trigCrystalMaiden = false;
            trigVengeful = false;
            trigTreant = false;
            trigBatRider = false;
            trigVenomancer = false;
            trigChaosKnight = false;
            trigTroll = false;
            trigSpectre = false;
            trigTwinHead = false;
            trigDeathPropeth = false;
            trigJaggernut = false;
            trigAlchemist = false;
            trigKardel = false;
            trigNaix = false;
            trigMirana = false;
            trigTimberSaw = false;
            trigRazor = false;
            trigWitchDoctor = false;
            trigLuna = false;
            trigMedusa = false;
            trigTiny = false;
            trigDragonKnight = false;
            trigLycan = false;
            trigElderTitan = false;
            trigHuskar = false;
            trigInvoker = false;
            trigKeeperOfLight = false;
            trigLegionCommander = false;
            trigLich = false;
            trigMagina = false;
            trigMeepo = false;
            trigNeverMore = false;
            trigNyxAssasin = false;
            trigRubick = false;
            trigSandKing = false;
            trigSpiritBreaker = false;
            trigTerrorBlade = false;
            trigTusk = false;
            trigUrsa = false;
            trigWeaver = false;
        }

        private void IOLogikE1240ControllerForm_Load(object sender, EventArgs e)
        {
            disableHorizontalPics();
            disableVerticalPics();
        }
        void disableHorizontalPics()
        {
            picXCenter.Image = arrowImagesList.Images[9];
            picLeftLvl_1.Image = arrowImagesList.Images[1];
            picLeftLvl_2.Image = arrowImagesList.Images[1];
            picLeftLvl_3.Image = arrowImagesList.Images[1];
            picLeftLvl_4.Image = arrowImagesList.Images[1];
            picRightLvl_1.Image = arrowImagesList.Images[2];
            picRightLvl_2.Image = arrowImagesList.Images[2];
            picRightLvl_3.Image = arrowImagesList.Images[2];
            picRightLvl_4.Image = arrowImagesList.Images[2];
        }
        void disableVerticalPics()
        {
            picYCenter.Image = arrowImagesList.Images[9];
            picUpLvl_1.Image = arrowImagesList.Images[3];
            picUpLvl_2.Image = arrowImagesList.Images[3];
            picUpLvl_3.Image = arrowImagesList.Images[3];
            picUpLvl_4.Image = arrowImagesList.Images[3];
            picDownLvl_1.Image = arrowImagesList.Images[0];
            picDownLvl_2.Image = arrowImagesList.Images[0];
            picDownLvl_3.Image = arrowImagesList.Images[0];
            picDownLvl_4.Image = arrowImagesList.Images[0];
        }
        void generateRandomTarget()
        {
            trigAllFalse();
            randomTarget = new Random();
            randomNum = randomTarget.Next(0, 52);
            if (randomNum == 0)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[0];
                trigAlchemist = true;
            }
            if (randomNum == 1)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[1];
                trigBatRider = true;
            }
            if (randomNum == 2)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[2];
                trigBounty = true;
            }
            if (randomNum == 3)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[3];
                trigCentaur = true;
            }
            if (randomNum == 4)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[4];
                trigChaosKnight = true;
            }
            if (randomNum == 5)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[5];
                trigCrystalMaiden = true;
            }
            if (randomNum == 6)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[6];
                trigDeathPropeth = true;
            }
            if (randomNum == 7)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[7];
                trigDragonKnight = true;
            }
            if (randomNum == 8)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[8];
                trigFireSpirit = true;
            }
            if (randomNum == 9)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[9];
                trigJaggernut = true;
            }
            if (randomNum == 10)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[10];
                trigKardel = true;
            }
            if (randomNum == 11)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[11];
                trigLanaya = true;
            }
            if (randomNum == 12)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[12];
                trigLoneDruid = true;
            }
            if (randomNum == 13)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[13];
                trigLuna = true;
            }
            if (randomNum == 14)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[14];
                trigLycan = true;
            }
            if (randomNum == 15)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[15];
                trigMedusa = true;
            }
            if (randomNum == 16)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[16];
                trigMirana = true;
            }
            if (randomNum == 17)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[17];
                trigNaix = true;
            }
            if (randomNum == 18)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[18];
                trigObsydian = true;
            }
            if (randomNum == 19)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[19];
                trigPheonix = true;
            }
            if (randomNum == 20)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[20];
                trigRazor = true;
            }
            if (randomNum == 21)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[21];
                trigRhasta = true;
            }
            if (randomNum == 22)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[22];
                trigShadowDemon = true;
            }
            if (randomNum == 23)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[23];
                trigSlardar = true;
            }
            if (randomNum == 24)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[24];
                trigSpectre = true;
            }
            if (randomNum == 25)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[25];
                trigTimberSaw = true;
            }
            if (randomNum == 26)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[26];
                trigTiny = true;
            }
            if (randomNum == 27)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[27];
                trigTreant = true;
            }
            if (randomNum == 28)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[28];
                trigTroll = true;
            }
            if (randomNum == 29)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[29];
                trigTwinHead = true;
            }
            if (randomNum == 30)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[30];
                trigVengeful = true;
            }
            if (randomNum == 31)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[31];
                trigVenomancer = true;
            }
            if (randomNum == 32)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[32];
                trigVissage = true;
            }
            if (randomNum == 33)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[33];
                trigWindRunner = true;
            }
            if (randomNum == 34)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[34];
                trigWitchDoctor = true;
            }
            if (randomNum == 35)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[35];
                trigElderTitan = true;
            }
            if (randomNum == 36)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[36];
                trigHuskar = true;
            }
            if (randomNum == 37)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[37];
                trigInvoker = true;
            }
            if (randomNum == 38)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[38];
                trigKeeperOfLight = true;
            }
            if (randomNum == 39)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[39];
                trigLegionCommander = true;
            }
            if (randomNum == 40)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[40];
                trigLich = true;
            }
            if (randomNum == 41)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[41];
                trigMagina = true;
            }
            if (randomNum == 42)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[42];
                trigMeepo = true;
            }
            if (randomNum == 43)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[43];
                trigNeverMore = true;
            }
            if (randomNum == 44)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[44];
                trigNyxAssasin = true;
            }
            if (randomNum == 45)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[45];
                trigRubick = true;
            }
            if (randomNum == 46)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[46];
                trigSandKing = true;
            }
            if (randomNum == 47)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[47];
                trigSpiritBreaker = true;
            }
            if (randomNum == 48)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[48];
                trigTerrorBlade = true;
            }
            if (randomNum == 49)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[49];
                trigTusk = true;
            }
            if (randomNum == 50)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[50];
                trigUrsa = true;
            }
            if (randomNum == 51)
            {
                trigAllFalse();
                picBoxToFind.Image = heroesImgList.Images[51];
                trigWeaver = true;
            }

        }
        void incrementStopWatch()
        {
            ms = ms + 1000;
        }
        void decrementFindTimer()
        {
            findTimerVal--;
            if (findTimerVal == 0)
            {
                findTimerVal = 20;
            }
            lblfindTimer.Text = findTimerVal.ToString();
        }
        void Play(string audioPath)
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
        void changeEvent(object sender, EventArgs e)
        {
            generateRandomTarget();
            if (isMiss == true)
            {
                miss++;
                lblMiss.Text = miss.ToString();
                Play(@"./Unmounted.wav");
            }
            isMiss = true;
        }
        void gameStart()
        {
            //btnStart.Visible = false;
            //picboxGear.Visible = true;
            gameReset();
            changeTimer.Start();
            OneSecTimer.Start();
            backgoundSound.PlayLooping();
            generateRandomTarget();
            //SixtySecTimer.Start();
            gameTimer.Start();
            isMiss = true;
            findTimerVal = 20;
            lblfindTimer.Text = findTimerVal.ToString();
        }
        void gameReset()
        {
            //SixtySecTimer.Reset();
            accuracyVal = 0;
            ms = 0;
            hits = 0;
            miss = 0;
            beforeStartVal = 3;
            lblHits.Text = hits.ToString();
            lblMiss.Text = miss.ToString();
            colr = Color.FromArgb(0, 192, 0);
            progGameTimer.Value = 100;
            progGameTimer.ProgressColor = colr;
            accuracyGauge.Value = Convert.ToInt32(accuracyVal);
        }
        void validateHighScore()
        {
            if (hits > hHits)
            {
                isBeaten = true;
                File.WriteAllText(@".\HighHits.txt", hits.ToString());
                File.WriteAllText(@".\HighAccuracy.txt", accuracyVal.ToString());
                //hHits = Convert.ToInt32(File.ReadAllText(@".\HighHits.txt"));
                lblHhits.Text = hits.ToString();
                //int a = Convert.ToInt32(File.ReadAllText(@".\HighAccuracy.txt")); //error
                accuracyHighGauge.Value = Convert.ToInt32(accuracyVal);
                Play(@"./Win.wav");
            }
            else if (hits == hHits && accuracyVal > hAccuracy)
            {
                isBeaten = true;
                File.WriteAllText(@".\HighHits.txt", hits.ToString());
                File.WriteAllText(@".\HighAccuracy.txt", accuracyVal.ToString());
                lblHhits.Text = hits.ToString();
                accuracyHighGauge.Value = Convert.ToInt32(accuracyVal);
                Play(@"./Win.wav");
            }
            else
            {
                isBeaten = false;
                Play(@"./LoseV2.wav");
            }
        }
        void changePosition()
        {
            gtVal = 60000 - Convert.ToDouble(ms);
            gtVal = (gtVal / 60000) * 100;

            if (ms >= 50000 && endingTimerCanTrig == true)
            {
                PlayEnding(@"./Timer12.8sec.wav");
                endingTimerCanTrig = false;
            }

            if (ms >= 60000)
            {
                progGameTimer.Value = 0;
                //SixtySecTimer.Stop();
                gameTimer.Stop();
                OneSecTimer.Stop();
                changeTimer.Stop();
                lblIndicator.Text = "Game Over";
                BeforeStartTimer.Start();
                picBoxToFind.Image = null;
                lblfindTimer.Text = "0";
                backgoundSound.Stop();
                endingTimer.Stop();
                Play(@"./gameover.wav");
            }
            else
            {
                progGameTimer.Value = Convert.ToInt32(gtVal);
                if (progGameTimer.Value <= 50 && progGameTimer.Value > 20)
                {
                    colr = Color.FromArgb(192, 192, 0);
                    progGameTimer.ProgressColor = colr;
                }
                else if (progGameTimer.Value <= 20)
                {
                    colr = Color.FromArgb(192, 0, 0);
                    progGameTimer.ProgressColor = colr;
                }
                else
                {
                    colr = Color.FromArgb(0, 192, 0);
                    progGameTimer.ProgressColor = colr;
                }
            }
            shotCenterLocX = pnlShot.Location.X + (pnlShot.Width / 2);
            shotCenterLocY = pnlShot.Location.Y + (pnlShot.Height / 2);
            xMove = Convert.ToInt32(A0val);
            yMove = Convert.ToInt32(A1val);
            if (xMove != 12)
            {
                switch (xMove)
                {
                    case 4:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X - 16);
                        break;
                    case 5:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X - 14);
                        break;
                    case 6:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X - 12);
                        break;
                    case 7:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X - 10);
                        break;
                    case 8:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X - 8);
                        break;
                    case 9:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X - 6);
                        break;
                    case 10:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X - 4);
                        break;
                    case 11:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X - 2);
                        break;

                    case 13:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X + 2);
                        break;
                    case 14:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X + 4);
                        break;
                    case 15:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X + 6);
                        break;
                    case 16:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X + 8);
                        break;
                    case 17:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X + 10);
                        break;
                    case 18:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X + 12);
                        break;
                    case 19:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X + 14);
                        break;
                    case 20:
                        holdPnlShotLocX = Convert.ToInt32(pnlShot.Location.X + 16);
                        break;
                }
            }
            if (yMove != 12)
            {
                switch (yMove)
                {
                    case 4:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y - 16);
                        break;
                    case 5:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y - 14);
                        break;
                    case 6:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y - 12);
                        break;
                    case 7:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y - 10);
                        break;
                    case 8:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y - 8);
                        break;
                    case 9:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y - 6);
                        break;
                    case 10:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y - 4);
                        break;
                    case 11:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y - 2);
                        break;

                    case 13:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y + 2);
                        break;
                    case 14:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y + 4);
                        break;
                    case 15:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y + 6);
                        break;
                    case 16:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y + 8);
                        break;
                    case 17:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y + 10);
                        break;
                    case 18:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y + 12);
                        break;
                    case 19:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y + 14);
                        break;
                    case 20:
                        holdPnlShotLocY = Convert.ToInt32(pnlShot.Location.Y + 16);
                        break;
                }
            }
            
            try
            {
                if (holdPnlShotLocY > 916)
                {
                    holdPnlShotLocY = -22;
                }
                if (holdPnlShotLocY < -22)
                {
                    holdPnlShotLocY = 916;
                }

                if (holdPnlShotLocX > 1653)
                {
                    holdPnlShotLocX = -28;
                }
                if (holdPnlShotLocX < -28)
                {
                    holdPnlShotLocX = 1653;
                }

                var point = new Point(holdPnlShotLocX, holdPnlShotLocY);
                pnlShot.Location = point;
            }
            catch (Exception ex)
            {
            }

            trig = digitalSignalUi.DigitalSignal;
            if (trig == false)
            {
                entered = false;
            }
            if (trig == true)
            {
                switch (randomNum)
                {
                    case 0:
                        validateAlchemist();
                        break;
                    case 1:
                        validateBatRider();
                        break;
                    case 2:
                        validateBountyHunter();
                        break;
                    case 3:
                        validateCentaur();
                        break;
                    case 4:
                        validateChaosKnight();
                        break;
                    case 5:
                        validateCrystalMaiden();
                        break;
                    case 6:
                        validateDeathPropeth();
                        break;
                    case 7:
                        validateDragonKnight();
                        break;
                    case 8:
                        validateFireSpirit();
                        break;
                    case 9:
                        validateJuggernut();
                        break;
                    case 10:
                        validateKardel();
                        break;
                    case 11:
                        validateLanaya();
                        break;
                    case 12:
                        validateLoneDruid();
                        break;
                    case 13:
                        validateLuna();
                        break;
                    case 14:
                        validateLycan();
                        break;
                    case 15:
                        validateMedusa();
                        break;
                    case 16:
                        validateMirana();
                        break;
                    case 17:
                        validateNaix();
                        break;
                    case 18:
                        validateObsydian();
                        break;
                    case 19:
                        validatePheonix();
                        break;
                    case 20:
                        validateRazor();
                        break;
                    case 21:
                        validateRhasta();
                        break;
                    case 22:
                        validateShadowDemon();
                        break;
                    case 23:
                        validateSlardar();
                        break;
                    case 24:
                        validateSpectre();
                        break;
                    case 25:
                        validateTimberSaw();
                        break;
                    case 26:
                        validateTiny();
                        break;
                    case 27:
                        validateTreant();
                        break;
                    case 28:
                        validateTroll();
                        break;
                    case 29:
                        validateTwinHead();
                        break;
                    case 30:
                        validateVengeful();
                        break;
                    case 31:
                        validateVenomancer();
                        break;
                    case 32:
                        validateVissage();
                        break;
                    case 33:
                        validateWindRunner();
                        break;
                    case 34:
                        validateWitchDoctor();
                        break;
                    case 35:
                        validateElderTitan();
                        break;
                    case 36:
                        validateHuskar();
                        break;
                    case 37:
                        validateInvoker();
                        break;
                    case 38:
                        validateKeeperOfLight();
                        break;
                    case 39:
                        validateLegionCommander();
                        break;
                    case 40:
                        validateLich();
                        break;
                    case 41:
                        validateMagina();
                        break;
                    case 42:
                        validateMeepo();
                        break;
                    case 43:
                        validateNeverMore();
                        break;
                    case 44:
                        validateNyxAssasin();
                        break;
                    case 45:
                        validateRubick();
                        break;
                    case 46:
                        validateSandKing();
                        break;
                    case 47:
                        validateSpiritBreaker();
                        break;
                    case 48:
                        validateTerrorBlade();
                        break;
                    case 49:
                        validateTusk();
                        break;
                    case 50:
                        validateUrsa();
                        break;
                    case 51:
                        validateWeaver();
                        break;
                }
            }
            else if (trig == false)
            {
                pnlShot.BackColor = Color.Transparent;
            }
        }
        void trigScore()
        {
            //SixtySecTimer.Stop();
            var holdMs = ms - 20000;
            if (holdMs < 0)
            {
                ms = 0;
            }
            else
            {
                ms = holdMs;
            }

            if (endingTimerCanTrig == false)
            {
                endingTimerCanTrig = true;
                endingTimer.Stop();
            }
            //SixtySecTimer.Start();
            pnlShot.BackColor = Color.Green;
            Play(@"./Hit2.wav");
            hits++;
            lblHits.Text = hits.ToString();
            isMiss = false;
            Invoke(new EventHandler(changeEvent));
            changeTimer.Stop();
            changeTimer.Start();
            findTimerVal = 20;
            lblfindTimer.Text = findTimerVal.ToString();
        }
        void trigMiss()
        {
            entered = true;
            pnlShot.BackColor = Color.Red;
            Play(@"./Warning.wav");
            var holdMs = ms + 5000;
            ms = holdMs;
        }
        void validateAlchemist()
        {
            if ((shotCenterLocX >= pnlAlchemist.Location.X && shotCenterLocX <= (pnlAlchemist.Location.X + pnlAlchemist.Width)) && (shotCenterLocY >= pnlAlchemist.Location.Y && shotCenterLocY <= (pnlAlchemist.Location.Y + pnlAlchemist.Height)) && trigAlchemist == true && entered == false)
            {
                trigAlchemist = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateBatRider()
        {
            if ((shotCenterLocX >= pnlBatRider.Location.X && shotCenterLocX <= (pnlBatRider.Location.X + pnlBatRider.Width)) && (shotCenterLocY >= pnlBatRider.Location.Y && shotCenterLocY <= (pnlBatRider.Location.Y + pnlBatRider.Height)) && trigBatRider == true && entered == false)
            {
                trigBatRider = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateBountyHunter()
        {
            if ((shotCenterLocX >= pnlBounty.Location.X && shotCenterLocX <= (pnlBounty.Location.X + pnlBounty.Width)) && (shotCenterLocY >= pnlBounty.Location.Y && shotCenterLocY <= (pnlBounty.Location.Y + pnlBounty.Height)) && trigBounty == true && entered == false)
            {
                trigBounty = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateCentaur()
        {
            if ((shotCenterLocX >= pnlCentaur.Location.X && shotCenterLocX <= (pnlCentaur.Location.X + pnlCentaur.Width)) && (shotCenterLocY >= pnlCentaur.Location.Y && shotCenterLocY <= (pnlCentaur.Location.Y + pnlCentaur.Height)) && trigCentaur == true && entered == false)
            {
                trigCentaur = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateChaosKnight()
        {
            if ((shotCenterLocX >= pnlChaosKnight.Location.X && shotCenterLocX <= (pnlChaosKnight.Location.X + pnlChaosKnight.Width)) && (shotCenterLocY >= pnlChaosKnight.Location.Y && shotCenterLocY <= (pnlChaosKnight.Location.Y + pnlChaosKnight.Height)) && trigChaosKnight == true && entered == false)
            {
                trigChaosKnight = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateCrystalMaiden()
        {
            if ((shotCenterLocX >= pnlCrystalMaiden.Location.X && shotCenterLocX <= (pnlCrystalMaiden.Location.X + pnlCrystalMaiden.Width)) && (shotCenterLocY >= pnlCrystalMaiden.Location.Y && shotCenterLocY <= (pnlCrystalMaiden.Location.Y + pnlCrystalMaiden.Height)) && trigCrystalMaiden == true && entered == false)
            {
                trigCrystalMaiden = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateDeathPropeth()
        {
            if ((shotCenterLocX >= pnlDeathPropeth.Location.X && shotCenterLocX <= (pnlDeathPropeth.Location.X + pnlDeathPropeth.Width)) && (shotCenterLocY >= pnlDeathPropeth.Location.Y && shotCenterLocY <= (pnlDeathPropeth.Location.Y + pnlDeathPropeth.Height)) && trigDeathPropeth == true && entered == false)
            {
                trigDeathPropeth = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateDragonKnight()
        {
            if ((shotCenterLocX >= pnlDragonKnight.Location.X && shotCenterLocX <= (pnlDragonKnight.Location.X + pnlDragonKnight.Width)) && (shotCenterLocY >= pnlDragonKnight.Location.Y && shotCenterLocY <= (pnlDragonKnight.Location.Y + pnlDragonKnight.Height)) && trigDragonKnight == true && entered == false)
            {
                trigDragonKnight = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateFireSpirit()
        {
            if ((shotCenterLocX >= pnlFireSpirit.Location.X && shotCenterLocX <= (pnlFireSpirit.Location.X + pnlFireSpirit.Width)) && (shotCenterLocY >= pnlFireSpirit.Location.Y && shotCenterLocY <= (pnlFireSpirit.Location.Y + pnlFireSpirit.Height)) && trigFireSpirit == true && entered == false)
            {
                trigFireSpirit = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateJuggernut()
        {
            if ((shotCenterLocX >= pnlJuggernut.Location.X && shotCenterLocX <= (pnlJuggernut.Location.X + pnlJuggernut.Width)) && (shotCenterLocY >= pnlJuggernut.Location.Y && shotCenterLocY <= (pnlJuggernut.Location.Y + pnlJuggernut.Height)) && trigJaggernut == true && entered == false)
            {
                trigJaggernut = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateKardel()
        {
            if ((shotCenterLocX >= pnlKardel.Location.X && shotCenterLocX <= (pnlKardel.Location.X + pnlKardel.Width)) && (shotCenterLocY >= pnlKardel.Location.Y && shotCenterLocY <= (pnlKardel.Location.Y + pnlKardel.Height)) && trigKardel == true && entered == false)
            {
                trigKardel = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateLanaya()
        {
            if ((shotCenterLocX >= pnlLanaya.Location.X && shotCenterLocX <= (pnlLanaya.Location.X + pnlLanaya.Width)) && (shotCenterLocY >= pnlLanaya.Location.Y && shotCenterLocY <= (pnlLanaya.Location.Y + pnlLanaya.Height)) && trigLanaya == true && entered == false)
            {
                trigLanaya = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateLoneDruid()
        {
            if ((shotCenterLocX >= pnlLoneDruid.Location.X && shotCenterLocX <= (pnlLoneDruid.Location.X + pnlLoneDruid.Width)) && (shotCenterLocY >= pnlLoneDruid.Location.Y && shotCenterLocY <= (pnlLoneDruid.Location.Y + pnlLoneDruid.Height)) && trigLoneDruid == true && entered == false)
            {
                trigLoneDruid = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateLuna()
        {
            if ((shotCenterLocX >= pnlLuna.Location.X && shotCenterLocX <= (pnlLuna.Location.X + pnlLuna.Width)) && (shotCenterLocY >= pnlLuna.Location.Y && shotCenterLocY <= (pnlLuna.Location.Y + pnlLuna.Height)) && trigLuna == true && entered == false)
            {
                trigLuna = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateLycan()
        {
            if ((shotCenterLocX >= pnlLycan.Location.X && shotCenterLocX <= (pnlLycan.Location.X + pnlLycan.Width)) && (shotCenterLocY >= pnlLycan.Location.Y && shotCenterLocY <= (pnlLycan.Location.Y + pnlLycan.Height)) && trigLycan == true && entered == false)
            {
                trigLycan = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateMedusa()
        {
            if ((shotCenterLocX >= pnlMedusa.Location.X && shotCenterLocX <= (pnlMedusa.Location.X + pnlMedusa.Width)) && (shotCenterLocY >= pnlMedusa.Location.Y && shotCenterLocY <= (pnlMedusa.Location.Y + pnlMedusa.Height)) && trigMedusa == true && entered == false)
            {
                trigMedusa = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateMirana()
        {
            if ((shotCenterLocX >= pnlMirana.Location.X && shotCenterLocX <= (pnlMirana.Location.X + pnlMirana.Width)) && (shotCenterLocY >= pnlMirana.Location.Y && shotCenterLocY <= (pnlMirana.Location.Y + pnlMirana.Height)) && trigMirana == true && entered == false)
            {
                trigMirana = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateNaix()
        {
            if ((shotCenterLocX >= pnlNaix.Location.X && shotCenterLocX <= (pnlNaix.Location.X + pnlNaix.Width)) && (shotCenterLocY >= pnlNaix.Location.Y && shotCenterLocY <= (pnlNaix.Location.Y + pnlNaix.Height)) && trigNaix == true && entered == false)
            {
                trigNaix = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateObsydian()
        {
            if ((shotCenterLocX >= pnlObsydian.Location.X && shotCenterLocX <= (pnlObsydian.Location.X + pnlObsydian.Width)) && (shotCenterLocY >= pnlObsydian.Location.Y && shotCenterLocY <= (pnlObsydian.Location.Y + pnlObsydian.Height)) && trigObsydian == true && entered == false)
            {
                trigObsydian = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validatePheonix()
        {
            if ((shotCenterLocX >= pnlPheonix.Location.X && shotCenterLocX <= (pnlPheonix.Location.X + pnlPheonix.Width)) && (shotCenterLocY >= pnlPheonix.Location.Y && shotCenterLocY <= (pnlPheonix.Location.Y + pnlPheonix.Height)) && trigPheonix == true && entered == false)
            {
                trigPheonix = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateRazor()
        {
            if ((shotCenterLocX >= pnlRazor.Location.X && shotCenterLocX <= (pnlRazor.Location.X + pnlRazor.Width)) && (shotCenterLocY >= pnlRazor.Location.Y && shotCenterLocY <= (pnlRazor.Location.Y + pnlRazor.Height)) && trigRazor == true && entered == false)
            {
                trigRazor = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateRhasta()
        {
            if ((shotCenterLocX >= pnlRhasta.Location.X && shotCenterLocX <= (pnlRhasta.Location.X + pnlRhasta.Width)) && (shotCenterLocY >= pnlRhasta.Location.Y && shotCenterLocY <= (pnlRhasta.Location.Y + pnlRhasta.Height)) && trigRhasta == true && entered == false)
            {
                trigRhasta = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateShadowDemon()
        {
            if ((shotCenterLocX >= pnlShadowDemon.Location.X && shotCenterLocX <= (pnlShadowDemon.Location.X + pnlShadowDemon.Width)) && (shotCenterLocY >= pnlShadowDemon.Location.Y && shotCenterLocY <= (pnlShadowDemon.Location.Y + pnlShadowDemon.Height)) && trigShadowDemon == true && entered == false)
            {
                trigShadowDemon = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateSlardar()
        {
            if ((shotCenterLocX >= pnlSlardar.Location.X && shotCenterLocX <= (pnlSlardar.Location.X + pnlSlardar.Width)) && (shotCenterLocY >= pnlSlardar.Location.Y && shotCenterLocY <= (pnlSlardar.Location.Y + pnlSlardar.Height)) && trigSlardar == true && entered == false)
            {
                trigSlardar = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateSpectre()
        {
            if ((shotCenterLocX >= pnlSpectre.Location.X && shotCenterLocX <= (pnlSpectre.Location.X + pnlSpectre.Width)) && (shotCenterLocY >= pnlSpectre.Location.Y && shotCenterLocY <= (pnlSpectre.Location.Y + pnlSpectre.Height)) && trigSpectre == true && entered == false)
            {
                trigSpectre = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateTimberSaw()
        {
            if ((shotCenterLocX >= pnlTimberSaw.Location.X && shotCenterLocX <= (pnlTimberSaw.Location.X + pnlTimberSaw.Width)) && (shotCenterLocY >= pnlTimberSaw.Location.Y && shotCenterLocY <= (pnlTimberSaw.Location.Y + pnlTimberSaw.Height)) && trigTimberSaw == true && entered == false)
            {
                trigTimberSaw = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateTiny()
        {
            if ((shotCenterLocX >= pnlTiny.Location.X && shotCenterLocX <= (pnlTiny.Location.X + pnlTiny.Width)) && (shotCenterLocY >= pnlTiny.Location.Y && shotCenterLocY <= (pnlTiny.Location.Y + pnlTiny.Height)) && trigTiny == true && entered == false)
            {
                trigTiny = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateTreant()
        {
            if ((shotCenterLocX >= pnlTreant.Location.X && shotCenterLocX <= (pnlTreant.Location.X + pnlTreant.Width)) && (shotCenterLocY >= pnlTreant.Location.Y && shotCenterLocY <= (pnlTreant.Location.Y + pnlTreant.Height)) && trigTreant == true && entered == false)
            {
                trigTreant = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateTroll()
        {
            if ((shotCenterLocX >= pnlTroll.Location.X && shotCenterLocX <= (pnlTroll.Location.X + pnlTroll.Width)) && (shotCenterLocY >= pnlTroll.Location.Y && shotCenterLocY <= (pnlTroll.Location.Y + pnlTroll.Height)) && trigTroll == true && entered == false)
            {
                trigTroll = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateTwinHead()
        {
            if ((shotCenterLocX >= pnlTwinHead.Location.X && shotCenterLocX <= (pnlTwinHead.Location.X + pnlTwinHead.Width)) && (shotCenterLocY >= pnlTwinHead.Location.Y && shotCenterLocY <= (pnlTwinHead.Location.Y + pnlTwinHead.Height)) && trigTwinHead == true && entered == false)
            {
                trigTwinHead = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateVengeful()
        {
            if ((shotCenterLocX >= pnlVengeful.Location.X && shotCenterLocX <= (pnlVengeful.Location.X + pnlVengeful.Width)) && (shotCenterLocY >= pnlVengeful.Location.Y && shotCenterLocY <= (pnlVengeful.Location.Y + pnlVengeful.Height)) && trigVengeful == true && entered == false)
            {
                trigVengeful = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateVenomancer()
        {
            if ((shotCenterLocX >= pnlVenomancer.Location.X && shotCenterLocX <= (pnlVenomancer.Location.X + pnlVenomancer.Width)) && (shotCenterLocY >= pnlVenomancer.Location.Y && shotCenterLocY <= (pnlVenomancer.Location.Y + pnlVenomancer.Height)) && trigVenomancer == true && entered == false)
            {
                trigVenomancer = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateVissage()
        {
            if ((shotCenterLocX >= pnlVissage.Location.X && shotCenterLocX <= (pnlVissage.Location.X + pnlVissage.Width)) && (shotCenterLocY >= pnlVissage.Location.Y && shotCenterLocY <= (pnlVissage.Location.Y + pnlVissage.Height)) && trigVissage == true && entered == false)
            {
                trigVissage = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateWindRunner()
        {
            if ((shotCenterLocX >= pnlWindRunner.Location.X && shotCenterLocX <= (pnlWindRunner.Location.X + pnlWindRunner.Width)) && (shotCenterLocY >= pnlWindRunner.Location.Y && shotCenterLocY <= (pnlWindRunner.Location.Y + pnlWindRunner.Height)) && trigWindRunner == true && entered == false)
            {
                trigWindRunner = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateWitchDoctor()
        {
            if ((shotCenterLocX >= pnlWitchDoctor.Location.X && shotCenterLocX <= (pnlWitchDoctor.Location.X + pnlWitchDoctor.Width)) && (shotCenterLocY >= pnlWitchDoctor.Location.Y && shotCenterLocY <= (pnlWitchDoctor.Location.Y + pnlWitchDoctor.Height)) && trigWitchDoctor == true && entered == false)
            {
                trigWitchDoctor = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateElderTitan()
        {
            if ((shotCenterLocX >= pnlElderTitan.Location.X && shotCenterLocX <= (pnlElderTitan.Location.X + pnlElderTitan.Width)) && (shotCenterLocY >= pnlElderTitan.Location.Y && shotCenterLocY <= (pnlElderTitan.Location.Y + pnlElderTitan.Height)) && trigElderTitan == true && entered == false)
            {
                trigElderTitan = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateHuskar()
        {
            if ((shotCenterLocX >= pnlHuskar.Location.X && shotCenterLocX <= (pnlHuskar.Location.X + pnlHuskar.Width)) && (shotCenterLocY >= pnlHuskar.Location.Y && shotCenterLocY <= (pnlHuskar.Location.Y + pnlHuskar.Height)) && trigHuskar == true && entered == false)
            {
                trigHuskar = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateInvoker()
        {
            if ((shotCenterLocX >= pnlInvoker.Location.X && shotCenterLocX <= (pnlInvoker.Location.X + pnlInvoker.Width)) && (shotCenterLocY >= pnlInvoker.Location.Y && shotCenterLocY <= (pnlInvoker.Location.Y + pnlInvoker.Height)) && trigInvoker == true && entered == false)
            {
                trigInvoker = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateKeeperOfLight()
        {
            if ((shotCenterLocX >= pnlKeeperOfLight.Location.X && shotCenterLocX <= (pnlKeeperOfLight.Location.X + pnlKeeperOfLight.Width)) && (shotCenterLocY >= pnlKeeperOfLight.Location.Y && shotCenterLocY <= (pnlKeeperOfLight.Location.Y + pnlKeeperOfLight.Height)) && trigKeeperOfLight == true && entered == false)
            {
                trigKeeperOfLight = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateLegionCommander()
        {
            if ((shotCenterLocX >= pnlLegionCommander.Location.X && shotCenterLocX <= (pnlLegionCommander.Location.X + pnlLegionCommander.Width)) && (shotCenterLocY >= pnlLegionCommander.Location.Y && shotCenterLocY <= (pnlLegionCommander.Location.Y + pnlLegionCommander.Height)) && trigLegionCommander == true && entered == false)
            {
                trigLegionCommander = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateLich()
        {
            if ((shotCenterLocX >= pnlLich.Location.X && shotCenterLocX <= (pnlLich.Location.X + pnlLich.Width)) && (shotCenterLocY >= pnlLich.Location.Y && shotCenterLocY <= (pnlLich.Location.Y + pnlLich.Height)) && trigLich == true && entered == false)
            {
                trigLich = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateMagina()
        {
            if ((shotCenterLocX >= pnlMagina.Location.X && shotCenterLocX <= (pnlMagina.Location.X + pnlMagina.Width)) && (shotCenterLocY >= pnlMagina.Location.Y && shotCenterLocY <= (pnlMagina.Location.Y + pnlMagina.Height)) && trigMagina == true && entered == false)
            {
                trigMagina = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateMeepo()
        {
            if ((shotCenterLocX >= pnlMeepo.Location.X && shotCenterLocX <= (pnlMeepo.Location.X + pnlMeepo.Width)) && (shotCenterLocY >= pnlMeepo.Location.Y && shotCenterLocY <= (pnlMeepo.Location.Y + pnlMeepo.Height)) && trigMeepo == true && entered == false)
            {
                trigMeepo = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateNeverMore()
        {
            if ((shotCenterLocX >= pnlNeverMore.Location.X && shotCenterLocX <= (pnlNeverMore.Location.X + pnlNeverMore.Width)) && (shotCenterLocY >= pnlNeverMore.Location.Y && shotCenterLocY <= (pnlNeverMore.Location.Y + pnlNeverMore.Height)) && trigNeverMore == true && entered == false)
            {
                trigNeverMore = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateNyxAssasin()
        {
            if ((shotCenterLocX >= pnlNyxAssasin.Location.X && shotCenterLocX <= (pnlNyxAssasin.Location.X + pnlNyxAssasin.Width)) && (shotCenterLocY >= pnlNyxAssasin.Location.Y && shotCenterLocY <= (pnlNyxAssasin.Location.Y + pnlNyxAssasin.Height)) && trigNyxAssasin == true && entered == false)
            {
                trigNyxAssasin = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateRubick()
        {
            if ((shotCenterLocX >= pnlRubick.Location.X && shotCenterLocX <= (pnlRubick.Location.X + pnlRubick.Width)) && (shotCenterLocY >= pnlRubick.Location.Y && shotCenterLocY <= (pnlRubick.Location.Y + pnlRubick.Height)) && trigRubick == true && entered == false)
            {
                trigRubick = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateSandKing()
        {
            if ((shotCenterLocX >= pnlSandKing.Location.X && shotCenterLocX <= (pnlSandKing.Location.X + pnlSandKing.Width)) && (shotCenterLocY >= pnlSandKing.Location.Y && shotCenterLocY <= (pnlSandKing.Location.Y + pnlSandKing.Height)) && trigSandKing == true && entered == false)
            {
                trigSandKing = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateSpiritBreaker()
        {
            if ((shotCenterLocX >= pnlSpiritBreaker.Location.X && shotCenterLocX <= (pnlSpiritBreaker.Location.X + pnlSpiritBreaker.Width)) && (shotCenterLocY >= pnlSpiritBreaker.Location.Y && shotCenterLocY <= (pnlSpiritBreaker.Location.Y + pnlSpiritBreaker.Height)) && trigSpiritBreaker == true && entered == false)
            {
                trigSpiritBreaker = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateTerrorBlade()
        {
            if ((shotCenterLocX >= pnlTerrorBlade.Location.X && shotCenterLocX <= (pnlTerrorBlade.Location.X + pnlTerrorBlade.Width)) && (shotCenterLocY >= pnlTerrorBlade.Location.Y && shotCenterLocY <= (pnlTerrorBlade.Location.Y + pnlTerrorBlade.Height)) && trigTerrorBlade == true && entered == false)
            {
                trigTerrorBlade = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateTusk()
        {
            if ((shotCenterLocX >= pnlTusk.Location.X && shotCenterLocX <= (pnlTusk.Location.X + pnlTusk.Width)) && (shotCenterLocY >= pnlTusk.Location.Y && shotCenterLocY <= (pnlTusk.Location.Y + pnlTusk.Height)) && trigTusk == true && entered == false)
            {
                trigTusk = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateUrsa()
        {
            if ((shotCenterLocX >= pnlUrsa.Location.X && shotCenterLocX <= (pnlUrsa.Location.X + pnlUrsa.Width)) && (shotCenterLocY >= pnlUrsa.Location.Y && shotCenterLocY <= (pnlUrsa.Location.Y + pnlUrsa.Height)) && trigUrsa == true && entered == false)
            {
                trigUrsa = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        void validateWeaver()
        {
            if ((shotCenterLocX >= pnlWeaver.Location.X && shotCenterLocX <= (pnlWeaver.Location.X + pnlWeaver.Width)) && (shotCenterLocY >= pnlWeaver.Location.Y && shotCenterLocY <= (pnlWeaver.Location.Y + pnlWeaver.Height)) && trigWeaver == true && entered == false)
            {
                trigWeaver = false;
                trigScore();
                entered = true;
            }
            else if (entered == false)
            {
                trigMiss();
            }
            else
            {
                pnlShot.BackColor = Color.Red;
            }
        }
        private void AnalogSignalInputInterface_OnInputChanged(object sender, EventArgs e)
        {
            try
            {
                Invoke((Delegate)new IOLogikE1240ControllerForm.SynchronizeFormControlsDelegate(this.SynchronizeFormControls));
            }
            catch (ObjectDisposedException ex)
            {
            }
            catch (InvalidOperationException ex)
            {
            }
        }

        private void gameTimer_Tick_1(object sender, EventArgs e)
        {
            changePosition();
            picHorizontalArrowSetter();
            picVerticalArrowSetter();
        }
        void picHorizontalArrowSetter()
        {
            if (xMove == 12)
            {
                disableHorizontalPics();
                picXCenter.Image = arrowImagesList.Images[8];
            }
            else if (xMove == 13 || xMove == 14)
            {
                disableHorizontalPics();
                picRightLvl_1.Image = arrowImagesList.Images[6];
            }
            else if (xMove == 15 || xMove == 16)
            {
                disableHorizontalPics();
                picRightLvl_1.Image = arrowImagesList.Images[6];
                picRightLvl_2.Image = arrowImagesList.Images[6];
            }
            else if (xMove == 17 || xMove == 18)
            {
                disableHorizontalPics();
                picRightLvl_1.Image = arrowImagesList.Images[6];
                picRightLvl_2.Image = arrowImagesList.Images[6];
                picRightLvl_3.Image = arrowImagesList.Images[6];
            }
            else if (xMove == 19)
            {
                disableHorizontalPics();
                picRightLvl_1.Image = arrowImagesList.Images[6];
                picRightLvl_2.Image = arrowImagesList.Images[6];
                picRightLvl_3.Image = arrowImagesList.Images[6];
                picRightLvl_4.Image = arrowImagesList.Images[6];
            }
            else if (xMove == 20)
            {
                disableHorizontalPics();
                picRightLvl_1.Image = arrowImagesList.Images[12];
                picRightLvl_2.Image = arrowImagesList.Images[12];
                picRightLvl_3.Image = arrowImagesList.Images[12];
                picRightLvl_4.Image = arrowImagesList.Images[12];
            }
            else if (xMove == 11 || xMove == 10)
            {
                disableHorizontalPics();
                picLeftLvl_1.Image = arrowImagesList.Images[5];
            }
            else if (xMove == 9 || xMove == 8)
            {
                disableHorizontalPics();
                picLeftLvl_1.Image = arrowImagesList.Images[5];
                picLeftLvl_2.Image = arrowImagesList.Images[5];
            }
            else if (xMove == 7 || xMove == 6)
            {
                disableHorizontalPics();
                picLeftLvl_1.Image = arrowImagesList.Images[5];
                picLeftLvl_2.Image = arrowImagesList.Images[5];
                picLeftLvl_3.Image = arrowImagesList.Images[5];
            }
            else if (xMove == 5)
            {
                disableHorizontalPics();
                picLeftLvl_1.Image = arrowImagesList.Images[5];
                picLeftLvl_2.Image = arrowImagesList.Images[5];
                picLeftLvl_3.Image = arrowImagesList.Images[5];
                picLeftLvl_4.Image = arrowImagesList.Images[5];
            }
            else if (xMove == 4)
            {
                disableHorizontalPics();
                picLeftLvl_1.Image = arrowImagesList.Images[11];
                picLeftLvl_2.Image = arrowImagesList.Images[11];
                picLeftLvl_3.Image = arrowImagesList.Images[11];
                picLeftLvl_4.Image = arrowImagesList.Images[11];
            }
        }
        void picVerticalArrowSetter()
        {
            if (yMove == 12)
            {
                disableVerticalPics();
                picYCenter.Image = arrowImagesList.Images[8];
            }
            else if (yMove == 13 || yMove == 14)
            {
                disableVerticalPics();
                picDownLvl_1.Image = arrowImagesList.Images[4];
            }
            else if (yMove == 15 || yMove == 16)
            {
                disableVerticalPics();
                picDownLvl_1.Image = arrowImagesList.Images[4];
                picDownLvl_2.Image = arrowImagesList.Images[4];
            }
            else if (yMove == 17 || yMove == 18)
            {
                disableVerticalPics();
                picDownLvl_1.Image = arrowImagesList.Images[4];
                picDownLvl_2.Image = arrowImagesList.Images[4];
                picDownLvl_3.Image = arrowImagesList.Images[4];
            }
            else if (yMove == 19)
            {
                disableVerticalPics();
                picDownLvl_1.Image = arrowImagesList.Images[4];
                picDownLvl_2.Image = arrowImagesList.Images[4];
                picDownLvl_3.Image = arrowImagesList.Images[4];
                picDownLvl_4.Image = arrowImagesList.Images[4];
            }
            else if (yMove == 20)
            {
                disableVerticalPics();
                picDownLvl_1.Image = arrowImagesList.Images[10];
                picDownLvl_2.Image = arrowImagesList.Images[10];
                picDownLvl_3.Image = arrowImagesList.Images[10];
                picDownLvl_4.Image = arrowImagesList.Images[10];
            }
            else if (yMove == 11 || yMove == 10)
            {
                disableVerticalPics();
                picUpLvl_1.Image = arrowImagesList.Images[7];
            }
            else if (yMove == 9 || yMove == 8)
            {
                disableVerticalPics();
                picUpLvl_1.Image = arrowImagesList.Images[7];
                picUpLvl_2.Image = arrowImagesList.Images[7];
            }
            else if (yMove == 7 || yMove == 6)
            {
                disableVerticalPics();
                picUpLvl_1.Image = arrowImagesList.Images[7];
                picUpLvl_2.Image = arrowImagesList.Images[7];
                picUpLvl_3.Image = arrowImagesList.Images[7];
            }
            else if (yMove == 5)
            {
                disableVerticalPics();
                picUpLvl_1.Image = arrowImagesList.Images[7];
                picUpLvl_2.Image = arrowImagesList.Images[7];
                picUpLvl_3.Image = arrowImagesList.Images[7];
                picUpLvl_4.Image = arrowImagesList.Images[7];
            }
            else if (yMove == 4)
            {
                disableVerticalPics();
                picUpLvl_1.Image = arrowImagesList.Images[13];
                picUpLvl_2.Image = arrowImagesList.Images[13];
                picUpLvl_3.Image = arrowImagesList.Images[13];
                picUpLvl_4.Image = arrowImagesList.Images[13];
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IOLogikE1240ControllerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to disconnect this device controller?", "Disconnect Controller", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
                return;
            e.Cancel = true;
        }
        private delegate void SynchronizeFormControlsDelegate();
        void IDeviceControllerForm.Close()
        {
            Close();
        }
    }
}
