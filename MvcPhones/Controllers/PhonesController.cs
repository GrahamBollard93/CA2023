using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcPhones.Data;
using MvcPhones.Models;

namespace MvcPhones.Controllers
{
    public class PhonesController : Controller
    {
         public IActionResult Index()
        {
            return View();
        }
   }
}