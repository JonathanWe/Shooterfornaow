using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Shooter.GUI;

namespace Shooter
{
    class GameOver : IScene
    {
        Texture2D GameOverBackground;
        Button btnbacktoMenu = new Button("Goto");

        public void Load()
        {
            GameOverBackground = Engine.Content.Load<Texture2D>("GameOver");

            btnbacktoMenu.Position = new Vector2(400, 500);
            btnbacktoMenu.Size = new Vector2(250, 75);
            btnbacktoMenu.Z = 0.01f;
            btnbacktoMenu.OnClick += new EventHandler(btnbacktoMenu_OnClick);
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
            Engine.SpriteBatch.Draw(GameOverBackground, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight),null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            Engine.SpriteBatch.DrawString(GameResources.DefaultFont, "Your Highscore: " + Player.PlayerScore, new Vector2(300, 350), Color.Yellow, 0,Vector2.Zero, 2 ,SpriteEffects.None, 0.1f);
            btnbacktoMenu.Draw();   
            
        }
    }

}
