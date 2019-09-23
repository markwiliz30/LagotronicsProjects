int effect9i = 0, effect9j = 0;
bool revC = false, revLet = false;

void effect1(){
  callRed(10);
  callGreen(10);
  callBlue(10);
  callMagenta(10);
  callYellow(10);
  callCyan(10);
  callWhite(10);
}

void effect2(){
  //int r = random(0,5);
  for(int r=0;r<6;r++){
    for(int i=1;i<130;i++){
      leds[i-2]=set[6]-dec[6];
      leds[i-1]=set[r];
      leds[i]=set[r];
      leds[i+1]=set[r];
      leds[i+2]=set[r];
      leds[i+3]=set[r];
      leds[i+4]=set[r];
      delay(40);
      FastLED.show();
    }
  }
}
void effect3(){
  for(int x=1;x<6;x++){
    for(int i=1;i<130;i++){
      leds[i-2]=set[x];
      leds[i-1]=set[6];
      leds[i]=set[6];
      leds[i+1]=set[6];
      leds[i+2]=set[6];
      delay(40);
      FastLED.show();
    }
  }
}

void effect4(){
  for(int r=0;r<7;r++){
    for(int i=1;i<130;i++){
      memset(leds,0,sizeof(leds));
      leds[i-1]=set[r];
      leds[i]=set[r];
      leds[i+1]=set[r];
      leds[i+2]=set[r];
      leds[i+3]=set[r];
      leds[i+4]=set[r];
      leds[i+5]=set[r];
      leds[i+6]=set[r];
      leds[i+7]=set[r];
      delay(10);
      FastLED.show();
    }
  }
}

void effect5(){
  Ran(80);
}

void effect6(){
  for(int r=0;r<7;r++){
    for(int i=1;i<130;i++){
      memset(leds,0,sizeof(leds));
      int opp = 130-i;
      leds[opp-1]=set[r];
      leds[opp]=set[r];
      leds[opp+1]=set[r];
      leds[opp+2]=set[r];
      leds[opp+3]=set[r];
      leds[opp+4]=set[r];
      
      leds[i-1]=set[r];
      leds[i]=set[r];
      leds[i+1]=set[r];
      leds[i+2]=set[r];
      leds[i+3]=set[r];
      leds[i+4]=set[r];
      delay(20);
      FastLED.show();
    }
  }
}

void effect7(){
  int holdLedCount = -1;
  int x = -1;
   for(int i=0;i<25;i++){
    holdLedCount++;
    if(holdLedCount == 5){
      holdLedCount = 0;
    }
    for(int j=0;j<=holdLedCount;j++){
      if(holdLedCount==0)
      {
        x+=1;
      }
      leds[i]=set[x];
    }
    delay(65);
    FastLED.show();
  }
}

void effect8(){
  for(int i=0;i<7;i++){
    for(int j=0;j<12;j++){
      selectLetter(j, i);
      delay(65);
    }
  }
}

void effect9(){
  bool rev = false;
  for(int i=0;i<6;i++){
    if(!rev){
      for(int j=0;j<10;j++){
        selectLetter(j+1, 6);
        selectLetter(j, i);
        delay(100);
        if(j==9){
          rev = true;
          break;
        }
      }
    }else{
        for(int j=11;j>0;j--){
        selectLetter(j-1, 6);
        selectLetter(j, i);
        delay(100);
        if(j==1){
          rev = false;
          break;
        }
      }
    }    
  }
}
