using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Shooter
{
    public static class Engine
    {
        public static IScene CurrentScene;
        public static ContentManager Content;
        public static SpriteBatch SpriteBatch;
        public static float GameTimeInSec = 0;
        public static int WindowWidth;
        public static int WindowHeight;
        public static Vector2 MousePosition;
        public static bool MouseDown;
        public static bool MouseLastDown;
        public static bool MouseClick { get { return MouseDown == false && MouseLastDown == true; } }

        public static bool Collide(Vector2 Position1, Vector2 Size1, Vector2 Position2, Vector2 Size2)
        {
            if (Position1.X + Size1.X >= Position2.X &&
                Position1.X <= Position2.X + Size2.X &&
                Position1.Y + Size1.Y >= Position2.Y &&
                Position1.Y <= Position2.Y + Size2.Y)
            {

                return true;
            }
            return false;
        }
    }
}
