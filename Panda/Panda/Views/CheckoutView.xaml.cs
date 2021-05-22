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
    public partial class CheckoutView : ContentPage
    {

        private CheckoutViewModel ViewModel { 
            get => base.BindingContext as CheckoutViewModel;
            set => base.BindingContext = value as CheckoutViewModel; 
        }

        public CheckoutView()
        {
            InitializeComponent();
            this.ViewModel = new CheckoutViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            this.ViewModel.RefreshCart();
            await this.ViewModel.LoadAddresses();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker senderPicker = sender as Picker;
            this.ViewModel.SelectedAddressCommand?.Execute(senderPicker.SelectedIndex);
        }
    }
}