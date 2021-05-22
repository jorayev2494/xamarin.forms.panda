using MvvmHelpers;
using Panda.Models;
using Panda.Services.HttpService;
using Panda.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Panda.ViewModels
{
    public class PaymentViewModel : BaseViewModel
    {

        private IList<Card> cards;

        public IList<Card> Cards
        {
            get { return this.cards; }
            set { base.SetProperty<IList<Card>>(ref this.cards, value); }
        }
        public IEnumerable<Card> MyCards { get; private set; }

        public ICommand GoAddCardCommand { get; set; }

        public PaymentViewModel()
        {
            this.Cards = new List<Card>();
            this.GoAddCardCommand = new Command(async () => await this.GoAddCard());

            this.MyCards = new List<Card>()
            {
                new Card() { Id = 2, Image = ImageSource.FromFile("visaCreditCard.png"), Code = "1234 5678 1234 5679", ExpiresEnd = "12/25", SecurityCode = 242, TypeCard = "visa" },
                new Card() { Id = 1, Image = ImageSource.FromFile("visaCreditCard.png"), Code = "1234 5678 1234 5678", ExpiresEnd = "10/25", SecurityCode = 245, TypeCard = "master" },
                new Card() { Id = 3, Image = ImageSource.FromFile("visaCreditCard.png"), Code = "1234 5678 1234 5680", ExpiresEnd = "10/25", SecurityCode = 245, TypeCard = "visa" }
            };
        }

        private async Task GoAddCard()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CreateCardView(), true);
        }

        public async Task LoadCards()
        {
            this.Cards.Clear();
            this.Cards = await RestApi.GET<List<Card>>("/api/profile/cards");
            this.Cards.ForEach((Card card) => card.Image = ImageSource.FromFile("visaCreditCard.png"));
        }

    }
}
