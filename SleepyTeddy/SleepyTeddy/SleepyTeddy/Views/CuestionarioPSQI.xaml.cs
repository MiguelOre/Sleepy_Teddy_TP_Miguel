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
    public partial class CuestionarioPSQI : ContentPage
    {
        public CuestionarioPSQI()
        {
            InitializeComponent();

            PickerOne.Items.Add("No me ha ocurrido durante el último mes");
            PickerOne.Items.Add("Menos de una vez a la semana");
            PickerOne.Items.Add("Una o dos veces a la semana");
            PickerOne.Items.Add("Tres o más veces a la semana");

            PickerTwo.Items.Add("No me ha ocurrido durante el último mes");
            PickerTwo.Items.Add("Menos de una vez a la semana");
            PickerTwo.Items.Add("Una o dos veces a la semana");
            PickerTwo.Items.Add("Tres o más veces a la semana");

            PickerThree.Items.Add("No me ha ocurrido durante el último mes");
            PickerThree.Items.Add("Menos de una vez a la semana");
            PickerThree.Items.Add("Una o dos veces a la semana");
            PickerThree.Items.Add("Tres o más veces a la semana");

            PickerFour.Items.Add("No me ha ocurrido durante el último mes");
            PickerFour.Items.Add("Menos de una vez a la semana");
            PickerFour.Items.Add("Una o dos veces a la semana");
            PickerFour.Items.Add("Tres o más veces a la semana");

            PickerFive.Items.Add("No me ha ocurrido durante el último mes");
            PickerFive.Items.Add("Menos de una vez a la semana");
            PickerFive.Items.Add("Una o dos veces a la semana");
            PickerFive.Items.Add("Tres o más veces a la semana");

            PickerSix.Items.Add("No me ha ocurrido durante el último mes");
            PickerSix.Items.Add("Menos de una vez a la semana");
            PickerSix.Items.Add("Una o dos veces a la semana");
            PickerSix.Items.Add("Tres o más veces a la semana");

            PickerSeven.Items.Add("No me ha ocurrido durante el último mes");
            PickerSeven.Items.Add("Menos de una vez a la semana");
            PickerSeven.Items.Add("Una o dos veces a la semana");
            PickerSeven.Items.Add("Tres o más veces a la semana");

            PickerEight.Items.Add("No me ha ocurrido durante el último mes");
            PickerEight.Items.Add("Menos de una vez a la semana");
            PickerEight.Items.Add("Una o dos veces a la semana");
            PickerEight.Items.Add("Tres o más veces a la semana");

            PickerNine.Items.Add("No me ha ocurrido durante el último mes");
            PickerNine.Items.Add("Menos de una vez a la semana");
            PickerNine.Items.Add("Una o dos veces a la semana");
            PickerNine.Items.Add("Tres o más veces a la semana");

            PickerTen.Items.Add("No me ha ocurrido durante el último mes");
            PickerTen.Items.Add("Menos de una vez a la semana");
            PickerTen.Items.Add("Una o dos veces a la semana");
            PickerTen.Items.Add("Tres o más veces a la semana");

            PickerEleven.Items.Add("Muy buena");
            PickerEleven.Items.Add("Bastante buena");
            PickerEleven.Items.Add("Bastante mala");
            PickerEleven.Items.Add("Muy mala");

            PickerTwelve.Items.Add("No me ha ocurrido durante el último mes");
            PickerTwelve.Items.Add("Menos de una vez a la semana");
            PickerTwelve.Items.Add("Una o dos veces a la semana");
            PickerTwelve.Items.Add("Tres o más veces a la semana");

            PickerThirteen.Items.Add("No me ha ocurrido durante el último mes");
            PickerThirteen.Items.Add("Menos de una vez a la semana");
            PickerThirteen.Items.Add("Una o dos veces a la semana");
            PickerThirteen.Items.Add("Tres o más veces a la semana");

            PickerFourteen.Items.Add("No ha resultado problemático en absoluto");
            PickerFourteen.Items.Add("Solo ligeramente problemático");
            PickerFourteen.Items.Add("Moderadamente problemático");
            PickerFourteen.Items.Add("Muy problemático");



        }

        private void PickerOne_OnSelectedIndexChangue(object sender, EventArgs e) 
        {
            var name = PickerOne.Items[PickerOne.SelectedIndex];
        }

        private void PickerTwo_OnSelectedIndexChangue(object sender, EventArgs e)
        {
            var name = PickerTwo.Items[PickerTwo.SelectedIndex];
        }

        private void PickerThree_OnSelectedIndexChangue(object sender, EventArgs e)
        {
            var name = PickerThree.Items[PickerThree.SelectedIndex];
        }

        private void PickerFour_OnSelectedIndexChangue(object sender, EventArgs e)
        {
            var name = PickerFour.Items[PickerFour.SelectedIndex];
        }

        private void PickerFive_OnSelectedIndexChangue(object sender, EventArgs e)
        {
            var name = PickerFive.Items[PickerFive.SelectedIndex];
        }

        private void PickerSix_OnSelectedIndexChangue(object sender, EventArgs e)
        {
            var name = PickerSix.Items[PickerSix.SelectedIndex];
        }

        private void PickerSeven_OnSelectedIndexChangue(object sender, EventArgs e)
        {
            var name = PickerSeven.Items[PickerSeven.SelectedIndex];
        }

        private void PickerEight_OnSelectedIndexChangue(object sender, EventArgs e)
        {
            var name = PickerEight.Items[PickerEight.SelectedIndex];
        }

        private void PickerNine_OnSelectedIndexChangue(object sender, EventArgs e)
        {
            var name = PickerNine.Items[PickerNine.SelectedIndex];
        }

        private void PickerTen_OnSelectedIndexChangue(object sender, EventArgs e)
        {
            var name = PickerTen.Items[PickerTen.SelectedIndex];
        }

        private void PickerEleven_OnSelectedIndexChangue(object sender, EventArgs e)
        {
            var name = PickerEleven.Items[PickerEleven.SelectedIndex];
        }

        private void PickerTwelve_OnSelectedIndexChangue(object sender, EventArgs e)
        {
            var name = PickerTwelve.Items[PickerTwelve.SelectedIndex];
        }

        private void PickerThirteen_OnSelectedIndexChangue(object sender, EventArgs e)
        {
            var name = PickerThirteen.Items[PickerThirteen.SelectedIndex];
        }

        private void PickerFourteen_OnSelectedIndexChangue(object sender, EventArgs e)
        {
            var name = PickerFourteen.Items[PickerFourteen.SelectedIndex];
        }

        private async void btnAceptar_clicked(object sender, EventArgs e)
        {
            
        }

        private async void btnCancelar_clicked(object sender, EventArgs e)
        {
            
        }

    }
}