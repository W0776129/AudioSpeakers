using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AudioSpeakers.Data;
using AudioSpeakers.Models;

namespace AudioSpeakers.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly AudioSpeakersContext _context;

        public SpeakersController(AudioSpeakersContext context)
        {
            _context = context;
        }

        // GET: Speakers
        public async Task<IActionResult> Index(string searchString)
        {
            var speaker = from m in _context.Speakers
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                speaker = speaker.Where(s => s.Title.Contains(searchString));
            }

            return View(await speaker.ToListAsync());
        }

        // GET: Speakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakers = await _context.Speakers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (speakers == null)
            {
                return NotFound();
            }

            return View(speakers);
        }

        // GET: Speakers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Speakers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Type,Rating,Price")] Speakers speakers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speakers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(speakers);
        }

        // GET: Speakers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakers = await _context.Speakers.FindAsync(id);
            if (speakers == null)
            {
                return NotFound();
            }
            return View(speakers);
        }

        // POST: Speakers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Type,Rating,Price")] Speakers speakers)
        {
            if (id != speakers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speakers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeakersExists(speakers.Id))
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
            return View(speakers);
        }

        // GET: Speakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakers = await _context.Speakers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (speakers == null)
            {
                return NotFound();
            }

            return View(speakers);
        }

        // POST: Speakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speakers = await _context.Speakers.FindAsync(id);
            _context.Speakers.Remove(speakers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeakersExists(int id)
        {
            return _context.Speakers.Any(e => e.Id == id);
        }
    }
}
