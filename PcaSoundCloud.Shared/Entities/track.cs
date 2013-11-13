using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcaSoundCloud.Shared.Entities
{
    public class Track
    {
        public string Kind { get; set; }
        public string Id { get; set; }
        public string Createdat { get; set; }
        public string Userid { get; set; }
        public string Duration { get; set; }
        public string Commentable { get; set; }
        public string State { get; set; }
        public string Originalcontentsize { get; set; }
        public string Sharing { get; set; }
        public string Taglist { get; set; }
        public string Permalink { get; set; }
        public string Streamable { get; set; }
        public string Embeddableby { get; set; }
        public string Downloadable { get; set; }
        public string Purchaseurl { get; set; }
        public string Labelid { get; set; }
        public string Purchasetitle { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Labelname { get; set; }
        public string Release { get; set; }
        public string Tracktype { get; set; }
        public string Keysignature { get; set; }
        public string Isrc { get; set; }
        public string Videourl { get; set; }
        public string Bpm { get; set; }
        public string Releaseyear { get; set; }
        public string Releasemonth { get; set; }
        public string Releaseday { get; set; }
        public string Originalformat { get; set; }
        public string License { get; set; }
        public string Uri { get; set; }
        public TrackUser User { get; set; }
        public string Permalinkurl { get; set; }
        public string Artworkurl { get; set; }
        public string Waveformurl { get; set; }
        public string Streamurl { get; set; }
        public string Playbackcount { get; set; }
        public string Downloadcount { get; set; }
        public string Favoritingscount { get; set; }
        public string Commentcount { get; set; }
        public string Attachmentsuri { get; set; }        
    }

    public class TrackUser
    {
        public string Id { get; set; }
        public string Kind { get; set; }
        public string Permalink { get; set; }
        public string Username { get; set; }
        public string Uri { get; set; }
        public string PermalinkUrl { get; set; }
        public string AvatarUrl { get; set; }
    }
}
