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
    public partial class CartView : ContentPage
    {

        public CartViewModel ViewModel 
        { 
            get => base.BindingContext as CartViewModel;
            set => base.BindingContext = value as CartViewModel;
        }

        public CartView()
        {
            InitializeComponent();
            this.ViewModel = new CartViewModel();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}