using QLSP.Entities;
using QLSP.DAL;


namespace QLSP.Services
{
    public class XuLyLoaiHang
    {

        // DocDanhSachLoaiHang
        // DocLoaiHang

        //ThemLoaiHang
        // SuaLoaiHang
        // XoaLoaiHang

        public static LoaiHang[] DocDanhSachLoaiHang(string keyword = "")
        {
            LoaiHang[] DanhSachLoaiHang = LuuTruLoaiHang.DocDanhSachLoaiHang();
            if (string.IsNullOrEmpty(keyword))
            {
                return DanhSachLoaiHang;
            }
            else
            {
                int sl = 0;
                for (int i = 0; i < DanhSachLoaiHang.Length; i++)
                {
                    if (DanhSachLoaiHang[i].TenLoaiHang.Contains(keyword))
                    {
                        sl++;
                    }
                }
                LoaiHang[] DanhSachTimKiemLoaiHang = new LoaiHang[sl];
                int k = 0;
                foreach (LoaiHang LoaiHangX in DanhSachLoaiHang)
                {
                    if (LoaiHangX.TenLoaiHang.Contains(keyword))
                    {
                        DanhSachTimKiemLoaiHang[k] = LoaiHangX;
                        k++;
                    }
                }
                return DanhSachTimKiemLoaiHang;
            }
        }

            // DocLoaiHang
        public static LoaiHang DocLoaiHang(int MaLoaiHangX)
        {
                return LuuTruLoaiHang.DocLoaiHang(MaLoaiHangX);
        }


        //ThemLoaiHang
        public static bool ThemLoaiHang(string TenLoaiHangX)
        {
            if (string.IsNullOrEmpty(TenLoaiHangX))
            {
                return false;
            }
            else
            {
                LoaiHang[] DanhSachLoaiHang = DocDanhSachLoaiHang();
                bool daTonTaiLoaiHang = false;
                for (int i = 0; i < DanhSachLoaiHang.Length; i++)
                {
                    if (DanhSachLoaiHang[i].TenLoaiHang == TenLoaiHangX)
                    {
                        daTonTaiLoaiHang = true;
                        break;
                    }
                }
                if (daTonTaiLoaiHang == true)
                {
                    return false;
                }    
                else
                {
                    LoaiHang LoaiHangX;
                    LoaiHangX.MaLoaiHang = 0;
                    LoaiHangX.TenLoaiHang = TenLoaiHangX;
                    LuuTruLoaiHang.LuuLoaiHang(LoaiHangX);
                    return true;
                }
            }
        }

        public static bool SuaLoaiHang(LoaiHang LoaiHangX)
        {
                LoaiHang[] DanhSachLoaiHang = DocDanhSachLoaiHang();
                bool daTonTaiLoaiHang = false;
                for (int i = 0; i < DanhSachLoaiHang.Length; i++)
                {
                    if (DanhSachLoaiHang[i].MaLoaiHang == LoaiHangX.MaLoaiHang && DanhSachLoaiHang[i].TenLoaiHang == LoaiHangX.TenLoaiHang)
                    {
                        daTonTaiLoaiHang = true;
                        break;
                    }
                }
                if (daTonTaiLoaiHang == true)
                {
                    return false;
                }
                else
                {
                    LuuTruLoaiHang.SuaLoaiHang(LoaiHangX);
                    return true;
                }
        }


        public static bool XoaLoaiHang(int MaLoaiHangX)
        {
            return LuuTruLoaiHang.XoaLoaiHang(MaLoaiHangX);
        }

    }
}

