using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;

namespace QLSP.Pages
{
    public class MH_DanhSachHoaDonBanModel : PageModel
    {
        
        public HoaDonBan[] DanhSachHoaDonBan;
        [BindProperty]
        public string keyword { get; set; }

        public void OnGet()
        {
            DanhSachHoaDonBan = XuLyHoaDonBan.DocDanhSachHoaDonBan();
        }

        public void OnPost()
        {
            DanhSachHoaDonBan = XuLyHoaDonBan.DocDanhSachHoaDonBan(keyword);
        }
    }
}
