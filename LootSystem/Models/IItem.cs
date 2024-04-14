using System;

namespace GameLib.Lootsystem.Models
{
    /// <summary>
    /// Interface representing an item that can be looted or used by characters.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the value of the item.
        /// </summary>
        int Value { get; }

        /// <summary>
        /// Uses the item.
        /// </summary>
        void Use();
    }
}
