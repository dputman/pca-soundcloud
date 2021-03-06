﻿using System.Collections.Generic;
using System.Web.Mvc;
using PcaSoundCloud.Core.Interfaces;
using PcaSoundCloud.Shared;

namespace PcaSoundCloud.Web.Controllers
{
    public class UserSearchController : Controller
    {
        private readonly IUserSearchService _service;

        public UserSearchController(IUserSearchService service)
        {
            _service = service;
        }

        //
        // GET: /UserSearch/

        public ActionResult Index(string searchQuery)
        {
            var users = _service.GetListOfUsers(searchQuery) ?? new List<User>();
            //Response.Write(JsonConvert.SerializeObject(users, Formatting.Indented));
            return View(users);
        }

        //
        // GET: /UserSearch/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /UserSearch/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserSearch/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UserSearch/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /UserSearch/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UserSearch/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /UserSearch/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
