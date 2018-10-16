using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication.Data;
using WebApplication.Services;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly CDLContext _cdlContext;

        public AppController(IMailService mailService, CDLContext cdlContext)
        {
            _mailService = mailService;
            _cdlContext = cdlContext;
        }
        public IActionResult Index()
        {
            //throw new InvalidOperationException("Bad things happened!");

            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the email
                _mailService.SendMessage("sebastianferrari@live.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail sent!";
                ModelState.Clear();
            }


            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }

        public IActionResult Licenses()
        {
            return View();
        }
    }
}