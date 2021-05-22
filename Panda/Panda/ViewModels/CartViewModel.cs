using MvvmHelpers;
using Panda.Models;
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
    public class CartViewModel : CartService
    {

        public ICommand GoToCheckoutCommand { get; private set; }

        public CartViewModel()
        {
            this.GoToCheckoutCommand = new Command(async () => await GoToChecout());
        }

        private async Task GoToChecout()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CheckoutView(), true);
        }
    }
}
