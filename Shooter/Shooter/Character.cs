using System;
using System.Collections.Generic;
using System.Globalization;
using Adamo;

namespace Shooter
{
    public class Character
    {
        SpriteAnimation runAnimationR = new SpriteAnimation();
        SpriteAnimation runAnimationL = new SpriteAnimation();
        float degrees = 0;
        bool lookRight = true;

		public CharacterData CharacterData;
		public String CharacterColor = "Red";
        public Weapon Weapon;
        public Vector2 Position;
        public Vector2 Size { get { return CharacterData.BoundingBox; } }
        public Vector2 Acceleration = new Vector2();
		public float Gravity = 1000;
		public int Team = -1;
        public bool IsHit = false; //Used to display the character as hit in next draw if true

		public virtual float Health { get; set; }

        public Character(SpriteSheet Sheet)
        {
            this.CharacterData.Sheet = Sheet;
            //runAnimation = sheet.GetAnimation("Run");
            //runAnimation.Loop = true;
            //runAnimation.AnimationSpeed = 0.1f;
            //runAnimation.Animating = true;

            Weapon = Weapon.DefaultWeapon();
        }
        public Character(CharacterData Data, string Color)
        {
			CharacterData = Data;
			runAnimationL.AnimationSpeed = CharacterData.RunAnimationSpeedL;
			runAnimationR.AnimationSpeed = CharacterData.RunAnimationSpeedR;
            CharacterColor = Color;
            LoadRunAnimation();
            Weapon = new Weapon(GameResources.Weapons["Sub"]);
        }
        public void LoadRunAnimation() 
        {
            //Initializes animations and gives it a weapon
            runAnimationR.Clear();
            runAnimationR.AddFrames(CharacterData.Sheet.GetAnimationRectangles(CharacterColor + "RunR"));
            runAnimationR.Loop = true;
            runAnimationR.Animating = true;

            runAnimationL.Clear();
			runAnimationL.AddFrames(CharacterData.Sheet.GetAnimationRectangles(CharacterColor + "RunL"));
            runAnimationL.Loop = true;
            runAnimationL.Animating = true;
        }

