using System;
using System.Web.UI.WebControls;

namespace MiHs.Controls
{
    public partial class AddYoutubeVideo : System.Web.UI.UserControl
    {
        protected string ValidationGroup { get { return ClientID + "_ValidationGroup"; } }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                UrlRequiredValidator.ValidationGroup =
                    Add.ValidationGroup = UrlValidator.ValidationGroup = ValidationGroup;
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Page.Validate(ValidationGroup);

            if (Page.IsValid)
            {
                AddingYoutubeVideo(this, new AddYoutubeVideoEventArgs(new Uri(Url.Text), Comment.Text));
                Url.Text = Comment.Text = String.Empty;
            }
        }

        public event EventHandler<AddYoutubeVideoEventArgs> AddingYoutubeVideo = delegate { };

        public class AddYoutubeVideoEventArgs : EventArgs
        {
            public AddYoutubeVideoEventArgs(Uri uri, string comment)
            {
                Uri = uri;
                Comment = comment;
            }

            public Uri Uri { get; set; }
            public string Comment { get; set; }
        }

        protected void ValidateUrl(object source, ServerValidateEventArgs args)
        {
            try
            {
                var uri = new Uri(args.Value);
            }
            catch (Exception)
            {
                args.IsValid = false;
            }
        }
    }
}