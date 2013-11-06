using RestSharp;

namespace PcaSoundCloud.API
{
    //soundcloud username: Pca-SoundCloud-User
    //soundcloud password: agileLIVE!
    //app name: PcaSoundCloudApp
    //client id: c49610f852b5967ec6df11d4d53d71b4
    //client secret: 7707d3433572cc5591fe295b85b3e385
    //https://soundcloud.com/connect
    //https://api.soundcloud.com/oauth2/token
    public class MusicService : IMusicService
    {
        private const string ClientId = "c49610f852b5967ec6df11d4d53d71b4";
        private const string ClientSecret = "7707d3433572cc5591fe295b85b3e385";
        private const string AppName = "PcaSoundCloudApp";
        private const string _testToken = "1-55455-62452880-fe694f0d2b2f7fa";
        private const string ApiUrl = "https://api.soundcloud.com";
        private RestClient RestClient;

        public MusicService()
        {
						RestClient = new RestClient();
            RestClient.BaseUrl = ApiUrl;
        }

        public static string TestToken
        {
            get { return _testToken; }
        }

        //https://soundcloud.com/connect
        //https://api.soundcloud.com/oauth2/token
        public string GetClientId()
        {
            return ClientId;
        }

        public T CallMusicService<T>(RestRequest request) where T : new()
        {
            request.AddParameter("oath_token", TestToken);
            var response = RestClient.Execute<T>(request);
            return response.Data;
        }

        public T CallMusicService<T>(RestRequest request, string token) where T : new()
        {
            request.AddParameter("oauth_token", token);
            var response = RestClient.Execute<T>(request);
            return response.Data;
        }

        public void SetApiKey(string apiKey)
        {
            throw new System.NotImplementedException();
        }
    }
}
