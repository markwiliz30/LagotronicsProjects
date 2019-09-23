int BLUE[23];
int GREEN[23];
int RED[23];

int clockpin = 2;
int datapin = 3;

void setup() {
  // put your setup code here, to run once:
  pinMode(clockpin, OUTPUT);
  pinMode(datapin, OUTPUT);
  delay(2000);
  for(int i=0;i<23;i++){
    BLUE[i]=0;
    GREEN[i]=0;
    RED[i]=0;
    updatestring();
    }
}

void loop() {
  // put your main code here, to run repeatedly:
  for(int i=0;i<23;i++){
    BLUE[i]=4;GREEN[i]=77;RED[i]=245;
    updatestring();
    BLUE[i]=0;GREEN[i]=0;RED[i]=0;
    delay(10);
    }
    //BLUE[2]=4;GREEN[2]=77;RED[2]=245;
    //updatestring();
}

void callred(int a){
  BLUE[a]=0;GREEN[a]=0;RED[a]=255;
  updatestring();
}

void callgreen(int a){
  BLUE[a]=0;GREEN[a]=0;RED[a]=255;
  updatestring();
}

void callblue(int a){
  BLUE[a]=0;GREEN[a]=0;RED[a]=255;
  updatestring();
}
