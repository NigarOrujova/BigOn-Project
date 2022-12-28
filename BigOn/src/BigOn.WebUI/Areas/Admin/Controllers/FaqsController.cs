using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using BigOn.Domain.Business.FaqModule;

namespace BigOn.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FaqsController : Controller
    {
        private readonly IMediator mediator;

        public FaqsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(FaqsAllQuery query)
        {
            var data = await mediator.Send(query);

            return View(data);
        }

        public async Task<IActionResult> Details(FaqSingleQuery query)
        {
            var data = await mediator.Send(query);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FaqCreateCommand command)
        {
            var response = await mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(FaqSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FaqEditCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }


            var response = await mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove(FaqRemoveCommand command)
        {
            var response = await mediator.Send(command);


            if (response.Error)
            {
                return Json(response);
            }

            var newQuery = new FaqsAllQuery();
            var data = await mediator.Send(newQuery);
            return PartialView("_ListBody", data);
        }
    }
}
