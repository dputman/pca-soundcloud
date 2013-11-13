using System.Web.Mvc;
using PcaSoundCloud.Core.Interfaces;
using PcaSoundCloud.Shared;

namespace PcaSoundCloud.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly ITrackService _trackService;

        public UserController(IUserService service, ITrackService trackService)
        {
            _service = service;
            _trackService = trackService;
        }

        public ActionResult Index(int id)
        {
            var userModel = new UserIndexViewModel
            {
                User = _service.GetUserById(id),
                Favorites = _trackService.GetFavoriteTracksByUserId(id)
            };
            return View(userModel);
        }
    }
}