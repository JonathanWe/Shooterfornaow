using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Shooter
{
    public class Weapon
    {
        public int AmmoLeft;
        public int MaxAmmo;
        public int RateOfFire;
        public int ReloadTime;
        public float RecoilForce;
        public Texture2D WeaponTexture;
        public Point GunSize = new Point(70, 40);
        public Rectangle Frame;

        Vector2 gunOrigin = new Vector2(-60, 20);

        public Weapon(Texture2D GunTexture, Rectangle Frame) 
        {
            this.WeaponTexture = GunTexture;
            this.Frame = Frame;
        }

        public void Draw(Vector2 Position, float Degrees) 
        {
            Engine.SpriteBatch.Draw(WeaponTexture, new Rectangle((int)(Position.X), (int)(Position.Y), GunSize.X, GunSize.Y), Frame, Color.White, Degrees, gunOrigin * (new Vector2(Frame.Width, Frame.Height) / new Vector2(GunSize.X, GunSize.Y)), SpriteEffects.None, 0.2f);
        }


        public static Weapon DefaultWeapon() 
        {
            var sheet = new SpriteSheet("Content/Weapons/Guns.sht");
            return new Weapon(sheet.Texture, sheet.GetSprite("Gun0"));
        }
    }
}