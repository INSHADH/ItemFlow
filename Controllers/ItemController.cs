using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AddItemApp.Data;
using AddItemApp.Models;

namespace AddItemApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly AppDbContext _context;

        public ItemController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.Items.ToList(); 
            return View(items);
        }

        [HttpGet]
        [Route("Item/Create")]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [Route("Item/Create")]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item); 
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

            return Json(new { success = false, error = "Invalid data" });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound(); 
            }
            return View(item); 
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                _context.SaveChanges(); 
                return RedirectToAction("Index"); 
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return Json(new { success = false, message = "Item not found" });
            }

            _context.Items.Remove(item);
            _context.SaveChanges();

            return Json(new { success = true });
        }


      
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges(); 
            }
            return RedirectToAction("Index");
        }
    }
}

