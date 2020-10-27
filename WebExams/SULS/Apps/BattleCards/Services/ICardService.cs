using BattleCards.ViewModels;
using System.Collections.Generic;

namespace BattleCards.Services
{
    public interface ICardService
    {
        public int Add(CardAddModel input);

        public IEnumerable<CardViewModel> GetAll();

        public void AddCardToCollection(string userId, int cardId);

        public bool UserHasCard(string userId, int cardId);

        public IEnumerable<CardViewModel> GetMyCollection(string userId);

        public void RemoveCardFromCollection(string userId, int cardId);
    }
}
