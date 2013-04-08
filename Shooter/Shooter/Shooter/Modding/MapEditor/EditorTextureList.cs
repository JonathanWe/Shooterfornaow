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
        public Vector2 BottomSize = new Vector2(0, 100);
        public int SelectedIndex = -1;
        public Texture2D SelectedTexture 
        { 
            get
            {
                if (SelectedIndex >= 0 && SelectedIndex < Textures.Count) return Textures[SelectedIndex];
                else return null;
            } 
        }

        float margin = 12;
        float textureDistance = 16;
        Vector2 textureSize = new Vector2(64, 64);

        public EditorTextureList() 
        {
            Size.X = Engine.WindowWidth / 5;
            Size.Y = Engine.WindowHeight;
            BottomSize.X = Engine.WindowWidth;
            BottomSize.Y = Engine.WindowHeight / 5;
        }

        public void LoadTexture(string TexturePath) 
        {
            Textures.Add(Texture2D.FromStream(Engine.Device, new System.IO.MemoryStream(System.IO.File.ReadAllBytes(TexturePath))));
            TexturePaths.Add(TexturePath);
        }
        public void Update() 
        {
            for (int i = 0; i < Textures.Count; i++)
            {
                Vector2 position = getPositionFromindex(i);
                if (Engine.MouseClick && Engine.Collide(position, textureSize, Engine.MousePosition, Vector2.Zero))
                {
                    SelectedIndex = i;
                }
            }
        }
        public void Draw() 
        {
            Engine.SpriteBatch.Draw(Engine.GUISheet.Texture, new RectangleF(Vector2.Zero, Size), Engine.GUISheet.GetSprite("Y"), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.52f);
            Engine.SpriteBatch.Draw(Engine.GUISheet.Texture, new RectangleF(new Vector2(0, Engine.WindowHeight - BottomSize.Y), BottomSize), Engine.GUISheet.GetSprite("X"), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.5201f);
            for (int i = 0; i < Textures.Count; i++)
            {
                Vector2 position = getPositionFromindex(i);
                if (i == SelectedIndex)
                    Engine.SpriteBatch.Draw(Engine.WhiteTexture, new RectangleF(position - new Vector2(textureDistance / 2, textureDistance / 2), textureSize + new Vector2(textureDistance, textureDistance)), null, new Color(1f, 1f, 0f, 0.00f), 0, Vector2.Zero, SpriteEffects.None, 0.521f);
                else if (Engine.Collide(position, textureSize, Engine.MousePosition, Vector2.Zero))
                    Engine.SpriteBatch.Draw(Engine.WhiteTexture, new RectangleF(position - new Vector2(textureDistance / 2, textureDistance / 2), textureSize + new Vector2(textureDistance, textureDistance)), null, Color.CornflowerBlue, 0, Vector2.Zero, SpriteEffects.None, 0.521f);
                Engine.SpriteBatch.Draw(Textures[i], new RectangleF(position, textureSize), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.522f);
            }
        }
        Vector2 getPositionFromindex(int Index) 
        {
            Vector2 position = new Vector2();
            position.X = Index % 2 * (textureSize.X + textureDistance) + margin;
            position.Y = (int)(Index / 2) * (textureSize.Y + textureDistance) + margin;

            return position;
        }
    }
}