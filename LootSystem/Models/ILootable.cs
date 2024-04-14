using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Lootsystem.Models
{
    public interface ILootable
    {
        void AddItem(IItem item);
        void RemoveItem(IItem item);
        IEnumerable<IItem> GetItems();
    }
}
