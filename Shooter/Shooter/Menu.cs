using System;
using System.Collections.Generic;
using System.Text;
using Adamo;
using Shooter.GUI;

namespace Shooter
{
    public class Menu : IScene
    {
        Texture2D background;
        Texture2D gunShoot;
        Texture2D fadeTexture;
        GUI.Button btnPlay = new GUI.Button("Start");
        GUI.Button btnMapEditor = new GUI.Button("MapEd");
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
			background = Texture2D.FromFile("Content/MenuBackground.png");
			gunShoot = Texture2D.FromFile("Content/bullethole.png");
            fadeTexture = Texture2D.WhiteTexture();

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
            mouseClickPosition = Mouse.Position;
        }

        public void Update() 
        {
            if (timer > fadeTime)
            {
                Engine.Game = new Shooter();
                Engine.CurrentScene = new CharacterSelection();
                Engine.CurrentScene.Load();
            }
			else if (timer != 0) timer += (float)FrameTime.Elapsed.Seconds;
            else
            {
                btnPlay.Update();
                btnMapEditor.Update();
            }
            if (Window.Current.Keyboard.KeyClick(Keys.F2))
            {
                Engine.CurrentScene = new GameOver();
                Engine.CurrentScene.Load();
            }
        }

        public void Draw() 
        {
            Engine.SpriteBatch.Draw(background, new Vector2(0, 0), new Vector2(Engine.WindowWidth, Engine.WindowHeight), 0, null, Vector2.Zero, 0, AlphaColor.White);
            btnPlay.Draw();
            btnMapEditor.Draw();
            if (timer != 0)
            {
                Engine.SpriteBatch.Draw(gunShoot, new Vector2((int)(mouseClickPosition.X - (gunShootSize.X / 2)), (int)(mouseClickPosition.Y - (gunShootSize.X / 2))), new Vector2((int)gunShootSize.X, (int)gunShootSize.Y), 0.11f, null, Vector2.Zero, 0, AlphaColor.White);
                Engine.SpriteBatch.Draw(fadeTexture, new Vector2(0, 0), new Vector2(Engine.WindowWidth, Engine.WindowHeight), 0.2f, null, Vector2.Zero, 0, new AlphaColor(0, 0, 0, timer / fadeTime));
            }
        }
    }
}
