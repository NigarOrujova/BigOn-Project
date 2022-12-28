using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;

namespace BigOn.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaterialsController : Controller
    {
        private readonly BigOnDbContext _context;

        public MaterialsController(BigOnDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Materials
        public async Task<IActionResult> Index()
        {
            var data = await _context.Materials
                .Where(m => m.DeletedDate == null)
                .ToListAsync();


            return View(data);
        }

        // GET: Admin/Materials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMaterial = await _context.Materials
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productMaterial == null)
            {
                return NotFound();
            }

            return View(productMaterial);
        }

        // GET: Admin/Materials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,CreatedDate,DeletedDate")] ProductMaterial productMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productMaterial);
        }

        // GET: Admin/Materials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMaterial = await _context.Materials.FindAsync(id);
            if (productMaterial == null)
            {
                return NotFound();
            }
            return View(productMaterial);
        }

        // POST: Admin/Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,CreatedDate,DeletedDate")] ProductMaterial productMaterial)
        {
            if (id != productMaterial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductMaterialExists(productMaterial.Id))
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
            return View(productMaterial);
        }



        // POST: Admin/Materials/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            var entity = _context.Brands
                .FirstOrDefault(m => m.Id == id && m.DeletedDate == null);


            if (entity == null)
            {
                var response = new
                {
                    error = true,
                    message = "Qeyd tapilmadi"
                };
                return Json(response);
            }

            //db.Brands.Remove(entity);

            entity.DeletedDate = DateTime.UtcNow.AddHours(4);
            _context.SaveChanges();

            return Json(new
            {
                error = false,
                message = "Silindi!"
            });
        }

        private bool ProductMaterialExists(int id)
        {
            return _context.Materials.Any(e => e.Id == id);
        }
    }
}
