
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;
namespace DoAn1
{
    public partial class frmTaoLich : Form
    {
        public frmTaoLich()
        {
            InitializeComponent();
        }
        LinqDataContext dbs = new LinqDataContext();



        void TaoLich()
        {
            DialogResult tl = MessageBox.Show("Bạn Muốn Tạo Lịch Mới (Lịch Cũ Sẽ Bị Xóa) Theo chi tiết bên dưới", "Thông Báo", MessageBoxButtons.OKCancel);

            if (tl == DialogResult.OK)
            {
                //000
                if (cbbTenGV.Text.Equals("Tất Cả"))
                {
                    if (cbbTenGV.Text.Equals("Tất Cả") && cbbNamHoc.Text.Equals("Tất Cả") && cbbHocKy.Text.Equals("Tất Cả"))
                    {
                        var PhanCong = from x in dbs.PhanCongs select x;
                        foreach (PhanCong pc in PhanCong)
                            phanCongRanDomGV(pc);

                        var lich = from x in dbs.Liches select x;
                        dbs.Liches.DeleteAllOnSubmit(lich);

                        TaoLichRanDom(true, true, true);
                    }
                    //010
                    if (cbbTenGV.Text.Equals("Tất Cả") && !cbbNamHoc.Text.Equals("Tất Cả") && cbbHocKy.Text.Equals("Tất Cả"))
                    {
                        var lich = from li in dbs.Liches
                                   from pc in dbs.PhanCongs
                                   where li.MaPC == pc.MaPC && pc.NamHoc == Convert.ToInt32(cbbNamHoc.Text)
                                   select li;
                        dbs.Liches.DeleteAllOnSubmit(lich);
                        TaoLichRanDom(true, false, true);
                    }
                    //001
                    if (cbbTenGV.Text.Equals("Tất Cả") && cbbNamHoc.Text.Equals("Tất Cả") && !cbbHocKy.Text.Equals("Tất Cả"))
                    {
                        var lich = from li in dbs.Liches
                                   from pc in dbs.PhanCongs
                                   where li.MaPC == pc.MaPC && pc.HocKy == Convert.ToInt32(cbbHocKy.Text)
                                   select li;
                        dbs.Liches.DeleteAllOnSubmit(lich);
                        TaoLichRanDom(true, true, false);
                    }


                    //011
                    if (cbbTenGV.Text.Equals("Tất Cả") && !cbbNamHoc.Text.Equals("Tất Cả") && !cbbHocKy.Text.Equals("Tất Cả"))
                    {
                        var lich = from li in dbs.Liches
                                   from pc in dbs.PhanCongs
                                   where li.MaPC == pc.MaPC && pc.HocKy == Convert.ToInt32(cbbHocKy.Text) && pc.NamHoc == Convert.ToInt32(cbbNamHoc.Text)
                                   select li;
                        dbs.Liches.DeleteAllOnSubmit(lich);
                        TaoLichRanDom(true, false, false);
                    }
                    dbs.SubmitChanges();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Mục Giảng Viên Phải Chọn Tất Cả", "Error");
                }
            }
        }

        List<string> khoiTaoListNamHoc()
        {
            var NamHoc = (from x in dbs.PhanCongs select new { x.NamHoc }).Distinct();

            List<String> lNamHoc = new List<string>();
            String str = "Tất Cả";
            lNamHoc.Add(str);
            foreach (var x in NamHoc)
            {
                String a = x.NamHoc.ToString();

                lNamHoc.Add(a);
            }
            return lNamHoc;
        }
        List<string> khoiTaoListHocKy()
        {
            var HocKY = (from x in dbs.PhanCongs select new { x.HocKy }).Distinct();

            List<String> lHocKy = new List<string>();
            String str = "Tất Cả";
            lHocKy.Add(str);
            foreach (var x in HocKY)
            {
                String a = x.HocKy.ToString();

                lHocKy.Add(a);
            }
            return lHocKy;
        }



