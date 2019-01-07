void MoveRightArm(){
  if(!armRightIsRev){
    rightArm = false;
  }else{
    rightArm = true;
  }

  digitalWrite(RIGHT_HAND, rightArm);
}

void MoveLeftArm(){
  if(!armLeftIsRev){
    leftArm = false;
  }else{
    leftArm = true;
  }

  digitalWrite(LEFT_HAND, leftArm);
}

void RightArmUpWatcher(){
  isSenseARightUp = digitalRead(RIGHT_ARM_SENSOR_UP);
  
  if(isSenseARightUp){
    if(toCountRightUp){
      toCountRightUp = false;
      aRightUpSensorState++;
    }
  }else{
    toCountRightUp = true;
  }  
}

void RightArmDownWatcher(){
  isSenseARightDown = digitalRead(RIGHT_ARM_SENSOR_DOWN);
  
  if(isSenseARightDown){
    if(toCountRightDown){
      toCountRightDown = false;
      aRightDownSensorState++;
    }
  }else{
    toCountRightDown = true;
  }
}

void LeftArmUpWatcher(){
  isSenseALeftUp = digitalRead(LEFT_ARM_SENSOR_UP);
  
  if(isSenseALeftUp){
    if(toCountLeftUp){
      toCountLeftUp = false;
      aLeftUpSensorState++;
    }
  }else{
    toCountLeftUp = true;
  }
}

void LeftArmDownWatcher(){
  isSenseALeftDown = digitalRead(LEFT_ARM_SENSOR_DOWN);
  
  if(isSenseALeftDown){
    if(toCountLeftDown){
      toCountLeftDown = false;
      aLeftDownSensorState++;
    }
  }else{
    toCountLeftDown = true;
  }
}
