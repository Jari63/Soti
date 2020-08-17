using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soti.Models
{
	public class AuthorPlay
	{
		public int AuthorId { get; set; }
		public Author Author { get; set; }

		public int PlayId { get; set; }
		public Play Play { get; set; }

	}
}
