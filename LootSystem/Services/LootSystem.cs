using GameLib.Lootsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Lootsystem.Services
{
    public class LootSystem
    {
        public void OpenBag(Bag bag)
        {
            Console.WriteLine("Opening bag...");
            foreach (var item in bag.GetItems())
            {
                Console.WriteLine($"Found {item.Name} in the bag.");
            }
        }

        public IEnumerable<Bag> GetBagsContainingItemType(IEnumerable<Bag> bags, Type itemType)
        {
            return bags.Where(bag => bag.GetItems().Any(item => item.GetType() == itemType));
        }

        // Example: Get the bag with the highest total value
        public Bag GetBagWithHighestValue(IEnumerable<Bag> bags)
        {
            return bags.OrderByDescending(bag => bag.GetTotalValue()).FirstOrDefault();
        }

        // Example: Get the bag with the most items
        public Bag GetBagWithMostItems(IEnumerable<Bag> bags)
        {
            return bags.OrderByDescending(bag => bag.GetItems().Count()).FirstOrDefault();
        }
    }
}
