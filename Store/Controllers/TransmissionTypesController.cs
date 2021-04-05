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
    public class TransmissionTypesController : Controller
    {
        private readonly RepositoryContext _context;

        public TransmissionTypesController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: TransmissionTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.shopTransmissionTypes.ToListAsync());
        }

        // GET: TransmissionTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopTransmissionType = await _context.shopTransmissionTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopTransmissionType == null)
            {
                return NotFound();
            }

            return View(shopTransmissionType);
        }

        // GET: TransmissionTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransmissionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,type")] ShopTransmissionType shopTransmissionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopTransmissionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopTransmissionType);
        }

        // GET: TransmissionTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopTransmissionType = await _context.shopTransmissionTypes.FindAsync(id);
            if (shopTransmissionType == null)
            {
                return NotFound();
            }
            return View(shopTransmissionType);
        }

        // POST: TransmissionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,type")] ShopTransmissionType shopTransmissionType)
        {
            if (id != shopTransmissionType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopTransmissionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopTransmissionTypeExists(shopTransmissionType.id))
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
            return View(shopTransmissionType);
        }

        // GET: TransmissionTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopTransmissionType = await _context.shopTransmissionTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopTransmissionType == null)
            {
                return NotFound();
            }

            return View(shopTransmissionType);
        }

        // POST: TransmissionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopTransmissionType = await _context.shopTransmissionTypes.FindAsync(id);
            _context.shopTransmissionTypes.Remove(shopTransmissionType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopTransmissionTypeExists(int id)
        {
            return _context.shopTransmissionTypes.Any(e => e.id == id);
        }
    }
}
