#include"DelayUsingMillis.h";

#define EYES1_HEAD 12 //Q0.7
#define EYES2_HEAD 3 //Q0.6
#define EYE_SENSOR 7 //I0.1
#define MUSTACHE 5 //Q0.5
#define LEFT_EYEBROW 6 //Q0.4
#define RIGHT_EYEBROW 9 //Q0.3
#define START_SWITCH 2 //I0.0

int switchKnob = 0, sensor = 0, eyes1 = 0, eyes2 = 0, moveHair = 0;

float readDelay = 0.5;

int sensorState = 0, mulEye = 6;

bool isEntered = false, isEnteredForEyes = false, isEnteredGlobal = false, toStop = false, isReverse = false, holdRev, isReverseForOther = false, isReaded = false, needToRead = true, toCount = true, toMove = true;
bool isEyeBrowsMoving = false, eyeBrowsIsUp, isMustacheMoving;

long previousMillis_forEyes = 0;
long previousMillis = 0;
long previousMillis_forSensor = 0;

long interval = 1000;

DelayMillis moveEyeBrows, moveMustache;

unsigned long currentMillis, currentMillisForSensor, currentMillisForEyeMovement;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(EYES1_HEAD, OUTPUT);
  pinMode(EYES2_HEAD, OUTPUT);
  pinMode(MUSTACHE, OUTPUT);
  pinMode(LEFT_EYEBROW, OUTPUT);
  pinMode(RIGHT_EYEBROW, OUTPUT);
  pinMode(EYE_SENSOR, INPUT);
  pinMode(START_SWITCH, INPUT);

  moveHair = 1;
  toCount = true;
  toMove = true;
  sensorState = 0;
  isEyeBrowsMoving = false;
}

void loop() {
  // put your main code here, to run repeatedly:
  switchKnob = digitalRead(START_SWITCH);
  if (switchKnob == 1){
    DetectSensor();
    MoveMustache();
    //Move();
    //Serial.println(EYES1_HEAD);
  }
  else
  {
    isEnteredGlobal = false;
    digitalWrite(EYES1_HEAD, LOW);
    digitalWrite(EYES2_HEAD, LOW);
    digitalWrite(MUSTACHE, LOW);
    digitalWrite(LEFT_EYEBROW, LOW);
    digitalWrite(RIGHT_EYEBROW, LOW);
  }
  Serial.println(toStop);
  Serial.println(currentMillisForSensor - previousMillis_forSensor);
//  MoveEyes();
//  Serial.println(isReverse);
}
