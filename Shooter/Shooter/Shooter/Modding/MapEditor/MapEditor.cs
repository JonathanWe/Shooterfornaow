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

        //Used to navigate int the grid part of the editor
        Vector2 dragMountPoint;
        bool dragging;

        public void Load() 
        {
            camera.RenderingPosition = mapPosition;
            camera.RenderingSize = mapSize;

            grid.GridSize = new Point(20, 20);
            grid.GridTexture = new int[20 * 20];
            for (int i = 0; i < 20*20; i++)
            {
                grid.GridTexture[i] =  - 1;
            }

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

            //Placing blocks
            if (Engine.MouseClick && !dragging)
            {
                int index = grid.ColideWithGrid(Engine.MousePosition);
                if (index != -1) 
                {
                    if (grid.GridTexture[index] != textureList.SelectedIndex)
                    {
                        grid.GridTexture[index] = textureList.SelectedIndex;
                    }
                    else grid.GridTexture[index] = -1;
                }
            }
            //Draging around the mapEditor
            if (Engine.MouseDown && !dragging)
            {
                if (Engine.MouseLastDown == false)
                {
                    dragMountPoint = Engine.MousePosition;
                }
                if ((dragMountPoint - Engine.MousePosition).Length() > 3)
                {
                    dragging = true;
                }
            }
            else dragging = false;
            if (dragging)
            {
                camera.Position = dragMountPoint - Engine.MousePosition;
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
