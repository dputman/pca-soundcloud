using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PcaSoundCloud.Shared;
using RestSharp;

namespace PcaSoundCloud.API
{
    public interface ISoundCloudService
    {
    }

    public class SoundCloudService : ISoundCloudService
    {
	    private readonly IMusicService _music;

	    public SoundCloudService(IMusicService music)
        {
	        _music = music;
        }

			public User GetUser(string searchString)
	    {
				var request = new RestRequest("users.format", Method.GET);
				request.AddParameter("consumer_key", "apigee");
				request.AddParameter("q", searchString);

		    return _music.CallMusicService<User>(request);
	    }

	    public List<User> GetCollectionOfUsers(string searchString)
			{
				var request = new RestRequest("users.format", Method.GET);
				request.AddParameter("consumer_key", "apigee");
				request.AddParameter("q", searchString);

				return _music.CallMusicService<List<User>>(request);
	    }
    }
}