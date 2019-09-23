#define BUTTON 7

unsigned long sendCurrentMillis, currentMillis, previousMillis, sendPreviousMillis, sendInterval = 20, interval = 1000;
bool sendIsEntered = false, isEnteredGlobal = false, isReverseForOther = false;
String holder1, holder2, holder3;

int moveHair = 0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(1200);
  //pinMode(BUTTON, INPUT_PULLUP);

  sendIsEntered = false;
  moveHair = 1;
  holder1 = "";
  holder2 = "";
  holder3 = "";
}

void loop() {
  // put your main code here, to run repeatedly:
  Move();
}
