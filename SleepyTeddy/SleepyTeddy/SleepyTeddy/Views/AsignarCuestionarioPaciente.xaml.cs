using Plugin.CloudFirestore;
using SleepyTeddy.Models;
using SleepyTeddy.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SleepyTeddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AsignarCuestionarioPaciente : ContentPage
    {
        //SearchPatientView aa = new SearchPatientView();      
        public SearchPatientView objSearch { get; set; }
    
        public AsignarCuestionarioPaciente()
        {
            InitializeComponent();       
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();          
            LoadItems();            
        }

        private async void LoadItems()
        {
            objSearch = new SearchPatientView();
            await objSearch.GetPatientsViewAsync();
            BindingContext = objSearch;
        }
     

        private async void btnAceptar_clicked(object sender, EventArgs e)
        {
            var ObjPatientSel =(PatientsView)lista_pacientes.SelectedItem;
            var cuestionarioSel = lista_cuestionarios.SelectedItem;

            bool allFine = true;

            if(ObjPatientSel != null && cuestionarioSel !=null) {
                await DisplayAlert("", "Cuestionario asignado al paciente correctamente", "OK");
                await CrossCloudFirestore.Current
                             .Instance
                             .Collection("Questionnaries")
                             .AddAsync(new Questionnaries
                             {
                                 Pacient_ID = ObjPatientSel.Key,
                                 D_Assigned_Date = DateTime.Now,
                                 D_Completed_Date = DateTime.MinValue,
                                 Questionnaries_ID = Guid.NewGuid().ToString(),
                                 Therapist_ID = Guid.NewGuid().ToString(),
                                 Type = cuestionarioSel.ToString(),
                                 N_Result = ""
                             });
            }
            else
            {
                Acr.UserDialogs.UserDialogs.Instance.Toast("Complete los campos faltantes", new TimeSpan(3));
            }
        }
    }
}