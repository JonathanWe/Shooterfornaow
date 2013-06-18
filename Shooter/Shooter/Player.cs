using System;
using System.Collections.Generic;
using System.Text;
using Adamo;

namespace Shooter
{
    public class Player : Character
    {
        public static Character SelectedPlayer;
        public static int PlayerScore = 0;

        float health = 100;
        public override float Health
        {
            get { return health; }
            set 
            {
                if (health > value)
                    IsHit = true;
                health = value;
            }
        }

		public Player(CharacterData Data, string Color) : base (Data, Color)
		{
		}

        /// <summary>
        /// Updates the position of the character depending on which button is pressed
        /// </summary>
        public override void Update() 
        {
            if (Health <= 0)
            {
                //GameOver
                Engine.CurrentScene = new GameOver();
                Engine.CurrentScene.Load();
                Engine.Cursor = Cursor.MenuCursor();
                Engine.Camera = new Camera();
                return;
            }

            //Input
			if (Window.Current.Keyboard.KeyDown(Keys.Left) | Window.Current.Keyboard.KeyDown(Keys.A))
            {
                MoveLeft();
            }
			if (Window.Current.Keyboard.KeyDown(Keys.Right) || Window.Current.Keyboard.KeyDown(Keys.D))
            {
                MoveRight();
            }
			if ((Window.Current.Keyboard.KeyDown(Keys.Up) || Window.Current.Keyboard.KeyDown(Keys.W)))
            {
                Jump();
            }
            if (Weapon != null) Weapon.Update(Mouse.Down(), Position + CharacterData.WeaponMountPoint, Engine.Camera.MousePosition);

            base.Update();

            Engine.Camera.Position = Position - new Vector2(Engine.WindowWidth / 2, Engine.WindowHeight / 2);
        }

        /// <summary>
        /// Draws the character
        /// </summary>
        public override void Draw() 
        {
            base.Draw();
        }
    }
}
