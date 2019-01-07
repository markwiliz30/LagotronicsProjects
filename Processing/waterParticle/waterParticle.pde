PImage frog;

void setup(){
  size(520, 320);
  frog = loadImage("car2.jpg");
  background(0);
}

void draw(){
  for(int i = 0; i< 500; i++)
  {
    float x = random(width);
  float y = random(height);
  color c = frog.get(int(x), int(y));
  fill(c, 25);
  noStroke();
  ellipse(x,y,16,16);
  }
}