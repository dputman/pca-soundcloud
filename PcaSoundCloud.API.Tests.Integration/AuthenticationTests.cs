using System;
using NUnit.Framework;
using RestSharp;
using Should;

namespace PcaSoundCloud.API.Tests.Integration
{
    public class AuthenticationTests
    {
        private const string ClientId = "c49610f852b5967ec6df11d4d53d71b4";
        private const string ClientSecret = "7707d3433572cc5591fe295b85b3e385";
        private const string AppName = "PcaSoundCloudApp";


        private const string TestToken = "1-55455-62452880-fe694f0d2b2f7fa";


        [Test]
        public void ApiShouldConnect()
        {
            var sut = new NSoundCloud();
            //var actual = sut.Authentication();
            //_sut.GetClientId().ShouldReturn("873cc698f936328f3b702353621a5e93");
        }

        [Test]
        public void Spike()
        {
            var client = new RestClient("https://api.soundcloud.com/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("me.json", Method.GET);
            request.AddParameter("oauth_token", TestToken);

            var response = client.Execute<Rootobject>(request);
            //response.Data.id.Should().Be(62452880);
            var content = response.Content; // raw content as string
            Console.WriteLine(content);



        }
    }

    public class Rootobject
    {
        public int id { get; set; }
        public string kind { get; set; }
        public string permalink { get; set; }
        public string username { get; set; }
        public string uri { get; set; }
        public string permalink_url { get; set; }
        public string avatar_url { get; set; }
        public object country { get; set; }
        public string full_name { get; set; }
        public object description { get; set; }
        public object city { get; set; }
        public object discogs_name { get; set; }
        public object myspace_name { get; set; }
        public object website { get; set; }
        public object website_title { get; set; }
        public bool online { get; set; }
        public int track_count { get; set; }
        public int playlist_count { get; set; }
        public string plan { get; set; }
        public int public_favorites_count { get; set; }
        public int followers_count { get; set; }
        public int followings_count { get; set; }
        public object[] subscriptions { get; set; }
        public int upload_seconds_left { get; set; }
        public Quota quota { get; set; }
        public int private_tracks_count { get; set; }
        public int private_playlists_count { get; set; }
        public bool primary_email_confirmed { get; set; }
    }

    public class Quota
    {
        public bool unlimited_upload_quota { get; set; }
        public int upload_seconds_used { get; set; }
        public int upload_seconds_left { get; set; }
    }


}
