using System.ComponentModel.DataAnnotations;

namespace DuAn.Models
{
	public class ShoppingCart
	{
		[Key]
		public int MaGioHang { get; set; }

		public string? MaNguoiDung { get; set; }

		public virtual ICollection<Cartdetails> ChiTietGioHangs { get; set; } = new List<Cartdetails>();

		public virtual ApplicationUser? MaNguoiDungNavigation { get; set; }
	}
}
