using GameLib.Lootsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.LootSystem.Models
{
    /// <summary>
    /// Interface representing a composite item that can contain other items.
    /// </summary>
    public interface ICompositeItem : IItem
    {
        /// <summary>
        /// Adds an item to the composite item.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void AddItem(IItem item);

        /// <summary>
        /// Removes an item from the composite item.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        void RemoveItem(IItem item);

        /// <summary>
        /// Gets all items in the composite item.
        /// </summary>
        /// <returns>An enumerable collection of items.</returns>
        IEnumerable<IItem> GetItems();
    }
}
