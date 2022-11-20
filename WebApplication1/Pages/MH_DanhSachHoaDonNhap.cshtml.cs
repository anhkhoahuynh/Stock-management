using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;

namespace QLSP.Pages
{
    public class MH_DanhSachHoaDonNhapModel : PageModel
    {
        
        public HoaDonNhap[] DanhSachHoaDonNhap;
        [BindProperty]
        public string keyword { get; set; }

        public void OnGet()
        {
            DanhSachHoaDonNhap = XuLyHoaDonNhap.DocDanhSachHoaDonNhap();
        }

        public void OnPost()
        {
            DanhSachHoaDonNhap = XuLyHoaDonNhap.DocDanhSachHoaDonNhap(keyword);
        }
    }
}
