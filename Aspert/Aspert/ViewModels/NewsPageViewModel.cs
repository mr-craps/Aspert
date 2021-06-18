using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Linq;
using Aspert.Database;
using System;
using Xamarin.Forms;

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
            _ = Task.Run(async () =>
            {
                const string url = "https://www.aspergerparaasperger.org/blog/rss";

                if (SQLiteDB.Usuario.UsarDatos && SQLiteDB.Usuario.Sincronizar)
                {
                    var reader = XmlReader.Create(url, new XmlReaderSettings
                    {
                        DtdProcessing = DtdProcessing.Parse
                    });
                    var feed = SyndicationFeed.Load(reader);

                    reader.Close();

                    foreach (var item in feed.Items.Take(10))
                        Instance.Feeds.Add(new Feed(item));
                }

                while (SQLiteDB.Usuario.UsarDatos && SQLiteDB.Usuario.Sincronizar)
                {
                    await Task.Delay(TimeSpan.FromHours(1));

                    var reader = XmlReader.Create(url, new XmlReaderSettings
                    {
                        DtdProcessing = DtdProcessing.Parse
                    });
                    var feed = SyndicationFeed.Load(reader);

                    reader.Close();

                    if (!feed.Items.First().Equals(Instance.Feeds.First()))
                    {
                        Instance.Feeds.Remove(Instance.Feeds.Last());
                        Instance.Feeds.Add(new Feed(feed.Items.First()));
                    }

                    if (SQLiteDB.Usuario.Notificaciones)
                        await Application.Current.MainPage.DisplayAlert("Actualización!", "Hay una nueva actualización en la página de noticias.", "Ok");
                }
            });
        }
    }
}
