using GameEnvironment.Models;
using CharacterFactory.Models;
using Logging.Services;

namespace Engine.Services
{
    /// <summary>
    /// Service responsible for handling game mechanics such as player movement and enemy actions.
    /// </summary>
    public class GameService
    {
        private readonly World _world;
        private readonly Player _hero;
        private readonly NPC _monster;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameService"/> class.
        /// </summary>
        /// <param name="world">The game world.</param>
        /// <param name="hero">The player character.</param>
        /// <param name="monster">The enemy character.</param>
        /// <param name="logger">The logger instance.</param>
        public GameService(World world, Player hero, NPC monster, ILogger logger)
        {
            _world = world;
            _hero = hero;
            _monster = monster;
            _logger = logger;
        }

        /// <summary>
        /// Moves the player character in the specified direction.
        /// </summary>
        /// <param name="direction">The direction of movement (W, A, S, D).</param>
        public void MovePlayer(char direction)
        {
            int newX = _hero.X;
            int newY = _hero.Y;

            switch (direction)
            {
                case 'W':
                case 'w':
                    newY--;
                    break;
                case 'S':
                case 's':
                    newY++;
                    break;
                case 'A':
                case 'a':
                    newX--;
                    break;
                case 'D':
                case 'd':
                    newX++;
                    break;
                default:
                    return; // Invalid input
            }

            if (IsPositionValid(newX, newY))
            {
                _hero.Move(newX, newY);
            }
            else
            {
                // Handle invalid movement
            }
        }

        /// <summary>
        /// Checks if the specified position is valid within the game world.
        /// </summary>
        /// <param name="x">The X-coordinate of the position.</param>
        /// <param name="y">The Y-coordinate of the position.</param>
        /// <returns>True if the position is valid; otherwise, false.</returns>
        private bool IsPositionValid(int x, int y)
        {
            return x >= 0 && x < _world.Width && y >= 0 && y < _world.Height;
        }

        /// <summary>
        /// Performs actions for the enemy character's turn.
        /// </summary>
        public void EnemyTurn()
        {
            // Implement enemy behavior here
            // For example, move towards the player or attack
        }
    }
}
