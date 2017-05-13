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
    // class FCompare3Image
    //--------------------------------------------------------------------------------------
    public partial class FCompare3Image : Form
    {
        private int fCurrentTurn = 1;
        private IClearComareForm fOwner = null;
        //--------------------------------------------------------------------------------------
        public FCompare3Image()
        {
            InitializeComponent();
            tcbValColor.SelectedIndex = 0;
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
            else if (fCurrentTurn == 2)
            {
                pbPicture2.Image = pImage.Clone() as Image;
                fCurrentTurn = 3;
            }
            else 
            {
                pbPicture3.Image = pImage.Clone() as Image;
                fCurrentTurn = 1;
            }
        }
        //--------------------------------------------------------------------------------------
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (pbPicture1.Image == null || pbPicture2.Image == null || pbPicture3.Image == null)
                return;

            CBlackWhiteExplorer lBlackWhiteExplorer = new CBlackWhiteExplorer();
            byte[][] lMatrix1 = CBlackWhiteExplorer.BitmapToBinaryMatrix(pbPicture1.Image as Bitmap);
            byte[][] lMatrix2 = CBlackWhiteExplorer.BitmapToBinaryMatrix(pbPicture2.Image as Bitmap);
            byte[][] lMatrix3 = CBlackWhiteExplorer.BitmapToBinaryMatrix(pbPicture3.Image as Bitmap);
            byte[][][] lMatrixs = lBlackWhiteExplorer.Compare3BWMatrix(lMatrix1, lMatrix2, lMatrix3, byte.Parse(tcbValColor.SelectedItem.ToString()));
            Bitmap lPictureIntersection = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[0]);
            Bitmap lPictureUnion = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[1]);
            Bitmap lPictureUnionDiffer = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[2]);
            Bitmap lPicture001 = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[3]);
            Bitmap lPicture010 = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[4]);
            Bitmap lPicture100 = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[5]);
            Bitmap lPicture011 = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[6]);
            Bitmap lPicture101 = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[7]);
            Bitmap lPicture110 = CBlackWhiteExplorer.BinaryMatrixToBitmap(lMatrixs[8]);

            pbIntersection.Image = lPictureIntersection;
            pbUnion.Image = lPictureUnion;
            pbUnionDiffer.Image = lPictureUnionDiffer;
            pb001.Image = lPicture001;
            pb010.Image = lPicture010;
            pb100.Image = lPicture100;
            pb011.Image = lPicture011;
            pb101.Image = lPicture101;
            pb110.Image = lPicture110;
        }
        //--------------------------------------------------------------------------------------
        private void FCompare3Image_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fOwner != null)
                fOwner.ClearCompare3();
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
