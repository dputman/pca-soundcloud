using NUnit.Framework;

namespace PcaSoundCloud.API.Tests.Unit
{
    public class SoundCloudServiceTests
    {

        [Test]
        public void Return_fake_data_without_calling_soundcloud()
        {
            IMusicService music = new MusicService();
            
            SoundCloudService service = new SoundCloudService(music);

          
        }
    }
}