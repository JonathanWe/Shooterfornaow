using System;
using System.Collections.Generic;
using Adamo;

namespace Shooter
{
	public class Map2
	{
		Texture2D background;
		SpriteSheet ObjectsSheet;

		public List<MapObject> Objects = new List<MapObject>();

		public Map2 ()
		{
		}

		public void Draw()
		{
			for (int i = 0; i < Objects.Count; i++)
			{
				Objects[i].Draw();
			}
		}
	}
}

