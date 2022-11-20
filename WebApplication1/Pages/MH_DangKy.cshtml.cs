using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;

namespace QLSP.Pages
{
    public class MH_DangKyModel : PageModel
    {

        public string chuoithongbao;
        [BindProperty]
        public string fullname { get; set; }

        [BindProperty]
        public string username { get; set; }

        [BindProperty]
        public string password { get; set; }

        public void OnGet()
        {
            chuoithongbao = string.Empty;

        }
        public void OnPost()
        {
            bool kq = XuLyNguoiDung.ThemNguoiDung(fullname, username, password);
            chuoithongbao = "Dang ky Thanh cong";
            Response.Redirect("/MH_DanhSachSanPham");
        }
    }
}
