using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    public class SpriteSheet
    {
        public Texture2D Texture;
        public Dictionary<string, RectangleF> Sprites = new Dictionary<string, RectangleF>();

        public SpriteSheet() { }
        public SpriteSheet(string File) 
        {
            LoadSpriteSheet(File);
        }

        public void LoadSpriteSheet(string File) 
        {
            byte[] bytes = System.IO.File.ReadAllBytes(File);
            int infoLength = BitConverter.ToInt32(bytes, 0);

            byte[] infoBytes = new byte[infoLength];
            for (int i = 0; i < infoLength; i++)
            {
                infoBytes[i] = bytes[i + 4];
            }
            string sheetInfo = System.Text.Encoding.Unicode.GetString(infoBytes, 0, infoBytes.Length);
            LoadInfo(sheetInfo);
            Texture = Texture2D.FromStream(Engine.Device, new MemoryStream(bytes, 4 + infoLength, bytes.Length - (4 + infoLength)));
        }
        public void LoadSpriteSheet(Texture2D Texture, string SheetInfo) 
        {
            this.Texture = Texture;
            LoadInfo(SheetInfo);
        }
        void LoadInfo(string Info) 
        {
            Sprites.Clear();
            string[] split = Info.Replace("\n", "").Split(';');
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i] != "")
                {
                    string bup = split[i];
                    string name = TextHelper.Between(split[i], "\"", "\"")[0];
                    split[i] = split[i].Substring(name.Length + 2);
                    string[] split2 = split[i].Split('=')[1].Split(',');
                    RectangleF rect = new RectangleF(int.Parse(split2[0]), int.Parse(split2[1]), int.Parse(split2[2]), int.Parse(split2[3]));
                    Sprites.Add(name.Replace("\\\\", "\\").Replace("\\1", "\"").Replace("\\2", ";"), rect);
                }
            }
        }
        public RectangleF GetSprite(string SpriteName)
        {
            return Sprites[SpriteName];
        }
        public RectangleF[] GetAnimationRectangles(string AnimationName)
        {
            List<RectangleF> rects = new List<RectangleF>();
            int i = 0;
            while (true)
            {
                if (Sprites.ContainsKey(AnimationName + i))
                {
                    rects.Add(Sprites[AnimationName + i]);
                }
                else break;
                i++;
            }
            return rects.ToArray();
        }
        public Animation GetAnimation(string AnimationName)
        {
            return new Animation(GetAnimationRectangles(AnimationName));
        }
    }
}
