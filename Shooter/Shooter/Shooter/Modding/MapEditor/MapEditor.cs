using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shooter.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter.Modding.MapEditor
{
    public class MapEditor : IScene
    {
        EditorTextureList textureList = new EditorTextureList();
        EditorGrid grid = new EditorGrid();

        Texture2D background;
        Camera camera = new Camera();
        Vector2 mapPosition { get { return new Vector2(textureList.Size.X, 0); } }
        Vector2 mapSize { get { return new Vector2(Engine.WindowWidth - textureList.Size.X, Engine.WindowHeight - textureList.BottomSize.Y); } }

        public void Load() 
        {
            camera.RenderingPosition = mapPosition;
            camera.RenderingSize = mapSize;

            grid.GridSize = new Point(20, 20);

            textureList.LoadTexture("Modding/MapEditor/Textures/Metal0.png");
            textureList.LoadTexture("Modding/MapEditor/Textures/Metal1.png");
            textureList.LoadTexture("Modding/MapEditor/Textures/Metal2.png");
            textureList.LoadTexture("Modding/MapEditor/Textures/Metal3.png");
            textureList.LoadTexture("Modding/MapEditor/Textures/Metal4.png");
            textureList.LoadTexture("Modding/MapEditor/Textures/Metal5.png");
            textureList.LoadTexture("Modding/MapEditor/Textures/Metal6.png");
            textureList.LoadTexture("Modding/MapEditor/Textures/Metal8.png");
            textureList.LoadTexture("Modding/MapEditor/Textures/Metal8.png");
            textureList.LoadTexture("Modding/MapEditor/Textures/Metal9.png");

            background = Engine.Content.Load<Texture2D>("TestBackground");
        }
        public void Update() 
        {
            textureList.Update();

            if (Engine.MouseClick)
            {
                int index = grid.ColideWithGrid(Engine.MousePosition);
                if (index != -1) 
                {
                    grid.GridTexture[index] = textureList.SelectedIndex;
                }
            }

            if (Engine.KeyClick(Keys.O))
            {
                camera.Zoom *= 1.2f;
            }
            if (Engine.KeyClick(Keys.P))
            {
                camera.Zoom /= 1.2f;
            }
        }
        public void Draw() 
        {
            textureList.Draw();
            camera.Draw(background, mapPosition, mapSize, null, Color.White, 0);
            grid.Draw(camera, textureList.Textures);
        }
    }
}
