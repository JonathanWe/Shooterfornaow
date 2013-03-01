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
        Vector2 mousePosition;
        float scale = 0.1f;

        public void Load() 
        {
            cursorTex = Engine.Content.Load<Texture2D>("Cursor/Crosshair");
        }
        public void Update()
        {
        }
        public void Draw() 
        {
            Engine.SpriteBatch.Draw(cursorTex, Engine.MousePosition - new Vector2(cursorTex.Width*scale, cursorTex.Height*scale) / 2, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0.1f);
        }

    }
}
