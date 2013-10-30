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
            TrackService trackService = new TrackService();

            var tracks = trackService.Search(new TrackCriteria{SearchText = "stuff", MaxResults = 5});

            Assert.That(tracks.Count, Is.EqualTo(5));
        }

    }
}
