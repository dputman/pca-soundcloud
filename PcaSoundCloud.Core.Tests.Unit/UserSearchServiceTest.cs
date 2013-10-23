using System;
using Moq;
using NUnit.Framework;
using PcaSoundCloud.API;
using User = PcaSoundCloud.Shared.User;

namespace PcaSoundCloud.Core.Tests.Unit
{
	class UserSearchServiceTest
	{
		private UserSearchService _UserSearchService;
		Mock<NSoundCloud> _mockAPIInterface;


		[SetUp]
		public void Setup()
		{
			_mockAPIInterface = new Mock<NSoundCloud>();
			_UserSearchService = new UserSearchService(_mockAPIInterface.Object);
		}

		[Test]
		public void SearchForUsersShouldReturnAListOfUsers()
		{
			//var post = new Post() { Id = 1 };
			//_mockRepository.Setup(x => x.Add(post)).Verifiable();
			//_controller.Create(post);
			//_mockRepository.Verify();
			User actual = _UserSearchService.SearchForUsers("blahblahblah");
			Assert.That(actual, Is.AssignableTo<User>());
		}

	}
}
