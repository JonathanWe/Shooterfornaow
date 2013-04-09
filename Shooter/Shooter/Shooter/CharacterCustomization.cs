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
            character.Position = new Vector2(300,300);
            
            cbRed = new ChechBox(Engine.GUISheet, "RedButton");
            cbRed.Position = new Vector2(200, 305);
            cbRed.Size = new Vector2(35, 35);cbRed.Z = 1;
            cbRed.OnActive += new EventHandler(cbRed_OnActive);

            cbBlack = new ChechBox(Engine.GUISheet, "BlackButton");
            cbBlack.Position = new Vector2(200, 345);
            cbBlack.Size = new Vector2(35, 35); cbBlack.Z = 1;

            cbWhite = new ChechBox(Engine.GUISheet, "WhiteButton");
            cbWhite.Position = new Vector2(200, 385);
            cbWhite.Size = new Vector2(35, 35); cbWhite.Z = 1;

            cbPink = new ChechBox(Engine.GUISheet, "PinkButton");
            cbPink.Position = new Vector2(200, 425);
            cbPink.Size = new Vector2(35, 35); cbPink.Z = 1;

        }

        void cbRed_OnActive(object sender, EventArgs e)
        {

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
            //character.Draw();
            cbRed.Draw();
            cbBlack.Draw();
            cbWhite.Draw();
            cbPink.Draw();
        }
    }
}
