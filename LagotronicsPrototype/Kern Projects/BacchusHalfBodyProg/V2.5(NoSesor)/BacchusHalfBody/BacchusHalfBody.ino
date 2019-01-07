#include"DelayUsingMillis.h";

#define RIGHT_HAND 39 //Q0.7
#define LEFT_HAND 40 //Q0.6
#define HEAD 36 //I0.1
#define EYE_LID 37 //Q0.1
#define MOUTH 38 //Q0.2
#define MOUTH_SENSOR 24 //I0.2
#define HEAD_SENSOR 23 //I0.1
#define LEFT_ARM_SENSOR_UP A0 //I0.7
#define LEFT_ARM_SENSOR_DOWN A1 //I0.8
#define RIGHT_ARM_SENSOR_UP 25 //I0.3
#define RIGHT_ARM_SENSOR_DOWN 26 //I0.4
#define START_SWITCH 22 //I0.0

DelayMillis reset, headPlay, mouthPlay, mouthPlay2, loopMotion, drinkPlay, blinkPlay, blinkTrig;

bool innerBlinkState;
bool isSenseMouth, isSenseHead, isSenseALeftUp, isSenseALeftDown, isSenseARightUp, isSenseARightDown;
bool toCountMouth, toCountHead, toCountLeftUp, toCountLeftDown, toCountRightUp, toCountRightDown;
bool armRightIsRev, armLeftIsRev, headIsRev, eyeLidIsRev, mouthIsRev, inDefaultPos, playLoop;
bool rightArm, leftArm, head, eyeLid, mouth;
bool rightArmInDef, leftArmInDef;
bool timeElapsed, mouthEnteredDown;
int mouthSensorState, headSensorState, aLeftUpSensorState, aLeftDownSensorState, aRightUpSensorState, aRightDownSensorState;
int mouthEnteredUp = 0, blinkState = 0;
bool switchKnob;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(RIGHT_HAND, OUTPUT);
  pinMode(LEFT_HAND, OUTPUT);
  pinMode(HEAD, OUTPUT);
  pinMode(EYE_LID, OUTPUT);
  pinMode(MOUTH, OUTPUT);
//  pinMode(MOUTH_SENSOR, INPUT);
//  pinMode(HEAD_SENSOR, INPUT);
//  pinMode(LEFT_ARM_SENSOR_UP, INPUT);
//  pinMode(LEFT_ARM_SENSOR_DOWN, INPUT);
//  pinMode(RIGHT_ARM_SENSOR_UP, INPUT);
//  pinMode(RIGHT_ARM_SENSOR_DOWN, INPUT);
//  pinMode(START_SWITCH, INPUT);

  innerBlinkState = false;
  mouthEnteredUp = blinkState = 0;
  timeElapsed = mouthEnteredDown = false;
  rightArmInDef = leftArmInDef= playLoop = false;
  mouthSensorState = headSensorState = aLeftUpSensorState = aLeftDownSensorState = aRightUpSensorState = aRightDownSensorState = 0;
  toCountMouth = toCountHead = toCountLeftUp = toCountLeftDown = toCountRightUp = toCountRightDown = true;
  inDefaultPos = armRightIsRev = armLeftIsRev = headIsRev = eyeLidIsRev = mouthIsRev = false;
}

void loop() {
  // put your main code here, to run repeatedly:
  //StartPlay();
  
  switchKnob = digitalRead(START_SWITCH);
  if(switchKnob){
    if (inDefaultPos){
      StartPlay();
    }else{
      SetDefault();
    }
  }else{
    digitalWrite(RIGHT_HAND, LOW);
    digitalWrite(LEFT_HAND, LOW);
    digitalWrite(HEAD, LOW);
    digitalWrite(EYE_LID, LOW);
    digitalWrite(MOUTH, LOW);

    headPlay.isEntered = false;
    mouthPlay.isEntered = false;
    loopMotion.isEntered = false;
    drinkPlay.isEntered = false;
    mouthPlay2.isEntered = false;
    blinkPlay.isEntered = false;
    blinkTrig.isEntered =false;
    mouthSensorState = 0;
    headSensorState = 0;
    aRightUpSensorState = 0;
    aRightDownSensorState = 0;
    aLeftUpSensorState = 0;
    aLeftDownSensorState = 0;
    blinkState = 0;
    playLoop = false;
    mouthEnteredDown = false;
    reset.isEntered = false;
    inDefaultPos = false;
    armRightIsRev = armLeftIsRev = headIsRev = eyeLidIsRev = mouthIsRev = false;
    playLoop = false;
    mouthEnteredUp = 0;
    innerBlinkState = false;
  }
  Serial.println(inDefaultPos);
}
