using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompStore.Models.DAO;
using PagedList;

namespace CompStore.Controllers
{
    public class UserController : Controller
    {
        Entities entities = new Entities();
        DAOUser user = new DAOUser();
        DAOrole role = new DAOrole();
        // GET: User

   

    public ActionResult Index(int? page)
        {  
              
       var model = entities.User.ToList();
            int pageNumber = page ?? 1;
            int pageSize = 10;
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View(user.GetUser(id));
        }

        protected bool ViewDataSelectList(string pos_id)
        {
            var roles = role.GetAllRole();
            ViewData["RoleId"] = new SelectList(roles, "Id", "Name", pos_id);
            return roles.Count() > 0;
        }

        private void InitDynamicData() => ViewData["AspNetRoles"] = role.GetAllRole();




        // [Authorize(Roles = "Manadger")]
        // GET: User/Create
        public ActionResult Create()
        {
            
                return RedirectToAction("Index");
            
        }

        [HttpPost]
       // [Authorize(Roles = "Manadger")]
        public ActionResult Create([Bind(Exclude = "Id")] User users)
        {
            if (user.AddUser(users))
                return RedirectToAction("Index");
            else
            {
               
                return View("Create");
            }
        }
        //[Authorize(Roles = "Manadger")]
        // GET: User/Edit/5
        public ActionResult Edit(int Id)
        {
            User us = user.GetUser(Id);
            if (!ViewDataSelectList(us.AspNetRoles.Id))
                return RedirectToAction("Index");
            return View(us);

        }

        [HttpPost]
        //[Authorize(Roles = "Manadger")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, User contact)
        {
            

            if ((id > 0) && (contact != null) && (ModelState.IsValid))
            {
                user.UpdateUser(contact);
                return RedirectToAction("Index");
            }
            else
            {
                
                return View("Edit");
            }

        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View("Delete", user.GetUser(id));
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (id > 0 && ModelState.IsValid)
            {
                user.DeleteUser(id);
                return RedirectToAction("Index");
            }

            else
                return View();
            }
        }
    }

