using QLSP.Entities;
using QLSP.DAL;

namespace QLSP.Services
{
    public class XuLyHoaDonBan
    {

        // DocDanhSachHoaDon
        // DocHoaDon
        // ThemHoaDon
        // SuaHoaDon
        // XoaHoaDon

        public static HoaDonBan[] DocDanhSachHoaDonBan(string keyword = "")
        {
            HoaDonBan[] DanhSachHoaDonBan = LuuTruHoaDonBan.DocDanhSachHoaDonBan();
            if (string.IsNullOrEmpty(keyword))
            {
                return DanhSachHoaDonBan;
            }
            else
            {
                int sl = 0;
                for (int i = 0; i < DanhSachHoaDonBan.Length; i++)
                {
                    if (DanhSachHoaDonBan[i].MaHoaDonBan.ToString().Contains(keyword))
                    {
                        sl++;
                    }
                }
                HoaDonBan[] DanhSachHoaDonBanTimKiem = new HoaDonBan[sl];
                int k = 0;
                foreach (HoaDonBan HoaDonBanX in DanhSachHoaDonBan)
                {
                    if (HoaDonBanX.MaHoaDonBan.ToString().Contains(keyword))
                    {
                        DanhSachHoaDonBanTimKiem[k] = HoaDonBanX;
                        k++;
                    }
                }
                return DanhSachHoaDonBanTimKiem;
            }
        }

        // DocHoaDonBan
        public static HoaDonBan DocHoaDonBan(int MaHoaDonBanX)
        {
            return LuuTruHoaDonBan.DocHoaDonBan(MaHoaDonBanX);
        }



        public static bool ThemHoaDonBan(DateTime NgayTaoHoaDonBanX, ChiTietHoaDon[] ChiTietHoaDonBanX, float TongGiaTriHoaDonX)
        {
            if (NgayTaoHoaDonBanX == null || ChiTietHoaDonBanX == null || ChiTietHoaDonBanX.Length == 0 || TongGiaTriHoaDonX == null )
            {
                return false;
            }
            else
            {
                HoaDonBan HoaDonBanX = new HoaDonBan();
                HoaDonBanX.MaHoaDonBan = 0;
                HoaDonBanX.NgayTaoHoaDonBan = NgayTaoHoaDonBanX;
                HoaDonBanX.ChiTietHoaDon = ChiTietHoaDonBanX;
                HoaDonBanX.TongGiaTriHoaDonBan = TongGiaTriHoaDonX;
                LuuTruHoaDonBan.LuuHoaDonBan(HoaDonBanX);
                XuLySanPham.CapNhatTonKho();
                return true;
            }
        }


        public static bool SuaHoaDonBan(HoaDonBan HoaDonBanX)
        {

            return LuuTruHoaDonBan.SuaHoaDonBan(HoaDonBanX);
        }
        public static bool XoaHoaDonBan(int MaHoaDonBanX)
        {
            return LuuTruHoaDonBan.XoaHoaDonBan(MaHoaDonBanX);
        }

    }
}
