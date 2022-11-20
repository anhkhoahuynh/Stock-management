using System.Linq;

namespace QLSP.Entities
{
    public struct HoaDonBan
    {
        public int MaHoaDonBan;
        public DateTime NgayTaoHoaDonBan;
        public ChiTietHoaDon[] ChiTietHoaDon;
        public float TongGiaTriHoaDonBan;
    }

}
