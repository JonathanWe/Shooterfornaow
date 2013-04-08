using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    public static class Engine
    {
        public static IScene CurrentScene;
        public static Map Map;
        public static Shooter Game;
        public static Camera Camera = new Camera();
        public static Cursor Cursor;
        public static ContentManager Content;
        public static SpriteBatch SpriteBatch;
        public static GraphicsDevice Device;
        public static Texture2D WhiteTexture;
        public static SpriteSheet GUISheet;
        public static SpriteSheet BulletSheet;
        public static SpriteFont DefaultFont;
        public static float GameTimeInSec = 0;
        public static int WindowWidth { get { return Device.Viewport.Width; } }
        public static int WindowHeight { get { return Device.Viewport.Height; } }
        public static Vector2 MousePosition;
        public static bool MouseDown;
        public static bool MouseLastDown;
        public static bool MouseClick { get { return MouseDown == false && MouseLastDown == true; } }

        static internal List<Keys> keysDown = new List<Keys>();
        static internal List<Keys> keysLastDown = new List<Keys>();

        public static bool KeyDown(Keys Key) 
        {
            return keysDown.Contains(Key);
        }
        public static bool KeyClick(Keys Key) 
        {
            return !keysDown.Contains(Key) && keysLastDown.Contains(Key);
        }

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
