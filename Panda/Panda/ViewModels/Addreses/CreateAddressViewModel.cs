using MvvmHelpers;
using MvvmHelpers.Commands;
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
    public class CreateAddressViewModel : BaseViewModel
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set { base.SetProperty<string>(ref this.name, value); }
        }

        private string city;

        public string City
        {
            get { return this.city; }
            set { base.SetProperty<string>(ref this.city, value); }
        }

        private string addressStreet;

        public string AddressStreet
        {
            get { return this.addressStreet; }
            set { base.SetProperty<string>(ref this.addressStreet, value); }
        }

        private string addressLane;

        public string AddressLane
        {
            get { return this.addressLane; }
            set { base.SetProperty<string>(ref this.addressLane, value); }
        }

        private int postalCode;

        public int PostalCode
        {
            get { return this.postalCode; }
            set { base.SetProperty<int>(ref this.postalCode, value); }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { base.SetProperty(ref this.phoneNumber, value); }
        }

        public ICommand AddAddressCommand { get; private set; }

        public CreateAddressViewModel()
        {
            this.AddAddressCommand = new Xamarin.Forms.Command(async () => await this.AddAddress());
        }

        private async Task AddAddress()
        {
             bool isSuccess = await RestApi.POST("/api/profile/address", new Address() {
                Name = this.Name,
                City = this.City,
                AddressStreet = this.AddressStreet,
                AddressLane = this.AddressLane,
                PostalCode = this.PostalCode,
                PhoneNumber = this.PhoneNumber
            });

            if (isSuccess)
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
        }

        private void SetAddress(Address model)
        {
            this.Name = model.Name;
            this.City = model.City;
            this.AddressStreet = model.AddressStreet;
            this.AddressLane = model.AddressLane;
            this.PostalCode = model.PostalCode;
            this.PhoneNumber = model.PhoneNumber;
        }
    }
}
