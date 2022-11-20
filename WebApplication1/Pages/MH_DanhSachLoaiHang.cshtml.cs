using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;

namespace QLSP.Pages
{
    public class MH_DanhSachLoaiHangModel : PageModel
    {
        public LoaiHang[] DanhSachLoaiHang;
        [BindProperty]
        public string keyword { get; set; }

        public void OnGet()
        {
            DanhSachLoaiHang = XuLyLoaiHang.DocDanhSachLoaiHang();
        }

        public void OnPost()
        {
            DanhSachLoaiHang = XuLyLoaiHang.DocDanhSachLoaiHang(keyword);
        }
    }
}
