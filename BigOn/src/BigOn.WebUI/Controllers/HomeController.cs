using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System;
using BigOn.Domain.AppCode.Services;
using MediatR;
using BigOn.Domain.Business.FaqModule;
using Microsoft.AspNetCore.Authorization;

namespace BigOn.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly BigOnDbContext db;
        private readonly ICryptoService crypto;
        private readonly IEmailService emailService;
        private readonly IMediator mediator;

        public HomeController(BigOnDbContext db, ICryptoService crypto, IEmailService emailService,IMediator mediator)
        {
            this.db = db;
            this.crypto = crypto;
            this.emailService = emailService;
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/about.html")]
        public IActionResult About()
        {
            return View();
        }

        [Route("/faqs.html")]
        public async Task<IActionResult> Faqs(FaqsAllQuery query)
        {
            var faqs = await mediator.Send(query);
            return View(faqs);
        }

        [Route("/contact.html")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("/contact.html")]
        public IActionResult Contact(ContactPost model)
        {
            db.ContactPosts.Add(model);
            db.SaveChanges();
            TempData["message"] = "muracietiniz qebul edildi.";
            return RedirectToAction(nameof(Contact));
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            var subscriber = await db.Subscribers.FirstOrDefaultAsync(s => s.Email.Equals(email));

            if (subscriber != null && subscriber.ApprovedDate != null)
            {
                return Json(new
                {
                    error = false,
                    message = "Siz artıq abunəsiniz!"
                });
            }
            else if (subscriber != null)
            {
                //send to email
                goto end;
            }
            else
            {
                subscriber = new Subscribe();

                subscriber.Email = email;

                await db.Subscribers.AddAsync(subscriber);
                await db.SaveChangesAsync();

                string token = crypto.Encrypt($"{subscriber.Id}-{subscriber.Email}", true);

                string approveLink = $"https://localhost:44356/subscribe-approve?token={token}";
                string message = "Memnun olduq,<br/>Zehmet olmasa abuneliyiniz  " +
                              $"<a href='{approveLink}'>link</a> tamamalayasiniz";

                await emailService.SendEmailAsync(email, "BigOn E-commerce Subscribe Request", message);
            }

        end:
            return Json(new
            {
                error = false,
                message = "E-poct addressinize tesdiq linki gonderildi!"
            });
        }

        [Route("/subscribe-approve")]
        public async Task<IActionResult> SubscribeApprove(string token)
        {
            token = crypto.Decrypt(token);

            var match = Regex.Match(token, @"^(?<id>\d+)-(?<email>.+)$");

            if (!match.Success)
            {
                return Content("token zedelidir");
            }

            int id = Convert.ToInt32(match.Groups["id"].Value);

            string email = match.Groups["email"].Value;
            string expireDate = match.Groups["expireDate"].Value;

            var subscriber = await db.Subscribers.FirstOrDefaultAsync(s => s.Id == id);

            if (subscriber == null)
            {
                return Content("tapilmadi");
            }
            else if (!subscriber.Email.Equals(email))
            {
                return Content("token size aid deyil");
            }
            else if (subscriber.ApprovedDate != null)
            {
                return View("AlreadySubscribed");
            }

            subscriber.ApprovedDate = DateTime.Now;
            await db.SaveChangesAsync();

            return View("Success");
        }
    }
}
