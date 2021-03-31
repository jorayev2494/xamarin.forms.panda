using MvvmHelpers;
using MvvmHelpers.Commands;
using Panda.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panda.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Products
        public ObservableCollection<Product> Products { get; private set; }
        private ImageSource cover = ImageSource.FromFile("photo3.jpg");
        private List<ImageSource> images = new List<ImageSource>() 
        { 
            ImageSource.FromFile("photo_show7.jpg"),
            ImageSource.FromFile("photo_show8.jpg"),
            ImageSource.FromFile("photo_show9.jpg"),
        };
        private string description = "A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart. I am alone, and feel the charm of existence in this spot, which was created for the bliss of souls like mine.";
        #endregion

        public IList<Category> Categories { get; private set; }

        public ICommand SelectedCommand { get; private set; }
        public HomeViewModel()
        {
            this.SelectedCommand = new AsyncCommand<Product>(async (Product product) => 
            {
                await Application.Current.MainPage.DisplayAlert("Command", product.Title, "Ok");
            });

            this.Categories = new List<Category>()
            {
                new Category() { Id = 1, Title = "Woman", Color = System.Drawing.Color.Blue, Image = ImageSource.FromFile("photo.jpg") },
                new Category() { Id = 2, Title = "Man", Color = System.Drawing.Color.Red, Image = ImageSource.FromFile("photo2.jpg") },
                new Category() { Id = 3, Title = "Kids", Color = System.Drawing.Color.Green, Image = ImageSource.FromFile("photo3.jpg") },
                new Category() { Id = 4, Title = "Father", Color = System.Drawing.Color.Orange, Image = ImageSource.FromFile("photo4.jpg") }
            };

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
    }
}
