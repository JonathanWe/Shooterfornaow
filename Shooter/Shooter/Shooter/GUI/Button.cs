using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shooter.GUI
{
    public enum ButtunState { Over, Down, Up}
    public class Button
    {
        public Vector2 Position;
        public Vector2 Size;
        public float Z;
        public string ButtonSkinName = "";
        public bool Flip = false;
        public event EventHandler OnClick;


        ButtunState state = ButtunState.Up;

        public Button(string ButtonSkinName) 
        {
            this.ButtonSkinName = ButtonSkinName;
        }

        public void Update() 
        {
            if (!RectangleF.Intersect(new RectangleF(Position, Size), new RectangleF(Engine.MousePosition, Vector2.One)).IsNull)
            {
                if (Engine.MouseDown)
                    state = ButtunState.Down;
                else if (Engine.MouseClick) 
                {
                    if (OnClick != null) OnClick(this, EventArgs.Empty);
                }
                else
                    state = ButtunState.Over;
            }
            else state = ButtunState.Up;
        }
        public void Draw() 
        {
            string frameName = ButtonSkinName;
            if (state == ButtunState.Up)
                frameName += "Up";
            else if (state == ButtunState.Over)
                frameName += "Over";
            else if (state == ButtunState.Down)
                frameName += "Down";
            if(Flip)Engine.SpriteBatch.Draw(Engine.GUISheet.Texture, new RectangleF(Position, Size), Engine.GUISheet.GetSprite(frameName), Color.White, 0, Vector2.Zero, Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally, Z);
            else Engine.SpriteBatch.Draw(Engine.GUISheet.Texture, new RectangleF(Position, Size), Engine.GUISheet.GetSprite(frameName), Color.White, 0, Vector2.Zero, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, Z);

        }
    }
}
