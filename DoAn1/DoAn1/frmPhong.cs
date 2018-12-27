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
    public partial class frmPhong : Form
    {
        public frmPhong()
        {
            InitializeComponent();
        }

        bool flag;
        LinqDataContext dbs = new LinqDataContext();

        void LoadData()
        {
            var Phong = from x in dbs.PhongHocs select new {x.MaPH , x.TenPH };
            dgvPhong.DataSource = Phong.ToList();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Muốn Xóa ?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (tl == DialogResult.OK)
            {
                int n = dgvPhong.CurrentCell.RowIndex;
                int iMaPH = Convert.ToInt32(dgvPhong.Rows[n].Cells[0].Value.ToString());
                if (dbs.Liches.FirstOrDefault(p => p.Phong == iMaPH) != null)
                    MessageBox.Show("Phòng này Đang Được Phân Công, Không Thể Xóa", "Thông Báo");
                else
                {
                    PhongHoc ph = dbs.PhongHocs.First(p => p.MaPH == iMaPH);
                    dbs.PhongHocs.DeleteOnSubmit(ph);
                    dbs.SubmitChanges();
                    LoadData();
                }
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            DialogResult tl = MessageBox.Show("Bạn Muốn Lưu ?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (tl == DialogResult.OK)
            {
                PhongHoc phonghoc;
                if (flag)
                {
                    phonghoc = new PhongHoc();
                    if (dbs.PhongHocs.Count() == 0)
                        phonghoc.myIndex = 1;
                    else
                        phonghoc.myIndex = Convert.ToInt32(dbs.PhongHocs.Max(p => p.myIndex)) + 1;
                    phonghoc.MaPH = Convert.ToInt32(phonghoc.myIndex);
                }
                else
                {
                    int n = dgvPhong.CurrentCell.RowIndex;
                    int iMaPH = Convert.ToInt32(dgvPhong.Rows[n].Cells[0].Value.ToString());
                    phonghoc = dbs.PhongHocs.FirstOrDefault(p => p.MaPH == iMaPH);
                }
                phonghoc.TenPH = txtTenPhong.Text;
                if (flag)
                    dbs.PhongHocs.InsertOnSubmit(phonghoc);
                dbs.SubmitChanges();
            }

            LoadData();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            flag = true;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            txtTenPhong.ResetText();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = false;
            grpInfor.Enabled = true;
            btnLuu.Enabled = true;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            btnLuu.Enabled = false;
            ResetText();
        }
        private void frmPhong_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = dgvPhong.CurrentCell.RowIndex;
            int iMaPH = Convert.ToInt32(dgvPhong.Rows[n].Cells[0].Value.ToString());
            txtTenPhong.Text = dbs.PhongHocs.FirstOrDefault(p => p.MaPH == iMaPH).TenPH;
        }
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
