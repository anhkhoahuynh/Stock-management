using QLSP.Entities;
using QLSP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QLSP.Pages
{
    public class MH_SuaHoaDonNhapModel : PageModel
    {
        public string ChuoiThongBao;
        public HoaDonNhap HoaDonNhapCanSua;
        public SanPham[] DanhSachSanPham = XuLySanPham.DocDanhSachSanPham();

        [BindProperty(SupportsGet = true)]
        public int MaHoaDonNhapCanSua { get; set; }

        [BindProperty] public DateTime NgayTaoHoaDonNhapCanSua { get; set; }
        
        [BindProperty] public ChiTietHoaDon[] ChiTietHoaDonCanSua { get; set; }


        public void OnGet()
        {
            if (MaHoaDonNhapCanSua != 0)
            {
                HoaDonNhapCanSua = XuLyHoaDonNhap.DocHoaDonNhap(MaHoaDonNhapCanSua);
            }
            else
            {
                ChuoiThongBao = "Khong co id cua san pham";
            }
        }

        public void OnPost()
        {

            HoaDonNhap HoaDonNhapX;
            HoaDonNhapX.MaHoaDonNhap = MaHoaDonNhapCanSua;
            HoaDonNhapX.NgayTaoHoaDonNhap = NgayTaoHoaDonNhapCanSua;
            float sum = 0;
            for (int i = 0; i < ChiTietHoaDonCanSua.Length; i++)
            {
                for (int j = 0; j < DanhSachSanPham.Length; j++)
                {

                    if (ChiTietHoaDonCanSua[i].MaSanPham == DanhSachSanPham[j].MaSanPham)
                    {
                        ChiTietHoaDonCanSua[i].ThanhTien = ChiTietHoaDonCanSua[i].SoLuong * DanhSachSanPham[j].Gia;
                        ChiTietHoaDonCanSua[i].Gia = DanhSachSanPham[j].Gia;
                        ChiTietHoaDonCanSua[i].TenSanPham = DanhSachSanPham[j].TenSanPham;
                        break;
                    }
                }
                sum += ChiTietHoaDonCanSua[i].ThanhTien;
            }
            HoaDonNhapX.TongGiaTriHoaDonNhap = sum;
            HoaDonNhapX.ChiTietHoaDon = ChiTietHoaDonCanSua;
            bool kq = XuLyHoaDonNhap.SuaHoaDonNhap(HoaDonNhapX);
            ChuoiThongBao = "ket qua luu tru" + kq;
            Response.Redirect("/MH_DanhSachHoaDonNhap");
        }
    }
}
