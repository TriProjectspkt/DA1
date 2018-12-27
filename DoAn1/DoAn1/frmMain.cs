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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form gv = new frmGiangVien();
            gv.ShowDialog();
        }

        private void btnDeTai_Click(object sender, EventArgs e)
        {
            Form dt = new frmDeTai();
            dt.ShowDialog();
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            Form pc = new frmPhanCongDeTai();
            pc.ShowDialog();
        }


        private void btnPhong_Click(object sender, EventArgs e)
        {
            Form ph = new frmPhong();
            ph.ShowDialog();
        }

        private void btnLich_Click(object sender, EventArgs e)
        {
            Form li = new frmTaoLich();
            li.ShowDialog();
        }

        private void btnNhom_Click(object sender, EventArgs e)
        {
            //Form nh = new frmNhom();
            //nh.ShowDialog();
        }
    }
}
