import gab.opencv.*;
import java.awt.Rectangle;
import processing.video.*;

Capture video;
OpenCV opencv;
Rectangle[] faces;

PImage img;

void setup() {
  size(640, 480);
  img = loadImage("prisonbars0.png");
  video = new Capture(this, 640, 480);
  opencv = new OpenCV(this, 640, 480);
  opencv.loadCascade(OpenCV.CASCADE_FRONTALFACE); 
  video.start();
}

void draw() {
  opencv.loadImage(video);
  image(video, 0, 0);
  faces = opencv.detect();

  if (faces.length > 0 )
  {
    image(img,0,0,width,height);
  }
  /*noFill();
  stroke(0, 255, 0);
  strokeWeight(3);
  for (int i = 0; i < faces.length; i++) {
    //image(img,faces[i].x,faces[i].y-140,faces[i].width,faces[i].height);
    //rect(faces[i].x, faces[i].y, faces[i].width, faces[i].height);
  }*/
}

void captureEvent(Capture video){
  video.read();
}
