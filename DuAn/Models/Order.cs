using System.ComponentModel.DataAnnotations;

namespace DuAn.Models
{
	public class Order
	{
		[Key]
		public int MaDonHang { get; set; }

		public DateTime ThoiGianDat { get; set; }

		public string? TrangThai { get; set; }

		public double TongTien { get; set; }
		public string? Address { get; set; }
		public string? MaNguoiDung { get; set; }

		public virtual ICollection<Orderdetails> ChiTietDonHangs { get; set; } = new List<Orderdetails>();

		public virtual ApplicationUser? MaNguoiDungNavigation { get; set; }

	}
}
