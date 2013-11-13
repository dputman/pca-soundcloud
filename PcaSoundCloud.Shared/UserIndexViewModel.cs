using System.Collections.Generic;
using PcaSoundCloud.Shared.Entities;

namespace PcaSoundCloud.Shared
{
    public class UserIndexViewModel
    {
        public UserIndexViewModel()
        {
            Favorites = new List<Track>();
        }

        public User User { get; set; }

        public IList<Track> Favorites { get; set; }
    }
}