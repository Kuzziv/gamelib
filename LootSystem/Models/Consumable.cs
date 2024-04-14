using System;

namespace GameLib.Lootsystem.Models
{
    /// <summary>
    /// Represents a consumable item that can be used by characters.
    /// </summary>
    public class Consumable : IItem
    {
        /// <summary>
        /// Gets the name of the consumable.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value of the consumable.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Consumable"/> class.
        /// </summary>
        /// <param name="name">The name of the consumable.</param>
        /// <param name="value">The value of the consumable.</param>
        public Consumable(string name, int value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Uses the consumable.
        /// </summary>
        public void Use()
        {
            // Consume the consumable and apply its effects (e.g., heal the player)
            // Implement this method according to the specific behavior of the consumable
        }
    }
}
