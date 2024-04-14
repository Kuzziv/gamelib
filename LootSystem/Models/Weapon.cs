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
        public int Value { get; }

        public Weapon(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public void Use()
        {
            // Equip the weapon
        }
    }
}
