using QLSP.Entities;
using System.IO;
using Newtonsoft.Json;

namespace QLSP.DAL
{
    public class LuuTruHoaDonBan
{
    public static HoaDonBan[] DocDanhSachHoaDonBan()
    {
        string filePath = "E:\\DanhSachHoaDonBan.json";
        StreamReader file = new StreamReader(filePath);
        string json = file.ReadLine();
        file.Close();
        HoaDonBan[] DanhSachHoaDonBanX = JsonConvert.DeserializeObject<HoaDonBan[]>(json);
        return DanhSachHoaDonBanX;
    }


    public static void LuuDanhSachHoaDonBan(HoaDonBan[] DanhSachHoaDonBanX)
    {
        string filePath = "E:\\DanhSachHoaDonBan.json";
        string json = JsonConvert.SerializeObject(DanhSachHoaDonBanX);
        StreamWriter file = new StreamWriter(filePath);
        file.Write(json);
        file.Close();
    }

    public static HoaDonBan DocHoaDonBan(int MaHoaDonBanX)
    {
        HoaDonBan[] DanhSachHoaDonBanX = DocDanhSachHoaDonBan();
        for (int i = 0; i < DanhSachHoaDonBanX.Length; i++)
        {
            if (DanhSachHoaDonBanX[i].MaHoaDonBan == MaHoaDonBanX)
            {
                return DanhSachHoaDonBanX[i];
            }
        }
        return new HoaDonBan();
    }

    public static void LuuHoaDonBan(HoaDonBan HoaDonBanX)
    {
        HoaDonBan[] DanhSachHoaDonBan = DocDanhSachHoaDonBan();
        int MaxMaHoaDonBan = DanhSachHoaDonBan.Length;
        if (DanhSachHoaDonBan.Length > 0)
        {
            for (int i = 0; i < DanhSachHoaDonBan.Length; i++)
            {
                if (DanhSachHoaDonBan[i].MaHoaDonBan > MaxMaHoaDonBan)
                {
                    MaxMaHoaDonBan = DanhSachHoaDonBan[i].MaHoaDonBan;
                }
            }
        }
        HoaDonBanX.MaHoaDonBan = MaxMaHoaDonBan + 1;
        //them sản phẩm mới vào danh sách
        HoaDonBan[] DanhSachHoaDonBanMoi = new HoaDonBan[DanhSachHoaDonBan.Length + 1];
        for (int i = 0; i < DanhSachHoaDonBan.Length; i++)
        {
            DanhSachHoaDonBanMoi[i] = DanhSachHoaDonBan[i];
        }
        DanhSachHoaDonBanMoi[DanhSachHoaDonBanMoi.Length - 1] = HoaDonBanX;
        LuuTruSanPham.CapNhatTonKho();
        LuuDanhSachHoaDonBan(DanhSachHoaDonBanMoi);

    }

    public static bool SuaHoaDonBan(HoaDonBan HoaDonBanX)
    {
        HoaDonBan[] DanhSachHoaDonBan = DocDanhSachHoaDonBan();
        for (int i = 0; i < DanhSachHoaDonBan.Length; i++)
        {
            if (HoaDonBanX.MaHoaDonBan == DanhSachHoaDonBan[i].MaHoaDonBan)
            {
                DanhSachHoaDonBan[i] = HoaDonBanX;
                LuuDanhSachHoaDonBan(DanhSachHoaDonBan);
                return true;
            }
        }
        return false;
    }


    public static bool XoaHoaDonBan(int MaHoaDonBanX)
    {
        HoaDonBan[] DanhSachHoaDonBan = DocDanhSachHoaDonBan();
        HoaDonBan[] DanhSachHoaDonBanMoi = new HoaDonBan[DanhSachHoaDonBan.Length - 1];
        int indexMoi = 0;
        bool coHoaDonBanCanXoa = false;
        for (int i = 0; i < DanhSachHoaDonBan.Length; i++)
        {
            if (MaHoaDonBanX != DanhSachHoaDonBan[i].MaHoaDonBan)
            {
                DanhSachHoaDonBanMoi[indexMoi] = DanhSachHoaDonBan[i];
                indexMoi++;
            }
            else
            {
                coHoaDonBanCanXoa = true;
            }
        }
        if (coHoaDonBanCanXoa == true)
        {

            LuuDanhSachHoaDonBan(DanhSachHoaDonBanMoi);
            return true;
        }
        else
        {
            return false;
        }
    }

}
}
