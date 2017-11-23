using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompStore.Models.DAO;

namespace CompStore.Controllers.DAOController
{
    public class CategoryController : Controller
    {
        Entities entities = new Entities();
        DAOCategory daocat = new DAOCategory();

        // GET: Category
        public ActionResult Index(int? page)
        {
            Entities _db = new Entities();

            var model = _db.Category.ToList();
            int pageNumber = page ?? 1;
            int pageSize = 10;
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View(daocat.GetCategory(id));
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Category category)
        {
            if (daocat.AddCategory(category))
                return RedirectToAction("Index");
            else
            {

                return View("Create");
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category c = daocat.GetCategory(id);
           
                return RedirectToAction("Index");
          
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category contact)
        {


            if ((id > 0) && (contact != null) && (ModelState.IsValid))
            {
                daocat.UpdateCategory(contact);
                return RedirectToAction("Index");
            }
            else
            {

                return View("Edit");
            }

        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View("Delete", daocat.GetCategory(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            if (id > 0 && ModelState.IsValid)
            {
                daocat.DeleteCategory(id);
                return RedirectToAction("Index");
            }

            else
                return View();
        }
    }
    }

