#include"DelayUsingMillis.h";

#define PROGSWITCH 7 //I0.1
#define TROMBONE 8 //Q0.8
#define HAND 9 //Q0.3

float mulTrombone = 5;

DelayMillis tromboneDelay;

int switchKnob = 0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(PROGSWITCH, INPUT);
  pinMode(TROMBONE, OUTPUT);
  pinMode(HAND, OUTPUT);
}

void loop() {
  switchKnob = digitalRead(PROGSWITCH);
  
  if(switchKnob == 1){
    Move();
  }else{
    digitalWrite(HAND, LOW);
    digitalWrite(TROMBONE, LOW);
  }
}

void Move(){
  bool tromboneTrig = tromboneDelay.Playgreater(mulTrombone);
  
  digitalWrite(HAND, tromboneTrig);
  digitalWrite(TROMBONE, tromboneTrig);
}
