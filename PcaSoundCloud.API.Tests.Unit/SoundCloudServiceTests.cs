using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using NUnit.Framework;
using PcaSoundCloud.Shared;
using RestSharp;

namespace PcaSoundCloud.API.Tests.Unit
{
    public class SoundCloudServiceTests
    {

        [Test]
        public void Return_fake_data_without_calling_soundcloud()
        {
            IMusicService music = new MusicService();
            
            SoundCloudService service = new SoundCloudService(music);

          
        }

	    [Test]
	    public void GetUserShouldNotBeNull()
	    {
				IMusicService music = new MusicService();
				SoundCloudService service = new SoundCloudService(music);
				//does this need a user name or id...or what?

		    User user = service.GetUser("Jimmy");
				Assert.That(user, Is.Not.Null);
	    }

			[Test]
			public void GetUserShouldBeOfTypeUser()
			{
				IMusicService music = new MusicService();
				SoundCloudService service = new SoundCloudService(music);
				//does this need a user name or id...or what?

				User user = service.GetUser("Jimmy");
				Assert.That(user, Is.TypeOf<User>());
			}

			[Test]
			public void GetCollectionOfUsersShouldNotBeNull()
			{
				IMusicService music = new MusicService();
				SoundCloudService service = new SoundCloudService(music);
				//does this need a user name or id...or what?

				List<User> user = service.GetCollectionOfUsers("Jimmy");
				Assert.That(user, Is.Not.Null);
			}

	    [Test]
	    public void GetCollectionOfUsersShouldReturnCollectionOfUsers()
			{
				IMusicService music = new MusicService();
				SoundCloudService service = new SoundCloudService(music);
				//does this need a user name or id...or what?

				List<User> user = service.GetCollectionOfUsers("Jimmy");
				Assert.That(user, Is.TypeOf<List<User>>());
	    }
    }
}