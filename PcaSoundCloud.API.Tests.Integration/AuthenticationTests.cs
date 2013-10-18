using System;
using NUnit.Framework;
using PcaSoundCloud.Shared;
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

            var response = client.Execute<User>(request);
            Assert.That(response.Data.id, Is.EqualTo(62452880));
            //response.Data.Id.Should().Be(62452880);
            var content = response.Content; // raw content as string
            Console.WriteLine(content);



        }
    }
}
