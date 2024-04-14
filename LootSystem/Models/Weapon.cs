using System;

namespace GameLib.Lootsystem.Models
{
    /// <summary>
    /// Represents a weapon item.
    /// </summary>
    public class Weapon : IItem
    {
        /// <summary>
        /// Gets the name of the weapon.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value of the weapon.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the weapon.</param>
        /// <param name="value">The value of the weapon.</param>
        public Weapon(string name, int value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Uses the weapon (equips it).
        /// </summary>
        public void Use()
        {
            // Implement logic to equip the weapon
        }
    }
}
