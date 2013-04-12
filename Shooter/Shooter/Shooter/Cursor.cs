using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            cursorTex = Engine.Content.Load<Texture2D>(Cursor);
        }

        /// <summary>
        /// Draws the cursor at the correct position
        /// </summary>
        public void Draw() 
        {
            Engine.SpriteBatch.Draw(cursorTex, new RectangleF(Engine.MousePosition, Size), null, Color.White, 0, Origin * (new Vector2(cursorTex.Width, cursorTex.Height) / Size), SpriteEffects.None, 0.9f);
        }

        /// <summary>
        /// Loads the gamecursro (crosshair)
        /// </summary>
        /// <returns>returns the cursor value of crosshair</returns>
        public static Cursor GameCursor() 
        {
            Cursor cursor = new Cursor();
            cursor.Load("Cursor/Crosshair");
            return cursor;
        }

        /// <summary>
        /// Loads the menucursor
        /// </summary>
        /// <returns>Cursor with menucursor loaded</returns>
        public static Cursor MenuCursor()
        {
            Cursor cursor = new Cursor();
            cursor.Load("Cursor/MenuCursor");
            return cursor;
        }
    }
}