        void LoadData()
        {
            //000
            if (cbbTenGV.Text.Equals("Tất Cả") && cbbNamHoc.Text.Equals("Tất Cả") && cbbHocKy.Text.Equals("Tất Cả"))
            {
                var lich = from l in dbs.Liches
                           from gvhd in dbs.GiangViens
                           from gvpb in dbs.GiangViens
                           from uv in dbs.GiangViens
                           from pc in dbs.PhanCongs
                           from nh in dbs.Nhoms
                           where l.MaPC == pc.MaPC && pc.GVHuongDan == gvhd.MaGV && pc.GVPhanBien == gvpb.MaGV && pc.UyVien == uv.MaGV && nh.MaNhom == pc.MaNhom
                           orderby pc.NamHoc, pc.HocKy, l.Ngay, l.Ca, l.PhongHoc.TenPH
                           select new { pc.NamHoc, pc.HocKy, l.Ngay, l.CaTrongNgay.ThoiDiem, l.PhongHoc.TenPH, GVHD = gvhd.TenGV, GVPB = gvpb.TenGV, UV = uv.TenGV, nh.SV1, nh.SV2 };
                dgvPhanCongDate.DataSource = lich.ToList();
            }
            //100
            if (!cbbTenGV.Text.Equals("Tất Cả") && cbbNamHoc.Text.Equals("Tất Cả") && cbbHocKy.Text.Equals("Tất Cả"))
            {

                var lich = from l in dbs.Liches
                           from gvhd in dbs.GiangViens
                           from gvpb in dbs.GiangViens
                           from uv in dbs.GiangViens
                           from pc in dbs.PhanCongs
                           from nh in dbs.Nhoms
                           where l.MaPC == pc.MaPC && pc.GVHuongDan == gvhd.MaGV && pc.GVPhanBien == gvpb.MaGV && pc.UyVien == uv.MaGV && nh.MaNhom == pc.MaNhom && (pc.GiangVien.TenGV == cbbTenGV.Text || pc.GiangVien1.TenGV == cbbTenGV.Text || pc.GiangVien2.TenGV == cbbTenGV.Text)
                           orderby pc.NamHoc, pc.HocKy, l.Ngay, l.Ca, l.PhongHoc.TenPH
                           select new { pc.NamHoc, pc.HocKy, l.Ngay, l.CaTrongNgay.ThoiDiem, l.PhongHoc.TenPH, GVHD = gvhd.TenGV, GVPB = gvpb.TenGV, UV = uv.TenGV, nh.SV1, nh.SV2 };
                dgvPhanCongDate.DataSource = lich.ToList();
            }
            //010
            if (cbbTenGV.Text.Equals("Tất Cả") && !cbbNamHoc.Text.Equals("Tất Cả") && cbbHocKy.Text.Equals("Tất Cả"))
            {

                var lich = from l in dbs.Liches
                           from gvhd in dbs.GiangViens
                           from gvpb in dbs.GiangViens
                           from uv in dbs.GiangViens
                           from pc in dbs.PhanCongs
                           from nh in dbs.Nhoms
                           where l.MaPC == pc.MaPC && pc.GVHuongDan == gvhd.MaGV && pc.GVPhanBien == gvpb.MaGV && pc.UyVien == uv.MaGV
                           && nh.MaNhom == pc.MaNhom && pc.NamHoc == Convert.ToInt32(cbbNamHoc.Text)

                           orderby pc.NamHoc, pc.HocKy, l.Ngay, l.Ca, l.PhongHoc.TenPH
                           select new { pc.NamHoc, pc.HocKy, l.Ngay, l.CaTrongNgay.ThoiDiem, l.PhongHoc.TenPH, GVHD = gvhd.TenGV, GVPB = gvpb.TenGV, UV = uv.TenGV, nh.SV1, nh.SV2 };
                dgvPhanCongDate.DataSource = lich.ToList();
            }
            //001
            if (cbbTenGV.Text.Equals("Tất Cả") && cbbNamHoc.Text.Equals("Tất Cả") && !cbbHocKy.Text.Equals("Tất Cả"))
            {

                var lich = from l in dbs.Liches
                           from gvhd in dbs.GiangViens
                           from gvpb in dbs.GiangViens
                           from uv in dbs.GiangViens
                           from pc in dbs.PhanCongs
                           from nh in dbs.Nhoms
                           where l.MaPC == pc.MaPC && pc.GVHuongDan == gvhd.MaGV && pc.GVPhanBien == gvpb.MaGV && pc.UyVien == uv.MaGV
                           && nh.MaNhom == pc.MaNhom && pc.NamHoc == Convert.ToInt32(cbbNamHoc.Text) && pc.HocKy == Convert.ToInt32(cbbHocKy.Text)

                           orderby pc.NamHoc, pc.HocKy, l.Ngay, l.Ca, l.PhongHoc.TenPH
                           select new { pc.NamHoc, pc.HocKy, l.Ngay, l.CaTrongNgay.ThoiDiem, l.PhongHoc.TenPH, GVHD = gvhd.TenGV, GVPB = gvpb.TenGV, UV = uv.TenGV, nh.SV1, nh.SV2 };
                dgvPhanCongDate.DataSource = lich.ToList();
            }
            //110
            if (!cbbTenGV.Text.Equals("Tất Cả") && !cbbNamHoc.Text.Equals("Tất Cả") && cbbHocKy.Text.Equals("Tất Cả"))
            {
                var lich = from l in dbs.Liches
                           from gvhd in dbs.GiangViens
                           from gvpb in dbs.GiangViens
                           from uv in dbs.GiangViens
                           from pc in dbs.PhanCongs
                           from nh in dbs.Nhoms
                           where l.MaPC == pc.MaPC && pc.GVHuongDan == gvhd.MaGV && pc.GVPhanBien == gvpb.MaGV && pc.UyVien == uv.MaGV
                           && nh.MaNhom == pc.MaNhom && pc.NamHoc == Convert.ToInt32(cbbNamHoc.Text)
                           && (pc.GiangVien.TenGV == cbbTenGV.Text || pc.GiangVien1.TenGV == cbbTenGV.Text || pc.GiangVien2.TenGV == cbbTenGV.Text)

                           orderby pc.NamHoc, pc.HocKy, l.Ngay, l.Ca, l.PhongHoc.TenPH
                           select new { pc.NamHoc, pc.HocKy, l.Ngay, l.CaTrongNgay.ThoiDiem, l.PhongHoc.TenPH, GVHD = gvhd.TenGV, GVPB = gvpb.TenGV, UV = uv.TenGV, nh.SV1, nh.SV2 };
                dgvPhanCongDate.DataSource = lich.ToList();
            }
            //101
            if (!cbbTenGV.Text.Equals("Tất Cả") && cbbNamHoc.Text.Equals("Tất Cả") && !cbbHocKy.Text.Equals("Tất Cả"))
            {
                var lich = from l in dbs.Liches
                           from gvhd in dbs.GiangViens
                           from gvpb in dbs.GiangViens
                           from uv in dbs.GiangViens
                           from pc in dbs.PhanCongs
                           from nh in dbs.Nhoms
                           where l.MaPC == pc.MaPC && pc.GVHuongDan == gvhd.MaGV && pc.GVPhanBien == gvpb.MaGV && pc.UyVien == uv.MaGV
                           && nh.MaNhom == pc.MaNhom && pc.HocKy == Convert.ToInt32(cbbHocKy.Text)
                           && (pc.GiangVien.TenGV == cbbTenGV.Text || pc.GiangVien1.TenGV == cbbTenGV.Text || pc.GiangVien2.TenGV == cbbTenGV.Text)

                           orderby pc.NamHoc, pc.HocKy, l.Ngay, l.Ca, l.PhongHoc.TenPH
                           select new { pc.NamHoc, pc.HocKy, l.Ngay, l.CaTrongNgay.ThoiDiem, l.PhongHoc.TenPH, GVHD = gvhd.TenGV, GVPB = gvpb.TenGV, UV = uv.TenGV, nh.SV1, nh.SV2 };
                dgvPhanCongDate.DataSource = lich.ToList();
            }
            //011
            if (cbbTenGV.Text.Equals("Tất Cả") && !cbbNamHoc.Text.Equals("Tất Cả") && !cbbHocKy.Text.Equals("Tất Cả"))
            {
                var lich = from l in dbs.Liches
                           from gvhd in dbs.GiangViens
                           from gvpb in dbs.GiangViens
                           from uv in dbs.GiangViens
                           from pc in dbs.PhanCongs
                           from nh in dbs.Nhoms
                           where l.MaPC == pc.MaPC && pc.GVHuongDan == gvhd.MaGV && pc.GVPhanBien == gvpb.MaGV && pc.UyVien == uv.MaGV
                           && nh.MaNhom == pc.MaNhom && pc.HocKy == Convert.ToInt32(cbbHocKy.Text) && pc.NamHoc == Convert.ToInt32(cbbNamHoc.Text)

                           orderby pc.NamHoc, pc.HocKy, l.Ngay, l.Ca, l.PhongHoc.TenPH
                           select new { pc.NamHoc, pc.HocKy, l.Ngay, l.CaTrongNgay.ThoiDiem, l.PhongHoc.TenPH, GVHD = gvhd.TenGV, GVPB = gvpb.TenGV, UV = uv.TenGV, nh.SV1, nh.SV2 };
                dgvPhanCongDate.DataSource = lich.ToList();
            }

            //111
            if (!cbbTenGV.Text.Equals("Tất Cả") && !cbbNamHoc.Text.Equals("Tất Cả") && !cbbHocKy.Text.Equals("Tất Cả"))
            {
                var lich = from l in dbs.Liches
                           from gvhd in dbs.GiangViens
                           from gvpb in dbs.GiangViens
                           from uv in dbs.GiangViens
                           from pc in dbs.PhanCongs
                           from nh in dbs.Nhoms
                           where l.MaPC == pc.MaPC && pc.GVHuongDan == gvhd.MaGV && pc.GVPhanBien == gvpb.MaGV && pc.UyVien == uv.MaGV
                           && nh.MaNhom == pc.MaNhom && pc.HocKy == Convert.ToInt32(cbbHocKy.Text) && pc.NamHoc == Convert.ToInt32(cbbNamHoc.Text)
                            && (pc.GiangVien.TenGV == cbbTenGV.Text || pc.GiangVien1.TenGV == cbbTenGV.Text || pc.GiangVien2.TenGV == cbbTenGV.Text)

                           orderby pc.NamHoc, pc.HocKy, l.Ngay, l.Ca, l.PhongHoc.TenPH
                           select new { pc.NamHoc, pc.HocKy, l.Ngay, l.CaTrongNgay.ThoiDiem, l.PhongHoc.TenPH, GVHD = gvhd.TenGV, GVPB = gvpb.TenGV, UV = uv.TenGV, nh.SV1, nh.SV2 };
                dgvPhanCongDate.DataSource = lich.ToList();

            }
        }


