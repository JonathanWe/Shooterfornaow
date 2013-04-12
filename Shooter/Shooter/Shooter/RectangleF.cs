using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shooter
{
    
    public struct RectangleF
    {

        /// <summary>
        /// RectangleF does the same as the rectangle function, only with float instead of int.
        /// </summary>

        public static implicit operator Rectangle(RectangleF value) { return new Rectangle((int)value.X, (int)value.Y, (int)value.Width, (int)value.Height); }
        public static bool operator ==(RectangleF left, RectangleF right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(RectangleF left, RectangleF right)
        {
            return !left.Equals(right);
        }

        public float X;
        public float Y;
        public float Width;
        public float Height;

        public Vector2 XY { get { return new Vector2(X, Y); } }
        public Vector2 WH { get { return new Vector2(Width, Height); } }
        public Vector4 XYWH { get { return new Vector4(X, Y, Width, Height); } }
        public bool IsNull { get { return Width <= 0 || Height <= 0; } }

        public Vector2[] Quad(Point TextureSize)
        {
            return new Vector2[] { new Vector2(X, Y) / new Vector2(TextureSize.X, TextureSize.Y), new Vector2(X, Y + Height) / new Vector2(TextureSize.X, TextureSize.Y),
                new Vector2(X + Width, Y + Height) / new Vector2(TextureSize.X, TextureSize.Y), new Vector2(X + Width, Y) / new Vector2(TextureSize.X, TextureSize.Y) };
        }
        public Vector4 TexCoord(Point TextureSize)
        { return new Vector4(X / TextureSize.X, Y / TextureSize.Y, (X + Width) / TextureSize.X, (Y + Height) / TextureSize.Y); }

        public RectangleF(float X, float Y, float Width, float Height) 
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }
        public RectangleF(Vector2 Position, Vector2 Size)
        {
            this.X = Position.X;
            this.Y = Position.Y;
            this.Width = Size.X;
            this.Height = Size.Y;
        }

        public static bool MakeInside(Vector2 Position, Vector2 Size, RectangleF Inside, RectangleF Frame, out Vector2 NewPosition, out Vector2 NewSize, out RectangleF NewFrame)
        {
            if (Position.X < Inside.X)
            {
                float outside = Inside.X - Position.X;
                float v = Frame.Width * ((Size.X - outside) / Size.X);
                Frame.X += (Frame.Width - v);
                Frame.Width = v;
                Size.X = Position.X + Size.X - Inside.X;
                Position.X = Inside.X;
            }
            if (Position.X + Size.X > Inside.X + Inside.Width)
            {
                float outside = (Position.X + Size.X) - (Inside.X + Inside.Width);
                Frame.Width = Frame.Width * ((Size.X - outside) / Size.X);
                Size.X = (Inside.X + Inside.Width) - Position.X;
            }
            if (Position.Y < Inside.Y)
            {
                float outside = Inside.Y - Position.Y;
                float v = Frame.Height * ((Size.Y - outside) / Size.Y);
                Frame.Y += (Frame.Height - v);
                Frame.Height = v;
                Size.Y = Position.Y + Size.Y - Inside.Y;
                Position.Y = Inside.Y;
            }
            if (Position.Y + Size.Y > Inside.Y + Inside.Height)
            {
                float outside = (Position.Y + Size.Y) - (Inside.Y + Inside.Height);
                Frame.Height = (int)(Frame.Height * ((Size.Y - outside) / Size.Y));
                Size.Y = (Inside.Y + Inside.Height) - Position.Y;
            }

            NewPosition = Position;
            NewSize = Size;
            NewFrame = Frame;

            if (NewSize.X > 0 && NewSize.Y > 0)
            {
                return true;
            }
            return false;
        }
        public static RectangleF Intersect(RectangleF rect1, RectangleF rect2) 
        {
            RectangleF rect;
            //X
            if (rect1.X > rect2.X)
            {
                rect.X = rect1.X;
                rect.Width = AdamoMath.SmalestValue(rect2.X - rect1.X + rect2.Width, rect1.Width);
            }
            else //rect1.X <= rect2.X
            {
                rect.X = rect2.X;
                rect.Width = AdamoMath.SmalestValue(rect1.X - rect2.X + rect1.Width, rect2.Width);
            }
            //Y
            if (rect1.Y > rect2.Y)
            {
                rect.Y = rect1.Y;
                rect.Height = AdamoMath.SmalestValue(rect2.Y - rect1.Y + rect2.Height, rect1.Height);
            }
            else //rect1.Y <= rect2.Y
            {
                rect.Y = rect2.Y;
                rect.Height = AdamoMath.SmalestValue(rect1.Y - rect2.Y + rect1.Height, rect2.Height);
            }

            return rect;
        }
        public static RectangleF? IntersectNullable(RectangleF? rect1, RectangleF? rect2)
        {
            if (!rect1.HasValue) return rect2;
            if (!rect2.HasValue) return rect1;
            return Intersect(rect1.Value, rect2.Value);
        }
    }
}
