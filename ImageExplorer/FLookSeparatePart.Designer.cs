namespace ImageExplorer
{
    partial class FLookSeparatePart
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbShow = new System.Windows.Forms.ToolStripButton();
            this.txtSelectedNumber = new System.Windows.Forms.ToolStripTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbCurrentPicture = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.centreXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.centreYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorBright = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsImages = new System.Windows.Forms.BindingSource(this.components);
            this.imageListDataSet1 = new ImageExplorer.ImageListDataSet();
            this.pbSourcePicture = new System.Windows.Forms.PictureBox();
            this.lCurColor = new System.Windows.Forms.Label();
            this.pbAgregate = new System.Windows.Forms.PictureBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageListDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSourcePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgregate)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(842, 473);
            this.splitContainer1.SplitterDistance = 31;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbDelete,
            this.tsbShow,
            this.txtSelectedNumber});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(840, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = global::ImageExplorer.Properties.Resources.plus16;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbAdd.Text = "Удалить последний";
            this.tsbAdd.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = global::ImageExplorer.Properties.Resources.delete_x16;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Text = "Добавить";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click_1);
            // 
            // tsbShow
            // 
            this.tsbShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShow.Image = global::ImageExplorer.Properties.Resources.show16;
            this.tsbShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShow.Name = "tsbShow";
            this.tsbShow.Size = new System.Drawing.Size(23, 22);
            this.tsbShow.Text = "показать";
            this.tsbShow.Click += new System.EventHandler(this.tsbShow_Click);
            // 
            // txtSelectedNumber
            // 
            this.txtSelectedNumber.Name = "txtSelectedNumber";
            this.txtSelectedNumber.Size = new System.Drawing.Size(300, 25);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.49583F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.50417F));
            this.tableLayoutPanel1.Controls.Add(this.pbCurrentPicture, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbSourcePicture, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lCurColor, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pbAgregate, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.06266F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.06266F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.06266F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.81203F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(840, 436);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pbCurrentPicture
            // 
            this.pbCurrentPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCurrentPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCurrentPicture.Location = new System.Drawing.Point(477, 4);
            this.pbCurrentPicture.Name = "pbCurrentPicture";
            this.pbCurrentPicture.Size = new System.Drawing.Size(359, 102);
            this.pbCurrentPicture.TabIndex = 0;
            this.pbCurrentPicture.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.centreXDataGridViewTextBoxColumn,
            this.centreYDataGridViewTextBoxColumn,
            this.Color,
            this.ColorBright});
            this.dataGridView1.DataSource = this.bsImages;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 4);
            this.dataGridView1.RowTemplate.Height = 18;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(466, 428);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn.Width = 69;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 71;
            // 
            // centreXDataGridViewTextBoxColumn
            // 
            this.centreXDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.centreXDataGridViewTextBoxColumn.DataPropertyName = "CentreX";
            this.centreXDataGridViewTextBoxColumn.HeaderText = "CentreX";
            this.centreXDataGridViewTextBoxColumn.Name = "centreXDataGridViewTextBoxColumn";
            this.centreXDataGridViewTextBoxColumn.ReadOnly = true;
            this.centreXDataGridViewTextBoxColumn.Width = 70;
            // 
            // centreYDataGridViewTextBoxColumn
            // 
            this.centreYDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.centreYDataGridViewTextBoxColumn.DataPropertyName = "CentreY";
            this.centreYDataGridViewTextBoxColumn.HeaderText = "CentreY";
            this.centreYDataGridViewTextBoxColumn.Name = "centreYDataGridViewTextBoxColumn";
            this.centreYDataGridViewTextBoxColumn.ReadOnly = true;
            this.centreYDataGridViewTextBoxColumn.Width = 70;
            // 
            // Color
            // 
            this.Color.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Width = 56;
            // 
            // ColorBright
            // 
            this.ColorBright.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColorBright.DataPropertyName = "ColorBright";
            this.ColorBright.HeaderText = "ColorBright";
            this.ColorBright.Name = "ColorBright";
            this.ColorBright.ReadOnly = true;
            this.ColorBright.Width = 83;
            // 
            // bsImages
            // 
            this.bsImages.DataMember = "Images";
            this.bsImages.DataSource = this.imageListDataSet1;
            // 
            // imageListDataSet1
            // 
            this.imageListDataSet1.DataSetName = "ImageListDataSet";
            this.imageListDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pbSourcePicture
            // 
            this.pbSourcePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSourcePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSourcePicture.Location = new System.Drawing.Point(477, 113);
            this.pbSourcePicture.Name = "pbSourcePicture";
            this.pbSourcePicture.Size = new System.Drawing.Size(359, 102);
            this.pbSourcePicture.TabIndex = 2;
            this.pbSourcePicture.TabStop = false;
            // 
            // lCurColor
            // 
            this.lCurColor.AutoSize = true;
            this.lCurColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lCurColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lCurColor.Location = new System.Drawing.Point(477, 219);
            this.lCurColor.Name = "lCurColor";
            this.lCurColor.Size = new System.Drawing.Size(359, 108);
            this.lCurColor.TabIndex = 3;
            // 
            // pbAgregate
            // 
            this.pbAgregate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAgregate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAgregate.Location = new System.Drawing.Point(477, 331);
            this.pbAgregate.Name = "pbAgregate";
            this.pbAgregate.Size = new System.Drawing.Size(359, 101);
            this.pbAgregate.TabIndex = 4;
            this.pbAgregate.TabStop = false;
            // 
            // FLookSeparatePart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 473);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FLookSeparatePart";
            this.Text = "FLookSeparatePart";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageListDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSourcePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgregate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbCurrentPicture;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bsImages;
        public ImageListDataSet imageListDataSet1;
        private System.Windows.Forms.PictureBox pbSourcePicture;
        private System.Windows.Forms.Label lCurColor;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbShow;
        private System.Windows.Forms.ToolStripTextBox txtSelectedNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn centreXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn centreYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorBright;
        private System.Windows.Forms.PictureBox pbAgregate;
    }
}