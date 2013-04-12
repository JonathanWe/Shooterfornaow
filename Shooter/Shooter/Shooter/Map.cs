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
            Grid.DisplayGrid = false;
        }

        /// <summary>
        /// Checks if the character (enemy or player) is colliding with any texture. If yes, it will put the character back to before it collided
        /// </summary>
        /// <param name="Character">Character instance (player or enemey)</param>
        public void UpdateCharacterCollision(Character Character) 
        {
            int gridIndex = Grid.ColideWithBlock(Character.Position, Character.Size);
            //First checks if gridIndex is a posible arrayIndex, then checks if the block contains a texture
            //If it does then it means that there is a collision here(and not empty space)
            if (gridIndex != -1 && Grid.GridTexture[gridIndex] != -1)
            {
                Vector2 pos2, size2;
                pos2.X = Character.Position.X + Character.Size.X / 2;
                pos2.Y = Character.Position.Y;
                size2.X = 1;
                size2.Y = Character.Size.Y / 6;
                gridIndex = Grid.ColideWithBlock(pos2, size2);
                if (gridIndex != -1 && Grid.GridTexture[gridIndex] != -1) //Collides with top
                {
                    Character.Acceleration.Y = -1f; //-1 instead of 0 so it wont be glued to the top if the system renders to fast
                    Character.Position.Y = Grid.GetPositionFromIndex(gridIndex).Y + Grid.GridElementSize.Y;
                }
                pos2.X = Character.Position.X + (Character.Size.X / 2);
                pos2.Y = Character.Position.Y + Character.Size.Y - (Character.Size.Y / 6);
                size2.X = 1;
                size2.Y = Character.Size.Y / 6;
                gridIndex = Grid.ColideWithBlock(pos2, size2);
                if (gridIndex != -1 && Grid.GridTexture[gridIndex] != -1) //Collides with bottom
                {
                    Character.Acceleration.Y = 0;
                    Character.Position.Y = Grid.GetPositionFromIndex(gridIndex).Y - Character.Size.Y;
                }
            }
        }

        /// <summary>
        /// Draws the map 
        /// </summary>
        public void Draw() 
        {
            Grid.Draw(Engine.Camera);
        }

    }
}
