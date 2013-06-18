using System;
using System.Collections.Generic;
using System.Text;
using Adamo;

namespace Shooter
{
    public class Cursor
    {
        private Texture2D cursorTex;
        Vector2 Size = new Vector2(32, 32);
        Vector2 Origin = new Vector2(0, 0);

        /// <summary>
        /// Loads the cursor
        /// </summary>
        /// <param name="Cursor"></param>
        public void Load(string Cursor) 
        {
			cursorTex = Texture2D.FromFile (Cursor);
        }

        /// <summary>
        /// Draws the cursor at the correct position
        /// </summary>
        public void Draw() 
        {
			Engine.SpriteBatch.Draw(cursorTex, Mouse.Position, Size, 0.9f, null, Origin * (new Vector2(cursorTex.Width, cursorTex.Height) / Size), 0, AlphaColor.White);
        }

        /// <summary>
        /// Loads the gamecursro (crosshair)
        /// </summary>
        /// <returns>returns the cursor value of crosshair</returns>
        public static Cursor GameCursor() 
        {
            Cursor cursor = new Cursor();
            cursor.Load("Content/Cursor/crosshair.png");
            return cursor;
        }

        /// <summary>
        /// Loads the menucursor
        /// </summary>
        /// <returns>Cursor with menucursor loaded</returns>
        public static Cursor MenuCursor()
        {
            Cursor cursor = new Cursor();
            cursor.Load("Content/Cursor/MenuCursor.png");
            return cursor;
        }
    }
}
