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
    public partial class CuestionarioISI : ContentPage
    {
        public CuestionarioISI()
        {
            InitializeComponent();

            PickerOne.Items.Add("0 - Nada");
            PickerOne.Items.Add("1 - Leve");
            PickerOne.Items.Add("2 - Moderado");
            PickerOne.Items.Add("3 - Grave");
            PickerOne.Items.Add("4 - Muy grave");

            PickerTwo.Items.Add("0 - Nada");
            PickerTwo.Items.Add("1 - Leve");
            PickerTwo.Items.Add("2 - Moderado");
            PickerTwo.Items.Add("3 - Grave");
            PickerTwo.Items.Add("4 - Muy grave");

            PickerThree.Items.Add("0 - Nada");
            PickerThree.Items.Add("1 - Leve");
            PickerThree.Items.Add("2 - Moderado");
            PickerThree.Items.Add("3 - Grave");
            PickerThree.Items.Add("4 - Muy grave");

            PickerFour.Items.Add("Muy satisfecho - 0");
            PickerFour.Items.Add("1");
            PickerFour.Items.Add("Moderadamente satisfecho - 2");
            PickerFour.Items.Add("3");
            PickerFour.Items.Add("Muy insatisfecho - 4");

            PickerFive.Items.Add("0 - Nada");
            PickerFive.Items.Add("1 - Un poco");
            PickerFive.Items.Add("2 - Algo");
            PickerFive.Items.Add("3 - Mucho");
            PickerFive.Items.Add("4 - Muchísimo");

            PickerSix.Items.Add("0 - Nada");
            PickerSix.Items.Add("1 - Un poco");
            PickerSix.Items.Add("2 - Algo");
            PickerSix.Items.Add("3 - Mucho");
            PickerSix.Items.Add("4 - Muchísimo");

            PickerSeven.Items.Add("0 - Nada");
            PickerSeven.Items.Add("1 - Un poco");
            PickerSeven.Items.Add("2 - Algo");
            PickerSeven.Items.Add("3 - Mucho");
            PickerSeven.Items.Add("4 - Muchísimo");
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

        private async void btnAceptar_clicked(object sender, EventArgs e)
        {

        }

        private async void btnCancelar_clicked(object sender, EventArgs e)
        {

        }

    }
}