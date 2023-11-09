
namespace final_project_DB
{
    partial class extra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.product_idgrd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_namegrd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categorygrd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitygrd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.racknogrd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode_grd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Tan;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product_idgrd,
            this.product_namegrd,
            this.categorygrd,
            this.quantitygrd,
            this.racknogrd,
            this.barcode_grd});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 2;
            // 
            // product_idgrd
            // 
            this.product_idgrd.HeaderText = "Poduct_id";
            this.product_idgrd.Name = "product_idgrd";
            // 
            // product_namegrd
            // 
            this.product_namegrd.HeaderText = "Product_name";
            this.product_namegrd.Name = "product_namegrd";
            // 
            // categorygrd
            // 
            this.categorygrd.HeaderText = "Category";
            this.categorygrd.Name = "categorygrd";
            // 
            // quantitygrd
            // 
            this.quantitygrd.HeaderText = "Quantity";
            this.quantitygrd.Name = "quantitygrd";
            // 
            // racknogrd
            // 
            this.racknogrd.HeaderText = "Rack_no";
            this.racknogrd.Name = "racknogrd";
            // 
            // barcode_grd
            // 
            this.barcode_grd.HeaderText = "Barcode";
            this.barcode_grd.Name = "barcode_grd";
            // 
            // extra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "extra";
            this.Text = "extra";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_idgrd;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_namegrd;
        private System.Windows.Forms.DataGridViewTextBoxColumn categorygrd;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantitygrd;
        private System.Windows.Forms.DataGridViewTextBoxColumn racknogrd;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode_grd;
    }
}