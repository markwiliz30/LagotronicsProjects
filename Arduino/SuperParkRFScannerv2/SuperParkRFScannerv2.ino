#include <Ethernet.h>
#include <SD.h>
#include <SPI.h>
#include <MFRC522.h>

#include <EthernetUdp.h>

#define SS_PIN 6
#define RST_PIN 9
MFRC522 mfrc522(SS_PIN, RST_PIN);   // Create MFRC522 instance. 

byte my_mac[] = {0xDE, 0xAD, 0xBE , 0xEF,0xFE,0xED};
IPAddress my_ip(192,168,1,71);
IPAddress ip_client(192,168,1,133);

String content;
unsigned int localPort = 200;
char packetBuffer[UDP_TX_PACKET_MAX_SIZE];
char ReplyBuffer[] = "Hello";
  
  EthernetUDP Udp;

  int buttonState;            
  int lastButtonState = LOW; 
  
  unsigned long lastDebounceTime = 0;  
  unsigned long debounceDelay = 50;

void setup()
{
  Serial.begin(9600);       // for debugging
  SPI.begin();
  mfrc522.PCD_Init();
  Ethernet.begin(my_mac, my_ip);
  Udp.begin(localPort);
}

void loop()
{
    if ( !mfrc522.PICC_IsNewCardPresent()) 
    {
      return;
    }
    if (!mfrc522.PICC_ReadCardSerial())
    {
      return;
    } 
    udp_check();
    UDPSendData(readRFID());
    //Serial.println(readRFID());
    delay(500);
}
