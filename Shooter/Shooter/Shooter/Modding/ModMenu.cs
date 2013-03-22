using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Shooter.GUI;

namespace Shooter.Modding
{
    public class ModMenu : IScene
    {
        Texture2D background;
        SpriteSheet Sheet;
        Button btnMapEditor;

        public void Load()
        {
            background = Engine.Content.Load<Texture2D>("MenuBackground");
            btnMapEditor = new Button("MapEditorButton");
            btnMapEditor.Position = new Vector2(300, 200);
            btnMapEditor.Size = new Vector2(300, 100);
            btnMapEditor.Z = 0.01f;
            btnMapEditor.OnClick += new EventHandler(btnMapEditor_OnClick);
        }

        void btnMapEditor_OnClick(object sender, EventArgs e)
        {
            Engine.CurrentScene = new MapEditor.MapEditor();
            Engine.CurrentScene.Load();
        }
        public void Update()
        {
            btnMapEditor.Update();
        }
        public void Draw()
        {
            Engine.SpriteBatch.Draw(background, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), Color.White);
            btnMapEditor.Draw();
        }
    }
}
