void SetDefault(){

  if(!inDefaultPos){
    MoveRightArm();
    MoveLeftArm();
    MoveEyeLid();
    MoveHead();
    MoveMouth();
  }

  //timeElapsed = reset.Timer(float(5));

  if(reset.Timer(float(10))){
    inDefaultPos = true;
  }
  
//  RightArmUpWatcher();
//  RightArmDownWatcher();
//  LeftArmUpWatcher();
//  LeftArmDownWatcher();
//
//  if(aRightUpSensorState == 1){
//    armRightIsRev = true;  
//  }
//
//  if (aRightDownSensorState == 1){
//    rightArmInDef = true;
//    aRightDownSensorState = 0;
//  }
//
//   if(aLeftDownSensorState == 1){
//    armLeftIsRev = true;  
//  }
//
//  if (aLeftUpSensorState == 1){
//    leftArmInDef = true;
//    aLeftUpSensorState = 0;
//  }
//
//  if(rightArmInDef && leftArmInDef && timeElapsed){
//    rightArmInDef = leftArmInDef = timeElapsed = false;
//    inDefaultPos = true;
//  }
}
