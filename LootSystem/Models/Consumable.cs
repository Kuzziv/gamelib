using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Lootsystem.Models
{
    public class Consumable : IItem
    {
        public string Name { get; }
        public int Value { get; }
        public int HealingPower { get; }

        public Consumable(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public void Use()
        {
            // Consume the consumable and apply its effects (e.g., heal the player)
        }
    }
}
