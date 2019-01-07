class Particle {
  float x;
  float y;
  
  float vx;
  float vy;
  
  Particle() {
    x = width/2;
    y = height/2;
    float a = random(TWO_PI);
    float speed = random(1,2);
    vx = cos(a)*speed;
    vy = sin(a)*speed;
  }
  
  void display(){
    noStroke();
    color c = car.get(int(x/2), int(y/2));
    fill(c, 25);
    rect(x, y, 12,12);
  }
  
  void move(){
    x = x + vx;
    y = y + vy;
    if (y<0){
      y = height;
    }
    
    if (y > height){
      y = 0;
    }
    
    if (x < 0) {
      x = width;
    }
    
    if (x > width){
      x = 0;    
    }
  }
}
