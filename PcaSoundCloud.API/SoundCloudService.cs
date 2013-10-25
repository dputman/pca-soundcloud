using System;
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

        public string GetToken(string id, string secret)
        {
            return id;
        }
        public User GetUser(string searchString)
        {
            var request = new RestRequest("users.format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            request.AddParameter("q", searchString);

            return _music.CallMusicService<User>(request);
        }


        //SPIKE
        public User GetMe(string token)
        {
            var client = new RestClient("https://api.soundcloud.com/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("me.json", Method.GET);
            request.AddParameter("oauth_token", token);

            var response = client.Execute<User>(request);

            return response.Data;
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