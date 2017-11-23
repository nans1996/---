using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompStore.Models.DAO;
using PagedList;

namespace CompStore.Controllers.DAOController
{
    public class SellingController : Controller
    {
        Entities entities = new Entities();
        DAOSelling s = new DAOSelling();


        // GET: Product
        public ActionResult Index(int? page)
        {
            var model = entities.Selling.ToList();
            int pageNumber = page ?? 1;
            int pageSize = 10;
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(s.GetSelling(id));
        }

        //protected bool ViewDataSelectList(int pos_id)
        //{
        //    var categoryes = category.GetAllCategoryes();
        //    ViewData["CategoryId"] = new SelectList(categoryes, "Id", "Name", pos_id);
        //    return categoryes.Count() > 0;
        //}

        //private void InitDynamicData() => ViewData["Category"] = category.GetAllCategoryes();


        // GET: Product/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Selling selling)
        {
            if (s.AddSelling(selling))
                return RedirectToAction("Index");
            else
            {

                return View("Create");
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Selling pr = s.GetSelling(id);
            //if (!ViewDataSelectList(pr.Category.Id))
            
            return View(pr);

        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Selling contact)
        {

            if ((id > 0) && (contact != null) && (ModelState.IsValid))
            {
                s.UpdateSelling(contact);
                return RedirectToAction("Index");
            }
            else
            {

                return View("Edit");
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View("Delete", s.GetSelling(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (id > 0 && ModelState.IsValid)
            {
                s.DeleteSelling(id);
                return RedirectToAction("Index");
            }

            else
                return View();
        }
    }
}
