using Aula8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Aula8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: Home/AddCookies
        public IActionResult AddCookies()
        {
            // test the use of web cookies
            // check the response messages and subsequent requests
            // session cookie
            HttpContext.Response.Cookies.Append("Test1", "Value1");
            // persistent cookies
            HttpContext.Response.Cookies.Append("Test2", "Value2",
                new CookieOptions() { Expires = DateTime.Now.AddSeconds(10) });
            HttpContext.Response.Cookies.Append("Test3", "Value3",
                new CookieOptions() { Expires = DateTime.Now.AddDays(1) });
            // some application logic code
            return RedirectToAction(nameof(Index));
        }

        // GET: Home/DeleteCookies
        public IActionResult DeleteCookies()
        {
            // delete all cookies from response (and client)
            foreach (var item in HttpContext.Request.Cookies.Keys)
            {
                HttpContext.Response.Cookies.Delete(item);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Home/AddSessionVariables
        public IActionResult AddSessionVariables()
        {
            // create variables of type string, int or byte array
            HttpContext.Session.SetString("StringValue", "Text variable value");
            HttpContext.Session.SetInt32("IntegerValue", 100);

            // a session cookie will automatically be created and sent to the client
            return RedirectToAction(nameof(Index));
        }

        // GET: Home/DeleteSessionVariables
        public IActionResult DeleteSessionVariables()
        {
            // delete all variables stored in session
            // this does not end the session,
            // for that it is necessary to delete the cookie
            foreach (var item in HttpContext.Session.Keys)
            {
                HttpContext.Session.Remove(item);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Home/DeleteSession
        public IActionResult DeleteSession()
        {
            // this deletes all session variables, bcs it ends the session itself
            // this is the default name
            HttpContext.Response.Cookies.Delete(".AspNetCore.Session");

            return RedirectToAction(nameof(Index));
        }

        // GET: Home/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
