using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Linq;

namespace Aspert.ViewModels
{
    public class NewsPageViewModel : ViewModel
    {
        public static readonly NewsPageViewModel Instance = new NewsPageViewModel
        {
            Feeds = new ObservableCollection<Feed>()
        };

        public ICollection<Feed> Feeds { get; set; }

        static NewsPageViewModel()
        {
            _ = Task.Run(() =>
            {
                const string url = "https://www.aspergerparaasperger.org/blog/rss";
                var reader = XmlReader.Create(url, new XmlReaderSettings
                {
                    DtdProcessing = DtdProcessing.Parse
                });
                var feed = SyndicationFeed.Load(reader);

                reader.Close();

                foreach (var item in feed.Items.Take(3))
                    Instance.Feeds.Add(new Feed(item));
            });
        }
    }

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
            && Title == feed.Title
            && Summary == feed.Summary;

        public override int GetHashCode()
            => base.GetHashCode();
    }
}
