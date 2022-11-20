using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;

namespace QLSP.Pages
{
    public class MH_SuaLoaiHangModel : PageModel
    {
        public string ChuoiThongBao;

        [BindProperty(SupportsGet = true)]
        public int MaLoaiHangCanSua { get; set; }

        public LoaiHang LoaiHangCanSua;
        [BindProperty] public string TenLoaiHangCanSua { get; set; }

        public void OnGet()
        {
            if (MaLoaiHangCanSua != 0)
            {
                LoaiHangCanSua = XuLyLoaiHang.DocLoaiHang(MaLoaiHangCanSua);
            }
            else
            {
                ChuoiThongBao = "Không có ID của loại hang";
            }
        }

        public void OnPost()
        {
            LoaiHang LoaiHangX;
            LoaiHangX.MaLoaiHang = MaLoaiHangCanSua;
            LoaiHangX.TenLoaiHang = TenLoaiHangCanSua;
            bool kq = XuLyLoaiHang.SuaLoaiHang(LoaiHangX);
            if (kq==false)
            {
                ChuoiThongBao = "Sửa thất bại vì thông tin sửa bị trùng với một loại hàng đã tồn tại!";
            }
            else
            {
                ChuoiThongBao = "Sửa thành công" + kq;
                Response.Redirect("/MH_DanhSachLoaiHang");
            }    
        }

    }

}
