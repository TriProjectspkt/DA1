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
    public partial class frmPhanCongDeTai : Form
    {
        public frmPhanCongDeTai()
        {
            InitializeComponent();
        }
        LinqDataContext dbs = new LinqDataContext();
        bool flag;

        void ResetTexts()
        {
            cbbNhomSV.ResetText();
            cbbTenDT.ResetText();
            cbbGVHD.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            grpInfor.Enabled = true;
            dgvPhanCong.Enabled = false;
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
            dgvPhanCong.Enabled = true;
        }


        bool checkError()
        {

            var detai = from dt in dbs.DeTais
                        where dt.TenDT == cbbTenDT.Text && dt.HocKy == Convert.ToInt32(cbbHocKy.Text) && dt.NamHoc == Convert.ToInt32(cbbNamHoc.Text)
                        select dt;
            if (detai.Count() == 0)
                return true;


            return false;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Muốn Lưu ?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (tl == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(cbbGVHD.Text) || String.IsNullOrEmpty(cbbHocKy.Text) || String.IsNullOrEmpty(cbbNhomSV.Text) || String.IsNullOrEmpty(cbbTenDT.Text) || string.IsNullOrEmpty(cbbNamHoc.Text))
                    MessageBox.Show("Nhập Thiếu Thông Tin", "Thông Báo");
                else
                    if(checkError())
                    {
                        MessageBox.Show("Thông Tin Nhập Vào Không Đúng,Xem Lại Thông Tin Vừa Nhập", "Thông Báo");
                    }
                    else
                    {
                        PhanCong pc;
                        if (flag)
                        {
                            pc = new PhanCong();
                            if (dbs.PhanCongs.Count() == 0)
                                pc.myIndex = 1;
                            else
                                pc.myIndex = Convert.ToInt32(dbs.PhanCongs.Max(p => p.myIndex)) + 1;
                            pc.MaPC = Convert.ToInt32(pc.myIndex) + 1;
                            pc.GVHuongDan = Convert.ToInt32(cbbGVHD.SelectedValue);
                            pc.TenDeTai = cbbTenDT.Text;
                            pc.MaNhom = Convert.ToInt32(cbbNhomSV.Text);
                            pc.HocKy = Convert.ToInt32(cbbHocKy.Text);
                            pc.NamHoc = Convert.ToInt32(cbbNamHoc.Text);
                            dbs.PhanCongs.InsertOnSubmit(pc);
                        }
                        else
                        {
                            int n = dgvPhanCong.CurrentCell.RowIndex;
                            int iMaPC = Convert.ToInt32(dgvPhanCong.Rows[n].Cells[0].Value.ToString());
                          //  dbs.SubmitChanges();
                            pc = dbs.PhanCongs.First(p => p.MaPC == iMaPC);

                            pc.GiangVien = dbs.GiangViens.FirstOrDefault(p => p.MaGV == Convert.ToInt32(cbbGVHD.SelectedValue));
                            pc.DeTai = dbs.DeTais.FirstOrDefault(p => p.TenDT == cbbTenDT.Text && p.HocKy == Convert.ToInt32(cbbHocKy.Text) && p.NamHoc == Convert.ToInt32(cbbNamHoc.Text));
                      //      pc.TenDeTai = cbbTenDT.Text;
                            pc.MaNhom = Convert.ToInt32(cbbNhomSV.Text);
                            pc.HocKy = Convert.ToInt32(cbbHocKy.Text);
                            if (String.IsNullOrEmpty(cbbNamHoc.Text))
                                pc.NamHoc = 0;
                            else
                                pc.NamHoc = Convert.ToInt32(cbbNamHoc.Text);
                        }
                        dbs.SubmitChanges();
                        LoadData();
                    }
                }
        }

        private void dgvPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = dgvPhanCong.CurrentCell.RowIndex;
            int iMaPC = Convert.ToInt32(dgvPhanCong.Rows[n].Cells[0].Value.ToString());
            PhanCong pc = dbs.PhanCongs.First(p => p.MaPC == iMaPC);
            cbbNhomSV.Text = pc.MaNhom.ToString();
            cbbTenDT.Text = pc.DeTai.TenDT;
            cbbHocKy.Text = pc.HocKy.ToString();
            cbbNamHoc.Text = pc.NamHoc.ToString();
            cbbGVHD.Text = pc.GiangVien.TenGV;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Muốn Xóa ?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (tl == DialogResult.OK)
            {
                 
                int n = dgvPhanCong.CurrentCell.RowIndex;
                int iMaPC = Convert.ToInt32(dgvPhanCong.Rows[n].Cells[0].Value.ToString());
                if (dbs.Liches.FirstOrDefault(p => p.MaPC == iMaPC) != null)
                    MessageBox.Show("Phân Công Này Đã Được Lên Lịch Không Xóa Được", "Thông Báo");
                else
                {
                    PhanCong pc = dbs.PhanCongs.First(p => p.MaPC == iMaPC);
                    dbs.PhanCongs.DeleteOnSubmit(pc);
                    dbs.SubmitChanges();
                    LoadData();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            grpInfor.Enabled = false;
            dgvPhanCong.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            ResetTexts();
        }


        void LoadData()
        {

            //var pc = from x in dbs.PhanCongs select x;

            var phancong = from pc in dbs.PhanCongs
                      from dt in dbs.DeTais
                      from gv in dbs.GiangViens
                      from nh in dbs.Nhoms
                      where pc.MaNhom == nh.MaNhom && pc.GVHuongDan == gv.MaGV && pc.TenDeTai == dt.TenDT && pc.NamHoc == dt.NamHoc && pc.HocKy == dt.HocKy
                      select new { pc.MaPC, gv.TenGV, dt.TenDT, nh.SV1, nh.SV2 ,pc.NamHoc,pc.HocKy};

            dgvPhanCong.DataSource = phancong.ToList();


            var gvhd = from x in dbs.GiangViens
                       where (x.SLDeTaiToiDa > dbs.PhanCongs.Where(p => p.GVHuongDan == x.MaGV).Count())
                       select x;

            cbbGVHD.DataSource = gvhd.ToList();
            cbbGVHD.DisplayMember = "TenGV";
            cbbGVHD.ValueMember = "MaGV";


            var nhom = from x in dbs.Nhoms
                     where (dbs.PhanCongs.First(p => p.MaNhom == x.MaNhom) == null)
                     select x.MaNhom;

            cbbNhomSV.DataSource = nhom.ToList();
            cbbNhomSV.DisplayMember = "MaNhom";


            int[] hocky = new int[3] { 1, 2, 3 };
            cbbHocKy.DataSource = hocky.ToList();

            var namhoc = (from x in dbs.DeTais
                         select new { x.NamHoc }).Distinct();

            cbbNamHoc.DataSource = namhoc.ToList();
            cbbNamHoc.DisplayMember = "NamHoc";


            grpInfor.Enabled = false;
            dgvPhanCong.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void frmPhanCongDeTai_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNhom_Click(object sender, EventArgs e)
        {
            frmNhomSV f = new frmNhomSV();
            f.ShowDialog();
            LoadData();
        }

        private void txtNamHoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9'))
                if (e.KeyChar != 8)
                    e.Handled = true;
        }

        private void cbbGVHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbTenDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbNhomSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbHocKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnLoadDeTai_Click(object sender, EventArgs e)
        {
            var dtpc = from x in dbs.PhanCongs select new { x.TenDeTai, x.NamHoc, x.HocKy };


            var detai = dbs.sp_getDeTaiChuaDuocPhanCong(Convert.ToInt32(cbbHocKy.Text), Convert.ToInt32(cbbNamHoc.Text));

            cbbTenDT.DataSource = detai.ToList();
            cbbTenDT.DisplayMember = "TenDT";
        }

        private void cbbNamHoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbTenDT.DataSource = null;
        }

        private void cbbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbTenDT.DataSource = null;
        }

   
    }
}
