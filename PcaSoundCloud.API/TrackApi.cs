using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcaSoundCloud.API;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;
using RestSharp;

namespace PcaSoundCloud.API
{
    public interface ITrackApi
    {
        IList<Track> Search(TrackCriteria criteria);
        IList<Track> GetFavoriteTracksByUserId(int userId);
    }


    public class TrackApi : ITrackApi
    {
        private readonly IMusicService _musicService;

        public TrackApi(IMusicService musicService)
        {
            _musicService = musicService;
        }

        public IList<Track> Search(TrackCriteria criteria)
        {
            var request = new RestRequest("tracks.format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            request.AddParameter("filter", "all");
            request.AddParameter("limit", criteria.MaxResults);
            request.AddParameter("q", criteria.SearchText);

            var tracks = _musicService.CallMusicService<List<Track>>(request);

            return tracks;
        }

	    public IList<Track> GetFavoriteTracksByUserId(int userId)
	    {
				var request = new RestRequest("favorites.format", Method.GET);
				request.AddParameter("consumer_key", "apigee");
				var tracks = _musicService.CallMusicService<List<Track>>(request);
                return tracks;
			}

    }
}
    
