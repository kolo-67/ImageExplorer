using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageExplorer
{
    //--------------------------------------------------------------------------------------
    // class CProximityColor
    //--------------------------------------------------------------------------------------
    public class CProximityColor
    {
        private int fXPos;
        private int fYPos;
        private Color fColor;
        //--------------------------------------------------------------------------------------
        public CProximityColor(int pXPos, int pYPos, Color pColor)
        {
            fXPos = pXPos;
            fYPos = pYPos;
            fColor = pColor;
        }
        //--------------------------------------------------------------------------------------
        public static Bitmap ProximityPicture(Bitmap pSourcePicture, int pCountCubic)
        {
            Bitmap lTargetPicture = pSourcePicture.Clone() as Bitmap;
            CProximityColorData lProximityColorData = new CProximityColorData(pSourcePicture, pCountCubic);

            lProximityColorData.EnforceToAverage(lTargetPicture);
            return lTargetPicture;
        }
        //--------------------------------------------------------------------------------------
        public static Bitmap[] CreateProjection(Bitmap pSourcePicture, int pScale)
        {
            CProximityColorData lProximityColorData = new CProximityColorData(pSourcePicture, pScale);
            int lNewPictureSize = pScale * 256;
            Bitmap lProjectionXY = new Bitmap(lNewPictureSize, lNewPictureSize);
            Bitmap lProjectionXZ = new Bitmap(lNewPictureSize, lNewPictureSize);
            Bitmap lProjectionYZ = new Bitmap(lNewPictureSize, lNewPictureSize);
            Color lBackColor = Color.FromArgb(255,255,255);
            Color lForeColor = Color.FromArgb(0,0,0);
            for (int i = 0; i < lNewPictureSize; i++)
                for (int j = 0; j < lNewPictureSize; j++)
                {
                    lProjectionXY.SetPixel(i, j, lBackColor);
                    lProjectionXZ.SetPixel(i, j, lBackColor);
                    lProjectionYZ.SetPixel(i, j, lBackColor);
                }
            foreach (CProximityColorList lColorList in lProximityColorData)
            {
                int lXPos = lColorList.CubeCoordinate[0];
                int lYPos = lColorList.CubeCoordinate[1];
                int lZPos = lColorList.CubeCoordinate[2];
                int lRadius = (Convert.ToInt32(Math.Ceiling( (1.0 * pScale * lProximityColorData.MaxSize)/lColorList.Count ))-1)/2; //????
                for (int i = lXPos * pScale - lRadius; i <= lXPos * pScale + lRadius; i++)
                    for (int j = lYPos * pScale - lRadius; j <= lYPos * pScale + lRadius; j++)
                        if (i >= 0 && j < lNewPictureSize && j >= 0 && j < lNewPictureSize)
                            lProjectionXY.SetPixel(i,j,lForeColor);
                for (int i = lXPos * pScale - lRadius; i <= lXPos * pScale + lRadius; i++)
                    for (int j = lZPos * pScale - lRadius; j <= lZPos * pScale + lRadius; j++)
                        if (i >= 0 && j < lNewPictureSize && j >= 0 && j < lNewPictureSize)
                            lProjectionXZ.SetPixel(i,j,lForeColor);
                for (int i = lYPos * pScale - lRadius; i <= lYPos * pScale + lRadius; i++)
                    for (int j = lZPos * pScale - lRadius; j <= lZPos * pScale + lRadius; j++)
                        if (i >= 0 && j < lNewPictureSize && j >= 0 && j < lNewPictureSize)
                            lProjectionYZ.SetPixel(i,j,lForeColor);
            }
            return new Bitmap[] { lProjectionXY, lProjectionXZ, lProjectionYZ };
        }
        //--------------------------------------------------------------------------------------
        public Color DataColor
        {
            get
            {
                return fColor;
            }
        }
        //--------------------------------------------------------------------------------------
        public int XPos
        {
            get
            {
                return XPos;
            }
        }
        //--------------------------------------------------------------------------------------
        public int YPos
        {
            get
            {
                return YPos;
            }
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
    // class CProximityColorList
    //--------------------------------------------------------------------------------------
    public class CProximityColorList : List<CProximityColor>
    {
        private Color fAverageColor = new Color();
        private byte[] fCubeCoordinate;
        //--------------------------------------------------------------------------------------
        public CProximityColorList(byte[] pCubeCoordinate)
            : base()
        {
            fCubeCoordinate = new byte[pCubeCoordinate.Length];
            for (int i = 0; i < pCubeCoordinate.Length; i++)
                fCubeCoordinate[i] = pCubeCoordinate[i];
        }
        //--------------------------------------------------------------------------------------
        public void DefineAverageColor()
        {
            decimal lRData = (from lProxColor in this
                          select lProxColor.DataColor.R).Average(b => Convert.ToDecimal(b));
            decimal lGData = (from lProxColor in this
                              select lProxColor.DataColor.G).Average(b => Convert.ToDecimal(b));
            decimal lBData = (from lProxColor in this
                              select lProxColor.DataColor.B).Average(b => Convert.ToDecimal(b));
            fAverageColor = Color.FromArgb(Convert.ToByte(Math.Round(lRData)), 
                                            Convert.ToByte(Math.Round(lGData)),
                                            Convert.ToByte(Math.Round(lBData)));
                
        }
        //--------------------------------------------------------------------------------------
        public void EnforceToAverage(Bitmap pPicture)
        {
            foreach (CProximityColor lProximityColor in this)
                pPicture.SetPixel(lProximityColor.XPos, lProximityColor.YPos, fAverageColor); 
        }
        //--------------------------------------------------------------------------------------
        public byte[] CubeCoordinate
        {
            get
            {
                return fCubeCoordinate;
            }
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
    // class CProximityColorData
    //--------------------------------------------------------------------------------------
    public class CProximityColorData : KeyedCollection<byte[], CProximityColorList>
    {
         private int fMaxSize = 0;
        //--------------------------------------------------------------------------------------
        public CProximityColorData(Bitmap pSourcePicture, int pCountCubic)
        {
            for (int i = 0; i < pSourcePicture.Width; i++)
                for (int j = 0; j < pSourcePicture.Height; j++)
                {
                    Color lColor = pSourcePicture.GetPixel(i, j);
                    byte[] lCude = new byte[]
                    {
                        (byte)(lColor.R/pCountCubic * pCountCubic),
                        (byte)(lColor.G/pCountCubic * pCountCubic),
                        (byte)(lColor.B/pCountCubic * pCountCubic)
                    };
                    if (!Contains(lCude))
                    {
                        CProximityColorList lProximityColorList = new CProximityColorList(lCude);
                        Add(lProximityColorList);
                    }
                    this[lCude].Add(new CProximityColor(i, j, lColor));
                }
            DefineAverageColor();
        }
        //--------------------------------------------------------------------------------------
        public CProximityColorData(Bitmap pSourcePicture)
        {
            for (int i = 0; i < pSourcePicture.Width; i++)
                for (int j = 0; j < pSourcePicture.Height; j++)
                {
                    Color lColor = pSourcePicture.GetPixel(i, j);
                    byte[] lCude = new byte[]
                    {
                        lColor.R,
                        lColor.G,
                        lColor.B
                    };
                    if (!Contains(lCude))
                    {
                        CProximityColorList lProximityColorList = new CProximityColorList(lCude);
                        Add(lProximityColorList);
                    }
                    this[lCude].Add(new CProximityColor(i, j, lColor));
                }
        }
        //--------------------------------------------------------------------------------------
        protected override byte[] GetKeyForItem(CProximityColorList item)
        {
            return item.CubeCoordinate;
        }
        //--------------------------------------------------------------------------------------
        public void DefineAverageColor()
        {
            foreach (CProximityColorList lColorList in this)
                lColorList.DefineAverageColor();
        }
        //--------------------------------------------------------------------------------------
        private void DefineMaxSize()
        {
            fMaxSize = 0;
            foreach (CProximityColorList lColorList in this)
                if (lColorList.Count > fMaxSize)
                    fMaxSize = lColorList.Count;
        }
        //--------------------------------------------------------------------------------------
        public void EnforceToAverage(Bitmap pPicture)
        {
            foreach (CProximityColorList lColorList in this)
                lColorList.EnforceToAverage(pPicture);
        }
        //--------------------------------------------------------------------------------------
        public int MaxSize
        {
            get
            {
                return fMaxSize;
            }
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
