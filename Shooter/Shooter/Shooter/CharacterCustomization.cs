using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Shooter.GUI;

namespace Shooter
{
    class CharacterCustomization : IScene
    {
        Texture2D background;
        Character character;
        ChechBox cbRed;
        ChechBox cbBlack;
        ChechBox cbWhite;
        ChechBox cbPink;

        public void Load()
        {

            background = Engine.Content.Load<Texture2D>("BGCharCuz");

            character = Character.Shiro();
            character.Position = new Vector2(422,274);
            
            cbRed = new ChechBox(Engine.GUISheet, "RedButton");
            cbRed.Position = new Vector2(412, 245);
            cbRed.Size = new Vector2(35, 35);
            cbRed.Z = 0.1f;
            cbRed.OnActive += new EventHandler(cb_OnActive);

            cbBlack = new ChechBox(Engine.GUISheet, "BlackButton");
            cbBlack.Position = new Vector2(452, 245);
            cbBlack.Size = new Vector2(35, 35); 
            cbBlack.Z = 0.1f;
            cbBlack.OnActive += new EventHandler(cb_OnActive);

            cbWhite = new ChechBox(Engine.GUISheet, "WhiteButton");
            cbWhite.Position = new Vector2(492, 245);
            cbWhite.Size = new Vector2(35, 35); 
            cbWhite.Z = 0.1f;
            cbWhite.OnActive += new EventHandler(cb_OnActive);

            cbPink = new ChechBox(Engine.GUISheet, "PinkButton");
            cbPink.Position = new Vector2(532, 245);
            cbPink.Size = new Vector2(35, 35); 
            cbPink.Z = 0.1f;
            cbPink.OnActive += new EventHandler(cb_OnActive);

        }

        void cb_OnActive(object sender, EventArgs e)
        {
            if((ChechBox)sender != cbRed) cbRed.Active = false;
            if ((ChechBox)sender != cbBlack) cbBlack.Active = false;
            if ((ChechBox)sender != cbWhite) cbWhite.Active = false;
            if ((ChechBox)sender != cbPink) cbPink.Active = false;
        }

        public void Update()
        {
            cbRed.Update();
            cbBlack.Update();
            cbWhite.Update();
            cbPink.Update();
        }

        public void Draw()
        {
            Engine.SpriteBatch.Draw (background, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            character.Draw();
            cbRed.Draw();
            cbBlack.Draw();
            cbWhite.Draw();
            cbPink.Draw();
        }
    }
}
