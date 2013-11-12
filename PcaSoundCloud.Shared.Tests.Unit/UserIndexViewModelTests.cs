using NUnit.Framework;

namespace PcaSoundCloud.Shared.Tests.Unit
{
    public class UserIndexViewModelTests
    {
        [Test]
        public void has_a_user_object_on_it()
        {
            var actual = new UserIndexViewModel();
            Assert.That(actual.User, Is.Null);
        }

        [Test]
        public void has_a_list_of_fav_tracks()
        {
            var actual = new UserIndexViewModel();
            Assert.That(actual.Favorites, Is.Empty);
        }
    }
}
