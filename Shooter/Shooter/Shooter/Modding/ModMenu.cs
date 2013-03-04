using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Shooter.Modding
{
    public class ModMenu : IScene
    {
        Texture2D background;
        SpriteSheet Sheet;

        public void Load()
        {
            background = Engine.Content.Load<Texture2D>("MenuBackground");
        }
        public void Update()
        {
        }
        public void Draw()
        {
            Engine.SpriteBatch.Draw(background, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), Color.White);
        }
    }
}
