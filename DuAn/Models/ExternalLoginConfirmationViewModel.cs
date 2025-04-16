using System.ComponentModel.DataAnnotations;

namespace DuAn.Models
{
	public class ExternalLoginConfirmationViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
