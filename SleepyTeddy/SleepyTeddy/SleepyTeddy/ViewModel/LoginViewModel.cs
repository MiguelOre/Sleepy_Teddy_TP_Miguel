using Acr.UserDialogs;
using SleepyTeddy.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SleepyTeddy.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        public static string Administrator_ID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel()
        {

        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }
        public Command SignUp
        {
            get
            {
                return new Command(()=> { App.Current.MainPage.Navigation.PushAsync(new RegAdministrador()); });
            }
        }

        private async void Login()
        {
            //null or empty field validation, check weather email and password is null or empty
            
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
             await App.Current.MainPage.DisplayAlert("Campos vacíos", "Por favor, ingresa el usuario y contraseña", "OK");
            else
            {
                //call GetUser function which we define in Firebase helper class
                var user = await FirebaseHelperLogIn.GetUser(Email);
                //firebase return null valuse if user data not found in database
                if(user!=null)
                if (Email == user.Email && Password == user.Password && user.Role_ID=="1")
                {
                        Administrator_ID = user.Administrator_ID;
                        //await  App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                        //Navigate to Wellcom page after successfuly login
                        //pass user email to welcom page
                        using (var dialog = UserDialogs.Instance.Progress("Procesando"))
                        {
                            for (int i = 1; i <= 10; i++)
                            {
                                await Task.Delay(100);
                                dialog.PercentComplete = i * 10;
                            }
                        }
                        await App.Current.MainPage.Navigation.PushAsync(new PaginaPrincipal());
                }else
                if (Email == user.Email && Password == user.Password && user.Role_ID == "3")
                    {
                        Administrator_ID = user.Administrator_ID;
                        //await  App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                        //Navigate to Wellcom page after successfuly login
                        //pass user email to welcom page
                        using (var dialog = UserDialogs.Instance.Progress("Procesando"))
                        {
                            for (int i = 1; i <= 10; i++)
                            {
                                await Task.Delay(100);
                                dialog.PercentComplete = i * 10;
                            }
                        }
                        await App.Current.MainPage.Navigation.PushAsync(new AsignarCuestionarioPaciente());
                    }

                    else
                await  App.Current.MainPage.DisplayAlert("Error", "Por favor ingresa el usuario y contraseña correctos", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Error", "Usuario no encontrado, por favor, registrate", "OK");
            }
        }
    }
}
