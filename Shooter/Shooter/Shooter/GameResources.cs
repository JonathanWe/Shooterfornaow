using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    public class GameResources
    {
        public static Texture2D WhiteTexture;
        public static SpriteFont DefaultFont;
        public static SpriteSheet GUISheet;
        public static SpriteSheet BulletSheet;
        public static Dictionary<string, SpriteSheet> CharacterSheets = new Dictionary<string, SpriteSheet>();
        public static Dictionary<string, SpriteSheet> WeaponSheets = new Dictionary<string, SpriteSheet>();
    }
}
