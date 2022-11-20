using QLSP.Entities;
using System.IO;
using Newtonsoft.Json;

namespace QLSP.DAL
{
    public class LuuTruLoaiHang
    {
        public static LoaiHang[] DocDanhSachLoaiHang()
        {
            string filePath = "E:\\danhsachloaihang.json";
            StreamReader file = new StreamReader(filePath);
            string json = file.ReadLine();
            file.Close();
            LoaiHang[] DanhSachLoaiHang = JsonConvert.DeserializeObject<LoaiHang[]>(json);
            return DanhSachLoaiHang;
        }
     
        public static void LuuDanhSachLoaiHang(LoaiHang[] DanhSachLoaiHangX)
        {
            string filePath = "E:\\danhsachloaihang.json";
            string json = JsonConvert.SerializeObject(DanhSachLoaiHangX);
            StreamWriter file = new StreamWriter(filePath);
            file.Write(json);
            file.Close();
        }


        public static LoaiHang DocLoaiHang(int MaLoaiHangX)
        {
            LoaiHang[] DanhSachLoaiHang = DocDanhSachLoaiHang();
            for (int i = 0; i < DanhSachLoaiHang.Length; i++)
            {
                if (DanhSachLoaiHang[i].MaLoaiHang == MaLoaiHangX)
                {
                    return DanhSachLoaiHang[i];
                }
            }
            return new LoaiHang();
        }


        public static void LuuLoaiHang(LoaiHang LoaiHangX)
        {
            LoaiHang[] DanhSachLoaiHang = DocDanhSachLoaiHang();
            int MaxMaLoaiHang = DanhSachLoaiHang.Length;
            if (DanhSachLoaiHang.Length > 0)
            {
                for (int i = 0; i < DanhSachLoaiHang.Length; i++)
                {
                    if (DanhSachLoaiHang[i].MaLoaiHang > MaxMaLoaiHang)
                    {
                        MaxMaLoaiHang = DanhSachLoaiHang[i].MaLoaiHang;
                    }
                }
            }
            LoaiHangX.MaLoaiHang = MaxMaLoaiHang + 1;
            //them sản phẩm mới vào danh sách
            LoaiHang[] DanhSachLoaiHangMoi = new LoaiHang[DanhSachLoaiHang.Length + 1];
            for (int i = 0; i < DanhSachLoaiHang.Length; i++)
            {
                DanhSachLoaiHangMoi[i] = DanhSachLoaiHang[i];
            }
            DanhSachLoaiHangMoi[DanhSachLoaiHangMoi.Length - 1] = LoaiHangX;
            LuuDanhSachLoaiHang(DanhSachLoaiHangMoi);
        }

        public static bool SuaLoaiHang(LoaiHang LoaiHangX)
        {
            LoaiHang[] DanhSachLoaiHang = DocDanhSachLoaiHang();

            for (int i = 0; i < DanhSachLoaiHang.Length; i++)
            {
                if (LoaiHangX.MaLoaiHang == DanhSachLoaiHang[i].MaLoaiHang)
                {
                    DanhSachLoaiHang[i] = LoaiHangX;
                    LuuDanhSachLoaiHang(DanhSachLoaiHang);
                    return true;
                }
            }
            return false;
        }

       
        public static bool XoaLoaiHang(int MaLoaiHangX)
        {
            LoaiHang[] DanhSachLoaiHang = DocDanhSachLoaiHang();
            LoaiHang[] DanhSachLoaiHangMoi = new LoaiHang[DanhSachLoaiHang.Length - 1];
            int indexMoi = 0;
            bool coLoaiHangCanXoa = false;
            for (int i = 0; i < DanhSachLoaiHang.Length; i++)
            {
                if (MaLoaiHangX != DanhSachLoaiHang[i].MaLoaiHang)
                {
                    DanhSachLoaiHangMoi[indexMoi] = DanhSachLoaiHang[i];
                    indexMoi++;
                }
                else
                {
                    coLoaiHangCanXoa = true;
                }
            }
            if (coLoaiHangCanXoa == true)
            {

                LuuDanhSachLoaiHang(DanhSachLoaiHangMoi);
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
