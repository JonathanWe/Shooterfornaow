using System;
using System.Collections.Generic;
using System.Text;
using Adamo;
using System.Globalization;

namespace Shooter
{
    public class Weapon
    {
		public SpriteAnimation ShootAnimation = new SpriteAnimation();
		public WeaponData WeaponData;

        bool playShootAnimation = false;
        float timer = 0;


        public Weapon(SpriteSheet Sheet)
        {
            this.WeaponData.WeaponSheet = Sheet;
        }

        /// <summary>
        /// Retrieves data from textfiles and creates values. Also sets gunfiresound and animationspeed
        /// </summary>
        /// <param name="File">weaponname</param>
        public Weapon(WeaponData Data) 
        {
			WeaponData = Data;
			ShootAnimation.AnimationSpeed = WeaponData.ShootAnimationSpeed;

            ShootAnimation.AddFrames(WeaponData.WeaponSheet.GetAnimationRectangles("Shoot"));
            ShootAnimation.Loop = true;
            ShootAnimation.Animating = true;
            ShootAnimation.OnFinished += new EventHandler(ShootAnimation_OnFinished);
        }

        void ShootAnimation_OnFinished(object sender, EventArgs e)
        {
            playShootAnimation = false;
            ShootAnimation.CurrentFrame = 0;
        }

        public void Update(bool Shooting, Vector2 Position, Vector2 Destination) 
        {
            if (Shooting) 
            {
				if (timer >= WeaponData.RateOfFire) 
                {
                    timer = 0;
                    playShootAnimation = true;
                    ShootAnimation.CurrentFrame = 0;
                    ShootAnimation.Animating = true;

                    //Test of gunfire sounds
                    GameResources.Gunfire.Play();

					Position = Position + WeaponData.GunPosition;

                    float degrees = (float)Math.Atan2(Destination.Y - Position.Y, Destination.X - Position.X);
					Vector2 transBulletPos = Vector2.Transform(WeaponData.BulletStartPosition, Matrix4.CreateRotation(Vector3.UnitZ, degrees));
					Vector2 transOffset = Vector2.Transform(WeaponData.GunOffset, Matrix4.CreateRotation(Vector3.UnitZ, degrees));
                    Position = Position + transBulletPos - transOffset;
					new Bullet(Position, Destination, WeaponData.BulletSpeed, WeaponData.Damage);
                }
            }
            if (playShootAnimation) ShootAnimation.Update();
			if (timer < WeaponData.RateOfFire) timer += (float)FrameTime.Elapsed.Seconds;
        }

        public void Draw(Vector2 Position, float Degrees) 
        {
            Rectangle frame = ShootAnimation.GetFrame();
			bool flipY = false;
			if (AdamoMath.ToRadians (90) > Degrees && AdamoMath.ToRadians (-90) < Degrees)
				flipY = false;
			else
				flipY = true;
			Engine.Camera.Draw(WeaponData.WeaponSheet.Texture, new Vector2(Position.X + WeaponData.GunPosition.X, Position.Y + WeaponData.GunPosition.Y), new Vector2(WeaponData.GunSize.X, WeaponData.GunSize.Y), frame, AlphaColor.White, 0.2f, new Vector2(WeaponData.GunOffset.X, WeaponData.GunOffset.Y), Degrees, false, flipY);
        }

        public static Weapon DefaultWeapon() 
        {
            return new Weapon(GameResources.Weapons["M4A1"]);
        }
    }
}