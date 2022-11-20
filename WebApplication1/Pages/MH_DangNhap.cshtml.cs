using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;
using Microsoft.AspNetCore.Http;

namespace QLSP.Pages
{
    public class MH_DangNhapModel : PageModel
    {

        public string ChuoiThongBao;
        public NguoiDung s;

        [BindProperty]
        public string TenTaiKhoanX   { get; set; }

        [BindProperty]
        public string MatKhauX { get; set; }


        public void OnGet()
        {
            ChuoiThongBao = "vui long dang nhap";
        }

        public void OnPost()
        {
            NguoiDung NguoiDungX = XuLyNguoiDung.DangNhap(TenTaiKhoanX, MatKhauX);
            if(!string.IsNullOrEmpty(NguoiDungX.TenTaiKhoan))
            {
                HttpContext.Session.SetString("user", NguoiDungX.TenTaiKhoan);
                Response.Redirect("/MH_DanhSachSanPham");
            }
            else
            {
                ChuoiThongBao = "Vui long dang nhap lai";
            }    
            
            
        }

    }
}
