void MoveHead(){
  if(!headIsRev){
    head = true;
  }else{
    head = false;
  }

  digitalWrite(HEAD, head);
}

void HeadWatcher(){
  isSenseHead = digitalRead(HEAD_SENSOR);
  
  if(isSenseHead){
    if(toCountHead){
      toCountHead = false;
      headSensorState++;
    }
  }else{
    toCountHead = true;
  }
}
