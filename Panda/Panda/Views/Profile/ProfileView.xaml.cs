using Panda.Models;
using Panda.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Panda.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileView : ContentPage
    {

        public ProfileViewModel ViewModel { 
            get => base.BindingContext as ProfileViewModel;
            set => base.BindingContext = value as ProfileViewModel;
        }

        public ProfileView()
        {
            InitializeComponent();
            User authUser = Panda.Services.Authenticate.Auth.GetAuthUser();
            this.ViewModel = new ProfileViewModel(authUser);
        }
    }
}