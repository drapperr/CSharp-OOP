namespace PlayersAndMonsters.Core.Factories
{
    using Contracts;
    using Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            if (type+"Card"==nameof(MagicCard))
            {
               return new MagicCard(name);
            }
            else if (type + "Card" == nameof(TrapCard))
            {
                return new TrapCard(name);
            }
            else
            {
                return null;
            }
        }
    }
}
