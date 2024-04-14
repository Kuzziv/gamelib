using GameLib.CharacterFactory.Services;
using GameLib.Lootsystem.Models;
using System;

namespace CharacterFactory.Models
{
    /// <summary>
    /// Represents a monster character in the game, derived from the <see cref="CharacterBase"/> class.
    /// </summary>
    public class NPC : CharacterBase, IObserver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NPC"/> class with specified parameters.
        /// </summary>
        /// <param name="name">The name of the monster.</param>
        /// <param name="health">The health points of the monster.</param>
        /// <param name="attackDamage">The attack damage of the monster.</param>
        /// <param name="defense">The defense points of the monster.</param>
        /// <param name="x">The X-coordinate of the monster's position.</param>
        /// <param name="y">The Y-coordinate of the monster's position.</param>
        public NPC(string name, int health, int attackDamage, int defense, int x, int y)
            : base(name, health, attackDamage, defense, x, y)
        {
        }

        /// <summary>
        /// Moves the monster to the specified position.
        /// </summary>
        /// <param name="newX">The X-coordinate of the new position.</param>
        /// <param name="newY">The Y-coordinate of the new position.</param>
        public void Move(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }

        /// <summary>
        /// Attacks the specified enemy hero.
        /// </summary>
        /// <param name="enemy">The hero being attacked.</param>
        public void Attack(Player enemy)
        {
            int damageDealt = Math.Max(AttackDamage - enemy.Defense, 0);
            enemy.Health -= damageDealt;
            Console.WriteLine($"{Name} attacks {enemy.Name} and deals {damageDealt} damage!");
        }

        /// <summary>
        /// Updates the NPC.
        /// </summary>
        public void Update()
        {
            // Define behavior when the subject notifies the NPC
        }

        /// <summary>
        /// Uses an item.
        /// </summary>
        /// <param name="item">The item to use.</param>
        public void UseItem(IItem item)
        {
            item.Use(); // Implement logic to use the item
        }
    }
}