﻿using WiseEngine2.Engine;

namespace WiseEngine2.Game;

public abstract class Scene
{
    public List<GameObject> GameObjects { get; private set; }
    public TileMap? Tiles { get; set; }
    public Scene ()
    {
        GameObjects = new List<GameObject> ();

    }

    public abstract void Update ();
        
}
