using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aspert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            Dispatcher.BeginInvokeOnMainThread(async () =>
            {
                if (await DisplayAlert("¿Deseas salir de la aplicación?", "Presiona \"OK\" para salir de la aplicación.", "OK", "CANCELAR"))
                    Environment.Exit(0);
            });

            return true;
        }
    }
}