using System;
using System.Collections.Generic;
using System.Text;
using Adamo;

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
            if (!RectangleF.Intersect(new RectangleF(Position, Size), new RectangleF(Mouse.Position, Vector2.One)).IsNull)
            {
                if (Mouse.Down())
                    state = ButtunState.Down;
                else if (Mouse.Click()) 
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
            if (Flip) Engine.SpriteBatch.Draw(GameResources.GUISheet.Texture, Position, Size, Z, GameResources.GUISheet.GetSprite(frameName), Vector2.Zero, 0, AlphaColor.White, true, false);
            else Engine.SpriteBatch.Draw(GameResources.GUISheet.Texture, Position, Size, Z, GameResources.GUISheet.GetSprite(frameName), Vector2.Zero, 0, AlphaColor.White);

        }
    }
}
