PImage car;

void setup(){
  size(516,328);
  car = loadImage("car2.jpg");
}

void draw(){
  loadPixels();
  car.loadPixels();
  for (int x = 0; x < width; x++){
    for(int y = 0; y < height; y++){
      int loc = x+y*width;
      
      float b = brightness(car.pixels[loc]);
      float myMouse = map(mouseX, 0, 516, 0, 256);
      if (b >= myMouse) {
        pixels[loc] = color(255);
      } else {
        pixels[loc] = color(0);
      }
      
      //float r = red(car.pixels[loc]);
      //float g = green(car.pixels[loc]);
      //float b = blue(car.pixels[loc]);
      //if (x>mouseX)
      //{
      //  pixels[loc] = color(b,r,g);
      //}
      //else
      //{
      //  pixels[loc] = color(r,g,b);
      //}
    }
  }
  updatePixels();
}