using Panda.Services.Authenticate;
using Panda.Services.Authenticate.Contracts;
using Panda.Views;
using Panda.Views.MDPage;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Panda
{
    public partial class App : Application
    {

        public static IAuthenticate Authenticate
        {
            get => new Authenticate();
        }

        public App()
        {
            InitializeComponent();

            this.ClearAuthData();
            if (Panda.Services.Authenticate.Auth.HasAccessToken())
                base.MainPage = new RootcView();
            else
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
        
        private void ClearAuthData()
        {
            Auth.RemoveAccessToken();
            Auth.RemoveAuthUser();
        }
    }
}
