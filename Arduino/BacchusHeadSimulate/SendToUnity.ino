void Transmit(String data1, String data2, String data3){
    sendCurrentMillis = millis();

    if(!sendIsEntered){
      sendPreviousMillis = millis();
    }
    sendIsEntered = true;

    if (sendCurrentMillis - sendPreviousMillis >= sendInterval){
      sendIsEntered = false;
      if(holder1 != data1){
        Serial.println(data1);
        //Serial.flush();
        holder1 = data1;
      }

      if(holder2 != data2){
        Serial.println(data2);
        //Serial.flush();
        holder2 = data2;
      }

      if(holder3 != data3){
        Serial.println(data3);
        //Serial.flush();
        holder3 = data3;
      }
    }    
    //delay(20);
}
