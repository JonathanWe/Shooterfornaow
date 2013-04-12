﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace Shooter
{
    public class BackgroundSound
    {

        Song Sound;
        bool songstart = false;
        ContentManager Content = Engine.Content;

        /// <summary>
        /// Loads the backgroundsound
        /// </summary>
        public void Load()
        {
            Sound = Content.Load<Song>("Sounds/Background sounds/BackgroundSound");
            MediaPlayer.IsRepeating = true;
        }

        /// <summary>
        /// Keeps checking if the backgroundsound is playing, if not it will start it.
        /// </summary>
        public void Update()
        {
            if (!songstart)
            {
                MediaPlayer.Play(Sound);
                songstart = true;
            }
        }
    }
}
