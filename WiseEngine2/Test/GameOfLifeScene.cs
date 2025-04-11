using Raylib_cs;
using WiseEngine2.Engine;
using WiseEngine2.Game;

namespace WiseEngine2.Test;

internal class GameOfLifeScene : Scene
{
    Random rand = new Random();
    private int[,] nextGrid;
    public GameOfLifeScene(int width, int height, int scale) 
    {
        Tiles = new GameOfLifeTiles(width, height, scale);
        InitializeField(0.3f);
    }

    public void InitializeField (float lifeFrac)
    {
        for (int y = 0; y < Tiles.Map.GetLength(1); y++)
            for (int x = 0; x < Tiles.Map.GetLength(0); x++)
            {
                if (rand.NextDouble() < lifeFrac)
                {
                    Tiles.Map[x, y] = 1;
                }
            }
    }

    public int CountNeighbors(int x, int y, int width, int height)
    {
        int count = 0;
        for (int ny = -1; ny <= 1; ny++)
        {
            for (int nx = -1; nx <= 1; nx++)
            {
                if (nx == 0 && ny == 0) continue;

                int cx = x + nx;
                int cy = y + ny;

                if (cx >= 0 && cx < width && cy >= 0 && cy < height && Tiles.Map[cx, cy]==1)
                    count++;
            }
        }
        return count;
    }

    public override void Update()
    {
        nextGrid = new int[Tiles.Map.GetLength(0), Tiles.Map.GetLength(1)];
        for (int y = 0; y < Tiles.Map.GetLength(1); y++)
        {
            for (int x = 0; x < Tiles.Map.GetLength(0); x++)
            {
                int neighbors = CountNeighbors(x, y, Tiles.Map.GetLength(0), Tiles.Map.GetLength(1));
                bool isAlive = Tiles.Map[x, y] == 1;

                nextGrid[x, y] = (isAlive && (neighbors == 2 || neighbors == 3)) || (!isAlive && neighbors == 3) ? 1 : 0;
            }
        }
        Array.Copy(nextGrid, Tiles.Map, Tiles.Map.GetLength(1) * Tiles.Map.GetLength(0));
    }
}
