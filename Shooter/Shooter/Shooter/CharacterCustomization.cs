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
        Button btnPlay;
        Button btnNextWep;
        Button btnPrevWep;
        List<Weapon> weapons = new List<Weapon>();
        int weaponID = 0;

        public CharacterCustomization(bool Shiro) 
        {
            if (Shiro) character = Character.Shiro("Red");
            else character = Character.Kuro("Red");
        }

        public void Load()
        {

            background = Engine.Content.Load<Texture2D>("BGCharCuz");

            character.Position = new Vector2(422,274);

            cbRed = new ChechBox(GameResources.GUISheet, "RedButton");
            cbRed.Position = new Vector2(412, 245);
            cbRed.Size = new Vector2(35, 35);
            cbRed.Z = 0.1f;
            cbRed.Active = true;
            cbRed.OnActive += new EventHandler(cb_OnActive);

            cbBlack = new ChechBox(GameResources.GUISheet, "BlackButton");
            cbBlack.Position = new Vector2(452, 245);
            cbBlack.Size = new Vector2(35, 35); 
            cbBlack.Z = 0.1f;
            cbBlack.OnActive += new EventHandler(cb_OnActive);

            cbWhite = new ChechBox(GameResources.GUISheet, "WhiteButton");
            cbWhite.Position = new Vector2(492, 245);
            cbWhite.Size = new Vector2(35, 35); 
            cbWhite.Z = 0.1f;
            cbWhite.OnActive += new EventHandler(cb_OnActive);

            cbPink = new ChechBox(GameResources.GUISheet, "PinkButton");
            cbPink.Position = new Vector2(532, 245);
            cbPink.Size = new Vector2(35, 35); 
            cbPink.Z = 0.1f;
            cbPink.OnActive += new EventHandler(cb_OnActive);

            btnPlay = new Button("Start");
            btnPlay.Position = new Vector2(755,620);
            btnPlay.Size = new Vector2(250,75);
            btnPlay.Z = 0.1f;
            btnPlay.OnClick += new EventHandler(btnPlay_OnClick);

            btnNextWep = new Button("Arrow");
            btnNextWep.Position = new Vector2(666, 355);
            btnNextWep.Size = new Vector2(55, 45);
            btnNextWep.Z = 0.1f;
            btnNextWep.Flip = true;
            btnNextWep.OnClick += new EventHandler(btnNextWep_OnClick);


            btnPrevWep = new Button("Arrow");
            btnPrevWep.Position = new Vector2(320, 355);
            btnPrevWep.Size = new Vector2(55, 45);
            btnPrevWep.Z = 0.1f;
            btnPrevWep.OnClick += new EventHandler(btnPrevWep_OnClick);

            String [] files = System.IO.Directory.GetFiles("Content/Weapons");
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].EndsWith(".txt")) 
                {
                    weapons.Add(new Weapon(files[i]));
                }
            }
        }

        void btnPrevWep_OnClick(object sender, EventArgs e)
        {
            weaponID--;
            if (weaponID < 0) weaponID = weapons.Count - 1;
            character.Weapon = weapons[weaponID];

        }

        void btnNextWep_OnClick(object sender, EventArgs e)
        {
            weaponID++;
            if (weaponID >= weapons.Count) weaponID = 0;
            character.Weapon = weapons[weaponID];
        }

        void btnPlay_OnClick(object sender, EventArgs e)
        {
            Player.SelectedPlayer = character;
            Engine.Game = new Shooter();
            Engine.CurrentScene = Engine.Game;
            Engine.CurrentScene.Load();

        }

        void cb_OnActive(object sender, EventArgs e)
        {
            if ((ChechBox)sender != cbRed) cbRed.Active = false;
            else character.CharacterColor = "Red";
            if ((ChechBox)sender != cbBlack) cbBlack.Active = false;
            else character.CharacterColor = "Black";
            if ((ChechBox)sender != cbWhite) cbWhite.Active = false;
            else character.CharacterColor = "White";
            if ((ChechBox)sender != cbPink) cbPink.Active = false;
            else character.CharacterColor = "Pink";
        }

        public void Update()
        {
            cbRed.Update();
            cbBlack.Update();
            cbWhite.Update();
            cbPink.Update();
            btnPlay.Update();
            btnNextWep.Update();
            btnPrevWep.Update();

        }

        public void Draw()
        {
            Engine.SpriteBatch.Draw (background, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            character.Draw();
            cbRed.Draw();
            cbBlack.Draw();
            cbWhite.Draw();
            cbPink.Draw();
            btnPlay.Draw();
            btnNextWep.Draw();
            btnPrevWep.Draw();
        }
    }
}
