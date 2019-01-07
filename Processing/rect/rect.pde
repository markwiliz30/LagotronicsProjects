float circleX;
boolean a, b;
void setup() {
  size(640, 360);
  a = false;
  b = false;
  circleX = 0;
}

void draw() {
  background(50);

  stroke(255);
  ellipse(circleX, 50, 50, 50);

  if (a == false && b == false)
  {
    circleX++;
  } else if (a == true && b == true)
  {
    circleX--;
  }

  if (circleX == width)
  {
    a = true;
  } else if (circleX == 0)
  {
    a = false;
  }
}

void mousePressed() {
  b = !b;
}