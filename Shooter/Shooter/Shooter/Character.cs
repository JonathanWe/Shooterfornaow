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
        SpriteSheet sheet;
        Animation runAnimation;

        Point headSize = new Point(55, 55);
        Point bodySize = new Point(90, 110);
        Point bodyStandSize = new Point(60, 110);
        Point handSize = new Point(70, 40);

        Vector2 headOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 bodyOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 handOffsetPositionOrginal = new Vector2(0, 0);

        internal Vector2 headOffset = new Vector2(47, 10);
        internal Vector2 bodyOffset = new Vector2(0, 45);
        internal Vector2 bodyStandOffset = new Vector2(55, 47);
        internal Vector2 handOffset = new Vector2(40, 85);
        Vector2 boundingBox = new Vector2(110, 155);
        float degrees = 0;

        public Vector2 HeadOffset { get { return headOffset; } }
        public Vector2 BodyOffset { get { return bodyOffset; } }
        public Vector2 HandOffset { get { return handOffset; } }

        public Weapon Weapon;
        public Vector2 Position;
        public Vector2 Size { get { return boundingBox; } }
        public Vector2 Acceleration = new Vector2();
        public float MaxSpeed = 300;
        public float JumpStrength = 700;
        public float Gravity = 1000;

        public Character(SpriteSheet Sheet)
        {
            this.sheet = Sheet;
            runAnimation = sheet.GetAnimation("Run");
            runAnimation.Loop = true;
            runAnimation.AnimationSpeed = 0.1f;
            runAnimation.Animating = true;

            Weapon = Weapon.DefaultWeapon();
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
                runAnimation.Update();
            }
            else if (Acceleration.X < 0)
            {
                Acceleration.X -= -200 * Engine.GameTimeInSec;
                if (Acceleration.X > 0) Acceleration.X = 0;
                runAnimation.Update();
            }
            else runAnimation.CurrentFrame = 0;
            //Jump
            Acceleration.Y += Gravity * Engine.GameTimeInSec;

            Position += Acceleration * Engine.GameTimeInSec;
            Engine.Map.UpdateCharacterCollision(this);
        }
        public void Draw(Vector2 Position) 
        {
            var runFrame = runAnimation.GetFrame();

            if (Acceleration.X != 0)
            {
                if (Acceleration.X > 0)
                {
                    Engine.SpriteBatch.Draw(sheet.Texture, new Rectangle((int)(Position.X + headOffset.X), (int)(Position.Y + headOffset.Y), headSize.X, headSize.Y), sheet.GetSprite("Head1"), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
                    Engine.SpriteBatch.Draw(sheet.Texture, new Rectangle((int)(Position.X + bodyOffset.X), (int)(Position.Y + bodyOffset.Y), bodySize.X, bodySize.Y), runFrame, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.11f);
                }
                else
                {
                    Vector2 realHeadOffset = headOffset + new Vector2(headSize.X, headSize.Y) - new Vector2(bodySize.X, bodySize.Y);
                    Engine.SpriteBatch.Draw(sheet.Texture, new Rectangle((int)(Position.X - realHeadOffset.X), (int)(Position.Y + headOffset.Y), headSize.X, headSize.Y), sheet.GetSprite("Head2"), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
                    Engine.SpriteBatch.Draw(sheet.Texture, new Rectangle((int)(Position.X + bodyOffset.X), (int)(Position.Y + bodyOffset.Y), bodySize.X, bodySize.Y), runFrame, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0.11f);
                }
            }
            else
            {
                Engine.SpriteBatch.Draw(sheet.Texture, new Rectangle((int)(Position.X + headOffset.X), (int)(Position.Y + headOffset.Y), headSize.X, headSize.Y), sheet.GetSprite("Head3"), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
                Engine.SpriteBatch.Draw(sheet.Texture, new Rectangle((int)(Position.X + bodyStandOffset.X), (int)(Position.Y + bodyStandOffset.Y), bodyStandSize.X, bodyStandSize.Y), sheet.GetSprite("Stand"), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.11f);
            }
            Weapon.Draw(Position + handOffset, degrees);
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
            return new Character(new SpriteSheet("Content/Characters/Player/Kuro/KuroSpriteSheet.sht"));
        }
        public static Character Enemy1()
        {
            Character character = new Character(new SpriteSheet("Content/Characters/Player/Kuro/KuroSpriteSheet.sht"));
            character.MaxSpeed = 150;
            return character;
        }
    }
}
