using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTaskNikonov.Models;
using Microsoft.EntityFrameworkCore;

namespace TestTaskNikonov.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult GetCategory()
        {
            List<Category> categories= _context.Categories.ToList();
            return View(categories);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("GetCategory");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int Id)
        {
            _context.Categories.Remove(_context.Categories.FirstOrDefault(f => f.Id == Id));
            _context.SaveChanges();
            return RedirectToAction("GetCategory");
        }

        [HttpGet]
        public IActionResult EditCategory(int Id)
        {
            Category category = _context.Categories.FirstOrDefault(f => f.Id == Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("GetCategory");
        }


        public IActionResult Index()
        {
            List<Application> applications = _context.Applications.ToList();

            applications.Select(f => f.Category = new Category
            {
                Name = _context.Categories.FirstOrDefault(z => z.Id == f.CategoryID).Name,
            }).ToList();

            ViewBag.Categories = _context.Categories;

            return View(applications);
        }

        [HttpPost]
        public IActionResult Create(Application app)
        {
            app.DateUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {                
                app.Category = _context.Categories.FirstOrDefault(f => f.Id == app.CategoryID);
                _context.Applications.Add(app);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _context.Applications.Remove(_context.Applications.FirstOrDefault(f => f.Id == Id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {

            Application app = _context.Applications.FirstOrDefault(f => f.Id == Id);
            app.Category = _context.Categories.FirstOrDefault(x => x.Id == app.CategoryID);
            ViewBag.Categories = _context.Categories;
            return View(app);
        }

        [HttpPost]
        public IActionResult Edit(Application app)
        {           
            app.DateUpdate = DateTime.Now;
            _context.Entry(app).State = EntityState.Modified;
            _context.SaveChanges();            
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
