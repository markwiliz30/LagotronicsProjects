class Indicator{
public:

void Set(byte pinNum, byte pinNum2)
{
 pinMode(pinNum, OUTPUT);
 pinMode(pinNum2, OUTPUT); 
}

void PH(byte pinNum)
{
  digitalWrite(pinNum, 1);
}

void PL(byte pinNum)
{
  digitalWrite(pinNum, 0);
}
};
