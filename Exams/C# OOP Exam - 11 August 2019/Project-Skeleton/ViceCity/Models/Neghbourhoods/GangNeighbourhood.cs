namespace ViceCity.Models.Neghbourhoods
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var gun in mainPlayer.GunRepository.Models)
            {
                foreach (var civilPlayer in civilPlayers)
                {
                    while (civilPlayer.IsAlive && gun.CanFire)
                    {
                        civilPlayer.TakeLifePoints(gun.Fire());
                    }
                }
            }

            foreach (var player in civilPlayers.Where(p => p.IsAlive))
            {
                foreach (var gun in player.GunRepository.Models)
                {
                    while (gun.CanFire&& mainPlayer.IsAlive)
                    {
                        mainPlayer.TakeLifePoints(gun.Fire());
                    }
                }
            }
        }
    }
}
