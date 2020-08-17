using Microsoft.EntityFrameworkCore;
using Soti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Soti.Data
{
	public class SotiContext : DbContext
	{
		public SotiContext(DbContextOptions<SotiContext> options)
			: base(options)
		{
		}

		public DbSet<Author> Author { get; set; }
		public DbSet<Play> Play { get; set; }

		public DbSet<Theatre> Theatre { get; set; }

		public DbSet<Contract> Contract { get; set; }

		public DbSet<Address> Address { get; set; }

		public DbSet<AuthorPlay> AuthorPlay { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Address>().HasNoKey();

			modelBuilder.Entity<Play>()
				.HasMany(x => x.AuthorPlays);

			modelBuilder.Entity<Author>()
				.HasMany(x => x.AuthorPlays);


			modelBuilder.Entity<AuthorPlay>()
				.HasKey(x => new { x.AuthorId, x.PlayId });

			//modelBuilder.Entity<AuthorPlay>()
			//	.HasOne(x => x.Play)
			//	.WithMany(x => (ICollection<AuthorPlay>)x.AuthorPlays)
			//	.HasForeignKey(x => x.PlayId);

			//modelBuilder.Entity<AuthorPlay>()
			//	.HasOne(x => x.Author)
			//	.WithMany(x => (ICollection<AuthorPlay>)x.AuthorPlays)
			//	.HasForeignKey(x => x);



			modelBuilder.Entity<Contract>()
				.HasKey(x => new { x.TheatreId, x.PlayId });

			modelBuilder.Entity<Contract>()
				.Property(x => x.MinimumPayment)
				.HasColumnType("money");

			modelBuilder.Entity<Contract>()
				.Property(x => x.PaymentInAnticipation)
				.HasColumnType("money");

			modelBuilder.Entity<Contract>()
				.Property(x => x.PercentageFee)
				.HasColumnType("money");

			//modelBuilder.Entity<Contract>()
			//	.HasOne(x => x.Play)
			//	.WithMany(x => x.Contracts)
			//	.HasForeignKey(x => x.PlayId);

			//modelBuilder.Entity<Contract>()
			//	.HasOne(x => x.Theatre)
			//	.WithMany(x => x.Contracts)
			//	.HasForeignKey(x => x.TheatreId);

		}
	}
}
