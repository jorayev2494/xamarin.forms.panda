using MvvmHelpers;
using MvvmHelpers.Commands;
using Panda.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Panda.ViewModels.Addreses
{
    public class CreateAddressViewModel : BaseViewModel
    {

        public Address Address { get; set; }

        public ICommand AddAddressCommand { get; private set; }

        public CreateAddressViewModel()
        {
            this.AddAddressCommand = new Command(async () => await this.AddAddress());
        }

        private async Task AddAddress()
        {
            await App.Current.MainPage.DisplayActionSheet(
                "Title",
                "Cancel",
                "Description",
                this.Address.Name,
                this.Address.PhoneNumber,
                this.Address.PostalCode.ToString(),
                this.Address.AddressLane,
                this.Address.AddressStreet,
                this.Address.City
                );
        }


    }
}
