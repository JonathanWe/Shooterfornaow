using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shooter
{
    public class Enemy
    {
        public int Healt;
        public Weapon Weapon;
        public Vector2 Position { get { return character.Position; } set { character.Position = value; } }
        public Vector2 Size;

        Character character;

        public void Load() 
        {
            character = Character.Enemy1();
        }
        public void Update() 
        {
            //Walk towards player
            float direction = Engine.Game.Player.Position.X - Position.X;
            if (direction > 0) character.MoveRight();
            else if (direction < 0) character.MoveLeft();

            character.Update(false, false);
        }
        public void Draw() 
        {
            character.Draw();
        }
    }
}
