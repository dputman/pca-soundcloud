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

        public User GetUserByAccessToken(string accessToken)
        {
            var request = new RestRequest("me.json", Method.POST);
            User selectedUser = _music.CallMusicService<User>(request, accessToken);
            return selectedUser;
        }
    }
}