        int RanDom_GVPB_UV(int SLGV, int GV1, int GV2)
        {
            int Ma_GVPB_UV = new Random().Next(1, SLGV);
            while (true)
            {
                if (Ma_GVPB_UV != GV1 && Ma_GVPB_UV != GV2)
                    break;
                Ma_GVPB_UV = new Random().Next(1, SLGV);
            }
            return Ma_GVPB_UV;
        }
        void phanCongRanDomGV(PhanCong pc)
        {
            var PhanCong = from x in dbs.PhanCongs select x;

            int SLGV = dbs.GiangViens.Count();

            int MaGVHD = Convert.ToInt32(pc.GVHuongDan);
            int MaGVPhanBien;
            int UyVien;

            MaGVPhanBien = RanDom_GVPB_UV(SLGV, MaGVHD, -1);

            UyVien = RanDom_GVPB_UV(SLGV, MaGVHD, MaGVPhanBien);

            pc.GVPhanBien = MaGVPhanBien;
            pc.UyVien = UyVien;

            dbs.SubmitChanges();
        }
        int RanDomSoLuongPhong(int CountPC)
        {
            int soluong = new Random().Next(1, dbs.PhongHocs.Count() + 1);
            double tam = dbs.GiangViens.Count() / 3; // so luong phong toi da
            int MaxPhong = Convert.ToInt32(Math.Floor(tam));

            while (CountPC < soluong || soluong > MaxPhong)
                soluong = new Random().Next(1, dbs.PhongHocs.Count() + 1);
            return soluong;
        }
        void outPutExcel()
        {
            app excel = new app();
            Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
            excel.Columns.ColumnWidth = 50;

            Worksheet ws = (Worksheet)excel.ActiveSheet;

            ws.get_Range("A1", "I1").ColumnWidth = 20;
            ws.Cells[1, 1] = "Nam Học";
            ws.Cells[1, 2] = "Học Kỳ";
            ws.Cells[1, 3] = "Ngày";
            ws.Cells[1, 4] = "Thời Gian";
            ws.Cells[1, 5] = "Phòng";
            ws.Cells[1, 6] = "Giảng Viên Hướng Dẩn";
            ws.Cells[1, 7] = "Giảng Viên Phản Biện";
            ws.Cells[1, 8] = "Ủy Viên";
            ws.Cells[1, 9] = "Sinh Viên 1";
            ws.Cells[1, 10] = "Sinh Viên 2";

            for (int i = 0; i < dgvPhanCongDate.Rows.Count; i++)
            {
                for (int j = 0; j < dgvPhanCongDate.Columns.Count; j++)
                {
                    ws.Cells[i + 2, j + 1] = (dgvPhanCongDate.Rows[i].Cells[j].Value).ToString();
                }
            }
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();

            String url = save.FileName;
            if (!String.IsNullOrEmpty(url))
            {
                ws.SaveAs(url);
                wb.Close();
                MessageBox.Show("Thành Công", "Thông Báo");
            }
        }

