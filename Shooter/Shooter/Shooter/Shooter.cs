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

        float timer = 0;

        public void Load()
        {
            Engine.Map = new Map();
            Engine.Map.Load("test.map");
            Player.Load();
            //Enemies.Add(new Enemy());
            //Enemies[0].Load();
            bgSound.Load();
            Engine.Cursor = Cursor.GameCursor();
            Console.Write("");
        }

        public void Update()
        {
            timer += Engine.GameTimeInSec;
            if (timer > 2)
            {
                Enemies.Add(new Enemy());
                timer = 0;
            }

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
