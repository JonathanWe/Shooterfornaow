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
<<<<<<< HEAD
        public Cursor Cursor = new Cursor();
        public BackgroundSound bgSound = new BackgroundSound();
=======
>>>>>>> Changes for 07.03.2013


        public void Load()
        {
            Engine.Map = new Map();
            Engine.Map.Load("TestBackground", "TestMap", new Rectangle[] { new Rectangle(0, Engine.WindowHeight - 45, Engine.WindowWidth, 45) }, new Vector2(Engine.WindowWidth, Engine.WindowHeight));
            Player.Load();
            //Enemies.Add(new Enemy());
            //Enemies[0].Load();
<<<<<<< HEAD
            bgSound.Load();
            Cursor.Load();
=======
            Engine.Cursor = Cursor.GameCursor();
>>>>>>> Changes for 07.03.2013
        }

        public void Update()
        {
            Player.Update();
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Update();
            }
<<<<<<< HEAD
            bgSound.Update();
            Cursor.Update();
=======
>>>>>>> Changes for 07.03.2013
        }

        public void Draw()
        {
            Engine.Map.Draw();
            Player.Draw();
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Draw();
            }
        }
    }
}
