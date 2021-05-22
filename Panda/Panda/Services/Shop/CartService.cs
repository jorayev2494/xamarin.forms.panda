using MvvmHelpers;
using Newtonsoft.Json;
using Panda.Models;
using Panda.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Panda.Services.Shop
{
    public class CartService : BaseViewModel, INotifyPropertyChanged
    {

        private const string PROPERTY_ADDRES_ID = "address_id";
        private const string PROPERTY_ORDERS = "orders";
        private const string PROPERTY_QUENTITY_ORDERS = "quentity_orders";
        private const string PROPERTY_SUM = "sum";

        #region Cart Properties
        private ObservableCollection<Order> orders { get; set; }

        public ObservableCollection<Order> Orders
        {
            get { return this.orders; }
            set {
                if (this.orders != value)
                {
                    this.orders = value;
                    base.OnPropertyChanged("Orders");
                }
            }
        }

        private int addressId;

        public int AddressId
        {
            get { return this.addressId; }
            set { base.SetProperty<int>(ref this.addressId, value); }
        }

        private int quantityOrders;

        public int QuantityOrders
        {
            get { return this.quantityOrders; }
            set { base.SetProperty<int>(ref this.quantityOrders, value); }
        }

        private double sum;

        public double Sum
        {
            get { return this.sum; }
            set { base.SetProperty<double>(ref this.sum, value); }
        }
        #endregion

        #region Commands
        public ICommand GoToCartCommand { get; private set; }
        public ICommand AddToCartCommand { get; private set; }
        public ICommand RemoveFromCartCommand { get; private set; }
        public ICommand ProductIcrementCommand { get; private set; }
        public ICommand ProductDecrementCommand { get; private set; }
        public ICommand ClearCartConfirmCommand { get; private set; }
        #endregion

        public CartService()
        {
            this.RefreshCart();            

            // Commands
            this.GoToCartCommand = new Command(async () => await this.GoToCart());
            this.AddToCartCommand = new Command<Product>((Product product) => this.AddToCart(product));
            this.RemoveFromCartCommand = new Command<Product>((Product product) => this.RemoveFromCart(product));
            this.ProductIcrementCommand = new Command<Product>((Product product) => this.ProductIncrement(product));
            this.ProductDecrementCommand = new Command<Product>((Product product) => this.ProductDecrement(product));
            this.ClearCartConfirmCommand = new Command(async () => await this.ClearCartConfirm());
        }

        private async Task GoToCart()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CartView(), true);
        }

        #region Mutations
        private void AddToCart(Product model)
        {
            if (!this.ProductIncrement(model))
            {
                Order makeOrder = new Order()
                {
                    Id = model.Id,
                    Product = model,
                    Price = model.Price,
                    SalePrice = model.SalePrice,
                    Quantity = 1
                };

                this.orders.Add(makeOrder);
                this.Sum += makeOrder.Product.Price;   // price;
                this.QuantityOrders++;

                // Fresh datas
                this.SetByKey(PROPERTY_QUENTITY_ORDERS, this.QuantityOrders);
                this.SaveCart();
            }

            //this.SetByKey(PROPERTY_ADDRES_ID, this.AddressId);
            //this.SetByKey(PROPERTY_ORDERS, this.orders);
            //this.SetByKey(PROPERTY_SUM, this.Sum);

            //this.SetByKey(PROPERTY_QUENTITY_ORDERS, this.QuantityOrders);
            //this.SaveCart();
        }

        private void RemoveFromCart(Product model)
        {
            Order foundOrder = this.orders.FirstOrDefault((Order odr) => odr.Id == model.Id);

            if (foundOrder is Order)
            {
                double price = foundOrder.Product.SalePrice != double.NaN
                                                            ? foundOrder.Product.SalePrice
                                                            : foundOrder.Product.Price;
                this.Sum -= foundOrder.Quantity * foundOrder.Product.Price; // price;
                this.QuantityOrders -= foundOrder.Quantity;
                this.Orders.Remove(foundOrder);
                //Application.Current.MainPage.DisplayAlert("FromDeleted count",
                //                        string.Format("Sum: {0}, QuantityOrders: {1}, Orders: {2}",
                //                        this.Sum,
                //                        this.QuantityOrders,
                //                        this.orders.Count),
                //                        "Ok");
            }

            this.SaveCart();

        }
        #endregion

        private void CalculaceCartSum()
        {
            double cartSum = 0.0;

            this.Orders.ForEach((Order odr) =>
            {
                if (odr.Product.SalePrice != double.NaN)
                    cartSum += odr.Product.SalePrice;
                else
                    cartSum += odr.Product.Price;
            });

            this.Sum = cartSum;
        }

        #region Save Phone Local

        public void RefreshCart()
        {
            this.AddressId = this.GetByKey<int>(PROPERTY_ADDRES_ID);
            this.Orders = this.GetByKey<ObservableCollection<Order>>(PROPERTY_ORDERS);
            this.QuantityOrders = this.GetByKey<int>(PROPERTY_QUENTITY_ORDERS);
            this.Sum = this.GetByKey<double>(PROPERTY_SUM);

            // this.SetByKey(PROPERTY_ADDRES_ID, this.GetByKey<int>(PROPERTY_ADDRES_ID));
            // this.SetByKey(PROPERTY_ORDERS, this.GetByKey<ObservableCollection<Order>>(PROPERTY_ORDERS));
            // this.SetByKey(PROPERTY_QUENTITY_ORDERS, this.GetByKey<int>(PROPERTY_QUENTITY_ORDERS));
            // this.SetByKey(PROPERTY_SUM, this.GetByKey<double>(PROPERTY_SUM));
        }

        private void SaveCart()
        {
            this.SetByKey(PROPERTY_ADDRES_ID, this.AddressId);
            this.SetByKey(PROPERTY_ORDERS, this.orders);
            this.SetByKey(PROPERTY_QUENTITY_ORDERS, this.QuantityOrders);
            this.SetByKey(PROPERTY_SUM, this.Sum);
        }

        public void ClearCart()
        {
            
            this.RemoveByKey(PROPERTY_ADDRES_ID);
            this.RemoveByKey(PROPERTY_ORDERS);
            this.RemoveByKey(PROPERTY_QUENTITY_ORDERS);
            this.RemoveByKey(PROPERTY_SUM);
            this.RefreshCart();
            
        }

        private void SetByKey(string key, object value)
        {
            string cartOrders = JsonConvert.SerializeObject(value);
            this.RemoveByKey(key);
            Application.Current.Properties.Add(key, cartOrders);
        }

        private T GetByKey<T>(string key) where T: new()
        {
            if (this.HasByKey(key))
            {
                string strData = (string)Application.Current.Properties[key];
                return JsonConvert.DeserializeObject<T>(strData);
            }
            else
            {
                return new T();
            }
        }

        private bool HasByKey(string key)
        {
            return Application.Current.Properties.ContainsKey(key);
        }

        private void RemoveByKey(string key)
        {
            if (this.HasByKey(key))
            {
                Application.Current.Properties.Remove(key);
            }
        }
        #endregion

        #region Icrement & Decrement
        private bool ProductIncrement(Product model)
        {
            Order foundOrder = this.orders.FirstOrDefault((Order ordr) => ordr.Id == model.Id);

            if (foundOrder is Order)
            {
                foundOrder.Quantity++;
                foundOrder.Price = foundOrder.Quantity * model.Price;
                foundOrder.SalePrice = foundOrder.Quantity * model.SalePrice;

                //double price = foundOrder.Product.SalePrice != double.NaN
                //                                            ? foundOrder.Product.SalePrice
                //                                            : foundOrder.Product.Price;
                this.Sum += foundOrder.Product.Price;   // price;

                this.QuantityOrders++;

                // Fresh datas
                this.SetByKey(PROPERTY_QUENTITY_ORDERS, this.QuantityOrders);
                this.SaveCart();

                return true;
            }

            return false;

        }

        private bool ProductDecrement(Product model)
        {
            Order foundOrder = this.orders.FirstOrDefault((Order ordr) => ordr.Id == model.Id);

            if (foundOrder is Order)
            {
                foundOrder.Quantity--;
                foundOrder.Price -= model.Price;
                foundOrder.SalePrice -= model.SalePrice;

                //double price = foundOrder.Product.SalePrice != double.NaN
                //                                            ? foundOrder.Product.SalePrice
                //                                            : foundOrder.Product.Price;
                this.Sum -= foundOrder.Product.Price;   // price;

                this.QuantityOrders--;

                // Fresh datas
                this.SetByKey(PROPERTY_QUENTITY_ORDERS, this.QuantityOrders);
                this.SaveCart();

                return true;
            }

            return false;

        }
        #endregion

        private async Task ClearCartConfirm()
        {
            bool isConfirmed = await Application.Current.MainPage.DisplayAlert("Confirm", "You want clear card?", "Yes", "No");

            if (isConfirmed) this.ClearCart();
        }

        //~CartService()
        //{
        //    Application.Current.MainPage.DisplayAlert("Destructor", "ka ka ka!", "ok");
        //}

    }
}
