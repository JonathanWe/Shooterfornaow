using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    public class Weapon
    {
        public int AmmoLeft;
        public int MaxAmmo;
        public int RateOfFire;
        public int ReloadTime;
        public float RecoilForce;

        public Texture2D WeapondTexture;
    }
}