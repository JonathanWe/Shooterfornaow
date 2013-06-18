using System;
using System.Collections.Generic;
using System.Text;
using Adamo;

namespace Shooter
{
    public class Enemy : Character
    {
        float health = 30;
        public override float Health
        {
            get { return health; }
            set 
            {
                if (health > value) IsHit = true;
                health = value;
            }
        }

        public Enemy(CharacterData Data, string Color) : base(Data, Color)
        {
        }

        public override void Update() 
        {
            if (Health <= 0) //If it has no more healt it is dead an should be removed
            {
				((Shooter)Engine.CurrentScene).Characters.Remove(this);
                Player.PlayerScore += 100;
            }

			//AI here|
			//OOOOOOO|
			//OOOOOOOV
			float closestDist = float.MaxValue;
			Character closestChar = null;
			for (int i = 0; i < Engine.Game.Characters.Count; i++) //Finds closest Enemy
			{
				Character character = Engine.Game.Characters[i];
				float dist = ((character.Position + character.Size / 2) - (Position + Size / 2)).Length;
				if (IsEnemyTeam (character) && closestDist > dist)
				{
					closestDist = dist;
					closestChar = character;
				}
			}

			//Walk toward closest enemy
			if (closestChar != null)
			{
				float direction = closestChar.Position.X - Position.X;
				if (direction > 0) MoveRight();
				else if (direction < 0) MoveLeft();
			}
			//Attack all enemies that are close enough
			for (int i = 0; i < Engine.Game.Characters.Count; i++)
			{
				Character character = Engine.Game.Characters[i];
				if (IsEnemyTeam(character) && ((character.Position + character.Size / 2) - (Position + Size / 2)).Length < 100)
				{
					character.Health -= 50 * (float)FrameTime.Elapsed.Seconds;
				}
			}

            base.Update();
        }
        public override void Draw() 
        {
            base.Draw();
        }
    }
}
