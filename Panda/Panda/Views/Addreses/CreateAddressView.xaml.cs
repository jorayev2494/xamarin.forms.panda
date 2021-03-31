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
    public partial class CreateAddressView : ContentPage
    {

        private CreateAddressViewModel ViewModel
        {
            get => base.BindingContext as CreateAddressViewModel;
            set => base.BindingContext = value as CreateAddressViewModel;
        }

        public CreateAddressView()
        {
            this.ViewModel = new CreateAddressViewModel();
            InitializeComponent();
        }
    }
}