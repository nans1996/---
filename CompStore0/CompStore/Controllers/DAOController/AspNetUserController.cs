using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompStore.Models.DAO;

namespace CompStore.Controllers.DAOController
{
    public class AspNetUserController : Controller
    {
        DAOAspNetUser daouser = new DAOAspNetUser();
        DAORole daorole = new DAORole();

        // GET: AspNetUser
        public ActionResult Index()
        {
            return View(daouser.GetAllUsers());
        }

        // GET: AspNetUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: AspNetUser/Edit/5
        public ActionResult Edit(string id)
        {
            AspNetUsers asp = daouser.GetUser(id);
            return View(asp);
        }

        // POST: AspNetUser/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, AspNetUsers contact)
        {
            if ((id != null) && (contact != null) && (ModelState.IsValid))
            {
                daouser.UpdateUser(contact);
                return RedirectToAction("Index");
            }
            else
            {

                return View("Edit");
            }
        }

        // GET: AspNetUser/Delete/5
        public ActionResult Delete(string id)
        {
            return View("Delete", daouser.GetUser(id));
        }

        // POST: AspNetUser/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (id != null && ModelState.IsValid)
            {
                daouser.DeleteUser(id);
                return RedirectToAction("Index");
            }

            else
                return View();
        }

        public ActionResult ChangeRole(string id)
        {

            var User = new Entities().AspNetUsers.Where(n => n.Id.Equals(id)).FirstOrDefault();
            return View(User);
        }

        // POST: AspNetUser/Edit/5
        [HttpPost]
        public ActionResult ChangeRole(string id, AspNetRoles contact)
        {
            daorole.UpdateRoles(id, contact);
            return RedirectToAction("Index");
        }


    }
}
