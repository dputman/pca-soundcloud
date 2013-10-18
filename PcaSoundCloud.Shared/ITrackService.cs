using System.Collections;
using System.Collections.Generic;

namespace PcaSoundCloud.Shared
{
    public interface ITrackService
    {
        IList<string> Search(string searchString);
    }
}