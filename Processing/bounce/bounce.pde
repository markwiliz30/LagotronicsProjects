float circleX, circleY, dirX, dirY, speed;
void setup()
{
  size(640, 360); 
  circleX = 25;
  circleY = 25;
  speed = 5;
  dirX = 1;
  dirY = 1;
}

void draw()
{
  background(0);

  displayBall();
  moveBall();
  bounceBack();
}

void displayBall() {
  stroke(255);
  ellipse(circleX, circleY, 50, 50);
}
void moveBall() {
  circleX = circleX + (speed * dirX);
  circleY = circleY + (speed * dirY);
}
void bounceBack() {
  if (circleX >= (width-25) || circleX <= 25)
  {
    dirX = dirX * -1;
  }

  if (circleY >= (height-25) || circleY <= 25)
  {
    dirY = dirY * -1;
  }
}