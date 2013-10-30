using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;
using RestSharp;

namespace PcaSoundCloud.API.Tests.Unit
{
	class TrackApiTests
	{

		private Mock<IMusicService> _mockMusicService;
		private SoundCloudService _service;

		[SetUp]
		public void SetUp()
		{
			_mockMusicService = new Mock<IMusicService>();
			_service = new SoundCloudService(_mockMusicService.Object);
		}


		[Test]
		public void GetListOfTracksShouldReturnListOfTracks()
		{
			_mockMusicService.Setup(sut => sut.CallMusicService<List<Track>>(It.IsAny<RestRequest>())).Returns(new List<Track>());

			var track= _service.GetListOfTracks("futurefocus");
			Assert.That(track, Is.TypeOf<List<Track>>());
		}

		[Test]
		[ExpectedException(typeof(Exception))]
		public void IfTrackDoesntExistExpectAnException()
		{
			_mockMusicService.Setup(sut => sut.CallMusicService<Track>(It.IsAny<RestRequest>())).Returns((Track)null);

			Track track = _service.getTrackByID(-1);
		}




	//	private Track listOfTracks;

	}
}
