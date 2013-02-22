using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shooter
{
    public class Player
    {
        public int Healt = 100;
        public Weapon Weapon;
        public Vector2 Position;
        public Vector2 Size;

        Character character;

        public void Load() 
        {
            character = Character.Player();
        }
        public void Update() 
        {
            character.Update(true, false);
        }
        public void Draw() 
        {
            character.Draw(Position);
        }
    }
}
