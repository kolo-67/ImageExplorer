using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageExplorer
{
    //--------------------------------------------------------------------------------------
    // class CompareColorBorderInImage
    //--------------------------------------------------------------------------------------
    public class CompareColorBorderInImage
    {
        private Bitmap fImage = null;
        private byte[][] fMatrix000;
        private byte[][] fMatrix001;
        private byte[][] fMatrix010;
        private byte[][] fMatrix011;
        private byte[][] fMatrix100;
        private byte[][] fMatrix101;
        private byte[][] fMatrix110;
        private byte[][] fMatrix111;
        private Bitmap fColorPicture;
        //--------------------------------------------------------------------------------------
        public CompareColorBorderInImage(Bitmap pImage)
        {
            fImage = pImage;
        }
        //--------------------------------------------------------------------------------------
        public void ComputePicture(int pBorderRed, int pBorderGreen, int pBorderBlue, Color[] pColorsForMatrix)
        {
            fMatrix000 = new byte[fImage.Width][];
            fMatrix001 = new byte[fImage.Width][];
            fMatrix010 = new byte[fImage.Width][];
            fMatrix011 = new byte[fImage.Width][];
            fMatrix100 = new byte[fImage.Width][];
            fMatrix101 = new byte[fImage.Width][];
            fMatrix110 = new byte[fImage.Width][];
            fMatrix111 = new byte[fImage.Width][];
            fColorPicture = new Bitmap(fImage.Width,fImage.Height);
            for (int i = 0; i < fImage.Width; i++)
            {
                try
                {
                    fMatrix000[i] = new byte[fImage.Height];
                    fMatrix001[i] = new byte[fImage.Height];
                    fMatrix010[i] = new byte[fImage.Height];
                    fMatrix011[i] = new byte[fImage.Height];
                    fMatrix100[i] = new byte[fImage.Height];
                    fMatrix101[i] = new byte[fImage.Height];
                    fMatrix110[i] = new byte[fImage.Height];
                    fMatrix111[i] = new byte[fImage.Height];
                    for (int j = 0; j < fImage.Height; j++)
                    {
                        fMatrix000[i][j] = 0;
                        fMatrix001[i][j] = 0;
                        fMatrix010[i][j] = 0;
                        fMatrix011[i][j] = 0;
                        fMatrix100[i][j] = 0;
                        fMatrix101[i][j] = 0;
                        fMatrix110[i][j] = 0;
                        fMatrix111[i][j] = 0;
                        fColorPicture.SetPixel(i, j, pColorsForMatrix[0]);
                        Color lCurColor = fImage.GetPixel(i, j);
                        int lRed = lCurColor.R;
                        int lGreen = lCurColor.G;
                        int lBlue = lCurColor.B;
                        if (lRed < pBorderRed && lGreen < pBorderGreen && lBlue < pBorderBlue)
                        {
                            fMatrix000[i][j] = 1;
                            fColorPicture.SetPixel(i, j, pColorsForMatrix[0]);
                        }
                        else if (lRed < pBorderRed && lGreen < pBorderGreen && lBlue >= pBorderBlue)
                        {
                            fMatrix001[i][j] = 1;
                            fColorPicture.SetPixel(i, j, pColorsForMatrix[1]);
                        }
                        else if (lRed < pBorderRed && lGreen >= pBorderGreen && lBlue < pBorderBlue)
                        {
                            fMatrix010[i][j] = 1;
                            fColorPicture.SetPixel(i, j, pColorsForMatrix[2]);
                        }
                        else if (lRed < pBorderRed && lGreen >= pBorderGreen && lBlue >= pBorderBlue)
                        {
                            fMatrix011[i][j] = 1;
                            fColorPicture.SetPixel(i, j, pColorsForMatrix[3]);
                        }
                        else if (lRed >= pBorderRed && lGreen < pBorderGreen && lBlue < pBorderBlue)
                        {
                            fMatrix100[i][j] = 1;
                            fColorPicture.SetPixel(i, j, pColorsForMatrix[4]);
                        }
                        else if (lRed >= pBorderRed && lGreen < pBorderGreen && lBlue >= pBorderBlue)
                        {
                            fMatrix101[i][j] = 1;
                            fColorPicture.SetPixel(i, j, pColorsForMatrix[5]);
                        }
                        else if (lRed >= pBorderRed && lGreen >= pBorderGreen && lBlue < pBorderBlue)
                        {
                            fMatrix110[i][j] = 1;
                            fColorPicture.SetPixel(i, j, pColorsForMatrix[6]);
                        }
                        else if (lRed >= pBorderRed && lGreen >= pBorderGreen && lBlue >= pBorderBlue)
                        {
                            fMatrix111[i][j] = 1;
                            fColorPicture.SetPixel(i, j, pColorsForMatrix[7]);
                        }
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    throw;
                }

            }
        }
        //--------------------------------------------------------------------------------------
        public byte[][] Matrix000
        {
            get
            {
                return fMatrix000;
            }
        }
        //--------------------------------------------------------------------------------------
        public byte[][] Matrix001
        {
            get
            {
                return fMatrix001;
            }
        }
        //--------------------------------------------------------------------------------------
        public byte[][] Matrix010
        {
            get
            {
                return fMatrix010;
            }
        }
        //--------------------------------------------------------------------------------------
        public byte[][] Matrix011
        {
            get
            {
                return fMatrix011;
            }
        }
        //--------------------------------------------------------------------------------------
        public byte[][] Matrix100
        {
            get
            {
                return fMatrix100;
            }
        }
        //--------------------------------------------------------------------------------------
        public byte[][] Matrix101
        {
            get
            {
                return fMatrix101;
            }
        }
        //--------------------------------------------------------------------------------------
        public byte[][] Matrix110
        {
            get
            {
                return fMatrix110;
            }
        }
        //--------------------------------------------------------------------------------------
        public byte[][] Matrix111
        {
            get
            {
                return fMatrix111;
            }
        }
        //--------------------------------------------------------------------------------------
        public Bitmap ColorPicture
        {
            get
            {
                return fColorPicture;
            }
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
