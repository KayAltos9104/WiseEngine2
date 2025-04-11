using System.Numerics;
using Raylib_cs;

namespace WiseEngine2.Engine;

public class GameObject
{
    public string ID { get; private set; }
    public string Name { get; set; }
    public Vector2 Pos { get; set; }    
    public Quaternion Quaternion { get; set; }
    public Vector2 Scale { get; set; }
    public GameObject(Vector2 pos, Quaternion quaternion, Vector2 scale)
    {
        ID = Guid.NewGuid().ToString();
        Pos = pos;
        Quaternion = quaternion;
        Scale = scale;
        Name = "";
    }
    public GameObject(Vector2 pos) : this (pos, Quaternion.Identity, Vector2.One)
    {
        
    }
    public virtual void Update ()
    {

    }
    public virtual void Draw ()
    {
        int x = (int)Pos.X;
        int y = (int)Pos.Y;
        Raylib.DrawRectangle(x, y, 10, 10, Color.Black);
    }
}
