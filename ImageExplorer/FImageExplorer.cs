using System;
using System.Threading;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageExplorer
{
    //--------------------------------------------------------------------------------------
    // class FImageExplorer
    //--------------------------------------------------------------------------------------
    public partial class FImageExplorer : Form, IClearComareForm
    {
        private Bitmap bmpOriginal;
        private Bitmap bmpBW;
        private Bitmap bmpRefine;
        private CBlackWhiteExplorer fBlackWhiteExplorer;
        private byte[][] fMatrixAfterClean = null;
//        private byte[][] fMatrixAfterClean = null;
//        private byte[][] flMatrixAfterClean = null;
        private FCompare2Image fCompare2Image = null;
        private FCompare3Image fCompare3Image = null;
        private PictureBox fPictureFocus = null;
        //--------------------------------------------------------------------------------------
        public FImageExplorer()
        {
            InitializeComponent();
            tsbExec.Image = ilCom.Images[0];
            tsbBWExec.Image = ilCom.Images[0];
            tsbByRed.Image = ilCom.Images[4];
            tsbByBlue.Image = ilCom.Images[2];
            tsbByGreen.Image = ilCom.Images[3];
            tsbShadow.Image = ilCom.Images[8];
            tsbShadowRed.Image = ilCom.Images[7];
            tsbShadowBlue.Image = ilCom.Images[5];
            tsbShadowGreen.Image = ilCom.Images[6];
            tsbClean.Image = ilCom.Images[9];
            tsbCleanAccurate.Image = ilCom.Images[10];
            tsbCleanAccurateDefault.Image = ilCom.Images[11];
            tsbCleanSplit.Image = ilCom.Images[13];
            tsbCleanExactSplit.Image = ilCom.Images[13];
            tsbCleanExactDefaultSplit.Image = ilCom.Images[13];
            tsbColorSplit.Image = ilCom.Images[14];
            tsbSplitByColor.Image = ilCom.Images[15];
            tsbSplitByColorResult.Image = ilCom.Images[15];
            fBlackWhiteExplorer = new CBlackWhiteExplorer();
            tscbTypeSplit.SelectedIndex = 0;
            cbClearColor.SelectedIndex = 0;
            txtA0.Text = "1.0";
            txtA1.Text = Math.Round(1.0 / Math.Sqrt(2.0), 3).ToString();
            txtB0.Text = "0.5";
            txtB1.Text = Math.Round(1.0 / Math.Sqrt(5.0), 3).ToString();
            txtB2.Text = Math.Round(1.0 / Math.Sqrt(8.0), 3).ToString();
            txtLimit.Text = "0.26";
            cbClearColor.SelectedIndex = 1;
            lShow.BackColor = Color.Black;
            toolStrip2.Visible = true;
            toolStrip5.Visible = true;
            tabControl1.SelectedIndex = 1;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("");
        }
        //--------------------------------------------------------------------------------------
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
        //--------------------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            if (opdPicture.ShowDialog() == DialogResult.OK)
                txtBWFile.Text = opdPicture.FileName;
        }

        //--------------------------------------------------------------------------------------
        private void tsbBWExec_Click(object sender, EventArgs e)
        {

            
            try
            {
                bmpOriginal = new Bitmap(txtBWFile.Text);
                bmpBW = new Bitmap(txtBWFile.Text);
                pbSource.Image = bmpOriginal;
                pbBlackWhite.Image = bmpBW;
                int[][] lCentres = fBlackWhiteExplorer.DefineCentres(bmpOriginal, (TypeDivisionEnum)tscbTypeSplit.SelectedIndex);
                txtRedMin.Text = lCentres[0][0].ToString();
                txtRedMax.Text = lCentres[0][1].ToString();
                txtGreenMin.Text = lCentres[1][0].ToString();
                txtGreenMax.Text = lCentres[1][1].ToString();
                txtBlueMin.Text = lCentres[2][0].ToString();
                txtBlueMax.Text = lCentres[2][1].ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            if (fPictureFocus != null)
                fPictureFocus.BackColor = System.Drawing.SystemColors.Control;
            fPictureFocus = pbSource;
            if (fPictureFocus != null)
                fPictureFocus.BackColor = Color.FromArgb(224, 224, 224);
        }
        //--------------------------------------------------------------------------------------
        private void tsbByRed_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = pbSource.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                Bitmap lBmp = fBlackWhiteExplorer.PictureToBlackWhite(lInBmp, 1);
                pbBlackWhite.Image = lBmp;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbByGreen_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = pbSource.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                Bitmap lBmp = fBlackWhiteExplorer.PictureToBlackWhite(lInBmp, 2);
                pbBlackWhite.Image = lBmp;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbByBlue_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = pbSource.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                Bitmap lBmp = fBlackWhiteExplorer.PictureToBlackWhite(lInBmp, 3);
                pbBlackWhite.Image = lBmp;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbShadow_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = pbSource.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                Bitmap lBmp = fBlackWhiteExplorer.PictureToShadow(lInBmp, 0);
                pbBlackWhite.Image = lBmp;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbShadowRed_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = pbSource.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                Bitmap lBmp = fBlackWhiteExplorer.PictureToShadow(lInBmp, 1);
                pbBlackWhite.Image = lBmp;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbShadowGreen_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = pbSource.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                Bitmap lBmp = fBlackWhiteExplorer.PictureToShadow(lInBmp, 2);
                pbBlackWhite.Image = lBmp;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbShadowBlue_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = pbSource.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                Bitmap lBmp = fBlackWhiteExplorer.PictureToShadow(lInBmp, 3);
                pbBlackWhite.Image = lBmp;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void FImageExplorer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ImageExplorer.Properties.Settings.Default.Save();
        }
        //--------------------------------------------------------------------------------------
        private void tsbClean_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = pbBlackWhite.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                byte[][] lMatrix = CBlackWhiteExplorer.BitmapToBinaryMatrix(lInBmp);
                if (cbClearColor.SelectedIndex < 3)
                    CBlackWhiteExplorer.RemoveIsolatePoint(lMatrix, (byte)cbClearColor.SelectedIndex);
                else if (cbClearColor.SelectedIndex == 3)
                {
                    CBlackWhiteExplorer.RemoveIsolatePoint(lMatrix, 0);
                    CBlackWhiteExplorer.RemoveIsolatePoint(lMatrix, 1);
                }
                else
                {
                    CBlackWhiteExplorer.RemoveIsolatePoint(lMatrix, 1);
                    CBlackWhiteExplorer.RemoveIsolatePoint(lMatrix, 0);
                }

                Bitmap lNewBmp = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrix);
                pbAfterClean.Image = lNewBmp;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbCleanAcurate_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = pbBlackWhite.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                byte[][] lMatrix = CBlackWhiteExplorer.BitmapToBinaryMatrix(lInBmp);
                if (cbClearColor.SelectedIndex < 3)
                    CBlackWhiteExplorer.RemoveIsolatePointAccurate(lMatrix, (byte)cbClearColor.SelectedIndex, double.Parse(txtLimit.Text),
                    double.Parse(txtA0.Text), double.Parse(txtA1.Text), double.Parse(txtB0.Text),
                    double.Parse(txtB1.Text), double.Parse(txtB2.Text));
                else if (cbClearColor.SelectedIndex == 3)
                {
                    CBlackWhiteExplorer.RemoveIsolatePointAccurate(lMatrix, 0, double.Parse(txtLimit.Text),
                    double.Parse(txtA0.Text), double.Parse(txtA1.Text), double.Parse(txtB0.Text),
                    double.Parse(txtB1.Text), double.Parse(txtB2.Text));
                    CBlackWhiteExplorer.RemoveIsolatePointAccurate(lMatrix, 1, double.Parse(txtLimit.Text),
                    double.Parse(txtA0.Text), double.Parse(txtA1.Text), double.Parse(txtB0.Text),
                    double.Parse(txtB1.Text), double.Parse(txtB2.Text));
                }
                else
                {
                    CBlackWhiteExplorer.RemoveIsolatePointAccurate(lMatrix, 1, double.Parse(txtLimit.Text),
                    double.Parse(txtA0.Text), double.Parse(txtA1.Text), double.Parse(txtB0.Text),
                    double.Parse(txtB1.Text), double.Parse(txtB2.Text));
                    CBlackWhiteExplorer.RemoveIsolatePointAccurate(lMatrix, 0, double.Parse(txtLimit.Text),
                    double.Parse(txtA0.Text), double.Parse(txtA1.Text), double.Parse(txtB0.Text),
                    double.Parse(txtB1.Text), double.Parse(txtB2.Text));
                }
                Bitmap lNewBmp = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrix);
                pbAfterCleanExact.Image = lNewBmp;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }
        //--------------------------------------------------------------------------------------
        private void tsbCleanAccurateDefault_Click(object sender, EventArgs e)
        {

            try
            {
                Bitmap lInBmp = pbBlackWhite.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                byte[][] lMatrix = CBlackWhiteExplorer.BitmapToBinaryMatrix(lInBmp);
                if (cbClearColor.SelectedIndex < 3)
                    CBlackWhiteExplorer.RemoveIsolatePointAccurate(lMatrix, (byte)cbClearColor.SelectedIndex);
                else if (cbClearColor.SelectedIndex == 3)
                {
                    CBlackWhiteExplorer.RemoveIsolatePointAccurate(lMatrix, 0);
                    CBlackWhiteExplorer.RemoveIsolatePointAccurate(lMatrix, 1);
                }
                else
                {
                    CBlackWhiteExplorer.RemoveIsolatePointAccurate(lMatrix, 1);
                    CBlackWhiteExplorer.RemoveIsolatePointAccurate(lMatrix, 0);
                }
                Bitmap lNewBmp = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrix);
                pbAfterCleanExactDefault.Image = lNewBmp;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbRemoveSmall_Click(object sender, EventArgs e)
        {
            try
            {
                CImageSplitter lImageSplitter = new CImageSplitter();
                if (pbAfterClean.Image != null)
                {
                    fMatrixAfterClean = lImageSplitter.RemoveSmallRegion(pbAfterClean.Image as Bitmap, (byte)cbClearColor.SelectedIndex,int.Parse( txtThreshold.Text));
                    Bitmap lNewBmp = CBlackWhiteExplorer.BinaryMatrixToBitmap(fMatrixAfterClean);
                    pbAfterClean_RL.Image = lNewBmp;
                }
                if (pbAfterCleanExact.Image != null)
                {
                    fMatrixAfterClean = lImageSplitter.RemoveSmallRegion(pbAfterCleanExact.Image as Bitmap, (byte)cbClearColor.SelectedIndex,int.Parse(txtThreshold.Text));
                    Bitmap lNewBmp = CBlackWhiteExplorer.BinaryMatrixToBitmap(fMatrixAfterClean);
                    pbAfterCleanExact_RL.Image = lNewBmp;
                }
                if (pbAfterCleanExactDefault.Image != null)
                {
                    fMatrixAfterClean = lImageSplitter.RemoveSmallRegion(pbAfterCleanExactDefault.Image as Bitmap, (byte)cbClearColor.SelectedIndex, int.Parse(txtThreshold.Text));
                    Bitmap lNewBmp = CBlackWhiteExplorer.BinaryMatrixToBitmap(fMatrixAfterClean);
                    pbAfterCleanExactDefault_RL.Image = lNewBmp;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Bitmap lInBmp = pbAfterClean_RL.Image as Bitmap;
            if (lInBmp == null)
            {
                MessageBox.Show("Нет картинки");
                return;
            }
            pbAfterCleanColor.Image = CommonSplit(lInBmp);
        }
        //--------------------------------------------------------------------------------------
        private Bitmap CommonSplit(Bitmap pInBitmap)
        {
            byte lWhat = (byte)cbClearColor.SelectedIndex;
            CImageSplitter lImageSplitter = new CImageSplitter();
            FLookSeparatePart form = new FLookSeparatePart();
            List<byte[][]> lMatrixList = lImageSplitter.SplitByMatrix(pInBitmap, lWhat);
            List<Bitmap> lImages = CBlackWhiteExplorer.BinaryMatrixListToBitmapList(lMatrixList);
            form.PictureList = lImages;
            for (int i = 0; i < lMatrixList.Count; i++)
            {
                int lNumber = i;
                int lQuantity = 0;
                int lQuantityAll = 0;
                int lCentreX = 0;
                int lCentreY = 0;
                byte[][] lMatrix = lMatrixList[i];
                for (int n = 0; n < lMatrix.Length; n++)
                {
                    lQuantityAll += lMatrix[n].Length;
                    for (int m = 0; m < lMatrix[n].Length; m++)
                    {
                        if (lMatrix[n][m] == lWhat)
                        {
                            lQuantity++;
                            lCentreX += n;
                            lCentreY += m;
                        }
                    }
                }
                lCentreX /= lQuantityAll;
                lCentreY /= lQuantityAll;
                form.imageListDataSet1.Images.AddImagesRow(lNumber, lQuantity,
                    lCentreX, lCentreY, "", 0);
            }
            form.Show();
            int[][] lColorMatrix = CBlackWhiteExplorer.BinaryMatrixListToColorMatrix(lMatrixList, lWhat);
            Bitmap lColorImage = CBlackWhiteExplorer.ColorMatrixToColorBitmap(lColorMatrix, lMatrixList.Count);
//            pbAfterCleanColor.Image = lColorImage;
            return lColorImage;
        }

        //--------------------------------------------------------------------------------------
        private void tsbColorSplit_Click(object sender, EventArgs e)
        {
            try
            {
                byte lWhat = (byte)cbClearColor.SelectedIndex;
                CImageSplitter lImageSplitter = new CImageSplitter();
                if (pbAfterClean_RL.Image != null)
                {
                    Bitmap lNewBmp = CBlackWhiteExplorer.BWImageToColorImage(pbAfterClean_RL.Image as Bitmap, lWhat);
                    pbAfterCleanColor.Image = lNewBmp;
                }
                if (pbAfterCleanExact_RL.Image != null)
                {
                    Bitmap lNewBmp = CBlackWhiteExplorer.BWImageToColorImage(pbAfterCleanExact_RL.Image as Bitmap, lWhat);
                    pbAfterCleanExactColor.Image = lNewBmp;
                }
                if (pbAfterCleanExactDefault_RL.Image != null)
                {
                    Bitmap lNewBmp = CBlackWhiteExplorer.BWImageToColorImage(pbAfterCleanExactDefault_RL.Image as Bitmap, lWhat);
                    pbAfterCleanExactDefaultColor.Image = lNewBmp;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }
        //--------------------------------------------------------------------------------------
        private void tsbCleanExactDefaultSplit_Click(object sender, EventArgs e)
        {
            Bitmap lInBmp = pbAfterCleanExactDefault_RL.Image as Bitmap;
            if (lInBmp == null)
            {
                MessageBox.Show("Нет картинки");
                return;
            }
            pbAfterCleanExactDefaultColor.Image = CommonSplit(lInBmp);
        }
        //--------------------------------------------------------------------------------------
        private void tsbCleanExactSplit_Click(object sender, EventArgs e)
        {
            Bitmap lInBmp = pbAfterCleanExact_RL.Image as Bitmap;
            if (lInBmp == null)
            {
                MessageBox.Show("Нет картинки");
                return;
            }
            pbAfterCleanExactColor.Image = CommonSplit(lInBmp);
        }
        //--------------------------------------------------------------------------------------
        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int lWishColors = Convert.ToInt32(tstWishfulColos.Text);
                Color[] lRealColors = CBlackWhiteExplorer.DefineNeedColor(lWishColors);
                Color[] lFinalColors = CBlackWhiteExplorer.DefineExactNeedColor(lWishColors);
                tstSatisfColor.Text = lRealColors.Length.ToString();
                flpColors.Controls.Clear();
                int lNumberInString = 0;
                for (int i = 0; i < lRealColors.Length; i++)
                {
                    Panel lPanel = new Panel();
                    lPanel.BackColor = lRealColors[i];
                    lPanel.Width = 50;
                    lPanel.Height = 50;
                    TextBox lLabel = new TextBox();
                    lLabel.Multiline = true;
                    lLabel.Text = "R:" +
                        lRealColors[i].R.ToString("G") + Environment.NewLine + " G:" +
                        lRealColors[i].G.ToString("G") + Environment.NewLine + " B:" +
                        lRealColors[i].B.ToString("G");
                    lLabel.Width = 50;
                    lLabel.Height = 50;
//                    lLabel.AutoSize = true;
                    flpColors.Controls.Add(lLabel);
                    flpColors.Controls.Add(lPanel);
                    lNumberInString += 2;
                    if (lNumberInString == 6)
                    {
                        //                        flpColors.SetFlowBreak(flpColors.Controls[flpColors.Controls.Count - 1]);
                        flpColors.SetFlowBreak(lPanel,true);
                        lNumberInString = 0;
                    }
                }
                lNumberInString = 0;
                flpFinalColors.Controls.Clear();
                for (int i = 0; i < lFinalColors.Length; i++)
                {
                    Panel lPanel = new Panel();
                    lPanel.BackColor = lFinalColors[i];
                    lPanel.Width = 50;
                    lPanel.Height = 50;
                    TextBox lLabel = new TextBox();
                    lLabel.Multiline = true;
                    lLabel.Text = "R:" +
                        lFinalColors[i].R.ToString("G") + Environment.NewLine + " G:" +
                        lFinalColors[i].G.ToString("G") + Environment.NewLine + " B:" +
                        lFinalColors[i].B.ToString("G");
                    lLabel.Width = 50;
                    lLabel.Height = 50;
                    //                    lLabel.AutoSize = true;
                    flpFinalColors.Controls.Add(lLabel);
                    flpFinalColors.Controls.Add(lPanel);
                    lNumberInString += 2;
                    if (lNumberInString == 6)
                    {
                        //                        flpColors.SetFlowBreak(flpColors.Controls[flpColors.Controls.Count - 1]);
                        flpColors.SetFlowBreak(lPanel, true);
                        lNumberInString = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //--------------------------------------------------------------------------------------
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //--------------------------------------------------------------------------------------
        private void tbRed_Scroll(object sender, EventArgs e)
        {
            CreatelShowColor();
            if (txtRed.Text != tbRed.Value.ToString())
                txtRed.Text = tbRed.Value.ToString();
        }
        //--------------------------------------------------------------------------------------
        private void tbGreen_Scroll(object sender, EventArgs e)
        {
            CreatelShowColor();
            if (txtGreen.Text != tbGreen.Value.ToString())
                txtGreen.Text = tbGreen.Value.ToString();
        }
        //--------------------------------------------------------------------------------------
        private void tbBlue_Scroll(object sender, EventArgs e)
        {
            CreatelShowColor();
            if (txtBlue.Text != tbBlue.Value.ToString())
                txtBlue.Text = tbBlue.Value.ToString();
        }
        //--------------------------------------------------------------------------------------
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
        }
        //--------------------------------------------------------------------------------------
        private void tsbSplitByColo_Click(object sender, EventArgs e)
        {
            Bitmap lInBmp = fPictureFocus.Image as Bitmap;
            if (lInBmp == null)
            {
                MessageBox.Show("Нет картинки");
                return;
            }
            PrepareLookSeparatePartForPicture(lInBmp);
        }
        //--------------------------------------------------------------------------------------
        private void PrepareLookSeparatePartForPicture(Bitmap pPictureForLook)
        {
            try
            {
                CImageSplitter lImageSplitter = new CImageSplitter();
                FLookSeparatePart form = new FLookSeparatePart();
                Dictionary<Color, Bitmap> lDictPicture = lImageSplitter.SplitImageByColor(pPictureForLook);
                List<Bitmap> lImages = new List<Bitmap>();
                List<Color> lColors = new List<Color>();
                form.PictureList = lImages;
                form.ColorList = lColors;
                form.PictureForLook = pPictureForLook;
                int lNumber = 0;
                foreach (Color lWhat in lDictPicture.Keys)
                {

                    Bitmap lBitmap = lDictPicture[lWhat];
                    lImages.Add(lBitmap);
                    lColors.Add(lWhat);
                    int lQuantity = 0;
                    int lQuantityAll = 0;
                    int lCentreX = 0;
                    int lCentreY = 0;
                    for (int n = 0; n < lBitmap.Width; n++)
                    {
                        lQuantityAll += lBitmap.Height;
                        for (int m = 0; m < lBitmap.Height; m++)
                        {
                            if (lBitmap.GetPixel(n, m) == lWhat)
                            {
                                lQuantity++;
                                lCentreX += n;
                                lCentreY += m;
                            }
                        }
                    }
                    lCentreX /= lQuantity;
                    lCentreY /= lQuantity;
                    form.imageListDataSet1.Images.AddImagesRow(lNumber++, lQuantity,
                        lCentreX, lCentreY, "R:" + lWhat.R.ToString("G") +
                        "G:" + lWhat.G.ToString("G") +
                        "B:" + lWhat.B.ToString("G"),
                        lWhat.R + lWhat.G + lWhat.B);
                }
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void CreatelShowColor()
        {
            try
            {
                lShow.BackColor = Color.FromArgb(255, (byte)tbRed.Value, (byte)tbGreen.Value, (byte)tbBlue.Value);
                tslRgb.Text = "R:" + tbRed.Value.ToString() + " G:" + tbGreen.Value.ToString() + " B:" + tbBlue.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void txtRed_TextChanged(object sender, EventArgs e)
        {
            TextBox lTextBoxSender = sender as TextBox;
            try
            {
                int lNewValue = Convert.ToInt32(lTextBoxSender.Text);
                if (lNewValue <= 255 && lNewValue >= 0)
                    if (lNewValue != tbRed.Value)
                    {
                        tbRed.Value = lNewValue;
                        CreatelShowColor();
                    }
            }
            catch
            {
            }
        }
        //--------------------------------------------------------------------------------------
        private void txtGreen_TextChanged(object sender, EventArgs e)
        {
            TextBox lTextBoxSender = sender as TextBox;
            try
            {
                int lNewValue = Convert.ToInt32(lTextBoxSender.Text);
                if (lNewValue <= 255 && lNewValue >= 0)
                    if (lNewValue != tbGreen.Value)
                    {
                        tbGreen.Value = lNewValue;
                        CreatelShowColor();
                    }
            }
            catch
            {
            }
        }
        //--------------------------------------------------------------------------------------
        private void txtBlue_TextChanged(object sender, EventArgs e)
        {

            TextBox lTextBoxSender = sender as TextBox;
            try
            {
                int lNewValue = Convert.ToInt32(lTextBoxSender.Text);
                if (lNewValue <= 255 && lNewValue >= 0)
                    if (lNewValue != tbBlue.Value)
                    {
                        tbBlue.Value = lNewValue;
                        CreatelShowColor();
                    }
            }
            catch
            {
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbSplitByColorResult_Click(object sender, EventArgs e)
        {
            PrepareLookSeparatePartForPicture((Bitmap)pbAfterCleanColor.Image);
        }
        //--------------------------------------------------------------------------------------
        private void pbSource_Click(object sender, EventArgs e)
        {
            if (fPictureFocus != null)
                fPictureFocus.BackColor = System.Drawing.SystemColors.Control;
            fPictureFocus = sender as PictureBox;
            if (fPictureFocus != null)
                fPictureFocus.BackColor = Color.FromArgb(224, 224, 224);
        }
        //--------------------------------------------------------------------------------------
        private void pbSource_MouseClick(object sender, MouseEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Alt) == Keys.Alt) && e.Button == MouseButtons.Left)
            {
                FColorBorderExplorer form = new FColorBorderExplorer(((PictureBox)sender).Image);
                form.Show();
            }
            else if (((Control.ModifierKeys & Keys.Alt) == Keys.Alt) && e.Button == MouseButtons.Right)
            {
                FBordersByColorForImage form = new FBordersByColorForImage(((PictureBox)sender).Image);
                form.Show();
            }
        }
        //--------------------------------------------------------------------------------------
        private void pbSource_MouseUp(object sender, MouseEventArgs e)
        {
            
        }
        //--------------------------------------------------------------------------------------
        private void AddToCompare2Image(Bitmap pImage)
        {
            if (fCompare2Image == null)
                fCompare2Image = new FCompare2Image();
            fCompare2Image.AddPicture(pImage, this);
            fCompare2Image.Show();
            fCompare2Image.BringToFront();
        }
        //--------------------------------------------------------------------------------------
        private void AddToCompare3Image(Bitmap pImage)
        {
            if (fCompare3Image == null)
                fCompare3Image = new FCompare3Image();
            fCompare3Image.AddPicture(pImage, this);
            fCompare3Image.Show();
            fCompare3Image.BringToFront();
        }
        //--------------------------------------------------------------------------------------
        private void pbBlackWhite_MouseClick(object sender, MouseEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Alt) == Keys.Alt) && e.Button == MouseButtons.Left)
            {
                FColorBorderExplorer form = new FColorBorderExplorer(((PictureBox)sender).Image);
                form.Show();
            }
            else if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.Button == MouseButtons.Left)
            {
                PictureBox lPictBox = sender as PictureBox;
                if (lPictBox != null && (lPictBox.Image as Bitmap) != null)
                {
                    AddToCompare2Image(lPictBox.Image as Bitmap);
                    /*
                    if (fCompare2Image == null)
                        fCompare2Image = new FCompare2Image();
                    fCompare2Image.AddPicture(lPictBox.Image, this);
                    fCompare2Image.Show();
                    fCompare2Image.BringToFront();
                    */
                }
                else
                    MessageBox.Show("Нет картинки");
            }
            else if (((Control.ModifierKeys & Keys.Shift) == Keys.Shift) && e.Button == MouseButtons.Left)
            {
                PictureBox lPictBox = sender as PictureBox;
                if (lPictBox != null && (lPictBox.Image as Bitmap) != null)
                {
                    AddToCompare3Image(lPictBox.Image as Bitmap);
                    /*
                    if (fCompare3Image == null)
                        fCompare3Image = new FCompare3Image();
                    fCompare3Image.AddPicture(lPictBox.Image, this);
                    fCompare3Image.Show();
                    fCompare3Image.BringToFront();
                    */
                }
                else
                    MessageBox.Show("Нет картинки");
            }
        }
        //--------------------------------------------------------------------------------------
        void IClearComareForm.ClearCompare2()
        {
            fCompare2Image = null;
        }
        //--------------------------------------------------------------------------------------
        void IClearComareForm.ClearCompare3()
        {
            fCompare3Image = null;
        }
        //--------------------------------------------------------------------------------------
        private void tsbByAllColorvsVote_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = pbSource.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                Bitmap lBmp = fBlackWhiteExplorer.PictureToBlackWhiteByVote(lInBmp);
                pbBlackWhite.Image = lBmp;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbByAllColorvsDistance_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = pbSource.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                Bitmap lBmp = fBlackWhiteExplorer.PictureToBlackWhiteByDistance(lInBmp);
                pbBlackWhite.Image = lBmp;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbColorBorderExplorer_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = fPictureFocus.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                FColorBorderExplorer form = new FColorBorderExplorer(lInBmp);
                form.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbBordersByColorForImage_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = fPictureFocus.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                FBordersByColorForImage form = new FBordersByColorForImage(lInBmp);
                form.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbCompare2Image_Click(object sender, EventArgs e)
        {
            Bitmap lInBmp = fPictureFocus.Image as Bitmap;
            if (lInBmp == null)
            {
                MessageBox.Show("Нет картинки");
                return;
            }
            AddToCompare2Image(lInBmp);
        }
        //--------------------------------------------------------------------------------------
        private void Compare3Image_Click(object sender, EventArgs e)
        {
            Bitmap lInBmp = fPictureFocus.Image as Bitmap;
            if (lInBmp == null)
            {
                MessageBox.Show("Нет картинки");
                return;
            }
            AddToCompare3Image(lInBmp);
        }
        //--------------------------------------------------------------------------------------
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lInBmp = fPictureFocus.Image as Bitmap;
                if (lInBmp == null)
                {
                    MessageBox.Show("Нет картинки");
                    return;
                }
                FLookProximityAndProjection form = new FLookProximityAndProjection(lInBmp);
                form.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
    public interface IClearComareForm
    {
        void ClearCompare2();
        void ClearCompare3();
    }
    //--------------------------------------------------------------------------------------
}
