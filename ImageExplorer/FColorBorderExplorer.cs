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
    // class FColorBorderExplorer
    //--------------------------------------------------------------------------------------
    public partial class FColorBorderExplorer : Form
    {
        Bitmap fImage = null;
        private CBlackWhiteExplorer fBlackWhiteExplorer;
        //--------------------------------------------------------------------------------------
        public FColorBorderExplorer()
        {
            InitializeComponent();
            tsbRun.Image = ilCom.Images[0];
        }
        //--------------------------------------------------------------------------------------
        public FColorBorderExplorer(Image pImage)
        {
            InitializeComponent();
            tsbRun.Image = ilCom.Images[0];
            cbColor.SelectedIndex = 0;
            fImage = pImage as Bitmap;
            if (fImage != null)
                pbSourve.Image = fImage;
            fBlackWhiteExplorer = new CBlackWhiteExplorer();
        }
        //--------------------------------------------------------------------------------------
        private void tsbRun_Click(object sender, EventArgs e)
        {
            Exec();
        }
        //--------------------------------------------------------------------------------------
        private void Exec()
        {
            try
            {
                CDescriptionPartition lDescriptionPartition = null;
                Image bmpBW = fBlackWhiteExplorer.PictureToBlackWhiteVarBorder(fImage, cbColor.SelectedIndex+1, int.Parse(txtBorder.Text), out lDescriptionPartition);
                pbTarget.Image = bmpBW;
                txtAverageBottom.Text = Math.Round(lDescriptionPartition.AverageBottom).ToString();
                txtAverageTop.Text = Math.Round(lDescriptionPartition.AverageTop).ToString();
                txtBottomWeight.Text = lDescriptionPartition.BottomWeight.ToString();
                txtTopWeight.Text = lDescriptionPartition.TopWeight.ToString();
                txtBottomDevision.Text = Math.Round(lDescriptionPartition.BottomDevision).ToString();
                txtTopDevision.Text = Math.Round(lDescriptionPartition.TopDevision).ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //--------------------------------------------------------------------------------------
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            txtBorder.Text = tbBorder.Value.ToString();
            Exec();
        }
        //--------------------------------------------------------------------------------------
        private void txtBorder_Leave(object sender, EventArgs e)
        {
            tbBorder.Value = int.Parse(txtBorder.Text);
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