        public virtual void Update() 
        {
			Vector2 gunDir = Engine.Camera.MousePosition - (Position + CharacterData.WeaponMountPoint);
            degrees = (float)Math.Atan2(gunDir.Y, gunDir.X);

            lookRight = AdamoMath.ToRadians(90) > degrees && AdamoMath.ToRadians(-90) < degrees;

            //Movement
            if (Acceleration.X > 0)
            {
				Acceleration.X -= 200 * (float)FrameTime.Elapsed.Seconds;
                if (Acceleration.X < 0) Acceleration.X = 0;
            }
            else if (Acceleration.X < 0)
            {
				Acceleration.X -= -200 * (float)FrameTime.Elapsed.Seconds;
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
			Acceleration.Y += Gravity * (float)FrameTime.Elapsed.Seconds;

			Position += Acceleration * (float)FrameTime.Elapsed.Seconds;
            Engine.Map.UpdateCharacterCollision(this);
        }
        public virtual void Draw()
        {
            AlphaColor color;
            if (IsHit) color = AlphaColor.Red;
            else color = AlphaColor.White;
            IsHit = false;
            if (Acceleration.X != 0)
            {
                if (lookRight)
                {
                    var runFrame = runAnimationR.GetFrame();
					Engine.Camera.Draw(CharacterData.Sheet.Texture, new Vector2(Position.X + CharacterData.HeadR1Offset.X, (Position.Y + CharacterData.HeadR1Offset.Y)), new Vector2(CharacterData.HeadR1Size.X, CharacterData.HeadR1Size.Y), CharacterData.Sheet.GetSprite(CharacterColor + "HeadR1"), color, 0.2f, Vector2.Zero, 0);
					Engine.Camera.Draw(CharacterData.Sheet.Texture, new Vector2(Position.X + CharacterData.BodyRunROffset.X, Position.Y + CharacterData.BodyRunROffset.Y), new Vector2(CharacterData.BodyRunRSize.X, CharacterData.BodyRunRSize.Y), runFrame, color, 0.11f, Vector2.Zero, 0);
                }
                else
                {
                    var runFrame = runAnimationL.GetFrame();
					Engine.Camera.Draw(CharacterData.Sheet.Texture, new Vector2(Position.X + CharacterData.HeadL1Offset.X, Position.Y + CharacterData.HeadL1Offset.Y), new Vector2(CharacterData.HeadL1Size.X, CharacterData.HeadL1Size.Y), CharacterData.Sheet.GetSprite(CharacterColor + "HeadL1"), color, 0.2f, Vector2.Zero, 0);
					Engine.Camera.Draw(CharacterData.Sheet.Texture, new Vector2(Position.X + CharacterData.BodyRunLOffset.X, Position.Y + CharacterData.BodyRunLOffset.Y), new Vector2(CharacterData.BodyRunLSize.X, CharacterData.BodyRunLSize.Y), runFrame, color, 0.11f, Vector2.Zero, 0);
                }
            }
            else
            {
                if (lookRight)
                {
					Engine.Camera.Draw(CharacterData.Sheet.Texture, new Vector2(Position.X + CharacterData.HeadR2Offset.X, Position.Y + CharacterData.HeadR2Offset.Y), new Vector2(CharacterData.HeadR2Size.X, CharacterData.HeadR2Size.Y), CharacterData.Sheet.GetSprite(CharacterColor + "HeadR2"), color, 0.2f, Vector2.Zero, 0);
					Engine.Camera.Draw(CharacterData.Sheet.Texture, new Vector2(Position.X + CharacterData.BodyStandROffset.X, Position.Y + CharacterData.BodyStandROffset.Y), new Vector2(CharacterData.BodyStandRSize.X, CharacterData.BodyStandRSize.Y), CharacterData.Sheet.GetSprite(CharacterColor + "StandR"), color, 0.11f, Vector2.Zero, 0);
                }
                else 
                {
					Engine.Camera.Draw(CharacterData.Sheet.Texture, new Vector2(Position.X + CharacterData.HeadL2Offset.X, Position.Y + CharacterData.HeadL2Offset.Y), new Vector2(CharacterData.HeadR2Size.X, CharacterData.HeadR2Size.Y), CharacterData.Sheet.GetSprite(CharacterColor + "HeadL2"), color, 0.2f, Vector2.Zero, 0);
					Engine.Camera.Draw(CharacterData.Sheet.Texture, new Vector2(Position.X + CharacterData.BodyStandROffset.X, Position.Y + CharacterData.BodyStandROffset.Y), new Vector2(CharacterData.BodyStandRSize.X, CharacterData.BodyStandRSize.Y), CharacterData.Sheet.GetSprite(CharacterColor + "StandL"), color, 0.11f, Vector2.Zero, 0);
                }
            }
			if(Weapon != null) Weapon.Draw(Position + CharacterData.WeaponMountPoint, degrees);
        }

        public void MoveLeft() 
		{
			Acceleration.X += -500 * (float)FrameTime.Elapsed.Seconds;
			if (Acceleration.X < -CharacterData.MaxSpeed) Acceleration.X = -CharacterData.MaxSpeed;
        }
        public void MoveRight() 
        {
			Acceleration.X += 500 * (float)FrameTime.Elapsed.Seconds;
			if (Acceleration.X > CharacterData.MaxSpeed) Acceleration.X = CharacterData.MaxSpeed;
        }
        public void Jump() 
        {
            if (Acceleration.Y == 0)
            {
				Acceleration.Y = -CharacterData.JumpStrength;
            }
        }
		public bool IsEnemyTeam(Character Character)
		{
			return (this.Team != Character.Team || this.Team == -1 || Character.Team == -1) && Character != this;
		}

        public static Character Shiro(String Color)
        {
			return new Character (GameResources.Characters["Shiro"], Color);
        }
        public static Character Kuro(String Color)
        {
			return new Character (GameResources.Characters["Kuro"], Color);
        }
        public static Enemy Enemy1()
        {
			Enemy character = new Enemy (GameResources.Characters["Enemy1"], "Black");
            character.Weapon = null;
			character.Team = 11;
            return character;
        }
		public static Enemy Enemy2()
        {
			Enemy character = new Enemy (GameResources.Characters["Enemy2"], "Black");
            character.Weapon = null;
			character.Team = 11;
            return character;
        }
		public static Enemy Enemy3()
        {
			Enemy character = new Enemy (GameResources.Characters["Enemy3"], "Black");
            character.Weapon = null;
			character.Team = 11;
            return character;
        }
		public static Enemy Enemy4()
        {
			Enemy character = new Enemy (GameResources.Characters["Enemy4"], "Black");
            character.Weapon = null;
			character.Team = 11;
            return character;
        }
    }
}
