using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcaSoundCloud.Shared;

namespace PcaSoundCloud.Core
{
    public interface IUserSearchService
    {
        List<User> GetListOfUsers(string searchString);
    }
}
