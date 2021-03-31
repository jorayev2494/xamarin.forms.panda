using MvvmHelpers;
using MvvmHelpers.Commands;
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
        public ICommand GoToLoginViewCommand { get; private set; }

        public WelcomeViewModel()
        {
            this.GoToLoginViewCommand = new Command(() => App.Current.MainPage.Navigation.PushAsync(new LoginView(), true));
            App.Current.MainPage = new HomeView();
        }

    }
}
