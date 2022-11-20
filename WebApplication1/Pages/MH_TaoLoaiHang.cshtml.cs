using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;

namespace QLSP.Pages
{
    public class MH_TaoLoaiHangModel : PageModel
    {
        public LoaiHang LoaiHangX;
        public string ChuoiThongBao;

        [BindProperty]
        public string TenLoaiHangX { get; set; }

        public void OnGet()
        {
            ChuoiThongBao = string.Empty;
        }

        public void OnPost()
        {
            bool kq = XuLyLoaiHang.ThemLoaiHang(TenLoaiHangX);
            if(kq == false)
            {
                ChuoiThongBao = "Tên loại hàng bị trùng với một loại hàng có sẵn";
            }
            else
            {
                ChuoiThongBao = "Thêm thành công loại hàng mới";
                Response.Redirect("/MH_DanhSachLoaiHang");
            }    
        }
    }
}
