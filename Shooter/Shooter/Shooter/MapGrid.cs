
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    public class MapGrid
    {
        public Point GridSize;
        public Vector2 GridElementSize = new Vector2(64, 64);
        public int[] GridTexture; //This says what texture is rendered in the grid
        public bool DisplayGrid = true;

        public Texture2D Background;
        public string BackgroundName;

        public List<Texture2D> Textures = new List<Texture2D>();
        public List<string> TextureNames = new List<string>();

        /// <summary>
        /// Adds textures into the Textures list
        /// </summary>
        /// <param name="TexturePath">Path to the texture in content</param>
        public void LoadTexture(string TexturePath)
        {
            Textures.Add(Texture2D.FromStream(Engine.Device, new System.IO.MemoryStream(System.IO.File.ReadAllBytes(TexturePath))));
            TextureNames.Add(TexturePath);
        }

        /// <summary>
        /// Draws the map, using a map file
        /// </summary>
        /// <param name="Map">Path to the map file</param>
        public void LoadMap(string Map)
        {
            int offset = 0;
            byte[] data = System.IO.File.ReadAllBytes(Map);
            GridSize.X = data[0];
            GridSize.Y = data[1];
            GridTexture = new int[GridSize.X * GridSize.Y];
            int bgLength = BitConverter.ToInt32(data, 2);
            BackgroundName = System.Text.ASCIIEncoding.Default.GetString(data, 6, bgLength);
            Background = Texture2D.FromStream(Engine.Device, new System.IO.MemoryStream(System.IO.File.ReadAllBytes(BackgroundName)));
            int textures = data[6 + bgLength];
            offset = 7 + bgLength;
            for (int i = 0; i < textures; i++)
            {
                int count = data[offset];
                LoadTexture(System.Text.ASCIIEncoding.Default.GetString(data, offset + 1, count));
                offset += count + 1;
            }
            for (int i = 0; i < GridTexture.Length; i++)
            {
                GridTexture[i] = (SByte)data[i + offset];
            }
        }

        /// <summary>
        /// Returns index of grid-square that the input position is in
        /// </summary>
        public int ColideWithGrid(Vector2 Position) 
        {
            int index = -1;
            for (int x = 0; x < GridSize.X; x++)
            {
                if (AdamoMath.IsBetween(x * GridElementSize.X, (x + 1) * GridElementSize.X, Position.X))
                {
                    index = x;
                    break;
                }
            }
            for (int y = 0; y < GridSize.Y; y++)
            {
                if (AdamoMath.IsBetween(y * GridElementSize.Y, (y + 1) * GridElementSize.Y, Position.Y))
                {
                    index = index + y * GridSize.X;
                }
            }
            return index;
        }

        /// <summary>
        /// Used to check if anything collides with the block. If it does, it will set the object back to the previous locations
        /// </summary>
        public int ColideWithBlock(Vector2 Position, Vector2 Size) 
        {
            for (int y = 0; y < GridSize.Y; y++)
            {
                for (int x = 0; x < GridSize.X; x++)
                {
                    if (Engine.Collide(new Vector2(x * GridElementSize.X, y * GridElementSize.Y), GridElementSize, Position, Size) && GridTexture[y * GridSize.X + x] != -1)
                        return y * GridSize.X + x;
                }
            }
            return -1;
        }

        /// <summary>
        /// Gets the position of value in the index
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public Vector2 GetPositionFromIndex(int Index) 
        {
            return new Vector2(Index % GridSize.X * GridElementSize.X, Index / GridSize.X * GridElementSize.Y);
        }

        /// <summary>
        /// Used to draw the blocks and background
        /// </summary>
        /// <param name="Camer"></param>
        public void Draw(Camera Camer) 
        {
            //Draw Background
            Engine.SpriteBatch.Draw(Background, new Rectangle(0, 0, Engine.WindowWidth, Engine.WindowHeight), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);

            //Draw blocks
            for (int i = 0; i < GridTexture.Length; i++)
            {
                if (GridTexture[i] != -1)
                {
                    int x = i % GridSize.X;
                    int y = i / GridSize.X;
                    Camer.Draw(Textures[GridTexture[i]], new Vector2(x * GridElementSize.X, y * GridElementSize.Y), GridElementSize, null, Color.White, 0.5f); 
                }
            }

            if (DisplayGrid)
            {
                //Draws grid
                for (int x = 0; x < GridSize.X + 1; x++)
                {
                    Camer.Draw(GameResources.WhiteTexture, new Vector2(0, GridElementSize.Y * x), new Vector2(GridElementSize.X * GridSize.X, 1 / Camer.Zoom), null, Color.Black, 0.51f);
                }
                for (int y = 0; y < GridSize.X + 1; y++)
                {
                    Camer.Draw(GameResources.WhiteTexture, new Vector2(GridElementSize.X * y, 0), new Vector2(1 / Camer.Zoom, GridElementSize.Y * GridSize.Y), null, Color.Black, 0.51f);
                } 
            }
        }

        /// <summary>
        /// Saves the custom map to a file
        /// </summary>
        public void SaveMap()
        {
            List<byte> mapData = new List<byte>();
            mapData.Add((byte)GridSize.X); //Stores the grids in the x axiss in [0] int he array as byte
            mapData.Add((byte)GridSize.Y);
            mapData.AddRange(BitConverter.GetBytes(BackgroundName.Length)); //stores the length of the string
            mapData.AddRange(System.Text.ASCIIEncoding.Default.GetBytes(BackgroundName)); //Stores the string data
            mapData.Add((byte)TextureNames.Count); //Store how many Textures to load. Max 256 textures
            for (int i = 0; i < TextureNames.Count; i++)
            {
                byte[] stringData = System.Text.ASCIIEncoding.Default.GetBytes(TextureNames[i]);
                mapData.Add((byte)stringData.Length);
                mapData.AddRange(stringData);
            }
            for (int i = 0; i < GridSize.X * GridSize.Y; i++)
            {
                mapData.Add(BitConverter.GetBytes((SByte)GridTexture[i])[0]); //Stores the texture as a byte id
            }
            System.IO.File.WriteAllBytes("test.map", mapData.ToArray());
        }
    }
}
