using MvvmHelpers;
using Panda.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panda.ViewModels
{
    public class CartViewModel : BaseViewModel
    {

        public ObservableCollection<Product> Products { get; private set; }

        private ImageSource cover = ImageSource.FromResource("Panda.Images.photo3.jpg");
        private List<ImageSource> images = new List<ImageSource>()
        {
            ImageSource.FromResource("Panda.Images.photo_show7.jpg"),
            ImageSource.FromResource("Panda.Images.photo_show8.jpg"),
            ImageSource.FromResource("Panda.Images.photo_show9.jpg"),
        };
        private string description = "A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart. I am alone, and feel the charm of existence in this spot, which was created for the bliss of souls like mine.";

        #region Commands
        public ICommand DeleteFormCartCommand { get; private set; }
        public ICommand ProductIncrementCommand { get; private set; }
        public ICommand ProductDecrementCommand { get; private set; }
        #endregion

        public CartViewModel()
        {
            this.DeleteFormCartCommand = new Command<Product>((Product product) => this.DeleteFromCart(product));
            this.ProductDecrementCommand = new Command<Product>(async (Product product) => await this.ProductDecrement(product));
            this.ProductIncrementCommand = new Command<Product>(async (Product product) => await this.ProductIncrement(product));

            this.LoadOroducts();
        }

        private void LoadOroducts()
        {
            this.Products = new ObservableCollection<Product>()
            {
                new Product() {
                    Id = 1,
                    Title = "Woman T-Shirt File",
                    Price = 14.00d,
                    SalePrice = 13d,
                    Description = this.description,
                    Cover = ImageSource.FromFile("photo3.jpg"),
                    Images = this.images
                },
                new Product() {
                    Id = 2,
                    Title = "Black turtleneck top",
                    Price = 84.00d,
                    SalePrice = 72d,
                    Description = this.description,
                    Cover = ImageSource.FromFile("photo5.jpg"),
                    Images = this.images
                },
                new Product() {
                    Id = 3,
                    Title = "Man T-Shirt",
                    Price = 34.00d,
                    SalePrice = 30d,
                    Description = this.description,
                    Cover = ImageSource.FromFile("photo2.jpg"),
                    Images = this.images
                },
                new Product() {
                    Id = 4,
                    Title = "Blezer",
                    Price = 94.00d,
                    SalePrice = 84d,
                    Description = this.description,
                    Cover = ImageSource.FromFile("photo6.jpg"),
                    Images = this.images
                },
            };
        }

        private void DeleteFromCart(Product product)
        {
            this.Products.Remove(product);
        }

        private async Task ProductIncrement(Product product)
        {
            await Application.Current.MainPage.DisplayAlert("Increment", product.Title, "Ok");
        }

        private async Task ProductDecrement(Product product)
        {
            await Application.Current.MainPage.DisplayAlert("Decrement", product.Title, "Ok");
        }
    }
}
