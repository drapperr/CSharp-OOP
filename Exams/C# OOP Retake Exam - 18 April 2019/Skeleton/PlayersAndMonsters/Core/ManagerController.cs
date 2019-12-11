using System.Text;
using PlayersAndMonsters.Core.Factories;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.BattleFields;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core
{
    using Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        private IBattleField battleField;

        public ManagerController()
        {
            playerRepository = new PlayerRepository();
            cardRepository = new CardRepository();
            playerFactory = new PlayerFactory();
            cardFactory=new CardFactory();
            battleField=new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            var player = playerFactory.CreatePlayer(type, username);
            playerRepository.Add(player);

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            var card = cardFactory.CreateCard(type, name);
            cardRepository.Add(card);

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string userName, string cardName)
        {
            var card = cardRepository.Find(cardName);
            var player = playerRepository.Find(userName);
            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {userName}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = playerRepository.Find(attackUser);
            var enemy = playerRepository.Find(enemyUser);

            battleField.Fight(attacker, enemy);

            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(
                    $"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Cards.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
