Particle[] particles;

PImage car;

void setup(){
  size(520, 320);
  car = loadImage("car2.jpg");
  particles = new Particle[50];
  for (int i = 0; i < particles.length; i++){
    particles[i] = new Particle();
  }
}

void draw(){
  for(int i = 0; i< particles.length; i++)
  {
    particles[i].display();
    particles[i].move();
  }
}