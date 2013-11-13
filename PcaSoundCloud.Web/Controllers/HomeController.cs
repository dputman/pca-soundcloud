using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using PcaSoundCloud.API;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;
using Ploeh.AutoFixture;

namespace PcaSoundCloud.Web.Controllers
{
    public class HomeController : DefaultController
    {
        //
        // GET: /User/
        private ITrackService _trackService;
        private IUserApi _userApi;

        public HomeController(ITrackService trackService, IUserApi userApi)
        {
            _trackService = trackService;
            _userApi = userApi;
        }

        public ActionResult Index(string access_token, string scope)
        {
            this.HttpContext.Session.Add("token", access_token);
            var _service = new UserApi(new MusicService());
            var me = _service.GetUserByAccessToken(access_token);
            this.HttpContext.Session.Add("username", me.username);

            var fixture = new Fixture();
            var tracks = fixture.CreateMany<Track>(20);
            var vm = new IndexViewModel {User = me, Tracks = tracks.ToList()};
            return View(vm);
        }

        public List<Track> GetPopularTracks(List<int> userIds)
        {
            var tracks = new List<Track>();
            foreach (var userId in userIds)
            {
                 tracks.AddRange(_trackService.GetFavoriteTracksByUserId(userId));    
            }
            return tracks;
        }
    }


    public class IndexViewModel
    {
        public User User { get; set; }
        public IList<Track> Tracks { get; set; }
    }
}
