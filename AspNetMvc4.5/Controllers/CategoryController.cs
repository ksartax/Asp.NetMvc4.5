using AspNetMvc4._5.Models;
using AspNetMvc4._5.Services;
using AspNetMvc4._5.Services.Interface;
using System;
using System.Web.Mvc;

namespace AspNetMvc4._5.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService = new CategoryService();

        // GET: Category
        public ActionResult Index()
        {
            return View(_categoryService.GetListView());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(_categoryService.GetView(id));
            }
            catch
            {
                return HttpNotFound();
            }
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryCreateModel createModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createModel);
            }

            try
            {
                _categoryService.Add(createModel);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(500, e.Message);
            }

            return RedirectToAction("Index");
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(_categoryService.GetEditView(id));
            }
            catch
            {
                return HttpNotFound();
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryUpdateModel updateModel)
        {
            if (!ModelState.IsValid)
            {
                return View(updateModel);
            }

            try
            {
                _categoryService.Update(id, updateModel);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(500, e.Message);
            }

            return RedirectToAction("Index");
        }

        // POST: Category/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryService.Delete(id);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(500, e.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
