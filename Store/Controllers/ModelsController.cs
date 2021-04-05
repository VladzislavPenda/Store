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
    public class ModelsController : Controller
    {
        private readonly RepositoryContext _context;

        public ModelsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: Models
        public async Task<IActionResult> Index()
        {
            var repositoryContext = _context.ShopModels.Include(s => s.ShopCarcaseType).Include(s => s.ShopDriveType).Include(s => s.ShopEngineType).Include(s => s.ShopMark).Include(s => s.ShopTransmissionType);
            return View(await repositoryContext.ToListAsync());
        }

        // GET: Models/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopModel = await _context.ShopModels
                .Include(s => s.ShopCarcaseType)
                .Include(s => s.ShopDriveType)
                .Include(s => s.ShopEngineType)
                .Include(s => s.ShopMark)
                .Include(s => s.ShopTransmissionType)
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopModel == null)
            {
                return NotFound();
            }

            return View(shopModel);
        }

        // GET: Models/Create
        public IActionResult Create()
        {
            ViewData["carcaseTypeId"] = new SelectList(_context.shopCarcaseTypes, "id", "type");
            ViewData["driveTypeId"] = new SelectList(_context.shopDriveTypes, "id", "type");
            ViewData["engineTypeId"] = new SelectList(_context.ShopEngineTypes, "id", "type");
            ViewData["markId"] = new SelectList(_context.shopMarks, "id", "markNum");
            ViewData["transmissionId"] = new SelectList(_context.shopTransmissionTypes, "id", "type");
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,model,year,horsePower,price,mileAge,pathToPicture,description,markId,transmissionId,carcaseTypeId,engineTypeId,driveTypeId")] ShopModel shopModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["carcaseTypeId"] = new SelectList(_context.shopCarcaseTypes, "id", "type", shopModel.carcaseTypeId);
            ViewData["driveTypeId"] = new SelectList(_context.shopDriveTypes, "id", "type", shopModel.driveTypeId);
            ViewData["engineTypeId"] = new SelectList(_context.ShopEngineTypes, "id", "type", shopModel.engineTypeId);
            ViewData["markId"] = new SelectList(_context.shopMarks, "id", "markNum", shopModel.markId);
            ViewData["transmissionId"] = new SelectList(_context.shopTransmissionTypes, "id", "type", shopModel.transmissionId);
            return View(shopModel);
        }

        // GET: Models/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopModel = await _context.ShopModels.FindAsync(id);
            if (shopModel == null)
            {
                return NotFound();
            }
            ViewData["carcaseTypeId"] = new SelectList(_context.shopCarcaseTypes, "id", "type", shopModel.carcaseTypeId);
            ViewData["driveTypeId"] = new SelectList(_context.shopDriveTypes, "id", "type", shopModel.driveTypeId);
            ViewData["engineTypeId"] = new SelectList(_context.ShopEngineTypes, "id", "type", shopModel.engineTypeId);
            ViewData["markId"] = new SelectList(_context.shopMarks, "id", "markNum", shopModel.markId);
            ViewData["transmissionId"] = new SelectList(_context.shopTransmissionTypes, "id", "type", shopModel.transmissionId);
            return View(shopModel);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,model,year,horsePower,price,mileAge,pathToPicture,description,markId,transmissionId,carcaseTypeId,engineTypeId,driveTypeId")] ShopModel shopModel)
        {
            if (id != shopModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopModelExists(shopModel.id))
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
            ViewData["carcaseTypeId"] = new SelectList(_context.shopCarcaseTypes, "id", "type", shopModel.carcaseTypeId);
            ViewData["driveTypeId"] = new SelectList(_context.shopDriveTypes, "id", "id", shopModel.driveTypeId);
            ViewData["engineTypeId"] = new SelectList(_context.ShopEngineTypes, "id", "id", shopModel.engineTypeId);
            ViewData["markId"] = new SelectList(_context.shopMarks, "id", "id", shopModel.markId);
            ViewData["transmissionId"] = new SelectList(_context.shopTransmissionTypes, "id", "id", shopModel.transmissionId);
            return View(shopModel);
        }

        // GET: Models/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopModel = await _context.ShopModels
                .Include(s => s.ShopCarcaseType)
                .Include(s => s.ShopDriveType)
                .Include(s => s.ShopEngineType)
                .Include(s => s.ShopMark)
                .Include(s => s.ShopTransmissionType)
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopModel == null)
            {
                return NotFound();
            }

            return View(shopModel);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopModel = await _context.ShopModels.FindAsync(id);
            _context.ShopModels.Remove(shopModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopModelExists(int id)
        {
            return _context.ShopModels.Any(e => e.id == id);
        }
    }
}
