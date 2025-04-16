using Azure;
using System.ComponentModel.DataAnnotations;

namespace DuAn.Models
{
	public class Dish
	{
		[Key]
		public int MaMonAn { get; set; }

		public string TenMonAn { get; set; } = null!;

		public string? MoTa { get; set; }

		public double Gia { get; set; }

		public int? MaTag { get; set; }

		public string? DuongDanHinh { get; set; }

		public int? Soluong { get; set; }

		public bool? TrangThai { get; set; }

		public virtual ICollection<Combodetails> ChiTietCombos { get; set; } = new List<Combodetails>();

		public virtual ICollection<Orderdetails> ChiTietDonHangs { get; set; } = new List<Orderdetails>();

		public virtual ICollection<Cartdetails> ChiTietGioHangs { get; set; } = new List<Cartdetails>();

		public virtual Tag? MaTagNavigation { get; set; }
	}
}
