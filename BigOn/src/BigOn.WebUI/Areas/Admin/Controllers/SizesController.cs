using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BigOn.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizesController : Controller
    {
        private readonly BigOnDbContext db;

        public SizesController(BigOnDbContext db)
        {
            this.db = db;
        }

        // GET: Admin/Sizes
        public async Task<IActionResult> Index()
        {
            var data = await db.Sizes
                .Where(m => m.DeletedDate == null)
                .ToListAsync();
            return View(data);
        }

        // GET: Admin/Sizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSize = await db.Sizes
                .FirstOrDefaultAsync(m => m.Id == id && m.DeletedDate == null);

            if (productSize == null)
            {
                return NotFound();
            }

            return View(productSize);
        }

        // GET: Admin/Sizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ShortName,Id,CreatedDate,DeletedDate")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                db.Add(productSize);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productSize);
        }

        // GET: Admin/Sizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSize = await db.Sizes
                .FirstOrDefaultAsync(m => m.Id == id && m.DeletedDate == null);
            if (productSize == null)
            {
                return NotFound();
            }
            return View(productSize);
        }

        // POST: Admin/Sizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ShortName,Id,CreatedDate,DeletedDate")] ProductSize productSize)
        {
            if (id != productSize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(productSize);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSizeExists(productSize.Id))
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
            return View(productSize);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {

            var entity = db.Sizes
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

            var data = db.Sizes
              .Where(m => m.DeletedDate == null)
              .AsEnumerable();

            return PartialView("_ListBody", data);
        }

        private bool ProductSizeExists(int id)
        {
            return db.Sizes.Any(e => e.Id == id);
        }
    }
}
