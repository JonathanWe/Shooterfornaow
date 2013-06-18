using System;
using System.Collections.Generic;
using Adamo;

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

        public Bullet(Vector2 StartPos, Vector2 EndPos, float Speed, float Damage)
        {
            this.speed = Speed;
            position = StartPos;
            this.damage = Damage;

            Vector2 tmp = EndPos - StartPos;
            Dir.X = tmp.X / tmp.Length;
            Dir.Y = tmp.Y / tmp.Length;

            ActiveBullets.Add(this);
        }

        public void Update()
        {
            position.X += Dir.X * speed * (float)FrameTime.Elapsed.Seconds;
			position.Y += Dir.Y * speed * (float)FrameTime.Elapsed.Seconds + (speedY * (float)FrameTime.Elapsed.Seconds);
			speedY += gravity * (float)FrameTime.Elapsed.Seconds;

			for (int i = 0; i < Engine.Game.Characters.Count; i++)
            {
				if (Engine.Collide(Engine.Game.Characters[i].Position, Engine.Game.Characters[i].Size, position, size)) 
                {
					Engine.Game.Characters[i].Health -= (int)damage;
                    ActiveBullets.Remove(this);
                    break;
                }
            }
        }

        public void Draw()
        {
            float rotation = (float)Math.Atan2(Dir.Y, Dir.X);
            Engine.Camera.Draw(GameResources.BulletSheet.Texture, new Vector2(position.X, position.Y), size, GameResources.BulletSheet.GetSprite("Bullet1"), AlphaColor.White, 0.5f, Vector2.Zero, rotation);
        }
    }
}
