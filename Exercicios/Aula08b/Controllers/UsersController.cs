using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aula8b.Data;
using Aula8b.Models;
using Microsoft.AspNetCore.Http;

namespace Aula8b.Controllers
{
    public class UsersController : Controller
    {
        private readonly Aula8bContext _context;

        public UsersController(Aula8bContext context)
        {
            _context = context;
        }

        // GET: Users/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Users/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string UserName, string Password)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.User.SingleOrDefaultAsync(u => 
                u.UserName == UserName && u.Password == Password);
                if (user == null)
                {
                    ModelState.AddModelError("UserName", "Incorrect credentials");
                }
                else
                {
                    // user is authenticated
                    // session variable "user" is created to recover the user identity at each request
                    HttpContext.Session.SetString("user", UserName);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        // GET: Users/Logout
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete(".Class08b.Session");

            return RedirectToAction("Index", "Home");
        }

        // GET: Users/Preferences
        public IActionResult Preferences()
        {
            ViewBag.mode = HttpContext.Request.Cookies["viewMode"] ?? "light";

            return View();
        }

        // POST: Users/Preferences
        [HttpPost]
        public IActionResult Preferences(string mode)
        {
            HttpContext.Response.Cookies.Append("viewMode", mode,
                new CookieOptions { Expires = DateTime.Now.AddYears(1) });

            return RedirectToAction("Index", "Home");
        }
    }
}
