namespace PlayersAndMonsters.Core
{
    using Contracts;
    using System.Text;
    using Common;
    using Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private readonly ICardRepository cardRepository;
        private readonly IPlayerRepository playerRepository;
        private readonly ICardFactory cardFactory;
        private readonly IPlayerFactory playerFactory;
        private readonly IBattleField battleField;

        public ManagerController()
        {
            this.cardRepository=new CardRepository();
            this.playerRepository=new PlayerRepository();
            this.cardFactory=new CardFactory();
            this.playerFactory=new PlayerFactory();
            this.battleField=new BattleField();;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);
            ICard card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackerPlayer = this.playerRepository.Find(attackUser);
            IPlayer enemyPlayer = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attackerPlayer,enemyPlayer);

            return string.Format(ConstantMessages.FightInfo, attackerPlayer.Health, enemyPlayer.Health);
        }

        public string Report()
        {
            var sb =new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health,
                    player.CardRepository.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo,card.Name,card.DamagePoints));
                }

                sb.AppendLine(string.Format(ConstantMessages.DefaultReportSeparator));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
