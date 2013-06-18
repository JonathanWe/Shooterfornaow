using System;
using System.Collections.Generic;
using System.Text;
using Adamo;

namespace Shooter
{
    public static class Engine
    {   

        /// <summary>
        /// Engine contains most of the values used to load, draw and the contentmanager. It contains classes that are needed in most of the code.
        /// </summary>
        public static IScene CurrentScene;
        public static Map Map;
        public static Shooter Game;
        public static Camera Camera = new Camera();
        public static Cursor Cursor;
        public static SpriteBatch SpriteBatch;
        public static int WindowWidth { get { return Window.Current.Width; } }
        public static int WindowHeight { get { return Window.Current.Height; } }

        /// <summary>
        /// Collition checks objects
        /// </summary>
        /// <returns>True or false wether they collide or not</returns>
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
