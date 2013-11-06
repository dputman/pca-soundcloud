using RestSharp;

namespace PcaSoundCloud.API
{
    public interface IMusicService
    {
        void SetApiKey(string apiKey);
        T CallMusicService<T>(RestRequest request) where T : new();
        T CallMusicService<T>(RestRequest request, string accessToken) where T : new();
    }


    public class FakeMusicService : IMusicService
    {
        public void SetApiKey(string apiKey)
        {
            //thanks. I have an API key now.
        }

        public T CallMusicService<T>(RestRequest request) where T : new()
        {
            throw new System.NotImplementedException();
        }

        public T CallMusicService<T>(RestRequest request, string accessToken) where T : new()
        {
            //this would call the API and return data of type T.
            return new T();
        }
    }
}
