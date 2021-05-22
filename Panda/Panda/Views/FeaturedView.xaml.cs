using Panda.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Panda.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FeaturedView : ContentPage
	{

		private FeaturedViewModel ViewModel
        {
			get => base.BindingContext as FeaturedViewModel;
			set => base.BindingContext = value as FeaturedViewModel;
		}

		public FeaturedView()
		{
			InitializeComponent();
			this.ViewModel = new FeaturedViewModel();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
			this.ViewModel.RefreshCart();
			await this.ViewModel.SingletoneRefresh();
		}
    }
}