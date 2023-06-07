using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phone.DATA;
using Phone.Models;

namespace Phone.Controllers
{
    public class PhoneBookController : Controller
    {
        private readonly PhoneDbContext _context;
        public PhoneBookController(PhoneDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(_context.Contacts.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(contact);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id != null)
            {
                var contact = await _context.Contacts.FindAsync(id);
                return View(contact);

            }
            return BadRequest();
            
        }
    }
}
