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
    public class DriveTypesController : Controller
    {
        private readonly RepositoryContext _context;

        public DriveTypesController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: DriveTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.shopDriveTypes.ToListAsync());
        }

        // GET: DriveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopDriveType = await _context.shopDriveTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopDriveType == null)
            {
                return NotFound();
            }

            return View(shopDriveType);
        }

        // GET: DriveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DriveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,type")] ShopDriveType shopDriveType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopDriveType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopDriveType);
        }

        // GET: DriveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopDriveType = await _context.shopDriveTypes.FindAsync(id);
            if (shopDriveType == null)
            {
                return NotFound();
            }
            return View(shopDriveType);
        }

        // POST: DriveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,type")] ShopDriveType shopDriveType)
        {
            if (id != shopDriveType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopDriveType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopDriveTypeExists(shopDriveType.id))
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
            return View(shopDriveType);
        }

        // GET: DriveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopDriveType = await _context.shopDriveTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopDriveType == null)
            {
                return NotFound();
            }

            return View(shopDriveType);
        }

        // POST: DriveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopDriveType = await _context.shopDriveTypes.FindAsync(id);
            _context.shopDriveTypes.Remove(shopDriveType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopDriveTypeExists(int id)
        {
            return _context.shopDriveTypes.Any(e => e.id == id);
        }
    }
}
