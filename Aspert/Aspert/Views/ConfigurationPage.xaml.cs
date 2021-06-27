using Aspert.Database;
using Aspert.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aspert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigurationPage : ContentPage
    {
        private readonly bool eventOn;

        public ConfigurationPage()
        {
            InitializeComponent();
            BindingContext = new ConfigurationPageViewModel();
            sNotificaciones.IsToggled = SQLiteDB.Usuario.Notificaciones;
            sSincronizacion.IsToggled = SQLiteDB.Usuario.Sincronizar;
            sUsoDeDatosMoviles.IsToggled = SQLiteDB.Usuario.UsarDatos;
            eventOn = true;
        }

        private async void SwitchToggled(object sender, ToggledEventArgs e)
        {
            if (!eventOn)
                return;
            try
            {
                var @switch = (Switch)sender;
                var context = (ConfigurationPageViewModel)BindingContext;
                var value = e.Value;

                if (@switch == sNotificaciones)
                    context.Notify = value;
                else if (@switch == sSincronizacion)
                    context.Synchronize = value;
                else if (@switch == sUsoDeDatosMoviles)
                    context.UseData = value;
            }
            catch (System.Exception ex)
            {
                await DisplayAlert("ERROR", ex.ToString(), "Cancelar");
            }
        }

        private async void ImageButton_Pressed(object sender, System.EventArgs e)
        {
            var context = (ConfigurationPageViewModel)BindingContext;
            var button = (ImageButton)sender;

            if (button == btnClose)
                context.Logout.Execute(null);
            else if (button == btnDelete)
                context.DeleteAccount.Execute(null);
            else if (button == btnEdit)
            {
                var nombre = await DisplayPromptAsync("Introduzca su nombre", string.Empty, cancel: "Cancelar");
                SQLiteDB.Usuario.Nombre = nombre;
                SQLiteDB.UpdateCurrentUser();
                lbName.Text = nombre;
            }
        }
    }
}