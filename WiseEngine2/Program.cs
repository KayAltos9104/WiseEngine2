using Raylib_cs;
using System.Numerics;
using System.Runtime.InteropServices;
using WiseEngine2.Engine;
using WiseEngine2.Game;
using WiseEngine2.Test;

namespace WiseEngine2;

internal class Program
{  
    
    static void Main()
    {
        Scene test = new GameOfLifeScene(160, 80, 10);
        GameEngine.InitializeGraphics(1600, 800);
        Console.WriteLine(GameEngine.EngineLogger.GetLog());
        while (!Raylib.WindowShouldClose())
        {
            test.Update();
            GameEngine.DrawTiles(test.Tiles);
        }
        GameEngine.ShutdownGraphics();
    }   
}
