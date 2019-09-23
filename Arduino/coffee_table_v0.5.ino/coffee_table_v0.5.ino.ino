#include "FastLED.h"
#define NUM_LEDS 128
#define DATA_PIN 3
#define CLOCK_PIN 2
CRGB leds[NUM_LEDS];
CRGB set[8] = {0xFF0000, 0x00FF00, 0x0000FF,0xFFFF00,0x00FFFF,0xFF00FF,0xFFFFFF,0x000000 };
CRGB dec[7] = {0x110000, 0x001100, 0x000011,0x111100,0x001111,0xFF00FF,0x555555};


void setup() {
  delay(2000);
  FastLED.addLeds<WS2801, DATA_PIN, CLOCK_PIN, RGB>(leds, NUM_LEDS);
  Serial.begin(9600);
}

unsigned long stepTime;


void loop() {
  
  //effect1();
  //effect4();
  //effect1(); 
  //effect4();

  effect6();
}

void callA(unsigned long time)
{
  CRGB colour = set[0];
  for(int i=0; i<=22; i++){
  colour -= dec[0];
  leds[i]=colour; 
  delay(200);
  FastLED.show();
  }  
}
