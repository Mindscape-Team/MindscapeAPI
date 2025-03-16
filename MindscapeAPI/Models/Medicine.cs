using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindscapeAPI.Models
{
	public class Medicine
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id {  get; set; }
		public string? Name { get; set; }
		public string? DosageFrequency { get; set; }
		public string? Dosage { get; set; }
		public string? MedicineTime { get; set; }
		public string? MedicinePhoto { get; set; }
		public DateTime Date { get; set; }

		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
	}
}
