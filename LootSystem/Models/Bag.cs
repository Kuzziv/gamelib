using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Lootsystem.Models
{
    public class Bag : ILootable
    {
        private List<IItem> items;

        public Bag()
        {
            items = new List<IItem>();
        }

        public void AddItem(IItem item)
        {
            items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            items.Remove(item);
        }

        public IEnumerable<IItem> GetItems()
        {
            return items;
        }

        public IEnumerable<IItem> GetItemsByName(string name)
        {
            return items.Where(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Example: Get the total value of all items in the bag
        public int GetTotalValue()
        {
            return items.Sum(item => item.Value);
        }

        // Example: Check if the bag contains a specific item
        public bool ContainsItem(IItem item)
        {
            return items.Contains(item);
        }

    }
}
