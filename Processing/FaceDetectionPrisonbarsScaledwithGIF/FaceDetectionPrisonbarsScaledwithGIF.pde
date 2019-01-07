import g4p_controls.*;
import jp.nyatla.nyar4psg.*;
import gab.opencv.*;
import java.awt.Rectangle;
import processing.video.*;
import gifAnimation.*;

Capture cam;
OpenCV opencv;
MultiMarker nya;
Rectangle[] faces;

Gif prisonBars;

PImage img;
boolean isClosed;

void setup() {
  size(800,600,P3D);
  cam = new Capture(this, 640, 480);
  //img = loadImage("prisonbars0.png");
  opencv = new OpenCV(this, 640, 480);
  opencv.loadCascade(OpenCV.CASCADE_FRONTALFACE); 
  frameRate(1000);
  nya=new MultiMarker(this,width,height,"camera_para.dat");
  prisonBars  = new Gif(this, "animationofclosedjailbarshq4.gif"); 
  isClosed = false;
  cam.start();
}

void draw() {
  nya.detect(cam);
  if (cam.available() !=true) {
    return;
  }
  nya.detect(cam);
  cam.start();
  nya.detect(cam);
  cam.read();
  
     //image(cam,0,0);
  nya.drawBackground(cam);
  opencv.loadImage(cam);
  noFill();
  faces = opencv.detect();
  
  if (faces.length > 0 )
  {
    image(prisonBars,0,0,width,height);
    if (!isClosed){
      prisonBars.play();
      isClosed = true;
    }
  }
  else{
    prisonBars.play();
    delay(1);
    image(prisonBars,0,0,width,height);
    prisonBars.stop();
    isClosed = false;
  }
  
  /*noFill();
  stroke(0, 255, 0);
  strokeWeight(3);
  for (int i = 0; i < faces.length; i++) {
    //image(img,faces[i].x,faces[i].y-140,faces[i].width,faces[i].height);
    //rect(faces[i].x, faces[i].y, faces[i].width, faces[i].height);
  }*/
}
/*void mousePressed(){
   prisonBars.play();
}*/
/*void captureEvent(Capture video){
  video.read();
}*/
