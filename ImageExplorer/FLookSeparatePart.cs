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
    // class FLookSeparatePart
    //--------------------------------------------------------------------------------------
    public partial class FLookSeparatePart : Form
    {
        private List<Bitmap> fPictureList = null;
        private List<Color> fColorList = null;
        private Bitmap fPictureForLook = null;
        //--------------------------------------------------------------------------------------
        public FLookSeparatePart()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------------------------
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            ImageListDataSet.ImagesRow lRow = (ImageListDataSet.ImagesRow)((DataRowView)(bsImages.Current)).Row;
            int lIndex = lRow.Number;
            if (lIndex >= 0 && lIndex < PictureList.Count)
            {
                pbCurrentPicture.Image = PictureList[lIndex];
                if (fColorList != null)
                    lCurColor.BackColor = fColorList[lIndex];
            }
        }
        //--------------------------------------------------------------------------------------
        public List<Bitmap> PictureList
        {
            get
            {
                return fPictureList;
            }
            set
            {
                fPictureList = value;
            }
        }
        //--------------------------------------------------------------------------------------
        public List<Color> ColorList
        {
            get
            {
                return fColorList;
            }
            set
            {
                fColorList = value;
            }
        }
        //--------------------------------------------------------------------------------------
        public Bitmap PictureForLook
        {
            get
            {
                return fPictureForLook;
            }
            set
            {
                fPictureForLook = value;
                pbSourcePicture.Image = fPictureForLook;
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            AddCurrent();
        }
        //--------------------------------------------------------------------------------------
        private void tsbDelete_Click_1(object sender, EventArgs e)
        {
            DeleteLast();
        }
        //--------------------------------------------------------------------------------------
        private void AddCurrent()
        {
            int lNumber = ((ImageListDataSet.ImagesRow)((DataRowView)bsImages.Current).Row).Number;
            string lOldString = txtSelectedNumber.Text.Trim();
            if (string.IsNullOrEmpty(lOldString))
                txtSelectedNumber.Text = lNumber.ToString();
            else
            {
                string[] lOldStringAsArray = lOldString.Split(new char[] { ',' });
                string lNewNumber = lNumber.ToString();
                if (!lOldStringAsArray.Contains(lNewNumber))
                    txtSelectedNumber.Text += "," + lNewNumber;
            }
        }
        //--------------------------------------------------------------------------------------
        private void DeleteLast()
        {
            string lOldString = txtSelectedNumber.Text.Trim();
            if (!string.IsNullOrEmpty(lOldString))
            {
                string[] lOldStringAsArray = lOldString.Split(new char[] { ',' });
                txtSelectedNumber.Text = String.Join(",", lOldStringAsArray, 0, lOldStringAsArray.Length - 1);
            }
        }
        //--------------------------------------------------------------------------------------
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                AddCurrent();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteLast();
            }
        }
        //--------------------------------------------------------------------------------------
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                AddCurrent();
            }

        }
        //--------------------------------------------------------------------------------------
        private void tsbShow_Click(object sender, EventArgs e)
        {

            Color lBackColor = System.Drawing.Color.FromArgb(0, 0, 0);
            Bitmap lNewPicture = new Bitmap(fPictureList[0].Width, fPictureList[0].Height);
            for (int l = 0; l < lNewPicture.Width; l++)
                for (int k = 0; k < lNewPicture.Height; k++)
                    lNewPicture.SetPixel(l, k, lBackColor);
            string lOldString = txtSelectedNumber.Text.Trim();
            if (string.IsNullOrEmpty(lOldString))
                return;
            string[] lStringAsArray = lOldString.Split(new char[] { ',' });
            int[] lIntArray = (from s in lStringAsArray select Convert.ToInt32(s)).ToArray();
            for (int i = 0; i < lIntArray.Length; i++)
            {
                Bitmap lCurPicture = fPictureList[lIntArray[i]];
                System.Drawing.Color lColorCur = fColorList[lIntArray[i]];
                for (int l = 0; l < lCurPicture.Width; l++)
                    for (int k = 0; k < lCurPicture.Height; k++)
                        if (lCurPicture.GetPixel(l,k) == lColorCur)
                            lNewPicture.SetPixel(l, k, lColorCur);
            }
            pbAgregate.Image = lNewPicture;
        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
