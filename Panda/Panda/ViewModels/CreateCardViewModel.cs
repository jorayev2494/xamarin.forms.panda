using MvvmHelpers;
using Panda.Models;
using Panda.Services.HttpService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panda.ViewModels
{
    public class CreateCardViewModel : BaseViewModel
    {
        
        private Card card = new Card();

        public Card Card
        {
            get { return this.card; }
            set { base.SetProperty<Card>(ref this.card, value); }
        }

        public ICommand CreateCardCommand { get; private set; }

        public CreateCardViewModel()
        {
            this.CreateCardCommand = new Command(async () => await this.CreateCard());
        }

        private async Task CreateCard()
        {
            bool isCreatedCard = await RestApi.POST("/api/profile/cards", this.Card);

            if (isCreatedCard)
            {
                await Application.Current.MainPage.Navigation.PopModalAsync(true);
                await Application.Current.MainPage.DisplayAlert("Success", $"Card succesfull created \r\n [{this.Card.Code}].", "Ok");
            }
        }
    }
}
