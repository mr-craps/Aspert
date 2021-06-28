using Xamarin.Essentials;

namespace Aspert.ViewModels
{
    public class AboutPageViewModel : ViewModel
    {
        public string Version => "v" + VersionTracking.CurrentVersion;
    }
}
