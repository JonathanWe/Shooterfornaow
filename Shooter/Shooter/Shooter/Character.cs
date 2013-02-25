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

        Point headSize = new Point(80, 80);
        Point bodySize = new Point(64, 100);
        Point handSize = new Point(70, 40);
        Point feetSize = new Point(90, 30);

        Vector2 headOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 bodyOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 handOffsetPositionOrginal = new Vector2(0, 0);
        Vector2 feetOffsetPositionOrginal = new Vector2(0, 0);

        internal Vector2 headOffset = new Vector2(2, 0);
        internal Vector2 bodyOffset = new Vector2(0, 45);
        internal Vector2 handOffset = new Vector2(40, 85);
        internal Vector2 feetOffset = new Vector2(5, 155);
        Vector2 gunOrigin = new Vector2(-88, 20);
        Vector2 boundingBox = new Vector2(110, 185);

        public Vector2 HeadOffset { get { return headOffset; } }
        public Vector2 BodyOffset { get { return bodyOffset; } }
        public Vector2 HandOffset { get { return handOffset; } }
        public Vector2 FeetOffset { get { return feetOffset; } }
        public Vector2 GunOrigin { get { return gunOrigin; } }

        public Vector2 Position;
        public Vector2 Size { get { return boundingBox; } }
        public Vector2 Acceleration = new Vector2();

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
            Engine.SpriteBatch.Draw(headTexture, new Rectangle((int)(Position.X + headOffset.X), (int)(Position.Y + headOffset.Y), headSize.X, headSize.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
            Engine.SpriteBatch.Draw(bodyTexture, new Rectangle((int)(Position.X + bodyOffset.X), (int)(Position.Y + bodyOffset.Y), bodySize.X, bodySize.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.11f);
            Engine.SpriteBatch.Draw(handTexture, new Rectangle((int)(Position.X + handOffset.X), (int)(Position.Y + handOffset.Y), handSize.X, handSize.Y), null, Color.White, GunDegree, gunOrigin * (new Vector2(handTexture.Width, handTexture.Height) / new Vector2(handSize.X, handSize.Y)), SpriteEffects.None, 0.2f);
            Engine.SpriteBatch.Draw(feetTexture, new Rectangle((int)(Position.X + feetOffset.X), (int)(Position.Y + feetOffset.Y), feetSize.X, feetSize.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.1f);
        }

        public static Character Player() 
        {
            return new Character("Pl_Head", "Pl_Body", "Gun", "Pl_Feet");
        }
    }
}
