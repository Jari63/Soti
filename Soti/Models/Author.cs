using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Soti.Models
{
	public class Author
	{
		#region Properties
		public int AuthorId { get; set; }

		/// <summary>
		/// Name of the author. Last name + first name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Type of the author
		/// </summary>
		public AuthorType AuthorType { get; set; }

		/// <summary>
		/// Contact person. Last name + first name
		/// </summary>
		public string ContactPerson { get; set; }

		public Address Address { get; set; }

		/// <summary>
		/// Social security number
		/// </summary>
		public string SSN { get; set; }

		/// <summary>
		/// Company Id
		/// </summary>
		public string CompanyId { get; set; }

		public string Phone { get; set; }

		public string Mobile { get; set; }

		public string Email { get; set; }

		/// <summary>
		/// Bank account number
		/// </summary>
		public string IBAN { get; set; }

		/// <summary>
		/// Bank identification code
		/// </summary>
		public string BIC { get; set; }


		public string Notes { get; set; }


		// Rewards -> maksujärjestely

		public ICollection<AuthorPlay> AuthorPlays { get; set; }

		#endregion
	}
}
