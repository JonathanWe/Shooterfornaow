using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Shooter
{
    class CharacterSelection : IScene
    {
        Texture2D PlayerScreen1;
        Texture2D PlayerScreen2;
        Texture2D PlayerScreen3;
        
        public void Load()
        {
            PlayerScreen2 = Engine.Content.Load<Texture2D>("Player Selec Screen2");
            PlayerScreen3 = Engine.Content.Load<Texture2D>("Player Selec Screen3");
            PlayerScreen1 = PlayerScreen2;
        }

        public void Update()
        {
            if (Engine.WindowWidth / 2 > Engine.MousePosition.X)
            {
                PlayerScreen1 = PlayerScreen2;
            }
            else { PlayerScreen1 = PlayerScreen3; }
        }

        public void Draw()
        {
            Engine.SpriteBatch.Draw(PlayerScreen1, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), Color.White);
        }
    }
}
