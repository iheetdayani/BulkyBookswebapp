using BulkyBooksweb.Data;
using BulkyBooksweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBooksweb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBcontext _db;

        public CategoryController(ApplicationDBcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData ["Sucess"] = "Category Created sucessfully";
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }
            var categoryfromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbsingle = _db.Categories.singleOrDefault(u => u.Id == id);
            if (categoryfromDb == null)
            {

                return NotFound();
            }
            return View(categoryfromDb);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "the displayorder cannot exactly match the name");
            }
           
            if (ModelState.IsValid)
            {

                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["sucess"] ="Category UPDATED sucessfully";
                return RedirectToAction("index");
            }
            return View(obj);


        }
        public IActionResult DeletePOST(int? id)
        {
            
            var obj= _db.Categories.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
        }
    }

