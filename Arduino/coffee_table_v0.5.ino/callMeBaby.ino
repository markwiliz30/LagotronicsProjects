void callRed(unsigned long time)
{
 // memset(leds,0,sizeof(leds));
  for(int i=0; i<129; i++){
  int led1=(time%NUM_LEDS);
  leds[i]=set[0]; 
  delay(35);
  FastLED.show();
  }  
}
void callGreen(unsigned long time)
{
  //memset(leds,0,sizeof(leds));
  for(int i=0; i<129; i++){
  int led1=(time%NUM_LEDS);
  leds[i]=set[1]; 
  delay(35);
  FastLED.show();
  }  
}
void callBlue(unsigned long time)
{
  //memset(leds,0,sizeof(leds));
  for(int i=0; i<129; i++){
  int led1=(time%NUM_LEDS);
  leds[i]=set[2]; 
  delay(35);
  FastLED.show();
  }  
}

void callYellow(unsigned long time)
{
 // memset(leds,0,sizeof(leds));
  for(int i=0; i<129; i++){
  int led1=(time%NUM_LEDS);
  leds[i]=set[3]; 
  delay(35);
  FastLED.show();
  }  
}

void callMagenta(unsigned long time)
{
  //memset(leds,0,sizeof(leds));
  for(int i=0; i<129; i++){
  int led1=(time%NUM_LEDS);
  leds[i]=set[5]; 
  delay(35);
  FastLED.show();
  }  
}

void callCyan(unsigned long time)
{
  //memset(leds,0,sizeof(leds));
  for(int i=0; i<129; i++){
  int led1=(time%NUM_LEDS);
  leds[i]=set[4]; 
  delay(35);
  FastLED.show();
  }  
}

void callWhite(unsigned long time)
{
  //memset(leds,0,sizeof(leds));
  for(int i=0; i<129; i++){
  int led1=(time%NUM_LEDS);
  leds[i]=set[6]; 
  delay(35);
  FastLED.show();
  }  
}


void Ran(int duration)
{
  for(int i=0; i<=duration; i++){
  memset(leds,0,sizeof(leds));
  for(int i=0; i<129; i++){
  int ran = random(0,6);
  Serial.println(ran);
  leds[i]= set[ran]; 
  }  
  FastLED.show();
  delay(10);
  }
}

void selectLetter(int letter, int letterColor){
  switch(letter){
    case 0:
      letterL(letterColor);
      break;
    case 1:
      letterA(letterColor);
      break;
    case 2:
      letterG(letterColor);
      break;
    case 3:
      letterO(letterColor);
      break;
    case 4:
      letterT(letterColor);
      break;
    case 5:
      letterR(letterColor);
      break;
    case 6:
      letterO2(letterColor);
      break;
    case 7:
      letterN(letterColor);
      break;
    case 8:
      letterI(letterColor);
      break;
    case 9:
      letterC(letterColor);
      break;
    case 10:
      letterS(letterColor);
      break;
  }
}
