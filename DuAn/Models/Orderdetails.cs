using System.ComponentModel.DataAnnotations;

namespace DuAn.Models
{
	public class Orderdetails
	{
		[Key]
        public int MaChiTietDonHang { get; set; }

        public int SoLuong { get; set; }

        public double Gia { get; set; }

        public int? MaDonHang { get; set; }

        public int? MaMonAn { get; set; }

        public int? MaCombo { get; set; }
        public string DiaChiNhanHang { get; set; }
        public string lyDoHuyDon { get; set; }

        public virtual Combo? MaComboNavigation { get; set; }

        public virtual Order? MaDonHangNavigation { get; set; }

        public virtual Dish? MaMonAnNavigation { get; set; }
    }
}
