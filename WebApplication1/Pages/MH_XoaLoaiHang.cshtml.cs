using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;

namespace QLSP.Pages
{
    public class MH_XoaLoaiHangModel : PageModel
    {
        public LoaiHang LoaiHangCanXoa;

        string ChuoiThongBao;

        [BindProperty(SupportsGet = true)]
        public int MaLoaiHangCanXoa { get; set; }


        [BindProperty]
        public string TenLoaiHangCanXoa { get; set; }

        public void OnGet()
        {
            if (MaLoaiHangCanXoa != 0)
            {
                LoaiHangCanXoa = XuLyLoaiHang.DocLoaiHang(MaLoaiHangCanXoa);
            }
            else
            {
                ChuoiThongBao = "Khong co id cua san pham";
            }
        }

        public void OnPost()
        {
            bool kq = XuLyLoaiHang.XoaLoaiHang(MaLoaiHangCanXoa);
            ChuoiThongBao = "ket qua luu tru" + kq;
            Response.Redirect("/MH_DanhSachLoaiHang");
        }
    }
}
