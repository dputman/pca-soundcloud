using System.Collections.Generic;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;

namespace PcaSoundCloud.Core
{
    public class TrackService : ITrackService
    {
        public IList<Track> Search(TrackCriteria criteria)
        {
            return new List<Track>();
        }
    }
}