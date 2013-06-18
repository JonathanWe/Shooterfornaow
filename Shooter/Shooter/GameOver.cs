using System;
using System.Collections.Generic;
using System.Text;
using Shooter.GUI;
using Adamo;

namespace Shooter
{
    class GameOver : IScene
    {
        Texture2D GameOverBackground;
		Texture2D highscoreText;
        GUI.Button btnbacktoMenu = new GUI.Button("Goto");

        public void Load()
        {
            GameOverBackground = Texture2D.FromFile("Content/GameOver.png");

            btnbacktoMenu.Position = new Vector2(400, 500);
            btnbacktoMenu.Size = new Vector2(250, 75);
            btnbacktoMenu.Z = 0.01f;
            btnbacktoMenu.OnClick += new EventHandler(btnbacktoMenu_OnClick);

			highscoreText = GameResources.DefaultFont.Draw ("Your Highscore: " + Player.PlayerScore);
        }     

        void btnbacktoMenu_OnClick(object sender, EventArgs e)
        {
            Engine.CurrentScene = new Menu();
            Engine.CurrentScene.Load();
        }

        public void Update()
        {
            btnbacktoMenu.Update();
        }

        public void Draw()
        {
            Engine.SpriteBatch.Draw(GameOverBackground, new Vector2(0, 0), new Vector2(Engine.WindowWidth, Engine.WindowHeight), 0);
            Engine.SpriteBatch.Draw(highscoreText, new Vector2(300, 350), highscoreText.Size, 0.1f, null, Vector2.Zero, 0, AlphaColor.Yellow);
            btnbacktoMenu.Draw();   
            
        }
    }

}
