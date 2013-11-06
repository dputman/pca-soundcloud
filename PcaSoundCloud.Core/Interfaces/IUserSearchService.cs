using System.Collections.Generic;
using PcaSoundCloud.Shared;

namespace PcaSoundCloud.Core.Interfaces
{
    public interface IUserSearchService
    {
        List<User> GetListOfUsers(string searchString);
    }
}
