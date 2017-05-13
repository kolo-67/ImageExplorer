namespace ImageExplorer
{
    partial class FCompare3Image
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCompare3Image));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tcbValColor = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbPicture1 = new System.Windows.Forms.PictureBox();
            this.pbPicture2 = new System.Windows.Forms.PictureBox();
            this.pbPicture3 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pbIntersection = new System.Windows.Forms.PictureBox();
            this.pbUnion = new System.Windows.Forms.PictureBox();
            this.pbUnionDiffer = new System.Windows.Forms.PictureBox();
            this.pb001 = new System.Windows.Forms.PictureBox();
            this.pb010 = new System.Windows.Forms.PictureBox();
            this.pb100 = new System.Windows.Forms.PictureBox();
            this.pb011 = new System.Windows.Forms.PictureBox();
            this.pb101 = new System.Windows.Forms.PictureBox();
            this.pb110 = new System.Windows.Forms.PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture3)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIntersection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnionDiffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb010)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb011)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb110)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(791, 383);
            this.splitContainer1.SplitterDistance = 33;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripLabel1,
            this.tcbValColor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(789, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Построить";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            "0",
            "1"});
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
            this.splitContainer2.Size = new System.Drawing.Size(791, 346);
            this.splitContainer2.SplitterDistance = 239;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.pbPicture1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbPicture2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pbPicture3, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(237, 344);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Picture1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Picture2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Picture3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPicture1
            // 
            this.pbPicture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPicture1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPicture1.Location = new System.Drawing.Point(4, 18);
            this.pbPicture1.Name = "pbPicture1";
            this.pbPicture1.Size = new System.Drawing.Size(229, 93);
            this.pbPicture1.TabIndex = 3;
            this.pbPicture1.TabStop = false;
            // 
            // pbPicture2
            // 
            this.pbPicture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPicture2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPicture2.Location = new System.Drawing.Point(4, 132);
            this.pbPicture2.Name = "pbPicture2";
            this.pbPicture2.Size = new System.Drawing.Size(229, 93);
            this.pbPicture2.TabIndex = 4;
            this.pbPicture2.TabStop = false;
            // 
            // pbPicture3
            // 
            this.pbPicture3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPicture3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPicture3.Location = new System.Drawing.Point(4, 246);
            this.pbPicture3.Name = "pbPicture3";
            this.pbPicture3.Size = new System.Drawing.Size(229, 94);
            this.pbPicture3.TabIndex = 5;
            this.pbPicture3.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label8, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label11, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label12, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.pbIntersection, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pbUnion, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.pbUnionDiffer, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.pb001, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.pb010, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.pb100, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.pb011, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.pb101, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.pb110, 2, 5);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(546, 344);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Intersection";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Union";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(366, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "100 U 010 U 001";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "001";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(185, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "010";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(366, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "100";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 229);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "011";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(185, 229);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "101";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(366, 229);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "110";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbIntersection
            // 
            this.pbIntersection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbIntersection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIntersection.Location = new System.Drawing.Point(4, 18);
            this.pbIntersection.Name = "pbIntersection";
            this.pbIntersection.Size = new System.Drawing.Size(174, 93);
            this.pbIntersection.TabIndex = 9;
            this.pbIntersection.TabStop = false;
            // 
            // pbUnion
            // 
            this.pbUnion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbUnion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbUnion.Location = new System.Drawing.Point(185, 18);
            this.pbUnion.Name = "pbUnion";
            this.pbUnion.Size = new System.Drawing.Size(174, 93);
            this.pbUnion.TabIndex = 10;
            this.pbUnion.TabStop = false;
            // 
            // pbUnionDiffer
            // 
            this.pbUnionDiffer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbUnionDiffer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbUnionDiffer.Location = new System.Drawing.Point(366, 18);
            this.pbUnionDiffer.Name = "pbUnionDiffer";
            this.pbUnionDiffer.Size = new System.Drawing.Size(176, 93);
            this.pbUnionDiffer.TabIndex = 11;
            this.pbUnionDiffer.TabStop = false;
            // 
            // pb001
            // 
            this.pb001.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb001.Location = new System.Drawing.Point(4, 132);
            this.pb001.Name = "pb001";
            this.pb001.Size = new System.Drawing.Size(174, 93);
            this.pb001.TabIndex = 12;
            this.pb001.TabStop = false;
            // 
            // pb010
            // 
            this.pb010.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb010.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb010.Location = new System.Drawing.Point(185, 132);
            this.pb010.Name = "pb010";
            this.pb010.Size = new System.Drawing.Size(174, 93);
            this.pb010.TabIndex = 13;
            this.pb010.TabStop = false;
            // 
            // pb100
            // 
            this.pb100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb100.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb100.Location = new System.Drawing.Point(366, 132);
            this.pb100.Name = "pb100";
            this.pb100.Size = new System.Drawing.Size(176, 93);
            this.pb100.TabIndex = 14;
            this.pb100.TabStop = false;
            // 
            // pb011
            // 
            this.pb011.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb011.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb011.Location = new System.Drawing.Point(4, 246);
            this.pb011.Name = "pb011";
            this.pb011.Size = new System.Drawing.Size(174, 94);
            this.pb011.TabIndex = 15;
            this.pb011.TabStop = false;
            // 
            // pb101
            // 
            this.pb101.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb101.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb101.Location = new System.Drawing.Point(185, 246);
            this.pb101.Name = "pb101";
            this.pb101.Size = new System.Drawing.Size(174, 94);
            this.pb101.TabIndex = 16;
            this.pb101.TabStop = false;
            // 
            // pb110
            // 
            this.pb110.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb110.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb110.Location = new System.Drawing.Point(366, 246);
            this.pb110.Name = "pb110";
            this.pb110.Size = new System.Drawing.Size(176, 94);
            this.pb110.TabIndex = 17;
            this.pb110.TabStop = false;
            // 
            // FCompare3Image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 383);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FCompare3Image";
            this.Text = "FCompare3Image";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FCompare3Image_FormClosed);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture3)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIntersection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnionDiffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb010)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb011)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb110)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tcbValColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbPicture1;
        private System.Windows.Forms.PictureBox pbPicture2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pbPicture3;
        private System.Windows.Forms.PictureBox pbIntersection;
        private System.Windows.Forms.PictureBox pbUnion;
        private System.Windows.Forms.PictureBox pbUnionDiffer;
        private System.Windows.Forms.PictureBox pb001;
        private System.Windows.Forms.PictureBox pb010;
        private System.Windows.Forms.PictureBox pb100;
        private System.Windows.Forms.PictureBox pb011;
        private System.Windows.Forms.PictureBox pb101;
        private System.Windows.Forms.PictureBox pb110;
    }
}