using CharacterFactory.Models;
using CharacterFactory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.CharacterFactory.Services
{
    /// <summary>
    /// Concrete factory for creating Hero characters.
    /// </summary>
    public class PlayerFactory : ICharacterFactory
    {
        /// <summary>
        /// Creates a hero character with the specified attributes.
        /// </summary>
        /// <param name="name">The name of the hero.</param>
        /// <param name="health">The health points of the hero.</param>
        /// <param name="attackDamage">The attack damage of the hero.</param>
        /// <param name="defense">The defense points of the hero.</param>
        /// <param name="x">The X-coordinate of the hero's position.</param>
        /// <param name="y">The Y-coordinate of the hero's position.</param>
        /// <returns>The created hero character.</returns>
        public CharacterBase CreateCharacter(string name, int health, int attackDamage, int defense, int x, int y)
        {
            return new Player(name, health, attackDamage, defense, x, y);
        }
    }
}
