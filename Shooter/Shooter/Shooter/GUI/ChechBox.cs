using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Shooter.GUI
{
    public class ChechBox
    {
        public RectangleF NormalFrame;
        public RectangleF ActiveFrame;
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Size;
        public float Z;
        bool active;
        public bool Active 
        {
            get { return active; }
            set 
            {
                active = value;
                if (value && OnActive != null)
                {
                    OnActive(this, EventArgs.Empty);
                }
            }
        }
        public event EventHandler OnActive;

        public ChechBox(SpriteSheet Sheet, string Name) 
        {
            NormalFrame = Sheet.GetSprite(Name);
            ActiveFrame = Sheet.GetSprite(Name + "Active");
            Texture = Sheet.Texture;
        }

        public ChechBox()
        {
            // TODO: Complete member initialization
        }
        public void Update() 
        {
            if (Engine.MouseClick && Engine.Collide(Engine.MousePosition, Vector2.One, Position, Size))
            {
                Active = true;
            }
        }
        public void Draw() 
        {
            if (!Active)
                Engine.SpriteBatch.Draw(Engine.GUISheet.Texture, new RectangleF(Position, Size), NormalFrame, Color.White, 0, Vector2.Zero, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, Z);
            else
                Engine.SpriteBatch.Draw(Engine.GUISheet.Texture, new RectangleF(Position, Size), ActiveFrame, Color.White, 0, Vector2.Zero, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, Z);  
        }
    }
}
