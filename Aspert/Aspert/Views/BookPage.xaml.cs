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
            => await Launcher.OpenAsync(((Label)sender).FormattedText.ToString()); 
    }
}