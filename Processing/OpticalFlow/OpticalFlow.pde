import gab.opencv.*;
import processing.video.*;

OpenCV opencv;
Capture video;

void setup() {
  size(1136, 322);
  video = new Capture(this, 640,480);
  opencv = new OpenCV(this, 640, 480);
  video.start();
}

void draw() {
  background(0);
  opencv.loadImage(video);
  opencv.calculateOpticalFlow();

  image(video, 0, 0);
  translate(video.width,0);
  stroke(255,0,0);
  opencv.drawOpticalFlow();
  
  PVector aveFlow = opencv.getAverageFlow();
  int flowScale = 50;
  
  stroke(255);
  strokeWeight(2);
  line(video.width/2, video.height/2, video.width/2 + aveFlow.x*flowScale, video.height/2 + aveFlow.y*flowScale);
}

void captureEvent(Capture video){
  video.read();
}