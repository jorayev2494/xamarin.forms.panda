using MvvmHelpers;
using MvvmHelpers.Commands;
using Panda.Models;
using Panda.Services.Authenticate;
using Panda.Services.HttpService;
using Panda.Views.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panda.ViewModels.Profile
{
    public class ProfileViewModel : BaseViewModel
    {
        private string firstName;

        public string FirstName
        {
            get => this.firstName;
            set => base.SetProperty<string>(ref this.firstName, value);
        }

        private string lastName;

        public string LastName
        {
            get { return this.lastName; }
            set { base.SetProperty<string>(ref this.lastName, value); }
        }

        private string email;

        public string Email
        {
            get { return this.email; }
            set { base.SetProperty<string>(ref this.email, value); }
        }

        private string avatar;

        public string Avatar
        {
            get { return this.avatar; }
            set { base.SetProperty<string>(ref this.avatar, value); }
        }

        private string phone;

        public string Phone
        {
            get { return this.phone; }
            set { base.SetProperty<string>(ref this.phone, value); }
        }


        public ICommand UpdateProfileCommand { get; set; }
        public ICommand LogoutCommand { get; set; }

        public ProfileViewModel(User profile)
        {
            this.SetProfile(profile);
            this.UpdateProfileCommand = new Xamarin.Forms.Command(async () => await this.UpdateProfile());
            this.LogoutCommand = new Xamarin.Forms.Command(async () => await Logout());
        }

        private async Task UpdateProfile()
        {
            User updatedUser = await RestApi.PUT<User>("/api/account", new User() {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Phone = this.Phone
            });

            if (updatedUser is User)
            {
                Panda.Services.Authenticate.Auth.SetAuthUser(updatedUser);
                await Application.Current.MainPage.DisplayAlert("Success", "Succesfull updated!", "Ok");
            }
        }

        private async Task Logout()  
        {
            bool isLogouted = await App.Authenticate.Logout();
            if (isLogouted)
            {
                Application.Current.MainPage = new NavigationPage(new LoginView());
            }
        }

        private void SetProfile(User model)
        {
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
            this.Email = model.Email;
            this.Avatar = model.Avatar;
            this.Phone = model.Phone;
        }
    }
}
