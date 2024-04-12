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
        public CharacterBase CreateCharacter(string name, int health, int attackDamage, int defense, int x, int y)
        {
            return new NPC(name, health, attackDamage, defense, x, y);
        }
    }
}
