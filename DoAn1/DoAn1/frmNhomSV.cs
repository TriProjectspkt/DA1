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
    public partial class frmNhomSV : Form
    {
        public frmNhomSV()
        {
            InitializeComponent();
        }

        private void frmNhomSV_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        LinqDataContext dbs = new LinqDataContext();

        void LoadData()
        {
            dgvNhom.DataSource = (from x in dbs.Nhoms select x).ToList();
            btnLuu.Enabled = false;
        }

        bool flag;

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            flag = true;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            txtSV1.ResetText();
            txtSV2.ResetText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = false;
            grpInfor.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Muốn Lưu ?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (tl == DialogResult.OK)
            {
                Nhom nh;
                if (flag)
                {
                    nh = new Nhom();
                    if (dbs.Nhoms.Count() == 0)
                        nh.myIndex = 1;
                    else
                        nh.myIndex = Convert.ToInt32(dbs.Nhoms.Max(p => p.myIndex)) + 1;
                    nh.MaNhom = Convert.ToInt32(nh.myIndex) + 1;
                }
                else
                {
                    int n = dgvNhom.CurrentCell.RowIndex;
                    int iMaNhom = Convert.ToInt32(dgvNhom.Rows[n].Cells[0].Value.ToString());
                    nh = dbs.Nhoms.FirstOrDefault(p => p.MaNhom == iMaNhom);
                }

                nh.SV1 = txtSV1.Text;
                nh.SV2 = txtSV2.Text;

                if (flag)
                    dbs.Nhoms.InsertOnSubmit(nh);
                dbs.SubmitChanges();
            }

            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Muốn Xóa ?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (tl == DialogResult.OK)
            {


                int n = dgvNhom.CurrentCell.RowIndex;
                int iMaNhom = Convert.ToInt32(dgvNhom.Rows[n].Cells[0].Value.ToString());

                if (dbs.PhanCongs.FirstOrDefault(p => p.MaNhom == iMaNhom) != null)
                    MessageBox.Show("Nhóm Này Đang Được Phân Công ,Không Thể Xóa", "Thông Báo");
                else
                {

                    Nhom nh = dbs.Nhoms.First(p => p.MaNhom == iMaNhom);
                    dbs.Nhoms.DeleteOnSubmit(nh);
                    dbs.SubmitChanges();
                    LoadData();
                }
            }
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
            ResetText();
        }

        private void dgvNhom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = dgvNhom.CurrentCell.RowIndex;
            int iMaNhom = Convert.ToInt32(dgvNhom.Rows[n].Cells[0].Value.ToString());
            Nhom nh = dbs.Nhoms.First(p => p.MaNhom == iMaNhom);
            txtSV1.Text = nh.SV1;
            txtSV2.Text = nh.SV2;
        }
    }
}
