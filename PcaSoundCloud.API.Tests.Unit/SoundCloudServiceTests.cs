using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using NUnit.Framework;
using PcaSoundCloud.Shared;
using RestSharp;
using Moq;

namespace PcaSoundCloud.API.Tests.Unit
{
    public class SoundCloudServiceTests
    {
        //Mock<RestClient> _mock = new Mock<RestClient>();
        //Mock<RestRequest> _moqRequest = new Mock<RestRequest>();

        [Test]
        public void Return_fake_data_without_calling_soundcloud()
        {
            IMusicService music = new MusicService();
            SoundCloudService service = new SoundCloudService(music);
        }

        [Test]
        public void GetUserShouldNotBeNull()
        {
            MusicService _mockMusicService = new Mock<MusicService>();
            SoundCloudService service = new SoundCloudService(_mockMusicService);
            int UID = 183;

            User user = service.GetUserByID(UID);
            Assert.That(user, Is.Not.Null);
        }

        [Test]
        public void GetUserShouldBeOfTypeUser()
        {
            IMusicService music = new MusicService();
            SoundCloudService service = new SoundCloudService(music);
            int UID = 183;

            User user = service.GetUserByID(UID);
            Assert.That(user, Is.TypeOf<User>());
        }

        [Test]
        public void GetUserByIdShouldReturnTheSelectedUser()
        {
            IMusicService music = new MusicService();
            SoundCloudService service = new SoundCloudService(music);
            int UID = 183;

            User user = service.GetUserByID(UID);
            Assert.That(user.id, Is.EqualTo(UID));
        }

        [Test]
        public void GetListOfUsersShouldNotBeNull()
        {
            IMusicService music = new MusicService();
            SoundCloudService service = new SoundCloudService(music);

            List<User> user = service.GetListOfUsers("Jimmy");
            Assert.That(user, Is.Not.Null);
        }

        [Test]
        public void GetListOfUsersShouldReturListOfUsers()
        {
            IMusicService music = new MusicService();
            SoundCloudService service = new SoundCloudService(music);

            List<User> user = service.GetListOfUsers("Jimmy");
            Assert.That(user, Is.TypeOf<List<User>>());
        }
    }
}