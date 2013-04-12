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

        public int Healt = 100;
        public Vector2 Position { get { return character.Position; } set { character.Position = value; } }
        public Vector2 Size;

        Character character;

        public void Load() 
        {
            character = SelectedPlayer;
        }
        public void Update() 
        {
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
        public void Draw() 
        {
            character.Draw();
        }
    }
}
