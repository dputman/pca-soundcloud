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
        public JsonResult SearchMusic(string userName)
        {
            var results = _service.Search(new TrackCriteria { User = userName });
            results[0].Description +=  " and also " + userName;
            return Json(new { tracks = results }, JsonRequestBehavior.AllowGet);
        }
    }
}