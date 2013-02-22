using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Shooter
{
    public class Menu : IScene
    {
        Texture2D background;
        Texture2D buttonPlay;
        Texture2D buttonPlayUp;
        Texture2D buttonPlayOver;
        Texture2D buttonPlayDown;
        Vector2 buttonPlayPosition;
        Vector2 buttonPlaySize;

        public void Load() 
        {

        }
        public void Update() 
        {
            if (Engine.Collide(buttonPlayPosition, buttonPlaySize, Engine.MousePosition, new Vector2(1, 1))) 
            {
                if (Engine.MouseClick)
                {
                    Engine.CurrentScene = new Shooter();
                    Engine.CurrentScene.Load();
                }
                else if (Engine.MouseDown) buttonPlay = buttonPlayDown;
                else buttonPlay = buttonPlayOver;
            }
        }
        public void Draw() 
        {
            Engine.SpriteBatch.Draw(background, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowWidth), Color.White);
            Engine.SpriteBatch.Draw(buttonPlay, new Rectangle((int)buttonPlayPosition.X, (int)buttonPlayPosition.Y, (int)buttonPlaySize.X, (int)buttonPlaySize.Y), Color.White);
        }
    }
}
