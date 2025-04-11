using Raylib_cs;

namespace WiseEngine2.Engine;

public abstract class TileMap
{
    public int[,] Map { get; set; }
    public int CellSize { get; set; }

    public TileMap (int width, int height, int size)
    {
        Map = new int[width, height];
        CellSize = size;
    }

    public abstract Color GetCellColor(int state);

    public abstract Image GetImage(int imageId);
}
