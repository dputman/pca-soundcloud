using RestSharp;

namespace PcaSoundCloud.API
{
    internal interface IMusicService
    {
        T CallMusicService<T>(RestRequest request);
        void SetApiKey(string apiKey);
    }
}
