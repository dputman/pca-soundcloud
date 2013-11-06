using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PcaSoundCloud.Shared;
using RestSharp;

namespace PcaSoundCloud.API
{
    public interface IUserApi
    {
        User GetUserById(int userId);
        List<User> GetListOfUsers(string searchString);
    }

    public class UserApi : IUserApi
    {
	    private readonly IMusicService _music;

	    public UserApi(IMusicService music)
        {
	        _music = music;
        }

        public User GetUserById(int userId)
        {
            var request = new RestRequest("users/" + userId + ".format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            var selectedUser = _music.CallMusicService<User>(request);

            if (selectedUser == null)
            {
                throw new Exception("No User Found For The Specified ID");
            }
            return selectedUser;
        }

        public List<User> GetListOfUsers(string searchString)
        {
            var request = new RestRequest("users.format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            request.AddParameter("q", searchString);

            return _music.CallMusicService<List<User>>(request);
        }

        public User GetUserByAccessToken(string access_token)
        {
            var request = new RestRequest("me.json", Method.GET);
            User selectedUser = _music.CallMusicService<User>(request, access_token);
            return selectedUser;
        }
    }
}