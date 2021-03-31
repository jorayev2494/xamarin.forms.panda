using Panda.Views;
using Panda.Views.MDPage;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Panda
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            base.MainPage = new NavigationPage(new WelcomeView());
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
