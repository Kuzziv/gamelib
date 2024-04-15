using GameLib.Lootsystem.Models;
using GameLib.LootSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLib.Lootsystem.Services
{
    /// <summary>
    /// Service for managing loot and bags.
    /// </summary>
    public class LootSystem
    {
        /// <summary>
        /// Opens a composite item and displays its contents.
        /// </summary>
        /// <param name="compositeItem">The composite item to open.</param>
        public void OpenBag(ICompositeItem compositeItem)
        {
            if (compositeItem == null)
            {
                throw new ArgumentNullException(nameof(compositeItem), "The composite item cannot be null.");
            }

            Console.WriteLine("Opening composite item...");
            foreach (var item in compositeItem.GetItems())
            {
                Console.WriteLine($"Found {item.Name} in the composite item.");
            }
        }

        /// <summary>
        /// Removes an item from a bag.
        /// </summary>
        /// <param name="bag">The bag from which to remove the item.</param>
        /// <param name="item">The item to remove.</param>
        /// <exception cref="ArgumentNullException">Thrown when the bag or item is null.</exception>
        public void RemoveItemFromBag(Bag bag, IItem item)
        {
            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag), "The bag cannot be null.");
            }

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "The item cannot be null.");
            }

            bag.RemoveItem(item);
        }

        /// <summary>
        /// Gets bags containing a specific type of item.
        /// </summary>
        /// <param name="bags">The collection of bags to search.</param>
        /// <param name="itemType">The type of item to search for.</param>
        /// <returns>An enumerable collection of bags containing the specified type of item.</returns>
        public IEnumerable<Bag> GetBagsContainingItemType(IEnumerable<Bag> bags, Type itemType)
        {
            return bags.Where(bag => bag.GetItems().Any(item => item.GetType() == itemType));
        }

        /// <summary>
        /// Gets the bag with the highest total value of items.
        /// </summary>
        /// <param name="bags">The collection of bags to search.</param>
        /// <returns>The bag with the highest total value of items, or null if no bags are provided.</returns>
        public Bag GetBagWithHighestValue(IEnumerable<Bag> bags)
        {
            return bags.OrderByDescending(bag => bag.Value).FirstOrDefault();
        }

        /// <summary>
        /// Gets the bag with the most items.
        /// </summary>
        /// <param name="bags">The collection of bags to search.</param>
        /// <returns>The bag with the most items, or null if no bags are provided.</returns>
        public Bag GetBagWithMostItems(IEnumerable<Bag> bags)
        {
            return bags.OrderByDescending(bag => bag.GetItems().Count()).FirstOrDefault();
        }
    }
}
