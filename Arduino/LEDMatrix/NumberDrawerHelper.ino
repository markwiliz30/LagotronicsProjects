void setNumber(int address, int row, int col, bool val)
{
  lc.setLed(address,row,col,val);
}

void assignPoints(int dots[][8], int address)
{
  Serial.println(dots[4][2]);
  for(int row=0;row<8;row++)
  {
    for(int col=0;col<8;col++)
    {
      if(dots[row][col] == 1)
      {
        setNumber(address, row, col, true);
      }
      else
      {
        setNumber(address, row, col, false);
      }
    }
  }
}
