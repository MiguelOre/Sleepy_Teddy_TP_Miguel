using Acr.UserDialogs;
using SleepyTeddy.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SleepyTeddy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPageLogin());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
