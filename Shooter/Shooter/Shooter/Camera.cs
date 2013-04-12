using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    public class Camera
    {
        public Vector2 Position;
        public float Zoom = 1;

        /// <summary>
        /// Retrieves the mouseposition
        /// </summary>
        public Vector2 MousePosition
        {
            get { return (Engine.MousePosition / Zoom) + Position; }
        }

        /// <summary>
        /// Draws texture using the parameters. 
        /// </summary>
        public void Draw(Texture2D Texture, Vector2 Position, Vector2 Size, Rectangle? Frame, Color Color, float Z) 
        {
            Draw(Texture, Position, Size, Frame, Color, Z, Vector2.Zero, 0);
        }

        /// <summary>
        /// Draws texture using the parameters. 
        /// </summary>
        public void Draw(Texture2D Texture, Vector2 Position, Vector2 Size, Rectangle? Frame, Color Color, float Z, Vector2 Origin, float Rotation)
        {
            Engine.SpriteBatch.Draw(Texture, new RectangleF((Position - this.Position) * Zoom, Size * Zoom), Frame, Color, Rotation, Origin, SpriteEffects.None, Z);
        }

        /// <summary>
        /// Draws texture using the parameters. 
        /// </summary>
        public void Draw(Texture2D Texture, Vector2 Position, Vector2 Size, Rectangle? Frame, Color Color, float Z, Vector2 Origin, float Rotation, SpriteEffects Flip)
        {
            Engine.SpriteBatch.Draw(Texture, new RectangleF((Position - this.Position) * Zoom, Size * Zoom), Frame, Color, Rotation, Origin, Flip, Z);
        }
    }
}
