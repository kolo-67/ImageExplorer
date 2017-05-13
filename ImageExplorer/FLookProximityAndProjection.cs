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
    // class FLookProximityAndProjection
    //--------------------------------------------------------------------------------------
    public partial class FLookProximityAndProjection : Form
    {
        //--------------------------------------------------------------------------------------
        public FLookProximityAndProjection()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------------------------
        public FLookProximityAndProjection(Bitmap pSource)
        {
            InitializeComponent();
            pbSource.Image = pSource;
        }
        //--------------------------------------------------------------------------------------
        private void tsbCreateTarget_Click(object sender, EventArgs e)
        {
            try
            {
                int lCountCubic = Convert.ToInt32(txtDens.Text);
                pbTarget.Image = CProximityColor.ProximityPicture(pbSource.Image as Bitmap, lCountCubic);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        //--------------------------------------------------------------------------------------
        private void tsbCreateProjection_Click(object sender, EventArgs e)
        {
            try
            {
                int lScale = Convert.ToInt32(txtScale.Text);
                Bitmap[] lProjections = CProximityColor.CreateProjection(pbSource.Image as Bitmap, lScale);
                pbProjXY.Image = lProjections[0];
                pbProjXZ.Image = lProjections[1];
                pbProjYZ.Image = lProjections[2];
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }
        //--------------------------------------------------------------------------------------
        private void tsbCreateProjectionForTarget_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap lImage = pbTarget.Image as Bitmap;
                if (lImage != null)
                {
                    int lScale = Convert.ToInt32(txtScale.Text);
                    Bitmap[] lProjections = CProximityColor.CreateProjection(lImage, lScale);
                    pbProjXY.Image = lProjections[0];
                    pbProjXZ.Image = lProjections[1];
                    pbProjYZ.Image = lProjections[2];
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }
        //--------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------
}
