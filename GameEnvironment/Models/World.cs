using System;

namespace GameEnvironment.Models
{
    /// <summary>
    /// Represents the world in which the game takes place.
    /// </summary>
    public class World
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public TerrainType[,] Terrain { get; private set; }

        public World(int width, int height)
        {
            Width = width;
            Height = height;
            Terrain = new TerrainType[Width, Height];
        }

        public void GenerateTerrain()
        {
            // Implement terrain generation logic here
            // For simplicity, let's fill the terrain with random terrain types
            Random random = new Random();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Terrain[x, y] = (TerrainType)random.Next(Enum.GetValues(typeof(TerrainType)).Length);
                }
            }
        }

        public void RenderTerrain()
        {
            // Output the terrain to the console with colors but without symbols
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    // Set console color based on terrain type
                    ConsoleColor color = GetColorForTerrain(Terrain[x, y]);
                    Console.ForegroundColor = color;

                    // Output empty square brackets for each cell
                    Console.Write("[ ]");
                }
                // Reset console color
                Console.ResetColor();

                // Move to the next line for the next row of terrain
                Console.WriteLine();
            }
        }

        private ConsoleColor GetColorForTerrain(TerrainType terrainType)
        {
            // Define colors for each terrain type
            switch (terrainType)
            {
                case TerrainType.Grass:
                    return ConsoleColor.Green;
                case TerrainType.Forest:
                    return ConsoleColor.DarkGreen;
                case TerrainType.Mountain:
                    return ConsoleColor.Gray;
                case TerrainType.Water:
                    return ConsoleColor.Blue;
                default:
                    return ConsoleColor.White; // Default color
            }
        }
    }
}
