﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    public class Player
    {
        public int Healt = 100;
        public Weapon Weapon;
        public Vector2 Position { get { return character.Position; } set { character.Position = value; } }
        public Vector2 Size;

        Character character;

        public void Load() 
        {
            character = Character.Player();
        }
        public void Update() 
        {
            //Input
            if (Engine.KeyDown(Keys.Left) | Engine.KeyDown(Keys.A))
            {
                character.MoveLeft();
            }
            if (Engine.KeyDown(Keys.Right) || Engine.KeyDown(Keys.D))
            {
                character.MoveRight();
            }
            if ((Engine.KeyDown(Keys.Up) || Engine.KeyDown(Keys.W)))
            {
                character.Jump();
            }

            character.Update(true, false);
        }
        public void Draw() 
        {
            character.Draw(Position);
        }
    }
}