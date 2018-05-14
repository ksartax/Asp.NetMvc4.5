using AspNetMvc4._5.Helpers;
using AspNetMvc4._5.ModelViews;
using AspNetMvc4._5.Services;
using AspNetMvc4._5.Services.Interface;
using System;
using System.Web.Mvc;

namespace AspNetMvc4._5.Controllers
{
    public class VechicleController : Controller
    {
        private readonly IVechicleService _vechicleService = new VechicleService();

        // GET: Vechicle
        [OutputCache(CacheProfile = "Test", Duration = 10, VaryByHeader = "X-Requested-With; Accept-Language", Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            return View(_vechicleService.GetListView());
        }

        // GET: Vechicle/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var a = _vechicleService.GetView(id);

                return View(_vechicleService.GetView(id));
            }
            catch
            {
                return HttpNotFound();
            }
        }

        // GET: Vechicle/Create
        public ActionResult Create()
        {
            ViewBag.Type = TypesHelpers.DropDownList();
            ViewBag.Categories = CategoryHelpers.DropDownList();

            return View();
        }

        // POST: Vechicle/Create
        [HttpPost]
        public ActionResult Create(VachicleCreateModel createModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createModel);
            }

            try
            {
                _vechicleService.Add(createModel);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(500, e.Message);
            }

            return RedirectToAction("Index");
        }

        // GET: Vechicle/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var vechicle = _vechicleService.GetEditView(id);

                ViewBag.Type = TypesHelpers.DropDownList(vechicle.Type);
                ViewBag.Categories = CategoryHelpers.DropDownList(vechicle.Categories);

                return View(vechicle);
            }
            catch
            {
                return HttpNotFound();
            }
        }

        // POST: Vechicle/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VachicleUpdateModel vechicleUpdate)
        {
            if (!ModelState.IsValid)
            {
                return View(vechicleUpdate);
            }

            try
            {
                _vechicleService.Update(id, vechicleUpdate);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(500, e.Message);
            }

            return RedirectToAction("Index");
        }

        // Get: Vechicle/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _vechicleService.Delete(id);
            }
            catch
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }
    }
}
