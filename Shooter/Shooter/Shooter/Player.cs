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
        public Vector2 Position;
        public Vector2 Size;

        Character character;
        Vector2 acceleration;
        float maxSpeed = 300;
        float degrees;

        public void Load() 
        {
            character = Character.Player();
        }
        public void Update() 
        {
            character.Update(true, false);

            //Input
            if (Engine.KeyDown(Keys.Left))
            {
                acceleration.X += -500 * Engine.GameTimeInSec;
                if (acceleration.X < -maxSpeed) acceleration.X = -maxSpeed;
            }
            if (Engine.KeyDown(Keys.Right))
            {
                acceleration.X += 500 * Engine.GameTimeInSec;
                if (acceleration.X > maxSpeed) acceleration.X = maxSpeed;
            }
            Vector2 gunDir = Engine.MousePosition - (Position + character.HandOffset);
            degrees = (float)Math.Atan2(gunDir.Y, gunDir.X);


            //Movement
            if (acceleration.X > 0)
            {
                acceleration.X -= 200 * Engine.GameTimeInSec;
                if (acceleration.X < 0) acceleration.X = 0;
            }
            else if (acceleration.X < 0)
            {
                acceleration.X -= -200 * Engine.GameTimeInSec;
                if (acceleration.X > 0) acceleration.X = 0;
            }
            Position += acceleration * Engine.GameTimeInSec;
        }
        public void Draw() 
        {
            character.Draw(Position, degrees);
        }
    }
}
