using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MvcPhones.Controllers;

public class UsersController : Controller
{

   public IActionResult Index(){
       return View();
   }

   [Authorize(Roles ="Admin")]
   public IActionResult Edit() {
       return View();
   }

}
