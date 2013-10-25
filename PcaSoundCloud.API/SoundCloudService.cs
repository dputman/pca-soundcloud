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
        public User GetUserByID(int UserID)
        {
            var request = new RestRequest("users/" + UserID + ".format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            User SelectedUser = _music.CallMusicService<User>(request);  //<error>404-nasldflaksdf</error>

            if (SelectedUser == null)
            {
                throw new Exception("No User Found For The Specified ID");
            }
            return SelectedUser;
        }

        //RETURNS LIST OF USERS VIA A SEARCH STRING
        public List<User> GetListOfUsers(string SearchString)
        {
            var request = new RestRequest("users.format", Method.GET);
            request.AddParameter("consumer_key", "apigee");
            request.AddParameter("q", SearchString);

            return _music.CallMusicService<List<User>>(request);
        }
    }
}