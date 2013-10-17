using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PcaSoundCloud.API.Tests.Integration
{
    public class AuthenticationTests
    {  
        
        [Test]
        public void ApiShouldConnect()
        {
            var sut = new NSoundCloud();
            //var actual = sut.Authentication();


            //_sut.GetClientId().ShouldReturn("873cc698f936328f3b702353621a5e93");
        }
    }
}
