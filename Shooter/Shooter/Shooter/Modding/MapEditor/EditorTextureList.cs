using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Shooter.Modding.MapEditor
{
    public class EditorTextureList
    {
        public List<Texture2D> Textures = new List<Texture2D>();
        public List<string> TexturePaths = new List<string>();
        public Vector2 Size = new Vector2(150, 0);

        public EditorTextureList() 
        {
            Size.Y = Engine.WindowHeight;
        }

        public void LoadTexture(string TexturePath) 
        {
            Textures.Add(Texture2D.FromStream(Engine.Device, new System.IO.MemoryStream(System.IO.File.ReadAllBytes(TexturePath))));
            TexturePaths.Add(TexturePath);
        }
        public void Update() 
        {

        }
        public void Draw() 
        {
            for (int i = 0; i < Textures.Count; i++)
            {
                Vector2 position = new Vector2();
                position.X = i % 2 * 64;
                position.Y = (int)(i / 2) * 64;
                Engine.SpriteBatch.Draw(Textures[i], new RectangleF(position, new Vector2(32, 32)), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.11f);
            }
        }
    }
}
