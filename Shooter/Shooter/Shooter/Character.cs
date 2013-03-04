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

        Point head1Size = new Point(55, 55);
        Point head2Size = new Point(55, 55);
        Point head3Size = new Point(55, 55);
        Point head4Size = new Point(55, 55);
        Point head5Size = new Point(55, 55);
        Point head6Size = new Point(55, 55);
        Vector2 head1Offset = new Vector2(47, 10);
        Vector2 head2Offset = new Vector2(47, 10);
        Vector2 head3Offset = new Vector2(47, 10);
        Vector2 head4Offset = new Vector2(47, 10);
        Vector2 head5Offset = new Vector2(47, 10);
        Vector2 head6Offset = new Vector2(47, 10);

        Point bodyRunSize = new Point(90, 110);
        Point bodyStandSize = new Point(60, 110);
        Vector2 bodyRunOffset = new Vector2(0, 45);
        Vector2 bodyStandOffset = new Vector2(55, 47);


        Vector2 boundingBox = new Vector2(110, 155);
        float degrees = 0;

        public Weapon Weapon;
        public Vector2 WeaponMountPoint;
        public float WeaponDistance;
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
        public Character(string File) 
        {
            string[] code = TextHelper.RemoveDoubble(System.IO.File.ReadAllText(File).Replace("\n", "").Replace("\r", "").Replace("\t"," "), ' ').ToLower().Split(';');

            for (int i = 0; i < code.Length; i++)
            {
                string[] split = code[i].Trim().Split('=');
                if (split.Length < 2) throw new Exception("Error while parsing " + File);
                string name = split[0];
                string value = split[1];

                if (name == "texture") 
                {
                    sheet = new SpriteSheet(value);
                }
                if (name == "boundingbox")
                {
                    split = value.Split(',');
                    boundingBox = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "weapon.mountpoint")
                {
                    split = value.Split(',');
                    WeaponMountPoint = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "weapon.distance")
                {
                    WeaponDistance = float.Parse(value);
                }
                else if (name == "head.position")
                {
                    split = value.Split(',');
                    head1Offset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                    head2Offset = head1Offset;
                    head3Offset = head1Offset;
                    head4Offset = head1Offset;
                    head5Offset = head1Offset;
                    head6Offset = head1Offset;
                }
                else if (name == "head.size")
                {
                    split = value.Split(',');
                    head1Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
                    head2Size = head1Size;
                    head3Size = head1Size;
                    head4Size = head1Size;
                    head5Size = head1Size;
                    head6Size = head1Size;
                }
                else if (name == "head1.position")
                {
                    split = value.Split(',');
                    head1Offset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "head1.size") 
                {
                    split = value.Split(',');
                    head1Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "head2.position")
                {
                    split = value.Split(',');
                    head2Offset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "head2.size")
                {
                    split = value.Split(',');
                    head2Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "head3.position")
                {
                    split = value.Split(',');
                    head3Offset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "head3.size")
                {
                    split = value.Split(',');
                    head3Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "head4.position")
                {
                    split = value.Split(',');
                    head4Offset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "head4.size")
                {
                    split = value.Split(',');
                    head4Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "head5.position")
                {
                    split = value.Split(',');
                    head5Offset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "head5.size")
                {
                    split = value.Split(',');
                    head5Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "head6.position")
                {
                    split = value.Split(',');
                    head6Offset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "head6.size")
                {
                    split = value.Split(',');
                    head6Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "body.position")
                {
                    split = value.Split(',');
                    bodyRunOffset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                    bodyStandOffset = bodyRunOffset;
                }
                else if (name == "body.size")
                {
                    split = value.Split(',');
                    bodyRunSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
                    bodyStandSize = bodyRunSize;
                }
                else if (name == "bodyrun.position")
                {
                    split = value.Split(',');
                    bodyRunOffset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "bodyrun.size")
                {
                    split = value.Split(',');
                    bodyRunSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "bodystand.position")
                {
                    split = value.Split(',');
                    bodyStandOffset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "bodystand.size")
                {
                    split = value.Split(',');
                    bodyStandSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
            }
            //Initializes animations and gives it a weapn
            runAnimation = sheet.GetAnimation("Run");
            runAnimation.Loop = true;
            runAnimation.AnimationSpeed = 0.1f;
            runAnimation.Animating = true;

            Weapon = Weapon.DefaultWeapon();
        }

        public void Update(bool Walking, bool Jumping) 
        {
            Vector2 gunDir = Engine.MousePosition - (Position + WeaponMountPoint);
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
                    Engine.SpriteBatch.Draw(sheet.Texture, new Rectangle((int)(Position.X + head1Offset.X), (int)(Position.Y + head1Offset.Y), head1Size.X, head1Size.Y), sheet.GetSprite("Head1"), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
                    Engine.SpriteBatch.Draw(sheet.Texture, new Rectangle((int)(Position.X + bodyRunOffset.X), (int)(Position.Y + bodyRunOffset.Y), bodyRunSize.X, bodyRunSize.Y), runFrame, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.11f);
                }
                else
                {
                    Vector2 realHeadOffset = head2Offset + new Vector2(head2Size.X, head2Size.Y) - new Vector2(bodyRunSize.X, bodyRunSize.Y);
                    Engine.SpriteBatch.Draw(sheet.Texture, new Rectangle((int)(Position.X - realHeadOffset.X), (int)(Position.Y + head2Offset.Y), head2Size.X, head2Size.Y), sheet.GetSprite("Head2"), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
                    Engine.SpriteBatch.Draw(sheet.Texture, new Rectangle((int)(Position.X + bodyRunOffset.X), (int)(Position.Y + bodyRunOffset.Y), bodyRunSize.X, bodyRunSize.Y), runFrame, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0.11f);
                }
            }
            else
            {
                Engine.SpriteBatch.Draw(sheet.Texture, new Rectangle((int)(Position.X + head3Offset.X), (int)(Position.Y + head3Offset.Y), head3Size.X, head3Size.Y), sheet.GetSprite("Head3"), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
                Engine.SpriteBatch.Draw(sheet.Texture, new Rectangle((int)(Position.X + bodyStandOffset.X), (int)(Position.Y + bodyStandOffset.Y), bodyStandSize.X, bodyStandSize.Y), sheet.GetSprite("Stand"), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.11f);
            }
            Weapon.Draw(Position + WeaponMountPoint, degrees);
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
        public static Character Shiro()
        {
            return new Character(new SpriteSheet("Content/Characters/Player/Shiro/ShiroSpriteSheet.sht"));
        }
        public static Character Enemy1()
        {
            Character character = new Character(new SpriteSheet("Content/Characters/Player/Kuro/KuroSpriteSheet.sht"));
            character.MaxSpeed = 150;
            return character;
        }
    }
}