        int RanDomMaPhong(int[] checkPhong)
        {
            int SLPhong = dbs.PhongHocs.Count();
            int MaPhong = new Random().Next(1, SLPhong + 1);
            while (true)
            {
                if (checkPhong[MaPhong] == 0)
                {
                    checkPhong[MaPhong]++;
                    break;
                }
                MaPhong = new Random().Next(1, SLPhong + 1);
            }
            return MaPhong;
        }

        int RanDomMaPhanCong(int Ngay, int Ca, ref List<int> lMaPC, ref List<int> ListMaPhanCong, int NamHoc, int HocKy)
        {
            int MaPC = lMaPC[new Random().Next(0, lMaPC.Count())];
            List<int> listPhanCongTrungLich = new List<int>();
            while (true)
            {
                bool checkInTime = CheckTrungThoiGian(MaPC, Ngay, Ca, NamHoc, HocKy);
                if (checkInTime)
                {
                    lMaPC.Remove(MaPC);
                    ListMaPhanCong.Remove(MaPC);
                    break;
                }
                else
                {
                    if (!listPhanCongTrungLich.Contains(MaPC))
                        listPhanCongTrungLich.Add(MaPC);

                    if (listPhanCongTrungLich.Count() == lMaPC.Count())
                        return -1;
                    MaPC = lMaPC[new Random().Next(0, lMaPC.Count())];
                }
            }
            return MaPC;
        }
        bool CheckTrungThoiGian(int MaPC, int Ngay, int Ca, int NamHoc, int HocKy)
        {
            var check = from li in dbs.Liches
                        from pc in dbs.PhanCongs
                        where li.Ngay == Ngay && li.Ca == Ca && pc.MaPC == li.MaPC && pc.NamHoc == NamHoc && pc.HocKy == HocKy && pc.MaPC != MaPC
                        select new { pc.GVHuongDan, pc.GVPhanBien, pc.UyVien };

            int GVHuongDan = Convert.ToInt32(dbs.PhanCongs.First(p => p.MaPC == MaPC).GVHuongDan);
            int GVPhanBien = Convert.ToInt32(dbs.PhanCongs.First(p => p.MaPC == MaPC).GVPhanBien);
            int UyVien = Convert.ToInt32(dbs.PhanCongs.First(p => p.MaPC == MaPC).UyVien);

            foreach (var ck in check)
            {
                if (ck.GVHuongDan == GVHuongDan || ck.GVPhanBien == GVHuongDan || ck.UyVien == GVHuongDan) // gvhd o 1 phong tai 1 thoi diem
                    return false;
                if (ck.GVHuongDan == GVPhanBien || ck.GVPhanBien == GVPhanBien || ck.UyVien == GVPhanBien) // gvkm1 o 1 phong tai 1 thoi diem
                    return false;
                if (ck.GVHuongDan == UyVien || ck.GVPhanBien == UyVien || ck.UyVien == UyVien) // gvkm2 o 1 phong tai 1 thoi diem
                    return false;
                //  MessageBox.Show(ck.GVHuongDan + "/" + ck.GVPhanBien + "/" + ck.UyVien, "asd");

            }
            return true;
        }
        List<int> getAllTablePhanCong()
        {
            var lphancong = from x in dbs.PhanCongs
                            select new { x.MaPC };
            //////////////////////////////////
            if (lphancong.Count() == 0)
                return null;
            //////////////////////////////////
            List<int> lMaPC = new List<int>();
            foreach (var pc in lphancong)
                lMaPC.Add(pc.MaPC);
            return lMaPC;
        }
        List<int> getAllTablePhanCongTheoGiangVien(String MaGV)
        {
            var lphancong = from x in dbs.PhanCongs
                            where x.GiangVien.MaGV == Convert.ToInt32(MaGV) || x.GiangVien1.MaGV == Convert.ToInt32(MaGV) || x.GiangVien2.MaGV == Convert.ToInt32(MaGV)
                            select new { x.MaPC };
            //////////////////////////////////
            if (lphancong.Count() == 0)
                return null;
            //////////////////////////////////
            List<int> lMaPC = new List<int>();
            foreach (var pc in lphancong)
                lMaPC.Add(pc.MaPC);
            return lMaPC;
        }
        List<int> getListPhanCongTheo_NamHoc_HocKy(int NamHoc, int HocKy, List<int> ListMaPhanCong)
        {
            var lphancong = from x in dbs.PhanCongs
                            where x.NamHoc == NamHoc && x.HocKy == HocKy && ListMaPhanCong.Contains(x.MaPC)
                            select new { x.MaPC };
            //////////////////////////////////
            if (lphancong.Count() == 0)
                return null;
            //////////////////////////////////
            List<int> lMaPC = new List<int>();
            foreach (var pc in lphancong)
                lMaPC.Add(pc.MaPC);

            return lMaPC;
        }


