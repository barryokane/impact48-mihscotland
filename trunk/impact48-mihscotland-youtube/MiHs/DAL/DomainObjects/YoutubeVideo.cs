using System;
using System.Web;

namespace MiHs.DAL.DomainObjects
{
    public class YoutubeVideo
    {
        public YoutubeVideo()
        {
            CreatedDate = DateTime.Now;
        }

        public virtual int YoutubeVideoId { get; set; }
        public virtual string YoutubeVideoReference { get; set; }
        public string Url { get { return string.Format("http://www.youtube.com/watch?v={0}", YoutubeVideoReference); } }
        public virtual string Comment { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}