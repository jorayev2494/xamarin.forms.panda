using MvvmHelpers;
using MvvmHelpers.Commands;
using Panda.Services.Authenticate;
using Panda.Views;
using Panda.Views.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Panda.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        private string token = "Default token";
        public string Token
        {
            get => this.token;
            set => base.SetProperty<string>(ref this.token, value);
        }

        public ICommand GoToLoginViewCommand { get; private set; }

        public WelcomeViewModel()
        {
            this.GoToLoginViewCommand = new Command(() => App.Current.MainPage.Navigation.PushAsync(new LoginView(), true));
            App.Current.MainPage = new HomeView();
            this.Token = Panda.Services.Authenticate.Auth.GetAccessToken() ?? "Dont token";
        }

    }
}
