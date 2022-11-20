using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;

namespace QLSP.Pages
{
    public class MH_DanhSachSanPhamModel : PageModel
    {
        public SanPham[] DanhSachSanPham;
        [BindProperty]
        public string keyword { get; set; }

        public void OnGet()
        {
            DanhSachSanPham = XuLySanPham.DocDanhSachSanPham();
        }

        public void OnPost()
        {
           
            DanhSachSanPham = XuLySanPham.DocDanhSachSanPham(keyword);
        }
    }
}
