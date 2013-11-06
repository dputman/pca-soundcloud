using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PcaSoundCloud.Shared.Entities;

namespace PcaSoundCloud.Web.Models
{
	public class UserModel
	{
		 public IEnumerable<Track> Favorites { get; set; } 
	}
}