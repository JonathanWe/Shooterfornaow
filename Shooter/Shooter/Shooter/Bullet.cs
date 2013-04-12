using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Bullet
    {
        public static List<Bullet> ActiveBullets = new List<Bullet>();

        public static void UpdateAllBullets()
        {
            for (int i = 0; i < ActiveBullets.Count; i++)
            {
                ActiveBullets[i].Update();
            }
        }

        public static void DrawAllBullets()
        {
            for (int i = 0; i < ActiveBullets.Count; i++)
            {
                ActiveBullets[i].Draw();
            }
        }


        Vector2 position;
        public Vector2 Dir;
        float speed;
        float speedY;
        float gravity = 100;

        public Bullet(Vector2 StartPos, Vector2 EndPos, float Speed)
        {
            this.speed = Speed;
            position = StartPos;

            var tmp = EndPos - StartPos;
            Dir.X = tmp.X / tmp.Length();
            Dir.Y = tmp.Y / tmp.Length();

            ActiveBullets.Add(this);
        }

        public void Update()
        {
            position.X += Dir.X * speed * Engine.GameTimeInSec;
            position.Y += Dir.Y * speed * Engine.GameTimeInSec + (speedY * Engine.GameTimeInSec);
            speedY += gravity * Engine.GameTimeInSec;
        }

        public void Draw()
        {
            float rotation = (float)Math.Atan2(Dir.Y, Dir.X);
            Engine.Camera.Draw(Engine.BulletSheet.Texture, new Vector2(position.X, position.Y), new Vector2(40, 10), Engine.BulletSheet.GetSprite("Bullet1"), Color.White, 0.5f, Vector2.Zero, rotation);
        }
    }
}