        void TaoLichRanDom(bool flagAllGiangVien, bool flagAllNamHoc, bool flagAllHocKy)
        {

            List<int> ListMaPhanCong;
            if (flagAllGiangVien)
                ListMaPhanCong = getAllTablePhanCong();
            else
                ListMaPhanCong = getAllTablePhanCongTheoGiangVien(cbbTenGV.SelectedValue.ToString());

            var NamHoc = (from x in dbs.PhanCongs select new { x.NamHoc }).Distinct();
            var HocKy = (from x in dbs.PhanCongs select new { x.HocKy }).Distinct();
            foreach (var nh in NamHoc)
            {
                if (ListMaPhanCong.Count() == 0)
                    break;

                foreach (var hk in HocKy)
                {
                    if (ListMaPhanCong.Count() == 0)
                        break;

                    List<int> lMaPC = new List<int>();

                    int inamHoc = (int)nh.NamHoc;
                    int ihocKy = (int)hk.HocKy;
                    if (flagAllNamHoc == false)
                        inamHoc = Convert.ToInt32(cbbNamHoc.Text);
                    if (flagAllHocKy == false)
                        ihocKy = Convert.ToInt32(cbbHocKy.Text);

                    lMaPC = getListPhanCongTheo_NamHoc_HocKy(inamHoc, ihocKy, ListMaPhanCong);
                    if (lMaPC != null && lMaPC.Count() > 0)
                    {
                        int ngay = 1;

                        while (lMaPC.Count() != 0)  // ngay
                        {
                            int ca = 1;
                            while (lMaPC.Count() != 0 && ca < 6)  // ca
                            {
                                int rdSLPhong = RanDomSoLuongPhong(lMaPC.Count());
                                int[] checkPhong = new int[dbs.PhongHocs.Count() + 1];
                                for (int i = 1; i <= rdSLPhong; i++)
                                {
                                    int MaPhong = RanDomMaPhong(checkPhong);
                                    int MaPC = RanDomMaPhanCong(ngay, ca, ref lMaPC, ref ListMaPhanCong, inamHoc, ihocKy);
                                    if (MaPC == -1)
                                        break;
                                    Lich li = new Lich();
                                    li.Ca = ca;
                                    li.Ngay = ngay;
                                    li.Phong = MaPhong;
                                    li.MaPC = MaPC;
                                    dbs.Liches.InsertOnSubmit(li);
                                    dbs.SubmitChanges();
                                    if (lMaPC.Count() == 0)
                                        break;
                                }
                                if (ca == 6)
                                    break;
                                ca++;
                            }
                            ngay++;
                        }
                    }
                }
            }
        }
        private void btnTaoLich_Click(object sender, EventArgs e)
        {
            TaoLich();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Muốn Xóa Lịch ?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (tl == DialogResult.OK)
            {
                var lich = from x in dbs.Liches select x;
                dbs.Liches.DeleteAllOnSubmit(lich);


               

                dbs.SubmitChanges();
                MessageBox.Show("Xóa Thành Công", "thông báo");
                LoadData();
            }
        }
        private void frmTaoLich_Load(object sender, EventArgs e)
        {
            var tengv = from x in dbs.GiangViens select new { x.TenGV, x.MaGV };
            cbbTenGV.DataSource = tengv.ToList();

            cbbTenGV.DisplayMember = "TenGV";
            cbbTenGV.ValueMember = "MaGV";


            cbbHocKy.DataSource = khoiTaoListHocKy();
            cbbHocKy.DisplayMember = "HocKy";

            cbbNamHoc.DataSource = khoiTaoListNamHoc();
            cbbNamHoc.DisplayMember = "NamHoc";
            LoadData();
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn Muốn xuất file ?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (tl == DialogResult.OK)
                outPutExcel();
        }


        private void cbbTenGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbNamHoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbHocKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnTheoGV_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnPhanCongNgauNhien_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Phân Công Ngẫu Nhiên Sẽ Dẫn Đến Tạo Lại Lịch Mới, Đồng Ý ?", "Thông Báo", MessageBoxButtons.OKCancel);
            if (tl == DialogResult.OK)
            {
                var PhanCong = from x in dbs.PhanCongs select x;
                foreach (PhanCong pc in PhanCong)
                    phanCongRanDomGV(pc);

                var lich = from x in dbs.Liches select x;
                dbs.Liches.DeleteAllOnSubmit(lich);

                TaoLichRanDom(true, true, true);
            }
        }


    }
}

