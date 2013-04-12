using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shooter
{
    public class Enemy
    {
        int healt = 30;
        public int Healt 
        {
            get { return healt; }
            set 
            {
                if (healt > value) character.IsHit = true;
                healt = value;
            }
        }
        public Weapon Weapon;
        public Vector2 Position { get { return character.Position; } set { character.Position = value; } }
        public Vector2 Size { get { return character.Size; } }

        Character character;

        public Enemy() 
        {
            character = Character.Enemy1();
        }

        public Enemy(Character Character)
        {
            character = Character;
        }
        public void Update() 
        {
            if (Healt <= 0) //If it has no more healt it is dead an should be removed
            {
                ((Shooter)Engine.CurrentScene).Enemies.Remove(this);
                Player.PlayerScore += 100;
            }

            //Take healt from player if close enough
            if (((Player.SelectedPlayer.Position + Player.SelectedPlayer.Size / 2) - (Position + Size / 2)).Length() < 100)
            {
                Engine.Game.Player.Healt -= 50 * Engine.GameTimeInSec;
            }

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
