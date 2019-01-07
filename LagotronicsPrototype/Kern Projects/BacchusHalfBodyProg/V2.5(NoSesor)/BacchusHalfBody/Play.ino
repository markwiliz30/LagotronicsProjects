void StartPlay(){
  MoveRightArm();
  MoveLeftArm();
  MoveEyeLid();
  MoveHead();
  MoveMouth();

//  RightArmUpWatcher();
//  RightArmDownWatcher();
//  LeftArmUpWatcher();
//  LeftArmDownWatcher();
//  HeadWatcher();
//  MouthWatcher();

  if(innerBlinkState){
    BlinkMove();
    if(blinkState >= 2){
      blinkState = 0;
      innerBlinkState = false;
    }
  }

  if(headSensorState == 0){
    if(headPlay.Timer(8)){
      headIsRev = false;
      armLeftIsRev = true;
      headSensorState = 1;
      headPlay.isEntered = false;
    }else{
      headIsRev = true;
      armLeftIsRev = false;
      if(blinkTrig.Timer(7)){
        innerBlinkState = true;
        blinkTrig.isEntered =false;
      }
    }
  }

  if(headSensorState == 1){
   if(blinkTrig.Timer(10)){
      innerBlinkState = true;
      blinkTrig.isEntered =false;
   }
   if(headPlay.Timer(12)){
    headIsRev = true;
    armRightIsRev = true;
    armLeftIsRev = false;
    headSensorState = 2;
    headPlay.isEntered = false;
   } 
  }

  if(headSensorState == 2){
    if(mouthPlay.Timer(4) && !mouthEnteredDown){
      mouthIsRev = true;
      eyeLidIsRev = true;
      mouthPlay.isEntered = false;
      mouthEnteredDown = true;
    }

//    if(mouthPlay.Timer(5) && !mouthEnteredUp){
//      mouthIsRev = false;
//        eyeLidIsRev = false;
//    }
    
    if(headPlay.Timer(8)){
      if(drinkPlay.Timer(4)){
        armRightIsRev = false;
        armLeftIsRev = false;
        if(mouthPlay2.Timer(float(3))){
          headIsRev = false;
          mouthEnteredUp = 1;
          mouthPlay2.isEntered = false;
          playLoop = loopMotion.Timer(8);
        }
      }
      
      if(mouthEnteredUp == 1){
        mouthEnteredUp = 0;
        mouthIsRev = false;
        eyeLidIsRev = false;
      }
    }
  }
//  if(headSensorState == 0){
//    headIsRev = true;
//  }
//
//  if (headSensorState == 1){
//    headIsRev = false;
//  }

//  if(headSensorState == 2){
//      if(headPlay.Timer(5)){
//        //headPlay.isEntered = false;
//        headIsRev = true;
//        armRightIsRev = true;
//        armLeftIsRev = true;
//      }
//  }

//  if(headSensorState == 3 && aRightUpSensorState == 1 && aLeftDownSensorState == 1){
//    if(mouthSensorState == 0){
//      mouthIsRev = true;
//      eyeLidIsRev = true;
//    }else if(mouthSensorState == 1){
//      if(mouthPlay.Timer(5)){
//        mouthIsRev = false;
//        eyeLidIsRev = false;
//        armRightIsRev = false;
//        armLeftIsRev = false;
//        headIsRev = false;
//        playLoop = loopMotion.Timer(5);
//      }
//    }
//  }
  
  LoopAct();

}

void LoopAct(){
  if(playLoop){
    headPlay.isEntered = false;
    mouthPlay.isEntered = false;
    loopMotion.isEntered = false;
    drinkPlay.isEntered = false;
    blinkTrig.isEntered =false;
    blinkPlay.isEntered = false;
    mouthSensorState = 0;
    headSensorState = 0;
    aRightUpSensorState = 0;
    aRightDownSensorState = 0;
    aLeftUpSensorState = 0;
    aLeftDownSensorState = 0;
    blinkState = 0;
    blinkPlay.isEntered = false;
    playLoop = false;
    mouthEnteredDown = false;
  }
}
