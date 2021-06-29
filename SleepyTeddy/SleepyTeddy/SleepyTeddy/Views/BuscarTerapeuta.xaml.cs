using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SleepyTeddy.Models.Terapeuta;
using SleepyTeddy.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SleepyTeddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarTerapeuta : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }
        public TabledPageTerapeutaView objTableBinding { get; set; }
        public BuscarTerapeuta()
        {
            InitializeComponent();
        }

        private async void btnSearch_clicked_terapeuta(object sender, EventArgs e)
        {
            string id_admin = LoginViewModel.Administrator_ID;
            if (string.IsNullOrWhiteSpace(apTerapeuta.Text))
            {
                Acr.UserDialogs.UserDialogs.Instance.Toast("Complete el campo de búsqueda", new TimeSpan(3));
            }
            else
            {
                try
                {
                    objTableBinding = new TabledPageTerapeutaView();
                    await objTableBinding.GetTerapistViewAsync(apTerapeuta.Text, id_admin);
                    list_terapist.ItemsSource = objTableBinding.ListTerapist;
                    if ((list_terapist.ItemsSource as ListaTerapeutas).Count == 0)
                    {
                        Acr.UserDialogs.UserDialogs.Instance.Toast("No se obtuvieron resultados", new TimeSpan(3));
                    }
                }
                catch (Exception ex) { }
            }
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            if (e.Item == null)
                return;

            var dataItem = e.Item as TerapistView;

            await Navigation.PushAsync(new UpdateAccTerapeuta(dataItem.Key));
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        private async void btnRegistrarTerapeuta_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegTerapeuta());
        }
    }
}