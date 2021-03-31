using Panda.ViewModels.Addreses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Panda.Views.Addreses
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressView : ContentPage
    {

        private AddressViewModel ViewModel
        {
            get => base.BindingContext as AddressViewModel;
            set => base.BindingContext = value as AddressViewModel;
        }

        public AddressView()
        {
            InitializeComponent();
            this.ViewModel = new AddressViewModel();
        }
    }
}