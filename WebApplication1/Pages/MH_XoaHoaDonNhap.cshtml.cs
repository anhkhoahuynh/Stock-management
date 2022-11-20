using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;

namespace QLSP.Pages
{
    public class MH_XoaHoaDonNhapModel : PageModel
    {
        public HoaDonNhap HoaDonNhapCanXoa;

        string ChuoiThongBao;

        [BindProperty(SupportsGet = true)]
        public int MaHoaDonNhapCanXoa { get; set; }


        public void OnGet()
        {
            if (MaHoaDonNhapCanXoa != 0)
            {
                HoaDonNhapCanXoa = XuLyHoaDonNhap.DocHoaDonNhap(MaHoaDonNhapCanXoa);
            }
            else
            {
                ChuoiThongBao = "Không có mã hóa đơn nhập!";
            }
        }


        public void OnPost()
        {
            bool kq = XuLyHoaDonNhap.XoaHoaDonNhap(MaHoaDonNhapCanXoa);
            ChuoiThongBao = "Kết quả lưu trữ" + kq;
            Response.Redirect("/MH_DanhSachHoaDonNhap");
        }
    }
}
