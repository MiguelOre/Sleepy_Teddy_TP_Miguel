using Plugin.CloudFirestore;
using SleepyTeddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SleepyTeddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePaciente : ContentPage
    {
        Patients patient;
        string documentId;
        string UID;
        public UpdatePaciente()
        {
            InitializeComponent();
            getPatient();

        }

        public UpdatePaciente(string UID)
        {
            this.UID = UID;
            InitializeComponent();
            getPatient();

        }

    private async void getPatient()
        {
            var document = await CrossCloudFirestore.Current
                                       .Instance
                                       .Collection("Patients")
                                       .WhereEqualsTo("Pacient_ID",UID)
                                       .GetAsync();
            patient = document.Documents.ElementAt(0).ToObject<Patients>();
            documentId = document.Documents.ElementAt(0).Id;
            dtNacimiento.Date = patient.Birthday;
            dtNacimiento.Date = patient.Birthday;
            nmPaciente.Text = patient.Names;
            apPaciente.Text = patient.Last_Names;
            dtNacimiento.Date = patient.Birthday;
            txEmail.Text = patient.Email;
            txPsw.Text = patient.Password ;
        }

        private async void btnAceptar_clicked(object sender, EventArgs e)
        {
            if (nmPaciente.Text.Length >0 && apPaciente.Text.Length > 0 && txEmail.Text.Length > 0 && txPsw.Text.Length > 0)
            {
                patient.Names = nmPaciente.Text;
                patient.Last_Names = apPaciente.Text;
                patient.Birthday = dtNacimiento.Date;

                if (IsValidEmail(txEmail.Text) && txPsw.Text.Length >= 7)
                {
                    patient.Email = txEmail.Text;
                    patient.Password = txPsw.Text;

                    await CrossCloudFirestore.Current
                        .Instance
                        .Collection("Patients")
                        .Document(documentId)
                        .UpdateAsync(patient);
                    await DisplayAlert("", "Paciente actualizado correctamente", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    Acr.UserDialogs.UserDialogs.Instance.Toast("Complete correctamente los campos", new TimeSpan(3));
                } 
            }
            else
            {
                Acr.UserDialogs.UserDialogs.Instance.Toast("Complete los campos faltantes", new TimeSpan(3));
            }            
        }
        private async void btnCancelar_clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void dtNacimiento_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}