using System;
using System.Collections.Generic;

namespace GameLib.Lootsystem.Models
{
    /// <summary>
    /// Represents a bag that can contain items.
    /// </summary>
    public class Bag : ILootable
    {
        private List<IItem> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bag"/> class.
        /// </summary>
        public Bag()
        {
            items = new List<IItem>();
        }

        /// <summary>
        /// Adds an item to the bag.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void AddItem(IItem item)
        {
            items.Add(item);
        }

        /// <summary>
        /// Removes an item from the bag.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        public void RemoveItem(IItem item)
        {
            items.Remove(item);
        }

        /// <summary>
        /// Gets all items in the bag.
        /// </summary>
        /// <returns>An enumerable collection of items in the bag.</returns>
        public IEnumerable<IItem> GetItems()
        {
            return items;
        }

        /// <summary>
        /// Gets items in the bag by name.
        /// </summary>
        /// <param name="name">The name of the items to retrieve.</param>
        /// <returns>An enumerable collection of items with the specified name.</returns>
        public IEnumerable<IItem> GetItemsByName(string name)
        {
            return items.Where(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Gets the total value of all items in the bag.
        /// </summary>
        /// <returns>The total value of all items in the bag.</returns>
        public int GetTotalValue()
        {
            return items.Sum(item => item.Value);
        }

        /// <summary>
        /// Checks if the bag contains a specific item.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>True if the bag contains the item; otherwise, false.</returns>
        public bool ContainsItem(IItem item)
        {
            return items.Contains(item);
        }
    }
}
