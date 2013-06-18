using System;
using System.Collections.Generic;
using System.Text;
using Adamo;
namespace Shooter.GUI
{
    public class TextBox
    {
        //Public varaiables
        public Vector2 Position = new Vector2();
        public Vector2 Size = new Vector2(100, 40);
        public float Z = 0;
        public string Text = "";
        public AlphaColor TextColor = AlphaColor.Black;
        public bool Active;
        public string TextBoxSheetName = "";
        public event EventHandler OnActive;

        //private varaibles
        Rectangle frame = new Rectangle();
		Texture2D textTexture;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TextBoxName">The name of thee TextBox image in GUISheet.sht</param>
        public TextBox(string TextBoxName) 
        {
            TextBoxSheetName = TextBoxName;
        }

        /// <summary>
        /// Updates the textbox. Checks for input.
        /// </summary>
        public void Update() 
        {
            if (Mouse.Click())
            {
                if (Engine.Collide(Position, Size, Mouse.Position, new Vector2(0, 0)))
                {
                    Active = true;
                    frame = GameResources.GUISheet.GetSprite(TextBoxSheetName + "Active");
                    if (OnActive != null) OnActive(this, EventArgs.Empty);
                }
                else Active = false;
            }
            if (!Active)
            {
                if (Engine.Collide(Position, Size, Mouse.Position, new Vector2(0, 0))) frame = GameResources.GUISheet.GetSprite(TextBoxSheetName + "Over");
            }
            else
            {
                frame = GameResources.GUISheet.GetSprite(TextBoxSheetName);
				if (Window.Current.Keyboard.keysDown.Count > 0)
                {

                }
            }
        }

        /// <summary>
        /// Draws the TextBox
        /// </summary>
        public void Draw() 
        {
			if (Text != null && Text != "")
				textTexture = GameResources.DefaultFont.Draw (Text);
			else
				textTexture = Texture2D.WhiteTexture ();
			Engine.SpriteBatch.Draw (GameResources.GUISheet.Texture, Position, Size, Z, frame, Vector2.Zero, 0, AlphaColor.White);
			Engine.SpriteBatch.Draw(textTexture, Position, textTexture.Size, Z + 0.0001f, null, Vector2.Zero, 0, TextColor);
        }
    }
}
