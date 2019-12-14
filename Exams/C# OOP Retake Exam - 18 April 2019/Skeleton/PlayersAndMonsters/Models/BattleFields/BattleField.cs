namespace PlayersAndMonsters.Models.BattleFields
{
    using System;
    using System.Linq;

    using Contracts;
    using Players;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead||enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            IncreaseIfPlayerIsBeginner(attackPlayer);
            IncreaseIfPlayerIsBeginner(enemyPlayer);

            GetBonusHealthFromCards(attackPlayer);
            GetBonusHealthFromCards(enemyPlayer);

            int attackPlayerDamage = GetPlayerDamage(attackPlayer);
            int enemyPlayerDamage = GetPlayerDamage(enemyPlayer);

            while (true)
            {
                 enemyPlayer.TakeDamage(attackPlayerDamage);
                 if (enemyPlayer.IsDead)
                 {
                     break;;
                 }

                 attackPlayer.TakeDamage(enemyPlayerDamage);
                 if (attackPlayer.IsDead)
                 {
                     break;
                 }
            }
        }

        private int GetPlayerDamage(IPlayer player)
        {
            return player.CardRepository.Cards.Sum(c => c.DamagePoints);
        }

        private void GetBonusHealthFromCards(IPlayer player)
        {
            player.Health += player.CardRepository.Cards.Sum(c => c.HealthPoints);
        }

        private void IncreaseIfPlayerIsBeginner(IPlayer player)
        {
            if (player is Beginner)
            {
                player.Health += 40;

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
