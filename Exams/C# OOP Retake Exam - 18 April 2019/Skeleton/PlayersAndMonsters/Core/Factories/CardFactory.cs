using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            if (type + "Card" == nameof(MagicCard))
            {
                return new MagicCard(name);
            }
            else if (type + "Card" == nameof(TrapCard))
            {
                return new TrapCard(name);
            }

            return null;
        }
    }
}
