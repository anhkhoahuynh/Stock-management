using QLSP.Entities;
using QLSP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QLSP.Pages
{
    public class MH_TaoHoaDonNhaplModel : PageModel
    {
       

        public SanPham[] DanhSachSanPham = XuLySanPham.DocDanhSachSanPham();

        [BindProperty]
        public DateTime NgayTaoHoaDonX { get; set; }

        [BindProperty]
        public ChiTietHoaDon[] ChiTietHoaDonNhapX { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public void OnPost(List<ChiTietHoaDon> model)
        {

            SanPham[] DanhSachSanPham = XuLySanPham.DocDanhSachSanPham();
            int count = 0;
            for(int i=0;i<ChiTietHoaDonNhapX.Length; i++)
            {
                if (ChiTietHoaDonNhapX[i].SoLuong != -1)
                {
                    count++;
                }
            }
            ChiTietHoaDon[] ChiTietHoaDonNhapSauKhiXuLy = new ChiTietHoaDon[count];
            int k = 0;
            for(int i=0; i<ChiTietHoaDonNhapX.Length; i++)
            {
                if(ChiTietHoaDonNhapX[i].SoLuong != -1)
                {
                    ChiTietHoaDonNhapSauKhiXuLy[k] = ChiTietHoaDonNhapX[i];
                    k++;
                }
                else { continue; }
            }
            float sum = 0;
            for (int i=0; i< ChiTietHoaDonNhapSauKhiXuLy.Length; i++)
            {
                for(int j=0; j<DanhSachSanPham.Length; j++)
                {
                   
                    if (ChiTietHoaDonNhapSauKhiXuLy[i].MaSanPham == DanhSachSanPham[j].MaSanPham)
                    {
                        ChiTietHoaDonNhapSauKhiXuLy[i].ThanhTien = ChiTietHoaDonNhapSauKhiXuLy[i].SoLuong * DanhSachSanPham[j].Gia;
                        ChiTietHoaDonNhapSauKhiXuLy[i].Gia = DanhSachSanPham[j].Gia;
                        ChiTietHoaDonNhapSauKhiXuLy[i].TenSanPham = DanhSachSanPham[j].TenSanPham;
                        break;
                    }
                }
                sum += ChiTietHoaDonNhapSauKhiXuLy[i].ThanhTien;
            }
            bool kq = XuLyHoaDonNhap.ThemHoaDonNhap(NgayTaoHoaDonX, ChiTietHoaDonNhapSauKhiXuLy, sum);
            Response.Redirect("/MH_DanhSachHoaDonNhap");
        }
    }
}
