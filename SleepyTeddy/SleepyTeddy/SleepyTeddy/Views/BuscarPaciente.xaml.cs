using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SleepyTeddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarPaciente : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public BuscarPaciente()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        private async void btnBuscar_clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
        }
        private async void btnRegistrarPaciente_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegPaciente());
        }
    }
}