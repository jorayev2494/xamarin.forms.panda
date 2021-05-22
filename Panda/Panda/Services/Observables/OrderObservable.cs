using MvvmHelpers;
using Newtonsoft.Json;
using Panda.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Services.Observables
{
    public class OrderObservable : ObservableObject
    {
        private int id;

        [JsonProperty("id")]
        public int Id {
            get { return this.id; }
            set { base.SetProperty<int>(ref this.id, value); }
        }

        private Product product;

        [JsonProperty("product")]
        public Product Product { 
            get { return this.product; }
            set { base.SetProperty<Product>(ref this.product, value); }
        }

        private double price;

        [JsonProperty("price")]
        public double Price {
            get { return this.price; }
            set { base.SetProperty<double>(ref this.price, value); }
        }

        private double salePrice;

        [JsonProperty("sale_price")]
        public double SalePrice { 
            get { return this.salePrice; }
            set { base.SetProperty<double>(ref this.salePrice, value); }
        }

        private int quantity;

        [JsonProperty("quantity")]
        public int Quantity 
        {
            get { return this.quantity; }
            set { base.SetProperty<int>(ref this.quantity, value); }
        }

        public OrderObservable()
        {

        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", this.Id, this.Quantity);
        }

    }
}
