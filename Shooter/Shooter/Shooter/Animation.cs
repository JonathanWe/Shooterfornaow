using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace Shooter
{
    public class Animation
    {
        List<RectangleF> animationFrames = new List<RectangleF>();

        public bool Animating = false;
        public float AnimationSpeed = 1.0f;
        public bool Loop = true;
        public int CurrentFrame = 0;

        public Animation()
        {
        }
        public Animation(RectangleF[] Rectangles)
        {
            animationFrames.AddRange(Rectangles);
        }

        public void AddFrame(RectangleF Rect)
        {
            animationFrames.Add(Rect);
        }
        public void AddFrames(RectangleF[] Frames)
        {
            animationFrames.AddRange(Frames);
        }
        public void AddFrames(Point SpriteSize, Point SpriteFrames, int StartFrame, int StopFrame)
        {
            int x = 0;
            int y = 0;
            int frameWidth = SpriteSize.X / SpriteFrames.X;
            int frameHeight = SpriteSize.Y / SpriteFrames.Y;

            for (int i = StartFrame; i <= StopFrame; i++)
            {
                y = 0;

                x = i - 1;
                while (x > SpriteFrames.X)
                {
                    x -= SpriteFrames.X;
                    y++;
                }
                animationFrames.Add(new RectangleF(frameWidth * x, frameHeight * y, frameWidth, frameHeight));
            }
        }
        public void Clear()
        {
            animationFrames.Clear();
        }
        public void NextFrame()
        {
            CurrentFrame++;
            if (CurrentFrame >= animationFrames.Count)
            {
                CurrentFrame = 0;
            }
        }
        float timer = 0;
        public void Update()
        {
            if (Animating)
            {
                timer += Engine.GameTimeInSec;
                if (timer >= AnimationSpeed)
                {
                    NextFrame();
                    timer = 0;
                }
            }
        }
        /// <summary>
        /// Get the cuurent frame of the animation
        /// </summary>
        /// <returns></returns>
        public RectangleF GetFrame()
        {
            return animationFrames[CurrentFrame];
        }
    }
}
