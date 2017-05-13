namespace ImageExplorer
{
    partial class FLookProximityAndProjection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLookProximityAndProjection));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtDens = new System.Windows.Forms.ToolStripTextBox();
            this.tsbCreateTarget = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtScale = new System.Windows.Forms.ToolStripTextBox();
            this.tsbCreateProjection = new System.Windows.Forms.ToolStripButton();
            this.pbSource = new System.Windows.Forms.PictureBox();
            this.pbTarget = new System.Windows.Forms.PictureBox();
            this.pbProjXY = new System.Windows.Forms.PictureBox();
            this.pbProjXZ = new System.Windows.Forms.PictureBox();
            this.pbProjYZ = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tsbCreateProjectionForTarget = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProjXY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProjXZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProjYZ)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbSource, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pbTarget, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pbProjXY, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.pbProjXZ, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.pbProjYZ, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(748, 412);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 3);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtDens,
            this.tsbCreateTarget,
            this.toolStripLabel2,
            this.txtScale,
            this.tsbCreateProjection,
            this.tsbCreateProjectionForTarget});
            this.toolStrip1.Location = new System.Drawing.Point(1, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(746, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(80, 22);
            this.toolStripLabel1.Text = "Густота сетки";
            // 
            // txtDens
            // 
            this.txtDens.Name = "txtDens";
            this.txtDens.Size = new System.Drawing.Size(100, 25);
            this.txtDens.Text = "20";
            // 
            // tsbCreateTarget
            // 
            this.tsbCreateTarget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCreateTarget.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreateTarget.Image")));
            this.tsbCreateTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateTarget.Name = "tsbCreateTarget";
            this.tsbCreateTarget.Size = new System.Drawing.Size(23, 22);
            this.tsbCreateTarget.Text = "toolStripButton1";
            this.tsbCreateTarget.Click += new System.EventHandler(this.tsbCreateTarget_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(93, 22);
            this.toolStripLabel2.Text = "Размер проекции";
            // 
            // txtScale
            // 
            this.txtScale.Name = "txtScale";
            this.txtScale.Size = new System.Drawing.Size(100, 25);
            this.txtScale.Text = "5";
            // 
            // tsbCreateProjection
            // 
            this.tsbCreateProjection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCreateProjection.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreateProjection.Image")));
            this.tsbCreateProjection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateProjection.Name = "tsbCreateProjection";
            this.tsbCreateProjection.Size = new System.Drawing.Size(23, 22);
            this.tsbCreateProjection.Text = "toolStripButton2";
            this.tsbCreateProjection.Click += new System.EventHandler(this.tsbCreateProjection_Click);
            // 
            // pbSource
            // 
            this.pbSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSource.Location = new System.Drawing.Point(4, 54);
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size(241, 105);
            this.pbSource.TabIndex = 1;
            this.pbSource.TabStop = false;
            // 
            // pbTarget
            // 
            this.pbTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbTarget.Location = new System.Drawing.Point(252, 54);
            this.pbTarget.Name = "pbTarget";
            this.pbTarget.Size = new System.Drawing.Size(242, 105);
            this.pbTarget.TabIndex = 2;
            this.pbTarget.TabStop = false;
            // 
            // pbProjXY
            // 
            this.pbProjXY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProjXY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProjXY.Location = new System.Drawing.Point(4, 190);
            this.pbProjXY.Name = "pbProjXY";
            this.pbProjXY.Size = new System.Drawing.Size(241, 218);
            this.pbProjXY.TabIndex = 4;
            this.pbProjXY.TabStop = false;
            // 
            // pbProjXZ
            // 
            this.pbProjXZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProjXZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProjXZ.Location = new System.Drawing.Point(252, 190);
            this.pbProjXZ.Name = "pbProjXZ";
            this.pbProjXZ.Size = new System.Drawing.Size(242, 218);
            this.pbProjXZ.TabIndex = 5;
            this.pbProjXZ.TabStop = false;
            // 
            // pbProjYZ
            // 
            this.pbProjYZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProjYZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProjYZ.Location = new System.Drawing.Point(501, 190);
            this.pbProjYZ.Name = "pbProjYZ";
            this.pbProjYZ.Size = new System.Drawing.Size(243, 218);
            this.pbProjYZ.TabIndex = 6;
            this.pbProjYZ.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Исходная";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "С заменой цветов";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 168);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Проекция XY";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 168);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Проекция XZ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 168);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Проекция YZ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tsbCreateProjectionForTarget
            // 
            this.tsbCreateProjectionForTarget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCreateProjectionForTarget.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreateProjectionForTarget.Image")));
            this.tsbCreateProjectionForTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateProjectionForTarget.Name = "tsbCreateProjectionForTarget";
            this.tsbCreateProjectionForTarget.Size = new System.Drawing.Size(23, 22);
            this.tsbCreateProjectionForTarget.Text = "toolStripButton2";
            this.tsbCreateProjectionForTarget.Click += new System.EventHandler(this.tsbCreateProjectionForTarget_Click);
            // 
            // FLookProximityAndProjection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 412);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FLookProximityAndProjection";
            this.Text = "FLookProximityAndProjection";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProjXY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProjXZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProjYZ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.PictureBox pbSource;
        private System.Windows.Forms.PictureBox pbTarget;
        private System.Windows.Forms.PictureBox pbProjXY;
        private System.Windows.Forms.PictureBox pbProjXZ;
        private System.Windows.Forms.PictureBox pbProjYZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtDens;
        private System.Windows.Forms.ToolStripButton tsbCreateTarget;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtScale;
        private System.Windows.Forms.ToolStripButton tsbCreateProjection;
        private System.Windows.Forms.ToolStripButton tsbCreateProjectionForTarget;
    }
}