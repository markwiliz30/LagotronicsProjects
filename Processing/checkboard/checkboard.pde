void setup() {
  size(640, 360);
}
void draw() {
  background(0);
  stroke(255);

  for (int x = 0; x < width; x=x+20)
  {
    for (int y = 0; y < height; y=y+20)
    {
      fill(random(255), random(255), random(255));
      rect(x, y, 20, 20);
    }
  }
  delay(100);
}