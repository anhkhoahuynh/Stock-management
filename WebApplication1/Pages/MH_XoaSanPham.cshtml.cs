using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;

namespace QLSP.Pages
{
    public class MH_XoaSanPhamModel : PageModel
    {
        public SanPham SanPhamCanXoa;

        string ChuoiThongBao;

        [BindProperty(SupportsGet = true)]
        public int MaSanPhamCanXoa { get; set; }


        [BindProperty]
        public string TenSanPhamCanXoa { get; set; }

        [BindProperty]
        public int GiaSanPhamCanXoa { get; set; }

        public void OnGet()
        {
            if (MaSanPhamCanXoa != 0)
            {
                SanPhamCanXoa = XuLySanPham.DocSanPham(MaSanPhamCanXoa);
            }
            else
            {
                ChuoiThongBao = "Khong co id cua san pham";
            }
        }


        public void OnPost()
        {
            bool kq = XuLySanPham.XoaSanPham(MaSanPhamCanXoa);
            ChuoiThongBao = "ket qua luu tru" + kq;
            Response.Redirect("/MH_DanhSachSanPham");
        }
    }
}
