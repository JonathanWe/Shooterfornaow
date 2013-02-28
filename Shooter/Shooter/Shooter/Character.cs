using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    public class Character
    {
        Texture2D headTexture;
        Texture2D bodyTexture;
        Texture2D handTexture;
        Texture2D feetTexture;

        Point headSize = new Point(80, 80);
        Point bodySize = new Point(64, 100);
        Point handSize = new Point(70, 40);
        Point feetSize = new Point(90, 30);

        Vector2 headOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 bodyOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 handOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 feetOffsetPositionOrginal = new Vector2(0, 0);

        internal Vector2 headOffset = new Vector2(2, 0);
        internal Vector2 bodyOffset = new Vector2(0, 45);
        internal Vector2 handOffset = new Vector2(40, 85);
        internal Vector2 feetOffset = new Vector2(5, 155);
        Vector2 gunOrigin = new Vector2(-60, 20);
        Vector2 boundingBox = new Vector2(110, 185);
        float degrees = 0;

        public Vector2 HeadOffset { get { return headOffset; } }
        public Vector2 BodyOffset { get { return bodyOffset; } }
        public Vector2 HandOffset { get { return handOffset; } }
        public Vector2 FeetOffset { get { return feetOffset; } }
        public Vector2 GunOrigin { get { return gunOrigin; } }

        public Vector2 Position;
        public Vector2 Size { get { return boundingBox; } }
        public Vector2 Acceleration = new Vector2();
        public float MaxSpeed = 300;
        public float JumpStrength = 700;
        public float Gravity = 1000;

        public Character(string Head, string Body, string Hand, string Feet)
        {
            headTexture = Engine.Content.Load<Texture2D>(Head);
            bodyTexture = Engine.Content.Load<Texture2D>(Body);
            handTexture = Engine.Content.Load<Texture2D>(Hand);
            feetTexture = Engine.Content.Load<Texture2D>(Feet);
        }

        public void Update(bool Walking, bool Jumping) 
        {
            Vector2 gunDir = Engine.MousePosition - (Position + HandOffset);
            degrees = (float)Math.Atan2(gunDir.Y, gunDir.X);


            //Movement
            if (Acceleration.X > 0)
            {
                Acceleration.X -= 200 * Engine.GameTimeInSec;
                if (Acceleration.X < 0) Acceleration.X = 0;
            }
            else if (Acceleration.X < 0)
            {
                Acceleration.X -= -200 * Engine.GameTimeInSec;
                if (Acceleration.X > 0) Acceleration.X = 0;
            }
            //Jump
            Acceleration.Y += Gravity * Engine.GameTimeInSec;

            Position += Acceleration * Engine.GameTimeInSec;
            Engine.Map.UpdateCharacterCollision(this);
        }
        public void Draw(Vector2 Position) 
        {
            Engine.SpriteBatch.Draw(headTexture, new Rectangle((int)(Position.X + headOffset.X), (int)(Position.Y + headOffset.Y), headSize.X, headSize.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
            Engine.SpriteBatch.Draw(bodyTexture, new Rectangle((int)(Position.X + bodyOffset.X), (int)(Position.Y + bodyOffset.Y), bodySize.X, bodySize.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.11f);
            Engine.SpriteBatch.Draw(handTexture, new Rectangle((int)(Position.X + handOffset.X), (int)(Position.Y + handOffset.Y), handSize.X, handSize.Y), null, Color.White, degrees, gunOrigin * (new Vector2(handTexture.Width, handTexture.Height) / new Vector2(handSize.X, handSize.Y)), SpriteEffects.None, 0.2f);
            Engine.SpriteBatch.Draw(feetTexture, new Rectangle((int)(Position.X + feetOffset.X), (int)(Position.Y + feetOffset.Y), feetSize.X, feetSize.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.1f);
        }

        public void MoveLeft() 
        {
            Acceleration.X += -500 * Engine.GameTimeInSec;
            if (Acceleration.X < -MaxSpeed) Acceleration.X = -MaxSpeed;
        }
        public void MoveRight() 
        {
            Acceleration.X += 500 * Engine.GameTimeInSec;
            if (Acceleration.X > MaxSpeed) Acceleration.X = MaxSpeed;
        }
        public void Jump() 
        {
            if (Acceleration.Y == 0)
            {
                Acceleration.Y = -JumpStrength;
            }
        }

        public static Character Player() 
        {
            return new Character("Pl_Head", "Pl_Body", "Gun", "Pl_Feet");
        }
        public static Character Enemy1()
        {
            Character character = new Character("En_Head", "En_Body", "Gun", "En_Feet");
            character.MaxSpeed = 150;
            return character;
        }
    }
}
