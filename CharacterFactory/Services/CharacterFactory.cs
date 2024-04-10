using System;
using System.Diagnostics;
using CharacterFactory.Models;
using Logging.Services;

namespace CharacterFactory.Services
{
    /// <summary>
    /// Factory for creating characters.
    /// </summary>
    public class CharacterFactory : ICharacterFactory
    {
        private readonly ILogger _logger;

        public CharacterFactory(ILogger logger)
        {
            _logger = logger;
        }

        public Hero CreateHero(string name, int health, int attackDamage, int defense, int x, int y)
        {
            _logger.LogInformation("Creating hero: " + name);
            return new Hero(name, health, attackDamage, defense, x, y);
        }

        public Monster CreateMonster(string name, int health, int attackDamage, int defense, int x, int y)
        {
            _logger.LogInformation("Creating monster: " + name);
            return new Monster(name, health, attackDamage, defense, x, y);
        }
    }
}