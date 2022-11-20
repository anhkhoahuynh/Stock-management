using QLSP.Entities;
using System.IO;
using Newtonsoft.Json;

namespace QLSP.DAL
{
    public class LuuTruHoaDonNhap
    {
        //DocDanhSachHoaDonNhap
        //LuuDanhSachHoaDonNhap
        //DocHoaDonNhap
        //LuuHoaDonNhap
        //SuaHoaDonNhap
        //XoaHoaDonNhap
        public static HoaDonNhap[] DocDanhSachHoaDonNhap()
        {
            string filePath = "E:\\DanhSachHoaDonNhap.json";
            StreamReader file = new StreamReader(filePath);
            string json = file.ReadLine();
            file.Close();
            HoaDonNhap[] DanhSachHoaDonNhapX = JsonConvert.DeserializeObject<HoaDonNhap[]>(json);
            return DanhSachHoaDonNhapX;
        }


        public static void LuuDanhSachHoaDonNhap(HoaDonNhap[] DanhSachHoaDonNhapX)
        {
            string filePath = "E:\\DanhSachHoaDonNhap.json";
            string json = JsonConvert.SerializeObject(DanhSachHoaDonNhapX);
            StreamWriter file = new StreamWriter(filePath);
            file.Write(json);
            file.Close();
        }
        
        public static HoaDonNhap DocHoaDonNhap(int MaHoaDonNhapX)
        {
            HoaDonNhap[] DanhSachHoaDonNhapX = DocDanhSachHoaDonNhap();
            for (int i = 0; i < DanhSachHoaDonNhapX.Length; i++)
            {
                if (DanhSachHoaDonNhapX[i].MaHoaDonNhap == MaHoaDonNhapX)
                {
                    return DanhSachHoaDonNhapX[i];
                }
            }
            return new HoaDonNhap();
        }

        public static void LuuHoaDonNhap(HoaDonNhap HoaDonNhapX)
        {
            HoaDonNhap[] DanhSachHoaDonNhap = DocDanhSachHoaDonNhap();
            int MaxMaHoaDonNhap = DanhSachHoaDonNhap.Length;
            if (DanhSachHoaDonNhap.Length > 0)
            {
                for (int i = 0; i < DanhSachHoaDonNhap.Length; i++)
                {
                    if (DanhSachHoaDonNhap[i].MaHoaDonNhap > MaxMaHoaDonNhap)
                    {
                        MaxMaHoaDonNhap = DanhSachHoaDonNhap[i].MaHoaDonNhap;
                    }
                }
            }
            HoaDonNhapX.MaHoaDonNhap = MaxMaHoaDonNhap + 1;
            //them sản phẩm mới vào danh sách
            HoaDonNhap[] DanhSachHoaDonNhapMoi = new HoaDonNhap[DanhSachHoaDonNhap.Length + 1];
            for (int i = 0; i < DanhSachHoaDonNhap.Length; i++)
            {
                DanhSachHoaDonNhapMoi[i] = DanhSachHoaDonNhap[i];
            }
            DanhSachHoaDonNhapMoi[DanhSachHoaDonNhapMoi.Length - 1] = HoaDonNhapX;
            LuuTruSanPham.CapNhatTonKho();
            LuuDanhSachHoaDonNhap(DanhSachHoaDonNhapMoi);
            
        }

        public static bool SuaHoaDonNhap(HoaDonNhap HoaDonNhapX)
        {
            HoaDonNhap[] DanhSachHoaDonNhap = DocDanhSachHoaDonNhap();
            for (int i = 0; i < DanhSachHoaDonNhap.Length; i++)
            {
                if (HoaDonNhapX.MaHoaDonNhap == DanhSachHoaDonNhap[i].MaHoaDonNhap)
                {
                    DanhSachHoaDonNhap[i] = HoaDonNhapX;
                    LuuDanhSachHoaDonNhap(DanhSachHoaDonNhap);
                    return true;
                }
            }
            return false;
        }


        public static bool XoaHoaDonNhap(int MaHoaDonNhapX)
        {
            HoaDonNhap[] DanhSachHoaDonNhap = DocDanhSachHoaDonNhap();
            HoaDonNhap[] DanhSachHoaDonNhapMoi = new HoaDonNhap[DanhSachHoaDonNhap.Length - 1];
            int indexMoi = 0;
            bool coHoaDonNhapCanXoa = false;
            for (int i = 0; i < DanhSachHoaDonNhap.Length; i++)
            {
                if (MaHoaDonNhapX != DanhSachHoaDonNhap[i].MaHoaDonNhap)
                {
                    DanhSachHoaDonNhapMoi[indexMoi] = DanhSachHoaDonNhap[i];
                    indexMoi++;
                }
                else
                {
                    coHoaDonNhapCanXoa = true;
                }
            }
            if (coHoaDonNhapCanXoa == true)
            {

                LuuDanhSachHoaDonNhap(DanhSachHoaDonNhapMoi);
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
