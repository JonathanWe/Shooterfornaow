using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Globalization;

namespace Shooter
{
    public class Weapon
    {
        public int ShopPrice;
        public int AmmoPrice;
        public int AmmoLeft;
        public int MaxAmmo;
        public int StartAmmo;
        public int AmmoPerClip;
        public float RateOfFire;
        public float ReloadTime;
        public float Damage;
        public float BulletSpeed;
        public bool Automatic = false;
        public SpriteSheet WeaponSheet;
        public Animation ShootAnimation = new Animation();
        public Vector2 GunPosition = new Vector2();
        public Point GunSize = new Point(70, 40);

        //Test of GunEffect
        public GameSoundEffect M4A1 = new GameSoundEffect();


        public Weapon(SpriteSheet Sheet)
        {
            this.WeaponSheet = Sheet;
        }
        public Weapon(string File) 
        {
            
            //Test of gunfire sounds
            M4A1.Load("Content/Sounds/Weapons/M4A1Fire.wav");

            ShootAnimation.AnimationSpeed = 0.1f;

            StatusScript script = new StatusScript(System.IO.File.ReadAllText(File));
            string name;
            string value;
            while (script.NextCommand(out name, out value))
            {
                name = name.ToLower();

                if (name == "texture") 
                {
                    WeaponSheet = new SpriteSheet(value);
                }
                else if (name == "position")
                {
                    string[] split = value.Split(',');
                    GunPosition = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "size")
                {
                    string[] split = value.Split(',');
                    GunSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
                }
                else if (name == "damage")
                {
                    Damage = float.Parse(value, CultureInfo.InvariantCulture);
                }
                else if (name == "bulletspeed")
                {
                    BulletSpeed = float.Parse(value, CultureInfo.InvariantCulture);
                }
                else if (name == "shopprice")
                {
                    ShopPrice = int.Parse(value);
                }
                else if (name == "ammoprice")
                {
                    AmmoPrice = int.Parse(value);
                }
                else if (name == "startammo")
                {
                    StartAmmo = int.Parse(value);
                }
                else if (name == "ammoperclip")
                {
                    AmmoPerClip = int.Parse(value);
                }
                else if (name == "rateoffire")
                {
                    RateOfFire = float.Parse(value, CultureInfo.InvariantCulture);
                }
                else if (name == "reloadtime")
                {
                    ReloadTime = float.Parse(value, CultureInfo.InvariantCulture);
                }
                else if (name == "automatic")
                {
                    Automatic = bool.Parse(value);
                }
                else if (name == "animation.shootspeed") 
                {
                    ShootAnimation.AnimationSpeed = float.Parse(value, CultureInfo.InvariantCulture);
                }
            }
            ShootAnimation.AddFrames(WeaponSheet.GetAnimationRectangles("Shoot"));
            ShootAnimation.Loop = true;
            ShootAnimation.Animating = true;
            ShootAnimation.OnFinished += new EventHandler(ShootAnimation_OnFinished);
        }
        public void CreateBullet(Vector2 Pos, Vector2 Dest)
        {
            new Bullet(Pos, Dest, BulletSpeed);
        }

        void ShootAnimation_OnFinished(object sender, EventArgs e)
        {
            playShootAnimation = false;
            ShootAnimation.CurrentFrame = 0;
        }

        bool playShootAnimation = false;
        float timer = 0;
        public void Update(bool Shooting, Vector2 Position, Vector2 Destination) 
        {
            if (Shooting) 
            {
                if (timer >= RateOfFire) 
                {
                    timer = 0;
                    playShootAnimation = true;
                    ShootAnimation.CurrentFrame = 0;
                    ShootAnimation.Animating = true;

                    //Test of gunfire sounds
                    M4A1.Play();

                    CreateBullet(Position, Destination);
                }
            }
            if (playShootAnimation) ShootAnimation.Update();
            if (timer < RateOfFire) timer += Engine.GameTimeInSec;
        }

        public void Draw(Vector2 Position, float Degrees) 
        {
            Position.Y += GunPosition.Y;
            Rectangle frame = ShootAnimation.GetFrame();
            SpriteEffects spriteEffect;
            if (AdamoMath.ToRadians(90) > Degrees && AdamoMath.ToRadians(-90) < Degrees) spriteEffect = SpriteEffects.None;
            else spriteEffect = SpriteEffects.FlipVertically;
            Engine.SpriteBatch.Draw(WeaponSheet.Texture, new Rectangle((int)(Position.X), (int)(Position.Y), GunSize.X, GunSize.Y), frame, Color.White, Degrees, new Vector2(-GunPosition.X, GunSize.Y / 2) * (new Vector2(frame.Width, frame.Height) / new Vector2(GunSize.X, GunSize.Y)), spriteEffect, 0.2f);
        }


        public static Weapon DefaultWeapon() 
        {
            return new Weapon("Content/Weapons/M4A1.txt");
        }
    }
}