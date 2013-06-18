using System;
using System.Collections.Generic;
using System.Text;
using Adamo;

namespace Shooter
{
    class CharacterSelection : IScene
    {
		Texture2D PlayerScreen;
        public void Load()
        {
			PlayerScreen = GameResources.PlayerScreen1;
        }
        
        public void Update()
        {
            if (Engine.WindowWidth / 2 > Mouse.Position.X)
            {
				PlayerScreen = GameResources.PlayerScreen1;
                if (Mouse.Click())
                {
                    Engine.CurrentScene = new CharacterCustomization(true);
                    Engine.CurrentScene.Load();
                }
            }
            else 
            { 
				PlayerScreen = GameResources.PlayerScreen2;
                if (Mouse.Click())
                {
                    Engine.CurrentScene = new CharacterCustomization(false);
                    Engine.CurrentScene.Load();
                }
            }
        }

        public void Draw()
        {
            Engine.SpriteBatch.Draw(PlayerScreen, new Vector2(0, 0), new Vector2(Engine.WindowWidth, Engine.WindowHeight), 0);
        }
    }
}
