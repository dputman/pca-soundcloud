using System.Collections.Generic;
using PcaSoundCloud.Shared;

namespace PcaSoundCloud.Core.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int UserId);
    }
}
