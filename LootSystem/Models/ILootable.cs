using System.Collections.Generic;

namespace GameLib.Lootsystem.Models
{
    /// <summary>
    /// Interface representing an entity that can hold items.
    /// </summary>
    public interface ILootable
    {
        /// <summary>
        /// Adds an item to the lootable entity.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void AddItem(IItem item);

        /// <summary>
        /// Removes an item from the lootable entity.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        void RemoveItem(IItem item);

        /// <summary>
        /// Gets all items in the lootable entity.
        /// </summary>
        /// <returns>An enumerable collection of items.</returns>
        IEnumerable<IItem> GetItems();
    }
}
