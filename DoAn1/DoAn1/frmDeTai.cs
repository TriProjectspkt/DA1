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
    public partial class frmDeTai : Form
    {
        public frmDeTai()
        {
            InitializeComponent();
        }
        bool flag;
        LinqDataContext dbs = new LinqDataContext();
        private void frmDeTai_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            flag = true;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            txtTenDT.ResetText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = false;
            grpInfor.Enabled = true;
            btnLuu.Enabled = true;
        }


        bool checkAlreadyExist()
        {
            var detai = from dt in dbs.DeTais
                        where dt.TenDT == txtTenDT.Text && dt.NamHoc == Convert.ToInt32(txtNamHoc.Text) && dt.HocKy == Convert.ToInt32(cbbHocKy.Text)
                        select dt;
            if (detai.Count() > 0)
                return true;
            return false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            DialogResult tl = MessageBox.Show("Bạn Muốn Lưu ?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (tl == DialogResult.OK)
            {
                if (checkAlreadyExist())
                {
                    MessageBox.Show("Thông Tin Bị Trùng Xem Lại Thông Tin Vừa Nhập", "Thông Báo");
                }
                else
                {

                    if (!String.IsNullOrEmpty(txtNamHoc.Text) && !String.IsNullOrEmpty(txtTenDT.Text) && !String.IsNullOrEmpty(cbbHocKy.Text))
                    {

                        DeTai detai = new DeTai();
                        detai.TenDT = txtTenDT.Text;
                        detai.NamHoc = Convert.ToInt32(txtNamHoc.Text);
                        detai.HocKy = Convert.ToInt32(cbbHocKy.Text);

                        if (flag)
                            dbs.DeTais.InsertOnSubmit(detai);
                        else
                        {
                            int n = dgvDeTai.CurrentCell.RowIndex;
                            string TenDeTai = dgvDeTai.Rows[n].Cells[0].Value.ToString();
                            int NamHoc = Convert.ToInt32(dgvDeTai.Rows[n].Cells[1].Value);
                            int HocKy = Convert.ToInt32(dgvDeTai.Rows[n].Cells[2].Value);



                            PhanCong pc = dbs.PhanCongs.FirstOrDefault(p => p.DeTai.TenDT == TenDeTai && p.DeTai.NamHoc == NamHoc && p.DeTai.HocKy == HocKy);
                            if (pc != null)
                            {
                                pc.DeTai = null;
                                dbs.SubmitChanges();
                            }

                            var dt = dbs.DeTais.FirstOrDefault(p => p.TenDT == TenDeTai && p.NamHoc == NamHoc && p.HocKy == HocKy);
                            dbs.DeTais.DeleteOnSubmit(dt);

                            if (pc != null)
                            {
                                dbs.DeTais.InsertOnSubmit(detai);
                                pc.DeTai.TenDT = txtTenDT.Text;
                                pc.DeTai.NamHoc = Convert.ToInt32(txtNamHoc.Text);
                                pc.DeTai.HocKy = Convert.ToInt32(cbbHocKy.Text);
                            }
                            else
                                dbs.DeTais.InsertOnSubmit(detai);
                        }
                        dbs.SubmitChanges();
                        LoadData();
                    }
                    else
                        MessageBox.Show("Nhập Thiếu", "Thông Báo");
                }
            }
        }

        void LoadData()
        {
            var dt = from x in dbs.DeTais  select new {x.TenDT,x.NamHoc,x.HocKy};
            dgvDeTai.DataSource = dt.ToList();

            int[] HocKy = new int[3] {1,2,3};
            cbbHocKy.DataSource = HocKy.ToList();
            

            btnLuu.Enabled = false;
        }

        private void dgvDeTai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = dgvDeTai.CurrentCell.RowIndex;
            string TenDeTai = dgvDeTai.Rows[n].Cells[0].Value.ToString();
            int NamHoc = Convert.ToInt32(dgvDeTai.Rows[n].Cells[1].Value);
            int HocKy = Convert.ToInt32(dgvDeTai.Rows[n].Cells[2].Value);
            txtTenDT.Text = TenDeTai;
            txtNamHoc.Text = NamHoc.ToString();
            cbbHocKy.Text = HocKy.ToString();
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            btnLuu.Enabled = false;
            ResetText();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Muốn Xóa ?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (tl == DialogResult.OK)
            {
                int n = dgvDeTai.CurrentCell.RowIndex;
                string TenDeTai = dgvDeTai.Rows[n].Cells[0].Value.ToString();
                int NamHoc = Convert.ToInt32(dgvDeTai.Rows[n].Cells[1].Value);
                int HocKy = Convert.ToInt32(dgvDeTai.Rows[n].Cells[2].Value);
                if (dbs.PhanCongs.FirstOrDefault(p => p.TenDeTai == TenDeTai) != null)
                    MessageBox.Show("Đề Tài này Đang Được Phân Công, Không Thể Xóa", "Thông Báo");
                else
                {
                    DeTai dt = dbs.DeTais.First(p => p.TenDT == TenDeTai && p.NamHoc == NamHoc && p.HocKy == HocKy);
                    dbs.DeTais.DeleteOnSubmit(dt);
                    dbs.SubmitChanges();
                    LoadData();
                }
            }
        }

        private void txtNamHoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9'))
                if (e.KeyChar != 8)
                    e.Handled = true;
        }

     



    }
}
