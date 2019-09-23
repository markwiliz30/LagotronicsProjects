void counting()
{
  if(counter > 9)
  {
    counter2++;
    counter = 0;
    count(counter, 0);
  }
  else 
  {
    count(counter, 0);
  }

  if(counter2 > 9)
  {
    counter3++;
    counter2 = 0;
    count(counter2, 1);
  }
  else
  {
    count(counter2, 1);
  }

  if(counter3 > 9)
  {
    counter3 = counter2 = counter = 0;
    count(counter, 0);
    count(counter2, 1);
    count(counter3, 2);
  }
  else
  {
    count(counter3, 2);
  }
  counter++;  
}

void casino()
{
  if(!isStopped)
  {
    int x = random(0, 10);
    int x1 = random(0, 10);
    int x2 = random(0, 10);

//    counter(x, 0);
//    counter(x1, 1);
//    counter(x2, 2);
  }
}
