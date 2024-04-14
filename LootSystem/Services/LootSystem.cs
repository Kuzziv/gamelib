using GameLib.Lootsystem.Models;
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
        /// Opens a bag and displays its contents.
        /// </summary>
        /// <param name="bag">The bag to open.</param>
        public void OpenBag(Bag bag)
        {
            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag), "The bag cannot be null.");
            }

            Console.WriteLine("Opening bag...");
            foreach (var item in bag.GetItems())
            {
                Console.WriteLine($"Found {item.Name} in the bag.");
            }
        }

        /// <summary>
        /// Removes an item from a bag.
        /// </summary>
        /// <param name="bag">The bag to remove the item from.</param>
        /// <param name="item">The item to remove.</param>
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
        /// <returns>The bags containing the specified item type.</returns>
        public IEnumerable<Bag> GetBagsContainingItemType(IEnumerable<Bag> bags, Type itemType)
        {
            return bags.Where(bag => bag.GetItems().Any(item => item.GetType() == itemType));
        }

        /// <summary>
        /// Gets the bag with the highest total value.
        /// </summary>
        /// <param name="bags">The collection of bags to search.</param>
        /// <returns>The bag with the highest total value.</returns>
        public Bag GetBagWithHighestValue(IEnumerable<Bag> bags)
        {
            return bags.OrderByDescending(bag => bag.GetTotalValue()).FirstOrDefault();
        }

        /// <summary>
        /// Gets the bag with the most items.
        /// </summary>
        /// <param name="bags">The collection of bags to search.</param>
        /// <returns>The bag with the most items.</returns>
        public Bag GetBagWithMostItems(IEnumerable<Bag> bags)
        {
            return bags.OrderByDescending(bag => bag.GetItems().Count()).FirstOrDefault();
        }
    }
}
