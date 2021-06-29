using FirebaseAdmin;
using Plugin.CloudFirestore;
using SleepyTeddy.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SleepyTeddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegPaciente : ContentPage
    {
        public RegPaciente()
        {
            InitializeComponent();
        }

        private async void btnAceptar_clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossCloudFirestore.Current
                             .Instance
                             .Collection("Patients")
                             .AddAsync(new Patients
                             {
                                 Last_Names = apPaciente.Text,
                                 Names = nmPaciente.Text,
                                 Pacient_ID = Guid.NewGuid().ToString().Replace("-", ""),
                                 Birthday = dtNacimiento.Date,
                                 Email = txEmail.Text,
                                 Password = txPsw.Text.ToString(),
                                 Administrator_ID = Guid.NewGuid().ToString().Replace("-", ""),
                                 Therapist_ID = Guid.NewGuid().ToString().Replace("-", "")
                             });
                await App.Current.MainPage.DisplayAlert("", "Paciente registrado correctamente", "OK");
                await Navigation.PushAsync(new AsignarPacienteTerapeuta());
            }
            catch (Exception ex)
            {
                //await App.Current.MainPage.DisplayAlert("Aviso", "No se pudo crear el usuario, complete los datos correctamente", "OK");
                Acr.UserDialogs.UserDialogs.Instance.Toast("No se pudo crear el usuario, complete los datos correctamente", new TimeSpan(3));
            }
        }
        private async void btnCancelar_clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AsignarPacienteTerapeuta());

        }

        private void dtNacimiento_DateSelected(object sender, DateChangedEventArgs e)
        {

        }
    }
}