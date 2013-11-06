using System.Collections.Generic;
using PcaSoundCloud.Shared.Entities;

namespace PcaSoundCloud.Shared
{
    public interface ITrackService
    {
        IList<Track> Search(TrackCriteria criteria);
	    IList<Track> GetFavoriteTracksByUserId(int userId);
    }

    public class TrackCriteria
    {
        public string SearchText { get; set; }
        public int MaxResults { get; set; }

    }
}