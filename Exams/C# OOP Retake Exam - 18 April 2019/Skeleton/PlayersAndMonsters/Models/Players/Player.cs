﻿using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }
        public ICardRepository CardRepository { get;} //TODO

        public string Username
        {
            get => this.username;
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }

                this.health = value;
            }

        }

        public bool IsDead => this.Health == 0;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            int currentHealth = this.health;
            currentHealth -= damagePoints;

            if (currentHealth < 0)
            {
                currentHealth = 0;
            }

            this.health = currentHealth;
        }
    }
}