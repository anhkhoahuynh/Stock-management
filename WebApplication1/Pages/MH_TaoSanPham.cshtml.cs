using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;


namespace QLSP.Pages
{


    public class MH_TaoSanPhamModel : PageModel
    {
        public SanPham SanPhamX;
        public string ChuoiThongBao;
        public LoaiHang[] DanhSachLoaiHang = XuLyLoaiHang.DocDanhSachLoaiHang();

        [BindProperty]
        public string TenSanPhamX { get; set; }

        [BindProperty]
        public DateTime HanSuDungX { get; set; }

        [BindProperty]
        public DateTime NgaySanXuatX { get; set; }

        [BindProperty]
        public string NhaSanXuatX { get; set; }

        [BindProperty(SupportsGet = true)]
        public int MaLoaiHangX { get; set; }

        [BindProperty]
        public float GiaX { get; set; }


        public string TenLoaiHangX;

           public void OnGet()
        {
            ChuoiThongBao = string.Empty;
        }

        public void OnPost()
        {

            for (int i = 0; i < DanhSachLoaiHang.Length; i++)
            {
                if (MaLoaiHangX == DanhSachLoaiHang[i].MaLoaiHang)
                {
                    TenLoaiHangX = DanhSachLoaiHang[i].TenLoaiHang;
                }
            }
            bool kq = XuLySanPham.ThemSanPham(TenSanPhamX, NhaSanXuatX,NgaySanXuatX,HanSuDungX,MaLoaiHangX,TenLoaiHangX,GiaX);
            if (kq == false)
            {
                ChuoiThongBao = "Vui lòng nhập đủ thông tin!";
            }
            else
            {
                ChuoiThongBao = "Thêm thành công loại hàng mới";
                Response.Redirect("/MH_DanhSachSanPham");
            }
        }
    }
}
