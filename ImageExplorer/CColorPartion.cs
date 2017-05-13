using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageExplorer
{
    //--------------------------------------------------------------------------------------
    // class CColorPartion
    //--------------------------------------------------------------------------------------
    public class CColorPartion
    {
        private Bitmap fSourceImage;
        private string fMainTextRed = "";
        private string fAddTextRed = "";
        private string fMainTextGreen = "";
        private string fAddTextGreen = "";
        private string fMainTextBlue = "";
        private string fAddTextBlue = "";
        private string fMainTextSumma = "";
        private string fAddTextSumma = "";
        private int[][] fRedPartition;
        private int[][] fGreenPartition;
        private int[][] fBluePartition;
        private int[][] fSummaPartition;
        //--------------------------------------------------------------------------------------
        public CColorPartion(Bitmap pImage)
        {
            fSourceImage = pImage;
            DefineColorPartition();
        }
        //--------------------------------------------------------------------------------------
        public void DefineColorPartition()
        {
            if (fSourceImage != null)
            {
                List<Color> lData = new List<Color>(fSourceImage.Height * fSourceImage.Width);
                for (int i = 0; i < fSourceImage.Width; i++)
                    for (int j = 0; j < fSourceImage.Height; j++)
                        lData.Add(fSourceImage.GetPixel(i, j));

                var queryGroupColorRed = from ColorVal in lData
                                         group ColorVal by ColorVal.R into ColorGroup
                                         orderby ColorGroup.Key
                                         select new
                                         {
                                             ColorLevel = ColorGroup.Key,
                                             ColorWeight = ColorGroup.Count()
                                         };
                var queryGroupColorGreen = from ColorVal in lData
                                           group ColorVal by ColorVal.G into ColorGroup
                                           orderby ColorGroup.Key
                                           select new
                                           {
                                               ColorLevel = ColorGroup.Key,
                                               ColorWeight = ColorGroup.Count()
                                           };
                var queryGroupColorBlue = from ColorVal in lData
                                          group ColorVal by ColorVal.B into ColorGroup
                                          orderby ColorGroup.Key
                                          select new
                                          {
                                              ColorLevel = ColorGroup.Key,
                                              ColorWeight = ColorGroup.Count()
                                          };
                var queryGroupColorSumma = from ColorVal in lData
                                           group ColorVal by (int)ColorVal.B + (int)ColorVal.G + (int)ColorVal.R into ColorGroup
                                          orderby ColorGroup.Key
                                          select new
                                          {
                                              ColorLevel = ColorGroup.Key,
                                              ColorWeight = ColorGroup.Count()
                                          };
                var lArrGroupColorRed = queryGroupColorRed.ToArray();
                var lArrGroupColorGreen = queryGroupColorGreen.ToArray();
                var lArrGroupColorBlue = queryGroupColorBlue.ToArray();
                var lArrGroupColorSumma = queryGroupColorSumma.ToArray();
                fRedPartition = new int[lArrGroupColorRed.Length][];
                fGreenPartition = new int[lArrGroupColorGreen.Length][];
                fBluePartition = new int[lArrGroupColorBlue.Length][];
                fSummaPartition = new int[lArrGroupColorSumma.Length][];
                int k = 0;
                foreach (var lColorPart in lArrGroupColorRed)
                {
                    fMainTextRed += lColorPart.ColorLevel.ToString() + ", ";
                    fAddTextRed += lColorPart.ColorLevel.ToString("D3") + " : " + lColorPart.ColorWeight.ToString() + Environment.NewLine;
                    fRedPartition[k++] = new int[] {lColorPart.ColorLevel, lColorPart.ColorWeight };
                }
                k = 0;
                foreach (var lColorPart in lArrGroupColorGreen)
                {
                    fMainTextGreen += lColorPart.ColorLevel.ToString() + ", ";
                    fAddTextGreen += lColorPart.ColorLevel.ToString("D3") + " : " + lColorPart.ColorWeight.ToString() + Environment.NewLine;
                    fGreenPartition[k++] = new int[] { lColorPart.ColorLevel, lColorPart.ColorWeight };
                }
                k = 0;
                foreach (var lColorPart in lArrGroupColorBlue)
                {
                    fMainTextBlue += lColorPart.ColorLevel.ToString() + ", ";
                    fAddTextBlue += lColorPart.ColorLevel.ToString("D3") + " : " + lColorPart.ColorWeight.ToString() + Environment.NewLine;
                    fBluePartition[k++] = new int[] { lColorPart.ColorLevel, lColorPart.ColorWeight };
                }
                k = 0;
                foreach (var lColorPart in lArrGroupColorSumma)
                {
                    fMainTextSumma += lColorPart.ColorLevel.ToString() + ", ";
                    fAddTextSumma += lColorPart.ColorLevel.ToString("D3") + " : " + lColorPart.ColorWeight.ToString() + Environment.NewLine;
                    fSummaPartition[k++] = new int[] { lColorPart.ColorLevel, lColorPart.ColorWeight };
                }
            }
        }
        //--------------------------------------------------------------------------------------
        public string MainTextRed
        {
            get
            {
                return fMainTextRed;
            }
        }
        //--------------------------------------------------------------------------------------
        public string AddTextRed
        {
            get
            {
                return fAddTextRed;
            }
        }
        //--------------------------------------------------------------------------------------
        public string MainTextGreen
        {
            get
            {
                return fMainTextGreen;
            }
        }
        //--------------------------------------------------------------------------------------
        public string AddTextGreen
        {
            get
            {
                return fAddTextGreen;
            }
        }
        //--------------------------------------------------------------------------------------
        public string MainTextBlue
        {
            get
            {
                return fMainTextBlue;
            }
        }
        //--------------------------------------------------------------------------------------
        public string AddTextBlue
        {
            get
            {
                return fAddTextBlue;
            }
        }
        //--------------------------------------------------------------------------------------
        public string MainTextSumma
        {
            get
            {
                return fMainTextSumma;
            }
        }
        //--------------------------------------------------------------------------------------
        public string AddTextSumma
        {
            get
            {
                return fAddTextSumma;
            }
        }
        //--------------------------------------------------------------------------------------
        public int[][] RedPartition
        {
            get
            {
                return fRedPartition;
            }
        }
        //--------------------------------------------------------------------------------------
        public int[][] GreenPartition
        {
            get
            {
                return fGreenPartition;
            }
        }
        //--------------------------------------------------------------------------------------
        public int[][] BluePartition
        {
            get
            {
                return fBluePartition;
            }
        }
        //--------------------------------------------------------------------------------------
        public int[][] SummaPartition
        {
            get
            {
                return fSummaPartition;
            }
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
