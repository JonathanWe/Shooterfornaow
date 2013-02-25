using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Shooter
{
    public class Map
    {
        Texture2D background;
        Texture2D mapTexture;

        public Rectangle[] CollisionMap;
        public Vector2 MapSize;

        public void Load(string Background, string MapTexture, Rectangle[] CollisionMap, Vector2 MapSize) 
        {
            background = Engine.Content.Load<Texture2D>(Background);
            mapTexture = Engine.Content.Load<Texture2D>(MapTexture);

            this.CollisionMap = CollisionMap;
            this.MapSize = MapSize;
        }
        public void Draw() 
        {
            Engine.SpriteBatch.Draw(background, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            Engine.SpriteBatch.Draw(mapTexture, new Rectangle(0, 0, (int)MapSize.X, (int)MapSize.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.01f);
        }

        public void UpdateCharacterCollision(Character Character) 
        {
            Rectangle rect = new Rectangle((int)Character.Position.X, (int)Character.Position.Y, (int)Character.Size.X, (int)Character.Size.Y);
            for (int i = 0; i < CollisionMap.Length; i++)
            {
                if (Rectangle.Intersect(CollisionMap[i], rect) != Rectangle.Empty) 
                {
                    Rectangle rect2 = rect;
                    rect2.Height = rect2.Height / 6;
                    rect2.X += rect2.Width / 2;
                    rect2.Width = 1;
                    if (Rectangle.Intersect(CollisionMap[i], rect2) != Rectangle.Empty) //Collides with top
                    {
                        Character.Acceleration.Y = 0;
                        Character.Position.Y = CollisionMap[i].Y + CollisionMap[i].Height;
                    }
                    rect2 = rect;
                    rect2.Y += rect2.Height - (rect2.Height / 6);
                    rect2.Height = rect2.Height / 6;
                    rect2.X += rect2.Width / 2;
                    rect2.Width = 1;
                    if (Rectangle.Intersect(CollisionMap[i], rect2) != Rectangle.Empty) //Collides with bottom
                    {
                        Character.Acceleration.Y = 0;
                        Character.Position.Y = CollisionMap[i].Y - Character.Size.Y;
                    }
                }
            }
        }
    }
}
