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
        Point bodySize = new Point(64, 100);
        Point handSize = new Point(70, 40);
        Point feetSize = new Point(64, 24);

        Vector2 headOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 bodyOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 handOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 feetOffsetPositionOrginal = new Vector2(0, 0);

        Vector2 headOffset = new Vector2(0, 0);
        Vector2 bodyOffset = new Vector2(0, 60);
        Vector2 handOffset = new Vector2(40, 100);
        Vector2 feetOffset = new Vector2(5, 170);
        Vector2 gunOrigin = new Vector2(-88, 20);

        public Vector2 HeadOffset { get { return headOffset; } }
        public Vector2 BodyOffset { get { return bodyOffset; } }
        public Vector2 HandOffset { get { return handOffset; } }
        public Vector2 FeetOffset { get { return feetOffset; } }
        public Vector2 GunOrigin { get { return gunOrigin; } }

        public Character(string Head, string Body, string Hand, string Feet)
        {
            headTexture = Engine.Content.Load<Texture2D>(Head);
            bodyTexture = Engine.Content.Load<Texture2D>(Body);
            handTexture = Engine.Content.Load<Texture2D>(Hand);
            feetTexture = Engine.Content.Load<Texture2D>(Feet);
        }

        public void Update(bool Walking, bool Jumping) { }
        public void Draw(Vector2 Position, float GunDegree) 
        {
            Engine.SpriteBatch.Draw(headTexture, new Rectangle((int)(Position.X + headOffset.X), (int)(Position.Y + headOffset.Y), headSize.X, headSize.Y), Color.White);
            Engine.SpriteBatch.Draw(bodyTexture, new Rectangle((int)(Position.X + bodyOffset.X), (int)(Position.Y + bodyOffset.Y), bodySize.X, bodySize.Y), Color.White);
            Engine.SpriteBatch.Draw(handTexture, new Rectangle((int)(Position.X + handOffset.X), (int)(Position.Y + handOffset.Y), handSize.X, handSize.Y), null, Color.White, GunDegree, gunOrigin * (new Vector2(handTexture.Width, handTexture.Height) / new Vector2(handSize.X, handSize.Y)), SpriteEffects.None, 0);
            Engine.SpriteBatch.Draw(feetTexture, new Rectangle((int)(Position.X + feetOffset.X), (int)(Position.Y + feetOffset.Y), feetSize.X, feetSize.Y), Color.White);
        }

        public static Character Player() 
        {
            return new Character("Pl_Head", "Pl_Body", "Gun", "Pl_Feet");
        }
    }
}
