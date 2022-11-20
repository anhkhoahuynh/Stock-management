using QLSP.Entities;
using QLSP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QLSP.Pages
{
    public class MH_TaoHoaDonBanlModel : PageModel
    {
       

        public SanPham[] DanhSachSanPham = XuLySanPham.DocDanhSachSanPham();

        [BindProperty]
        public DateTime NgayTaoHoaDonX { get; set; }

        [BindProperty]
        public ChiTietHoaDon[] ChiTietHoaDonBanX { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public void OnPost(List<ChiTietHoaDon> model)
        {

            SanPham[] DanhSachSanPham = XuLySanPham.DocDanhSachSanPham();
            int count = 0;
            for(int i=0;i<ChiTietHoaDonBanX.Length; i++)
            {
                if (ChiTietHoaDonBanX[i].SoLuong != -1)
                {
                    count++;
                }
            }
            ChiTietHoaDon[] ChiTietHoaDonBanSauKhiXuLy = new ChiTietHoaDon[count];
            int k = 0;
            for(int i=0; i<ChiTietHoaDonBanX.Length; i++)
            {
                if(ChiTietHoaDonBanX[i].SoLuong != -1)
                {
                    ChiTietHoaDonBanSauKhiXuLy[k] = ChiTietHoaDonBanX[i];
                    k++;
                }
                else { continue; }
            }
            float sum = 0;
            for (int i=0; i< ChiTietHoaDonBanSauKhiXuLy.Length; i++)
            {
                for(int j=0; j<DanhSachSanPham.Length; j++)
                {
                   
                    if (ChiTietHoaDonBanSauKhiXuLy[i].MaSanPham == DanhSachSanPham[j].MaSanPham)
                    {
                        ChiTietHoaDonBanSauKhiXuLy[i].ThanhTien = ChiTietHoaDonBanSauKhiXuLy[i].SoLuong * DanhSachSanPham[j].Gia;
                        ChiTietHoaDonBanSauKhiXuLy[i].Gia = DanhSachSanPham[j].Gia;
                        ChiTietHoaDonBanSauKhiXuLy[i].TenSanPham = DanhSachSanPham[j].TenSanPham;
                        break;
                    }
                }
                sum += ChiTietHoaDonBanSauKhiXuLy[i].ThanhTien;
            }
            bool kq = XuLyHoaDonBan.ThemHoaDonBan(NgayTaoHoaDonX, ChiTietHoaDonBanSauKhiXuLy, sum);
            Response.Redirect("/MH_DanhSachHoaDonBan");

        }
    }
}
