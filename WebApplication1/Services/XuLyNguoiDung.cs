using QLSP.Entities;
using QLSP.DAL;

namespace QLSP.Services
{
    public class XuLyNguoiDung
    {
        public static bool ThemNguoiDung(string TenDayDuX, string TenTaiKhoanX, string MatKhauX)
        {
            if(string.IsNullOrEmpty(TenDayDuX) || string.IsNullOrEmpty(TenTaiKhoanX) || string.IsNullOrEmpty(MatKhauX))
            {
                return false;   
            }
            NguoiDung NguoiDungX = new NguoiDung();
            NguoiDungX.TenDayDu = TenDayDuX;
            NguoiDungX.TenTaiKhoan = TenTaiKhoanX.Trim();
            NguoiDungX.MatKhau = MatKhauX.Trim();
            LuuTruNguoiDung.LuuNguoiDungMoi(NguoiDungX);
            return true;
        }

        public static NguoiDung DocNguoiDung(string TenDayDuX)
        {
            return LuuTruNguoiDung.DocNguoiDung(TenDayDuX);
        }

        public static bool SuaNguoiDung(NguoiDung NguoiDungX)
        {
            return LuuTruNguoiDung.SuaNguoiDung(NguoiDungX);
        }
        public static bool XoaNguoiDung(string TenTaiKhoanX)
        {
            return LuuTruNguoiDung.XoaNguoiDung(TenTaiKhoanX);
        }

        public static NguoiDung DangNhap(string TenTaiKhoanX, string MatKhauX)
        {
            NguoiDung NguoiDungX = LuuTruNguoiDung.DocNguoiDung(TenTaiKhoanX);
            if (NguoiDungX.MatKhau == MatKhauX)
            {
                return NguoiDungX;
            }    
            else
            {
                return new NguoiDung();
            }    
        }
    }



}
