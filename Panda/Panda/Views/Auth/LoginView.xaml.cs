﻿using Panda.ViewModels.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Panda.Views.Auth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {

        private LoginViewModel ViewModel
        {
            get => base.BindingContext as LoginViewModel;
            set => base.BindingContext = value as LoginViewModel;
        }

        public LoginView()
        {
            this.ViewModel = new LoginViewModel();
            InitializeComponent();
        }
    }
}