using MvvmHelpers;
using MvvmHelpers.Commands;
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
    public class HomeViewModel : CartService
    {
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products 
        { 
            get => this.products; 
            set => base.SetProperty<ObservableCollection<Product>>(ref this.products, value);
        }

        private IList<Category> categories;
        public IList<Category> Categories 
        {   
            get => this.categories;
            set => base.SetProperty<IList<Category>>(ref this.categories, value);
        }

        public ICommand SelectedCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public HomeViewModel()
        {
            this.SelectedCommand = new Xamarin.Forms.Command<Product>(async (Product product) => 
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ShowView(product), true);
            });

            this.RefreshCommand = new Xamarin.Forms.Command(async () => await this.Refresh());
        }

        public async Task SingletoneRefresh()
        {
            if (this.Categories == null || this.Products == null)
            {
                await this.Refresh();
            }
        }

        private async Task Refresh()
        {
            base.IsBusy = true;
            this.Categories = await RestApi.GET<List<Category>>("/api/categories");
            this.Products = await RestApi.GET<ObservableCollection<Product>>("/api/products");
            base.IsBusy = false;
        }
    }
}
