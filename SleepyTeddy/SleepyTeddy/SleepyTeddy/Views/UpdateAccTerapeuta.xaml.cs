using System;
using Plugin.CloudFirestore;
using SleepyTeddy.Models.Terapeuta;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SleepyTeddy.Models;
using SleepyTeddy.ViewModel;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SleepyTeddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateAccTerapeuta : ContentPage
    {

        String REGEX_LETRAS = "[^a-zA-Z ]{2,254}";
        String REGEX_NUMEROS = "^[0-9]+$";
        String REGEX_EMAIL = "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
        String REGEX_CONTRASENA = "^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$";
        String Terapist_ID;
        String documentID;
        String Administrator_ID;
        String Role_ID;
        PostTerapeuta terapeuta;

        public UpdateAccTerapeuta(String key_terapist)
        {
            Terapist_ID = key_terapist;
            InitializeComponent();
            getTerapeuta();

        }


        private async void getTerapeuta()
        {
            String role_id = "3";
            var document = await CrossCloudFirestore.Current
                                       .Instance
                                       .Collection("Users")
                                       .WhereEqualsTo("Role_ID", role_id)
                                       .WhereEqualsTo("Terapeuta_ID", Terapist_ID)
                                       .GetAsync();
            terapeuta = document.Documents.ElementAt(0).ToObject<PostTerapeuta>();
            documentID = document.Documents.ElementAt(0).Id;
            nmTpt.Text = terapeuta.Names;
            apTpt.Text = terapeuta.Last_Names;
            espTpt.Text = terapeuta.Especiality;
            txEmail.Text = terapeuta.Email;
            txPsw.Text = terapeuta.Password;
            Administrator_ID = terapeuta.administrator_ID;
            Role_ID = terapeuta.Role_ID;

        }




        private async void btnAceptar_clicked(object sender, EventArgs e)
        {

            var data = new PostTerapeuta
            {
                Names = nmTpt.Text,
                Last_Names = apTpt.Text,
                Especiality = espTpt.Text,
                Email = txEmail.Text,
                Password = txPsw.Text,
                //Terapeuta_ID = Guid.NewGuid().ToString(),
                Terapeuta_ID = Terapist_ID,
                administrator_ID = Administrator_ID,
                Role_ID = Role_ID,
            };

            if (await ValidarFormularioAsync())
            {

                try
                {
                    await CrossCloudFirestore.Current
                                     .Instance
                                     .Collection("Users")
                                     .Document(documentID)
                                     .UpdateAsync(data);

                    //Acr.UserDialogs.UserDialogs.Instance.Toast("Terapeuta actualizado correctamente", new TimeSpan(3));
                    await DisplayAlert("", "Terapeuta actualizado correctamente", "OK");
                    await Navigation.PushAsync(new BuscarTerapeuta());

                }
                catch (Exception ex){}
            }

        }
        private async void btnCancelar_clicked(object sender, EventArgs e)
        {

            //await Navigation.PushAsync(new BuscarTerapeuta());

        }

        private Task<bool> ValidarFormularioAsync()
        {
            Regex rgxLETRAS = new Regex(REGEX_LETRAS, RegexOptions.IgnoreCase);
            Regex rgxEMAIL = new Regex(REGEX_EMAIL, RegexOptions.IgnoreCase);
            Regex rgxCONTRASENA = new Regex(REGEX_CONTRASENA, RegexOptions.IgnoreCase);

            if (string.IsNullOrWhiteSpace(nmTpt.Text) || string.IsNullOrWhiteSpace(apTpt.Text)
                || string.IsNullOrWhiteSpace(espTpt.Text) || string.IsNullOrWhiteSpace(txEmail.Text)
                || string.IsNullOrWhiteSpace(txPsw.Text))
            {
                Acr.UserDialogs.UserDialogs.Instance.Toast("Complete los campos faltantes", new TimeSpan(3));
                return Task.FromResult(false);
            }
            
            if (rgxLETRAS.IsMatch(nmTpt.Text))
            {
                Acr.UserDialogs.UserDialogs.Instance.Toast("Los nombres no pueden contener números", new TimeSpan(3));
                return Task.FromResult(false);
            }
            else
            {
                if (rgxLETRAS.IsMatch(apTpt.Text))
                {
                    Acr.UserDialogs.UserDialogs.Instance.Toast("Los apellidos no pueden contener números", new TimeSpan(3));
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
                        if (rgxLETRAS.IsMatch(espTpt.Text))
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