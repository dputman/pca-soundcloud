using System.Collections.Generic;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;
using RestSharp;

namespace PcaSoundCloud.Core
{
    public class TrackService : ITrackService
    {
        public IList<Track> Search(TrackCriteria criteria)
        {
            var client = new RestClient("https://api.soundcloud.com/");
            var request = new RestRequest("tracks.format", Method.GET);
            //TODO: Add an AUTH controller
            request.AddParameter("consumer_key", "apigee");
            request.AddParameter("filter", "all");
            request.AddParameter("limit", criteria.MaxResults);
            request.AddParameter("q", criteria.SearchText);

            var response = client.Execute<List<Track>>(request);

            return response.Data;
        }
    }
}