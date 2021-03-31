using MvvmHelpers;
using Panda.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panda.ViewModels
{
    public class ShowViewModel : BaseViewModel
    {

        public Product SelectedProduct { get; private set; }

        private List<ImageSource> images = new List<ImageSource>()
        {
            ImageSource.FromFile("photo_show7.jpg"),
            ImageSource.FromFile("photo_show8.jpg"),
            ImageSource.FromFile("photo_show9.jpg"),
        };

        private string description = "A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart. I am alone, and feel the charm of existence in this spot, which was created for the bliss of souls like mine.";

        public ICommand SizeSelectedCommand { get; private set; }
        public ICommand ColorSelectedCommand { get; private set; }
        public ICommand BuyNowCommand { get; private set; }

        public ShowViewModel()
        {
            this.SizeSelectedCommand = new Command<Models.Size>(async (Models.Size s) => await this.SelectedSize(s));
            this.ColorSelectedCommand = new Command<Models.Color>(async (Models.Color color) => await this.SelectedColor(color));
            this.BuyNowCommand = new Command<Product>(async (Product product) => await this.BuyNow(this.SelectedProduct));
            
            this.SelectedProduct = new Product()
            {
                Id = 1,
                Title = "Woman T-Shirt File",
                Price = 14.00d,
                SalePrice = 13d,
                Description = this.description,
                Cover = ImageSource.FromFile("photo3.jpg"),
                Images = this.images,
                Sizes = new List<Models.Size>()
                {
                    new Models.Size() { Id = 1, Slug = "s", IsHave = true },
                    new Models.Size() { Id = 2, Slug = "M", IsHave = true },
                    new Models.Size() { Id = 3, Slug = "l", IsHave = true },
                    new Models.Size() { Id = 4, Slug = "xxl", IsHave = false }
                },
                Colors = new List<Models.Color>()
                {
                    new Models.Color() { Id = 5, Slug = Xamarin.Forms.Color.FromHex("red"), IsHave = false },
                    new Models.Color() { Id = 1, Slug = Xamarin.Forms.Color.FromHex("#667eea"), IsHave = true },
                    new Models.Color() { Id = 2, Slug = Xamarin.Forms.Color.FromHex("#bebebe"), IsHave = true },
                    new Models.Color() { Id = 3, Slug = Xamarin.Forms.Color.FromHex("yellow"), IsHave = false },
                    new Models.Color() { Id = 4, Slug = Xamarin.Forms.Color.FromHex("green"), IsHave = true },
                    new Models.Color() { Id = 5, Slug = Xamarin.Forms.Color.FromHex("blue"), IsHave = false },
                    new Models.Color() { Id = 5, Slug = Xamarin.Forms.Color.FromHex("orange"), IsHave = false },
                    new Models.Color() { Id = 5, Slug = Xamarin.Forms.Color.FromHex("black"), IsHave = false }
                }
            };
        }

        private async Task SelectedSize(Models.Size size)
        {
            await Application.Current.MainPage.DisplayAlert("Selceted size", size.Slug.ToString(), "Ok");
        }

        private async Task BuyNow(Product product)
        {
            await Application.Current.MainPage.DisplayAlert("Buy now", string.Format(product.Title.ToString() + " - " + product.Price.ToString()), "Ok");
        }

        private async Task SelectedColor(Models.Color color)
        {
            await Application.Current.MainPage.DisplayAlert("Selceted color", color.Slug.ToString(), "Ok");
        }
    }
}
