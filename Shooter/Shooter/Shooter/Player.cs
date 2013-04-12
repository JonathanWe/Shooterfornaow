using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    public class Player
    {
        public static Character SelectedPlayer;
        public static int PlayerScore = 0;

        float healt = 100;
        public float Healt 
        {
            get { return healt; }
            set 
            {
                if (healt > value)
                    character.IsHit = true;
                healt = value;
            }
        }
        public Vector2 Position { get { return character.Position; } set { character.Position = value; } }
        public Vector2 Size;

        Character character;

        /// <summary>
        /// Loads the character you have selected
        /// </summary>
        public void Load() 
        {
            character = SelectedPlayer;
        }

        /// <summary>
        /// Updates the position of the character depending on which button is pressed
        /// </summary>
        public void Update() 
        {
            if (Healt <= 0)
            {
                //GameOver
                Engine.CurrentScene = new GameOver();
                Engine.CurrentScene.Load();
                Engine.Cursor = Cursor.MenuCursor();
            }

            //Input
            if (Engine.KeyDown(Keys.Left) | Engine.KeyDown(Keys.A))
            {
                character.MoveLeft();
            }
            if (Engine.KeyDown(Keys.Right) || Engine.KeyDown(Keys.D))
            {
                character.MoveRight();
            }
            if ((Engine.KeyDown(Keys.Up) || Engine.KeyDown(Keys.W)))
            {
                character.Jump();
            }
            if (character.Weapon != null) character.Weapon.Update(Engine.MouseDown, Position + character.WeaponMountPoint, Engine.Camera.MousePosition);

            character.Update(true, false);

            Engine.Camera.Position = Position - new Vector2(Engine.WindowWidth / 2, Engine.WindowHeight / 2);
        }

        /// <summary>
        /// Draws the character
        /// </summary>
        public void Draw() 
        {
            character.Draw();
        }
    }
}
