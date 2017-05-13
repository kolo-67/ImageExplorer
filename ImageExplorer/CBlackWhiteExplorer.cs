using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageExplorer
{
    //--------------------------------------------------------------------------------------
    // class CBlackWhiteExplorer
    //--------------------------------------------------------------------------------------
    public enum TypeDivisionEnum : byte { Simple = 0, ByWeight, ByDeviation, ByWeightDeviation };
    public class CBlackWhiteExplorer
    {
        private Bitmap fPicture;
        private Bitmap fOutPicture = null;
        private const short DeltaForIteration = 3;
        private int[] fRedCentres = null;
        private int[] fGreenCentres = null;
        private int[] fBlueCentres = null;
        private CBordersByColorForImage fBordersByColorForImage;
        private static readonly double RationLimit;
        private static readonly double WeightA0;
        private static readonly double WeightA1;
        private static readonly double WeightB0;
        private static readonly double WeightB1;
        private static readonly double WeightB2;
        //--------------------------------------------------------------------------------------
        public CBlackWhiteExplorer()
        {
        }
        //--------------------------------------------------------------------------------------
        static CBlackWhiteExplorer()
        {
            WeightA0 = 1.0;
            WeightA1 = 1.0/Math.Sqrt(2.0);
            WeightB0 = 0.5;
            WeightB1 = 1.0/Math.Sqrt(5.0);
            WeightB2 = 1.0 / Math.Sqrt(8.0);
            RationLimit = 0.26;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// определить центры для данного цветов для групировки в 2 цвета 
        /// </summary>
        /// <param name="pTypeDevision"> тип группировки</param>
        /// <param name="pColorArray">массив значений для данного цвета</param>
        /// <returns></returns>
        private int[] DefineColorCentres(TypeDivisionEnum pTypeDevision, int[] pColorArray)
        {
            short lBorder = 128;


            short lTopCentre = 255;
            short lBottomCentre = 0;
            short lOldTopCentre = 255;
            short lOldBottomCentre = 0;
            long lTopWeight = 0;
            long lBottomWeight = 0;
            long lTopDevision = 0;
            long lBottomDevision = 0;

            try
            {

                for (int i = 0; i < 30; i++)
                {
                    var lTopQuery = from c in pColorArray
                                    where c > lBorder
                                    select c;
                    var lBottomQuery = from c in pColorArray
                                       where c <= lBorder
                                       select c;

                    lTopWeight = Convert.ToInt16(lTopQuery.Count());
                    lBottomWeight = Convert.ToInt16(lBottomQuery.Count());
                    if (lTopWeight > 0)
                    {
                        lTopCentre = Convert.ToInt16(lTopQuery.Average());
                        lTopDevision = Convert.ToInt16(lTopQuery.Average(num => Math.Abs(num - lTopCentre)));
                    }
                    if (lBottomWeight > 0)
                    {
                        lBottomCentre = Convert.ToInt16(lBottomQuery.Average());
                        lBottomDevision = Convert.ToInt16(lBottomQuery.Average(num => Math.Abs(num - lBottomCentre)));
                    }
                    if (lTopWeight == 0)
                    {
                        lTopCentre = Convert.ToInt16((lBorder + lBottomCentre) / 2);
                        lTopDevision = 1;
                    }
                    if (lBottomWeight == 0)
                    {
                        lBottomCentre = Convert.ToInt16((lBorder + lTopCentre) / 2);
                        lBottomDevision = 1;
                    }

                    if (Math.Abs(lOldTopCentre - lTopCentre) < DeltaForIteration &&
                        Math.Abs(lOldBottomCentre - lBottomCentre) < DeltaForIteration)
                        break;

                    switch (pTypeDevision)
                    {
                        case TypeDivisionEnum.Simple:
                            lBorder = (short)((lTopCentre + lBottomCentre) * 0.5);
                            break;
                        case TypeDivisionEnum.ByWeight:
                            lBorder = (short)(lBottomCentre + (lTopCentre - lBottomCentre) *
                                lBottomWeight / (lBottomWeight + lTopWeight));
                            break;
                        case TypeDivisionEnum.ByDeviation:
                            lBorder = (short)(lBottomCentre + (lTopCentre - lBottomCentre) *
                                lBottomDevision / (lBottomDevision + lTopDevision));
                            break;
                        case TypeDivisionEnum.ByWeightDeviation:
                            lBorder = (short)(lBottomCentre + (lTopCentre - lBottomCentre) *
                                lBottomWeight * lBottomDevision / (lBottomWeight * lBottomDevision + lTopWeight * lTopDevision));
                            break;
                    }


                    lOldTopCentre = lTopCentre;
                    lOldBottomCentre = lBottomCentre;

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            return new int[] { lBottomCentre, lTopCentre, lBorder };
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// определить центры для цветов для групировки в 2 цвета 
        /// по каждому состовляющему цвету
        /// </summary>
        /// <param name="pBmp">картинка для каждого цвета которой производится группировка</param>
        /// <param name="pTypeDevision">тип группировки</param>
        /// <returns></returns>
        public int[][] DefineCentres(Bitmap pBmp, TypeDivisionEnum pTypeDevision)
        {
            fPicture = pBmp;
            fOutPicture = new Bitmap(pBmp.Width, pBmp.Height);
            try
            {
                int lComLengthOfPicture = fPicture.Width * fPicture.Height;
                int[] lRedArray = new int[lComLengthOfPicture];
                int[] lGreenArray = new int[lComLengthOfPicture];
                int[] lBlueArray = new int[lComLengthOfPicture];
                int k = 0;
                for (int i = 0; i < fPicture.Width; i++)
                    for (int j = 0; j < fPicture.Height; j++)
                    {
                        Color lPixel = fPicture.GetPixel(i, j);
                        lRedArray[k] = lPixel.R;
                        lGreenArray[k] = lPixel.G;
                        lBlueArray[k] = lPixel.B;
                        k++;

                    }

                fRedCentres = DefineColorCentres(pTypeDevision, lRedArray);
                fGreenCentres = DefineColorCentres(pTypeDevision, lGreenArray);
                fBlueCentres = DefineColorCentres(pTypeDevision, lBlueArray);

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            return new int[][] { fRedCentres, fGreenCentres, fBlueCentres };
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать картинку в черно-белую без оттенков
        /// </summary>
        /// <param name="pBmp">преобразуемая картинка</param>
        /// <param name="pNmbColor">цвет принимаемы за основной 
        /// по которому производится преобразование
        /// остальные цвета игнорируются</param>
        /// <returns></returns>
        public Bitmap PictureToBlackWhite(Bitmap pBmp, int pNmbColor)
        {
            try
            {
                fBordersByColorForImage = new CBordersByColorForImage(pBmp);
                int[] lBestBorder = fBordersByColorForImage.ComputeBestBorders(pBmp);
                if (fOutPicture == null)
                    fOutPicture = new Bitmap(pBmp.Width, pBmp.Height);

                for (int i = 0; i < fPicture.Width; i++)
                    for (int j = 0; j < fPicture.Height; j++)
                    {
                        Color lPixel = fPicture.GetPixel(i, j);

                        byte lComValue = 0;
                        byte lInValue = pNmbColor == 1 ? lPixel.R : (pNmbColor==2 ? lPixel.G : lPixel.B);

                        if (lInValue <= lBestBorder[pNmbColor - 1])
                            lComValue = 0;
                        else
                            lComValue = 255;

                        Color lNewPixel = Color.FromArgb(lComValue, lComValue, lComValue);
                        fOutPicture.SetPixel(i, j, lNewPixel);

                    }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            return fOutPicture;
        }
        /*
        public Bitmap PictureToBlackWhite(Bitmap pBmp, int pNmbColor)
        {
            try
            {
                if (fOutPicture == null)
                    fOutPicture = new Bitmap(pBmp.Width, pBmp.Height);
                if (fRedCentres == null)
                    return null;
                for (int i = 0; i < fPicture.Width; i++)
                    for (int j = 0; j < fPicture.Height; j++)
                    {
                        Color lPixel = fPicture.GetPixel(i, j);

                        byte lComValue = 0;

                        switch (pNmbColor)
                        {
                            case 1:
                                if (lPixel.R <= fRedCentres[2])
                                    lComValue = 255;
                                else
                                    lComValue = 0;
                                break;
                            case 2:
                                if (lPixel.G <= fGreenCentres[2])
                                    lComValue = 255;
                                else
                                    lComValue = 0;
                                break;
                            case 3:
                                if (lPixel.B <= fBlueCentres[2])
                                    lComValue = 255;
                                else
                                    lComValue = 0;
                                break;
                        }


                        Color lNewPixel = Color.FromArgb(lComValue, lComValue, lComValue);
                        fOutPicture.SetPixel(i, j, lNewPixel);

                    }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            return fOutPicture;
        }
        */
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать картинку в черно-белую без оттенков
        /// на основе отдельных цветов
        /// методом большинства голосов
        /// </summary>
        /// <param name="pBmp">преобразуемая картинка</param>
        /// <returns></returns>
        public Bitmap PictureToBlackWhiteByVote(Bitmap pBmp)
        {
            try
            {
                fBordersByColorForImage = new CBordersByColorForImage(pBmp);
                int[] lBestBorder = fBordersByColorForImage.ComputeBestBorders(pBmp);
                if (fOutPicture == null)
                    fOutPicture = new Bitmap(pBmp.Width, pBmp.Height);

                for (int i = 0; i < fPicture.Width; i++)
                    for (int j = 0; j < fPicture.Height; j++)
                    {
                        Color lPixel = fPicture.GetPixel(i, j);

                        byte lComValue = 0;

                        int lToBottom = 0;
                        int lToTop = 0;

                        if (lPixel.R <= lBestBorder[0])
                            lToBottom++;
                        else
                            lToTop++;
                        if (lPixel.G <= lBestBorder[1])
                            lToBottom++;
                        else
                            lToTop++;
                        if (lPixel.B <= lBestBorder[2])
                            lToBottom++;
                        else
                            lToTop++;

                        if (lToTop < lToBottom)
                            lComValue = 0;
                        else
                            lComValue = 255;

                        Color lNewPixel = Color.FromArgb(lComValue, lComValue, lComValue);
                        fOutPicture.SetPixel(i, j, lNewPixel);

                    }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            return fOutPicture;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать картинку в черно-белую 
        /// на основе учета всех цветов
        /// методом максимизазции плотности (минимизация среднего расстояния от центра)
        /// расположения точек группы в 3-мерном пространстве
        /// </summary>
        /// <param name="pBmp">преобразуемая картинка</param>
        /// <returns></returns>
        public Bitmap PictureToBlackWhiteByDistance(Bitmap pBmp)
        {
            try
            {
                fBordersByColorForImage = new CBordersByColorForImage(pBmp);
                int[] lBestBorder = fBordersByColorForImage.ComputeBest3DBorderGroup(pBmp);
                int lBorderSum = lBestBorder.Sum(); // lBestBorder[0] + lBestBorder[1] + lBestBorder[2];
                if (fOutPicture == null)
                    fOutPicture = new Bitmap(pBmp.Width, pBmp.Height);

                for (int i = 0; i < fPicture.Width; i++)
                    for (int j = 0; j < fPicture.Height; j++)
                    {
                        Color lPixel = fPicture.GetPixel(i, j);

                        byte lComValue = 0;

                        if (lPixel.R + lPixel.G + lPixel.B < lBorderSum)
                            lComValue = 0;
                        else
                            lComValue = 255;

                        Color lNewPixel = Color.FromArgb(lComValue, lComValue, lComValue);
                        fOutPicture.SetPixel(i, j, lNewPixel);
                    }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            return fOutPicture;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать картинку в черно-белую без оттенков
        /// </summary>
        /// <param name="pBmp">преобразуемая картинка</param>
        /// <param name="pNmbColor">цвет принимаемы за основной 
        /// по которому производится преобразование
        /// остальные цвета игнорируются</param>
        /// <returns></returns>
        public Bitmap PictureToBlackWhiteVarBorder(Bitmap pBmp, int pNmbColor,
            int pBorder, out CDescriptionPartition pDescriptionPartition)
        {

            pDescriptionPartition = null;
            try
            {
                fOutPicture = new Bitmap(pBmp.Width, pBmp.Height);
                int lComNumber = pBmp.Width * pBmp.Height;
                List<byte> lTopList = new List<byte>(lComNumber);
                List<byte> lBottomList = new List<byte>(lComNumber);
                for (int i = 0; i < pBmp.Width; i++)
                    for (int j = 0; j < pBmp.Height; j++)
                    {
                        Color lPixel = pBmp.GetPixel(i, j);

                        byte lComValue = 0;
                        byte lInValue = 0;
                        if (pNmbColor == 1)
                            lInValue = lPixel.R;
                        else if (pNmbColor == 2)
                            lInValue = lPixel.G;
                        else if (pNmbColor == 3)
                            lInValue = lPixel.B;

                        if (lInValue <= pBorder)
                        {
                            lComValue = 255;
                            lBottomList.Add(lInValue);
                        }
                        else
                        {
                            lComValue = 0;
                            lTopList.Add(lInValue);
                        }

                        Color lNewPixel = Color.FromArgb(lComValue, lComValue, lComValue);
                        fOutPicture.SetPixel(i, j, lNewPixel);

                    }
                int lTopWeight = lTopList.Count;
                int lBottomWeight = lBottomList.Count;
                double lAverageTop = 0.0;
                double lTopDevision = 0.0;
                double lAverageBottom = 0.0;
                double lBottomDevision = 0.0;
                if (lTopWeight > 0)
                {
                    lAverageTop = lTopList.Average(s => s);
                    lTopDevision = lTopList.Average(num => Math.Abs(num - lAverageTop));
                }
                if (lBottomWeight > 0)
                {
                    lAverageBottom = lBottomList.Average(s => s);
                    lBottomDevision = lBottomList.Average(num => Math.Abs(num - lAverageBottom));
                }
                pDescriptionPartition = new CDescriptionPartition(lTopWeight, lBottomWeight,
                    lAverageTop, lAverageBottom, lTopDevision, lBottomDevision);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            return fOutPicture;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать картинку в картинку содержащую оттенки одного из цветов
        /// остальные цвета игнорируются
        /// </summary>
        /// <param name="pBmp">картинка для преобразования</param>
        /// <param name="pNmbColor">цвет по которому строится новая картинка</param>
        /// <returns></returns>
        public Bitmap PictureToShadow(Bitmap pBmp, int pNmbColor)
        {

            try
            {
                if (fOutPicture == null)
                    fOutPicture = new Bitmap(pBmp.Width, pBmp.Height);
                for (int i = 0; i < fOutPicture.Width; i++)
                    for (int j = 0; j < fOutPicture.Height; j++)
                    {
                        Color lPixel = pBmp.GetPixel(i, j);

                        byte lComValue = (byte)((lPixel.R + lPixel.G + lPixel.B)/3);

                        Color lNewPixel = Color.FromArgb(lComValue, lComValue, lComValue);
                        switch (pNmbColor)
                        {
                            case 0:
                                lNewPixel = Color.FromArgb(lComValue, lComValue, lComValue);
                                break;
                            case 1:
                                lNewPixel = Color.FromArgb(lComValue, 0, 0);
                                break;
                            case 2:
                                lNewPixel = Color.FromArgb(0, lComValue, 0);
                                break;
                            case 3:
                                lNewPixel = Color.FromArgb(0, 0, lComValue);
                                break;
                        }

                        fOutPicture.SetPixel(i, j, lNewPixel);

                    }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            return fOutPicture;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать картинку в двоичную матрицу
        /// подразумевается что картинку черно-белая
        /// </summary>
        /// <param name="pPicture">картинка для преобразованиия</param>
        /// <returns>двоичная матрица соответствующая чернобелой картинке</returns>
        public static byte[][] BitmapToBinaryMatrix(Bitmap pPicture)
        {
            byte [][] lOutMatrix = new byte[pPicture.Width][];
            for (int i = 0; i < pPicture.Width; i++)
            {
                try
                {
                    lOutMatrix[i] = new byte[pPicture.Height];
                    for (int j = 0; j < pPicture.Height; j++)
                    {
                        if (pPicture.GetPixel(i, j).R > 0)
                            lOutMatrix[i][j] = 1;
                        else
                            lOutMatrix[i][j] = 0;
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    throw;
                }

            }
            return lOutMatrix;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать двочную матрицу в черно-белую картинку
        /// </summary>
        /// <param name="pMatrix">двоичная матрица для преобразования</param>
        /// <returns>черно-белая картинка соответствующая матрице </returns>
        public static Bitmap  BinaryMatrixToBitmap(byte[][] pMatrix)
        {
            Bitmap lOutPicture = new Bitmap(pMatrix.Length, pMatrix[0].Length);
            for (int i = 0; i < pMatrix.Length; i++)
            {
                for (int j = 0; j < pMatrix[i].Length; j++)
                {
                    byte lComValue = pMatrix[i][j] == (byte)0 ? (byte)0 : (byte)255;
                    Color lNewPixel = Color.FromArgb(lComValue, lComValue, lComValue);
                    lOutPicture.SetPixel(i, j, lNewPixel);
                }
            }
            return lOutPicture;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать цветную матрицу в цветную картинку
        /// </summary>
        /// <param name="pMatrix">цветная матрица для преобразования</param>
        /// <returns>цветная картинка картинок соответствующая матрице </returns>
        public static Bitmap ColorMatrixToColorBitmap(int[][] pMatrix)
        {
            int lSize = DefineNumberOfColor(pMatrix);
            return ColorMatrixToColorBitmap(pMatrix, lSize);
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать цветную матрицу в цветную картинку
        /// </summary>
        /// <param name="pMatrix">цветная матрица для преобразования</param>
        /// <returns>цветная картинка картинок соответствующая матрице </returns>
        public static Bitmap ColorMatrixToColorBitmap(int[][] pMatrix, int pSize)
        {
            Color lNewPixel = Color.FromArgb((byte)255, (byte)255, (byte)255);
            // подготовим массив контрастных цветов достаточной длины
            Color[] lColorsForMatrix = DefineExactNeedColor(pSize, true);
            Bitmap lOutPicture = new Bitmap(pMatrix.Length, pMatrix[0].Length);
            // выходную матрицу заполним черным цветом
            for (int i = 0; i < pMatrix.Length; i++)
                for (int j = 0; j < pMatrix[0].Length; j++)
                    lOutPicture.SetPixel(i, j, lNewPixel);
            for (int i = 0; i < pMatrix.Length; i++)
            {
                for (int j = 0; j < pMatrix[i].Length; j++)
                {
                    int k = pMatrix[i][j];
                    if (k > 0)
                    {
                        // если в исходной матрице цвет обозначен как k
                        // то находим в массиве цветов соответствующий цвет
                        // и подставляем его в картинку на соответствующюю позицию
                        if (k <= lColorsForMatrix.Length)
                            lOutPicture.SetPixel(i, j, lColorsForMatrix[k-1]);
                    }
                }
            }
            return lOutPicture;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать цветную матрицу в черно-белую
        /// </summary>
        /// <param name="pMatrix">цветная матрица для преобразования</param>
        /// <returns>черно-белая матрица </returns>
        public static byte[][] ColorMatrixToBinaryMatrix(int[][] pMatrix)
        {
            // создать новую матрицу чтобы не трогать входную
            byte[][] lMatrix = new byte[pMatrix.Length][];
            for (int i = 0; i < pMatrix.Length; i++)
            {
                lMatrix[i] = new byte[pMatrix[i].Length];
                for (int j = 0; j < pMatrix[i].Length; j++)
                    lMatrix[i][j] = pMatrix[i][j] > 0 ? (byte)1:(byte)0;
            }
            return lMatrix;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать цветную матрицу в набор черно-белых картинок
        /// </summary>
        /// <param name="pMatrix">цветная матрица для преобразования</param>
        /// <returns>набор черно-белых картинок соответствующих матрице </returns>
        public static Bitmap[] ColorMatrixToBitmapList(int[][] pMatrix)
        {
            int lSize = DefineNumberOfColor(pMatrix);
            return ColorMatrixToBitmapList(pMatrix, lSize);
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать цветную матрицу в набор черно-белых картинок
        /// </summary>
        /// <param name="pMatrix">цветная матрица для преобразования</param>
        /// <returns>набор черно-белых картинок соответствующих матрице </returns>
        public static Bitmap[] ColorMatrixToBitmapList(int[][] pMatrix, int pSize)
        {
            Color lBlackPixel = Color.FromArgb((byte)0, (byte)0, (byte)0);
            Color lWhitePixel = Color.FromArgb((byte)0, (byte)0, (byte)0);
            // создадим заранее psize картинок
            Bitmap[] lOutPicture = new Bitmap[pSize];
            for (int k = 0; k < pSize; k++)
            {
                lOutPicture[k] = new Bitmap(pMatrix.Length, pMatrix[0].Length);
                // и покрасим все в черный цвет первоначально
                for (int i = 0; i < pMatrix.Length; i++)
                    for (int j = 0; j < pMatrix[0].Length; j++)
                        lOutPicture[k].SetPixel(i, j, lBlackPixel);
            }
            for (int i = 0; i < pMatrix.Length; i++)
            {
                for (int j = 0; j < pMatrix[i].Length; j++)
                {
                    if (pMatrix[i][j] != 0)
                    {
                        // k-й матрице будет соотвестствовать k-й цвет исходной матрицы
                        // если в данной точке в исходной матрице к-й цвет то 
                        // в k-й матрице в соответствующей точке ставим белый цвет
                        int k = pMatrix[i][j];
                        if (k < lOutPicture.Length )
                            lOutPicture[k].SetPixel(i, j, lWhitePixel);
                    }
                }
            }
            return lOutPicture;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать цветную матрицу в набор черно-белых 
        /// </summary>
        /// <param name="pMatrix">цветная матрица для преобразования</param>
        /// <returns>набор черно-белых матриц соответствующих матрице </returns>
        public static int[][][] ColorMatrixToBinMatrixList(int[][] pMatrix)
        {
            int lSize = DefineNumberOfColor(pMatrix);
            return ColorMatrixToBinMatrixList(pMatrix, lSize);
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать цветную матрицу в набор черно-белых
        /// </summary>
        /// <param name="pMatrix">цветная матрица для преобразования</param>
        /// <returns>набор черно-белых матриц соответствующих матрице </returns>
        public static int[][][] ColorMatrixToBinMatrixList(int[][] pMatrix, int pSize)
        {
            // создадим заранее psize матриц
            int[][][] lOutMatrix = new int[pSize][][];
            for (int k = 0; k < pSize; k++)
            {
                lOutMatrix[k] = new int[pMatrix.Length][]; //
                // и покрасим все в черный цвет первоначально
                for (int i = 0; i < pMatrix.Length; i++)
                {
                    lOutMatrix[k][i] = new int[pMatrix[i].Length];
                    for (int j = 0; j < pMatrix[i].Length; j++)
                        lOutMatrix[k][i][ j] = 0;
                }
            }
            for (int i = 0; i < pMatrix.Length; i++)
            {
                for (int j = 0; j < pMatrix[i].Length; j++)
                {
                    if (pMatrix[i][j] != 0)
                    {
                        // k-й матрице будет соотвестствовать k-й цвет исходной матрицы
                        // если в данной точке в исходной матрице к-й цвет то 
                        // в k-й матрице в соответствующей точке ставим белый цвет
                        int k = pMatrix[i][j];
                        if (k < lOutMatrix.Length)
                            lOutMatrix[k][i][j] = 1;
                    }
                }
            }
            return lOutMatrix;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать список двочных матриц в одну цветную
        /// </summary>
        /// <param name="pMatrixList">список двоичных матриц для преобразования</param>
        /// <returns>полученная цветная матрица</returns>
        public static int[][] BinaryMatrixListToColorMatrix(List<byte[][]> pMatrixList, byte pWhat)
        {
            int [][] lOutMatrix = new int[pMatrixList[0].Length][];
            for (int i = 0; i < pMatrixList[0].Length; i++)
            {
                lOutMatrix[i] = new int[pMatrixList[0][i].Length];
                for (int j = 0; j < lOutMatrix[i].Length; j++)
                    lOutMatrix[i][j] = 0;
            }
            for (int k = 0; k < pMatrixList.Count; k++)
            {
                for (int i = 0; i < pMatrixList[k].Length && i < lOutMatrix.Length; i++)
                {
                    for (int j = 0; j < lOutMatrix[i].Length && j < pMatrixList[k][i].Length; j++)
                        if (pMatrixList[k][i][j] == pWhat )
                            lOutMatrix[i][j] = k+1;
                }
            }
            return lOutMatrix;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать чернобелую картинку в цветную
        /// </summary>
        /// <param name="pPicture"></param>
        /// <returns></returns>
        public static Bitmap BWImageToColorImage(Bitmap pPicture, byte pWhat)
        {
            CImageSplitter lImageSplitter = new CImageSplitter();
            byte[][] lMatrix = BitmapToBinaryMatrix(pPicture);
            if (pWhat != (byte)1)
                lMatrix = lImageSplitter.InverseMatrix(lMatrix);
            int lNumberColor;
            int [][] lColorMatrix = lImageSplitter.SplitByOneMatrix(lMatrix, out lNumberColor);
            Bitmap lOutImage = ColorMatrixToColorBitmap(lColorMatrix, lNumberColor);
            return lOutImage;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// преобразовать список двочных матриц в список черно-белых картинок
        /// </summary>
        /// <param name="pMatrixList">список двоичных матриц для преобразования</param>
        /// <returns>список черно-белых картинок соответствующих матрицам во входном списке</returns>
        public static List<Bitmap> BinaryMatrixListToBitmapList(List<byte[][]> pMatrixList)
        {
            List<Bitmap> lBitmapList = new List<Bitmap>();

            for (int i = 0; i < pMatrixList.Count; i++)
            {
                lBitmapList.Add(BinaryMatrixToBitmap(pMatrixList[i]));
            }

            return lBitmapList;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// определить старший цвет а значит и число цветов для матрицы
        /// </summary>
        /// <param name="pMatrix"></param>
        /// <returns></returns>
        public static int DefineNumberOfColor(int[][] pMatrix)
        {
            int lNumberOfColor = 0;
            for (int i = 0; i < pMatrix.Length; i++)
                for (int j = 0; j < pMatrix[i].Length; j++)
                    if (pMatrix[i][j] > lNumberOfColor)
                        lNumberOfColor = pMatrix[i][j];
            return lNumberOfColor+1;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// удалить изолированиые точки те точки не имеющие достаточное число соседей
        /// </summary>
        /// <param name="pMatrix">матрица в которой удаляются изолированные точки</param>
        /// <param name="pThat">цвет удаляемых точек (черный или белый)
        /// если 2 то удаляются изолированные точки обоих цветов</param>
        public static void RemoveIsolatePoint(byte[][] pMatrix, byte pThat)
        {
            for (int i = 0; i < pMatrix.Length; i++)
            {
                for (int j = 0; j < pMatrix[i].Length; j++)
                {
                    int lTheSame = 0;
                    int lOthers = 0;
                    if (pThat == 2 || pMatrix[i][j] == pThat)
                    {
                        // если строка сверху существует
                        if (i > 0)
                        {
                            if (j > 0)  // если столбец слева существует
                            {
                                // если точка слева сверху совпадает с данной точкой
                                if (pMatrix[i][j] == pMatrix[i - 1][j - 1])
                                    lTheSame++;
                                else
                                    lOthers++;
                            }
                            // если точка сверху совпадает с данной точкой
                            if (pMatrix[i][j] == pMatrix[i - 1][j])
                                lTheSame++;
                            else
                                lOthers++;
                            if (j + 1 < pMatrix[i].Length)  // если столбец справа существует
                            {
                                // если точка справа сверху совпадает с данной точкой
                                if (pMatrix[i][j] == pMatrix[i - 1][j + 1])
                                    lTheSame++;
                                else
                                    lOthers++;
                            }
                        }
                        // если строка снизу существует
                        if (i + 1 < pMatrix.Length)
                        {
                            if (j > 0)  // если столбец слева существует
                            {
                                // если точка слева снизу совпадает с данной точкой
                                if (pMatrix[i][j] == pMatrix[i + 1][j - 1])
                                    lTheSame++;
                                else
                                    lOthers++;
                            }
                            // если точка снизу совпадает с данной точкой
                            if (pMatrix[i][j] == pMatrix[i + 1][j])
                                lTheSame++;
                            else
                                lOthers++;
                            if (j + 1 < pMatrix[i].Length)  // если столбец справа существует
                            {
                                // если точка справа снизу совпадает с данной точкой
                                if (pMatrix[i][j] == pMatrix[i + 1][j + 1])
                                    lTheSame++;
                                else
                                    lOthers++;
                            }
                        }
                        if (j > 0)  // если столбец слева существует
                        {
                            // если точка слева совпадает с данной точкой
                            if (pMatrix[i][j] == pMatrix[i][j - 1])
                                lTheSame++;
                            else
                                lOthers++;
                        }
                        if (j + 1 < pMatrix[i].Length)  // если столбец справа существует
                        {
                            // если точка справа совпадает с данной точкой
                            if (pMatrix[i][j] == pMatrix[i][j + 1])
                                lTheSame++;
                            else
                                lOthers++;
                        }
                        double lRation = 1.0;
                        lRation = lRation * lTheSame / (lOthers + lTheSame);
                        if (lRation < RationLimit)
                            pMatrix[i][j] = pMatrix[i][j] == (byte)0 ? (byte)1 : (byte)0;
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// удалить изолированиые точки те точки не имеющие достаточное число соседей
        /// веса и взвешенный коэфициэнт задаются по умолчанию
        /// </summary>
        /// <param name="pMatrix">матрица в которой удаляются изолированные точки</param>
        /// <param name="pThat">цвет удаляемых точек (черный или белый)
        public static void RemoveIsolatePointAccurate(byte[][] pMatrix, byte pThat)
        {
            RemoveIsolatePointAccurate(pMatrix, pThat, RationLimit,
                WeightA0, WeightA1, WeightB0, WeightB1, WeightB2);
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// удалить изолированиые точки те точки не имеющие достаточное число соседей
        /// </summary>
        /// <param name="pMatrix">матрица в которой удаляются изолированные точки</param>
        /// <param name="pThat">цвет удаляемых точек (черный или белый)
        /// <param name="pRationLimit">взвешенный коэфициент наличия соседей
        /// Каждый тип соседа учитывается со своим весом</param>
        /// <param name="pWeightA0">вес ближайшего соседа</param>
        /// <param name="pWeightA1">вес ближайшего по диагогали</param>
        /// <param name="pWeightB0">вес прямого удаленного на 1</param>
        /// <param name="pWeightB1">вес промежуточного удаленного на 1</param>
        /// <param name="pWeightB2">вес диагонального удаленного на 1</param>
        public static void RemoveIsolatePointAccurate(byte[][] pMatrix, byte pThat, double pRationLimit,
            double pWeightA0,double pWeightA1,double pWeightB0,double pWeightB1,double pWeightB2)
        {
            for (int i = 0; i < pMatrix.Length; i++)
            {
                for (int j = 0; j < pMatrix[i].Length; j++)
                {
                    double lTheSame = 0.0;
                    double lOthers = 0.0;
                    if (pThat == 2 || pMatrix[i][j] == pThat)
                    {
                        // если 2я строка сверху существует
                        if (i > 1)
                        {
                            if (j > 1)  // если 2й столбец слева существует
                            {
                                // если точка слева сверху совпадает с данной точкой
                                // точка типа B2
                                if (pMatrix[i][j] == pMatrix[i - 2][j - 2])
                                    lTheSame += pWeightB2;
                                else
                                    lOthers += pWeightB2;
                            }
                            if (j > 0)  // если 1й столбец слева существует
                            {
                                // если точка слева сверху совпадает с данной точкой
                                // точка типа B1
                                if (pMatrix[i][j] == pMatrix[i - 2][j - 1])
                                    lTheSame += pWeightB1;
                                else
                                    lOthers += pWeightB1;
                            }
                            // если точка сверху совпадает с данной точкой
                            // точка типа B0
                            if (pMatrix[i][j] == pMatrix[i - 2][j])
                                lTheSame += pWeightB0;
                            else
                                lOthers += pWeightB0;
                            if (j + 1 < pMatrix[i].Length)  // если 1й столбец справа существует
                            {
                                // если точка справа сверху совпадает с данной точкой
                                // точка типа B1
                                if (pMatrix[i][j] == pMatrix[i - 2][j + 1])
                                    lTheSame += pWeightB1;
                                else
                                    lOthers += pWeightB1;
                            }
                            if (j + 2 < pMatrix[i].Length)  // если 2й столбец справа существует
                            {
                                // если точка справа сверху совпадает с данной точкой
                                // точка типа B2
                                if (pMatrix[i][j] == pMatrix[i - 2][j + 2])
                                    lTheSame += pWeightB2;
                                else
                                    lOthers += pWeightB2;
                            }
                        }
                        // если 1я строка сверху существует
                        if (i > 0)
                        {
                            if (j > 1)  // если 2й столбец слева существует
                            {
                                // если точка слева сверху совпадает с данной точкой
                                // точка типа B1
                                if (pMatrix[i][j] == pMatrix[i - 1][j - 2])
                                    lTheSame += pWeightB1;
                                else
                                    lOthers += pWeightB1;
                            }
                            if (j > 0)  // если 1й столбец слева существует
                            {
                                // если точка слева сверху совпадает с данной точкой
                                // точка типа A1
                                if (pMatrix[i][j] == pMatrix[i - 1][j - 1])
                                    lTheSame += pWeightA1;
                                else
                                    lOthers += pWeightA1;
                            }
                            // если точка сверху совпадает с данной точкой
                            // точка типа A0
                            if (pMatrix[i][j] == pMatrix[i - 1][j])
                                lTheSame += pWeightA0;
                            else
                                lOthers += pWeightA0;
                            if (j + 1 < pMatrix[i].Length)  // если 1й столбец справа существует
                            {
                                // если точка справа сверху совпадает с данной точкой
                                // точка типа A1
                                if (pMatrix[i][j] == pMatrix[i - 1][j + 1])
                                    lTheSame += pWeightA1;
                                else
                                    lOthers += pWeightA1;
                            }
                            if (j + 2 < pMatrix[i].Length)  // если 2й столбец справа существует
                            {
                                // если точка справа сверху совпадает с данной точкой
                                // точка типа B1
                                if (pMatrix[i][j] == pMatrix[i - 1][j + 2])
                                    lTheSame += pWeightB1;
                                else
                                    lOthers += pWeightB1;
                            }
                        }

                        // если 1я строка снизу существует
                        if (i + 1 < pMatrix.Length)
                        {
                            if (j > 1)  // если 2й столбец слева существует
                            {
                                // если точка слева снизу совпадает с данной точкой
                                // точка типа B1
                                if (pMatrix[i][j] == pMatrix[i + 1][j - 2])
                                    lTheSame += pWeightB1;
                                else
                                    lOthers += pWeightB1;
                            }
                            if (j > 0)  // если 1й столбец слева существует
                            {
                                // если точка слева снизу совпадает с данной точкой
                                // точка типа A1
                                if (pMatrix[i][j] == pMatrix[i + 1][j - 1])
                                    lTheSame += pWeightA1;
                                else
                                    lOthers += pWeightA1;
                            }
                            // если точка снизу совпадает с данной точкой
                            // точка типа A0
                            if (pMatrix[i][j] == pMatrix[i + 1][j])
                                lTheSame += pWeightA0;
                            else
                                lOthers += pWeightA0;
                            if (j + 1 < pMatrix[i].Length)  // если 1й столбец справа существует
                            {
                                // если точка справа снизу совпадает с данной точкой
                                // точка типа A1
                                if (pMatrix[i][j] == pMatrix[i + 1][j + 1])
                                    lTheSame += pWeightA1;
                                else
                                    lOthers += pWeightA1;
                            }
                            if (j + 2 < pMatrix[i].Length)  // если 2й столбец справа существует
                            {
                                // если точка справа снизу совпадает с данной точкой
                                // точка типа B1
                                if (pMatrix[i][j] == pMatrix[i + 1][j + 2])
                                    lTheSame += pWeightB1;
                                else
                                    lOthers += pWeightB1;
                            }
                        }
                        // если 2я строка снизу существует
                        if (i + 2 < pMatrix.Length)
                        {
                            if (j > 1)  // если 2й столбец слева существует
                            {
                                // если точка слева снизу совпадает с данной точкой
                                // точка типа B2
                                if (pMatrix[i][j] == pMatrix[i + 2][j - 2])
                                    lTheSame += pWeightB2;
                                else
                                    lOthers += pWeightB2;
                            }
                            if (j > 0)  // если 1й столбец слева существует
                            {
                                // если точка слева снизу совпадает с данной точкой
                                // точка типа B1
                                if (pMatrix[i][j] == pMatrix[i + 2][j - 1])
                                    lTheSame += pWeightB1;
                                else
                                    lOthers += pWeightB1;
                            }
                            // если точка снизу совпадает с данной точкой
                            // точка типа B0
                            if (pMatrix[i][j] == pMatrix[i + 2][j])
                                lTheSame += pWeightB0;
                            else
                                lOthers += pWeightB0;
                            if (j + 1 < pMatrix[i].Length)  // если 1й столбец справа существует
                            {
                                // если точка справа снизу совпадает с данной точкой
                                // точка типа B1
                                if (pMatrix[i][j] == pMatrix[i + 2][j + 1])
                                    lTheSame += pWeightB1;
                                else
                                    lOthers += pWeightB1;
                            }
                            if (j + 2 < pMatrix[i].Length)  // если 2й столбец справа существует
                            {
                                // если точка справа снизу совпадает с данной точкой
                                // точка типа B2
                                if (pMatrix[i][j] == pMatrix[i + 2][j + 2])
                                    lTheSame += pWeightB2;
                                else
                                    lOthers += pWeightB2;
                            }
                        }

                        // своя строка
                        if (j > 1)  // если 2й столбец слева существует
                        {
                            // если точка слева совпадает с данной точкой
                            // точка типа B0
                            if (pMatrix[i][j] == pMatrix[i][j - 2])
                                lTheSame += pWeightB0;
                            else
                                lOthers += pWeightB0;
                        }
                        if (j > 0)  // если 1й столбец слева существует
                        {
                            // если точка слева совпадает с данной точкой
                            // точка типа A0
                            if (pMatrix[i][j] == pMatrix[i][j - 1])
                                lTheSame += pWeightA0;
                            else
                                lOthers += pWeightA0;
                        }
                        if (j + 1 < pMatrix[i].Length)  // если 1й столбец справа существует
                        {
                            // если точка справа совпадает с данной точкой
                            // точка типа A0
                            if (pMatrix[i][j] == pMatrix[i][j + 1])
                                lTheSame += pWeightA0;
                            else
                                lOthers += pWeightA0;
                        }
                        if (j + 2 < pMatrix[i].Length)  // если 2й столбец справа существует
                        {
                            // если точка справа совпадает с данной точкой
                            // точка типа B0
                            if (pMatrix[i][j] == pMatrix[i][j + 2])
                                lTheSame += pWeightB0;
                            else
                                lOthers += pWeightB0;
                        }
                        double lRation = 1.0;
                        lRation = lRation * lTheSame / (lOthers + lTheSame);
                        if (lRation < pRationLimit)
                            pMatrix[i][j] = pMatrix[i][j] == (byte)0 ? (byte)1 : (byte)0;
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// определить необходимую базу для автоматичекого построения контрастного
        /// списка цветов
        /// </summary>
        /// <param name="pNumberColor">минимум цветов которые должны содержаться в таблице</param>
        /// <returns></returns>
        private static int DefineNeedBaseForColor(int pNumberColor)
        {
            int lPurposeBase = 2;
            while (lPurposeBase * lPurposeBase * lPurposeBase <= pNumberColor) lPurposeBase++;
            return lPurposeBase;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// автоматическое построение списка котрастных цветов для заданной базы
        /// </summary>
        /// <param name="pBase">база для построения</param>
        /// <returns></returns>
        private static Color[] DefineNeedColorByBase(int pBase)
        {
            // pBase - база те число точек интенсивности на которые разбиваем каждый цвет
            // две точки это концы отрезка 0 и 255, определим число промежуточных точек
            int lNumberInterPoint = pBase - 2;
            // массив точек интенсивности
            byte[] lArrayPoint = new byte [pBase];
            // первая точка 0
            lArrayPoint[0] = 0;
            // промежуточные точки
            for (byte i = 1; i < pBase - 1; i++)
                lArrayPoint[i] = (byte)(i * ((byte)255 / ((byte)pBase-1)));
            // последняя точка 255
            lArrayPoint[pBase - 1] = 255;

            // размер выходного массива 2 в степени pBase
            int lArraySize = pBase * pBase * pBase;
            // выходной массив
            Color[] lColors = new Color[lArraySize];
            int l = 0;
            // все комбинации возможных интенсивностей для каждого цвета
            for (int i = 0; i < pBase; i++)
                for (int j = 0; j < pBase; j++)
                    for (int k = 0; k < pBase; k++)
                        lColors[l++] = Color.FromArgb(lArrayPoint[i], lArrayPoint[j], lArrayPoint[k]);
            return lColors;

        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// автоматическое построение списка котрастных цветов для заданного минимума цветов
        /// </summary>
        /// <param name="pNumberColor">необходимій минимум цветов</param>
        /// <returns></returns>
        public static Color[] DefineNeedColor(int pNumberColor)
        {
            return DefineNeedColorByBase(DefineNeedBaseForColor(pNumberColor));
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// автоматическое построение списка котрастных цветов для заданного минимума цветов
        /// вариант с точным количеством
        /// </summary>
        /// <param name="pNumberColor"></param>
        /// <returns></returns>
        public static Color[] DefineExactNeedColor(int pNumberColor)
        {
            return DefineExactNeedColor(pNumberColor, false);
        }
        //--------------------------------------------------------------------------------------
        public static Color[] DefineExactNeedColor(int pNumberColor, bool pIsForWhite)
        {
            Color [] lOutColors = new Color[pNumberColor];
            int lBaseNumber = DefineNeedBaseForColor(pNumberColor);
            Color[] lFullList = DefineNeedColorByBase(DefineNeedBaseForColor(pNumberColor));
            if (pIsForWhite)
            {
                Color lFirst = lFullList[0];
                lFullList[0] = lFullList[lFullList.Length - 1];
                lFullList[lFullList.Length - 1] = lFirst;
            }
            if (lBaseNumber < 3)
            {
                int lShift = pNumberColor < lFullList.Length ? 1 : 0;
                for (int i = 0; i < lOutColors.Length; i++)
                    lOutColors[i] = lFullList[i+lShift];
            }
            else
            {
                int lShift = 0;
                if (lBaseNumber <= 5)
                    lShift = 1;
                else
                    lShift = 2;
                lShift = lBaseNumber - lShift;
                int i = 0;
                for (int lStart = 1; lStart < lBaseNumber && i < pNumberColor; lStart++)
                    for (int j = lStart; j < lFullList.Length && i < pNumberColor; j += lShift)
                        lOutColors[i++] = lFullList[j];
            }
            return lOutColors;
        }
        //--------------------------------------------------------------------------------------
        public byte[][][] Compare2BWMatrix(byte[][] pOne, byte[][] pTwo, byte pValueColor)
        {
            if (pOne.Length != pTwo.Length || pOne[0].Length != pTwo[0].Length)
                throw new ArgumentException("Не совпдает размерность входных матриц: " + pOne.Length.ToString() + " и " + pTwo.Length.ToString(), "pOne, pTwo");

            byte[][] lIntersection = new byte[pOne.Length][];
            byte[][] lUnion = new byte[pOne.Length][];
            byte[][] lUnionDiffer = new byte[pOne.Length][];
            byte[][] lPict1_Pict2 = new byte[pOne.Length][];
            byte[][] lPict2_Pict1 = new byte[pOne.Length][];
            byte lBackColor = pValueColor == (byte)1 ? (byte)0 : (byte)1;
            for (int i = 0; i < pOne.Length; i++)
            {
                lIntersection[i] = new byte[pOne[0].Length];
                lUnion[i] = new byte[pOne[0].Length];
                lUnionDiffer[i] = new byte[pOne[0].Length];
                lPict1_Pict2[i] = new byte[pOne[0].Length];
                lPict2_Pict1[i] = new byte[pOne[0].Length];
                for (int j = 0; j < pOne[0].Length; j++)
                {
                    if (pOne[i][j] == pValueColor && pTwo[i][j] == pValueColor)
                        lIntersection[i][j] = pValueColor;
                    else
                        lIntersection[i][j] = lBackColor;
                    if (pOne[i][j] == pValueColor || pTwo[i][j] == pValueColor)
                        lUnion[i][j] = pValueColor;
                    else
                        lUnion[i][j] = lBackColor;
                    if (pOne[i][j] == pValueColor && pTwo[i][j] != pValueColor)
                        lPict1_Pict2[i][j] = pValueColor;
                    else
                        lPict1_Pict2[i][j] = lBackColor;
                    if (pOne[i][j] != pValueColor && pTwo[i][j] == pValueColor)
                        lPict2_Pict1[i][j] = pValueColor;
                    else
                        lPict2_Pict1[i][j] = lBackColor;
                    if (lPict1_Pict2[i][j] == pValueColor || lPict2_Pict1[i][j] == pValueColor)
                        lUnionDiffer[i][j] = pValueColor;
                    else
                        lUnionDiffer[i][j] = lBackColor;
                }
            }
            return new byte[][][] { lIntersection, lUnion, lPict1_Pict2, lPict2_Pict1, lUnionDiffer };
        }
        //--------------------------------------------------------------------------------------
        public byte[][][] Compare3BWMatrix(byte[][] pOne, byte[][] pTwo,byte[][] pThree, byte pValueColor)
        {
            if (pOne.Length != pTwo.Length || pOne[0].Length != pTwo[0].Length )
                throw new ArgumentException("Не совпдает размерность входных матриц: " + pOne.Length.ToString() + " и " + pTwo.Length.ToString(), "pOne, pTwo");
            if ( pOne.Length != pThree.Length || pOne[0].Length != pThree[0].Length )
                throw new ArgumentException("Не совпдает размерность входных матриц: " + pOne.Length.ToString() + " и " + pThree.Length.ToString(), "pOne, pThree");

            byte[][] lUnion = new byte[pOne.Length][];
            byte[][] lIntersection = new byte[pOne.Length][];
            byte[][] lUnionDiffer = new byte[pOne.Length][];
            byte[][] lPict001 = new byte[pOne.Length][];
            byte[][] lPict010 = new byte[pOne.Length][];
            byte[][] lPict100 = new byte[pOne.Length][];
            byte[][] lPict011 = new byte[pOne.Length][];
            byte[][] lPict101 = new byte[pOne.Length][];
            byte[][] lPict110 = new byte[pOne.Length][];

            byte lBackColor = pValueColor == (byte)1 ? (byte)0 : (byte)1;
            for (int i = 0; i < pOne.Length; i++)
            {
                lUnion[i] = new byte[pOne[0].Length];
                lIntersection[i] = new byte[pOne[0].Length];
                lUnionDiffer[i] = new byte[pOne[0].Length];
                lPict001[i] = new byte[pOne[0].Length];
                lPict010[i] = new byte[pOne[0].Length];
                lPict100[i] = new byte[pOne[0].Length];
                lPict011[i] = new byte[pOne[0].Length];
                lPict101[i] = new byte[pOne[0].Length];
                lPict110[i] = new byte[pOne[0].Length];
                for (int j = 0; j < pOne[0].Length; j++)
                {
                    if (pOne[i][j] == pValueColor && pTwo[i][j] == pValueColor && 
                        pThree[i][j] == pValueColor)
                        lIntersection[i][j] = pValueColor;
                    else
                        lIntersection[i][j] = lBackColor;
                    if (pOne[i][j] == pValueColor || pTwo[i][j] == pValueColor || 
                        pThree[i][j] == pValueColor)
                        lUnion[i][j] = pValueColor;
                    else
                        lUnion[i][j] = lBackColor;

                    if (pOne[i][j] != pValueColor && pTwo[i][j] != pValueColor && 
                        pThree[i][j] == pValueColor)
                        lPict001[i][j] = pValueColor;
                    else
                        lPict001[i][j] = lBackColor;
                    if (pOne[i][j] != pValueColor && pTwo[i][j] == pValueColor &&
                        pThree[i][j] != pValueColor)
                        lPict010[i][j] = pValueColor;
                    else
                        lPict010[i][j] = lBackColor;
                    if (pOne[i][j] == pValueColor && pTwo[i][j] != pValueColor &&
                        pThree[i][j] != pValueColor)
                        lPict100[i][j] = pValueColor;
                    else
                        lPict100[i][j] = lBackColor;
                    if (pOne[i][j] != pValueColor && pTwo[i][j] == pValueColor &&
                        pThree[i][j] == pValueColor)
                        lPict011[i][j] = pValueColor;
                    else
                        lPict011[i][j] = lBackColor;
                    if (pOne[i][j] == pValueColor && pTwo[i][j] != pValueColor &&
                        pThree[i][j] == pValueColor)
                        lPict101[i][j] = pValueColor;
                    else
                        lPict101[i][j] = lBackColor;
                    if (pOne[i][j] == pValueColor && pTwo[i][j] == pValueColor &&
                        pThree[i][j] != pValueColor)
                        lPict110[i][j] = pValueColor;
                    else
                        lPict110[i][j] = lBackColor;

                    if (lPict001[i][j] == pValueColor || lPict010[i][j] == pValueColor || 
                        lPict100[i][j] == pValueColor)
                        lUnionDiffer[i][j] = pValueColor;
                    else
                        lUnionDiffer[i][j] = lBackColor;
                }
            }
            return new byte[][][] { lIntersection, lUnion, lUnionDiffer, lPict001,
            lPict010, lPict100, lPict011, lPict101, lPict110};
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
