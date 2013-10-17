using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PcaSoundCloud.Shared;

namespace PcaSoundCloud.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ITrackService _service;

        public SearchController(ITrackService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult searchMusic(string searchString)
        {
            var searchResults = _service.Search(searchString);
            return Json(new {search = searchString}, JsonRequestBehavior.AllowGet);
        }
    }
}