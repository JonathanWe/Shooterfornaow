using System;
using System.Collections.Generic;
using System.Text;
using Adamo;

namespace Shooter
{
    public class Shooter : IScene
    {
		public List<Character> Characters = new List<Character> ();
        public BackgroundSound bgSound = new BackgroundSound();

        float timer = 0;
        Random rnd = new Random();

        /// <summary>
        /// Loads the map, the characters, music and cursor
        /// </summary>
        public void Load()
        {
			GameResources.LoadInGameResources ();
            Engine.Map = new Map();
            Engine.Map.Load("test.map");
            bgSound.Load();
            Engine.Cursor = Cursor.GameCursor();
			Characters.Add (new Player(Player.SelectedPlayer.CharacterData, Player.SelectedPlayer.CharacterColor)); //needs weapon
			FrameTime.Elapsed.Reset ();
        }

        /// <summary>
        /// Updatesthe players and enemies. Spawning a new enemy every 2 seconds
        /// </summary>
        public void Update()
        {
			timer += (float)FrameTime.Elapsed.Seconds;
            if (timer > 2)
            {
                int enemyType = rnd.Next(4);
                if (enemyType == 0)
                    Characters.Add(Character.Enemy1());
                else if (enemyType == 1)
					Characters.Add(Character.Enemy2());
                else if (enemyType == 2)
					Characters.Add(Character.Enemy3());
                else if (enemyType == 3)
					Characters.Add(Character.Enemy4());
                timer = 0;
            }

			for (int i = 0; i < Characters.Count; i++)
            {
				Characters[i].Update();
            }
            Bullet.UpdateAllBullets();
            bgSound.Update();
          
            
        }

        /// <summary>
        /// Draw the maps, characters and bullets
        /// </summary>
        public void Draw()
        {
            Engine.Map.Draw();
			for (int i = 0; i < Characters.Count; i++)
            {
				Characters[i].Draw();
            }
            Bullet.DrawAllBullets();
        }
    }
}
