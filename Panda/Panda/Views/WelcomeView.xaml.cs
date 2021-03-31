using Panda.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Panda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomeView : ContentPage
    {
        private WelcomeViewModel ViewModel
        {
            get => base.BindingContext as WelcomeViewModel;
            set => base.BindingContext = value as WelcomeViewModel;
        }

        public WelcomeView()
        {
            InitializeComponent();
            this.ViewModel = new WelcomeViewModel();
        }
    }
}