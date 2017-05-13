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
    // class FCompare2Image
    //--------------------------------------------------------------------------------------
    public partial class FCompare2Image : Form
    {
        private int fCurrentTurn = 1;
        private IClearComareForm fOwner = null;
        //--------------------------------------------------------------------------------------
        public FCompare2Image()
        {
            InitializeComponent();
            tcbValColor.SelectedIndex = 0;
        }
        //--------------------------------------------------------------------------------------
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        //--------------------------------------------------------------------------------------
        private void tsbExec_Click(object sender, EventArgs e)
        {
            if (pbPicture1.Image == null || pbPicture2.Image == null)
                return;

            CBlackWhiteExplorer lBlackWhiteExplorer = new CBlackWhiteExplorer();
            byte[][] lMatrix1 = CBlackWhiteExplorer.BitmapToBinaryMatrix(pbPicture1.Image as Bitmap);
            byte[][] lMatrix2 = CBlackWhiteExplorer.BitmapToBinaryMatrix(pbPicture2.Image as Bitmap);
            byte[][][] lMatrixs = lBlackWhiteExplorer.Compare2BWMatrix(lMatrix1,lMatrix2,byte.Parse(tcbValColor.SelectedItem.ToString()));
            Bitmap lPictureIntersection = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[1]);
            Bitmap lPictureUnion = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[0]);
            Bitmap lPicture1_2 = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[2]);
            Bitmap lPicture2_1 = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[3]);
            Bitmap lPictureUnionDiffer = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[4]);

            pbIntersection.Image = lPictureIntersection;
            pbUnion.Image = lPictureUnion;
            pbUnionDiffer.Image = lPictureUnionDiffer;
            pb1_2.Image = lPicture1_2;
            pb2_1.Image = lPicture2_1;
        }
        //--------------------------------------------------------------------------------------
        public void AddPicture(Image pImage, IClearComareForm pOwner)
        {
            if (fOwner == null)
                fOwner = pOwner;
            if (fCurrentTurn == 1)
            {
                pbPicture1.Image = pImage.Clone() as Image;
                fCurrentTurn = 2;
            }
            else
            {
                pbPicture2.Image = pImage.Clone() as Image;
                fCurrentTurn = 1;
            }
        }
        //--------------------------------------------------------------------------------------
        private void FCompare2Image_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fOwner != null)
                fOwner.ClearCompare2();
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
