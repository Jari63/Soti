using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Soti.Models
{
	public class Play
	{
		public int PlayId { get; set; }

		/// <summary>
		/// Name of the play
		/// </summary>
		public string Name { get; set; }

		public string Notes { get; set; }

		/// <summary>
		/// Contracts of the play
		/// </summary>
		public ICollection<Contract> Contracts { get; set; }

		public ICollection<AuthorPlay> AuthorPlays { get; set; }


	}
}
