using BattleCards.Services;
using BattleCards.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardService cardService;

        public CardsController(ICardService cardService)
        {
            this.cardService = cardService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CardAddModel inputCard)
        {
            if (string.IsNullOrEmpty(inputCard.Name) || inputCard.Name.Length < 5 || inputCard.Name.Length > 15)
            {
                return this.Error("Invalid card name !");
            }

            if (string.IsNullOrEmpty(inputCard.Image))
            {
                return this.Error("The ImageUrl is required !");
            }

            if (string.IsNullOrEmpty(inputCard.Keyword))
            {
                return this.Error("The Keyword is required !");
            }

            if (inputCard.Attack < 0)
            {
                return this.Error("Attack cannot be negative!");
            }

            if (inputCard.Health < 0)
            {
                return this.Error("Health cannot be negative!");
            }

            if (string.IsNullOrEmpty(inputCard.Description) || inputCard.Description.Length>200)
            {
                return this.Error("Invalid description");
            }

            cardService.Add(inputCard);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            var cards = cardService.GetAll();

            return this.View(cards);
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View(new List<CardViewModel>());
        }
    }
}
