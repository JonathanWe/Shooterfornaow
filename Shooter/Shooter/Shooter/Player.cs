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
        public int Healt = 100;
        public Weapon Weapon;
        public Vector2 Position { get { return character.Position; } set { character.Position = value; } }
        public Vector2 Size;

        Character character;
        float maxSpeed = 300;
        float jumpStrength = 700;
        float gravity = 1000;
        float degrees;

        public void Load() 
        {
            character = Character.Player();
        }
        public void Update() 
        {
            character.Update(true, false);

            //Input
            if (Engine.KeyDown(Keys.Left) | Engine.KeyDown(Keys.A))
            {
                character.Acceleration.X += -500 * Engine.GameTimeInSec;
                if (character.Acceleration.X < -maxSpeed) character.Acceleration.X = -maxSpeed;
            }
            if (Engine.KeyDown(Keys.Right) || Engine.KeyDown(Keys.D))
            {
                character.Acceleration.X += 500 * Engine.GameTimeInSec;
                if (character.Acceleration.X > maxSpeed) character.Acceleration.X = maxSpeed;
            }
            if ((Engine.KeyDown(Keys.Up) || Engine.KeyDown(Keys.W)) && character.Acceleration.Y == 0)
            {
                character.Acceleration.Y = -jumpStrength;
            }
            Vector2 gunDir = Engine.MousePosition - (Position + character.HandOffset);
            degrees = (float)Math.Atan2(gunDir.Y, gunDir.X);


            //Movement
            if (character.Acceleration.X > 0)
            {
                character.Acceleration.X -= 200 * Engine.GameTimeInSec;
                if (character.Acceleration.X < 0) character.Acceleration.X = 0;
            }
            else if (character.Acceleration.X < 0)
            {
                character.Acceleration.X -= -200 * Engine.GameTimeInSec;
                if (character.Acceleration.X > 0) character.Acceleration.X = 0;
            }
            //Jump
            character.Acceleration.Y += gravity * Engine.GameTimeInSec;

            Position += character.Acceleration * Engine.GameTimeInSec;
            Engine.Map.UpdateCharacterCollision(character);
        }
        public void Draw() 
        {
            character.Draw(Position, degrees);
        }
    }
}
