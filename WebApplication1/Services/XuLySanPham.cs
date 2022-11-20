using QLSP.Entities;
using QLSP.DAL;

namespace QLSP.Services
{
    public class XuLySanPham
    {
        public static bool ThemSanPham(string TenSanPhamX, string NhaSanXuatX, 
                                    DateTime NgaySanXuatX, DateTime HanSuDungX,
                                    int MaLoaiHangX, string TenLoaiHangX, float GiaX)
        {
            if (string.IsNullOrEmpty(TenSanPhamX) || string.IsNullOrEmpty(NhaSanXuatX) 
                || NgaySanXuatX == null ||
                HanSuDungX == null || string.IsNullOrEmpty(TenLoaiHangX) 
                || string.IsNullOrEmpty(TenLoaiHangX)
                )
            {
                return false;
            }
            else
            {
                SanPham SanPhamX;
                SanPhamX.MaSanPham = 0;
                SanPhamX.TenSanPham = TenSanPhamX;
                SanPhamX.NhaSanXuat = NhaSanXuatX;
                SanPhamX.NgaySanXuat = NgaySanXuatX;
                SanPhamX.HanSuDung = HanSuDungX;
                SanPhamX.LoaiHang.MaLoaiHang = MaLoaiHangX;
                SanPhamX.LoaiHang.TenLoaiHang = TenLoaiHangX;
                SanPhamX.Gia = GiaX;
                SanPhamX.SoLuongTonKho = 0;
                LuuTruSanPham.LuuSanPham(SanPhamX);
                CapNhatTonKho();
                return true;
            }
        }
            
        public static SanPham[] DocDanhSachSanPham(string keyword="")
        {
            CapNhatTonKho();
            SanPham[] DanhSachSanPham = LuuTruSanPham.DocDanhSachSanPham();
            if (string.IsNullOrEmpty(keyword))
            {
                return DanhSachSanPham;
            }
            else
            {
                int sl = 0;
                for (int i = 0; i < DanhSachSanPham.Length; i++)
                {
                    if (DanhSachSanPham[i].TenSanPham.Contains(keyword))
                    {
                        sl++;
                    }
                }
                SanPham[] DanhSachSanPhamTimKiem = new SanPham[sl];
                int k = 0;
                foreach (SanPham SanPhamX in DanhSachSanPham)
                {
                    if(SanPhamX.TenSanPham.Contains(keyword))
                    {
                        DanhSachSanPhamTimKiem[k] = SanPhamX;
                        k++;
                    }
                }
                return DanhSachSanPhamTimKiem;
            }
        }

        public static SanPham DocSanPham(int MaSanPhamX)
        {
            
            return LuuTruSanPham.DocSanPham(MaSanPhamX);
        }

        public static bool SuaSanPham(SanPham SanPhamX)
        {
            
            return LuuTruSanPham.SuaSanPham(SanPhamX);
        }
        public static bool XoaSanPham(int MaSanPhamX)
        {
            return LuuTruSanPham.XoaSanPham(MaSanPhamX);
        }
           public static void CapNhatTonKho()
        {
            LuuTruSanPham.CapNhatTonKho();
        }
    }
}
