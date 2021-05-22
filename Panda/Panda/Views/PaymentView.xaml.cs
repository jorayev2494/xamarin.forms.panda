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
    public partial class PaymentView : ContentPage
    {
        private PaymentViewModel ViewModel {
            get => base.BindingContext as PaymentViewModel;
            set => base.BindingContext = value as PaymentViewModel;
        }

        public PaymentView()
        {
            InitializeComponent();
            this.ViewModel = new PaymentViewModel();
        }

        protected async override void OnAppearing()
        {
            await this.ViewModel.LoadCards();
            base.OnAppearing();
        }
    }
}