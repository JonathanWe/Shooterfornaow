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
        public Vector2 BulletStartPosition;
        public bool Automatic = false;
        public SpriteSheet WeaponSheet;
        public Animation ShootAnimation = new Animation();
        public Vector2 GunPosition = new Vector2();
        public Vector2 GunOffset = new Vector2();
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
                    if (GameResources.CharacterSheets.ContainsKey(value))
                        WeaponSheet = GameResources.CharacterSheets[value];
                    else
                    {
                        WeaponSheet = new SpriteSheet(value);
                        GameResources.CharacterSheets.Add(value, WeaponSheet);
                    }
                }
                else if (name == "position")
                {
                    string[] split = value.Split(',');
                    GunPosition = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
                }
                else if (name == "offset")
                {
                    string[] split = value.Split(',');
                    GunOffset = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
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
                else if (name == "bulletstartposition")
                {
                    string[] split = value.Split(',');
                    BulletStartPosition = new Vector2(float.Parse(split[0]), float.Parse(split[1]));
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

                    Position = Position + GunPosition;

                    float degrees = (float)Math.Atan2(Destination.Y - Position.Y, Destination.X - Position.X);
                    Vector2 transBulletPos = Vector2.Transform(BulletStartPosition, Matrix.CreateRotationZ(degrees));
                    Vector2 transOffset = Vector2.Transform(GunOffset, Matrix.CreateRotationZ(degrees));
                    Position = Position + transBulletPos - transOffset;
                    new Bullet(Position, Destination, BulletSpeed);
                }
            }
            if (playShootAnimation) ShootAnimation.Update();
            if (timer < RateOfFire) timer += Engine.GameTimeInSec;
        }

        public void Draw(Vector2 Position, float Degrees) 
        {
            Rectangle frame = ShootAnimation.GetFrame();
            SpriteEffects spriteEffect;
            if (AdamoMath.ToRadians(90) > Degrees && AdamoMath.ToRadians(-90) < Degrees) spriteEffect = SpriteEffects.None;
            else spriteEffect = SpriteEffects.FlipVertically;
            Engine.Camera.Draw(WeaponSheet.Texture, new Vector2(Position.X + GunPosition.X, Position.Y + GunPosition.Y), new Vector2(GunSize.X, GunSize.Y), frame, Color.White, 0.2f, new Vector2(GunOffset.X, GunOffset.Y) * (new Vector2(frame.Width, frame.Height) / new Vector2(GunSize.X, GunSize.Y)), Degrees, spriteEffect);
        }


        public static Weapon DefaultWeapon() 
        {
            return new Weapon("Content/Weapons/M4A1.txt");
        }
    }
}