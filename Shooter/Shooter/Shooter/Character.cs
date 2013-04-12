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
        Animation runAnimationR = new Animation();
        Animation runAnimationL = new Animation();

        Point headR1Size = new Point(55, 55);
        Point headL1Size = new Point(55, 55);
        Point headR2Size = new Point(55, 55);
        Point headL2Size = new Point(55, 55);
        Vector2 headR1Offset = new Vector2(47, 10);
        Vector2 headL1Offset = new Vector2(47, 10);
        Vector2 headR2Offset = new Vector2(47, 10);
        Vector2 headL2Offset = new Vector2(47, 10);

        Point bodyRunRSize = new Point(90, 110);
        Point bodyStandRSize = new Point(60, 110);
        Vector2 bodyRunROffset = new Vector2(0, 45);
        Vector2 bodyStandROffset = new Vector2(55, 47);
        Point bodyRunLSize = new Point(90, 110);
        Point bodyStandLSize = new Point(60, 110);
        Vector2 bodyRunLOffset = new Vector2(0, 45);
        Vector2 bodyStandLOffset = new Vector2(55, 47);



        Vector2 boundingBox = new Vector2(110, 155);
        float degrees = 0;
        bool lookRight = true;

        public Weapon Weapon;
        public Vector2 WeaponMountPoint;
        public Vector2 Position;
        public Vector2 Size { get { return boundingBox; } }
        public Vector2 Acceleration = new Vector2();
        public float MaxSpeed = 300;
        public float JumpStrength = 700;
        public float Gravity = 1000;
        public String CharacterColor = "Red";

        public Character(SpriteSheet Sheet)
        {
            this.sheet = Sheet;
            //runAnimation = sheet.GetAnimation("Run");
            //runAnimation.Loop = true;
            //runAnimation.AnimationSpeed = 0.1f;
            //runAnimation.Animating = true;

            Weapon = Weapon.DefaultWeapon();
        }
        public Character(string File)
        {
            runAnimationR.AnimationSpeed = 0.1f;
            runAnimationL.AnimationSpeed = 0.1f;

            string text = System.IO.File.ReadAllText(File);
            {
                string[] split = text.Split('\n');
                text = "";
                for (int i = 0; i < split.Length; i++)
                {
                    if (split[i].Trim().StartsWith("//")) continue;
                    else text += split[i] + "\n";
                }
            }
            string[] code = TextHelper.RemoveDoubble(text.Replace("\n", "").Replace("\r", "").Replace("\t", " "), ' ').ToLower().Split(';');

            for (int i = 0; i < code.Length; i++)
            {
                string[] split = code[i].Trim().Split('=');
                if (split.Length < 2) continue;
                string name = split[0].Trim();
                string value = split[1].Trim();

                if (name == "texture")
                {
                    if (GameResources.CharacterSheets.ContainsKey(value))
                        sheet = GameResources.CharacterSheets[value];
                    else
                    {
                        sheet = new SpriteSheet(value);
                        GameResources.CharacterSheets.Add(value, sheet);
                    }
                }
                if (name == "animation.runspeed")
                {
                    runAnimationR.AnimationSpeed = float.Parse(value);
                    runAnimationL.AnimationSpeed = runAnimationR.AnimationSpeed;
                }
                if (name == "animation.runspeedr") 
                {
                    runAnimationR.AnimationSpeed = float.Parse(value);
                }
                if (name == "animation.runspeedl")
                {
                    runAnimationL.AnimationSpeed = float.Parse(value);
                }
                if (name == "speed") 
                {
                    MaxSpeed = float.Parse(value);
                }
                if (name == "jumpstrength")
                {
                    JumpStrength = float.Parse(value);
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
                else if (name == "head.position")
                {
                    split = value.Split(',');
                    headR1Offset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                    headL1Offset = headR1Offset;
                    headR2Offset = headR1Offset;
                    headL2Offset = headR1Offset;
                }
                else if (name == "head.size")
                {
                    split = value.Split(',');
                    headR1Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
                    headL1Size = headR1Size;
                    headR2Size = headR1Size;
                    headL2Size = headR1Size;
                }
                else if (name == "headr1.position")
                {
                    split = value.Split(',');
                    headR1Offset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "headr1.size")
                {
                    split = value.Split(',');
                    headR1Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "headl1.position")
                {
                    split = value.Split(',');
                    headL1Offset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "headl1.size")
                {
                    split = value.Split(',');
                    headL1Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "headr2.position")
                {
                    split = value.Split(',');
                    headR2Offset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "headr2.size")
                {
                    split = value.Split(',');
                    headR2Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "headl2.position")
                {
                    split = value.Split(',');
                    headL2Offset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "headl2.size")
                {
                    split = value.Split(',');
                    headL2Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "body.position")
                {
                    split = value.Split(',');
                    bodyRunROffset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                    bodyStandROffset = bodyRunROffset;
                    bodyRunLOffset = bodyRunROffset;
                    bodyStandLOffset = bodyRunROffset;
                }
                else if (name == "body.size")
                {
                    split = value.Split(',');
                    bodyRunRSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
                    bodyStandRSize = bodyRunRSize;
                    bodyRunLSize = bodyRunRSize;
                    bodyStandLSize = bodyRunRSize;
                }
                else if (name == "bodyrunr.position")
                {
                    split = value.Split(',');
                    bodyRunROffset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "bodyrunr.size")
                {
                    split = value.Split(',');
                    bodyRunRSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "bodystandr.position")
                {
                    split = value.Split(',');
                    bodyStandROffset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "bodystandr.size")
                {
                    split = value.Split(',');
                    bodyStandRSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "bodyrunl.position")
                {
                    split = value.Split(',');
                    bodyRunLOffset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "bodyrunl.size")
                {
                    split = value.Split(',');
                    bodyRunLSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "bodystandl.position")
                {
                    split = value.Split(',');
                    bodyStandLOffset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "bodystandl.size")
                {
                    split = value.Split(',');
                    bodyStandLSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
            }
            //Initializes animations and gives it a weapon
            runAnimationR.AddFrames(sheet.GetAnimationRectangles("RunR"));
            runAnimationR.Loop = true;
            runAnimationR.Animating = true;

            runAnimationL.AddFrames(sheet.GetAnimationRectangles("RunL"));
            runAnimationL.Loop = true;
            runAnimationL.Animating = true;

            Weapon = new Weapon("Content/Weapons/Sub.txt");
        }

        public void Update(bool Walking, bool Jumping) 
        {
            Vector2 gunDir = Engine.Camera.MousePosition - (Position + WeaponMountPoint);
            degrees = (float)Math.Atan2(gunDir.Y, gunDir.X);

            lookRight = AdamoMath.ToRadians(90) > degrees && AdamoMath.ToRadians(-90) < degrees;

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
            else
            {
                runAnimationR.CurrentFrame = 0;
                runAnimationL.CurrentFrame = 0;
            }
            //Animation
            if (Acceleration.X != 0)
            {
                if (lookRight) runAnimationR.Update();
                else runAnimationL.Update();
            }
            //Jump
            Acceleration.Y += Gravity * Engine.GameTimeInSec;

            Position += Acceleration * Engine.GameTimeInSec;
            Engine.Map.UpdateCharacterCollision(this);
        }
        public void Draw()
        {
            if (Acceleration.X != 0)
            {
                if (lookRight)
                {
                    var runFrame = runAnimationR.GetFrame();
                    Engine.Camera.Draw(sheet.Texture, new Vector2(Position.X + headR1Offset.X, (Position.Y + headR1Offset.Y)), new Vector2(headR1Size.X, headR1Size.Y), sheet.GetSprite(CharacterColor + "HeadR1"), Color.White, 0.2f, Vector2.Zero, 0);
                    Engine.Camera.Draw(sheet.Texture, new Vector2(Position.X + bodyRunROffset.X, Position.Y + bodyRunROffset.Y), new Vector2(bodyRunRSize.X, bodyRunRSize.Y), runFrame, Color.White, 0.11f, Vector2.Zero, 0);
                }
                else
                {
                    var runFrame = runAnimationL.GetFrame();
                    Engine.Camera.Draw(sheet.Texture, new Vector2(Position.X + headL1Offset.X, Position.Y + headL1Offset.Y), new Vector2( headL1Size.X, headL1Size.Y), sheet.GetSprite(CharacterColor + "HeadL1"), Color.White, 0.2f, Vector2.Zero, 0);
                    Engine.Camera.Draw(sheet.Texture, new Vector2(Position.X + bodyRunLOffset.X, Position.Y + bodyRunLOffset.Y), new Vector2(bodyRunLSize.X, bodyRunLSize.Y), runFrame, Color.White, 0.11f, Vector2.Zero, 0);
                }
            }
            else
            {
                if (lookRight)
                {
                    Engine.Camera.Draw(sheet.Texture, new Vector2(Position.X + headR2Offset.X, Position.Y + headR2Offset.Y), new Vector2(headR2Size.X, headR2Size.Y), sheet.GetSprite(CharacterColor + "HeadR2"), Color.White, 0.2f, Vector2.Zero, 0);
                    Engine.Camera.Draw(sheet.Texture, new Vector2(Position.X + bodyStandROffset.X, Position.Y + bodyStandROffset.Y), new Vector2(bodyStandRSize.X, bodyStandRSize.Y), sheet.GetSprite("StandR"), Color.White, 0.11f, Vector2.Zero, 0);
                }
                else 
                {
                    Engine.Camera.Draw(sheet.Texture, new Vector2(Position.X + headL2Offset.X, Position.Y + headL2Offset.Y), new Vector2(headR2Size.X, headR2Size.Y), sheet.GetSprite(CharacterColor + "HeadL2"), Color.White, 0.2f, Vector2.Zero, 0);
                    Engine.Camera.Draw(sheet.Texture, new Vector2(Position.X + bodyStandROffset.X, Position.Y + bodyStandROffset.Y), new Vector2(bodyStandRSize.X, bodyStandRSize.Y), sheet.GetSprite("StandL"), Color.White, 0.11f, Vector2.Zero, 0);
                }
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
        public static Character Shiro(String Color)
        {
            Character character = new Character("Content/Characters/Player/Shiro/Shiro.txt");
            character.CharacterColor = Color;
            return character;
        }
        public static Character Kuro(String Color)
        {
            Character character = new Character("Content/Characters/Player/Kuro/Kuro.txt");
            character.CharacterColor = Color;
            return character;
        }
        public static Character Enemy1()
        {
            Character character = new Character("Content/Characters/Player/Shiro/Shiro.txt");
            character.CharacterColor = "Black";
            return character;
        }
    }
}
