class DelayMillis{
public:

  bool isEntered = false;
  unsigned long myCurrentMillis, myPreviousMillis;
  float multiplyer, interval = 1000;
  int initialState = 0;
  
  bool Playgreater(float myMultiplyer){
     myCurrentMillis = millis();

     if (!isEntered){
      myPreviousMillis = millis();
     }
     isEntered = true;
     if (myCurrentMillis - myPreviousMillis >= (interval * myMultiplyer)){
      isEntered = false;
      initialState = !initialState;
     }
     
     if(initialState == 1){
      return true;
     }
     else{
      return false;
     }
  }
};
