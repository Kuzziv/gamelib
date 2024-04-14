using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Lootsystem.Models
{
    public class Weapon : IItem
    {
        public string Name { get; }
        // Other properties and methods specific to weapons

        public Weapon(string name)
        {
            Name = name;
        }

        public void Use()
        {
            // Equip the weapon
        }
    }
}
