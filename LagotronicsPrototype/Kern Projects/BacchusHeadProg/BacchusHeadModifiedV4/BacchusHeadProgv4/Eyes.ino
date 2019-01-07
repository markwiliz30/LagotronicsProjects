void DetectSensor(){
  sensor = digitalRead(EYE_SENSOR);

  MoveEyeBrows();
  
  if(sensor == 1){
    if(sensorState == 0){
      toMove = false;
    }else if(toCount){
      toCount = false;
      sensorState++;
    }
  }
  else{
    toCount = true;
  }
   
  if(sensorState == 4){
    toMove = false;
    isEyeBrowsMoving = true;
  }

  if(toMove){
    isEyeBrowsMoving = false;
    MoveEyes();
    if(holdRev == isReverse){
      mulEye = 6;
    }
  }else{
    StopMoving();
    if(!SensorTimer()){
      isReverse = !isReverse;
      sensorState = 1;
      toMove = true;
      holdRev = isReverse;
      mulEye = 3;
     //isEyeBrowsMoving = true;
    }
  }
}

bool SensorTimer(){
  currentMillisForSensor = millis();
  
  if (!isEntered){
    previousMillis_forSensor = millis();
  }
  isEntered = true;
  if (currentMillisForSensor - previousMillis_forSensor >= (interval * 9)){
    sensorState = 1;
    isReverse = !isReverse;
    isEntered = false;
    return false;
  }
  return true;
}

void MoveEyes(){
  currentMillisForEyeMovement = millis();

  if(!isEnteredForEyes){
    previousMillis_forEyes = millis();
  }
  isEnteredForEyes = true;
  if(currentMillisForEyeMovement - previousMillis_forEyes >= (interval * mulEye)){
    isReverse = !isReverse;
    isEnteredForEyes = false;
  }
  
  if (!isReverse){
    eyes1 = 0;
    eyes2 = 1;
    digitalWrite(EYES1_HEAD, eyes1);
    digitalWrite(EYES2_HEAD, eyes2);
  }
  else{
    eyes1 = 1;
    eyes2 = 0;
    digitalWrite(EYES1_HEAD, eyes1);
    digitalWrite(EYES2_HEAD, eyes2);
  }
}

void StopMoving(){
  if (!isReverse){
      eyes1 = 1;
      eyes2 = 1;
    }
    else{
      eyes1 = 0;
      eyes2 = 0;
    }

    digitalWrite(EYES1_HEAD, eyes1);
    digitalWrite(EYES2_HEAD, eyes2);
}
