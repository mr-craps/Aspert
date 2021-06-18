using System.ServiceModel.Syndication;

namespace Aspert.ViewModels
{
    public class Feed
    {
        public string Title { get; }
        public string Summary { get; }

        public Feed(SyndicationItem item)
        {
            Title = item.Title.Text;
            Summary = item.Summary.Text;
        }

        public override bool Equals(object obj)
            => obj is Feed feed
            && Title.Equals(feed.Title)
            && Summary.Equals(feed.Summary);

        public override int GetHashCode()
            => base.GetHashCode();
    }
}
