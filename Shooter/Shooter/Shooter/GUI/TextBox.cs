using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter.GUI
{
    public class TextBox
    {
        public Vector2 Position = new Vector2();
        public Vector2 Size = new Vector2(100, 40);
        public float Z = 0;
        public string Text;
        public Color TextColor = Color.Black;
        public bool Active;
        public string TextBoxSheetName = "";
        public event EventHandler OnActive;

        Rectangle frame = new Rectangle();
        public TextBox(string TextBoxName) 
        {
            TextBoxSheetName = TextBoxName;
        }

        public void Update() 
        {
            if (Engine.MouseClick)
            {
                if (Engine.Collide(Position, Size, Engine.MousePosition, new Vector2(0, 0)))
                {
                    Active = true;
                    frame = Engine.GUISheet.GetSprite(TextBoxSheetName + "Active");
                    if (OnActive != null) OnActive(this, EventArgs.Empty);
                }
                else Active = false;
            }
            if (!Active)
            {
                if (Engine.Collide(Position, Size, Engine.MousePosition, new Vector2(0, 0))) frame = Engine.GUISheet.GetSprite(TextBoxSheetName + "Over");
            }
            else
            {
                frame = Engine.GUISheet.GetSprite(TextBoxSheetName);
                if (Engine.keysDown.Count > 0)
                {

                }
            }
        }
        public void Draw() 
        {
            Engine.SpriteBatch.Draw(Engine.GUISheet.Texture, new RectangleF(Position.X, Position.Y, Size.X, Size.Y), frame, Color.White, 0, Vector2.Zero,
                SpriteEffects.None, Z);
            Engine.SpriteBatch.DrawString(Engine.DefaultFont, Text, Position, TextColor, 0, Vector2.Zero, 1, SpriteEffects.None, Z + 0.0001f);
        }
    }
}
