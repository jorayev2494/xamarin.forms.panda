using MvvmHelpers;
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
    public partial class CreateCardView : ContentPage
    {

        private CreateCardViewModel ViewModel
        {
            get { return base.BindingContext as CreateCardViewModel; }
            set { base.BindingContext = value as CreateCardViewModel; }
        }

        public CreateCardView()
        {
            this.ViewModel = new CreateCardViewModel();
            InitializeComponent();
        }
    }
}