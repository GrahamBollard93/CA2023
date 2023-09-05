using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcPhones.Models;

namespace MvcPhones.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}