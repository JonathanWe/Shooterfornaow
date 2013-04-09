using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Shooter
{
    class CharacterCustomization : IScene
    {
        Texture2D Background;

        public void Load()
        {

            Background = Engine.Content.Load<Texture2D>("BGCharCuz");
        }

        public void Update()
        {

        }

        public void Draw()
        {
            Engine.SpriteBatch.Draw (Background, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), Color.White);
        }
    }
}
