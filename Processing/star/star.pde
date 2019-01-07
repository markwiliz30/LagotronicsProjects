void setup() {
  size(800, 500);
  background(0);
}
void draw(){

}
void mouseClicked(){
  drawStar(mouseX,mouseY);
}
void keyPressed(){
  background(0);
}
void drawStar(int x, int y){
  stroke(255);
  fill(random(255),random(255),random(255));
  beginShape();
  vertex(x, y-50);
  vertex(x+14, y-20);
  vertex(x+47, y-15);
  vertex(x+23, y+7);
  vertex(x+29, y+40);
  vertex(x+0, y+25);
  vertex(x-29, y+40);
  vertex(x-23, y+7);
  vertex(x-47, y-15);
  vertex(x-14, y-20);
  endShape(CLOSE);
}