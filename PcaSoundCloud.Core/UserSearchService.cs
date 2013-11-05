using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcaSoundCloud.API;
using PcaSoundCloud.Shared;

namespace PcaSoundCloud.Core
{
    public class UserSearchService : IUserSearchService
    {
        private IUserApi _userApi;
        
        public UserSearchService(IUserApi userApi)
        {
            _userApi = userApi;
        }

        public List<User> GetListOfUsers(string searchString)
        {
            return _userApi.GetListOfUsers(searchString);
        }
    }
}
