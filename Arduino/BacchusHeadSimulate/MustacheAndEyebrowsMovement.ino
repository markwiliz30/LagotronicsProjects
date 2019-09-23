void Move(){
  currentMillis = millis();

  if(!isEnteredGlobal){
    previousMillis = millis();
  }
  isEnteredGlobal = true;
  if(currentMillis - previousMillis >= (interval * 2)){
    isReverseForOther = !isReverseForOther;
    isEnteredGlobal = false;
  }

  if (isReverseForOther){
    moveHair = 0;
    //Transmit("l0");
    //Transmit("r0");
  //if(Serial.read() == "1"){
    Transmit("m1", "l0", "r0");
  //}
    //Transmit("e0");
//    digitalWrite(MUSTACHE, moveHair);
//    digitalWrite(LEFT_EYEBROW, moveHair);
//    digitalWrite(RIGHT_EYEBROW, moveHair);
  } 
  else{
    moveHair = 1;
    //Transmit("l1");
    //Transmit("r1");
  //if(Serial.read() == "0"){
    Transmit("m0", "l1", "r1");
  //}
    //Transmit("e1");
//    digitalWrite(MUSTACHE, moveHair);
//    digitalWrite(LEFT_EYEBROW, moveHair);
//    digitalWrite(RIGHT_EYEBROW, moveHair);
  }
}
