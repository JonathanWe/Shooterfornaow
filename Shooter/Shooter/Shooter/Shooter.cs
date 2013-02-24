using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    public class Shooter : IScene
    {
        Texture2D background;
        Player player = new Player();
        List<Enemy> enemies = new List<Enemy>();


        public void Load()
        {
            player.Load();
        }

        public void Update()
        {
            player.Update();
        }

        public void Draw()
        {
            player.Draw();
        }
    }
}
