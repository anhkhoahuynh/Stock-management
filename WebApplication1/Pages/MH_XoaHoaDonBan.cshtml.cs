using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;

namespace QLSP.Pages
{
    public class MH_XoaHoaDonBanModel : PageModel
    {
        public HoaDonBan HoaDonBanCanXoa;

        string ChuoiThongBao;

        [BindProperty(SupportsGet = true)]
        public int MaHoaDonBanCanXoa { get; set; }


        public void OnGet()
        {
            if (MaHoaDonBanCanXoa != 0)
            {
                HoaDonBanCanXoa = XuLyHoaDonBan.DocHoaDonBan(MaHoaDonBanCanXoa);
            }
            else
            {
                ChuoiThongBao = "Không có mã hóa đơn nhập!";
            }
        }


        public void OnPost()
        {
            bool kq = XuLyHoaDonBan.XoaHoaDonBan(MaHoaDonBanCanXoa);
            ChuoiThongBao = "Kết quả lưu trữ" + kq;
            Response.Redirect("/MH_DanhSachHoaDonBan");
        }
    }
}
