namespace DuAn.Models
{
	public class Tag
	{
		public int MaTag { get; set; }

		public string TenTag { get; set; } = null!;

		public bool TrangThai { get; set; }

		public virtual ICollection<Dish> MonAns { get; set; } = new List<Dish>();
	}
}
