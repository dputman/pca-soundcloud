using RestSharp;

namespace PcaSoundCloud.API
{
    public interface IMusicService
    {
        
        void SetApiKey(string apiKey);
        T CallMusicService<T>(RestRequest request) where T : new();
    }
}
