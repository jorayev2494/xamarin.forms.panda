using MvvmHelpers;
using MvvmHelpers.Commands;
using Panda.Views.Auth;
using Panda.Views.MDPage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Panda.ViewModels.Auth
{
    public class LoginViewModel : BaseViewModel
    {
        private string email = "jorayev2494@gmail.com";
        private string password = "secret";

        public string Email
        {
            get => this.email;
            set => base.SetProperty<string>(ref this.email, value);
        }

        public string Password
        {
            get => this.password;
            set => base.SetProperty<string>(ref this.password, value);
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand RegisterCpmmand { get; private set; }

        public LoginViewModel()
        {
            // Login Command
            this.LoginCommand = new Command(() => 
            {
                App.Current.MainPage = new RootcView();
                // await App.Current.MainPage.DisplayAlert("Login", $"Email: {this.email} \r\nPassword: {this.password}", "Ok");
            });

            // Register Command
            this.RegisterCpmmand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new RegisterView(), true);
            });
        }
    }
}
