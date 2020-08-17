using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Soti.Data;
using Soti.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcMovie.Models
{
	public static class SeedData
	{
		public static void Initialize(IServiceProvider provider)
		{
			using (var context = new SotiContext(provider.GetRequiredService<DbContextOptions<SotiContext>>()))
			{
				if (context.Theatre.Any())
				{
					return;   // DB has been seeded
				}

				context.Theatre.AddRange(
					new Theatre
					{
						Address = new Address
						{
							PostalAddress = "Ensi linja 2",
							Zip = "00530",
							City = "Helsinki"
						},
						CompanyId = "12345",
						ContactPerson = "Kaupunkilainen Kaisa",
						Contracts = new List<Contract>(),
						Email = "helsinginkaupunginteatteri@gmail.com",
						Mobile = "040 123 4567",
						Notes = "Jotain tekstiä",
						Phone = "09-1234567",
						TheatreType = Soti.Models.TheatreType.Professional
					},

					new Theatre
					{
						Address = new Address
						{
							PostalAddress = "Läntinen teatterikuja 1",
							Zip = "00100",
							City = "Helsinki"
						},
						CompanyId = "67890",
						ContactPerson = "Kansallinen Kauko",
						//Contracts = new List<Contract>(),
						Email = "helsinginkaupunginteatteri@gmail.com",
						Mobile = "040 456 4567",
						Notes = "Jotain tekstiä tähänkin",
						Phone = "09-4564567",
						TheatreType = Soti.Models.TheatreType.Professional
					}
				);

				var author1 = new Author
				{
					Address = new Address
					{
						PostalAddress = "PL 1000",
						Zip = "00100",
						City = "Helsinki"
					},
					AuthorType = AuthorType.Estate,
					BIC = "OKOYFIHH",
					IBAN = "FI 1234 5678 9000 2000 50",
					CompanyId = "123321",
					ContactPerson = "Perttilä Pertti",
					Email = "mika.waltarikp@gmail.com",
					Mobile = "040 222 333 444",
					Name = "Mika Waltarin kuolinpesä",
					Notes = "tekstiä",
					Phone = "09 456 654 345"
				};

				var author2 = new Author
				{
					Address = new Address
					{
						PostalAddress = "PL 2000",
						Zip = "00100",
						City = "Helsinki"
					},
					AuthorType = AuthorType.Estate,
					BIC = "OKOYFIHH",
					IBAN = "FI 1234 4451 9000 2000 50",
					CompanyId = "149321",
					ContactPerson = "Kivelä Kikka",
					Email = "aleksiskivikp@gmail.com",
					Mobile = "040 111 333 444",
					Name = "Aleksis Kiven kuolinpesä",
					Notes = "tekstiä",
					Phone = "09 456 222 345"
				};

				var play1 = new Play
				{
					Name = "Gabriel, tule takaisin",
				};

				var play2 = new Play
				{
					Name = "Sinuhe Egyptiläinen",
				};

				var play3 = new Play
				{
					Name = "Nummisuutarit",
				};

				var play4 = new Play
				{
					Name = "Seitsemän veljestä",
				};

				context.Author.AddRange(author1, author2);
				context.Play.AddRange(play1, play2, play3, play4);

				context.AuthorPlay.AddRange(
								new AuthorPlay { Author = author1, Play = play1 },
								new AuthorPlay { Author = author1, Play = play2 },
								new AuthorPlay { Author = author2, Play = play3 },
								new AuthorPlay { Author = author2, Play = play4 }
								);

				context.SaveChanges();
			}
		}
	}
}