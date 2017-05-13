namespace ImageExplorer
{
    partial class FCompare2Image
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCompare2Image));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExec = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tcbValColor = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbPicture1 = new System.Windows.Forms.PictureBox();
            this.pbPicture2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pbIntersection = new System.Windows.Forms.PictureBox();
            this.pb1_2 = new System.Windows.Forms.PictureBox();
            this.pb2_1 = new System.Windows.Forms.PictureBox();
            this.pbUnion = new System.Windows.Forms.PictureBox();
            this.pbUnionDiffer = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblb = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIntersection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnionDiffer)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(679, 299);
            this.splitContainer1.SplitterDistance = 34;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExec,
            this.toolStripLabel1,
            this.tcbValColor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(677, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbExec
            // 
            this.tsbExec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExec.Image = ((System.Drawing.Image)(resources.GetObject("tsbExec.Image")));
            this.tsbExec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExec.Name = "tsbExec";
            this.tsbExec.Size = new System.Drawing.Size(23, 22);
            this.tsbExec.Text = "Построить";
            this.tsbExec.Click += new System.EventHandler(this.tsbExec_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(61, 22);
            this.toolStripLabel1.Text = "Value Color";
            // 
            // tcbValColor
            // 
            this.tcbValColor.Items.AddRange(new object[] {
            "1",
            "0"});
            this.tcbValColor.Name = "tcbValColor";
            this.tcbValColor.Size = new System.Drawing.Size(121, 25);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(679, 261);
            this.splitContainer2.SplitterDistance = 225;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pbPicture1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbPicture2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(223, 259);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pbPicture1
            // 
            this.pbPicture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPicture1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPicture1.Location = new System.Drawing.Point(4, 18);
            this.pbPicture1.Name = "pbPicture1";
            this.pbPicture1.Size = new System.Drawing.Size(215, 108);
            this.pbPicture1.TabIndex = 0;
            this.pbPicture1.TabStop = false;
            // 
            // pbPicture2
            // 
            this.pbPicture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPicture2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPicture2.Location = new System.Drawing.Point(4, 147);
            this.pbPicture2.Name = "pbPicture2";
            this.pbPicture2.Size = new System.Drawing.Size(215, 108);
            this.pbPicture2.TabIndex = 1;
            this.pbPicture2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Picture1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Picture2";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.pbIntersection, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pb1_2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.pb2_1, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.pbUnion, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.pbUnionDiffer, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblb, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(448, 259);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pbIntersection
            // 
            this.pbIntersection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbIntersection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIntersection.Location = new System.Drawing.Point(4, 18);
            this.pbIntersection.Name = "pbIntersection";
            this.pbIntersection.Size = new System.Drawing.Size(216, 65);
            this.pbIntersection.TabIndex = 0;
            this.pbIntersection.TabStop = false;
            this.pbIntersection.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pb1_2
            // 
            this.pb1_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb1_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb1_2.Location = new System.Drawing.Point(4, 104);
            this.pb1_2.Name = "pb1_2";
            this.pb1_2.Size = new System.Drawing.Size(216, 65);
            this.pb1_2.TabIndex = 1;
            this.pb1_2.TabStop = false;
            // 
            // pb2_1
            // 
            this.pb2_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb2_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb2_1.Location = new System.Drawing.Point(4, 190);
            this.pb2_1.Name = "pb2_1";
            this.pb2_1.Size = new System.Drawing.Size(216, 65);
            this.pb2_1.TabIndex = 2;
            this.pb2_1.TabStop = false;
            // 
            // pbUnion
            // 
            this.pbUnion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbUnion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbUnion.Location = new System.Drawing.Point(227, 18);
            this.pbUnion.Name = "pbUnion";
            this.pbUnion.Size = new System.Drawing.Size(217, 65);
            this.pbUnion.TabIndex = 3;
            this.pbUnion.TabStop = false;
            // 
            // pbUnionDiffer
            // 
            this.pbUnionDiffer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbUnionDiffer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbUnionDiffer.Location = new System.Drawing.Point(227, 104);
            this.pbUnionDiffer.Name = "pbUnionDiffer";
            this.pbUnionDiffer.Size = new System.Drawing.Size(217, 65);
            this.pbUnionDiffer.TabIndex = 4;
            this.pbUnionDiffer.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Union";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Picture1-Picture2";
            // 
            // lblb
            // 
            this.lblb.AutoSize = true;
            this.lblb.Location = new System.Drawing.Point(227, 87);
            this.lblb.Name = "lblb";
            this.lblb.Size = new System.Drawing.Size(90, 13);
            this.lblb.TabIndex = 8;
            this.lblb.Text = "Union differences";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Picture2-Picture1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Intersection";
            // 
            // FCompare2Image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 299);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FCompare2Image";
            this.Text = "FCompare2Image";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FCompare2Image_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIntersection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnionDiffer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbPicture1;
        private System.Windows.Forms.PictureBox pbPicture2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pbIntersection;
        private System.Windows.Forms.PictureBox pb1_2;
        private System.Windows.Forms.PictureBox pb2_1;
        private System.Windows.Forms.PictureBox pbUnion;
        private System.Windows.Forms.PictureBox pbUnionDiffer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbExec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tcbValColor;
    }
}