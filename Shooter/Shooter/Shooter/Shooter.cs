using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Shooter
{
    public class Shooter : IScene
    {
        Player player = new Player();
        List<Enemy> enemies = new List<Enemy>();


        public void Load()
        {
            Engine.Map = new Map();
            Engine.Map.Load("TestBackground", "TestMap", new Rectangle[] { new Rectangle(0, Engine.WindowHeight - 45, Engine.WindowWidth, 45) }, new Vector2(Engine.WindowWidth, Engine.WindowHeight));
            player.Load();
        }

        public void Update()
        {
            player.Update();
        }

        public void Draw()
        {
            Engine.Map.Draw();
            player.Draw();
        }
    }
}
