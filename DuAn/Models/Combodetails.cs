using System.ComponentModel.DataAnnotations;

namespace DuAn.Models
{
	public class Combodetails
	{
		[Key]
		public int MaCombo { get; set; }

		public int MaMonAn { get; set; }

		public int SoLuong { get; set; }

		public virtual Combo MaComboNavigation { get; set; } = null!;

		public virtual Dish MaMonAnNavigation { get; set; } = null!;
	}
}
