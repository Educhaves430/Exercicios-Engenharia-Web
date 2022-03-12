using Aula6.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Aula6.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Aula6Context context;

        public StudentsController(Aula6Context context)
        {
            this.context = context;
        }
        // GET: Students
        public async Task<IActionResult> Index()
        {
            var context = this.context.Students.Include(c => c.Course);
            return View(await context.ToListAsync());
        }

        // GET: Students by letter
        public async Task<IActionResult> Index2(string letter)
        {
            ViewBag.letter = letter;

            if (string.IsNullOrEmpty(letter) == false)
            {
                return View(await context.Students.Where(x => x.Name.StartsWith(letter)).Include(c => c.Course).ToListAsync());
            }
            else
            {
                return View(await context.Students.Include(c => c.Course).ToListAsync());
            }
        }

        public async Task<IActionResult> Index3(string property, string order)
        {
            ViewBag.property = property;
            ViewBag.order = order;

            if (string.IsNullOrEmpty(order) == false && string.IsNullOrEmpty(property) == false)
            {
                if (ViewBag.order == "Ascending" && ViewBag.property == "byNumber")
                {
                    return View(await context.Students.OrderBy(x => x.Number).Include(c => c.Course).ToListAsync());
                }
                if (ViewBag.order == "Ascending" && ViewBag.property == "byName")
                {
                    return View(await context.Students.OrderBy(x => x.Name).Include(c => c.Course).ToListAsync());
                }
                if (ViewBag.order == "Descending" && ViewBag.property == "byNumber")
                {
                    return View(await context.Students.OrderByDescending(x => x.Number).Include(c => c.Course).ToListAsync());
                }
                if (ViewBag.order == "Descending" && ViewBag.property == "byName")
                {
                    return View(await context.Students.OrderByDescending(x => x.Name).Include(c => c.Course).ToListAsync());
                }
            }
            return View(await context.Students.Include(c => c.Course).ToListAsync());
        }
    }
}
