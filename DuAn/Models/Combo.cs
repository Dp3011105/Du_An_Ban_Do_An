namespace DuAn.Models
{
	public class Combo
	{

		public int MaCombo { get; set; }
		public string TenCombo { get; set; }
		public string MoTa { get; set; }
        public int SoLuong { get; set; }
        public double Gia { get; set; }
		public bool TrangThai { get; set; }
		public string DuongDanHinh { get; set; }


		public virtual ICollection<Combodetails> ChiTietCombos { get; set; } = new List<Combodetails>();

		public virtual ICollection<Orderdetails> ChiTietDonHangs { get; set; } = new List<Orderdetails>();

		public virtual ICollection<Cartdetails> ChiTietGioHangs { get; set; } = new List<Cartdetails>();
	}
}
