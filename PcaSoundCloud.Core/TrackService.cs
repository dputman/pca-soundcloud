using System;
using System.Collections.Generic;
using PcaSoundCloud.API;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;
using RestSharp;

namespace PcaSoundCloud.Core
{
    public class TrackService : ITrackService
    {
        private readonly ITrackApi _trackApi;

        public TrackService(ITrackApi trackApi)
        {
            _trackApi = trackApi;
        }

        public IList<Track> Search(TrackCriteria criteria)
        {
            return _trackApi.Search(criteria);
        }

	    public IList<Track> GetFavoriteTracksByUserId(int userId)
	    {
	        return _trackApi.GetFavoriteTracksByUserId(userId);
	    }
    }
}