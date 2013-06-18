using System;
using Adamo;
using System.Globalization;

namespace Shooter
{
	public struct CharacterData
	{
		public SpriteSheet Sheet;
		public float RunAnimationSpeedL;
		public float RunAnimationSpeedR;
		public Vector2 WeaponMountPoint;
		public float MaxSpeed;
		public float JumpStrength;
		public Vector2 BoundingBox;

		public Point HeadR1Size;
		public Point HeadL1Size;
		public Point HeadR2Size;
		public Point HeadL2Size;
		public Vector2 HeadR1Offset;
		public Vector2 HeadL1Offset;
		public Vector2 HeadR2Offset;
		public Vector2 HeadL2Offset;

		public Point BodyRunRSize;
		public Point BodyStandRSize;
		public Vector2 BodyRunROffset;
		public Vector2 BodyStandROffset;
		public Point BodyRunLSize;
		public Point BodyStandLSize;
		public Vector2 BodyRunLOffset;
		public Vector2 BodyStandLOffset; 

		public CharacterData(string File)
		{
			//Sets default values
			Sheet = null;
			RunAnimationSpeedL = 0.1f;
			RunAnimationSpeedR = 0.1f;
			WeaponMountPoint = Vector2.Zero;
			MaxSpeed = 300;
			JumpStrength = 820;
			BoundingBox = new Vector2 (110, 155);

			HeadR1Size = new Point (55, 55);
			HeadL1Size = new Point (55, 55);
			HeadR2Size = new Point (55, 55);
			HeadL2Size = new Point (55, 55);
			HeadR1Offset = new Vector2 (47, 10);
			HeadL1Offset = new Vector2 (47, 10);
			HeadR2Offset = new Vector2 (47, 10);
			HeadL2Offset = new Vector2 (47, 10);

			BodyRunRSize = new Point (90, 110);
			BodyStandRSize = new Point (60, 110);
			BodyRunROffset = new Vector2 (0, 45);
			BodyStandROffset = new Vector2 (55, 47);
			BodyRunLSize = new Point (90, 110);
			BodyStandLSize = new Point (60, 110);
			BodyRunLOffset = new Vector2 (0, 45);
			BodyStandLOffset = new Vector2 (55, 47);

			//Calculates data out from a text file
			string text = System.IO.File.ReadAllText(File);
			{
				string[] split = text.Split('\n');
				text = "";
				for (int i = 0; i < split.Length; i++)
				{
					if (split[i].Trim().StartsWith("//")) continue;
					else text += split[i] + "\n";
				}
			}
			string[] code = TextHelper.RemoveDoubble(text.Replace("\n", "").Replace("\r", "").Replace("\t", " "), ' ').Split(';');

			for (int i = 0; i < code.Length; i++)
			{
				string[] split = code[i].Trim().Split('=');
				if (split.Length < 2) continue;
				string name = split[0].Trim().ToLower();
				string value = split[1].Trim();

				if (name == "texture")
				{
					Sheet = new SpriteSheet(value);
				}
				if (name == "animation.runspeed")
				{
					RunAnimationSpeedL = float.Parse(value, CultureInfo.InvariantCulture);
					RunAnimationSpeedR = RunAnimationSpeedL;
				}
				if (name == "animation.runspeedr") 
				{
					RunAnimationSpeedR = float.Parse(value, CultureInfo.InvariantCulture);
				}
				if (name == "animation.runspeedl")
				{
					RunAnimationSpeedL = float.Parse(value, CultureInfo.InvariantCulture);
				}
				if (name == "speed") 
				{
					MaxSpeed = float.Parse(value, CultureInfo.InvariantCulture);
				}
				if (name == "jumpstrength")
				{
					JumpStrength = float.Parse(value, CultureInfo.InvariantCulture);
				}
				if (name == "boundingbox")
				{
					split = value.Split(',');
					BoundingBox = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "weapon.mountpoint")
				{
					split = value.Split(',');
					WeaponMountPoint = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "head.position")
				{
					split = value.Split(',');
					HeadR1Offset = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
					HeadL1Offset = HeadR1Offset;
					HeadR2Offset = HeadR1Offset;
					HeadL2Offset = HeadR1Offset;
				}
				else if (name == "head.size")
				{
					split = value.Split(',');
					HeadR1Size = new Point(int.Parse(split[0], CultureInfo.InvariantCulture), int.Parse(split[1], CultureInfo.InvariantCulture));
					HeadL1Size = HeadR1Size;
					HeadR2Size = HeadR1Size;
					HeadL2Size = HeadR1Size;
				}
				else if (name == "headr1.position")
				{
					split = value.Split(',');
					HeadR1Offset = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "headr1.size")
				{
					split = value.Split(',');
					HeadR1Size = new Point(int.Parse(split[0], CultureInfo.InvariantCulture), int.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "headl1.position")
				{
					split = value.Split(',');
					HeadL1Offset = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "headl1.size")
				{
					split = value.Split(',');
					HeadL1Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
				}
				else if (name == "headr2.position")
				{
					split = value.Split(',');
					HeadR2Offset = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "headr2.size")
				{
					split = value.Split(',');
					HeadR2Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
				}
				else if (name == "headl2.position")
				{
					split = value.Split(',');
					HeadL2Offset = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "headl2.size")
				{
					split = value.Split(',');
					HeadL2Size = new Point(int.Parse(split[0]), int.Parse(split[1]));
				}
				else if (name == "body.position")
				{
					split = value.Split(',');
					BodyRunROffset = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
					BodyStandROffset = BodyRunROffset;
					BodyRunLOffset = BodyRunROffset;
					BodyStandLOffset = BodyRunROffset;
				}
				else if (name == "body.size")
				{
					split = value.Split(',');
					BodyRunRSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
					BodyStandRSize = BodyRunRSize;
					BodyRunLSize = BodyRunRSize;
					BodyStandLSize = BodyRunRSize;
				}
				else if (name == "bodyrunr.position")
				{
					split = value.Split(',');
					BodyRunROffset = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "bodyrunr.size")
				{
					split = value.Split(',');
					BodyRunRSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
				}
				else if (name == "bodystandr.position")
				{
					split = value.Split(',');
					BodyStandROffset = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "bodystandr.size")
				{
					split = value.Split(',');
					BodyStandRSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
				}
				else if (name == "bodyrunl.position")
				{
					split = value.Split(',');
					BodyRunLOffset = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "bodyrunl.size")
				{
					split = value.Split(',');
					BodyRunLSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
				}
				else if (name == "bodystandl.position")
				{
					split = value.Split(',');
					BodyStandLOffset = new Vector2(float.Parse(split[0], CultureInfo.InvariantCulture), float.Parse(split[1], CultureInfo.InvariantCulture));
				}
				else if (name == "bodystandl.size")
				{
					split = value.Split(',');
					BodyStandLSize = new Point(int.Parse(split[0]), int.Parse(split[1]));
				}
			}
		}
	}
}

