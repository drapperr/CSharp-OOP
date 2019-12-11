using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;

            if (type + "Card" == nameof(MagicCard))
            {
                card = new MagicCard(name);
            }
            else if (type + "Card" == nameof(TrapCard))
            {
                card = new TrapCard(name);
            }

            return card;
        }
    }
}
