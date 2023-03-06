using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using testWeb.Models;

namespace testWeb.Controllers
{
    
    public class HomeController : Controller
    {
        DirectoriesContext _context;

        public HomeController(DirectoriesContext dbContext)
        {
            _context = dbContext;
        }
        public IActionResult Index(int? id)
        {
            var directory = _context.Directory
                .Include(d => d.Children)
                .FirstOrDefault(d => d.Id == id);

            if (directory == null)
            {
                return NotFound();
            }

            return View(directory);
        }
    }
}