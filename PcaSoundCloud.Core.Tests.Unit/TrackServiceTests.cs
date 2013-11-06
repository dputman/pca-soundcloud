using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;

namespace PcaSoundCloud.Core.Tests.Unit
{
    class TrackServiceTests
    {
        [Test]
        public void CanUseSearchService()
        {
            var trackService = new TrackService();
            var tracks = trackService.Search(new TrackCriteria{SearchText = "stuff", MaxResults = 5});
            Assert.That(tracks.Count, Is.EqualTo(5));
        }

	    [Test]
	    public void CanSearchByUserNameForFavoriteTracks()
	    {
		    var trackService = new TrackService();
		    var favorites = trackService.GetFavoriteTracksByUserId(183);
				Assert.That(favorites.Any());
	    }

			[Test]
			public void WhenBadUserNameNoResultsFound()
			{
				var trackService = new TrackService();
				var favorites = trackService.GetFavoriteTracksByUserId(-1);
				Assert.That(favorites.Count(), Is.EqualTo(0));
			}

    }
}
