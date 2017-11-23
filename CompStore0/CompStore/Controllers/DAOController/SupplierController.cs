using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompStore.Models.DAO;

namespace CompStore.Controllers.DAOController
{
    public class SupplierController : Controller
    {
        Entities entities = new Entities();
        DAOSupplier s = new DAOSupplier();

        public ActionResult Index(int? page)
        {
            var model = entities.Supplier.ToList();
            int pageNumber = page ?? 1;
            int pageSize = 10;
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(s.GetSupplier(id));
        }

         // GET: Product/Create
        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Supplier supplier)
        {
            if (s.AddSupplier(supplier))
                return RedirectToAction("Index");
            else
            {

                return View("Create");
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
           
                return RedirectToAction("Index");
           

        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Supplier contact)
        {

            if ((id > 0) && (contact != null) && (ModelState.IsValid))
            {
                s.UpdateSupplier(contact);
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
            return View("Delete", s.GetSupplier(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (id > 0 && ModelState.IsValid)
            {
                s.DeleteSupplier(id);
                return RedirectToAction("Index");
            }

            else
                return View();
        }
    }
}
