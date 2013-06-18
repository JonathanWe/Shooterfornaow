using System;
using System.Collections.Generic;
using System.Text;
using Adamo;
using Shooter.GUI;

namespace Shooter.Modding.MapEditor
{
    public class EditorTextureList
    {
        public Vector2 Size = new Vector2(150, 0);
        public Vector2 BottomSize = new Vector2(0, 100);
        public int SelectedIndex = -1;
        public MapGrid Grid;
        public Texture2D SelectedTexture 
        { 
            get
            {
                if (SelectedIndex >= 0 && SelectedIndex < Grid.Textures.Count) return Grid.Textures[SelectedIndex];
                else return null;
            } 
        }

        GUI.Button btnBackground = new GUI.Button("LoadBG");
        GUI.Button btnSave = new GUI.Button("SaveButton");
        TextBox tbGridX = new TextBox("NumberTextbox");
        TextBox tbGridY = new TextBox("NumberTextbox");

        float margin = 12;
        float textureDistance = 16;
        Vector2 textureSize = new Vector2(64, 64);

        public EditorTextureList() 
        {
            Size.X = Engine.WindowWidth / 5;
            Size.Y = Engine.WindowHeight;
            BottomSize.X = Engine.WindowWidth;
            BottomSize.Y = Engine.WindowHeight / 5;

            btnSave.Position = new Vector2(800, 650);
            btnSave.Size = new Vector2(100, 100);
            btnSave.Z = 0.622f;
            btnSave.OnClick += new EventHandler(btnSave_OnClick);
        }

        void btnSave_OnClick(object sender, EventArgs e)
        {
            Grid.SaveMap();
        }
        public void Update() 
        {
            btnBackground.Update();
            tbGridX.Update();
            tbGridY.Update();
            btnSave.Update();
            for (int i = 0; i < Grid.Textures.Count; i++)
            {
                Vector2 position = getPositionFromindex(i);
                if (Mouse.Click() && Engine.Collide(position, textureSize, Mouse.Position, Vector2.Zero))
                {
                    SelectedIndex = i;
                }
            }
        }
        public void Draw() 
        {
			Engine.SpriteBatch.Draw (GameResources.GUISheet.Texture, Vector2.Zero, Size, 0.52f, GameResources.GUISheet.GetSprite ("Y"), Vector2.Zero, 0, AlphaColor.White);
            Engine.SpriteBatch.Draw(GameResources.GUISheet.Texture, new Vector2(0, Engine.WindowHeight - BottomSize.Y), BottomSize, 0.5201f, GameResources.GUISheet.GetSprite("X"), Vector2.Zero, 0, AlphaColor.White);
            for (int i = 0; i < Grid.Textures.Count; i++)
            {
                Vector2 position = getPositionFromindex(i);
                if (i == SelectedIndex)
                    Engine.SpriteBatch.Draw(Texture2D.WhiteTexture(), position - new Vector2(textureDistance / 2, textureDistance / 2), textureSize + new Vector2(textureDistance, textureDistance), 0.521f, null, Vector2.Zero, 0, new AlphaColor(1f, 1f, 0f, 0.00f));
                else if (Engine.Collide(position, textureSize, Mouse.Position, Vector2.Zero))
                    Engine.SpriteBatch.Draw(Texture2D.WhiteTexture(), position - new Vector2(textureDistance / 2, textureDistance / 2), textureSize + new Vector2(textureDistance, textureDistance), 0.521f, null, Vector2.Zero, 0, AlphaColor.CornflowerBlue);
                Engine.SpriteBatch.Draw(Grid.Textures[i], position, textureSize, 0.522f, null, Vector2.Zero, 0, AlphaColor.White);
            }
            btnBackground.Draw();
            tbGridX.Draw();
            tbGridY.Draw();
            btnSave.Draw();
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