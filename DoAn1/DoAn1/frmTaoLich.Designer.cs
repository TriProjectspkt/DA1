namespace DoAn1
{
    partial class frmTaoLich
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
            this.dgvPhanCongDate = new System.Windows.Forms.DataGridView();
            this.NamHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTaoLich = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.cbbTenGV = new System.Windows.Forms.ComboBox();
            this.btnTheoGV = new System.Windows.Forms.Button();
            this.cbbNamHoc = new System.Windows.Forms.ComboBox();
            this.cbbHocKy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCongDate)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPhanCongDate
            // 
            this.dgvPhanCongDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanCongDate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamHoc,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvPhanCongDate.Location = new System.Drawing.Point(12, 12);
            this.dgvPhanCongDate.Name = "dgvPhanCongDate";
            this.dgvPhanCongDate.Size = new System.Drawing.Size(840, 318);
            this.dgvPhanCongDate.TabIndex = 0;
            // 
            // NamHoc
            // 
            this.NamHoc.DataPropertyName = "NamHoc";
            this.NamHoc.HeaderText = "Năm Học";
            this.NamHoc.Name = "NamHoc";
            this.NamHoc.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "HocKy";
            this.Column2.HeaderText = "Học Kỳ";
            this.Column2.Name = "Column2";
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Ngay";
            this.Column3.HeaderText = "Ngày";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.DataPropertyName = "ThoiDiem";
            this.Column4.HeaderText = "Thời Gian";
            this.Column4.Name = "Column4";
            this.Column4.Width = 72;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TenPH";
            this.Column5.HeaderText = "Phòng";
            this.Column5.Name = "Column5";
            this.Column5.Width = 50;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.DataPropertyName = "GVHD";
            this.Column6.HeaderText = "Giảng Viên Hướng Dẫn";
            this.Column6.Name = "Column6";
            this.Column6.Width = 112;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.DataPropertyName = "GVPB";
            this.Column7.HeaderText = "Giảng Viên Phản Biện";
            this.Column7.Name = "Column7";
            this.Column7.Width = 105;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.DataPropertyName = "UV";
            this.Column8.HeaderText = "Ủy Viên";
            this.Column8.Name = "Column8";
            this.Column8.Width = 64;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column9.DataPropertyName = "SV1";
            this.Column9.HeaderText = "Sinh Viên 1";
            this.Column9.Name = "Column9";
            this.Column9.Width = 71;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column10.DataPropertyName = "SV2";
            this.Column10.HeaderText = "Sinh Viên 2";
            this.Column10.Name = "Column10";
            this.Column10.Width = 71;
            // 
            // btnTaoLich
            // 
            this.btnTaoLich.BackColor = System.Drawing.Color.Red;
            this.btnTaoLich.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoLich.ForeColor = System.Drawing.Color.Black;
            this.btnTaoLich.Location = new System.Drawing.Point(858, 12);
            this.btnTaoLich.Name = "btnTaoLich";
            this.btnTaoLich.Size = new System.Drawing.Size(208, 59);
            this.btnTaoLich.TabIndex = 8;
            this.btnTaoLich.Text = "Tiếng Hành Tạo Lịch";
            this.btnTaoLich.UseVisualStyleBackColor = false;
            this.btnTaoLich.Click += new System.EventHandler(this.btnTaoLich_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(858, 271);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(208, 59);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Xóa Lịch\r\n";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.Red;
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForeColor = System.Drawing.Color.Black;
            this.btnXuatExcel.Location = new System.Drawing.Point(858, 206);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(208, 59);
            this.btnXuatExcel.TabIndex = 10;
            this.btnXuatExcel.Text = "Xuất File";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // cbbTenGV
            // 
            this.cbbTenGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTenGV.FormattingEnabled = true;
            this.cbbTenGV.Location = new System.Drawing.Point(127, 354);
            this.cbbTenGV.Name = "cbbTenGV";
            this.cbbTenGV.Size = new System.Drawing.Size(320, 33);
            this.cbbTenGV.TabIndex = 11;
            this.cbbTenGV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTenGV_KeyPress);
            // 
            // btnTheoGV
            // 
            this.btnTheoGV.BackColor = System.Drawing.Color.Red;
            this.btnTheoGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheoGV.ForeColor = System.Drawing.Color.Black;
            this.btnTheoGV.Location = new System.Drawing.Point(858, 142);
            this.btnTheoGV.Name = "btnTheoGV";
            this.btnTheoGV.Size = new System.Drawing.Size(208, 58);
            this.btnTheoGV.TabIndex = 12;
            this.btnTheoGV.Text = "Load Lịch";
            this.btnTheoGV.UseVisualStyleBackColor = false;
            this.btnTheoGV.Click += new System.EventHandler(this.btnTheoGV_Click);
            // 
            // cbbNamHoc
            // 
            this.cbbNamHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNamHoc.FormattingEnabled = true;
            this.cbbNamHoc.Location = new System.Drawing.Point(557, 354);
            this.cbbNamHoc.Name = "cbbNamHoc";
            this.cbbNamHoc.Size = new System.Drawing.Size(92, 33);
            this.cbbNamHoc.TabIndex = 13;
            this.cbbNamHoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbNamHoc_KeyPress);
            // 
            // cbbHocKy
            // 
            this.cbbHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbHocKy.FormattingEnabled = true;
            this.cbbHocKy.Location = new System.Drawing.Point(760, 354);
            this.cbbHocKy.Name = "cbbHocKy";
            this.cbbHocKy.Size = new System.Drawing.Size(92, 33);
            this.cbbHocKy.TabIndex = 14;
            this.cbbHocKy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbHocKy_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(459, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Năm Học :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(662, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Học Kỳ    :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = " Giảng Viên :";
            // 
            // frmTaoLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1074, 394);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbHocKy);
            this.Controls.Add(this.cbbNamHoc);
            this.Controls.Add(this.btnTheoGV);
            this.Controls.Add(this.cbbTenGV);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnTaoLich);
            this.Controls.Add(this.dgvPhanCongDate);
            this.Name = "frmTaoLich";
            this.Text = "frmTaoLich";
            this.Load += new System.EventHandler(this.frmTaoLich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCongDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhanCongDate;
        private System.Windows.Forms.Button btnTaoLich;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.ComboBox cbbTenGV;
        private System.Windows.Forms.Button btnTheoGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.ComboBox cbbNamHoc;
        private System.Windows.Forms.ComboBox cbbHocKy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}