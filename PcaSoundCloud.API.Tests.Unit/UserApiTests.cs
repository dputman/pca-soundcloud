using System;
using System.Collections.Generic;
using NUnit.Framework;
using PcaSoundCloud.Shared;
using RestSharp;
using Moq;

namespace PcaSoundCloud.API.Tests.Unit
{
    public class UserApiTests
    {
        private Mock<IMusicService> _mockMusicService;
        private UserApi _userApi;

        [SetUp]
        public void SetUp()
        {
            _mockMusicService = new Mock<IMusicService>();
            _userApi = new UserApi(_mockMusicService.Object);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void IfUserDoesntExistExpectAnException()
        {
            _mockMusicService.Setup(sut => sut.CallMusicService<User>(It.IsAny<RestRequest>())).Returns((User)null);

            User user = _userApi.GetUserById(-1);
        }

        [Test]
        public void GetUserShouldBeOfTypeUser()
        {
            _mockMusicService.Setup(sut => sut.CallMusicService<User>(It.IsAny<RestRequest>())).Returns(new User());

            User user = _userApi.GetUserById(111);
            Assert.That(user, Is.TypeOf<User>());
        }

        [Test]
        public void GetListOfUsersShouldReturnListOfUsers()
        {
            _mockMusicService.Setup(sut => sut.CallMusicService<List<User>>(It.IsAny<RestRequest>())).Returns(new List<User>());

            var user = _userApi.GetListOfUsers("futurefocus");
            Assert.That(user, Is.TypeOf<List<User>>());
        }

        [Test]
        public void GetListOfUsersYouAreFollowing()
        {
            var users = _userApi.GetListOfFollowedUsers(62262046);
            Assert.That(users, Is.TypeOf<List<User>>());
        }

        [Test]
        public void GetListOfUsersIAmFollowing()
        {
            var users = _userApi.GetListOfMyFollowedUsers();

            Assert.That(users, Is.TypeOf<List<User>>());
        }

        [Test]
        public void FollowAGivenUser()
        {
            Random random = new Random();
            var userId = random.Next(10000, 99999999);
            var user = _userApi.FollowUser(userId);
            Assert.That(user.id, Is.EqualTo(userId));
        }
    }
}