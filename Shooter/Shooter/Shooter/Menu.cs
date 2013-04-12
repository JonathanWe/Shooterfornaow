using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Shooter.GUI;

namespace Shooter
{
    public class Menu : IScene
    {
        Texture2D background;
        Texture2D gunShoot;
        Texture2D fadeTexture;
        Button btnPlay = new Button("PlayButton");
        Vector2 buttonPlayPosition = new Vector2(300, 250);
        Vector2 buttonPlaySize = new Vector2(300, 100);
        Vector2 gunShootSize = new Vector2(100, 100);
        Vector2 mouseClickPosition;
        float timer = 0;

        const float fadeTime = 0.3f;

        public void Load() 
        {
            background = Engine.Content.Load<Texture2D>("MenuBackground");
            gunShoot = Engine.Content.Load<Texture2D>("bullethole");
            fadeTexture = Engine.Content.Load<Texture2D>("White");

            btnPlay.Position = new Vector2(300, 250);
            btnPlay.Size = new Vector2(300, 100);
            btnPlay.Z = 0.01f;
            btnPlay.OnClick += new EventHandler(btnPlay_OnClick);
        }

        void btnPlay_OnClick(object sender, EventArgs e)
        {
            timer += 0.1f;
            mouseClickPosition = Engine.MousePosition;
        }
        public void Update() 
        {
            if (timer > fadeTime)
            {
                Engine.Game = new Shooter();
                Engine.CurrentScene = Engine.Game;
                Engine.CurrentScene.Load();
            }
            else if (timer != 0) timer += Engine.GameTimeInSec;
            else btnPlay.Update();
            if (Engine.KeyClick(Keys.F2))
            {
                Engine.CurrentScene = new Modding.ModMenu();
                Engine.CurrentScene.Load();
            }
            if (Engine.KeyClick(Keys.F3))
            {
                Engine.CurrentScene = new CharacterSelection();
                Engine.CurrentScene.Load();
            }
            if (Engine.KeyClick(Keys.F4))
            {
                Engine.CurrentScene = new CharacterCustomization(true);
                Engine.CurrentScene.Load();
            }

        }
        public void Draw() 
        {
            Engine.SpriteBatch.Draw(background, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            btnPlay.Draw();
            if (timer != 0)
            {
                Engine.SpriteBatch.Draw(gunShoot, new Rectangle((int)(mouseClickPosition.X - (gunShootSize.X / 2)), (int)(mouseClickPosition.Y - (gunShootSize.X / 2)), (int)gunShootSize.X, (int)gunShootSize.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.11f);
                Engine.SpriteBatch.Draw(fadeTexture, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), null, new Color(0, 0, 0, timer / fadeTime), 0, Vector2.Zero, SpriteEffects.None, 0.2f);
            }
        }
    }
}
