using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;

namespace Store.Controllers
{
    public class ShopMarksController : Controller
    {
        private readonly RepositoryContext _context;

        public ShopMarksController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: ShopMarks
        public async Task<IActionResult> Index()
        {
            return View(await _context.shopMarks.ToListAsync());
        }

        // GET: ShopMarks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopMark = await _context.shopMarks
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopMark == null)
            {
                return NotFound();
            }

            return View(shopMark);
        }

        // GET: ShopMarks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopMarks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,markNum,country")] ShopMark shopMark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopMark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopMark);
        }

        // GET: ShopMarks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopMark = await _context.shopMarks.FindAsync(id);
            if (shopMark == null)
            {
                return NotFound();
            }
            return View(shopMark);
        }

        // POST: ShopMarks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,markNum,country")] ShopMark shopMark)
        {
            if (id != shopMark.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopMark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopMarkExists(shopMark.id))
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
            return View(shopMark);
        }

        // GET: ShopMarks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopMark = await _context.shopMarks
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopMark == null)
            {
                return NotFound();
            }

            return View(shopMark);
        }

        // POST: ShopMarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopMark = await _context.shopMarks.FindAsync(id);
            _context.shopMarks.Remove(shopMark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopMarkExists(int id)
        {
            return _context.shopMarks.Any(e => e.id == id);
        }
    }
}
