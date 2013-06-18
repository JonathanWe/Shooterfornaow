using System;
using System.Collections.Generic;
using Adamo;

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
            get { return ((Vector2)Mouse.Position) / Zoom + Position; }
        }

        /// <summary>
        /// Draws texture using the parameters. 
        /// </summary>
        public void Draw(Texture2D Texture, Vector2 Position, Vector2 Size, Rectangle? Frame, AlphaColor Color, float Z) 
        {
            Draw(Texture, Position, Size, Frame, Color, Z, Vector2.Zero, 0);
        }

        /// <summary>
        /// Draws texture using the parameters. 
        /// </summary>
        public void Draw(Texture2D Texture, Vector2 Position, Vector2 Size, Rectangle? Frame, AlphaColor Color, float Z, Vector2 Origin, float Rotation)
        {
            Engine.SpriteBatch.Draw(Texture, (Position - this.Position) * Zoom, Size * Zoom, Z, Frame, Origin, Rotation, Color);
        }

        /// <summary>
        /// Draws texture using the parameters. 
        /// </summary>
        public void Draw(Texture2D Texture, Vector2 Position, Vector2 Size, Rectangle? Frame, AlphaColor Color, float Z, Vector2 Origin, float Rotation, bool FlipX, bool FlipY)
        {
			Engine.SpriteBatch.Draw(Texture, (Position - this.Position) * Zoom, Size * Zoom, Z, Frame, Origin, Rotation, Color, FlipX, FlipY);
		}
    }
}
