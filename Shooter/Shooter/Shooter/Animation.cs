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
        public event EventHandler OnFinished;

        private float timer = 0;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Animation()
        {
        }

        /// <summary>
        /// Value constructor which receives a value and adds it to the Rectangles range
        /// </summary>
        /// <param name="Rectangles"></param>
        public Animation(RectangleF[] Rectangles)
        {
            animationFrames.AddRange(Rectangles);
        }
        
        /// <summary>
        /// Makes an animation with 1 frame
        /// </summary>
        /// <param name="Rect">Rectangle float value</param>
        public void AddFrame(RectangleF Rect)
        {
            animationFrames.Add(Rect);
        }

        /// <summary>
        /// Makes a new animation with multiple frames
        /// </summary>
        public void AddFrames(RectangleF[] Frames)
        {
            animationFrames.AddRange(Frames);
        }

        /// <summary>
        /// Makes an animation with multiple frames based upon values you input. 
        /// </summary>
        /// <param name="SpriteSize">Height/width of the frames</param>
        /// <param name="SpriteFrames">Height/width of the texture 'grid'</param>
        /// <param name="StartFrame">First frame of the animation</param>
        /// <param name="StopFrame">Last frame of the animation</param>
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

        /// <summary>
        /// Clears the animationFrames
        /// </summary>
        public void Clear()
        {
            animationFrames.Clear();
        }

        /// <summary>
        /// Selects the next frame in the animationFrames list
        /// </summary>
        public void NextFrame()
        {
            CurrentFrame++;

            if (CurrentFrame >= animationFrames.Count)
            {
                if (OnFinished != null)
                {
                    Animating = false;
                    OnFinished(this, EventArgs.Empty);
                }

                if (Loop) CurrentFrame = 0;
            }
        }

        /// <summary>
        /// Keeps the animation going
        /// </summary>
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
        /// Get the current frame of the animation
        /// </summary>
        /// <returns></returns>
        public RectangleF GetFrame()
        {
            return animationFrames[CurrentFrame];
        }
    }
}
