using MvvmHelpers;
using Panda.Models;
using Panda.Services.HttpService;
using Panda.Views.Addreses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panda.ViewModels.Addreses
{
    public class AddressViewModel : BaseViewModel
    {

        private IList<Address> addreses;

        public IList<Address> Addresses
        {
            get { return this.addreses; }
            set { base.SetProperty<IList<Address>>(ref this.addreses, value); }
        }

        public ICommand GoAddAddressCommand { get; set; }

        public AddressViewModel()
        {
            this.GoAddAddressCommand = new Command(async () => await GoAddAddress());
        }

        public async Task LoadAddresses()
        {
            this.Addresses = await RestApi.GET<List<Address>>("/api/profile/address");
        }

        private async Task GoAddAddress()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CreateAddressView(), true);
        }
    }
}
