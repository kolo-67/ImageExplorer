using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageExplorer
{
    //--------------------------------------------------------------------------------------
    // class CBordersByColorForImage
    //--------------------------------------------------------------------------------------
    public class CBordersByColorForImage
    {
        private int fEstimateFor3DCounter;
        private int fEstimateFor3DCounterBlue;
        private int fEstimateFor3DCounterEnd;
        private Bitmap fSourceBitmap;
//        private Color[] fColorsOfVariant;
//        private string[] fTextOfColors;
        private CBlackWhiteExplorer fBlackWhiteExplorer;
        private int fTickStart;
        private int fTickCount;
        private DateTime fTimeStart;
        private TimeSpan fTimeCount;
        private List<int> fOrderDistinctRedList;
        private List<int> fOrderDistinctGreenList;
        private List<int> fOrderDistinctBlueList;
        private int fTopListCount = 0;
        private int fBottomListCount = 0;
        private double fTopRedSumma = 0.0;
        private double fTopGreenSumma = 0.0;
        private double fTopBlueSumma = 0.0;
        private double fBottomRedSumma = 0.0;
        private double fBottomGreenSumma = 0.0;
        private double fBottomBlueSumma = 0.0;
        private double fTopDevision;
        private double fBottomDevision;
        private double fTopDevisionSumma = 0.0;
        private double fBottomDevisionSumma = 0.0;
        private double fTopRedCentre = 0.0;
        private double fTopGreenCentre = 0.0;
        private double fTopBlueCentre = 0.0;
        private double fBottomRedCentre = 0.0;
        private double fBottomGreenCentre = 0.0;
        private double fBottomBlueCentre = 0.0;
        private int fBadPoint;
        private int fVeryBadPoint;
        private List<CBadPointData> fBadPointList;
        //--------------------------------------------------------------------------------------
        public CBordersByColorForImage(Bitmap pImage)
        {
            fBlackWhiteExplorer = new CBlackWhiteExplorer();
            fSourceBitmap = pImage;
            fBadPointList = new List<CBadPointData>();
        }
        //--------------------------------------------------------------------------------------
        public int[] ComputeBestBorders(Bitmap pImage)
        {
            int pSize = pImage.Width * pImage.Height;
            List<int> lListRed = new List<int>(pSize);
            List<int> lListGreen = new List<int>(pSize);
            List<int> lListBlue = new List<int>(pSize);
            for (int i = 0; i < pImage.Width; i++)
                for (int j = 0; j < pImage.Height; j++)
                {
                    Color lColor = pImage.GetPixel(i, j);
                    lListRed.Add(lColor.R);
                    lListGreen.Add(lColor.G);
                    lListBlue.Add(lColor.B);
                }

            int lBorderRed = ComputeBestBorder(lListRed);
            int lBorderGreen = ComputeBestBorder(lListGreen);
            int lBorderBlue = ComputeBestBorder(lListBlue);
            return new int[] { lBorderRed, lBorderGreen, lBorderBlue };
        }
        //--------------------------------------------------------------------------------------
        private int ComputeBestBorder(IList<int> pList)
        {
            int lCurrentBottom = 0;
            int lCurrentTop = 255;
            while (lCurrentTop - lCurrentBottom > 2)
            {
                int lStep = (lCurrentTop - lCurrentBottom) / 3;
                int lMiddleBottom = lCurrentBottom + lStep;
                int lMiddleTop = lCurrentTop - lStep;
                double[] lEstimateForBottom = EstimateForBorder(pList, lMiddleBottom, true);
                double[] lEstimateForTop = EstimateForBorder(pList, lMiddleTop, false);
                if ((lEstimateForBottom[0] < lEstimateForTop[0]) ||
                    (lEstimateForBottom[0] == lEstimateForTop[0] && lEstimateForBottom[1] < lEstimateForTop[1]))
                    lCurrentTop = lMiddleTop;
                else
                    lCurrentBottom = lMiddleBottom;
            }
            double[] lEstimateBetter = EstimateForBorder(pList, lCurrentBottom, true);
            int lBorderBetter = lCurrentBottom;
            for (int i = lCurrentBottom + 1; i <= lCurrentTop; i++)
            {
                double[] lNewBetter = EstimateForBorder(pList, i, true);
                if ((lNewBetter[0] < lEstimateBetter[0]) ||
                    (lNewBetter[0] == lEstimateBetter[0] && lNewBetter[1] < lEstimateBetter[1]))
                {
                    lBorderBetter = i;
                    lEstimateBetter = lNewBetter;
                }
            }

            return lBorderBetter;
        }
        //--------------------------------------------------------------------------------------
        private double[] EstimateForBorder(IList<int> pList, int pBorder, bool pIsBottom)
        {
            IEnumerable<int> lTopList = from n in pList
                                        where n >= pBorder
                                        select n;
            IEnumerable<int> lBottomList = from n in pList
                                           where n < pBorder
                                           select n;
            double lTopDevision = 256.0 - (pIsBottom ? 1 : 0);
            double lBottomDevision = 256.0 - (pIsBottom ? 0 : 1);
            if (lTopList.Count() > 0)
            {
                double lTopCentre = lTopList.Average(num => num);
                lTopDevision = lTopList.Average(num => Math.Abs(num - lTopCentre));
            }
            if (lBottomList.Count() > 0)
            {
                double lBottomCentre = lBottomList.Average();
                lBottomDevision = lBottomList.Average(num => Math.Abs(num - lBottomCentre));
            }
            return new double[] { Math.Max(lTopDevision, lBottomDevision), lTopDevision + lBottomDevision };
        }
        //--------------------------------------------------------------------------------------
        public int[] ComputeBest3DBorder(Bitmap pImage)
        {
            int pSize = pImage.Width * pImage.Height;
            List<Color> lList = new List<Color>(pSize);
            for (int i = 0; i < pImage.Width; i++)
                for (int j = 0; j < pImage.Height; j++)
                    lList.Add(pImage.GetPixel(i, j));

            int[] lBorder = ComputeBestBorderRed(lList);
            return lBorder;
        }
        //--------------------------------------------------------------------------------------
        private int[] ComputeBestBorderRed(IList<Color> pList)
        {
            int lGreenBorder = 0;
            int lBlueBorder = 0;
            int lCurrentBottom = 0;
            int lCurrentTop = 255;
            while (lCurrentTop - lCurrentBottom > 2)
            {
                int lStep = (lCurrentTop - lCurrentBottom) / 3;
                int lMiddleBottom = lCurrentBottom + lStep;
                int lMiddleTop = lCurrentTop - lStep;
                double[] lEstimateForBottom = ComputeBestBorderGreen(pList, lMiddleBottom, out lGreenBorder, out lBlueBorder, true);
                double[] lEstimateForTop = ComputeBestBorderGreen(pList, lMiddleTop, out lGreenBorder, out lBlueBorder, false);
                if ((lEstimateForBottom[0] < lEstimateForTop[0]) ||
                    (lEstimateForBottom[0] == lEstimateForTop[0] && lEstimateForBottom[1] < lEstimateForTop[1]))
                    lCurrentTop = lMiddleTop;
                else
                    lCurrentBottom = lMiddleBottom;
            }
            double[] lEstimateBetter = ComputeBestBorderGreen(pList, lCurrentBottom, out lGreenBorder, out lBlueBorder, true);
            int lBorderBetter = lCurrentBottom;
            for (int i = lCurrentBottom + 1; i <= lCurrentTop; i++)
            {
                double[] lNewBetter = ComputeBestBorderGreen(pList, i, out lGreenBorder, out lBlueBorder, true);
                if ((lNewBetter[0] < lEstimateBetter[0]) ||
                    (lNewBetter[0] == lEstimateBetter[0] && lNewBetter[1] < lEstimateBetter[1]))
                {
                    lBorderBetter = i;
                    lEstimateBetter = lNewBetter;
                }
            }

            return new int[] { lBorderBetter, lGreenBorder, lBlueBorder };
        }
        //--------------------------------------------------------------------------------------
        private double[] ComputeBestBorderGreen(IList<Color> pList, int pRedBorder, out int pGreenBorder, out int pBlueBorder, bool pIsRedBottom)
        {
            int lCurrentBottom = 0;
            int lCurrentTop = 255;
            int lBlueBorder = 0;
            fTimeStart = DateTime.Now;
            fEstimateFor3DCounter = 0;
            fTickStart = Environment.TickCount;
            while (lCurrentTop - lCurrentBottom > 2)
            {
                int lStep = (lCurrentTop - lCurrentBottom) / 3;
                int lMiddleBottom = lCurrentBottom + lStep;
                int lMiddleTop = lCurrentTop - lStep;
                double[] lEstimateForBottom = ComputeBestBorderBlue(pList, pRedBorder, lMiddleBottom, out lBlueBorder, pIsRedBottom, true);
                double[] lEstimateForTop = ComputeBestBorderBlue(pList, pRedBorder, lMiddleTop, out lBlueBorder, pIsRedBottom, false);
                if ((lEstimateForBottom[0] < lEstimateForTop[0]) ||
                    (lEstimateForBottom[0] == lEstimateForTop[0] && lEstimateForBottom[1] < lEstimateForTop[1]))
                    lCurrentTop = lMiddleTop;
                else
                    lCurrentBottom = lMiddleBottom;
            }
            double[] lEstimateBetter = ComputeBestBorderBlue(pList, pRedBorder, lCurrentBottom, out lBlueBorder, pIsRedBottom, true);
            int lBorderBetter = lCurrentBottom;
            for (int i = lCurrentBottom + 1; i <= lCurrentTop; i++)
            {
                double[] lNewBetter = ComputeBestBorderBlue(pList, pRedBorder, i, out lBlueBorder, pIsRedBottom, true);
                if ((lNewBetter[0] < lEstimateBetter[0]) ||
                    (lNewBetter[0] == lEstimateBetter[0] && lNewBetter[1] < lEstimateBetter[1]))
                {
                    lBorderBetter = i;
                    lEstimateBetter = lNewBetter;
                }
            }
            pGreenBorder = lBorderBetter;
            pBlueBorder = lBlueBorder;
            fTickCount = Environment.TickCount - fTickStart;
            fTimeCount = DateTime.Now - fTimeStart;
            double lFrequency = fEstimateFor3DCounter * 1000.0 / fTickCount;
            double lTimeOperation = ((double)fTickCount) / fEstimateFor3DCounter / 1000;
            return lEstimateBetter;
        }
        //--------------------------------------------------------------------------------------
        private double[] ComputeBestBorderBlue(IList<Color> pList, int pRedBorder, int pGreenBorder, out int pBlueBorder, bool pIsRedBottom, bool pIsGreenBottom)
        {
            fEstimateFor3DCounterBlue = 0;
            int lCurrentBottom = 0;
            int lCurrentTop = 255;
            while (lCurrentTop - lCurrentBottom > 2)
            {
                int lStep = (lCurrentTop - lCurrentBottom) / 3;
                int lMiddleBottom = lCurrentBottom + lStep;
                int lMiddleTop = lCurrentTop - lStep;
                double[] lEstimateForBottom = EstimateFor3DBorder(pList, pRedBorder, pGreenBorder, lMiddleBottom, pIsRedBottom, pIsGreenBottom, true);
                double[] lEstimateForTop = EstimateFor3DBorder(pList, pRedBorder, pGreenBorder, lMiddleTop, pIsRedBottom, pIsGreenBottom, false);
                if ((lEstimateForBottom[0] < lEstimateForTop[0]) ||
                    (lEstimateForBottom[0] == lEstimateForTop[0] && lEstimateForBottom[1] < lEstimateForTop[1]))
                    lCurrentTop = lMiddleTop;
                else
                    lCurrentBottom = lMiddleBottom;
            }
            double[] lEstimateBetter = EstimateFor3DBorder(pList, pRedBorder, pGreenBorder, lCurrentBottom, pIsRedBottom, pIsGreenBottom, true);
            int lBorderBetter = lCurrentBottom;
            for (int i = lCurrentBottom + 1; i <= lCurrentTop; i++)
            {
                double[] lNewBetter = EstimateFor3DBorder(pList, pRedBorder, pGreenBorder, i, pIsRedBottom, pIsGreenBottom, true);
                if ((lNewBetter[0] < lEstimateBetter[0]) ||
                    (lNewBetter[0] == lEstimateBetter[0] && lNewBetter[1] < lEstimateBetter[1]))
                {
                    lBorderBetter = i;
                    lEstimateBetter = lNewBetter;
                }
            }
            pBlueBorder = lBorderBetter;
            fTickCount = Environment.TickCount - fTickStart;
            fTimeCount = DateTime.Now - fTimeStart;
            return lEstimateBetter;
        }
        //--------------------------------------------------------------------------------------
        private double[] EstimateFor3DBorder(IList<Color> pList, int pRedBorder, int pGreenBorder, int pBlueBorder,
            bool pIsRedBottom, bool pIsGreenBottom, bool pIsBlueBottom)
        {
            fEstimateFor3DCounter++;
            fEstimateFor3DCounterBlue++;

            double lTopDevision = 256.0 - (pIsBlueBottom ? 1 : 0);
            double lBottomDevision = 256.0 - (pIsBlueBottom ? 0 : 1);

            int lTopListCount = 0;
            int lBottomListCount = 0;
            double lTopRedSumma = 0.0;
            double lTopGreenSumma = 0.0;
            double lTopBlueSumma = 0.0;
            double lBottomRedSumma = 0.0;
            double lBottomGreenSumma = 0.0;
            double lBottomBlueSumma = 0.0;
            foreach (Color c in pList)
            {
                if (c.R + c.G + c.B >= pRedBorder + pGreenBorder + pBlueBorder)
                {
                    lTopListCount++;
                    lTopRedSumma += c.R;
                    lTopGreenSumma += c.G;
                    lTopBlueSumma += c.B;
                }
                else
                {
                    lBottomListCount++;
                    lBottomRedSumma += c.R;
                    lBottomGreenSumma += c.G;
                    lBottomBlueSumma += c.B;
                }
            }
/*
            IEnumerable<Color> lTopList = from c in pList
                                          where c.R + c.G + c.B >=
                                          pRedBorder + pGreenBorder + pBlueBorder
                                          select c;
            IEnumerable<Color> lBottomList = from c in pList
                                             where c.R + c.G + c.B <
                                             pRedBorder + pGreenBorder + pBlueBorder
                                             select c;
*/
            double lTopRedCentre = 0.0;
            double lTopGreenCentre = 0.0;
            double lTopBlueCentre = 0.0;
            if (lTopListCount > 0)
            {
                lTopRedCentre = lTopRedSumma/lTopListCount;
                lTopGreenCentre = lTopGreenSumma / lTopListCount;
                lTopBlueCentre = lTopBlueSumma / lTopListCount;
            }
            double lBottomRedCentre = 0.0;
            double lBottomGreenCentre = 0.0;
            double lBottomBlueCentre = 0.0;
            if (lBottomListCount > 0)
            {
                lBottomRedCentre = lBottomRedSumma / lBottomListCount;
                lBottomGreenCentre = lBottomGreenSumma / lBottomListCount;
                lBottomBlueCentre = lBottomBlueSumma / lBottomListCount;
            }

            double lTopDevisionSumma = 0.0;
            double lBottomDevisionSumma = 0.0;
            foreach (Color c in pList)
            {
                if (c.R + c.G + c.B >= pRedBorder + pGreenBorder + pBlueBorder)
                {
                    lTopDevisionSumma = +Math.Sqrt(
                        Math.Pow((lTopRedCentre - c.R), 2.0) +
                        Math.Pow((lTopGreenCentre - c.G), 2.0) +
                        Math.Pow((lTopBlueCentre - c.B), 2.0));
                }
                else
                {
                    lBottomDevisionSumma += Math.Sqrt(
                        Math.Pow((lBottomRedCentre - c.R), 2.0) +
                        Math.Pow((lBottomGreenCentre - c.G), 2.0) +
                        Math.Pow((lBottomBlueCentre - c.B), 2.0));
                }
            }

            lTopDevision = lTopDevisionSumma / lTopListCount;
            lBottomDevision = lBottomDevisionSumma / lBottomListCount;
            return new double[] { Math.Max(lTopDevision, lBottomDevision), lTopDevision + lBottomDevision };
        }
        //--------------------------------------------------------------------------------------
        private double[] EstimateFor3DBorderLynx(IList<Color> pList, int pRedBorder, int pGreenBorder, int pBlueBorder,
            bool pIsRedBottom, bool pIsGreenBottom, bool pIsBlueBottom)
        {
            fEstimateFor3DCounter++;
            fEstimateFor3DCounterBlue++;
            IEnumerable<Color> lTopList = from c in pList
                                          where c.R + c.G + c.B >=
                                          pRedBorder + pGreenBorder + pBlueBorder
                                          select c;
            IEnumerable<Color> lBottomList = from c in pList
                                             where c.R + c.G + c.B <
                                             pRedBorder + pGreenBorder + pBlueBorder
                                             select c;
            double lTopDevision = 256.0 - (pIsBlueBottom ? 1 : 0);
            double lBottomDevision = 256.0 - (pIsBlueBottom ? 0 : 1);

            if (lTopList.Count() > 0)
            {
                double lTopRedCentre = lTopList.Average(c => c.R);
                double lTopGreenCentre = lTopList.Average(c => c.G);
                double lTopBlueCentre = lTopList.Average(c => c.B);
                var lTopCentre = new
                {
                    Red = lTopRedCentre,
                    Green = lTopGreenCentre,
                    Blue = lTopBlueCentre
                };
                lTopDevision = lTopList.Average(c => Math.Sqrt(
                    Math.Pow((lTopCentre.Red - c.R), 2.0) +
                    Math.Pow((lTopCentre.Green - c.G), 2.0) +
                    Math.Pow((lTopCentre.Blue - c.B), 2.0)
                    ));
            }
            if (lBottomList.Count() > 0)
            {
                double lBottomRedCentre = lBottomList.Average(c => c.R);
                double lBottomGreenCentre = lBottomList.Average(c => c.G);
                double lBottomBlueCentre = lBottomList.Average(c => c.B);
                var lBottomCentre = new
                {
                    Red = lBottomRedCentre,
                    Green = lBottomGreenCentre,
                    Blue = lBottomBlueCentre
                };
                lBottomDevision = lBottomList.Average(c => Math.Sqrt(
                    Math.Pow((lBottomCentre.Red - c.R), 2.0) +
                    Math.Pow((lBottomCentre.Green - c.G), 2.0) +
                    Math.Pow((lBottomCentre.Blue - c.B), 2.0)
                    ));
            }
            return new double[] { Math.Max(lTopDevision, lBottomDevision), lTopDevision + lBottomDevision };
        }
        //--------------------------------------------------------------------------------------
        public int[] ComputeBest3DBorderGroup(Bitmap pImage)
        {

            List<CColorWeight> lListColorPoint = DefineListColorPoint(pImage);

            int[] lBorder = ComputeBestBorderRedGroup(lListColorPoint);
            return lBorder;
        }
        //--------------------------------------------------------------------------------------
        public void Explore3DBorderGroup(Bitmap pImage, int pRedBorderInd, int pGreenBorderInd, int pBlueBorderInd)
        {

            List<CColorWeight> lListColorPoint = DefineListColorPoint(pImage);

            double[] lBorder = EstimateFor3DBorderGroup(lListColorPoint, pRedBorderInd, pGreenBorderInd, pBlueBorderInd,
            true, true, true);

            fBadPoint = 0;
            fVeryBadPoint = 0;
            fBadPointList.Clear();
            foreach (CColorWeight c in lListColorPoint)
            {
                int dif = 0;
                if (c.ColorPoint.R + c.ColorPoint.G + c.ColorPoint.B >= fOrderDistinctRedList[pRedBorderInd] + fOrderDistinctGreenList[pGreenBorderInd] + fOrderDistinctBlueList[pBlueBorderInd])
                {
                    if (c.ColorPoint.R < fOrderDistinctRedList[pRedBorderInd])
                        dif++;
                    if (c.ColorPoint.G < fOrderDistinctGreenList[pGreenBorderInd])
                        dif++;
                    if (c.ColorPoint.B < fOrderDistinctBlueList[pBlueBorderInd])
                        dif++;
                }
                else
                {
                    if (c.ColorPoint.R >= fOrderDistinctRedList[pRedBorderInd])
                        dif++;
                    if (c.ColorPoint.G >= fOrderDistinctGreenList[pGreenBorderInd])
                        dif++;
                    if (c.ColorPoint.B >= fOrderDistinctBlueList[pBlueBorderInd])
                        dif++;
                }
                if (dif > 0)
                {
                    fBadPoint += c.ColorWeight;
                    fBadPointList.Add(new CBadPointData(c.ColorPoint, dif, c.ColorWeight));
                }
                if (dif > 1)
                    fVeryBadPoint += c.ColorWeight;

            }


        }
        //--------------------------------------------------------------------------------------
        private List<CColorWeight> DefineListColorPoint(Bitmap pImage)
        {
            int pSize = pImage.Width * pImage.Height;

            List<Color> lList = new List<Color>(pSize);
            for (int i = 0; i < pImage.Width; i++)
                for (int j = 0; j < pImage.Height; j++)
                    lList.Add(pImage.GetPixel(i, j));

            List<CColorWeight> lListColorPoint = (from c in lList
                                                  group c by c into cg
                                                  select new CColorWeight(cg.Key, cg.Count())).ToList<CColorWeight>();

            fOrderDistinctRedList = (from g in lListColorPoint
                                     group g by g.ColorPoint.R into cg
                                     orderby cg.Key
                                     select (int)cg.Key).ToList();
            fOrderDistinctGreenList = (from g in lListColorPoint
                                       group g by g.ColorPoint.G into cg
                                       orderby cg.Key
                                       select (int)cg.Key).ToList();
            fOrderDistinctBlueList = (from g in lListColorPoint
                                      group g by g.ColorPoint.B into cg
                                      orderby cg.Key
                                      select (int)cg.Key).ToList();
            return lListColorPoint;
        }
        //--------------------------------------------------------------------------------------
        private int[] ComputeBestBorderRedGroup(IList<CColorWeight> pList)
        {
            int lGreenBorder = 0;
            int lBlueBorder = 0;
            int lGreenBorderTry = 0;
            int lBlueBorderTry = 0;
            int lCurrentBottomInd = 1;
            int lCurrentTopInd = fOrderDistinctRedList.Count-1;
            while (lCurrentTopInd - lCurrentBottomInd > 2)
            {
                int lStep = (lCurrentTopInd - lCurrentBottomInd) / 3;
                int lMiddleBottomInd = lCurrentBottomInd + lStep;
                int lMiddleTopInd = lCurrentTopInd - lStep;
                double[] lEstimateForBottom = ComputeBestBorderGreenGroup(pList, lMiddleBottomInd, out lGreenBorder, out lBlueBorder, true);
                double[] lEstimateForTop = ComputeBestBorderGreenGroup(pList, lMiddleTopInd, out lGreenBorder, out lBlueBorder, false);
                if ((lEstimateForBottom[0] < lEstimateForTop[0]) ||
                    (lEstimateForBottom[0] == lEstimateForTop[0] && lEstimateForBottom[1] < lEstimateForTop[1]))
                    lCurrentTopInd = lMiddleTopInd;
                else
                    lCurrentBottomInd = lMiddleBottomInd;
            }
            double[] lEstimateBetter = ComputeBestBorderGreenGroup(pList, lCurrentBottomInd, out lGreenBorder, out lBlueBorder, true);
            int lBorderBetter = lCurrentBottomInd;
            for (int i = lCurrentBottomInd + 1; i <= lCurrentTopInd; i++)
            {
                double[] lNewBetter = ComputeBestBorderGreenGroup(pList, i, out lGreenBorderTry, out lBlueBorderTry, true);
                if ((lNewBetter[0] < lEstimateBetter[0]) ||
                    (lNewBetter[0] == lEstimateBetter[0] && lNewBetter[1] < lEstimateBetter[1]))
                {
                    lBorderBetter = i;
                    lEstimateBetter = lNewBetter;
                    lGreenBorder = lGreenBorderTry;
                    lBlueBorder = lBlueBorderTry;
                }
            }

            return new int[] { fOrderDistinctRedList[lBorderBetter], lGreenBorder, lBlueBorder };
        }
        //--------------------------------------------------------------------------------------
        private double[] ComputeBestBorderGreenGroup(IList<CColorWeight> pList, int pRedBorderInd, out int pGreenBorder, out int pBlueBorder, bool pIsRedBottom)
        {
            int lCurrentBottomInd = 1;
            int lCurrentTopInd = fOrderDistinctGreenList.Count-1;
            int lBlueBorder = 0;
            int lBlueBorderTry = 0;
            fTimeStart = DateTime.Now;
            fEstimateFor3DCounter = 0;
            fTickStart = Environment.TickCount;
            while (lCurrentTopInd - lCurrentBottomInd > 2)
            {
                int lStep = (lCurrentTopInd - lCurrentBottomInd) / 3;
                int lMiddleBottomInd = lCurrentBottomInd + lStep;
                int lMiddleTopInd = lCurrentTopInd - lStep;
                double[] lEstimateForBottom = ComputeBestBorderBlueGroup(pList, pRedBorderInd, lMiddleBottomInd, out lBlueBorder, pIsRedBottom, true);
                double[] lEstimateForTop = ComputeBestBorderBlueGroup(pList, pRedBorderInd, lMiddleTopInd, out lBlueBorder, pIsRedBottom, false);
                if ((lEstimateForBottom[0] < lEstimateForTop[0]) ||
                    (lEstimateForBottom[0] == lEstimateForTop[0] && lEstimateForBottom[1] < lEstimateForTop[1]))
                    lCurrentTopInd = lMiddleTopInd;
                else
                    lCurrentBottomInd = lMiddleBottomInd;
            }
            double[] lEstimateBetter = ComputeBestBorderBlueGroup(pList, pRedBorderInd, lCurrentBottomInd, out lBlueBorder, pIsRedBottom, true);
            int lBorderBetter = lCurrentBottomInd;
            for (int i = lCurrentBottomInd + 1; i <= lCurrentTopInd; i++)
            {
                double[] lNewBetter = ComputeBestBorderBlueGroup(pList, pRedBorderInd, i, out lBlueBorderTry, pIsRedBottom, true);
                if ((lNewBetter[0] < lEstimateBetter[0]) ||
                    (lNewBetter[0] == lEstimateBetter[0] && lNewBetter[1] < lEstimateBetter[1]))
                {
                    lBorderBetter = i;
                    lEstimateBetter = lNewBetter;
                    lBlueBorder = lBlueBorderTry;
                }
            }
            pGreenBorder = fOrderDistinctGreenList[lBorderBetter];
            pBlueBorder = lBlueBorder;
            fTickCount = Environment.TickCount - fTickStart;
            fTimeCount = DateTime.Now - fTimeStart;
            double lFrequency = fEstimateFor3DCounter * 1000.0 / fTickCount;
            double lTimeOperation = ((double)fTickCount) / fEstimateFor3DCounter / 1000;
            return lEstimateBetter;
        }
        //--------------------------------------------------------------------------------------
        private double[] ComputeBestBorderBlueGroup(IList<CColorWeight> pList, int pRedBorderInd, int pGreenBorderInd, out int pBlueBorder, bool pIsRedBottom, bool pIsGreenBottom)
        {
            fEstimateFor3DCounterBlue = 0;
            int lCurrentBottomInd = 1;
            int lCurrentTopInd = fOrderDistinctBlueList.Count-1;
            double[] lEstimateForBottom = null;
            double[] lEstimateForTop = null;
            while (lCurrentTopInd - lCurrentBottomInd > 2)
            {
                int lStep = (lCurrentTopInd - lCurrentBottomInd) / 3;
                int lMiddleBottomInd = lCurrentBottomInd + lStep;
                int lMiddleTopInd = lCurrentTopInd - lStep;
//                if ( lEstimateForBottom == null )
                    lEstimateForBottom = EstimateFor3DBorderGroup(pList, pRedBorderInd, pGreenBorderInd, lMiddleBottomInd, pIsRedBottom, pIsGreenBottom, true);
//                if (lEstimateForTop == null)
                    lEstimateForTop = EstimateFor3DBorderGroup(pList, pRedBorderInd, pGreenBorderInd, lMiddleTopInd, pIsRedBottom, pIsGreenBottom, false);
                if ((lEstimateForBottom[0] < lEstimateForTop[0]) ||
                    (lEstimateForBottom[0] == lEstimateForTop[0] && lEstimateForBottom[1] < lEstimateForTop[1]))
                    lCurrentTopInd = lMiddleTopInd;
                else
                    lCurrentBottomInd = lMiddleBottomInd;
            }
            double[] lEstimateBetter = EstimateFor3DBorderGroup(pList, pRedBorderInd, pGreenBorderInd, lCurrentBottomInd, pIsRedBottom, pIsGreenBottom, true);
            int lBorderBetter = lCurrentBottomInd;
            for (int i = lCurrentBottomInd + 1; i <= lCurrentTopInd; i++)
            {
                double[] lNewBetter = EstimateFor3DBorderGroup(pList, pRedBorderInd, pGreenBorderInd, i, pIsRedBottom, pIsGreenBottom, true);
                if ((lNewBetter[0] < lEstimateBetter[0]) ||
                    (lNewBetter[0] == lEstimateBetter[0] && lNewBetter[1] < lEstimateBetter[1]))
                {
                    lBorderBetter = i;
                    lEstimateBetter = lNewBetter;
                }
            }
            pBlueBorder = fOrderDistinctBlueList[lBorderBetter];
            fTickCount = Environment.TickCount - fTickStart;
            fTimeCount = DateTime.Now - fTimeStart;
            return lEstimateBetter;
        }
        //--------------------------------------------------------------------------------------
        private double[] EstimateFor3DBorderGroup(IList<CColorWeight> pList, int pRedBorderInd, int pGreenBorderInd, int pBlueBorderInd,
            bool pIsRedBottom, bool pIsGreenBottom, bool pIsBlueBottom)
        {
            fEstimateFor3DCounter++;
            fEstimateFor3DCounterBlue++;

            fTopDevision = 256.0 - (pIsBlueBottom ? 1 : 0);
            fBottomDevision = 256.0 - (pIsBlueBottom ? 0 : 1);

            fTopListCount = 0;          // количество точек сверху от раделителя
            fBottomListCount = 0;       // количество точек снизу от раделителя
            fTopRedSumma = 0.0;         // взвешенная сумма красной коордтнаты точек сверху
            fTopGreenSumma = 0.0;       // взвешенная сумма зеленой коордтнаты точек сверху
            fTopBlueSumma = 0.0;        // взвешенная сумма синей коордтнаты точек сверху
            fBottomRedSumma = 0.0;      // взвешенная сумма красной коордтнаты точек снизу
            fBottomGreenSumma = 0.0;    // взвешенная сумма зеленой коордтнаты точек снизу
            fBottomBlueSumma = 0.0;     // взвешенная сумма синей коордтнаты точек снизу
            fBadPoint = 0;              // количество точек имеющих несовпадение между общим делением
                                        // на верхние и нижние и делением для отдельных цветов
            fVeryBadPoint = 0;          // количество точек имеющих 2 несовпадения
            foreach (CColorWeight c in pList)
            {
                int dif = 0;
                if (c.ColorPoint.R + c.ColorPoint.G + c.ColorPoint.B >= fOrderDistinctRedList[pRedBorderInd] + fOrderDistinctGreenList[pGreenBorderInd] + fOrderDistinctBlueList[pBlueBorderInd])
                {
                    fTopListCount += c.ColorWeight;
                    fTopRedSumma += c.ColorPoint.R * c.ColorWeight;
                    fTopGreenSumma += c.ColorPoint.G * c.ColorWeight;
                    fTopBlueSumma += c.ColorPoint.B * c.ColorWeight;
                    if (c.ColorPoint.R < fOrderDistinctRedList[pRedBorderInd])
                        dif++;
                    if (c.ColorPoint.G < fOrderDistinctGreenList[pGreenBorderInd])
                        dif++;
                    if (c.ColorPoint.B < fOrderDistinctBlueList[pBlueBorderInd])
                        dif++;
                }
                else
                {
                    fBottomListCount += c.ColorWeight;
                    fBottomRedSumma += c.ColorPoint.R * c.ColorWeight;
                    fBottomGreenSumma += c.ColorPoint.G * c.ColorWeight;
                    fBottomBlueSumma += c.ColorPoint.B * c.ColorWeight;
                    if (c.ColorPoint.R >= fOrderDistinctRedList[pRedBorderInd])
                        dif++;
                    if (c.ColorPoint.G >= fOrderDistinctGreenList[pGreenBorderInd])
                        dif++;
                    if (c.ColorPoint.B >= fOrderDistinctBlueList[pBlueBorderInd])
                        dif++;
                }
                if (dif > 0)
                    fBadPoint += c.ColorWeight;
                if (dif > 1)
                    fVeryBadPoint += c.ColorWeight;
            }


            // определить центр верхней группы
            fTopRedCentre = 0.0;
            fTopGreenCentre = 0.0;
            fTopBlueCentre = 0.0;
            if (fTopListCount > 0)
            {
                fTopRedCentre = fTopRedSumma / fTopListCount;
                fTopGreenCentre = fTopGreenSumma / fTopListCount;
                fTopBlueCentre = fTopBlueSumma / fTopListCount;
            }
            else
            {
                MessageBox.Show("Не одной точки в верхней части");                
            }

            // определить центр нижней группы
            fBottomRedCentre = 0.0;
            fBottomGreenCentre = 0.0;
            fBottomBlueCentre = 0.0;
            if (fBottomListCount > 0)
            {
                fBottomRedCentre = fBottomRedSumma / fBottomListCount;
                fBottomGreenCentre = fBottomGreenSumma / fBottomListCount;
                fBottomBlueCentre = fBottomBlueSumma / fBottomListCount;
            }
            else
            {
                MessageBox.Show("Не одной точки в нижней части");
            }

            fTopDevisionSumma = 0.0;
            fBottomDevisionSumma = 0.0;
            foreach (CColorWeight c in pList)
            {
                if (c.ColorPoint.R + c.ColorPoint.G + c.ColorPoint.B >= fOrderDistinctRedList[pRedBorderInd] + fOrderDistinctGreenList[pGreenBorderInd] + fOrderDistinctBlueList[pBlueBorderInd])
                {
                    fTopDevisionSumma += Math.Sqrt(
                        Math.Pow(Math.Abs(fTopRedCentre - c.ColorPoint.R), 2.0) +
                        Math.Pow(Math.Abs(fTopGreenCentre - c.ColorPoint.G), 2.0) +
                        Math.Pow(Math.Abs(fTopBlueCentre - c.ColorPoint.B), 2.0)) * c.ColorWeight;
                }
                else
                {
                    fBottomDevisionSumma += Math.Sqrt(
                        Math.Pow(Math.Abs(fBottomRedCentre - c.ColorPoint.R), 2.0) +
                        Math.Pow(Math.Abs(fBottomGreenCentre - c.ColorPoint.G), 2.0) +
                        Math.Pow(Math.Abs(fBottomBlueCentre - c.ColorPoint.B), 2.0)) * c.ColorWeight;
                }
            }

            fTopDevision = fTopDevisionSumma / fTopListCount;
            fBottomDevision = fBottomDevisionSumma / fBottomListCount;
            return new double[] { Math.Max(fTopDevision, fBottomDevision), fBadPoint + fVeryBadPoint };
//            return new double[] { fVeryBadPoint, fBadPoint };
            //            return new double[] { Math.Max(fTopDevision, fBottomDevision), fTopDevision + fBottomDevision };
        }
        //--------------------------------------------------------------------------------------
        public int TopListCount
        {
            get
            {
                return fTopListCount;
            }
        }
        //--------------------------------------------------------------------------------------
        public int BottomListCount
        {
            get
            {
                return fBottomListCount;
            }
        }
        //--------------------------------------------------------------------------------------
        public double TopRedSumma
        {
            get
            {
                return fTopRedSumma;
            }
        }
        //--------------------------------------------------------------------------------------
        public double TopGreenSumma
        {
            get
            {
                return fTopGreenSumma;
            }
        }
        //--------------------------------------------------------------------------------------
        public double TopBlueSumma
        {
            get
            {
                return fTopBlueSumma;
            }
        }
        //--------------------------------------------------------------------------------------
        public double BottomRedSumma
        {
            get
            {
                return fBottomRedSumma;
            }
        }
        //--------------------------------------------------------------------------------------
        public double BottomGreenSumma
        {
            get
            {
                return fBottomGreenSumma;
            }
        }
        //--------------------------------------------------------------------------------------
        public double BottomBlueSumma
        {
            get
            {
                return fBottomBlueSumma;
            }
        }
        //--------------------------------------------------------------------------------------
        public double TopDevision
        {
            get
            {
                return Math.Round( fTopDevision, 2);
            }
        }
        //--------------------------------------------------------------------------------------
        public double BottomDevision
        {
            get
            {
                return Math.Round( fBottomDevision, 2);
            }
        }
        //--------------------------------------------------------------------------------------
        public double TopDevisionSumma
        {
            get
            {
                return Math.Round( fTopDevisionSumma, 2);
            }
        }
        //--------------------------------------------------------------------------------------
        public double BottomDevisionSumma
        {
            get
            {
                return Math.Round( fBottomDevisionSumma, 2);
            }
        }
        //--------------------------------------------------------------------------------------
        public double TopRedCentre
        {
            get
            {
                return Math.Round( fTopRedCentre, 2);
            }
        }
        //--------------------------------------------------------------------------------------
        public double TopGreenCentre
        {
            get
            {
                return Math.Round( fTopGreenCentre, 2);
            }
        }
        //--------------------------------------------------------------------------------------
        public double TopBlueCentre
        {
            get
            {
                return Math.Round( fTopBlueCentre, 2);
            }
        }
        //--------------------------------------------------------------------------------------
        public double BottomRedCentre
        {
            get
            {
                return Math.Round( fBottomRedCentre, 2);
            }
        }
        //--------------------------------------------------------------------------------------
        public double BottomGreenCentre
        {
            get
            {
                return Math.Round( fBottomGreenCentre,2);
            }
        }
        //--------------------------------------------------------------------------------------
        public double BottomBlueCentre
        {
            get
            {
                return Math.Round( fBottomBlueCentre, 2);
            }
        }
        //--------------------------------------------------------------------------------------
        public int BadPoint
        {
            get
            {
                return fBadPoint;
            }
        }
        //--------------------------------------------------------------------------------------
        public int VeryBadPoint
        {
            get
            {
                return fVeryBadPoint;
            }
        }
        //--------------------------------------------------------------------------------------
        public List<CBadPointData> BadPointList
        {
            get
            {
                return fBadPointList;
            }
        }
        //--------------------------------------------------------------------------------------
        // class CColorWeight
        //--------------------------------------------------------------------------------------
        private class CColorWeight
        {
            private Color fColorPoint;
            private int fColorWeight;
            //--------------------------------------------------------------------------------------
            public CColorWeight(Color pColorPoint, int pColorWeight)
            {
                fColorPoint = pColorPoint;
                fColorWeight = pColorWeight;
            }
            //--------------------------------------------------------------------------------------
            public Color ColorPoint
            {
                get
                {
                    return fColorPoint;
                }
            }
            //--------------------------------------------------------------------------------------
            public int ColorWeight
            {
                get
                {
                    return fColorWeight;
                }
            }
            //--------------------------------------------------------------------------------------
        }
        //--------------------------------------------------------------------------------------
        public struct CBadPointData
        {
            private Color fPoint;
            private int fLevel;
            private int fWeight;
            //--------------------------------------------------------------------------------------
            public CBadPointData( Color pPoint,int pLevel,int pWeight)
            {
            fPoint = pPoint;
            fLevel = pLevel;
            fWeight = pWeight;
            }
            //--------------------------------------------------------------------------------------
            public Color Point
            {
                get
                {
                    return fPoint;
                }
            }
            //--------------------------------------------------------------------------------------
            public int Level
            {
                get
                {
                    return fLevel;
                }
            }
            //--------------------------------------------------------------------------------------
            public int Weight
            {
                get
                {
                    return fWeight;
                }
            }
            //--------------------------------------------------------------------------------------
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
