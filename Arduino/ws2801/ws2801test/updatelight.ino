void updatestring(){
  for(int i=0;i<23;i++){
    shiftOut(datapin, clockpin, MSBFIRST, RED[i]);
    shiftOut(datapin, clockpin, MSBFIRST, GREEN[i]);
    shiftOut(datapin, clockpin, MSBFIRST, BLUE[i]);
    }
}
