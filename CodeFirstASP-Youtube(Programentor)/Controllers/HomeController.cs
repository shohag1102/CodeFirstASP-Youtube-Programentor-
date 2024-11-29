using CodeFirstASP_Youtube_Programentor_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeFirstASP_Youtube_Programentor_.Controllers
{
    public class HomeController : Controller
    {

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        public readonly StudentDBContext studentDBContext; // database access korte hole object create korte hbe
        public HomeController(StudentDBContext studentDBContext)
        {
            this.studentDBContext = studentDBContext;
        }

        public async Task<IActionResult> Index()
        {
            var stdList = await studentDBContext.Students.ToListAsync();
            return View(stdList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student std) // async use korsi tai Task<T> evabe use korte hobe
        {
            if (ModelState.IsValid)
            {
                await studentDBContext.Students.AddAsync(std);
                await studentDBContext.SaveChangesAsync();
                TempData["create-success"] = "Student created successfully!";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var student = await studentDBContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || studentDBContext.Students == null)
            {
                return NotFound();
            }
            var student = await studentDBContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Student std)
        {
            if (id != std.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                studentDBContext.Students.Update(std);
                await studentDBContext.SaveChangesAsync();
                TempData["update-success"] = "Student updated successfully!";

                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || studentDBContext.Students == null)
            {
                return NotFound();
            }
            var student = await studentDBContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var student = await studentDBContext.Students.FindAsync(id);
            if (student != null)
            {
                studentDBContext.Students.Remove(student);
            }
            await studentDBContext.SaveChangesAsync();
            TempData["delete-success"] = "Student deleted successfully!";
            return RedirectToAction("Index", "Home");
        }
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
