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
        Vector2 dir;
        float speed;
        float speedY;
        float gravity = 100;

        public Bullet(Vector2 StartPos, Vector2 EndPos, float Speed)
        {
            this.speed = Speed;
            position = StartPos;

            var tmp = EndPos - StartPos;
            dir.X = tmp.X / tmp.Length();
            dir.Y = tmp.Y / tmp.Length();

            ActiveBullets.Add(this);
        }

        public void Update()
        {
            position.X += dir.X * speed * Engine.GameTimeInSec;
            position.Y += dir.Y * speed * Engine.GameTimeInSec + (speedY * Engine.GameTimeInSec);
            speedY += gravity * Engine.GameTimeInSec;
        }

        public void Draw()
        {
            Engine.SpriteBatch.Draw(Engine.BulletSheet.Texture, new Rectangle((int)position.X, (int)position.Y, 20, 10), Engine.BulletSheet.GetSprite("Bullet1"), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.5f);

        }
    }
}
