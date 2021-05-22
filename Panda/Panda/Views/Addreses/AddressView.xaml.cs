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

        protected async override void OnAppearing()
        {
            await this.ViewModel.LoadAddresses();
            base.OnAppearing();
        }

        private async void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            string content = radioButton.Content.ToString();
            await DisplayAlert("Value", string.Format("{0} - {1}", e.Value.ToString(), content), "Ok");
        }
    }
}