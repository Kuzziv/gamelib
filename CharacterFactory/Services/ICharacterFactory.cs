using System;
using CharacterFactory.Models;

namespace CharacterFactory.Services
{

    /// <summary>
    /// Interface for creating characters in the game.
    /// </summary>
    public interface ICharacterFactory
    {
        /// <summary>
        /// Creates a character with the specified attributes.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="health">The health points of the character.</param>
        /// <param name="attackDamage">The attack damage of the character.</param>
        /// <param name="defense">The defense points of the character.</param>
        /// <param name="x">The X-coordinate of the character's position.</param>
        /// <param name="y">The Y-coordinate of the character's position.</param>
        CharacterBase CreateCharacter(string name, int health, int attackDamage, int defense, int x, int y);
    }

}