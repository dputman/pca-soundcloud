using Castle.MicroKernel;
using PcaSoundCloud.API;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using User = PcaSoundCloud.Shared.User;

namespace PcaSoundCloud.Core
{
	public class UserSearchService
	{
	//	NSoundCloud SoundCloudAPI = new NSoundCloud();
		//private string strUserSearch = "";
		//private var request = new RestRequest("me.json",Method.GET);
		//private string strSearchQuery;
		private NSoundCloud _nSoundCloud;

		public UserSearchService(NSoundCloud soundCloud)
		{
			_nSoundCloud = soundCloud;
		}

		public User SearchForUsers(string strSearchQuery)
		{
			var request = new RestRequest("user.json", Method.GET);
			//send request to those guys

			//return collection of users
			return new User();
		}

	}
}
