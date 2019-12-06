using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            if (type == nameof(Beginner))
            {
                return new Beginner(new CardRepository(), username);
            }
            else if (type == nameof(Advanced))
            {
                return new Advanced(new CardRepository(), username);
            }

            return null;
        }
    }
}
