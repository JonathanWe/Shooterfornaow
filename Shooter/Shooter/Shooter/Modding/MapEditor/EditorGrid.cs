using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter.Modding.MapEditor
{
    public class EditorGrid
    {
        public Point GridSize;
        public Vector2 GridElementSize = new Vector2(64, 64);
        public int[] GridTexture; //This says what texture is rendered in the grid

        /// <summary>
        /// Returns inedx of the grid square the position is in
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        public int ColideWithGrid(Vector2 Position) 
        {
            int index = -1;
            for (int x = 0; x < GridSize.X; x++)
            {
                if (AdamoMath.IsBetween(x * GridElementSize.X, x * GridElementSize.X + 1, Position.X))
                {
                    index = x;
                    break;
                }
            }
            for (int y = 0; y < GridSize.Y; y++)
            {
                if (AdamoMath.IsBetween(y * GridElementSize.Y, y * GridElementSize.Y + 1, Position.Y))
                {
                    index = index + y * GridSize.X;
                }
            }
            return index;
        }

        public void Draw(Camera Camer, List<Texture2D> Textures) 
        {
            for (int i = 0; i < GridTexture.Length; i++)
            {
                if (GridTexture[i] != -1)
                {
                    int x = i % GridSize.X;
                    int y = i / GridSize.X;
                    Camer.Draw(Textures[GridTexture[i]], new Vector2(x * GridElementSize.X, y * GridElementSize.Y), GridElementSize, null, Color.White, 0.5f); 
                }
            }

            //Draws grid
            for (int x = 0; x < GridSize.X; x++)
            {
                Camer.Draw(Engine.WhiteTexture, new Vector2(0, GridElementSize.Y * x), new Vector2(GridElementSize.X * GridSize.X, 2 / Camer.Zoom), null, Color.Black, 0.51f);
            }
            for (int y = 0; y < GridSize.X; y++)
            {
                Camer.Draw(Engine.WhiteTexture, new Vector2(GridElementSize.X * y, 0), new Vector2(2 / Camer.Zoom, GridElementSize.Y * GridSize.Y), null, Color.Black, 0.51f);
            }
        }
    }
}
