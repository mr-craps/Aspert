﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        protected static readonly INavigation _navigation = Application.Current.MainPage.Navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand Push { get; }
        public ICommand Back { get; }

        public ViewModel()
        {
            Push = new Command<Type>(async pageType => await _navigation.PushModalAsync((Page)Activator.CreateInstance(pageType)));
            Back = new Command(async () => await _navigation.PushModalAsync(
                (Page)Activator.CreateInstance(
                    _navigation.ModalStack[_navigation.ModalStack.Count - 1].GetType())));
        }

        protected void SetValue<T>(ref T field, T value, [CallerMemberName]string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected Task AlertAsync(string title, string message, string cancel)
            => Application.Current.MainPage.DisplayAlert(title, message, cancel);

        protected Task<bool> AlertAsync(string title, string message, string accept, string cancel)
            => Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
    }
}
