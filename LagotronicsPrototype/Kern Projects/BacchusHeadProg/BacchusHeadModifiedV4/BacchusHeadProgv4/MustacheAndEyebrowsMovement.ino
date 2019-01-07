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
    digitalWrite(MUSTACHE, !moveHair);
    digitalWrite(LEFT_EYEBROW, moveHair);
    digitalWrite(RIGHT_EYEBROW, moveHair);
  } 
  else{
    moveHair = 1;
    digitalWrite(MUSTACHE, !moveHair);
    digitalWrite(LEFT_EYEBROW, moveHair);
    digitalWrite(RIGHT_EYEBROW, moveHair);
  }
}

void MoveEyeBrows(){
  if(!isEyeBrowsMoving){
    eyeBrowsIsUp = false;
  }
  digitalWrite(LEFT_EYEBROW, eyeBrowsIsUp);
  digitalWrite(RIGHT_EYEBROW, eyeBrowsIsUp);
  if(isEyeBrowsMoving){
    eyeBrowsIsUp = isEyeBrowsMoving = moveEyeBrows.Playgreater(float(3));
  }
}

void MoveMustache(){
  isMustacheMoving = moveMustache.Playgreater(float(5));
  digitalWrite(MUSTACHE, isMustacheMoving);
}
