void Transmit(String data){
    currentMillis = millis();

    if(!isEntered){
      previousMillis = millis();
    }
    isEntered = true;

    if (currentMillis - previousMillis >= interval){
      isEntered = false;
      Serial.println(data);
      Serial.flush();
    }    
}
