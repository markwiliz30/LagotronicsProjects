String readRFID()
{
    content = "";
    for (byte i = 0; i < mfrc522.uid.size; i++) 
    {
       content.concat(String(mfrc522.uid.uidByte[i] < 0x10 ? "0" : ""));
       content.concat(String(mfrc522.uid.uidByte[i], HEX));
    }
    return content;
}

void udp_check(){
    
  int packetSize = Udp.parsePacket();

  if(packetSize){
    Serial.print("Received packet of size ");
    Serial.print(packetSize);
    Serial.print("From ");
    IPAddress remote =  Udp.remoteIP();
     
    for (int i = 0 ; i <4 ; i++){
 
      Serial.print(remote[i], DEC);
      if(i<3){
        Serial.print(".");
      }
    }
    Serial.print(", port ");
    Serial.println(Udp.remotePort());

    Udp.read(packetBuffer , UDP_TX_PACKET_MAX_SIZE);
    Serial.println("Contents: ");
    Serial.println(packetBuffer);

    memset(packetBuffer, 0 , sizeof(packetBuffer));
  }
  delay(10);
}

void UDPSendData(String target)
{
  Udp.beginPacket(ip_client , localPort);
  Udp.print(target);
  Udp.endPacket();
}
