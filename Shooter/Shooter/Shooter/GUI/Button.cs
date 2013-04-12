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
        //Public variables
        public Vector2 Position;
        public Vector2 Size;
        public float Z;
        public string ButtonSkinName = "";
        public bool Flip = false;
        public event EventHandler OnClick;

        //Privat variables
        ButtunState state = ButtunState.Up;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ButtonSkinName">The name om the image of the button stored in GUISheet.sht</param>
        public Button(string ButtonSkinName) 
        {
            this.ButtonSkinName = ButtonSkinName;
        }

        /// <summary>
        /// Checks if the mouse is over and if it has been cicked
        /// </summary>
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

        /// <summary>
        /// Draws the Button
        /// </summary>
        public void Draw() 
        {
            string frameName = ButtonSkinName;
            if (state == ButtunState.Up)
                frameName += "Up";
            else if (state == ButtunState.Over)
                frameName += "Over";
            else if (state == ButtunState.Down)
                frameName += "Down";
            if (Flip) Engine.SpriteBatch.Draw(GameResources.GUISheet.Texture, new RectangleF(Position, Size), GameResources.GUISheet.GetSprite(frameName), Color.White, 0, Vector2.Zero, Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally, Z);
            else Engine.SpriteBatch.Draw(GameResources.GUISheet.Texture, new RectangleF(Position, Size), GameResources.GUISheet.GetSprite(frameName), Color.White, 0, Vector2.Zero, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, Z);

        }
    }
}
