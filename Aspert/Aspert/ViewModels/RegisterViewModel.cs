﻿using System.Windows.Input;
using Aspert.Database;
using Xamarin.Forms;

namespace Aspert.ViewModels
{
    public class RegisterPageViewModel : ViewModel
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public ICommand Login { get; }

        public RegisterPageViewModel()
        {
            Login = new Command(async () =>
            {
                if (await SQLiteDB.GetUserAsync(Usuario, Contraseña) is User)
                {
                    await Application.Current.MainPage.DisplayAlert("Usuario duplicado", "El usuario que intenta registrar ya existe en la base de datos.", "Ok");
                }
                else
                {
                    if (Usuario.Length < 4 || Usuario.Length > 12)
                    {
                        await Application.Current.MainPage.DisplayAlert("Usuario inválido", "El usuario debe tener de 4 a 12 caracteres.", "Ok");
                        return;
                    }

                    if (Contraseña.Length < 4 || Contraseña.Length > 12)
                    {
                        await Application.Current.MainPage.DisplayAlert("Contraseña inválida", "La contraseña debe tener de 4 a 12 caracteres.", "Ok");
                        return;
                    }

                    SQLiteDB.Usuario = await SQLiteDB.RegisterAsync(Usuario, Contraseña);
                    await Application.Current.MainPage.DisplayAlert("¡Registro exitoso!", "¡Tu usuario ha sido registrado exitosamente!", "Ok");
                    await Application.Current.MainPage.Navigation.PushModalAsync(new WelcomePage());
                }
            });
        }
    }
}