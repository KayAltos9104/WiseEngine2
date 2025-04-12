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
        GameEngine.SceneManager.LoadScene("Game of Life", test);  
        Console.WriteLine(GameEngine.EngineLogger.GetLog());
        Console.WriteLine(GameEngine.SceneManager.SceneLogger.GetLog());
        GameEngine.RunEngine();
        GameEngine.ShutdownGraphics();
    }   
}
