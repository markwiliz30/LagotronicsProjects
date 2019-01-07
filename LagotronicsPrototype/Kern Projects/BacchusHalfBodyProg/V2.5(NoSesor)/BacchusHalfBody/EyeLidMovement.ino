void MoveEyeLid(){
  if(!eyeLidIsRev){
    eyeLid = false;
  }else{
    eyeLid = true;
  }

  digitalWrite(EYE_LID, eyeLid);
}

void BlinkMove(){
  if(blinkState < 2){
    if(blinkPlay.Timer(float(2))){
      eyeLidIsRev = false;
      blinkState = 2;
      blinkPlay.isEntered = false;
    }else{
      eyeLidIsRev = true;
    }
  } 
}
