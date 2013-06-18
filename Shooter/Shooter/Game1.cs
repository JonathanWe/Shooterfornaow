using System;
using System.Collections.Generic;
using Adamo;

namespace Shooter
{
    public class Game1 : IWindow
    {
        SpriteBatch spriteBatch;

        public Game1()
        {
        }

        public  void Load()
        {
            spriteBatch = new SpriteBatch(new Vector2(Window.Current.Width, Window.Current.Height));
            Engine.SpriteBatch = spriteBatch;
			GameResources.LoadBasicResources ();
            Engine.Cursor = Cursor.MenuCursor();

            Engine.CurrentScene = new Menu();
            Engine.CurrentScene.Load();
        }

        public void Update()
        {
            if (Window.Current.Keyboard.KeyClick(Keys.F11))
            {
//                graphics.ToggleFullScreen();
            }

            Engine.CurrentScene.Update();
        }

        public void Draw()
        {
            GraphicsDevice.Clear(AlphaColor.CornflowerBlue);

            Engine.CurrentScene.Draw();
            Engine.Cursor.Draw();
            spriteBatch.Finish();
        }
    }
}
