using MvvmHelpers;
using Panda.Models;
using Panda.Services.HttpService;
using Panda.Services.Shop;
using Panda.Views.Addreses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panda.ViewModels
{
    public class CheckoutViewModel : CartService
    {

        private IList<Address> addresses;

        public IList<Address> Addresses {
            get { return this.addresses; }
            set { base.SetProperty<IList<Address>>(ref this.addresses, value); }
        }
        public ICommand SelectedAddressCommand { get; set; }
        public ICommand GoToAddressCommand { get; set; }
        public ICommand SendOrderCommand { get; set; }

        public CheckoutViewModel()
        {
            this.SelectedAddressCommand = new Command<int>((int addressIndex) => this.SelectedAddress(addressIndex));
            this.GoToAddressCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new AddressView());
            });
            this.SendOrderCommand = new Command(async () => await this.SendOrder());
        }

        public async Task LoadAddresses()
        {
            this.Addresses = await RestApi.GET<List<Address>>("/api/profile/address");
        }

        private void SelectedAddress(int addressIndex)
        {
            Address selectedAddress = this.Addresses.ElementAt(addressIndex);
            Application.Current.MainPage.DisplayAlert("Selected address", selectedAddress.Name, "Ok");
            
            if (selectedAddress != null)
            {
                this.AddressId = selectedAddress.Id;
            }
        }

        private async Task SendOrder()
        {
            bool isSendOrder = await RestApi.POST("/api/carts", new {
                orders = this.Orders,
                address_id = this.AddressId,
                quantity_orders = this.QuantityOrders,
                sum = this.Sum
            });

            if (isSendOrder)
            {
                this.ClearCart();
                await Application.Current.MainPage.DisplayAlert("Success", "Orders succesfull sent!", "ok");
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }

        }


    }
}
