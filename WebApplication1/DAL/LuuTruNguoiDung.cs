using QLSP.Entities;
using System.IO;
using Newtonsoft.Json;

namespace QLSP.DAL
{
    public class LuuTruNguoiDung
    {
        public static NguoiDung DocNguoiDung(string TenTaiKhoan)
        {
            NguoiDung[] DanhSachNguoiDung = DocDanhSach();
            for(int i=0;i<DanhSachNguoiDung.Length; i++)
            {
                if(TenTaiKhoan == DanhSachNguoiDung[i].TenTaiKhoan)
                {
                    return DanhSachNguoiDung[i];
                }    
            }
            return new NguoiDung();
        }

        public static bool SuaNguoiDung(NguoiDung s)
        {
            NguoiDung[] DanhSachNguoiDung = DocDanhSach();
            for (int i = 0; i < DanhSachNguoiDung.Length; i++)
            {
                if (s.TenTaiKhoan == DanhSachNguoiDung[i].TenTaiKhoan)
                {
                    DanhSachNguoiDung[i] = s;
                    LuuDanhSach(DanhSachNguoiDung);
                    return true;
                }
            }
            return false;
        }

        public static bool XoaNguoiDung(string TenTaiKhoan)
        {
            NguoiDung[] DanhSachNguoiDung = DocDanhSach();
            NguoiDung[] DanhSachNguoiDungMoi = new NguoiDung[DanhSachNguoiDung.Length - 1];
            int newIndex = 0;
            bool CoNguoiDungCanXoa = false;
            for (int i = 0; i < DanhSachNguoiDung.Length; i++)
            {
                if (TenTaiKhoan != DanhSachNguoiDung[i].TenTaiKhoan)
                {
                    DanhSachNguoiDungMoi[newIndex] = DanhSachNguoiDung[i];
                    newIndex++;
                }
                else
                {
                    CoNguoiDungCanXoa = true;
                }    
            }
            if (CoNguoiDungCanXoa==true)
            {
                LuuDanhSach(DanhSachNguoiDungMoi);
                return true;
            }
            else
            {
                return false;
            }    
        }


        public static NguoiDung[] DocDanhSach()
        {
            string filePath = "E:\\danhsachnguoidung.json";
            StreamReader file = new StreamReader(filePath);
            string json = file.ReadLine();
            file.Close();
            NguoiDung[] DanhSachNguoiDung = JsonConvert.DeserializeObject<NguoiDung[]>(json);
            return DanhSachNguoiDung;
        }

        public static void LuuDanhSach(NguoiDung[] ds)
        {
            string filePath = "E:\\danhsachnguoidung.json";
            string json = JsonConvert.SerializeObject(ds);
            StreamWriter file = new StreamWriter(filePath);
            file.Write(json);
            file.Close();
        }

        public static void LuuNguoiDungMoi(NguoiDung s)
        {
            NguoiDung[] DanhSachNguoiDung = DocDanhSach();
            NguoiDung[] DanhSachNguoiDungMoi = new NguoiDung[DanhSachNguoiDung.Length + 1];
            for(int i=0; i<DanhSachNguoiDung.Length; i++)
            {
                DanhSachNguoiDungMoi[i] = DanhSachNguoiDung[i];
            }
            DanhSachNguoiDungMoi[DanhSachNguoiDungMoi.Length - 1] = s;
            LuuDanhSach(DanhSachNguoiDungMoi);
        }

    }
}
