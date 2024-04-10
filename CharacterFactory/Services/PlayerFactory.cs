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
    public class PlayerFactory : ICharacterAbstractFactory
    {
        public CharacterBase CreateCharacter(string name, int health, int attackDamage, int defense, int x, int y)
        {
            return new Player(name, health, attackDamage, defense, x, y);
        }
    }
}
