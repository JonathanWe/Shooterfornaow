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

        public Vector2 MousePosition
        {
            get { return (Engine.MousePosition / Zoom) + Position; }
        }

        public void Draw(Texture2D Texture, Vector2 Position, Vector2 Size, Rectangle? Frame, Color Color, float Z) 
        {
            Draw(Texture, Position, Size, Frame, Color, Z, Vector2.Zero, 0);
        }
        //public void Draw(Texture2D Texture, Vector2 Position, Vector2 Size, Rectangle? Frame, Color Color, float Z, Vector2 Origin, float Rotation)
        //{
        //    Position = (Position - RenderingPosition - this.Position) * Zoom - (RenderingSize / 2 * (Zoom - 1)) + RenderingPosition;
        //    Engine.SpriteBatch.Draw(Texture, new RectangleF(Position, Size * Zoom), Frame, Color, Rotation, Origin, SpriteEffects.None, Z);
        //}
        public void Draw(Texture2D Texture, Vector2 Position, Vector2 Size, Rectangle? Frame, Color Color, float Z, Vector2 Origin, float Rotation)
        {
            Engine.SpriteBatch.Draw(Texture, new RectangleF((Position - this.Position) * Zoom, Size * Zoom), Frame, Color, Rotation, Origin, SpriteEffects.None, Z);
        }
    }
}
