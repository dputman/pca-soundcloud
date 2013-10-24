using System.Collections.Generic;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;

namespace PcaSoundCloud.Core
{
    public class TrackService : ITrackService
    {
        public IList<Track> Search(TrackCriteria criteria)
        {
            var track = new Track
                {
                    Id = "1",
                    Title = "a track name!",
                    Description = "It's a description!!"
                };
            return new List<Track>{track};
        }
    }
}