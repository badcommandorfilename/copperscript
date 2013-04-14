using System.Collections.Generic;
using System.Html;

public interface JSDrawingContext{
   void drawImage(ImageElement img, int xpos, int ypos, int width, int height);
   object getImageData(int xstart, int ystart, int xend, int yend);
}