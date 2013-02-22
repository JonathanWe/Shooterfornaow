using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    public class Character
    {
        Texture2D headTexture;
        Texture2D bodyTexture;
        Texture2D handTexture;
        Texture2D feetTexture;

        Point headSize = new Point(64, 64);
        Point bodySize = new Point(64, 64);
        Point handSize = new Point(64, 64);
        Point feetSize = new Point(64, 64);

        Vector2 headOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 bodyOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 handOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 feetOffsetPositionOrginal = new Vector2(0, 0);

        Vector2 headOffset = new Vector2(0, 0);
        Vector2 bodyOffset = new Vector2(0, 0);
        Vector2 handOffset = new Vector2(0, 0);
        Vector2 feetOffset = new Vector2(0, 0);

        public Character(string Head, string Body, string Hand, string Feet) 
        {
            headTexture = Engine.Content.Load<Texture2D>(Head);
            bodyTexture = Engine.Content.Load<Texture2D>(Body);
            handTexture = Engine.Content.Load<Texture2D>(Hand);
            feetTexture = Engine.Content.Load<Texture2D>(Feet);
        }

        public void Update(bool Walking, bool Jumping) { }
        public void Draw(Vector2 Position) 
        {
            Engine.SpriteBatch.Draw(headTexture, new Rectangle((int)(Position.X + headOffset.X), (int)(Position.Y + headOffset.Y), headSize.X, headSize.Y), Color.White);
            Engine.SpriteBatch.Draw(bodyTexture, new Rectangle((int)(Position.X + bodyOffset.X), (int)(Position.Y + bodyOffset.Y), bodySize.X, bodySize.Y), Color.White);
            Engine.SpriteBatch.Draw(handTexture, new Rectangle((int)(Position.X + handOffset.X), (int)(Position.Y + handOffset.Y), handSize.X, handSize.Y), Color.White);
            Engine.SpriteBatch.Draw(feetTexture, new Rectangle((int)(Position.X + feetOffset.X), (int)(Position.Y + feetOffset.Y), feetSize.X, feetSize.Y), Color.White);
        }

        public static Character Player() 
        {
            return new Character("", "", "", "");
        }
    }
}
