using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompStore.Models.DAO;
using PagedList;

namespace CompStore.Controllers.DAOController
{
    public class ProductController : Controller
    {
        Entities entities = new Entities();
        DAOProduct DaoP = new DAOProduct();
        DAOCategory category = new DAOCategory();
        DAOSupplier sup = new DAOSupplier();

        // GET: Product
        public ActionResult Index(int? page)
        {
            var model = entities.Product.ToList();
            int pageNumber = page ?? 1;
            int pageSize = 10;
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(DaoP.GetProduct(id));
        }

        protected bool ViewDataSelectList(int pos_id)
        {
            var categoryes = category.GetAllCategoryes();
            ViewData["CategoryId"] = new SelectList(categoryes, "Id", "Name", pos_id);
            return categoryes.Count() > 0;
        }

        protected bool ViewDataSelectList1(int pos_id)
        {
            var supplier = sup.GetAllSupplier();
            ViewData["SupplierId"] = new SelectList(supplier, "Id", "Name", pos_id);
            return supplier.Count() > 0;
        }

        private void InitDynamicData() => ViewData["Category"] = category.GetAllCategoryes();
        private void InitDynamicData1() => ViewData["Supplier"] = sup.GetAllSupplier();


        // GET: Product/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Product product)
        {
            //Product pr = DaoP.GetProduct();
            if (DaoP.AddProduct(product))
                return RedirectToAction("Index");
            else
            {

                return View("Create");
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product pr = DaoP.GetProduct(id);
            if (!ViewDataSelectList(pr.Category.Id) && !ViewDataSelectList1(pr.Supplier.Id)) 
                return RedirectToAction("Index");
            return View(pr);

        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product contact)
        {

            if ((id > 0) && (contact != null) && (ModelState.IsValid))
            {
                DaoP.UpdateProduct(contact);
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
            return View("Delete", DaoP.GetProduct(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (id > 0 && ModelState.IsValid)
            {
                DaoP.DeleteProduct(id);
                return RedirectToAction("Index");
            }

            else
                return View();
        }
    }
}
