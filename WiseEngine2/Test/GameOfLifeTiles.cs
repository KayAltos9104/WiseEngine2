
using Raylib_cs;
using WiseEngine2.Engine;

namespace WiseEngine2.Test;

internal class GameOfLifeTiles : TileMap
{
    public GameOfLifeTiles(int width, int height, int size) : base(width, height, size)
    {
    }

    public override Color GetCellColor(int state)
    {
        return state == 1 ? Color.Blue : Color.White;
    }

    public override Image GetImage(int imageId)
    {
        throw new NotImplementedException();
    }
}
