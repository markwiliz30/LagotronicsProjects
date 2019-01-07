float circleX;
void setup() {
  size(640, 360);
  circleX = random(0,width);
}

void draw() {
  background(50);
  
  stroke(255);
  ellipse(circleX,50,50,50);

  circleX = circleX + random(-2,2);
  println(circleX);
}