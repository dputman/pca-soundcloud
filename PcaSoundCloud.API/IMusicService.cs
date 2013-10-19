using System.Collections.Generic;
using RestSharp;

namespace PcaSoundCloud.API
{
    internal interface IMusicService
    {
        object CallMusicService<T>(RestRequest request);
    }
}
