using GameLib.LootSystem.Models;
using System;
using System.Collections.Generic;

namespace GameLib.Lootsystem.Models
{
    /// <summary>
    /// Represents a bag that can contain items.
    /// </summary>
    public class Bag : ILootable, ICompositeItem
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
        /// Gets all items currently in the bag.
        /// </summary>
        /// <returns>An enumerable collection of items in the bag.</returns>
        public IEnumerable<IItem> GetItems()
        {
            return items;
        }

        /// <summary>
        /// Gets the name of the bag.
        /// </summary>
        public string Name => "Bag";

        /// <summary>
        /// Gets the total value of all items in the bag.
        /// </summary>
        public int Value => items.Sum(item => item.Value);

        /// <summary>
        /// Uses the bag.
        /// </summary>
        public void Use()
        {
            Console.WriteLine("Using Bag...");
            // Implement logic to use the bag
        }
    }
}
