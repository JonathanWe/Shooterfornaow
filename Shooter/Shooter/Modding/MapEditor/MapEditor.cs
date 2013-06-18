using System;
using System.Collections.Generic;
using System.Text;
using Shooter.GUI;
using Adamo;

namespace Shooter.Modding.MapEditor
{
    public class MapEditor : IScene
    {
        EditorTextureList textureList = new EditorTextureList();
        MapGrid grid = new MapGrid();

        Vector2 mapPosition { get { return new Vector2(-textureList.Size.X, 0); } }
        Vector2 mapSize { get { return new Vector2(grid.GridElementSize.X * grid.GridSize.X, grid.GridElementSize.Y * grid.GridSize.Y); } }

        //Used to navigate int the grid part of the editor
        Vector2 dragMountPoint;
        Vector2 dragPosition;
        bool dragging;

        public void Load() 
        {
            Engine.Camera.Position = mapPosition;

            textureList.Grid = grid;

            grid.GridSize = new Point(20, 20);
            grid.GridTexture = new int[20 * 20];
            for (int i = 0; i < 20*20; i++)
            {
                grid.GridTexture[i] =  - 1;
            }

            grid.LoadTexture("Content/Modding/MapEditor/Textures/Metal0.png");
			grid.LoadTexture("Content/Modding/MapEditor/Textures/Metal1.png");
			grid.LoadTexture("Content/Modding/MapEditor/Textures/Metal2.png");
			grid.LoadTexture("Content/Modding/MapEditor/Textures/Metal3.png");
			grid.LoadTexture("Content/Modding/MapEditor/Textures/Metal4.png");
			grid.LoadTexture("Content/Modding/MapEditor/Textures/Metal5.png");
			grid.LoadTexture("Content/Modding/MapEditor/Textures/Metal6.png");
			grid.LoadTexture("Content/Modding/MapEditor/Textures/Metal8.png");
			grid.LoadTexture("Content/Modding/MapEditor/Textures/Metal8.png");
			grid.LoadTexture("Content/Modding/MapEditor/Textures/Metal9.png");

            grid.BackgroundName = "Content/TestBackground.png";
            grid.Background = Texture2D.FromFile(grid.BackgroundName);
        }
        public void Update() 
        {
            textureList.Update();

            //Placing blocks
            if (Mouse.Click() && !dragging)
            {
                int index = grid.ColideWithGrid(Engine.Camera.MousePosition);
                if (index != -1) 
                {
                    if (grid.GridTexture[index] != textureList.SelectedIndex)
                    {
                        grid.GridTexture[index] = textureList.SelectedIndex;
                    }
                    else grid.GridTexture[index] = -1;
                }
            }
            //Draging the mapEditor
            if (Mouse.Down() && !dragging)
            {
                if (Mouse.LastDown() == false)
                {
                    dragPosition = Engine.Camera.Position;
                    dragMountPoint = Mouse.Position;
                }
                if ((dragMountPoint - (Vector2)Mouse.Position).Length > 3)
                {
                    dragging = true;
                }
            }
            else dragging = false;
            if (dragging)
            {
                Engine.Camera.Position = dragPosition + dragMountPoint - (Vector2)Mouse.Position;
            }

            //Keyboard Input
			if (Window.Current.Keyboard.KeyClick(Keys.O))
            {
                Engine.Camera.Zoom *= 1.2f;
            }
			if (Window.Current.Keyboard.KeyClick(Keys.P))
            {
                Engine.Camera.Zoom /= 1.2f;
            }
			if (Window.Current.Keyboard.KeyClick(Keys.G))
            {
                grid.DisplayGrid = !grid.DisplayGrid;
            }
        }
        public void Draw() 
        {
            textureList.Draw();
            grid.Draw(Engine.Camera);
        }
    }
}
