using MvvmHelpers;
using Newtonsoft.Json;
using Panda.Models;
using Panda.Services.HttpService;
using Panda.Services.Shop;
using Panda.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panda.ViewModels
{
    public class FeaturedViewModel : CartService
    {
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products 
        { 
            get => this.products; 
            set => base.SetProperty<ObservableCollection<Product>>(ref this.products, value);
        }

        public ICommand SelectedFeaturedCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public FeaturedViewModel()
        {
            this.SelectedFeaturedCommand = new Command<Product>(async (Product prod) => 
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ShowView(prod), true);
            });

            this.RefreshCommand = new Command(async () => await this.Refresh());
        }

        public async Task SingletoneRefresh()
        {
            if (this.Products == null)
                await this.Refresh();
        }

        private async Task Refresh()
        {
            this.IsBusy = true;
            this.Products = await RestApi.GET<ObservableCollection<Product>>("/api/products");
            this.IsBusy = false;
        }
    }
}
