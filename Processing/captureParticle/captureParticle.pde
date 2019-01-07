import processing.video.*;

Particle[] particles;

//PImage car;
Capture car;

void setup(){
  size(1280, 960);
  
  //printArray(Capture.list());
  
  car = new Capture(this, 640, 480);
  car.start();
  particles = new Particle[2500];
  for (int i = 0; i < particles.length; i++){
    particles[i] = new Particle();
  }
  background(0);
}

void draw(){
  for(int i = 0; i< particles.length; i++)
  {
    particles[i].display();
    particles[i].move();
  }
}

void captureEvent(Capture video){
  video.read();
}
