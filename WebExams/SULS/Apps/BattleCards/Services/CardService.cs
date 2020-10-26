using BattleCards.Data;
using BattleCards.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BattleCards.Services
{
    public class CardService : ICardService
    {
        private readonly ApplicationDbContext db;

        public CardService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int Add(CardAddModel input)
        {
            var card = new Card
            {
                Name = input.Name,
                ImageUrl = input.Image,
                Keyword = input.Keyword,
                Attack = input.Attack,
                Health = input.Health,
                Description = input.Description
            };

            db.Cards.Add(card);
            db.SaveChanges();

            return card.Id;
        }

        public void AddCardToCollection(string userId, int cardId)
        {
            db.UserCards.Add(new UserCard
            {
                UserId = userId,
                CardId = cardId
            });
            db.SaveChanges();
        }

        public IEnumerable<CardViewModel> GetAll()
        {
            return db.Cards
                .Select(x => new CardViewModel 
                { 
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Attack =x.Attack,
                    Health = x.Health,
                    Type= x.Keyword,
                    Description =x.Description
                }).ToList();
        }

        public IEnumerable<CardViewModel> GetMyCollection(string userId)
        {
            var cards = db.UserCards
                .Where(x => x.UserId == userId)
                .Select(x => new CardViewModel 
                { 
                    Id =x.Card.Id,
                    Name = x.Card.Name,
                    Attack = x.Card.Attack,
                    Health = x.Card.Health,
                    Description = x.Card.Description,
                    ImageUrl = x.Card.ImageUrl,
                    Type = x.Card.Keyword
                }).ToList();

            return cards;
        }

        public void RemoveCardFromCollection(string userId, int cardId)
        {
            var usercard = db.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);

            if (usercard == null)
            {
                return;
            }

            db.UserCards.Remove(usercard);
            db.SaveChanges();
        }

        public bool UserHasCard(string userId, int cardId)
        {
            return db.UserCards.Any(x => x.UserId == userId && x.CardId == cardId);
        }
    }
}
