PImage img;

void setup(){
  size(600,400);
  img = loadImage("test.jpg");
}
void draw(){
  background(0);
  tint(0,0,255);
  image(img,0,0,600,400);
}