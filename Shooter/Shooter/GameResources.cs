using System;
using System.Collections.Generic;
using System.Text;
using Adamo;

namespace Shooter
{
    public class GameResources
    {
		static bool inGameResourcesLoaded = false;

		//General
        public static Font DefaultFont;
        public static SpriteSheet BulletSheet;
        public static GameSoundEffect Gunfire;

		//Menu
		public static SpriteSheet GUISheet;
		public static Texture2D PlayerScreen1;
		public static Texture2D PlayerScreen2;
		public static Texture2D CharacterCustBackground;

		//In game resources
		public static Dictionary<string, CharacterData> Characters = new Dictionary<string, CharacterData> ();
		public static Dictionary<string, WeaponData> Weapons = new Dictionary<string, WeaponData> ();

		public static void LoadBasicResources()
		{
			GUISheet = new SpriteSheet("Content/GUISheet.sht");
			BulletSheet = new SpriteSheet("Content/BulletSheet.sht");
			DefaultFont = new Font ("Content/Font/DefaultFont.fnt");

			PlayerScreen1 = Texture2D.FromFile ("Content/Player Selec Screen2.png");
			PlayerScreen2 = Texture2D.FromFile ("Content/Player Selec Screen3.png");

			CharacterCustBackground = Texture2D.FromFile ("Content/BGCharCuz.jpg");

			Characters.Add ("Shiro", new CharacterData ("Content/Characters/Player/Shiro/Shiro.txt"));
			Characters.Add ("Kuro", new CharacterData ("Content/Characters/Player/Kuro/Kuro.txt"));

			String [] files = System.IO.Directory.GetFiles("Content/Weapons");
			for (int i = 0; i < files.Length; i++)
			{
				if (files[i].EndsWith(".txt")) 
				{
					var fileInfo = new System.IO.FileInfo (files[i]);
					Weapons.Add(fileInfo.Name.Substring(0, fileInfo.Name.Length - 4), new WeaponData(files[i]));
				}
			}
		}

		public static void LoadInGameResources()
		{
			if (!inGameResourcesLoaded)
			{
				GameResources.Gunfire = new GameSoundEffect ();
				GameResources.Gunfire.Load ("Content/Sounds/Weapons/M4A1Fire.wav");
				
				Characters.Add ("Enemy1", new CharacterData ("Content/Characters/NPC_mob/Zombie1.txt"));
				Characters.Add ("Enemy2", new CharacterData ("Content/Characters/NPC_mob/Zombie2.txt"));
				Characters.Add ("Enemy3", new CharacterData ("Content/Characters/NPC_mob/Zombie3.txt"));
				Characters.Add ("Enemy4", new CharacterData ("Content/Characters/NPC_mob/Zombie4.txt"));
				inGameResourcesLoaded = true;
			}
		}
    }
}