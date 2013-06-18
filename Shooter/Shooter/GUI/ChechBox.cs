using System;
using System.Collections.Generic;
using System.Text;
using Adamo;

namespace Shooter.GUI
{
    public class ChechBox
    {
        //Public variables
        public Rectangle NormalFrame;
        public Rectangle ActiveFrame;
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Size;
        public float Z;

        //privat variables
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sheet">The SpriteSheet that contains the CheckBox</param>
        /// <param name="Name">The name of the image of the checkbox in the sheet</param>
        public ChechBox(SpriteSheet Sheet, string Name) 
        {
            NormalFrame = Sheet.GetSprite(Name);
            ActiveFrame = Sheet.GetSprite(Name + "Active");
            Texture = Sheet.Texture;
        }

        /// <summary>
        /// Checks if the CheckBox has been clicked
        /// </summary>
        public void Update() 
        {
            if (Mouse.Click() && Engine.Collide(Mouse.Position, Vector2.One, Position, Size))
            {
                Active = true;
            }
        }
        /// <summary>
        /// Draws the CheckBox
        /// </summary>
        public void Draw() 
        {
            if (!Active)
                Engine.SpriteBatch.Draw(GameResources.GUISheet.Texture, Position, Size, Z, NormalFrame, Vector2.Zero, 0, AlphaColor.White);
            else
                Engine.SpriteBatch.Draw(GameResources.GUISheet.Texture, Position, Size, Z, ActiveFrame, Vector2.Zero, 0, AlphaColor.White);  
        }
    }
}
