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
    }
}
