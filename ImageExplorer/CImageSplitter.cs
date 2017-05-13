using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageExplorer
{
    //--------------------------------------------------------------------------------------
    // class CImageSplitter
    //--------------------------------------------------------------------------------------
    public class CImageSplitter
    {
        private List<CSetPoint> fSets;
        private List<byte[][]> fSetsOfMatrix;
        private const int SmallThreshold = 3;
        //--------------------------------------------------------------------------------------
        public CImageSplitter()
        {
            fSets = new List<CSetPoint>();
            fSetsOfMatrix = new List<byte[][]>();
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// разбить рисунок на отдельные куски в виде списка матриц по методу множеств
        /// </summary>
        /// <param name="pImage"></param>
        /// <returns></returns>
        public List<byte[][]> SplitBySet(Bitmap pImage)
        {
            byte[][] lMatrix = CBlackWhiteExplorer.BitmapToBinaryMatrix(pImage);
            return SplitBySet(lMatrix);
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// разбить рисунок на отдельные куски в виде списка матриц по методу матриц
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="pWhat"></param>
        /// <returns></returns>
        public List<byte[][]> SplitByMatrix(Bitmap pImage, byte pWhat)
        {
            byte[][] lMatrix = CBlackWhiteExplorer.BitmapToBinaryMatrix(pImage);
            return SplitByMatrix(lMatrix, pWhat);
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// разбить рисунок на отдельные куски в виде списка матриц по методу единной матрицы
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="pNumberColor"></param>
        /// <returns></returns>
        public int[][] SplitByOneMatrix(Bitmap pImage, out int pNumberColor)
        {
            byte[][] lMatrix = CBlackWhiteExplorer.BitmapToBinaryMatrix(pImage);
            return SplitByOneMatrix(lMatrix, out pNumberColor);
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// разбить рисунок(представленный как матрица) на отдельные куски 
        /// в виде списка рисунков по методу множеств
        /// </summary>
        /// <param name="pMatrix"></param>
        /// <returns></returns>
        public List<Bitmap> SplitBySetToImages(byte[][] pMatrix)
        {
            List<byte[][]> lMatrixList = SplitBySet(pMatrix);
            List<Bitmap> lImages = CBlackWhiteExplorer.BinaryMatrixListToBitmapList(lMatrixList);
            return lImages;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// разбить рисунок(представленный как матрица) на отдельные куски 
        /// в виде списка рисунков по методу матриц
        /// </summary>
        /// <param name="pMatrix"></param>
        /// <param name="pWhat"></param>
        /// <returns></returns>
        public List<Bitmap> SplitByMatrixToImages(byte[][] pMatrix, byte pWhat)
        {
            List<byte[][]> lMatrixList = SplitByMatrix(pMatrix, pWhat);
            List<Bitmap> lImages = CBlackWhiteExplorer.BinaryMatrixListToBitmapList(lMatrixList);
            return lImages;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// разбить рисунок на отдельные куски 
        /// в виде списка рисунков по методу множеств
        /// </summary>
        /// <param name="pImage"></param>
        /// <returns></returns>
        public List<Bitmap> SplitBySetToImages(Bitmap pImage)
        {
            List<byte[][]> lMatrixList = SplitBySet(pImage);
            List<Bitmap> lImages = CBlackWhiteExplorer.BinaryMatrixListToBitmapList(lMatrixList);
            return lImages;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// разбить рисунок на отдельные куски 
        /// в виде списка рисунков по методу матриц
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="pWhat"></param>
        /// <returns></returns>
        public List<Bitmap> SplitByMatrixToImages(Bitmap pImage, byte pWhat)
        {
            List<byte[][]> lMatrixList = SplitByMatrix(pImage, pWhat);
            List<Bitmap> lImages = CBlackWhiteExplorer.BinaryMatrixListToBitmapList(lMatrixList);
            return lImages;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// разбить рисунок(в виде матрицы) на отдельные куски 
        /// в виде списка матриц по методу множеств
        /// 
        /// </summary>
        /// <param name="pMatrix"></param>
        /// <returns></returns>
        public List<byte[][]> SplitBySet(byte[][] pMatrix)
        {
            List<CSetPoint> lContainnigSets = new List<CSetPoint>();
            fSets.Clear();

            for (int i = 0; i < pMatrix.Length; i++)
                for (int j = 0; j < pMatrix[i].Length; j++)
                    if (pMatrix[i][j] == 1)
                    {
                        lContainnigSets.Clear();
                        CPoint lCurrentPoint = new CPoint(i, j);
                        foreach (CSetPoint setpoint in fSets)
                            if (setpoint.ContainNeighborhood(lCurrentPoint))
                                lContainnigSets.Add(setpoint);
                        if (lContainnigSets.Count > 0)
                        {
                            lContainnigSets[0].Add(lCurrentPoint);
                            if (lContainnigSets.Count > 1)
                            {
                                for (int k = 1; k < lContainnigSets.Count; k++)
                                    lContainnigSets[0].AddSetPoint(lContainnigSets[k]);
                                for (int k = 1; k < lContainnigSets.Count; k++)
                                    fSets.Remove(lContainnigSets[k]);
                            }
                        }
                        else
                        {
                            CSetPoint lNewSet = new CSetPoint();
                            lNewSet.Add(lCurrentPoint);
                            fSets.Add(lNewSet);
                        }
                    }

                    return null;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// разбить рисунок(в виде матрицы) на отдельные куски 
        /// в виде списка матриц по методу матриц
        /// 
        /// </summary>
        /// <param name="pMatrix"></param>
        /// <param name="pWhat"></param>
        /// <returns></returns>
        public List<byte[][]> SplitByMatrix(byte[][] pMatrix, byte pWhat)
        {
            // временный набаор матриц смежных с текущей текущей точкой
            List<byte[][]> lContainnigSets = new List<byte[][]>();
            fSetsOfMatrix.Clear();

            // проходим все точки матрицы одна за одной
            for (int i = 0; i < pMatrix.Length; i++)
                for (int j = 0; j < pMatrix[i].Length; j++)
                    if (pMatrix[i][j] == pWhat)
                    {
                        lContainnigSets.Clear();
                        // текущая точка
                        CPoint lCurrentPoint = new CPoint(i, j);
                        // определяем смежные матрицы
                        foreach (byte[][] lMatrix in fSetsOfMatrix)
                        {
                            //  если одна из смежных точек принадлежит к текущей матрице
                            // добавляем эту матрицу во временный список
                            if (i > 0 && lMatrix[i-1][j] == pWhat || 
                                i < lMatrix.Length-1 && lMatrix[i+1][j] == pWhat ||
                                i > 0 && j >0 && lMatrix[i-1][j-1] == pWhat ||
                                j > 0 && lMatrix[i][j - 1] == pWhat ||
                                i < lMatrix.Length - 1 && j > 0 && lMatrix[i + 1][j - 1] == pWhat ||
                                i > 0 && j < lMatrix[i - 1].Length-1 && lMatrix[i - 1][j + 1] == pWhat ||
                                j < lMatrix[i].Length-1 && lMatrix[i][j + 1] == pWhat ||
                                i < lMatrix.Length - 1 && j < lMatrix[i +1].Length-1 && lMatrix[i + 1][j + 1] == pWhat)
                                lContainnigSets.Add(lMatrix);
                        }

                        if (lContainnigSets.Count > 0)
                        {
                            // к первой смежной матрице добавляем текщюю точку
                            lContainnigSets[0][i][j] = pWhat;
                            // остальные матрицы удаляем если они есть
                            if (lContainnigSets.Count > 1)
                            {
                                for (int k = 1; k < lContainnigSets.Count; k++)
                                    for (int m = 0; m < lContainnigSets[0].Length; m++)
                                        for (int n = 0; n < lContainnigSets[0][m].Length; n++)
                                            if (pWhat == 1)
                                                lContainnigSets[0][m][n] |= lContainnigSets[k][m][n];
                                            else
                                                lContainnigSets[0][m][n] &= lContainnigSets[k][m][n];
                                for (int k = 1; k < lContainnigSets.Count; k++)
                                    fSetsOfMatrix.Remove(lContainnigSets[k]);
                            }
                        }
                            // если не было смежных матриц в списке уже созданных
                        else 
                        {
                            // то дабавляем новую матрицу в список
                            byte[][] lNewMatrix = new byte[pMatrix.Length][];
                            // в новой матрице все элементы нулевые кроме текущей точки
                            for (int k = 0; k < pMatrix.Length; k++)
                            {
                                lNewMatrix[k] = new byte[pMatrix[k].Length];
                                for (int l = 0; l < pMatrix[i].Length; l++)
                                {
                                    lNewMatrix[k][l] = pWhat == (byte)1 ? (byte)0 : (byte)1;
                                }
                            }
                            // только текущая точка рана 1
                            lNewMatrix[i][j] = pWhat;
                            fSetsOfMatrix.Add(lNewMatrix);
                        }
                    }

            return fSetsOfMatrix;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Разбиение множества ненулевых точек матрицы на связанные группы
        /// каждая группа в новой матрице помечается своим цветом
        /// </summary>
        /// <param name="pMatrix">входящая матрица для разбиения</param>
        /// <param name="pNumberColor">число цветов в выходной матрице</param>
        /// <returns>выходная матрица с помеченными связнными группами</returns>
        public int[][] SplitByOneMatrix(byte[][] pMatrix,out int pNumberColor)
        {
            // новая матрица с помеченными связнными группами
            // ненулевые точки будем менять на цвета соседних точек или присваивать новый цвет 
            // если у точки нет ненулевых соседей
            int[][] lNewMatrix = new int[pMatrix.Length][];
            // первый цвет в новой матрице
            byte lCurColor = (byte)0;
            // 
            List<int> lActColors = new List<int>(10);
            lActColors.Add(1);
            for (int k = 0; k < pMatrix.Length; k++)
            {
                // очередная строка в новой матрице
                lNewMatrix[k] = new int[pMatrix[k].Length];
                for (int l = 0; l < pMatrix[k].Length; l++)
                {
                    lNewMatrix[k][l] = 0;
                }
            }

            // просматриваем последовательно все элементы входящей матрицы
            for (int k = 0; k < pMatrix.Length; k++)
            {
                for (int l = 0; l < pMatrix[k].Length; l++)
                {
                    if (pMatrix[k][l] == 0)
                    {
                        lNewMatrix[k][l] = 0;
                        continue;
                    }
                    // список цветов соседей
                    // будем добавлять в список все цвета которые встретятся 
                    // среди соседей данной точки 
                    List<int> lNeighColors = new List<int>(8);
                    // просматриваем все соседние точки и проверяем 
                    // всех соседей не равных 0
                    // если такой цвет еще не присутствует в списке 
                    // то добавляем его в список цветов соседей
                    if (k > 0 && lNewMatrix[k - 1][l] != 0 && !lNeighColors.Contains(lNewMatrix[k - 1][l]))
                        lNeighColors.Add(lNewMatrix[k - 1][l]);
                    if (k < lNewMatrix.Length - 1 && lNewMatrix[k + 1][l] != 0 && !lNeighColors.Contains(lNewMatrix[k + 1][l]))
                        lNeighColors.Add(lNewMatrix[k + 1][l]);
                    if (k > 0 && l > 0 && lNewMatrix[k - 1][l - 1] != 0 && !lNeighColors.Contains(lNewMatrix[k - 1][l - 1]))
                        lNeighColors.Add(lNewMatrix[k - 1][l - 1]);
                    if (l > 0 && lNewMatrix[k][l - 1] != 0 && !lNeighColors.Contains(lNewMatrix[k][l - 1]))
                        lNeighColors.Add(lNewMatrix[k][l - 1]);
                    if (k < lNewMatrix.Length - 1 && l > 0 && lNewMatrix[k + 1][l - 1] != 0 && !lNeighColors.Contains(lNewMatrix[k + 1][l - 1]))
                        lNeighColors.Add(lNewMatrix[k + 1][l - 1]);
                    if (k > 0 && l < lNewMatrix[k - 1].Length - 1 && lNewMatrix[k - 1][l + 1] != 0 && !lNeighColors.Contains(lNewMatrix[k - 1][l + 1]))
                        lNeighColors.Add(lNewMatrix[k - 1][l + 1]);
                    if (l < lNewMatrix[k].Length - 1 && lNewMatrix[k][l + 1] != 0 && !lNeighColors.Contains(lNewMatrix[k][l + 1]))
                        lNeighColors.Add( lNewMatrix[k][l + 1]);
                    if (k < lNewMatrix.Length - 1 && l < lNewMatrix[k + 1].Length - 1 && lNewMatrix[k + 1][l + 1] != 0 && !lNeighColors.Contains(lNewMatrix[k + 1][l + 1]))
                        lNeighColors.Add(lNewMatrix[k + 1][l + 1]);

                    // если есть соседи
                    if (lNeighColors.Count != 0)
                    {
                        // присваиваем текущей точке первый цвет из списка цветов соседей
                        lNewMatrix[k][l] = lNeighColors[0];
                        // если в списке только один цвет те все соседи одного цвета
                        // то больше ничего делать не надо
                        if (lNeighColors.Count > 1) // если в списке более одного цвета
                        {                           // то данная точка является связующей
                                                    // между несколькими группами точек
                                                    // которые до этого были несвязанны
                                                    // объединяем их в один цвет(первый)
                            // просматриваем все точки новой матрицы
                            for (int i = 0; i < lNewMatrix.Length; i++)
                                for (int j = 0; j < lNewMatrix[i].Length; j++)
                                {
                                    // если точка имеет цвет из списка цветов соседей кроме первого
                                    // то пменяем цвет на первый из списка
                                    for (int s = 1; s < lNeighColors.Count; s++)
                                        if (lNewMatrix[i][j] == lNeighColors[s])
                                        {
                                            lNewMatrix[i][j] = lNeighColors[0];
                                            break;
                                        }
                                }
                            // в спмске задействованных счетов отмечаем что данные цвета больше
                            // не задействованны в новой матрице
                            for (int s = 1; s < lNeighColors.Count; s++)
                                lActColors[lNeighColors[s] - 1] = 0;
                            //                        lActColors &= ~(1 << lNeighColors[s]);
                        }
                        lNeighColors.Clear();
                    }
                    else
                    {       // если нет соседей
                        // добавляем новый цвет в матрицу
                        lActColors.Add(1); // пополняем список задействованных цветов
                        lNewMatrix[k][l] = ++lCurColor;     // текущий элемент будет нового цвета
                    }
                }
            }
            // так как некоторые цвета могут быть удалены из списка и в перечне задействованных
            // в матрице цветов образуются дыры Надо сдвинуть номера цветов
            // чтобы они шли подряд
            // создаем массив соотвествий между старыми и новыми цветами
            // если дыр нет то старые и новые номера равны
            int[] lReferList = new int[lActColors.Count];
            // нумерация цветов которые задействованы те не равны 0 - для новых номеров
            int lAliveCount = 0;
            for (int i = 0; i < lActColors.Count; i++)
            {
                // если цвет есть присваиваем ему очередной номер (старый номер - позиция в массиве)
                if (lActColors[i] != 0)
                    lReferList[i] = ++lAliveCount;
                else
                    lReferList[i] = 0; // если цвета то переменную с новой нумерацией не трогаем
            }
            // меняем ситарые номера цветов на новые
            for (int i = 0; i < lNewMatrix.Length; i++)
                for (int j = 0; j < lNewMatrix[i].Length; j++)
                {
                    if (lNewMatrix[i][j] > 0)
                        lNewMatrix[i][j] = lReferList[lNewMatrix[i][j] - 1];
                }
            pNumberColor = lAliveCount;
            return lNewMatrix;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// разбиение рисунка на части - по одной для каждого цвета
        /// </summary>
        /// <param name="pPicture">входной рисунок для разбиения</param>
        /// <returns>выходной список рисунков - в каждом только один цвет</returns>
        public Dictionary<Color, Bitmap> SplitImageByColor(Bitmap pPicture)
        {
            Dictionary<Color, Bitmap> lOutList = new Dictionary<Color, Bitmap>();
            for (int i = 0; i < pPicture.Width; i++)
            {
                for (int j = 0; j < pPicture.Height; j++)
                {
                    Color lColor = pPicture.GetPixel(i, j);
                    if (!lOutList.ContainsKey(lColor))
                    {
                        Color lBackColor = CImageSplitter.DefineBestBackColor(lColor);
                        Bitmap lNewPicture = new Bitmap(pPicture.Width,pPicture.Height);
                        lOutList.Add(lColor, lNewPicture);
                        for (int l = 0; l < lNewPicture.Width; l++)
                            for (int k = 0; k < lNewPicture.Height; k++)
                                lNewPicture.SetPixel(l,k,lBackColor);
                    }
                    lOutList[lColor].SetPixel(i,j,lColor);
                }
            }
            return lOutList;
        }
        //--------------------------------------------------------------------------------------
        public static Color DefineBestBackColor(Color pColor)
        {
            Color lBackColor = Color.FromArgb(0, 0, 0);
            if (pColor.R + pColor.G + pColor.B < 381)
                lBackColor = Color.FromArgb(255, 255, 255);
            return lBackColor;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        ///  получить обратную матрицу из исходной 0->1  1->0
        /// </summary>
        /// <param name="pMatrix">исходная матрица</param>
        /// <returns>обращеннаятрица</returns>
        public byte[][] InverseMatrix(byte[][] pMatrix)
        {
            byte[][] lOutMatrix = new byte[pMatrix.Length][];
            for (int i = 0; i < pMatrix.Length; i++)
            {
                lOutMatrix[i] = new byte[pMatrix[i].Length];
                for (int j = 0; j < pMatrix[i].Length; j++)
                    if (pMatrix[i][j] == (byte)0)
                        lOutMatrix[i][j] = (byte)1;
                    else
                        lOutMatrix[i][j] = (byte)0;
            }
            return lOutMatrix;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// объединение матриц
        /// </summary>
        /// <param name="pList">список объединяемых матриц</param>
        /// <param name="pBackGround">цвет фона</param>
        /// <returns>итоговая матрица полученная в результате объединения</returns>
        public byte[][] UnionMatrix(List<byte[][]> pList, byte pBackGround)
        {
            int lLength0 = 0;
            int lLength1 = 0;
            // определить размеры результирующей матрицы так чтобы она была не  меньше
            // каждого из своих слагаемых
            foreach (byte[][] lMatrix in pList)
            {
                if (lMatrix.Length > lLength0)
                    lLength0 = lMatrix.Length;
                foreach (byte[] lVector in lMatrix)
                    if (lVector.Length > lLength1)
                        lLength1 = lVector.Length;
            }

            // создать и заполнить для начала фоновым цветом
            byte [][] lOutMatrix = new byte[lLength0][];
            for (int i = 0; i < lOutMatrix.Length; i++)
            {
                lOutMatrix[i] = new byte[lLength1];
                for (int j = 0; j < lOutMatrix[i].Length; j++)
                    lOutMatrix[i][j] = pBackGround;
            }
            // перенести все нефоновые точки из всех мариц в итоговую
            foreach (byte[][] lMatrix in pList)
            {
                for (int i = 0; i < lMatrix.Length; i++)
                    for (int j = 0; j < lMatrix[i].Length; j++)
                        if (lMatrix[i][j] != pBackGround)
                            lOutMatrix[i][j] = lMatrix[i][j];
            }
            return lOutMatrix;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// удалить маленькие области из картинки (предварительно преобразовав ее в 0.1 матрицу)
        /// предельный размер удаляемых множеств задается по умолчанию
        /// </summary>
        /// <param name="pImage">картинка для преобразования</param>
        /// <param name="pWhat">цвет рисунка</param>
        /// <returns>результирующая матрица очищенная от маленьких связанных областей</returns>
        public byte[][] RemoveSmallRegion(Bitmap pImage, byte pWhat)
        {
            byte[][] lMatrix = CBlackWhiteExplorer.BitmapToBinaryMatrix(pImage);
            return RemoveSmallRegion(lMatrix, pWhat, SmallThreshold);
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// удалить маленькие области из двоичной матрицы
        /// предельный размер удаляемых множеств задается по умолчанию
        /// </summary>
        /// <param name="pMatrix">матрица для преобразования</param>
        /// <param name="pWhat">цвет рисунка</param>
        /// <returns>результирующая матрица очищенная от маленьких связанных областей</returns>
        public byte[][] RemoveSmallRegion(byte[][] pMatrix, byte pWhat)
        {
            return RemoveSmallRegion(pMatrix, pWhat, SmallThreshold);
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// удалить маленькие области из картинки (предварительно преобразовав ее в 0.1 матрицу)
        /// </summary>
        /// <param name="pImage">картинка для преобразования</param>
        /// <param name="pWhat">цвет рисунка</param>
        /// <param name="pThreshold">предельный размер удаляемых</param>
        /// <returns>результирующая матрица очищенная от маленьких связанных областей</returns>
        public byte[][] RemoveSmallRegion(Bitmap pImage, byte pWhat, int pThreshold)
        {
            byte[][] lMatrix = CBlackWhiteExplorer.BitmapToBinaryMatrix(pImage);
            return RemoveSmallRegion(lMatrix, pWhat, pThreshold);
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// удалить маленькие области из двоичной матрицы
        /// </summary>
        /// <param name="pMatrix">матрица для преобразования</param>
        /// <param name="pWhat">цвет рисунка</param>
        /// <param name="pThreshold">предельный размер удаляемых</param>
        /// <returns>результирующая матрица очищенная от маленьких связанных областей</returns>
        public byte[][] RemoveSmallRegion(byte[][] pMatrix, byte pWhat, int pThreshold)
        {
            // разделить матрицу на связанные области
            // поместив каждую область в отдельную матрицу
            List<byte[][]> lList = SplitByMatrix(pMatrix,pWhat);
            // проверить каждую матрицу в списке и удалить те
            // которые содержат "мало" элементов
            for (int i = lList.Count - 1; i >= 0; i--)
                if (TestForSmall(lList[i], pWhat, pThreshold))
                    lList.RemoveAt(i);
            // объединить матрицы очищенного списка
            byte[][] lMatrix = UnionMatrix(lList, pWhat == (byte)0 ? (byte)1 : (byte)0);
            return lMatrix;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// удалить маленькие области из цветной матрицы
        /// </summary>
        /// <param name="pMatrix">матрица для преобразования</param>
        /// <param name="pBackColor">фоновый цвет</param>
        /// <param name="pThreshold">предельный размер удаляемых</param>
        /// <returns>результирующая матрица очищенная от маленьких связанных областей</returns>
        public byte[][] RemoveSmallFromColorMatrix(byte[][] pMatrix, byte pBackColor, int pThreshold)
        {
            // создать новую матрицу чтобы не трогать входную
            byte[][] lMatrix = new byte[pMatrix.Length][];
            for (int i = 0; i < pMatrix.Length; i++)
            {
                lMatrix[i] = new byte[pMatrix[i].Length];
                for (int j = 0; j < pMatrix[i].Length; j++)
                    lMatrix[i][j] = pMatrix[i][j];
            }
            // сформировать список цветов встречающихся в матрице при это для каждого
            // цвета посчитать частоту вхождения в матрицу
            Dictionary<int, int> lColorPresent = new Dictionary<int, int>();
            for (int i = 0; i < lMatrix.Length; i++ )
                for (int j = 0; j < lMatrix[i].Length; j++)
                    if (lMatrix[i][j] != pBackColor)
                    {
                        if (lColorPresent.ContainsKey(lMatrix[i][j]))
                            lColorPresent[lMatrix[i][j]] += 1;
                        else
                            lColorPresent.Add(lMatrix[i][j],1);
                    }
                // проверить каждый цвет в списке и удалить те
                // которые содержат "мало" элементов
            for (int i = 0; i < lMatrix.Length; i++)
                for (int j = 0; j < lMatrix[i].Length; j++)
                    if (lMatrix[i][j] != pBackColor)
                        if (lColorPresent[lMatrix[i][j]] <= pThreshold)
                            lMatrix[i][j] = pBackColor;
            return pMatrix;
        }
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// проверка данного цвета в матрице на большое/малое количество
        /// </summary>
        /// <param name="pMatrix">проверяемая матрица</param>
        /// <param name="pWhat">проверяемый цвет</param>
        /// <param name="pThreshold">критерий предельное число меньше которого 
        /// количество точек считается малым</param>
        /// <returns>truy если точек заданного цвета мало</returns>
        private bool TestForSmall(byte[][] pMatrix, byte pWhat, int pThreshold)
        {
            // счимаем количество точек заданного цветв в матрице
            int lQnt = 0;
            foreach (byte[] lVector in pMatrix)
                foreach (byte lElement in lVector)
                    if (lElement == pWhat)
                        lQnt++;
            // если меньше заданного критерия то количество считаем малым - маленькая область
            if (lQnt > pThreshold)
                return false;
            return true;
        }
        //--------------------------------------------------------------------------------------
        // Class CSetPoint
        //--------------------------------------------------------------------------------------
        public class CSetPoint : List<CPoint>
        {
            //--------------------------------------------------------------------------------------
            public CSetPoint()
                : base()
            {
            }
            //--------------------------------------------------------------------------------------
            public bool ContainNeighborhood(CPoint pp)
            {
                foreach (CPoint p in this)
                    if (pp.IsNeighborhood(p))
                        return true;
                return false;
            }
            //--------------------------------------------------------------------------------------
            public void AddSetPoint(CSetPoint pOtherSet)
            {
                foreach (CPoint lPoint in pOtherSet)
                    Add(lPoint);
            }
            //--------------------------------------------------------------------------------------
            public byte[][] ToMatrix(int pWidth, int pHeght)
            {
                byte [][] lMatrix = new byte[pWidth][];
                for (int i = 0; i < lMatrix.Length; i++)
                {
                    lMatrix[i] = new byte[pHeght];
                    for (int j = 0; j < lMatrix[i].Length; j++)
                        lMatrix[i][j] = 0;
                }
                foreach(CPoint lPoint in this)
                    lMatrix[lPoint.X][lPoint.Y] = 1;
                return lMatrix;
            }
            //--------------------------------------------------------------------------------------
            static public List<byte[][]> EdgeSetListToMatrixList(List<CSetPoint> pList, int pWidth, int pHeght)
            {
                List<byte[][]> lMatrixList = new List<byte[][]>();
                foreach ( CSetPoint lSetPoint in pList)
                    lMatrixList.Add(lSetPoint.ToMatrix(pWidth, pHeght));
                return lMatrixList;
            }
            //--------------------------------------------------------------------------------------
        }
        //--------------------------------------------------------------------------------------
        // struct CPoint
        //--------------------------------------------------------------------------------------
        public struct CPoint : IEquatable<CPoint>
        {
            public int X;
            public int Y;
            //--------------------------------------------------------------------------------------
            public CPoint(int px, int py)
            {
                X = px;
                Y = py;
            }
            //--------------------------------------------------------------------------------------
            public bool IsNeighborhood(CPoint pp)
            {
                if (Math.Abs(X - pp.X) <= 1 && Math.Abs(Y - pp.Y) <= 1)
                    return true;
                return false;
            }
            //--------------------------------------------------------------------------------------
            public bool Equals(CPoint pp)
            {
                if (pp.X == X && pp.Y == Y)
                    return true;
                return false;
            }
            //--------------------------------------------------------------------------------------
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
