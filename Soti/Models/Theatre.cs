using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soti.Models
{
	public class Theatre
	{
		public int TheatreId { get; set; }

		/// <summary>
		/// Name of the theatre
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// <see cref="TheatreType"/>
		/// </summary>
		public TheatreType TheatreType { get; set; }

		/// <summary>
		/// Contact person. Last name, first name
		/// </summary>
		public string ContactPerson { get; set; }

		/// <summary>
		/// <see cref="Address"/>
		/// </summary>
		public Address Address { get; set; }

		/// <summary>
		/// Company Id
		/// </summary>
		public string CompanyId { get; set; }

		public string Phone { get; set; }

		public string Mobile { get; set; }

		public string Email { get; set; }

		public string Notes { get; set; }

		/// <summary>
		/// Contracts of the theatre
		/// </summary>
		public ICollection<Contract> Contracts { get; set; }





	}
}
