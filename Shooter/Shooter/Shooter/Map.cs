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
        public MapGrid Grid = new MapGrid();
        public void Load(string File) 
        {
            Grid.LoadMap(File);
        }

        public void UpdateCharacterCollision(Character Character) 
        {
            int gridIndex = Grid.ColideWithGrid(Character.Position, Character.Size);
            //First checks if gridIndex is a posible arrayIndex, then checks if the block contains a texture
            //If it does then it means that there is a collision here(and not empty space)
            if (gridIndex != -1 && Grid.GridTexture[gridIndex] != -1)
            {
                Vector2 pos2, size2;
                pos2.X = Character.Position.X + Character.Size.X / 2;
                pos2.Y = Character.Position.Y;
                size2.X = 1;
                size2.Y = Character.Size.Y / 6;
                gridIndex = Grid.ColideWithGrid(pos2, size2);
                if (gridIndex != -1 && Grid.GridTexture[gridIndex] != -1) //Collides with top
                {
                    Character.Acceleration.Y = -1f; //-1 instead of 0 so it wont be glued to the top if the system renders to fast
                    Character.Position.Y = Grid.GetPositionFromIndex(gridIndex).Y + Grid.GridElementSize.Y;
                }
                pos2.X = Character.Position.X + Character.Size.X / 2;
                pos2.Y = Character.Position.X + Character.Size.Y - (Character.Size.Y / 6);
                size2.X = 1;
                size2.Y = Character.Size.Y / 6;
                gridIndex = Grid.ColideWithGrid(pos2, size2);
                if (gridIndex != -1 && Grid.GridTexture[gridIndex] != -1) //Collides with bottom
                {
                    Character.Acceleration.Y = 0;
                    Character.Position.Y = Grid.GetPositionFromIndex(gridIndex).Y - Character.Size.Y;
                }
            }
        }
        public void Draw() 
        {
            Grid.Draw(Engine.Camera);
        }



        //Texture2D background;
        //Texture2D mapTexture;
        //MapGrid grid = new MapGrid();

        //public void Load(string Background, string MapTexture, Rectangle[] CollisionMap, Vector2 MapSize) 
        //{
        //    background = Engine.Content.Load<Texture2D>(Background);
        //    mapTexture = Engine.Content.Load<Texture2D>(MapTexture);

        //    this.CollisionMap = CollisionMap;
        //    this.MapSize = MapSize;
        //}
        //public void Draw() 
        //{
        //    Engine.SpriteBatch.Draw(background, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
        //    Engine.SpriteBatch.Draw(mapTexture, new Rectangle(0, 0, (int)MapSize.X, (int)MapSize.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.01f);
        //}

        //public void UpdateCharacterCollision(Character Character) 
        //{
        //    Rectangle rect = new Rectangle((int)Character.Position.X, (int)Character.Position.Y, (int)Character.Size.X, (int)Character.Size.Y);
        //    for (int i = 0; i < CollisionMap.Length; i++)
        //    {
        //        if (Rectangle.Intersect(CollisionMap[i], rect) != Rectangle.Empty) 
        //        {
        //            Rectangle rect2 = rect;
        //            rect2.Height = rect2.Height / 6;
        //            rect2.X += rect2.Width / 2;
        //            rect2.Width = 1;
        //            if (Rectangle.Intersect(CollisionMap[i], rect2) != Rectangle.Empty) //Collides with top
        //            {
        //                Character.Acceleration.Y = 0;
        //                Character.Position.Y = CollisionMap[i].Y + CollisionMap[i].Height;
        //            }
        //            rect2 = rect;
        //            rect2.Y += rect2.Height - (rect2.Height / 6);
        //            rect2.Height = rect2.Height / 6;
        //            rect2.X += rect2.Width / 2;
        //            rect2.Width = 1;
        //            if (Rectangle.Intersect(CollisionMap[i], rect2) != Rectangle.Empty) //Collides with bottom
        //            {
        //                Character.Acceleration.Y = 0;
        //                Character.Position.Y = CollisionMap[i].Y - Character.Size.Y;
        //            }
        //        }
        //    }
        //}
    }
}
