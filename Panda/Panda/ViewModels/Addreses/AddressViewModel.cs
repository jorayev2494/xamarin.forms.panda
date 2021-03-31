using MvvmHelpers;
using Panda.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.ViewModels.Addreses
{
    public class AddressViewModel : BaseViewModel
    {

        public IList<Address> Addreses { get; private set; }

        public AddressViewModel()
        {
            this.Addreses = new List<Address>()
            {
                new Address() { Id = 1, Name = "Address Name", AddressStreet = "address street", AddressLane = "address lane", City = "City city", PostalCode = 1234, PhoneNumber = "+380 95 123 45 67" },
                new Address() { Id = 2, Name = "Address Name 2", AddressStreet = "address street 2", AddressLane = "address lane 2", City = "City city 2", PostalCode = 1235, PhoneNumber = "+380 95 123 45 68" },
                new Address() { Id = 3, Name = "Address Name 3", AddressStreet = "address street 3", AddressLane = "address lane 3", City = "City city 3", PostalCode = 1236, PhoneNumber = "+380 95 123 45 69" },
                new Address() { Id = 4, Name = "Address Name 4", AddressStreet = "address street 4", AddressLane = "address lane 4", City = "City city 4", PostalCode = 1237, PhoneNumber = "+380 95 123 45 70" },
                new Address() { Id = 5, Name = "Address Name 4", AddressStreet = "address street 5", AddressLane = "address lane 5", City = "City city 5", PostalCode = 1238, PhoneNumber = "+380 95 123 45 71" },
                new Address() { Id = 6, Name = "Address Name 5", AddressStreet = "address street 6", AddressLane = "address lane 6", City = "City city 6", PostalCode = 1239, PhoneNumber = "+380 95 123 45 72" }
            };
        }

    }
}
