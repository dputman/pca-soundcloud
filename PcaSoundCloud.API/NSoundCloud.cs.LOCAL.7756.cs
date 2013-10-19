using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
    public class NSoundCloud : IMusicService
    {
        private const string ClientId = "c49610f852b5967ec6df11d4d53d71b4";
        private const string ClientSecret = "7707d3433572cc5591fe295b85b3e385";
        private const string AppName = "PcaSoundCloudApp";
        private const string _testToken = "1-55455-62452880-fe694f0d2b2f7fa";
        private const string ApiUrl = "https://api.soundcloud.com";
        private RestClient RestClient;

        public NSoundCloud(RestClient restclient)
        {
            this.RestClient = restclient;
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

        public object CallMusicService<T>(RestRequest request)
        {
            request.AddParameter("oath_token", TestToken);
            var response =
            RestClient.Execute(request);
            return response;
        }
    }
}
