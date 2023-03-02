using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GhostHunter.Classes
{
    public class GhostMaker
    {
        public string imagePath { get; set; }
        public string ghostPath { get; set; }
        public Bitmap image { get; set; }
        public Bitmap ghostImage { get; set; }

        public GhostMaker(Bitmap image, string ghostPath)
        {
            this.image = image;
            this.ghostPath = ghostPath;
            ghostImage = new Bitmap(ghostPath);
        }

        public Bitmap AddGhosts()
        {
            int numGhosts = 1;
            int width = image.Width;
            int height = image.Height;

            Color pixelGhost;
            Color pixelImg;


            for (int y = 0; y < ghostImage.Height; y++)
            {
                for (int x = 0; x < ghostImage.Width; x++)
                {
                    //get pixel value
                    pixelGhost = ghostImage.GetPixel(x, y);
                    pixelImg = image.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = pixelGhost.A;
                    int r = pixelGhost.R;
                    int g = pixelGhost.G;
                    int b = pixelGhost.B;

                    pixelImg = image.GetPixel(x, y);

                    //extract pixel component ARGB
                    int aI = (pixelImg.A + pixelGhost.A) / 2;
                    int rI = (pixelImg.R + pixelGhost.R) / 2;
                    int gI = (pixelImg.G + pixelGhost.G) / 2;
                    int bI = (pixelImg.B + pixelGhost.B) / 2;

                    //find average
                    //int avg = (r + g + b) / 3;

                    //set new pixel value
                    if(!(r >= 240 && g >= 240 && b >= 240))
                    {
                        image.SetPixel(x, y, Color.FromArgb(aI, rI, gI, bI));
                    }
                    

                }
                
            }
            return image;

        }

        public static Bitmap MakeGreyscale(Bitmap bmp)
        {
            //get image dimension
            int width = bmp.Width;
            int height = bmp.Height;
            Console.WriteLine(width + ":" + height);

            //color of pixel
            Color p;

            //grayscale
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //find average
                    int avg = (r + g + b) / 3;

                    //set new pixel value
                    bmp.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            }
            return bmp;
        }
    }
}
