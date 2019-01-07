void setup() {
  size(640, 360);
}

void draw()
{
  background(0);

  stroke(255);
  line(100, 0, 100, height);

  line(200, 0, 200, height);

  if (mouseX > 200) {
    fill(255, 0, 0);
    rect(250, 100, 50, 50);
  } else if (mouseX > 100) {
    fill(0, 0, 255);
    rect(250, 200, 50, 50);
  }
}