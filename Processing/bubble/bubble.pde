PImage[] Balls = new PImage[2];

Ball[] b = new Ball[2];

void setup(){
  size(640, 360);
  for (int i = 0; i < Balls.length; i++){
    Balls[i] = loadImage("Ball"+i+".png");  
  }
  for (int i = 0; i < b.length; i++){
    int index = int(random(0,Balls.length));
    b[i] = new Ball(Balls[index],100+i*100, 300, random(32, 72));
  }
}
void draw(){
  background(255);
  //imageMode(CENTER);
  for (int i = 0; i < b.length; i++){
    b[i].ascend();
    b[i].display();
    b[i].top();
  }
}