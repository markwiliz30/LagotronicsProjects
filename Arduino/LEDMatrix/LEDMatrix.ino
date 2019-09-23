//We always have to include the library
#include "LedControl.h"
#define trigger 2
/*
 Now we need a LedControl to work with.
 ***** These pin numbers will probably not work with your hardware *****
 pin 12 is connected to the DataIn 
 pin 11 is connected to the CLK 
 pin 10 is connected to LOAD/CS 
 ***** Please set the number of devices you have *****
 But the maximum default of 8 MAX72XX wil also work.
 */
LedControl lc=LedControl(12,11,10,3);

/* we always wait a bit between updates of the display */
bool isStopped = false;
unsigned long delaytime=500;
int counter = 0;
int counter2 = 0;
int counter3 = 0;
int mover = 0;

/* 
 This time we have more than one device. 
 But all of them have to be initialized 
 individually.
 */
void setup() {
  Serial.begin(9600);
  pinMode(trigger, INPUT);
  //we have already set the number of devices when we created the LedControl
  int devices=lc.getDeviceCount();
  //we have to init all devices in a loop
  for(int address=0;address<devices;address++) {
    /*The MAX72XX is in power-saving mode on startup*/
    lc.shutdown(address,false);
    /* Set the brightness to a medium values */
    lc.setIntensity(address,1);
    /* and clear the display */
    lc.clearDisplay(address);
  }

  for(int x = 0; x<3; x++)
  {
    count(0, x);
  }
}

void loop() { 
  //read the number cascaded devices
  int devices=lc.getDeviceCount();

  if(digitalRead(trigger))
  {
    isStopped = !isStopped;
  }
  Serial.println(digitalRead(trigger));

  //casino();
  counting();
  delay(70);
  //we have to init all devices in a loop
}
