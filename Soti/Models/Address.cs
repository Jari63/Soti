using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soti.Models
{
	public class Address
	{
		public int AddressId { get; set; }

		public string PostalAddress { get; set; }

		public string Zip { get; set; }

		public string City { get; set; }
	}
}
