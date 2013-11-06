using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcaSoundCloud.Shared;
using PcaSoundCloud.Shared.Entities;
using RestSharp;

namespace PcaSoundCloud.API
{
	class TrackApi
	{
		 private readonly IMusicService _music;

	    public TrackApi(IMusicService music)
        {
	        _music = music;
        }

		private List<Track>getTracksBySearch(string search)
		{
			var request = new RestRequest("tracks.format", Method.GET);
					request.AddParameter("consumer_key", "apigee");
					request.AddParameter("q", search);

					return _music.CallMusicService<List<Track>>(request);
		}

		public Track getTrackByID(int trackID)
		{
			//https://api.soundcloud.com/tracks/291.json?consumer_key=apigee
			var request = new RestRequest("tracks/" + trackID.ToString() + ".format", Method.GET);
			request.AddParameter("consumer_key", "apigee");
			//request.AddParameter("q", search);

			return _music.CallMusicService<Track>(request);
		}

	}

}
