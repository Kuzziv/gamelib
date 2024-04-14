using GameEnvironment.Models;
using GameLib.CharacterFactory.Services;
using GameLib.Lootsystem.Models;
using System.Collections.Generic;

namespace CharacterFactory.Models
{
    /// <summary>
    /// Represents a base class for characters in the game.
    /// </summary>
    public abstract class CharacterBase : ISubject
    {
        /// <summary>
        /// Gets or sets the name of the character.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Gets or sets the health points of the character.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Gets or sets the attack damage of the character.
        /// </summary>
        public int AttackDamage { get; set; }

        /// <summary>
        /// Gets or sets the defense points of the character.
        /// </summary>
        public int Defense { get; set; }

        /// <summary>
        /// Gets or sets the X-coordinate of the character's position.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y-coordinate of the character's position.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the current terrain type.
        /// </summary>
        public TerrainType CurrentTerrain { get; set; } = TerrainType.Normal;

        private List<IObserver> _observers = new List<IObserver>();

        /// <summary>
        /// Gets or sets the character's inventory.
        /// </summary>
        public ILootable Inventory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterBase"/> class.
        /// </summary>
        protected CharacterBase()
        {
            Inventory = new Bag(); // Initialize Inventory as a new Bag
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterBase"/> class with specified parameters.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="health">The health points of the character.</param>
        /// <param name="attackDamage">The attack damage of the character.</param>
        /// <param name="defense">The defense points of the character.</param>
        /// <param name="x">The X-coordinate of the character's position.</param>
        /// <param name="y">The Y-coordinate of the character's position.</param>
        public CharacterBase(string name, int health, int attackDamage, int defense, int x, int y)
        {
            Name = name;
            Health = health;
            AttackDamage = attackDamage;
            Defense = defense;
            X = x;
            Y = y;
            Inventory = new Bag(); // Initialize Inventory as a new Bag
        }

        /// <summary>
        /// Attaches an observer to the subject.
        /// </summary>
        /// <param name="observer">The observer to attach.</param>
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        /// <summary>
        /// Detaches an observer from the subject.
        /// </summary>
        /// <param name="observer">The observer to detach.</param>
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        /// <summary>
        /// Notifies all observers attached to the subject.
        /// </summary>
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }

        /// <summary>
        /// Applies terrain effects to the character.
        /// </summary>
        public virtual void ApplyTerrainEffects()
        {
            switch (CurrentTerrain)
            {
                case TerrainType.Forest:
                    // Apply buffs or debuffs for characters on forest terrain
                    break;
                case TerrainType.Mountain:
                    // Apply buffs or debuffs for characters on mountain terrain
                    break;
                case TerrainType.Water:
                    // Apply buffs or debuffs for characters on water terrain
                    break;
                default:
                    // Apply default effects for characters on normal terrain
                    break;
            }
        }
    }
}