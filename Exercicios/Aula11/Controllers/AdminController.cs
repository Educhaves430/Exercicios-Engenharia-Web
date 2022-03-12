using Aula11.Data;
using Aula11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Aula11.Controllers
{
    public class AdminController : Controller
    {
        private readonly Aula11Context _context;

        public AdminController(Aula11Context context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Person.ToListAsync());
        }

        // POST: Create
        [HttpPost]
        public async Task<IActionResult> Create(string NewName)
        {
            Person person = new()
            {
                Name = NewName,
            };

            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return PartialView("Listing", _context.Person);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int Id)
        {
            Person person = await _context.Person.SingleOrDefaultAsync(x => x.Id == Id);
            return PartialView(nameof(Edit), person);
        }

        // POST: Edit
        [HttpPost]
        public async Task<string> Edit(int Id, Person person)
        {
            _context.Update(person);
            await _context.SaveChangesAsync();
            return person.Name;
        }

        // GET: Delete
        public async Task<string> Delete(int Id)
        {
            Person person = await _context.Person.FirstOrDefaultAsync(x => x.Id == Id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return "";
        }
    }
}
