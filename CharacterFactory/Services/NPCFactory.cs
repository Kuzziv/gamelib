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
    /// Concrete factory for creating Monster characters.
    /// </summary>
    public class NpcFactory : ICharacterFactory
    {
        /// <summary>
        /// Creates a monster character with the specified attributes.
        /// </summary>
        /// <param name="name">The name of the monster.</param>
        /// <param name="health">The health points of the monster.</param>
        /// <param name="attackDamage">The attack damage of the monster.</param>
        /// <param name="defense">The defense points of the monster.</param>
        /// <param name="x">The X-coordinate of the monster's position.</param>
        /// <param name="y">The Y-coordinate of the monster's position.</param>
        /// <returns>The created monster character.</returns>
        public CharacterBase CreateCharacter(string name, int health, int attackDamage, int defense, int x, int y)
        {
            return new NPC(name, health, attackDamage, defense, x, y);
        }
    }
}
