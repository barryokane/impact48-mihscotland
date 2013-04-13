using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Google.YouTube;
using MiHs.Controls;
using MiHs.DAL;
using MiHs.DAL.DomainObjects;

namespace MiHs
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly MihDbContext _mihDbContext;

        public Default()
        {
            _mihDbContext = new MihDbContext();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                YoutubeVideos.DataBind();
            }
        }

        protected void AddYoutubeVideoControl_AddingYoutubeVideo(object sender, AddYoutubeVideo.AddYoutubeVideoEventArgs e)
        {
            var youtubeVideoIdQueryStringParamaterName = ConfigurationManager.AppSettings["Youtube.VideoIdQueryStringParamametrName"];
            var youtubeVideoReference = HttpUtility.ParseQueryString(e.Uri.Query).Get(youtubeVideoIdQueryStringParamaterName);
            var youtubeVideo = new YoutubeVideo
                {
                    YoutubeVideoReference = youtubeVideoReference,
                    Comment = e.Comment
                };

            _mihDbContext.YoutubeVideos.Add(youtubeVideo);
            _mihDbContext.SaveChanges();

            var developerKey = ConfigurationManager.AppSettings["Youtube.DeveloperKey"];
            var appName = ConfigurationManager.AppSettings["Youtube.ApplicationName"];
            var userName = ConfigurationManager.AppSettings["Youtube.Username"];
            var password = ConfigurationManager.AppSettings["Youtube.Password"];
            var youTubeRequestSettings = new YouTubeRequestSettings(appName, developerKey, userName, password);
            var youTubeRequest = new YouTubeRequest(youTubeRequestSettings);
            var user = ConfigurationManager.AppSettings["Youtube.User"];
            var playlistsFeed = youTubeRequest.GetPlaylistsFeed(user);
            var playlistTitle = ConfigurationManager.AppSettings["Youtube.PlaylistTitle"];
            var playlist = playlistsFeed.Entries.FirstOrDefault(p => p.Title == playlistTitle);
            var playListMember = new PlayListMember { VideoId = youtubeVideo.YoutubeVideoReference };

            youTubeRequest.AddToPlaylist(playlist, playListMember);

            YoutubeVideos.DataBind();
        }

        protected void YoutubeVideos_DataBinding(object sender, EventArgs e)
        {
            var repeater = sender as Repeater;
            if (repeater != null) 
                repeater.DataSource = _mihDbContext.YoutubeVideos.ToList();
        }
    }
}
