using Acr.UserDialogs;
using Firebase.Auth;
using Plugin.CloudFirestore;
using SleepyTeddy.Models.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Joins;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SleepyTeddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegAdministrador : ContentPage
    {
        public string WebAPIkey = "AIzaSyCn23mEfbZVvw9Y7RTuCqmhpI5fcwQRL5o";
        String REGEX_LETRAS = "[^a-zA-Z ]{2,254}";
        String REGEX_NUMEROS = "^[0-9]+$";
        String REGEX_EMAIL = "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
        String REGEX_CONTRASENA = "^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$";
        public RegAdministrador()
        {
            InitializeComponent();
        }
        private async void btnAceptar_clicked(object sender, EventArgs e)
        {
            if(await ValidarFormularioAsync())
            { 
                try
                {
                    await CrossCloudFirestore.Current
                         .Instance
                         .Collection("Users")
                         .AddAsync(new PostAdminnistrator
                         {
                             Last_Names = apAdmin.Text,
                             Names = nmAdmin.Text,
                             Administrator_ID = Guid.NewGuid().ToString().Replace("-", ""),
                             Institution = apInstitucion.Text,
                             Email = txEmail.Text,
                             Password = txPsw.Text.ToString(),
                             Role_ID="1"
                         });         

                    await App.Current.MainPage.DisplayAlert("Registro", "Cuenta registrada correctamente", "Ok");
                    await Navigation.PushAsync(new MainPageLogin());
             }
             catch (Exception ex)
             {
                    await App.Current.MainPage.DisplayAlert("Registro", ex.Message, "OK");
                }
            }
        }
        private Task<bool> ValidarFormularioAsync()
        {
            
            Regex rgxLETRAS = new Regex(REGEX_LETRAS, RegexOptions.IgnoreCase);
            Regex rgxEMAIL = new Regex(REGEX_EMAIL, RegexOptions.IgnoreCase);
            Regex rgxCONTRASENA = new Regex(REGEX_CONTRASENA, RegexOptions.IgnoreCase);

            if (string.IsNullOrWhiteSpace(nmAdmin.Text)|| string.IsNullOrWhiteSpace(apAdmin.Text) || string.IsNullOrWhiteSpace(txEmail.Text) || string.IsNullOrWhiteSpace(apInstitucion.Text) || string.IsNullOrWhiteSpace(txPsw.Text))
            {
                //CrossToastPopUp.Current.ShowToastMessage("El campo Nombre no puede estar vacío");
                //await App.Current.MainPage.DisplayAlert("Alerta", "Nombre incorrecto", "OK");
                //UserDialogs.Instance.ShowLoading("Incorrecto");
                Acr.UserDialogs.UserDialogs.Instance.Toast("Complete los campos faltantes", new TimeSpan(3));
                return Task.FromResult(false);
            }
            
            if(rgxLETRAS.IsMatch(nmAdmin.Text))
            {
                Acr.UserDialogs.UserDialogs.Instance.Toast("Los nombres no pueden contener numeros", new TimeSpan(3));
                return Task.FromResult(false);
            }else
            {
                if (rgxLETRAS.IsMatch(apAdmin.Text))
                {
                    Acr.UserDialogs.UserDialogs.Instance.Toast("Los apellidos no pueden contener numeros", new TimeSpan(3));
                    return Task.FromResult(false);
                }else
                {
                    if (!rgxEMAIL.IsMatch(txEmail.Text))
                    {
                        Acr.UserDialogs.UserDialogs.Instance.Toast("El email es incorrecto", new TimeSpan(3));
                        return Task.FromResult(false);
                    }else
                    {
                        if (rgxLETRAS.IsMatch(apInstitucion.Text))
                        {
                            Acr.UserDialogs.UserDialogs.Instance.Toast("El nombre de institución no puede contener números", new TimeSpan(3));
                            return Task.FromResult(false);
                        }else
                        {
                            if (!rgxCONTRASENA.IsMatch(txPsw.Text))
                            {
                                Acr.UserDialogs.UserDialogs.Instance.Toast("La contraseña debe tener entre 8 y 16 caracteres, al menos un dígito, una minúscula y una mayúscula.", new TimeSpan(6));
                                return Task.FromResult(false);
                            }
                        }
                    }
                }
            }
            
          
           



            return Task.FromResult(true);
        }
    }
}