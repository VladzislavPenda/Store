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
    public class CarcaseTypesController : Controller
    {
        private readonly RepositoryContext _context;

        public CarcaseTypesController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: CarcaseTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.shopCarcaseTypes.ToListAsync());
        }

        // GET: CarcaseTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCarcaseType = await _context.shopCarcaseTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopCarcaseType == null)
            {
                return NotFound();
            }

            return View(shopCarcaseType);
        }

        // GET: CarcaseTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarcaseTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,type")] ShopCarcaseType shopCarcaseType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopCarcaseType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopCarcaseType);
        }

        // GET: CarcaseTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCarcaseType = await _context.shopCarcaseTypes.FindAsync(id);
            if (shopCarcaseType == null)
            {
                return NotFound();
            }
            return View(shopCarcaseType);
        }

        // POST: CarcaseTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,type")] ShopCarcaseType shopCarcaseType)
        {
            if (id != shopCarcaseType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopCarcaseType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopCarcaseTypeExists(shopCarcaseType.id))
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
            return View(shopCarcaseType);
        }

        // GET: CarcaseTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCarcaseType = await _context.shopCarcaseTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopCarcaseType == null)
            {
                return NotFound();
            }

            return View(shopCarcaseType);
        }

        // POST: CarcaseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopCarcaseType = await _context.shopCarcaseTypes.FindAsync(id);
            _context.shopCarcaseTypes.Remove(shopCarcaseType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopCarcaseTypeExists(int id)
        {
            return _context.shopCarcaseTypes.Any(e => e.id == id);
        }
    }
}
