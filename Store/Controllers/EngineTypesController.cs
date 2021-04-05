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
    public class EngineTypesController : Controller
    {
        private readonly RepositoryContext _context;

        public EngineTypesController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: EngineTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShopEngineTypes.ToListAsync());
        }

        // GET: EngineTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopEngineType = await _context.ShopEngineTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopEngineType == null)
            {
                return NotFound();
            }

            return View(shopEngineType);
        }

        // GET: EngineTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EngineTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,type")] ShopEngineType shopEngineType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopEngineType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopEngineType);
        }

        // GET: EngineTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopEngineType = await _context.ShopEngineTypes.FindAsync(id);
            if (shopEngineType == null)
            {
                return NotFound();
            }
            return View(shopEngineType);
        }

        // POST: EngineTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,type")] ShopEngineType shopEngineType)
        {
            if (id != shopEngineType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopEngineType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopEngineTypeExists(shopEngineType.id))
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
            return View(shopEngineType);
        }

        // GET: EngineTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopEngineType = await _context.ShopEngineTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopEngineType == null)
            {
                return NotFound();
            }

            return View(shopEngineType);
        }

        // POST: EngineTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopEngineType = await _context.ShopEngineTypes.FindAsync(id);
            _context.ShopEngineTypes.Remove(shopEngineType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopEngineTypeExists(int id)
        {
            return _context.ShopEngineTypes.Any(e => e.id == id);
        }
    }
}
