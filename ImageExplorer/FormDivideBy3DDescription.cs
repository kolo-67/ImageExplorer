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
    // class FormDivideBy3DDescription
    //--------------------------------------------------------------------------------------
    public partial class FormDivideBy3DDescription : Form
    {
        private Bitmap fSourceBitmap = null;
        private CColorPartion fColorPartion = null;
//        private ImageListDataSet fImageListDataSet;
        //--------------------------------------------------------------------------------------
        public FormDivideBy3DDescription()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------------------------
        public FormDivideBy3DDescription(Image pImage)
        {
            InitializeComponent();
//            fImageListDataSet = new ImageListDataSet();
            fSourceBitmap = pImage as Bitmap;
            if (fSourceBitmap != null)
            {
                pbSourceImage.Image = fSourceBitmap;
                fColorPartion = new CColorPartion(fSourceBitmap);
                lblRedSet.Text = fColorPartion.MainTextRed;
                lblGreenSet.Text = fColorPartion.MainTextGreen;
                lblBlueSet.Text = fColorPartion.MainTextBlue;
                lblSummaSet.Text = fColorPartion.MainTextSumma;
                this.toolTip1.SetToolTip(this.lblRedSet, fColorPartion.AddTextRed);
                this.toolTip1.SetToolTip(this.lblGreenSet, fColorPartion.AddTextGreen);
                this.toolTip1.SetToolTip(this.lblBlueSet, fColorPartion.AddTextBlue);
                this.toolTip1.SetToolTip(this.lblSummaSet, fColorPartion.AddTextSumma);
                tbRed.Minimum = 0;
                tbRed.Maximum = fColorPartion.RedPartition.Length - 1;
                tbGreen.Minimum = 0;
                tbGreen.Maximum = fColorPartion.GreenPartition.Length - 1;
                tbBlue.Minimum = 0;
                tbBlue.Maximum = fColorPartion.BluePartition.Length - 1;
            }
        }
        //--------------------------------------------------------------------------------------
        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        //--------------------------------------------------------------------------------------
        private void label5_Click(object sender, EventArgs e)
        {

        }
        //--------------------------------------------------------------------------------------
        private void label6_Click(object sender, EventArgs e)
        {

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
        private void tbRed_ValueChanged(object sender, EventArgs e)
        {
            if (txtRed.Text != fColorPartion.RedPartition[tbRed.Value][0].ToString())
                txtRed.Text = fColorPartion.RedPartition[tbRed.Value][0].ToString();
            txtBounds.Text = (fColorPartion.RedPartition[tbRed.Value][0] +
                fColorPartion.GreenPartition[tbGreen.Value][0] +
                fColorPartion.BluePartition[tbBlue.Value][0]).ToString();
            ApplySelectBorders(false);
        }
        //--------------------------------------------------------------------------------------
        private void tbGreen_ValueChanged(object sender, EventArgs e)
        {
            if (txtGreen.Text != fColorPartion.GreenPartition[tbGreen.Value][0].ToString())
                txtGreen.Text = fColorPartion.GreenPartition[tbGreen.Value][0].ToString();
            txtBounds.Text = (fColorPartion.RedPartition[tbRed.Value][0] +
                fColorPartion.GreenPartition[tbGreen.Value][0] +
                fColorPartion.BluePartition[tbBlue.Value][0]).ToString();
            ApplySelectBorders(false);
        }
        //--------------------------------------------------------------------------------------
        private void tbBlue_ValueChanged(object sender, EventArgs e)
        {
            if (txtBlue.Text != fColorPartion.BluePartition[tbBlue.Value][0].ToString())
                txtBlue.Text = fColorPartion.BluePartition[tbBlue.Value][0].ToString();
            txtBounds.Text = (fColorPartion.RedPartition[tbRed.Value][0] +
                fColorPartion.GreenPartition[tbGreen.Value][0] +
                fColorPartion.BluePartition[tbBlue.Value][0]).ToString();
            ApplySelectBorders(false);
        }
        //--------------------------------------------------------------------------------------
        private void tsbExec_Click(object sender, EventArgs e)
        {
            ApplySelectBorders(true);
        }
        //--------------------------------------------------------------------------------------
        private void ApplySelectBorders(bool pIsUpdateListBad)
        {
            CBordersByColorForImage lBordersByColorForImage = new CBordersByColorForImage(pbSourceImage.Image as Bitmap);
            lBordersByColorForImage.Explore3DBorderGroup(pbSourceImage.Image as Bitmap,
                tbRed.Value, tbGreen.Value, tbBlue.Value);
            txtTopCount.Text = lBordersByColorForImage.TopListCount.ToString();
            txtBottomCount.Text = lBordersByColorForImage.BottomListCount.ToString();
            txtTopRedSumma.Text = lBordersByColorForImage.TopRedSumma.ToString();
            txtTopGreenSumma.Text = lBordersByColorForImage.TopGreenSumma.ToString();
            txtTopBlueSumma.Text = lBordersByColorForImage.TopBlueSumma.ToString();
            txtBottomRedSumma.Text = lBordersByColorForImage.BottomRedSumma.ToString();
            txtBottomGreenSumma.Text = lBordersByColorForImage.BottomGreenSumma.ToString();
            txtBottomBlueSumma.Text = lBordersByColorForImage.BottomBlueSumma.ToString();
            txtTopRedCentre.Text = lBordersByColorForImage.TopRedCentre.ToString();
            txtTopGreenCentre.Text = lBordersByColorForImage.TopGreenCentre.ToString();
            txtTopBlueCentre.Text = lBordersByColorForImage.TopBlueCentre.ToString();
            txtBottomRedCentre.Text = lBordersByColorForImage.BottomRedCentre.ToString();
            txtBottomGreenCentre.Text = lBordersByColorForImage.BottomGreenCentre.ToString();
            txtBottomBlueCentre.Text = lBordersByColorForImage.BottomBlueCentre.ToString();
            txtTopDevisionSumma.Text = lBordersByColorForImage.TopDevisionSumma.ToString();
            txtBottomDevisionSumma.Text = lBordersByColorForImage.BottomDevisionSumma.ToString();
            txtTopDevision.Text = lBordersByColorForImage.TopDevision.ToString();
            txtBottomDevision.Text = lBordersByColorForImage.BottomDevision.ToString();
            txtBadPoints.Text = lBordersByColorForImage.BadPoint.ToString();
            txtVeryBadPoints.Text = lBordersByColorForImage.VeryBadPoint.ToString();

            fImageListDataSet.BadPointFor3D.Clear();
            if(pIsUpdateListBad)
            {
                for (int i = 0; i < lBordersByColorForImage.BadPointList.Count; i++)
                {
                    fImageListDataSet.BadPointFor3D.AddBadPointFor3DRow(
                        lBordersByColorForImage.BadPointList[i].Point.R.ToString()+","+
                        lBordersByColorForImage.BadPointList[i].Point.G.ToString()+","+
                        lBordersByColorForImage.BadPointList[i].Point.B.ToString(),
                        lBordersByColorForImage.BadPointList[i].Level,
                        lBordersByColorForImage.BadPointList[i].Weight);
                }
                dgBadPoint.Update();
            }
        }
        //--------------------------------------------------------------------------------------
        private void dgBadPoint_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            object oVal =  dgBadPoint.Rows[e.RowIndex].Cells[1].Value;
            if (oVal != null)
                if (oVal.GetType() == typeof(int))
                    if ( (int)oVal == 2)
                        e.CellStyle.BackColor = Color.Brown;
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
