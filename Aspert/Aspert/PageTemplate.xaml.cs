using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aspert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageTemplate : ContentView
    {
        private volatile bool _clicked;
        public View Body
        {
            get => BodyContent.Content;
            set => BodyContent.Content = value;
        }

        public PageTemplate()
        {
            InitializeComponent();
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            if (_clicked)
                return;

            _clicked = true;
            try
            {
                if (sender == btnBack)
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                else if (sender == btnMenu)
                    await Application.Current.MainPage.Navigation.PushModalAsync(new MenuPage());
                else if (sender == btnConfiguration)
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ConfigurationPage());
            }
            finally
            {
                _clicked = false;
            }
        }
    }
}