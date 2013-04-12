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
        Button btnPlay = new Button("Start");
        Button btnMapEditor = new Button("MapEd");
        Vector2 buttonPlayPosition = new Vector2(300, 250);
        Vector2 buttonPlaySize = new Vector2(300, 100);
        Vector2 gunShootSize = new Vector2(100, 100);
        Vector2 mouseClickPosition;
        float timer = 0;

        const float fadeTime = 0.3f;

        /// <summary>
        /// loads everything that is used in the menu
        /// </summary>
        public void Load() 
        {
            background = Engine.Content.Load<Texture2D>("MenuBackground");
            gunShoot = Engine.Content.Load<Texture2D>("bullethole");
            fadeTexture = Engine.Content.Load<Texture2D>("White");

            btnPlay.Position = new Vector2(400, 250);
            btnPlay.Size = new Vector2(250, 75);
            btnPlay.Z = 0.01f;
            btnPlay.OnClick += new EventHandler(btnPlay_OnClick);

            btnMapEditor.Position = new Vector2(400, 400);
            btnMapEditor.Size = new Vector2(250, 75);
            btnMapEditor.Z = 0.01f;
            btnMapEditor.OnClick += new EventHandler(btnMapEditor_OnClick);
        }

        /// <summary>
        /// Starts the mapeditor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnMapEditor_OnClick(object sender, EventArgs e)
        {
            Engine.CurrentScene = new Modding.MapEditor.MapEditor();
            Engine.CurrentScene.Load();
        }


        /// <summary>
        /// Starts the game
        /// </summary>
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
                Engine.CurrentScene = new CharacterSelection();
                Engine.CurrentScene.Load();
            }
            else if (timer != 0) timer += Engine.GameTimeInSec;
            else
            {
                btnPlay.Update();
                btnMapEditor.Update();
            }
            if (Engine.KeyClick(Keys.F2))
            {
                Engine.CurrentScene = new GameOver();
                Engine.CurrentScene.Load();
            }
        }

        public void Draw() 
        {
            Engine.SpriteBatch.Draw(background, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            btnPlay.Draw();
            btnMapEditor.Draw();
            if (timer != 0)
            {
                Engine.SpriteBatch.Draw(gunShoot, new Rectangle((int)(mouseClickPosition.X - (gunShootSize.X / 2)), (int)(mouseClickPosition.Y - (gunShootSize.X / 2)), (int)gunShootSize.X, (int)gunShootSize.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.11f);
                Engine.SpriteBatch.Draw(fadeTexture, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), null, new Color(0, 0, 0, timer / fadeTime), 0, Vector2.Zero, SpriteEffects.None, 0.2f);
            }
        }
    }
}
