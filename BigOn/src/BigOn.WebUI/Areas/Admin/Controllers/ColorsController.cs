using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BigOn.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorsController : Controller
    {
        private readonly BigOnDbContext db;

        public ColorsController(BigOnDbContext db)
        {
            this.db = db;
        }

        [Authorize(Policy = "admin.colors.index")]
        public IActionResult Index()
        {
            var data = db.Colors
                .Where(m => m.DeletedDate == null)
                .AsEnumerable();

            return View(data);
        }

        [Authorize(Policy = "admin.colors.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "admin.colors.create")]
        public IActionResult Create([Bind("Name")] ProductColor model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            db.Colors.Add(model);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "admin.colors.edit")]
        public IActionResult Edit(int id)
        {
            var entity = db.Colors
                .FirstOrDefault(m => m.Id == id && m.DeletedDate == null);


            if (entity == null)
            {
                return NotFound();
            }


            return View(entity);
        }

        [HttpPost]
        [Authorize(Policy = "admin.colors.edit")]
        public IActionResult Edit([Bind("Id,Name")] ProductColor model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = db.Colors
                .FirstOrDefault(m => m.Id == model.Id && m.DeletedDate == null);

            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "admin.colors.details")]
        public IActionResult Details(int id)
        {
            var entity = db.Colors
                .FirstOrDefault(m => m.Id == id && m.DeletedDate == null);


            if (entity == null)
            {
                return NotFound();
            }


            return View(entity);
        }

        [HttpPost]
        [Authorize(Policy = "admin.colors.remove")]
        public IActionResult Remove(int id)
        {
            var entity = db.Colors
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

            //db.Colors.Remove(entity);

            entity.DeletedDate = DateTime.UtcNow.AddHours(4);
            db.SaveChanges();

            return Json(new
            {
                error = false,
                message = "Silindi!"
            });
        }
    }
}
