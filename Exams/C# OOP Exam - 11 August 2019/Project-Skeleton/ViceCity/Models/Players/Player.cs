﻿using ViceCity.Repositories;

namespace ViceCity.Models.Players
{
    using System;
    using ViceCity.Models.Guns.Contracts;
    using Contracts;
    using ViceCity.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.GunRepository = new GunRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name), "Player's name cannot be null or a whitespace!");
                }

                this.name = value;
            }
        }

        public int LifePoints
        {
            get => this.lifePoints;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }

                this.lifePoints = value;
            }
        }

        public bool IsAlive => this.LifePoints > 0;

        public IRepository<IGun> GunRepository { get; }

        public void TakeLifePoints(int points)
        {
            this.LifePoints = Math.Max(this.LifePoints - points, 0);
        }
    }
}
