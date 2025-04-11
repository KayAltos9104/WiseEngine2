using Raylib_cs;
using System.Runtime.CompilerServices;
namespace WiseEngine2.Engine;

internal static class GameEngine
{
    private static bool _isInitialized = false;

    public static Logger EngineLogger = new Logger();
    public static void InitializeGraphics(int width = 800, int height = 600, int fps = 60, string title = "Wise Engine 2.0")
    {
        if (_isInitialized)
        {
            EngineLogger.AddMessage("Failure to initialize because graphics is already initialized");
        }
        else
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(fps);
            EngineLogger = new Logger();
            _isInitialized = true;
            EngineLogger.AddMessage("Graphics initialized succesfully");
        }
    }

    public static void ShutdownGraphics()
    {
        if (_isInitialized)
        {
            Raylib.CloseWindow();
            _isInitialized = false;
            EngineLogger.AddMessage("Graphics was shut down succesfully");
        }
        else
        {
            EngineLogger.AddMessage("Failure to shut down because graphics was not initialized");
        }
    }
    public static void DrawObjects(List<GameObject> objects)
    {
        if (_isInitialized==false && objects.Count <= 0)       
        {
            return;
        }
       
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);

        foreach (GameObject obj in objects)
        {
            obj.Draw();
        }

        Raylib.EndDrawing();
    }

    public static void DrawTiles (TileMap tilemap)
    {
        if (_isInitialized == false && tilemap.Map.Length <= 0)
        {
            return;
        }

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);

        for (int y = 0;  y < tilemap.Map.GetLength(1); y++)
            for (int x = 0; x < tilemap.Map.GetLength(0); x++)
            {
                Raylib.DrawRectangle(
                    x * tilemap.CellSize, y * tilemap.CellSize, 
                    tilemap.CellSize, tilemap.CellSize,
                    tilemap.GetCellColor(tilemap.Map[x,y])
                    );
            }
        Raylib.EndDrawing();
    }
}
