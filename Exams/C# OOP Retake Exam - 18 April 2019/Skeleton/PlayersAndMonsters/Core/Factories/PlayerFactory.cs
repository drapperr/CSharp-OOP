namespace PlayersAndMonsters.Core.Factories
{
    using Contracts;
    using Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using Repositories;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            if (type == nameof(Beginner))
            {
                return new Beginner(new CardRepository(), username);
            }
            else if (type==nameof(Advanced))
            {
                return new Advanced(new CardRepository(), username);
            }
            else
            {
                return null;
            }
        }
    }
}
