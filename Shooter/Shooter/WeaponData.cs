using System;
using Adamo;
using System.Globalization;

namespace Shooter
{
	public struct WeaponData
	{
		public SpriteSheet WeaponSheet;
		public int ShopPrice;
		public int AmmoPrice;
		public int AmmoLeft;
		public int MaxAmmo;
		public int StartAmmo;
		public int AmmoPerClip;
		public float RateOfFire;
		public float ReloadTime;
		public float Damage;
		public float BulletSpeed;
		public float ShootAnimationSpeed;
		public Vector2 BulletStartPosition;
		public bool Automatic;
		public Vector2 GunPosition;
		public Vector2 GunOffset;
		public Point GunSize;

		public WeaponData(string File)
		{
			//Sets default values
			WeaponSheet = null;
			ShopPrice = 0;
			AmmoPrice = 0;
			AmmoLeft = 0;
			MaxAmmo = 0;
			StartAmmo = 0;
			AmmoPerClip = 0;
			RateOfFire = 0;
			ReloadTime = 0;
			Damage = 0;
			BulletSpeed = 0;
			ShootAnimationSpeed = 0.1f;
			BulletStartPosition = Vector2.Zero;
			Automatic = false;
			GunPosition = Vector2.Zero;
			GunOffset = Vector2.Zero;
			GunSize = new Point (70, 40);

			//Calculates data out from a text file
			StatusScript script = new StatusScript(System.IO.File.ReadAllText(File));
			string name;
			string value;
			while (script.NextCommand(out name, out value))
			{
				name = name.ToLower();

				if (name == "texture") 
				{
					WeaponSheet = new SpriteSheet (value);
				}
				else if (name == "position")
				{
					string[] split = value.Split(',');
					GunPosition = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "offset")
				{
					string[] split = value.Split(',');
					GunOffset = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "size")
				{
					string[] split = value.Split(',');
					GunSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
				}
				else if (name == "damage")
				{
					Damage = float.Parse(value, CultureInfo.InvariantCulture);
				}
				else if (name == "bulletspeed")
				{
					BulletSpeed = float.Parse(value, CultureInfo.InvariantCulture);
				}
				else if (name == "bulletstartposition")
				{
					string[] split = value.Split(',');
					BulletStartPosition = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "shopprice")
				{
					ShopPrice = int.Parse(value);
				}
				else if (name == "ammoprice")
				{
					AmmoPrice = int.Parse(value);
				}
				else if (name == "startammo")
				{
					StartAmmo = int.Parse(value);
				}
				else if (name == "ammoperclip")
				{
					AmmoPerClip = int.Parse(value);
				}
				else if (name == "rateoffire")
				{
					RateOfFire = float.Parse(value, CultureInfo.InvariantCulture);
				}
				else if (name == "reloadtime")
				{
					ReloadTime = float.Parse(value, CultureInfo.InvariantCulture);
				}
				else if (name == "automatic")
				{
					Automatic = bool.Parse(value);
				}
				else if (name == "animation.shootspeed") 
				{
					ShootAnimationSpeed = float.Parse(value, CultureInfo.InvariantCulture);
				}
			}
		}
	}
}

