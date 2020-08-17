using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soti.Models
{
	public class Contract
	{
		//public int ContractId { get; set; }

		public int TheatreId { get; set; }

		public Theatre Theatre { get; set; }

		public int PlayId { get; set; }

		public Play Play { get; set; }

		/// <summary>
		/// Are performances ended
		/// </summary>
		public bool IsPerformanceEnded { get; set; }

		public string Music { get; set; }

		public string Stage { get; set; }

		/// <summary>
		/// Duration of the contract in months
		/// </summary>
		public int ValidMonths { get; set; }

		/// <summary>
		/// Number of performances of the play
		/// </summary>
		public int PlayTimes { get; set; }

		/// <summary>
		/// Payment in anticipation
		/// </summary>
		public decimal PaymentInAnticipation { get; set; }

		/// <summary>
		/// Percantage Fee
		/// </summary>
		public decimal PercentageFee { get; set; }

		/// <summary>
		/// Range of the contract in kilometres
		/// </summary>
		public int Range { get; set; }

		/// <summary>
		/// The date of the premiere of the play
		/// </summary>
		public DateTime Premiere { get; set; }

		/// <summary>
		/// Number of seats in the theatre
		/// </summary>
		public int Seats { get; set; }

		/// <summary>
		/// Date of the invoice
		/// </summary>
		public DateTime InvoiceDate { get; set; }

		/// <summary>
		/// Mimimum payment
		/// </summary>
		public decimal MinimumPayment { get; set; }

	}
}
