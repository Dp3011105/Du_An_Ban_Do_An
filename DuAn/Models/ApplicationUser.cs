using Microsoft.AspNetCore.Identity;

namespace DuAn.Models
{
	public class ApplicationUser : IdentityUser
	
	{

		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;

		public DateTime? DateOfBirth { get; set; }

		public string? Address { get; set; }
		public string? Gender { get; set; }
		public string? Nationality { get; set; }



		public string Role { get; set; } = "KhachHang";
		public virtual ICollection<Order> DonHangs { get; set; } = new List<Order>();

		public virtual ICollection<ShoppingCart> GioHangs { get; set; } = new List<ShoppingCart>();
	}
}
