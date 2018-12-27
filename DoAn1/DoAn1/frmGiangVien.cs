using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn1
{
    public partial class frmGiangVien : Form
    {
        public frmGiangVien()
        {
            InitializeComponent();
        }

        LinqDataContext dbs = new LinqDataContext();

        void ResetTexts()
        {
            txtTenGV.ResetText();
            txtSLDeTai.ResetText();
            txtSDT.ResetText();
            txtEmail.ResetText();
            txtDiaChi.ResetText();
            txtChucVu.ResetText();
        }

        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            var gv = from x in dbs.GiangViens 
                     where x.MaGV != 0
                     select new {x.MaGV,x.TenGV, x.ChucVu, x.Email, x.SDT, x.DiaChi, x.GioiTinh, x.SLDeTaiToiDa };
            dgvGiangVien.DataSource = gv;


            grpInfor.Enabled = false;
            dgvGiangVien.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
        }

        bool flag;
        private void btnThem_Click(object sender, EventArgs e)
        {
            grpInfor.Enabled = true;
            dgvGiangVien.Enabled = false;
            ResetTexts();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            flag = true;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            grpInfor.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = false;
            grpInfor.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Muốn Lưu ?","Thông Báo",MessageBoxButtons.OKCancel);
            if (tl == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(txtChucVu.Text) || String.IsNullOrEmpty(txtDiaChi.Text) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtSDT.Text) || String.IsNullOrEmpty(txtSLDeTai.Text) || String.IsNullOrEmpty(txtTenGV.Text))
                    MessageBox.Show("Nhập Thiếu Thông Tin", "Thông Báo");
                else
                {
                    GiangVien gv;
                    if (flag)
                    {
                        gv = new GiangVien();
                        if (dbs.GiangViens.Count() == 0)
                            gv.myIndex = 1;
                        else
                            gv.myIndex = Convert.ToInt32(dbs.GiangViens.Max(p => p.myIndex)) + 1;

                        gv.MaGV = Convert.ToInt32(gv.myIndex);
                    }
                    else
                    {
                        int n = dgvGiangVien.CurrentCell.RowIndex;
                        int sMaGV = Convert.ToInt32(dgvGiangVien.Rows[n].Cells[0].Value.ToString());


                        gv = dbs.GiangViens.First(p => p.MaGV == sMaGV);
                    }

                    gv.TenGV = txtTenGV.Text;
                    gv.SDT = txtSDT.Text;
                    if (txtSLDeTai.Text == null || string.IsNullOrEmpty(txtSLDeTai.Text))
                        gv.SLDeTaiToiDa = 0;
                    else
                        gv.SLDeTaiToiDa = Convert.ToInt32(txtSLDeTai.Text);
                    gv.ChucVu = txtChucVu.Text;
                    gv.DiaChi = txtDiaChi.Text;
                    gv.Email = txtEmail.Text;
                    if (ckbGioiTinh.Checked)
                        gv.GioiTinh = "Nam";
                    else
                        gv.GioiTinh = "Nữ";
                    if (flag)
                        dbs.GiangViens.InsertOnSubmit(gv);

                    dbs.SubmitChanges();
                }

                LoadData();
            }
        }

        private void dgvGiangVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = dgvGiangVien.CurrentCell.RowIndex;
            int sMaGV = Convert.ToInt32(dgvGiangVien.Rows[n].Cells[0].Value.ToString());
            GiangVien gv = dbs.GiangViens.First(p => p.MaGV == sMaGV);
            txtChucVu.Text = gv.ChucVu;
            txtDiaChi.Text = gv.DiaChi;
            txtEmail.Text = gv.Email;
            txtSDT.Text = gv.SDT;
            txtSLDeTai.Text = gv.SLDeTaiToiDa.ToString();
            txtTenGV.Text = gv.TenGV;
            if (gv.GioiTinh.Equals("Nam"))
                ckbGioiTinh.Checked = true;
            else
                ckbGioiTinh.Checked = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Muốn Xóa ?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (tl == DialogResult.OK)
            {
                int n = dgvGiangVien.CurrentCell.RowIndex;
                int sMaGV = Convert.ToInt32(dgvGiangVien.Rows[n].Cells[0].Value.ToString());
                if (dbs.PhanCongs.FirstOrDefault(p => (p.GVHuongDan == sMaGV || p.GVPhanBien == sMaGV || p.UyVien == sMaGV)) != null)
                    MessageBox.Show("Giảng Viên Này Đang Được Phân Công Không Thể Xóa", "Thông Báo");
                else
                {
                    GiangVien gv = dbs.GiangViens.First(p => p.MaGV == sMaGV);
                    dbs.GiangViens.DeleteOnSubmit(gv);
                    dbs.SubmitChanges();
                    LoadData();
                }
            }
        }

        private void txtSLDeTai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9'))
              if(e.KeyChar!=8)
                e.Handled = true;
            
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            grpInfor.Enabled = false;
            dgvGiangVien.Enabled = true;
            ResetTexts();
        }
    }
}
