using System;
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
    // class FBordersByColorFoImage
    //--------------------------------------------------------------------------------------
    public partial class FBordersByColorForImage : Form
    {
        private Bitmap fSourceBitmap;
        private Color[] fColorsOfVariant;
        private string[] fTextOfColors;
        private CBlackWhiteExplorer fBlackWhiteExplorer;
        private CBordersByColorForImage fBordersByColorForImage;
        //--------------------------------------------------------------------------------------
        public FBordersByColorForImage()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------------------------
        public FBordersByColorForImage(Image pImage)
        {
            InitializeComponent();

            fSourceBitmap = pImage as Bitmap;
            if (fSourceBitmap != null)
                pbSourceImage.Image = fSourceBitmap;

            fBlackWhiteExplorer = new CBlackWhiteExplorer();

            Color[] lFinalColors = CBlackWhiteExplorer.DefineExactNeedColor(8);
            fColorsOfVariant = new Color[8];
            fTextOfColors = new string[8];
            for (int i = 0; i < 6; i++)
                fColorsOfVariant[i + 1] = lFinalColors[i];
            fColorsOfVariant[0] = Color.FromArgb(255, 0, 0, 0);
            fColorsOfVariant[7] = Color.FromArgb(255, 255, 255, 255);
            for (int i = 0; i < fTextOfColors.Length; i++)
                fTextOfColors[i] = fColorsOfVariant[i].R.ToString() + ":" +
                    fColorsOfVariant[i].G.ToString() + ":" + fColorsOfVariant[i].B.ToString();
            l000.Text += "   (" + fTextOfColors[0] + ")";
            l001.Text += "   (" + fTextOfColors[1] + ")";
            l010.Text += "   (" + fTextOfColors[2] + ")";
            l011.Text += "   (" + fTextOfColors[3] + ")";
            l100.Text += "   (" + fTextOfColors[4] + ")";
            l101.Text += "   (" + fTextOfColors[5] + ")";
            l110.Text += "   (" + fTextOfColors[6] + ")";
            l111.Text += "   (" + fTextOfColors[7] + ")";
            l000.BackColor = fColorsOfVariant[0];
            l001.BackColor = fColorsOfVariant[1];
            l010.BackColor = fColorsOfVariant[2];
            l011.BackColor = fColorsOfVariant[3];
            l100.BackColor = fColorsOfVariant[4];
            l101.BackColor = fColorsOfVariant[5];
            l110.BackColor = fColorsOfVariant[6];
            l111.BackColor = fColorsOfVariant[7];
            l000.ForeColor = CImageSplitter.DefineBestBackColor(fColorsOfVariant[0]);
            l001.ForeColor = CImageSplitter.DefineBestBackColor(fColorsOfVariant[1]);
            l010.ForeColor = CImageSplitter.DefineBestBackColor(fColorsOfVariant[2]);
            l011.ForeColor = CImageSplitter.DefineBestBackColor(fColorsOfVariant[3]);
            l100.ForeColor = CImageSplitter.DefineBestBackColor(fColorsOfVariant[4]);
            l101.ForeColor = CImageSplitter.DefineBestBackColor(fColorsOfVariant[5]);
            l110.ForeColor = CImageSplitter.DefineBestBackColor(fColorsOfVariant[6]);
            l111.ForeColor = CImageSplitter.DefineBestBackColor(fColorsOfVariant[7]);
            fBordersByColorForImage = new CBordersByColorForImage(fSourceBitmap);
        }
        //--------------------------------------------------------------------------------------
        private void tbRed_Scroll(object sender, EventArgs e)
        {
        }

        //--------------------------------------------------------------------------------------
        private void tbGreen_Scroll(object sender, EventArgs e)
        {
        }

        //--------------------------------------------------------------------------------------
        private void tbBlue_Scroll(object sender, EventArgs e)
        {
        }
        //--------------------------------------------------------------------------------------
        private void txtRed_TextChanged(object sender, EventArgs e)
        {

            TextBox lTextBoxSender = sender as TextBox;
            try
            {
                int lNewValue = Convert.ToInt32(lTextBoxSender.Text);
                if (lNewValue > 255)
                {
                    lNewValue = 255;
                    lTextBoxSender.Text = lNewValue.ToString();
                }
                if (lNewValue < 0)
                {
                    lNewValue = 0;
                    lTextBoxSender.Text = lNewValue.ToString();
                }
                if (lNewValue <= 255 && lNewValue >= 0)
                    if (lNewValue != tbRed.Value)
                    {
                        tbRed.Value = lNewValue;
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
                if (lNewValue > 255)
                {
                    lNewValue = 255;
                    lTextBoxSender.Text = lNewValue.ToString();
                }
                if (lNewValue < 0)
                {
                    lNewValue = 0;
                    lTextBoxSender.Text = lNewValue.ToString();
                }
                if (lNewValue <= 255 && lNewValue >= 0)
                    if (lNewValue != tbGreen.Value)
                    {
                        tbGreen.Value = lNewValue;
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
                if (lNewValue > 255)
                {
                    lNewValue = 255;
                    lTextBoxSender.Text = lNewValue.ToString();
                }
                if (lNewValue < 0)
                {
                    lNewValue = 0;
                    lTextBoxSender.Text = lNewValue.ToString();
                }
                if (lNewValue <= 255 && lNewValue >= 0)
                    if (lNewValue != tbBlue.Value)
                    {
                        tbBlue.Value = lNewValue;
                    }
            }
            catch
            {
            }

        }
        //--------------------------------------------------------------------------------------
        private void tsbExec_Click(object sender, EventArgs e)
        {
            CreateBlackWhiteForRed();
            CreateBlackWhiteForGreen();
            CreateBlackWhiteForBlue();
            CompareColorBorderInImage lComparerColor = new CompareColorBorderInImage(fSourceBitmap);
            lComparerColor.ComputePicture(tbRed.Value, tbGreen.Value, tbBlue.Value, fColorsOfVariant);
            pb000.Image = CBlackWhiteExplorer.BinaryMatrixToBitmap(lComparerColor.Matrix000);
            pb001.Image = CBlackWhiteExplorer.BinaryMatrixToBitmap(lComparerColor.Matrix001);
            pb010.Image = CBlackWhiteExplorer.BinaryMatrixToBitmap(lComparerColor.Matrix010);
            pb011.Image = CBlackWhiteExplorer.BinaryMatrixToBitmap(lComparerColor.Matrix011);
            pb100.Image = CBlackWhiteExplorer.BinaryMatrixToBitmap(lComparerColor.Matrix100);
            pb101.Image = CBlackWhiteExplorer.BinaryMatrixToBitmap(lComparerColor.Matrix101);
            pb110.Image = CBlackWhiteExplorer.BinaryMatrixToBitmap(lComparerColor.Matrix110);
            pb111.Image = CBlackWhiteExplorer.BinaryMatrixToBitmap(lComparerColor.Matrix111);
            pbColor.Image = lComparerColor.ColorPicture;
            DefineColorPartion();
        }
        //--------------------------------------------------------------------------------------
        private void CreateBlackWhiteForRed()
        {
            try
            {
                CDescriptionPartition lDescriptionPartition = null;
                Image bmpBW = fBlackWhiteExplorer.PictureToBlackWhiteVarBorder(fSourceBitmap, 1, tbRed.Value, out lDescriptionPartition);
                pbRed.Image = bmpBW;
                txtAverageBottomRed.Text = Math.Round(lDescriptionPartition.AverageBottom).ToString();
                txtAverageTopRed.Text = Math.Round(lDescriptionPartition.AverageTop).ToString();
                txtBottomWeightRed.Text = lDescriptionPartition.BottomWeight.ToString();
                txtTopWeightRed.Text = lDescriptionPartition.TopWeight.ToString();
                txtBottomDevisionRed.Text = Math.Round(lDescriptionPartition.BottomDevision).ToString();
                txtTopDevisionRed.Text = Math.Round(lDescriptionPartition.TopDevision).ToString();
                txtBottomEstRed.Text = Math.Round(lDescriptionPartition.BottomDevision+lDescriptionPartition.TopDevision).ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void CreateBlackWhiteForGreen()
        {
            try
            {
                CDescriptionPartition lDescriptionPartition = null;
                Image bmpBW = fBlackWhiteExplorer.PictureToBlackWhiteVarBorder(fSourceBitmap, 2, tbGreen.Value, out lDescriptionPartition);
                pbGreen.Image = bmpBW;
                txtAverageBottomGreen.Text = Math.Round(lDescriptionPartition.AverageBottom).ToString();
                txtAverageTopGreen.Text = Math.Round(lDescriptionPartition.AverageTop).ToString();
                txtBottomWeightGreen.Text = lDescriptionPartition.BottomWeight.ToString();
                txtTopWeightGreen.Text = lDescriptionPartition.TopWeight.ToString();
                txtBottomDevisionGreen.Text = Math.Round(lDescriptionPartition.BottomDevision).ToString();
                txtTopDevisionGreen.Text = Math.Round(lDescriptionPartition.TopDevision).ToString();
                txtBottomEstGreen.Text = Math.Round(lDescriptionPartition.BottomDevision + lDescriptionPartition.TopDevision).ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void CreateBlackWhiteForBlue()
        {
            try
            {
                CDescriptionPartition lDescriptionPartition = null;
                Image bmpBW = fBlackWhiteExplorer.PictureToBlackWhiteVarBorder(fSourceBitmap, 3, tbBlue.Value, out lDescriptionPartition);
                pbBlue.Image = bmpBW;
                txtAverageBottomBlue.Text = Math.Round(lDescriptionPartition.AverageBottom).ToString();
                txtAverageTopBlue.Text = Math.Round(lDescriptionPartition.AverageTop).ToString();
                txtBottomWeightBlue.Text = lDescriptionPartition.BottomWeight.ToString();
                txtTopWeightBlue.Text = lDescriptionPartition.TopWeight.ToString();
                txtBottomDevisionBlue.Text = Math.Round(lDescriptionPartition.BottomDevision).ToString();
                txtTopDevisionBlue.Text = Math.Round(lDescriptionPartition.TopDevision).ToString();
                txtBottomEstBlue.Text = Math.Round(lDescriptionPartition.BottomDevision + lDescriptionPartition.TopDevision).ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbSplitByColor_Click(object sender, EventArgs e)
        {
            PrepareLookSeparatePartForPicture((Bitmap)pbColor.Image);
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
        private void DefineColorPartion()
        {
            Bitmap lPicture = pbSourceImage.Image as Bitmap;
            if (lPicture != null)
            {
                CColorPartion lColorPartition = new CColorPartion(lPicture);
                /*
                List<Color> lData = new List<Color>(lPicture.Height * lPicture.Width);
                for (int i = 0; i < lPicture.Width; i++)
                    for (int j = 0; j < lPicture.Height; j++)
                        lData.Add(lPicture.GetPixel(i, j));

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
                string lMainTextRed = "";
                string lMainTextGreen = "";
                string lMainTextBlue = "";
                string lAddTextRed = "";
                string lAddTextGreen = "";
                string lAddTextBlue = "";
                foreach (var lColorPart in queryGroupColorRed)
                {
                    lMainTextRed += lColorPart.ColorLevel.ToString() + ", ";
                    lAddTextRed += lColorPart.ColorLevel.ToString("D3") + " : " + lColorPart.ColorWeight.ToString() + Environment.NewLine;
                }
                foreach (var lColorPart in queryGroupColorGreen)
                {
                    lMainTextGreen += lColorPart.ColorLevel.ToString() + ", ";
                    lAddTextGreen += lColorPart.ColorLevel.ToString("D3") + " : " + lColorPart.ColorWeight.ToString() + Environment.NewLine;
                }
                foreach (var lColorPart in queryGroupColorBlue)
                {
                    lMainTextBlue += lColorPart.ColorLevel.ToString() + ", ";
                    lAddTextBlue += lColorPart.ColorLevel.ToString("D3") + " : " + lColorPart.ColorWeight.ToString() + Environment.NewLine;
                }
                lblRedSet.Text = lMainTextRed;
                lblGreenSet.Text = lMainTextGreen;
                lblBlueSet.Text = lMainTextBlue;
                this.toolTip1.SetToolTip(this.lblRedSet, lAddTextRed);
                this.toolTip1.SetToolTip(this.lblGreenSet, lAddTextGreen);
                this.toolTip1.SetToolTip(this.lblBlueSet, lAddTextBlue);
                */
                lblRedSet.Text = lColorPartition.MainTextRed;
                lblGreenSet.Text = lColorPartition.MainTextGreen;
                lblBlueSet.Text = lColorPartition.MainTextBlue;
                this.toolTip1.SetToolTip(this.lblRedSet, lColorPartition.AddTextRed);
                this.toolTip1.SetToolTip(this.lblGreenSet, lColorPartition.AddTextGreen);
                this.toolTip1.SetToolTip(this.lblBlueSet, lColorPartition.AddTextBlue);
            }

        }
        //--------------------------------------------------------------------------------------
        private void label22_Click(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------------------------------------------
        private void label24_Click(object sender, EventArgs e)
        {

        }
        //--------------------------------------------------------------------------------------
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int[] lBestBorder = fBordersByColorForImage.ComputeBestBorders(pbSourceImage.Image as Bitmap);
            tbRed.Value = lBestBorder[0];
            tbGreen.Value = lBestBorder[1];
            tbBlue.Value = lBestBorder[2];
        }
        //--------------------------------------------------------------------------------------
        private void tsbComputeBorderByAll_Click(object sender, EventArgs e)
        {
            int[] lBestBorder =fBordersByColorForImage.ComputeBest3DBorder(pbSourceImage.Image as Bitmap);
            tbRed.Value = lBestBorder[0];
            tbGreen.Value = lBestBorder[1];
            tbBlue.Value = lBestBorder[2];
        }
        //--------------------------------------------------------------------------------------
        private void tsbComputeBorderByAllGroup_Click(object sender, EventArgs e)
        {
            int[] lBestBorder = fBordersByColorForImage.ComputeBest3DBorderGroup(pbSourceImage.Image as Bitmap);
            tbRed.Value = lBestBorder[0];
            tbGreen.Value = lBestBorder[1];
            tbBlue.Value = lBestBorder[2];
        }
        //--------------------------------------------------------------------------------------
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //--------------------------------------------------------------------------------------
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            FormDivideBy3DDescription lForm = new FormDivideBy3DDescription(pbSourceImage.Image);
            lForm.Show();
        }
        //--------------------------------------------------------------------------------------
        private void tbRed_ValueChanged(object sender, EventArgs e)
        {
            if (txtRed.Text != tbRed.Value.ToString())
                txtRed.Text = tbRed.Value.ToString();
        }
        //--------------------------------------------------------------------------------------
        private void tbGreen_ValueChanged(object sender, EventArgs e)
        {
            if (txtGreen.Text != tbGreen.Value.ToString())
                txtGreen.Text = tbGreen.Value.ToString();


        }
        //--------------------------------------------------------------------------------------
        private void tbBlue_ValueChanged(object sender, EventArgs e)
        {
            if (txtBlue.Text != tbBlue.Value.ToString())
                txtBlue.Text = tbBlue.Value.ToString();
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
