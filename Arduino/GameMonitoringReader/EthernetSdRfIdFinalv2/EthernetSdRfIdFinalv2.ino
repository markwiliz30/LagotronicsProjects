#include <SPI.h>
#include <Ethernet.h>
#include <SD.h>
#include <MFRC522.h>
#include "RF_Class.h";

#define SS_PIN 6
#define RST_PIN 9
#define LED_G 3 //define green LED pin
#define LED_R 5 //define red LED
MFRC522 mfrc522(SS_PIN, RST_PIN);   // Create MFRC522 instance.
Indicator i;

String content= "";

// MAC address from Ethernet shield sticker under board
byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };

EthernetClient client;
int port = 100;  // telnet default port

char myVar[100]; // contains string with variable to transmit
bool isConnected = true;

String serverNet1 = "";
String serverNet2 = "";
String serverHost1 = "";
String serverHost2 = "";

String clientNet1 = "";
String clientNet2 = "";
String clientHost1 = "";
String clientHost2 = "";

File file;

void(*resetFunc)(void)=0;

void setup()
{
    Serial.begin(9600);       // for debugging
    SPI.begin();
    i.Set(LED_R, LED_G);
    
    Serial.println("Initializing SD card...");
    if (!SD.begin(4)) {
        Serial.println("ERROR - SD card initialization failed!");
        Error();
        //return;    // init failed
    }
    Serial.println("SUCCESS - SD card initialized.");
    // check for index.htm file
    if (!SD.exists("ServerIp.txt")) {
        Serial.println("Can't find ServerIp.txt file");
        Error();
        //resetFunc();
    }
    else if (!SD.exists("ClientIp.txt"))
    {
        Serial.println("Can't find ClientIp.txt file");
        Error();
        //resetFunc();
    }
    
    ReadClientIP();
    
    IPAddress ip(clientNet1.toInt(),clientNet2.toInt(),clientHost1.toInt(),clientHost2.toInt());
    Ethernet.begin(mac, ip);  // initialize Ethernet device
    
    //initialize SD card
    
    Serial.println("SUCCESS - Found ServerIp.txt, ClientIp.txt file.");

    ReadServerIp();
    IPAddress server(serverNet1.toInt(),serverNet2.toInt(),serverHost1.toInt(),serverHost2.toInt());
    
     if (client.connect(server, port)) {
      mfrc522.PCD_Init();
      isConnected = true;
      client.print("(192.168.127.74 connected");
      Serial.println("connected");
      i.PH(LED_G);
     } 
     else {
    // if you didn't get a connection to the server:
    isConnected = false;
    Serial.println("connection failed");
    Error();
    //resetFunc();
  }
}

void loop()
{
   if (!client.connected()) {
    i.PL(LED_G);
    Error();
    /*Serial.println();
    Serial.println("disconnecting.");
    client.stop();
    i.PL(LED_G);
    // do nothing:
      Error();
      //resetFunc();*/
  }
  else
  {
      // Look for new cards
      if ( !mfrc522.PICC_IsNewCardPresent()) 
      {
        i.PL(LED_R);
        return;
      }
      if (!mfrc522.PICC_ReadCardSerial())
      {
        i.PL(LED_R);
        return;
      }
      //Show UID on serial monitor
      //i.PL(LED_R);  
      i.PH(LED_R);
      byte letter; 
      for (byte i = 0; i < mfrc522.uid.size; i++) 
      {
         //Serial.print(mfrc522.uid.uidByte[i] < 0x10 ? "0" : "");
         //Serial.print(mfrc522.uid.uidByte[i], HEX);
         content.concat(String(mfrc522.uid.uidByte[i] < 0x10 ? "0" : ""));
         content.concat(String(mfrc522.uid.uidByte[i], HEX));
      }
      Output(content);
      client.stop();
      IPAddress server(serverNet1.toInt(),serverNet2.toInt(),serverHost1.toInt(),serverHost2.toInt());
      client.connect(server, port);
      content = "";
    }
    delay(500);
    if(Serial.read() == "d")
    {
      Error();
    } 
}

void Output(String content)
{
  Serial.println(content);
  client.print(")"+content);
}

void ReadServerIp()
{
  file = SD.open("ServerIp.txt", FILE_READ);
    if (file)
    {
      Serial.println("Reading...");
      int sel = 0;
      char character;
      while((character = file.read()) != -1){
        switch(sel) {
          case 0:
          if (character != '.')
          {
            serverNet1.concat(String(character));
          }
          break;
          case 1:
          if (character != '.')
          {
            serverNet2.concat(String(character));
          }
          break;
          case 2:
          if (character != '.')
          {
            serverHost1.concat(String(character));
          }
          break;
          case 3:
          if (character != '.')
          {
            serverHost2.concat(String(character));
          }
          break;
          }
        if (character == '.')
        {
          sel++;
        }
       }
        Serial.println();
        file.close();
    }
}

void ReadClientIP()
{
 file = SD.open("ClientIp.txt", FILE_READ);
    if (file)
    {
      Serial.println("Reading Client ip...");
      int sel = 0;
      char character;
      while((character = file.read()) != -1){
        switch(sel) {
          case 0:
          if (character != '.')
          {
            clientNet1.concat(String(character));
          }
          break;
          case 1:
          if (character != '.')
          {
            clientNet2.concat(String(character));
          }
          break;
          case 2:
          if (character != '.')
          {
            clientHost1.concat(String(character));
          }
          break;
          case 3:
          if (character != '.')
          {
            clientHost2.concat(String(character));
          }
          break;
          }
        if (character == '.')
        {
          sel++;
        }
       }
        Serial.println();
        file.close();
        Serial.println("Client IP = " + clientNet1 + clientNet2 + clientHost1 + clientHost2);
    }
}

void Error()
{
  resetFunc();
}
