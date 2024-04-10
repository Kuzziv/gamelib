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

        public GameService(World world, Player hero, NPC monster, ILogger logger)
        {
            _world = world;
            _hero = hero;
            _monster = monster;
            _logger = logger;
        }

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
                
            }
        }

        private bool IsPositionValid(int x, int y)
        {
            return x >= 0 && x < _world.Width && y >= 0 && y < _world.Height;
        }

        public void EnemyTurn()
        {
            // Implement enemy behavior here
            // For example, move towards the player or attack
        }
    }
}