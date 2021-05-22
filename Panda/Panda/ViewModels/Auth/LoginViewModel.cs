using MvvmHelpers;
using MvvmHelpers.Commands;
using Panda.Services.Authenticate;
using Panda.Views.Auth;
using Panda.Views.MDPage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panda.ViewModels.Auth
{
    public class LoginViewModel : BaseViewModel
    {
        private string email = "user1@gmail.com";
        private string password = "secret123_!";

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
            this.LoginCommand = new Xamarin.Forms.Command(async () => await this.Login());

            // Register Command
            this.RegisterCpmmand = new Xamarin.Forms.Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new RegisterView(), true);
            });
        }

        private async Task Login()
        {
            bool isLogined = await App.Authenticate.Login(new { email = this.email, password = this.password });

            if (isLogined)
            {
                App.Current.MainPage = new RootcView();
            } 
            else
            {
                await Application.Current.MainPage.DisplayAlert("Errorr", "errorr", "ok");
            }
        }
    }
}
