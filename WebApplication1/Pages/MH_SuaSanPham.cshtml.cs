using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP.Entities;
using QLSP.Services;

namespace QLSP.Pages
{
    public class MH_SuaSanPhamModel : PageModel
    {
        public string ChuoiThongBao;
        public string TenLoaiHangCanSua;
        public SanPham SanPhamCanSua;
        public LoaiHang[] DanhSachLoaiHang = XuLyLoaiHang.DocDanhSachLoaiHang();

        [BindProperty(SupportsGet = true)]
        public int MaSanPhamCanSua { get; set; }

        [BindProperty] public string TenSanPhamCanSua { get; set; }
        [BindProperty] public DateTime HanSuDungCanSua { get; set; }
        [BindProperty] public DateTime NgaySanXuatCanSua { get; set; }
        [BindProperty] public string NhaSanXuatCanSua { get; set; }
        [BindProperty] public int MaLoaiHangCanSua { get; set; }
        [BindProperty] public float GiaCanSua { get; set; }

        public void OnGet()
        {
            if (MaSanPhamCanSua != 0)
            {
                SanPhamCanSua = XuLySanPham.DocSanPham(MaSanPhamCanSua);
            }
            else
            {
                ChuoiThongBao = "Không có id của sản phẩm";
            }
        }

        public void OnPost()
        {

            LoaiHang LoaiHangX = XuLyLoaiHang.DocLoaiHang(MaLoaiHangCanSua);
            SanPham SanPhamX;
            SanPhamX.MaSanPham = MaSanPhamCanSua;
            SanPhamX.TenSanPham = TenSanPhamCanSua;
            SanPhamX.HanSuDung = HanSuDungCanSua;
            SanPhamX.NgaySanXuat = NgaySanXuatCanSua;
            SanPhamX.NhaSanXuat = NhaSanXuatCanSua;
            SanPhamX.LoaiHang.MaLoaiHang = MaLoaiHangCanSua;
            SanPhamX.LoaiHang.TenLoaiHang = LoaiHangX.TenLoaiHang;
            SanPhamX.Gia = GiaCanSua;
            SanPhamX.SoLuongTonKho = 0;
            bool kq = XuLySanPham.SuaSanPham(SanPhamX);
            ChuoiThongBao = "Kết quả lưu trữ" + kq;
            Response.Redirect("/MH_DanhSachSanPham");
            
        }

    }
    
}
