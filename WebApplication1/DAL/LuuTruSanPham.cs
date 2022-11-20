using QLSP.Entities;
using System.IO;
using Newtonsoft.Json;

namespace QLSP.DAL
{
    public class LuuTruSanPham
    {
        public static void LuuSanPham(SanPham SanPhamX)
        {
            SanPham[] dssp = DocDanhSachSanPham();
            int MaxMaSanPham = dssp.Length;
            if(dssp.Length > 0)
            {
                for (int i = 0; i < dssp.Length; i++)
                {
                    if (dssp[i].MaSanPham > MaxMaSanPham)
                    {
                        MaxMaSanPham = dssp[i].MaSanPham;
                    }
                }    
            }
            SanPhamX.MaSanPham = MaxMaSanPham + 1;
            //them sản phẩm mới vào danh sách
            SanPham[] dssp_moi = new SanPham[dssp.Length+1];
            for (int i = 0; i < dssp.Length; i++)
            {
                dssp_moi[i] = dssp[i];
            }
            dssp_moi[dssp_moi.Length - 1] = SanPhamX;
            LuuDanhSachSanPham(dssp_moi);
        }

        public static SanPham[] DocDanhSachSanPham()
        {
            string filePath = "E:\\danhsachsanpham.json";
            StreamReader file = new StreamReader(filePath);
            string json = file.ReadLine();
            file.Close();
            SanPham[] DanhSachSanPham = JsonConvert.DeserializeObject<SanPham[]>(json);
            return DanhSachSanPham;
        }


        public static void LuuDanhSachSanPham(SanPham[] dssp)
        {
            string filePath = "E:\\danhsachsanpham.json";
            string json = JsonConvert.SerializeObject(dssp);
            StreamWriter file = new StreamWriter(filePath);
            file.Write(json);
            file.Close();
        }

        public static SanPham DocSanPham(int MaSanPhamX)
        {
            SanPham[] dssp = DocDanhSachSanPham();
            for(int i=0; i < dssp.Length; i++)
            {
                if (dssp[i].MaSanPham == MaSanPhamX)
                {
                    return dssp[i];
                }
            }
            return new SanPham();
        }


        public static bool SuaSanPham(SanPham SanPhamX)
        {
            SanPham[] dssp = DocDanhSachSanPham();
            
            for(int i=0; i<dssp.Length;i++)
            {
                if (SanPhamX.MaSanPham == dssp[i].MaSanPham)
                {
                    dssp[i] = SanPhamX;
                    LuuDanhSachSanPham(dssp);
                    return true;
                }
            }
            return false;
        }

        public static bool XoaSanPham(int MaSanPhamX)
        {
            SanPham[] dssp = DocDanhSachSanPham();
            SanPham[] dssp_moi = new SanPham[dssp.Length - 1];
            int indexMoi = 0;
            bool coSanPhamCanXoa = false;
            for (int i = 0; i < dssp.Length; i++)
            {
                if (MaSanPhamX != dssp[i].MaSanPham)
                {
                    dssp_moi[indexMoi] = dssp[i];
                    indexMoi++;
                }
                else
                {
                    coSanPhamCanXoa = true;
                }
            }
            if(coSanPhamCanXoa == true)
            {
                LuuDanhSachSanPham(dssp_moi);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void CapNhatTonKho()
        {
            HoaDonNhap[] DanhSachHoaDonNhap = LuuTruHoaDonNhap.DocDanhSachHoaDonNhap();
            HoaDonBan[] DanhSachHoaDonBan = LuuTruHoaDonBan.DocDanhSachHoaDonBan();
            SanPham[] DanhSachSanPham = LuuTruSanPham.DocDanhSachSanPham();
            for(int i=0; i<DanhSachSanPham.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < DanhSachHoaDonNhap.Length; j++)
                {
                    for (int k = 0; k < DanhSachHoaDonNhap[j].ChiTietHoaDon.Length; k++)
                    {
                        if (DanhSachSanPham[i].MaSanPham == DanhSachHoaDonNhap[j].ChiTietHoaDon[k].MaSanPham)
                        {
                            sum += DanhSachHoaDonNhap[j].ChiTietHoaDon[k].SoLuong;
                        }
                    }
                }
                for (int l = 0; l< DanhSachHoaDonNhap.Length; l++)
                {
                    for (int m = 0; m < DanhSachHoaDonNhap[l].ChiTietHoaDon.Length; m++)
                    {
                        if (DanhSachSanPham[i].MaSanPham == DanhSachHoaDonNhap[l].ChiTietHoaDon[m].MaSanPham)
                        {
                            sum -= DanhSachHoaDonNhap[l].ChiTietHoaDon[m].SoLuong;
                        }
                    }
                }

                DanhSachSanPham[i].SoLuongTonKho = sum;
            }
            LuuDanhSachSanPham(DanhSachSanPham);
        }
    }
}
