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
	public partial class ShowView : ContentPage
	{
		private ShowViewModel ViewModel
        {
			get => base.BindingContext as ShowViewModel;
			set => base.BindingContext = value as ShowViewModel;
		}

		public ShowView(Product model)
		{
			InitializeComponent();
			this.ViewModel = new ShowViewModel(model);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			this.ViewModel.RefreshCart();
        }
    }
}