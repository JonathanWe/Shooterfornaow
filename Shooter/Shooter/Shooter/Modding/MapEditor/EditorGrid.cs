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
        public Vector2 GridSize;
        Vector2 GridElementSize = new Vector2(64, 64);

        public void Draw(Camera Camer) 
        {
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
