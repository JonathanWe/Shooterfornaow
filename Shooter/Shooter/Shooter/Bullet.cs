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
        Vector2 size = new Vector2(40, 10);
        public Vector2 Dir;
        float speed;
        float speedY;
        float gravity = 100;
        float damage = 1;
        Shooter shooter = ((Shooter)Engine.CurrentScene);

        public Bullet(Vector2 StartPos, Vector2 EndPos, float Speed, float Damage)
        {
            this.speed = Speed;
            position = StartPos;
            this.damage = Damage;

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

            for (int i = 0; i < shooter.Enemies.Count; i++)
            {
                if (Engine.Collide(shooter.Enemies[i].Position, shooter.Enemies[i].Size, position, size)) 
                {
                    shooter.Enemies[i].Healt -= (int)damage;
                    ActiveBullets.Remove(this);
                    break;
                }
            }
        }

        public void Draw()
        {
            float rotation = (float)Math.Atan2(Dir.Y, Dir.X);
            Engine.Camera.Draw(GameResources.BulletSheet.Texture, new Vector2(position.X, position.Y), size, GameResources.BulletSheet.GetSprite("Bullet1"), Color.White, 0.5f, Vector2.Zero, rotation);
        }
    }
}
