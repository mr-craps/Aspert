using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetValue<T>(ref T field, T value, [CallerMemberName]string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected Task AlertAsync(string title, string message, string cancel)
            => Application.Current.MainPage.DisplayAlert(title, message, cancel);

        protected ICommand Push<T>() where T : Page, new()
            => new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new T()));
    }
}
