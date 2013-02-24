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
        Texture2D gunShoot;
        Texture2D fadeTexture;
        Vector2 buttonPlayPosition = new Vector2(300, 250);
        Vector2 buttonPlaySize = new Vector2(300, 100);
        Vector2 gunShootSize = new Vector2(100, 100);
        Vector2 mouseClickPosition;
        float timer = 0;

        const float fadeTime = 3f;

        public void Load() 
        {
            background = Engine.Content.Load<Texture2D>("MenuBackground");
            buttonPlayUp = Engine.Content.Load<Texture2D>("Menu1");
            buttonPlayOver = Engine.Content.Load<Texture2D>("Menu2");
            gunShoot = Engine.Content.Load<Texture2D>("bullethole");
            fadeTexture = Engine.Content.Load<Texture2D>("White");
        }
        public void Update() 
        {
            if (timer > fadeTime)
            {
                Engine.CurrentScene = new Shooter();
                Engine.CurrentScene.Load();
            }
            else if (timer != 0) timer += Engine.GameTimeInSec;
            else if (Engine.Collide(buttonPlayPosition, buttonPlaySize, Engine.MousePosition, new Vector2(1, 1)))
            {
                if (Engine.MouseClick)
                {
                    timer += 0.1f;
                    mouseClickPosition = Engine.MousePosition;
                }
                else buttonPlay = buttonPlayOver;
            }
            else buttonPlay = buttonPlayUp;
        }
        public void Draw() 
        {
            Engine.SpriteBatch.Draw(background, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), Color.White);
            Engine.SpriteBatch.Draw(buttonPlay, new Rectangle((int)buttonPlayPosition.X, (int)buttonPlayPosition.Y, (int)buttonPlaySize.X, (int)buttonPlaySize.Y), Color.White);
            if (timer != 0)
            {
                Engine.SpriteBatch.Draw(gunShoot, new Rectangle((int)(mouseClickPosition.X - (gunShootSize.X / 2)), (int)(mouseClickPosition.Y - (gunShootSize.X / 2)), (int)gunShootSize.X, (int)gunShootSize.Y), Color.White);
                Engine.SpriteBatch.Draw(fadeTexture, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), new Color(0, 0, 0, timer / fadeTime));
            }
        }
    }
}
