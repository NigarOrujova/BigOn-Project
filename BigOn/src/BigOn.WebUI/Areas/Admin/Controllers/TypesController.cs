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
    public class TypesController : Controller
    {
        private readonly BigOnDbContext db;

        public TypesController(BigOnDbContext db)
        {
            this.db = db;
        }

        // GET: Admin/Types
        public async Task<IActionResult> Index()
        {
            var data = await db.Types
                .Where(t => t.DeletedDate == null)
                .ToListAsync();
            return View(data);
        }

        // GET: Admin/Types/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await db.Types
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // GET: Admin/Types/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Types/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,CreatedDate,DeletedDate")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                db.Add(productType);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productType);
        }

        // GET: Admin/Types/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await db.Types.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        // POST: Admin/Types/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,CreatedDate,DeletedDate")] ProductType productType)
        {
            if (id != productType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(productType);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTypeExists(productType.Id))
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
            return View(productType);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var entity = db.Types
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
            db.SaveChanges();

            return Json(new
            {
                error = false,
                message = "Silindi!"
            });
        }

        private bool ProductTypeExists(int id)
        {
            return db.Types.Any(e => e.Id == id);
        }
    }
}
