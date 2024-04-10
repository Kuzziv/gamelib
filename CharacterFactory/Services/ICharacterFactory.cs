using System;
using CharacterFactory.Models;

namespace CharacterFactory.Services
{

    /// <summary>
    /// Interface for creating characters in the game.
    /// </summary>
    public interface ICharacterFactory
    {
        Hero CreateHero(string name, int health, int attackDamage, int defense, int x, int y);
        Monster CreateMonster(string name, int health, int attackDamage, int defense, int x, int y);

    }

}