using Plugin.CloudFirestore;
using SleepyTeddy.Models.Terapeuta;
using SleepyTeddy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SleepyTeddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegTerapeuta : ContentPage
    {
        String REGEX_LETRAS = "[^a-zA-Z ]{2,254}";
        String REGEX_NUMEROS = "^[0-9]+$";
        String REGEX_EMAIL = "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
        String REGEX_CONTRASENA = "^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$";

        
        public RegTerapeuta()
        {
            InitializeComponent();
        }

        private async void btnAceptar_clicked(object sender, EventArgs e)
        {
            string id_admin = LoginViewModel.Administrator_ID;
            if (await ValidarFormularioAsync())
            {

                try
                {
                    await CrossCloudFirestore.Current
                             .Instance
                             .Collection("Users")
                             .AddAsync(new PostTerapeuta
                             {
                                 Last_Names = apTerapeuta.Text,
                                 Names = nmTerapeuta.Text,
                                 Terapeuta_ID = Guid.NewGuid().ToString().Replace("-", ""),
                                 Especiality = nmEspecialidad.Text,
                                 Email = txEmail.Text,
                                 Password = txPsw.Text.ToString(),
                                 administrator_ID= id_admin,
                                 Role_ID="3"
                             });

                    await App.Current.MainPage.DisplayAlert("Registro", "Cuenta registrada correctamente", "Ok");
                    nmTerapeuta.Text = "";
                    apTerapeuta.Text = "";
                    nmEspecialidad.Text = "";
                    txEmail.Text = "";
                    txPsw.Text = "";
                    //await Navigation.PushAsync(new MainPageLogin());
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Registro", ex.Message, "OK");
                }
            }

        }
        private async void btnCancelar_clicked(object sender, EventArgs e)
        {

        }
        private Task<bool> ValidarFormularioAsync()
        {
            Regex rgxLETRAS = new Regex(REGEX_LETRAS, RegexOptions.IgnoreCase);
            Regex rgxEMAIL = new Regex(REGEX_EMAIL, RegexOptions.IgnoreCase);
            Regex rgxCONTRASENA = new Regex(REGEX_CONTRASENA, RegexOptions.IgnoreCase);

            if (string.IsNullOrWhiteSpace(nmTerapeuta.Text)|| string.IsNullOrWhiteSpace(apTerapeuta.Text)|| string.IsNullOrWhiteSpace(nmEspecialidad.Text)|| string.IsNullOrWhiteSpace(txEmail.Text)|| string.IsNullOrWhiteSpace(txPsw.Text))
            {
                //CrossToastPopUp.Current.ShowToastMessage("El campo Nombre no puede estar vacío");
                //await App.Current.MainPage.DisplayAlert("Alerta", "Nombre incorrecto", "OK");
                //UserDialogs.Instance.ShowLoading("Incorrecto");
                Acr.UserDialogs.UserDialogs.Instance.Toast("Complete los campos faltantes", new TimeSpan(3));
                return Task.FromResult(false);
            }
            

            if (rgxLETRAS.IsMatch(nmTerapeuta.Text))
            {
                Acr.UserDialogs.UserDialogs.Instance.Toast("Los nombres no pueden contener numeros", new TimeSpan(3));
                return Task.FromResult(false);
            }
            else
            {
                if (rgxLETRAS.IsMatch(apTerapeuta.Text))
                {
                    Acr.UserDialogs.UserDialogs.Instance.Toast("Los apellidos no pueden contener numeros", new TimeSpan(3));
                    return Task.FromResult(false);
                }
                else
                {
                    if (!rgxEMAIL.IsMatch(txEmail.Text))
                    {
                        Acr.UserDialogs.UserDialogs.Instance.Toast("El email es incorrecto", new TimeSpan(3));
                        return Task.FromResult(false);
                    }
                    else
                    {
                        if (rgxLETRAS.IsMatch(nmEspecialidad.Text))
                        {
                            Acr.UserDialogs.UserDialogs.Instance.Toast("El nombre de especialidad no puede contener números", new TimeSpan(3));
                            return Task.FromResult(false);
                        }
                        else
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