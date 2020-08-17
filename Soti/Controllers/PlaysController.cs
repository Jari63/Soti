using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Soti.Data;
using Soti.Models;

namespace Soti.Controllers
{
	public class PlaysController : Controller
	{
		private readonly SotiContext _context;
		private readonly ILogger<PlaysController> _logger;

		public PlaysController(SotiContext context, ILogger<PlaysController> logger)
		{
			_context = context;
			_logger = logger;
		}

		// GET: Plays
		public async Task<IActionResult> Index(string authorString)
		{
			if (!string.IsNullOrEmpty(authorString))
			{
				//var query = _context.Play.Where(play => play.AuthorPlays.Any(authorPlay => authorPlay.Author.Name.ToLower().Contains(authorString.ToLower())));
				var query = _context.AuthorPlay.Where(ap => ap.Author.Name.ToLower().Contains(authorString.ToLower())).Include(c => c.Play).Include(c => c.Author);
				return View(await query.ToListAsync());
			}
			return View(await _context.AuthorPlay.Include(c => c.Play).Include(c => c.Author).ToListAsync());
		}

		// GET: Plays/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var play = await _context.Play
				.FirstOrDefaultAsync(m => m.PlayId == id);
			if (play == null)
			{
				return NotFound();
			}

			return View(play);
		}

		// GET: Plays/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Plays/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("PlayId,Name,Notes")] Play play)
		{
			if (ModelState.IsValid)
			{
				_context.Add(play);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(play);
		}

		// GET: Plays/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var play = await _context.Play.FindAsync(id);
			if (play == null)
			{
				return NotFound();
			}
			return View(play);
		}

		// POST: Plays/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("PlayId,Name,Notes")] Play play)
		{
			if (id != play.PlayId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					//throw new ArgumentException("teit virheen", "parametri");
					_logger.Log(LogLevel.Error, "teit virheen", new object[] { "Virhe1", "Virhe2" });
					_context.Update(play);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PlayExists(play.PlayId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(play);
		}

		// GET: Plays/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var play = await _context.Play
				.FirstOrDefaultAsync(m => m.PlayId == id);
			if (play == null)
			{
				return NotFound();
			}

			return View(play);
		}

		// POST: Plays/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var play = await _context.Play.FindAsync(id);
			_context.Play.Remove(play);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool PlayExists(int id)
		{
			return _context.Play.Any(e => e.PlayId == id);
		}
	}
}
