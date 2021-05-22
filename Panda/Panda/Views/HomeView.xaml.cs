using Panda.Models;
using Panda.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Panda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        private HomeViewModel ViewModel
        {
            get => base.BindingContext as HomeViewModel;
            set => base.BindingContext = value as HomeViewModel;
        }

        public HomeView()
        {
            this.ViewModel = new HomeViewModel();
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            this.ViewModel.RefreshCart();
            await this.ViewModel.SingletoneRefresh();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs @event)
        {
            Product selectedProduct = @event.CurrentSelection.FirstOrDefault() as Product;
            this.ViewModel.SelectedCommand?.Execute(selectedProduct);
        }
    }
}