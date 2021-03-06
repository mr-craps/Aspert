using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aspert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {
        public BookPage()
            => InitializeComponent();

        public async void OnTapped(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var text = label.FormattedText.ToString();
            var url = text.Substring(text.IndexOf("http"));
            await Launcher.OpenAsync(url);
        }
    }
}