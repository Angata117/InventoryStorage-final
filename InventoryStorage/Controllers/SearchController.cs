using InventoryStorage.Data;
using InventoryStorage.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InventoryStorage.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SearchController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> obj = _db.Items;
            return View(obj);
        }
       
        public IActionResult Search(string searchBy, string search)
        {
            if (searchBy == "Id")
            {
                return View(_db.Items.Where(x => x.Id.ToString().StartsWith(search)).ToList());
            }
            else if (searchBy == "Description")
            {
                return View(_db.Items.Where(x => x.Description.ToLower().StartsWith(search)).ToList());
            }
            else if (searchBy == "ItemName")
            {
                return View(_db.Items.Where(x => x.ItemName.ToLower().StartsWith(search)).ToList());
            }
            return View(_db.Items.Where(x => x.Location.ToString().StartsWith(search)).ToList());
        }
        public IActionResult Update(int? Id)
        {
            var obj = _db.Items.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Update POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
                _db.Items.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
        public IActionResult Delete(int? Id)
        {
            var obj = _db.Items.Find(Id);

            if (Id == null)
            {
                return NotFound();
            }
            _db.Items.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
