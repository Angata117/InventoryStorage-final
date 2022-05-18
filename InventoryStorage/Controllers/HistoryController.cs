using InventoryStorage.Data;
using InventoryStorage.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InventoryStorage.Controllers
{
    public class HistoryController : Controller
    {

        private readonly ApplicationDbContext _db;
        public HistoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ItemHistory> obj = _db.Histories;
            return View(obj);
        }
        public IActionResult Search(string searchBy, string search)
        {
            if (searchBy == "Id")
            {
                return View(_db.Histories.Where(x => x.Id.ToString().StartsWith(search)).ToList());
            }
            //else if (searchBy == "Description")
            //{
            //    return View(_db.Histories.Where(x => x.Description.ToLower().StartsWith(search)).ToList());
            //}
            //else if (searchBy == "ItemName")
            //{
            //    return View(_db.Histories.Where(x => x.ItemName.ToLower().StartsWith(search)).ToList());
            //}
            return View(_db.Histories.Where(x => x.Location.ToString().StartsWith(search)).ToList());
        }
    }
}
