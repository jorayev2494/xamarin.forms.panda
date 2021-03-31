using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace Panda.ViewModels.Auth
{
    public class RegisterViewModel : BaseViewModel
    {

        private string firstName = "Yakub";
        private string lastName = "Jorayev";
        private string email = "jorayev2494@gmail.com";
        private string phone = "095xxxxxxx";
        private string password = "secret";

        public ICommand LoginCpmmand { get; private set; }

        public string FirstName
        {
            get => this.firstName;
            set => base.SetProperty<string>(ref this.firstName, value);
        }

        public string LastName
        {
            get => this.lastName;
            set => base.SetProperty<string>(ref this.lastName, value);
        }

        public string Email
        {
            get => this.email;
            set => base.SetProperty<string>(ref this.email, value);
        }

        public string Phone
        {
            get => this.phone;
            set => base.SetProperty<string>(ref this.phone, value);
        }

        public string Password
        {
            get => this.password;
            set => base.SetProperty<string>(ref this.password, value);
        }

        public RegisterViewModel()
        {
            this.LoginCpmmand = new Command(async () => await this.Login());
        }

        private async Task Login()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
