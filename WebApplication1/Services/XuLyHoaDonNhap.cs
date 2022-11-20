using QLSP.Entities;
using QLSP.DAL;

namespace QLSP.Services
{
    public class XuLyHoaDonNhap
    {

        // DocDanhSachHoaDon
        // DocHoaDon
        // ThemHoaDon
        // SuaHoaDon
        // XoaHoaDon

        public static HoaDonNhap[] DocDanhSachHoaDonNhap(string keyword = "")
        {
            HoaDonNhap[] DanhSachHoaDonNhap = LuuTruHoaDonNhap.DocDanhSachHoaDonNhap();
            if (string.IsNullOrEmpty(keyword))
            {
                return DanhSachHoaDonNhap;
            }
            else
            {
                int sl = 0;
                for (int i = 0; i < DanhSachHoaDonNhap.Length; i++)
                {
                    if (DanhSachHoaDonNhap[i].MaHoaDonNhap.ToString().Contains(keyword))
                    {
                        sl++;
                    }
                }
                HoaDonNhap[] DanhSachHoaDonNhapTimKiem = new HoaDonNhap[sl];
                int k = 0;
                foreach (HoaDonNhap HoaDonNhapX in DanhSachHoaDonNhap)
                {
                    if (HoaDonNhapX.MaHoaDonNhap.ToString().Contains(keyword))
                    {
                        DanhSachHoaDonNhapTimKiem[k] = HoaDonNhapX;
                        k++;
                    }
                }
                return DanhSachHoaDonNhapTimKiem;
            }
        }

        // DocHoaDonNhap
        public static HoaDonNhap DocHoaDonNhap(int MaHoaDonNhapX)
        {
            return LuuTruHoaDonNhap.DocHoaDonNhap(MaHoaDonNhapX);
        }



        public static bool ThemHoaDonNhap(DateTime NgayTaoHoaDonNhapX, ChiTietHoaDon[] ChiTietHoaDonNhapX, float TongGiaTriHoaDonX)
        {
            if (NgayTaoHoaDonNhapX == null || ChiTietHoaDonNhapX == null || ChiTietHoaDonNhapX.Length == 0 || TongGiaTriHoaDonX == null)
            {
                return false;
            }
            else
            {
                HoaDonNhap HoaDonNhapX = new HoaDonNhap();
                HoaDonNhapX.MaHoaDonNhap = 0;
                HoaDonNhapX.NgayTaoHoaDonNhap = NgayTaoHoaDonNhapX;
                HoaDonNhapX.ChiTietHoaDon = ChiTietHoaDonNhapX;
                HoaDonNhapX.TongGiaTriHoaDonNhap = TongGiaTriHoaDonX;
                LuuTruHoaDonNhap.LuuHoaDonNhap(HoaDonNhapX);
                XuLySanPham.CapNhatTonKho();
                return true;
            }
        }


        public static bool SuaHoaDonNhap(HoaDonNhap HoaDonNhapX)
        {

            return LuuTruHoaDonNhap.SuaHoaDonNhap(HoaDonNhapX);
        }
        public static bool XoaHoaDonNhap(int MaHoaDonNhapX)
        {
            return LuuTruHoaDonNhap.XoaHoaDonNhap(MaHoaDonNhapX);
        }

    }
}
