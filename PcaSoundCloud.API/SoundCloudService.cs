using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

        //RETURNS USER BY A SPECIFIED ID
        public User GetUserByID(int userID)
        {
            var request = new RestRequest("users/" + userID + ".format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            User SelectedUser = _music.CallMusicService<User>(request);

            if (SelectedUser == null)
            {
                throw new Exception("No User Found For The Specified ID");
            }
            return SelectedUser;
        }

        //RETURNS LIST OF USERS VIA A SEARCH STRING
        public List<User> GetListOfUsers(string searchString)
        {
            var request = new RestRequest("users.format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            request.AddParameter("q", searchString);

            return _music.CallMusicService<List<User>>(request);
        }

        //RETURNS LIST OF USERS THAT A USER IS FOLLOWING
        public List<User> GetListOfFollowedUsers(int userId)
        {
            var client = new RestClient("https://api.soundcloud.com/users/" + userId + "/");
            const string testToken = "b45b1aa10f1ac2941910a7f0d10f8e28";
            var request = new RestRequest("followings.format", Method.GET);
            request.AddParameter("client_id", testToken);
            var response = client.Execute<List<User>>(request);

            return response.Data;
        }

        public List<User> GetListOfMyFollowedUsers()
        {
            var client = new RestClient("https://api.soundcloud.com/me/");
            var request = new RestRequest("followings.format", Method.GET);
            const string testToken = "1-55455-62452880-fe694f0d2b2f7fa";
            request.AddParameter("oauth_token", testToken);
            var response = client.Execute<List<User>>(request);            

            return response.Data;
        }

        public User FollowUser(int userId)
        {
            var client = new RestClient("https://api.soundcloud.com/me/followings/");
            var request = new RestRequest(userId + ".format", Method.PUT);
            const string testToken = "1-55455-62452880-fe694f0d2b2f7fa";
            request.AddParameter("oauth_token", testToken);           
            var response = client.Execute<User>(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Data.id);

            return response.Data;
        }
    }
}