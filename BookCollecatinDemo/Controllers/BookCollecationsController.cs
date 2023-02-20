using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookCollecatinDemo.Data;
using BookCollecatinDemo.Models;

namespace BookCollecatinDemo.Controllers
{
    public class BookCollecationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookCollecationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookCollecations
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookColleactions.ToListAsync());
        }

        // GET: BookCollecations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCollecation = await _context.BookColleactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCollecation == null)
            {
                return NotFound();
            }

            return View(bookCollecation);
        }

        // GET: BookCollecations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookCollecations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Authorname,ReleaseDate,Rating")] BookCollecation bookCollecation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCollecation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookCollecation);
        }

        // GET: BookCollecations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCollecation = await _context.BookColleactions.FindAsync(id);
            if (bookCollecation == null)
            {
                return NotFound();
            }
            return View(bookCollecation);
        }

        // POST: BookCollecations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Authorname,ReleaseDate,Rating")] BookCollecation bookCollecation)
        {
            if (id != bookCollecation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCollecation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCollecationExists(bookCollecation.Id))
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
            return View(bookCollecation);
        }

        // GET: BookCollecations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCollecation = await _context.BookColleactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCollecation == null)
            {
                return NotFound();
            }

            return View(bookCollecation);
        }

        // POST: BookCollecations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookCollecation = await _context.BookColleactions.FindAsync(id);
            _context.BookColleactions.Remove(bookCollecation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCollecationExists(int id)
        {
            return _context.BookColleactions.Any(e => e.Id == id);
        }
    }
}
