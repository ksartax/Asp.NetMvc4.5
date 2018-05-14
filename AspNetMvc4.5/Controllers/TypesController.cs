using AspNetMvc4._5.ModelViews;
using AspNetMvc4._5.Services;
using AspNetMvc4._5.Services.Interface;
using System;
using System.Web.Mvc;

namespace AspNetMvc4._5.Controllers
{
    public class TypesController : Controller
    {
        private readonly ITypesService _typesService = new TypesService();

        // GET: Types
        public ActionResult Index()
        {
            return View(_typesService.GetListView());
        }

        //Get: Type/Details/:id
        public ActionResult Details(int id)
        {
            try
            {
                return View(_typesService.GetView(id));
            }
            catch
            {
                return HttpNotFound();
            }
        }

        //Get: Type/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Post: Type/Create
        [HttpPost]
        public ActionResult Create(TypesCreateModel createModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createModel);
            }

            try
            {
                _typesService.Add(createModel);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(500, e.Message);
            }

            return RedirectToAction("Index");
        }

        //Get: Type/Edit/:id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                return View(_typesService.GetEditView(id));
            }
            catch 
            {
                return HttpNotFound();
            }
        }

        //Post: Type/Edit/:id
        [HttpPost]
        public ActionResult Edit(int id, TypesUpdateModel typesUpdate)
        {
            if (!ModelState.IsValid)
            {
                return View(typesUpdate);
            }

            try
            {
                _typesService.Update(id, typesUpdate);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(500, e.Message);
            }

            return RedirectToAction("Index");
        }

        //Get: Type/Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                _typesService.Delete(id);
            }
            catch
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }
    }
}