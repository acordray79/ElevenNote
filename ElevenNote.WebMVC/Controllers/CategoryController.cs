using ElevenNote.Models;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService _service = new CategoryService();
        // GET: Category
        public ActionResult Index()
        {
            var model = _service.GetCategory();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            if (_service.CreateCat(model))
            {
                TempData["SaveResult"] = "Your category was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Category could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = _service.GetCategoryById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var detail = _service.GetCategoryById(id);
            var model =
                new CategoryEdit
                {
                    CatID = detail.CatID,
                    CatName = detail.CatName
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CatID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if (_service.UpdateCategory(model))
            {
                TempData["SaveResult"] = "Your category was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your category could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = _service.GetCategoryById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            _service.DeleteCategory(id);
            TempData["SaveResult"] = "Your category was deleted";
            return RedirectToAction("Index");
        }
    }
}