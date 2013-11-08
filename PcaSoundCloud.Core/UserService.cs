using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcaSoundCloud.API;
using PcaSoundCloud.Core.Interfaces;
using PcaSoundCloud.Shared;

namespace PcaSoundCloud.Core
{
    public class UserService : IUserService
    {
        private IUserApi _userApi;
        
        public UserService(IUserApi userApi)
        {
            _userApi = userApi;
        }

				public User GetUserById(int UserId)
				{
					return _userApi.GetUserById(UserId);
				}
    }
}
