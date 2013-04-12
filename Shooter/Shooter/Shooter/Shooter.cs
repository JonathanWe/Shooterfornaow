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
        Random rnd = new Random();

        /// <summary>
        /// Loads the map, the characters, music and cursor
        /// </summary>
        public void Load()
        {
            Engine.Map = new Map();
            Engine.Map.Load("test.map");
            Player.Load();
            bgSound.Load();
            Engine.Cursor = Cursor.GameCursor();
        }

        /// <summary>
        /// Updatesthe players and enemies. Spawning a new enemy every 2 seconds
        /// </summary>
        public void Update()
        {
            timer += Engine.GameTimeInSec;
            if (timer > 2)
            {
                int enemyType = rnd.Next(4);
                if (enemyType == 0)
                    Enemies.Add(new Enemy(Character.Enemy1()));
                else if (enemyType == 1)
                    Enemies.Add(new Enemy(Character.Enemy2()));
                else if (enemyType == 2)
                    Enemies.Add(new Enemy(Character.Enemy3()));
                else if (enemyType == 3)
                    Enemies.Add(new Enemy(Character.Enemy4()));
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

        /// <summary>
        /// Draw the maps, characters and bullets
        /// </summary>
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
