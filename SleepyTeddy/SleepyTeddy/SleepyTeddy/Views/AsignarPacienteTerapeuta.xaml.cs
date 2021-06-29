using SleepyTeddy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SleepyTeddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AsignarPacienteTerapeuta : TabbedPage
    {
        public TabledPageTerapeutaView objTableBinding { get; set; }
        public AsignarPacienteTerapeuta()
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
            objTableBinding = new TabledPageTerapeutaView();
            //wait objTableBinding.GetPatientsViewAsync();
            // BindingContext = objTableBinding;

        }

        private async void btnSearch_clicked(object sender, EventArgs e)
        {
            /*await objTableBinding.GetPatientsViewAsync(apPaciente.Text);
            list_patients.ItemsSource=objTableBinding.ListPatient;*/


        }


        private async void btnAceptar_clicked(object sender, EventArgs e)
        {

        }
        private async void btnCancelar_clicked(object sender, EventArgs e)
        {



        }

    }
}