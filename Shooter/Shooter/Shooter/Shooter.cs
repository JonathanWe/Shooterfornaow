using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Shooter
{
    public class Shooter : IScene
    {
        public Player Player = new Player();
        public List<Enemy> Enemies = new List<Enemy>();
        public BackgroundSound bgSound = new BackgroundSound();


        public void Load()
        {
            Engine.Map = new Map();
            Engine.Map.Load("TestBackground", "TestMap", new Rectangle[] { new Rectangle(0, Engine.WindowHeight - 45, Engine.WindowWidth, 45) }, new Vector2(Engine.WindowWidth, Engine.WindowHeight));
            Player.Load();
            //Enemies.Add(new Enemy());
            //Enemies[0].Load();
            bgSound.Load();
            Engine.Cursor = Cursor.GameCursor();
        }

        public void Update()
        {
            Player.Update();
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Update();
            }
            Bullet.UpdateAllBullets();
            bgSound.Update();
        }

        public void Draw()
        {
            Engine.Map.Draw();
            Player.Draw();
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Draw();
            }
            Bullet.DrawAllBullets();
        }
    }
}
