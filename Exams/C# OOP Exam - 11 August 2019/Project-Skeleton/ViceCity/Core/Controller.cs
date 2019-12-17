namespace ViceCity.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Guns;
    using ViceCity.Models.Guns.Contracts;
    using Models.Neghbourhoods;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using Models.Players;
    using ViceCity.Models.Players.Contracts;
    using Repositories;
    using ViceCity.Repositories.Contracts;

    public class Controller : IController
    {
        private List<IPlayer> civilPlayers;
        private readonly IPlayer mainPlayer;
        private readonly IRepository<IGun> gunRepository;
        private readonly INeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.civilPlayers = new List<IPlayer>();
            this.mainPlayer = new MainPlayer();
            this.gunRepository = new GunRepository();
            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            this.civilPlayers.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }

            if (type == "Rifle")
            {
                gun = new Rifle(name);
            }

            if (gun == null)
            {
                return "Invalid gun type!";
            }

            this.gunRepository.Add(gun);

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            IGun gun = gunRepository.Models.FirstOrDefault();
            this.gunRepository.Remove(gun);

            if (gun == null)
            {
                return "There are no guns in the queue!";
            }

            if (name == "Vercetti")
            {
                this.mainPlayer.GunRepository.Add(gun);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            IPlayer player = this.civilPlayers.FirstOrDefault(p => p.Name == name);
            
            if (player == null)
            {
                return "Civil player with that name doesn't exists!";
            }

            player.GunRepository.Add(gun);

            return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
        }

        public string Fight()
        {
            var sb = new StringBuilder();

            int mainPlayerHealth = this.mainPlayer.LifePoints;
            int totalCivilPlayersHealth = this.civilPlayers.Sum(p => p.LifePoints);

            this.gangNeighbourhood.Action(this.mainPlayer, this.civilPlayers);

            int deadPlayers = civilPlayers.Count(p => !p.IsAlive);

            this.civilPlayers = this.civilPlayers.Where(p => p.IsAlive).ToList();

            if (mainPlayerHealth == this.mainPlayer.LifePoints
                && totalCivilPlayersHealth == this.civilPlayers.Sum(p => p.LifePoints))
            {
                sb.AppendLine("Everything is okay!");
            }
            else
            {
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {deadPlayers} players!");
                sb.AppendLine($"Left Civil Players: {this.civilPlayers.Count}!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
