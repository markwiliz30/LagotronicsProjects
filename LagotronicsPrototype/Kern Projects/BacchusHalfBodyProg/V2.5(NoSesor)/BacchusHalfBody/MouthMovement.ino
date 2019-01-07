void MoveMouth(){
  if(!mouthIsRev){
    mouth = false;
  }else{
    mouth = true;
  }

  digitalWrite(MOUTH, mouth);
}

void MouthWatcher(){
  isSenseMouth = digitalRead(MOUTH_SENSOR);
  
  if(isSenseMouth){
    if(toCountMouth){
      toCountMouth = false;
      mouthSensorState++;
    }
  }else{
    toCountMouth = true;
  }
}
