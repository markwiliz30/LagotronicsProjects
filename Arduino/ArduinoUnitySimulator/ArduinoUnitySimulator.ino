#define POTENTIO A0


unsigned long currentMillis, previousMillis, interval = 20;
bool isEntered = false;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);

  isEntered = false;
}

void loop() {
    String myData = String((map(analogRead(POTENTIO), 0, 1024, 0, 360)));
    Transmit(myData);
}
