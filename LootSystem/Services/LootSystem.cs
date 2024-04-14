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
    }
}
